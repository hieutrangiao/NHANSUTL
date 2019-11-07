using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP.Base.BaseCommon
{
    public class VinaList<T> : List<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ICloneable where T : BusinessObject
    {

        #region Constant
        public const String cstRelationForeign = "Foreign";
        public const String cstRelationParent = "Parent";
        public const String cstRelationSwitcher = "Switcher";
        public const String cstRelationNone = "None";
        #endregion

        #region variables
        public ERPModuleEntities Entity { get; set; }
        public String Relation { get; set; }
        public String ParentTableName { get; set; }
        public String ItemTableName { get; set; }
        public VinaGridControl GridControl;
        public String ItemTableForeignKey { get; set; }
        public IList<T> OriginalList { get; set; }
        public bool IsEndCurrentEdit = false;
        public bool IsInputingNewRow = false;
        public int CurrentIndex
        {
            get
            {
                if (GridView != null)
                {
                    return GridView.GetDataSourceRowIndex(GridView.FocusedRowHandle);
                }
                return -1;
            }
        }
        public GridView GridView
        {
            get
            {
                if (GridControl != null)
                {
                    if (GridControl.Views[0] is GridView)
                    {
                        return (GridView)GridControl.Views[0];
                    }
                    return null;
                }
                return null;
            }
        }
        #endregion

        #region Constructor
        public VinaList()
        {
            Entity = new ERPModuleEntities();
            OriginalList = (IList<T>)new List<T>();
        }
        #endregion

        #region Init
        public void InitVinaList(ERPModuleEntities ent, String strParentTableName, String strItemTableName, String strRelation)
        {
            Entity = ent;
            VinaDbUtil dbUtil = new VinaDbUtil();
            ParentTableName = strParentTableName;
            ItemTableName = strItemTableName;
            Relation = strRelation;
            switch (strRelation)
            {
                case cstRelationForeign:
                    {
                        String strParentTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(ParentTableName);
                        String strItemTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(ItemTableName);
                        ItemTableForeignKey = "FK_" + strParentTablePrimaryColumn;
                        break;
                    }
                case cstRelationParent:
                    {
                        ItemTableForeignKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ParentID";
                        break;
                    }
            }
        }

        public virtual void InitVinaListGridControl()
        {
            String strGridControlName = "fld_dgc" + ItemTableName;
            InitVinaListGridControl(strGridControlName);
        }

        public virtual void InitVinaListGridControl(String strGridControlName)
        {
            if (Entity.Module.Controls.ContainsKey(strGridControlName))
            {
                InitVinaListGridControl((VinaGridControl)Entity.Module.Controls[strGridControlName]);
            }
        }

        public virtual void InitVinaListGridControl(VinaGridControl gridControl)
        {
            GridControl = gridControl;
        }

        public void SetDefaultListAndRefreshGridControl()
        {
            this.Clear();
            this.OriginalList.Clear();
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
            }
        }
        #endregion

        #region Invalidate
        public virtual void Invalidate(int iObjectID)
        {
            //Invalidate lookup edit columns to reflect all changes of lookup table
            //if (GridControl != null)
            //    GridControl.InvalidateLookupEditColumns();

            VinaDbUtil dbUtil = new VinaDbUtil();
            BaseBusinessController objItemController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");
            DataSet ds = new DataSet();

            if (Relation.Equals(cstRelationForeign))
            {
                ds = objItemController.GetAllDataByForeignColumn(ItemTableForeignKey, iObjectID);

            }
            else if (Relation.Equals(cstRelationParent))
            {
                ds = objItemController.GetAllObjectsByObjectParentID(iObjectID);
            }
            else if (Relation.Equals(cstRelationNone))
            {
                ds = objItemController.GetAllObjects();
            }
            DataView view = ds.Tables[0].DefaultView;
            string ID = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ID";
            view.Sort = ID + " ASC";
            DataTable sortIDData = view.ToTable();
            ds.Clear();
            ds.Merge(sortIDData);
            Invalidate(ds);
        }

        public virtual void Invalidate(DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                Invalidate(ds.Tables[0]);
            }
        }
        public virtual void Invalidate(DataTable table)
        {
            this.Clear();
            OriginalList.Clear();
            BaseBusinessController objItemController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");

            //Invalidate lookup edit columns to reflect all changes of lookup table
            //if (GridControl != null)
            //    GridControl.InvalidateLookupEditColumns();

            foreach (DataRow row in table.Rows)
            {
                T objT = (T)objItemController.GetObjectFromDataRow(row);
                this.Add(objT);
                OriginalList.Add((T)objT.Clone());
            }
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < Count)
                    {
                        GridViewFocusRow(CurrentIndex);
                    }
                    else
                    {
                        GridViewFocusRow(0);
                    }
                }
            }
        }

        /// <summary>
        /// Invalidate based on a list 
        /// </summary>
        /// <param name="lst">Object list</param>
        public virtual void Invalidate(IList<T> lst)
        {
            //Invalidate lookup edit columns to reflect all changes of lookup table
            //if (GridControl != null)
            //    GridControl.InvalidateLookupEditColumns();

            this.Clear();
            foreach (T obj in lst)
            {
                this.Add((T)obj.Clone());
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < Count)
                    {
                        GridViewFocusRow(CurrentIndex);
                    }
                    else
                    {
                        GridViewFocusRow(0);
                    }
                }
            }
        }
        #endregion

        #region Save List, Delete List to database
        public virtual void SaveItemObjects()
        {
            try
            {
                EndCurrentEdit();

                VinaDbUtil dbUtil = new VinaDbUtil();
                String strItemTablePrimaryKey = dbUtil.GetTablePrimaryColumn(ItemTableName);
                BaseBusinessController objItemsController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");
                int iParentObjectID = GetParentObjectID();

                //Create or update
                foreach (T objT in this)
                {
                    int iItemObjectID = (int)dbUtil.GetPropertyValue(objT, strItemTablePrimaryKey);

                    if (iItemObjectID == 0 && Relation == cstRelationForeign)
                    {
                        if (iParentObjectID > 0)
                        {
                            if (dbUtil.GetPropertyValue(objT, ItemTableForeignKey) != null)
                                dbUtil.SetPropertyValue(objT, ItemTableForeignKey, iParentObjectID);
                        }
                    }

                    bool isUpdate = iItemObjectID > 0;
                    if (isUpdate)
                    {
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AAUpdatedUser, VinaApp.CurrentUserName);
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AAUpdatedDate, DateTime.Now);
                        objItemsController.UpdateObject(objT);
                    }
                    else
                    {
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AACreatedUser, VinaApp.CurrentUserName);
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AACreatedDate, DateTime.Now);
                        iItemObjectID = objItemsController.CreateObject(objT);
                    }
                }

                //Delete items
                foreach (T obj in OriginalList)
                {
                    int iItemObjectID = (int)dbUtil.GetPropertyValue(obj, strItemTablePrimaryKey);
                    if (iItemObjectID > 0 && !this.Exists(strItemTablePrimaryKey, iItemObjectID))
                    {
                        objItemsController.DeleteObject(iItemObjectID);
                        //Entity.DeleteObjectRelations(ItemTableName, iItemObjectID);
                    }
                }
                //Invalidate original list
                OriginalList.Clear();
                foreach (T obj in this)
                    OriginalList.Add((T)obj.Clone());
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.ToString(), CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        public object Clone()
        {
            VinaList<T> result = new VinaList<T>();
            result.InitVinaList(Entity, ParentTableName, ItemTableName, Relation);
            result.ItemTableForeignKey = ItemTableForeignKey;
            foreach (T obj in this)
            {
                result.Add((T)obj.Clone());
            }
            foreach (T obj in OriginalList)
            {
                result.OriginalList.Add((T)obj.Clone());
            }
            return result;
        }

        public virtual void GridViewFocusRow(int iRowHandle)
        {
            if (GridView != null && GridView.FocusedRowHandle != iRowHandle)
            {
                GridView.FocusedRowHandle = iRowHandle;
            }
        }

        public virtual void EndCurrentEdit()
        {
            if (GridView != null)
            {
                IsEndCurrentEdit = true;
                GridView.FocusedRowHandle = -1;
            }
        }

        public int GetParentObjectID()
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            int iParentObjectID = 0;
            if (!String.IsNullOrEmpty(ParentTableName))
            {
                String strMainTableName = String.Empty;
                if (Entity.MainObject != null)
                {
                    strMainTableName = VinaUtil.GetTableNameFromBusinessObject(Entity.MainObject);
                }
                string strParentTablePrimaryKey = dbUtil.GetTablePrimaryColumn(ParentTableName);
                if (ParentTableName == strMainTableName)
                {
                    iParentObjectID = dbUtil.GetPropertyIntValue(Entity.MainObject, strParentTablePrimaryKey);
                }
            }
            return iParentObjectID;
        }

        public virtual bool Exists(String strPropertyName, object objPropertyValue)
        {
            if (this.PosOf(strPropertyName, objPropertyValue) >= 0)
                return true;
            return false;
        }

        public virtual int PosOf(String strPropertyName, object objPropertyValue)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            for (int i = 0; i < this.Count; i++)
            {
                object objValue = dbUtil.GetPropertyValue((T)this[i], strPropertyName);
                if (objPropertyValue.Equals(objValue))
                    return i;
            }
            return -1;
        }

        public virtual void RemoveSelectedRowObjectFromList()
        {
            if (GridView != null && GridView.FocusedRowHandle >= 0)
            {
                RemoveObjectFromList(CurrentIndex);
            }
        }

        public virtual void RemoveObjectFromList(int iIndex)
        {
            if (this.Count > iIndex)
            {
                this.RemoveAt(iIndex);
            }
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
            }
            if (this.Count > 0)
            {
                if (this.Count > GridView.FocusedRowHandle)
                    GridViewFocusRow(GridView.FocusedRowHandle);
                else
                    GridViewFocusRow(this.Count - 1);
            }
        }
    }
}
