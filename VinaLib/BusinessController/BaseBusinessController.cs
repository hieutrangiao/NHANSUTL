using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class BaseBusinessController
    {
        protected DALBaseProvider dal;

        public BaseBusinessController()
        {
            this.dal = new DALBaseProvider();
        }

        public BaseBusinessController(string strTableName, Type objType)
        {
            this.dal = new DALBaseProvider(strTableName, objType);
        }

        public BaseBusinessController(Type objType)
        {
            this.dal = new DALBaseProvider(objType.Name.Substring(0, objType.Name.Length - 4), objType);
        }

        public int GetMaxID()
        {
            return this.dal.GetMaxID() + 1;
        }

        public virtual int CreateObject(BusinessObject obj)
        {
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            DateTime currentServerDate = vinaDbUtil.GetCurrentServerDate();
            vinaDbUtil.SetPropertyValue(obj, "AACreatedDate", (object)currentServerDate);
            int iObjectID = this.dal.CreateObject((object)obj);
            this.dal.SetValueToPrimaryColumn((object)obj, iObjectID);
            return iObjectID;
        }

        public virtual int CreateObject(BusinessObject obj, int iObjectID)
        {
            if (this.IsExist(iObjectID))
                return -1;
            this.dal.SetValueToPrimaryColumn((object)obj, iObjectID);
            return this.dal.CreateObject((object)obj);
        }

        public virtual int CreateObject(BusinessObject obj, DbTransaction transaction)
        {
            int iObjectID = this.dal.CreateObject((object)obj, transaction);
            this.dal.SetValueToPrimaryColumn((object)obj, iObjectID);
            return iObjectID;
        }

        public virtual int UpdateObject(BusinessObject obj)
        {
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            DateTime currentServerDate = vinaDbUtil.GetCurrentServerDate();
            vinaDbUtil.SetPropertyValue(obj, "AAUpdatedDate", (object)currentServerDate);
            return this.dal.UpdateObject((object)obj);
        }

        public virtual int UpdateObject(BusinessObject obj, DbTransaction transaction)
        {
            return this.dal.UpdateObject((object)obj, transaction);
        }

        public virtual void DeleteObject(int iObjectID)
        {
            this.dal.DeleteObject(iObjectID);
        }

        public virtual void DeleteObject(int iObjectID, DbTransaction transaction)
        {
            this.dal.DeleteObject(iObjectID, transaction);
        }

        public void DeleteAllObjects()
        {
            this.dal.DeleteAllObjects();
        }

        public virtual void DeleteByForeignColumn(string strForeignColumn, object objForeignColumnValue)
        {
            this.dal.DeleteByForeignColumn(strForeignColumn, objForeignColumnValue);
        }

        public virtual object GetObjectByID(int iObjectID)
        {
            return this.dal.GetObjectById(iObjectID);
        }

        public virtual DataSet GetDataSetByID(int iObjectID)
        {
            return this.dal.GetDataSetByID(iObjectID);
        }

        public virtual object GetDeletedObjectByID(int iObjectID)
        {
            return this.dal.GetDeletedObjectByID(iObjectID);
        }

        public virtual string GetObjectNameByID(int iObjectID)
        {
            return this.dal.GetObjectNameByID(iObjectID);
        }

        public virtual string GetObjectNoByID(int iObjectID)
        {
            return this.dal.GetObjectNoByID(iObjectID);
        }

        public virtual object GetObjectByName(string strObjectName)
        {
            return this.dal.GetObjectByName(strObjectName);
        }

        public virtual object GetObjectByNo(string strObjectNo)
        {
            return this.dal.GetObjectByNo(strObjectNo);
        }

        public virtual int GetObjectIDByName(string strObjectName)
        {
            return this.dal.GetObjectIDByName(strObjectName);
        }

        public virtual int GetObjectIDByNo(string strObjectNo)
        {
            return this.dal.GetObjectIDByNo(strObjectNo);
        }

        public virtual DataSet GetAllObjects()
        {
            return this.dal.GetAllObject();
        }

        public virtual DataSet GetObjectsForDataLookup(string[] arrColumns, int iMaxResults)
        {
            string str = string.Format("Select TOP({0}) ", (object)iMaxResults);
            foreach (string arrColumn in arrColumns)
                str += string.Format("[{0}],", (object)arrColumn);
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(str.Remove(str.Length - 1, 1) + string.Format(" FROM [{0}] WHERE [AAStatus]='Alive'", (object)this.dal.TableName)));
        }

        public virtual DataSet GetObjectsByIDForDataLookup(string[] arrColumns, int iObjectID)
        {
            string str = "Select ";
            string tablePrimaryColumn = new VinaDbUtil().GetTablePrimaryColumn(this.dal.TableName);
            foreach (string arrColumn in arrColumns)
                str += string.Format("[{0}],", (object)arrColumn);
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(str.Remove(str.Length - 1, 1) + string.Format(" FROM [{0}] WHERE [{1}]={2} AND [AAStatus]='Alive'", (object)this.dal.TableName, (object)tablePrimaryColumn, (object)iObjectID)));
        }

        public virtual DataSet GetObjectsForDataLookup(string[] arrColumns, int iMaxResults, string strCondition)
        {
            string str = string.Format("Select TOP({0}) ", (object)iMaxResults);
            foreach (string arrColumn in arrColumns)
                str += string.Format("[{0}],", (object)arrColumn);
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(str.Remove(str.Length - 1, 1) + string.Format(" FROM [{0}] WHERE [AAStatus]='Alive'", (object)this.dal.TableName) + " AND " + strCondition));
        }

        public virtual DataSet GetDataSet(string strQuery)
        {
            return this.dal.GetDataSet(strQuery);
        }

        public virtual object GetDataObject(string spName, params object[] values)
        {
            return this.dal.GetDataObject(spName, values);
        }

        public virtual IList GetListFromDataSet(DataSet ds)
        {
            return (IList)null;
        }

        public virtual object GetFirstObject()
        {
            return this.dal.GetFirstObject();
        }

        public virtual int GetFirstObjectID()
        {
            try
            {
                object firstObject = this.GetFirstObject();
                if (firstObject != null)
                    return Convert.ToInt32(this.dal.GetPrimaryColumnValue(firstObject));
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public virtual object GetObjectFromDataRow(DataRow row)
        {
            return this.dal.GetObjectFromDataRow(row);
        }

        public DataRow GetDataRowFromBusinessObject(DataRow row, BusinessObject obj)
        {
            foreach (DataColumn column in (InternalDataCollectionBase)row.Table.Columns)
            {
                PropertyInfo property = obj.GetType().GetProperty(column.ColumnName);
                if (property != null)
                    row[column.ColumnName] = property.GetValue((object)obj, (object[])null);
            }
            return row;
        }

        public object GetRowCellValue(DataRow row, string columnName)
        {
            object obj = (object)null;
            if (row[columnName] != DBNull.Value)
                obj = row[columnName];
            return obj;
        }

        public virtual List<BusinessObject> GetListBusinessObjects()
        {
            List<BusinessObject> businessObjectList = new List<BusinessObject>();
            DataSet allObjects = this.GetAllObjects();
            if (allObjects.Tables.Count > 0)
            {
                foreach (DataRow row in (InternalDataCollectionBase)allObjects.Tables[0].Rows)
                {
                    BusinessObject objectFromDataRow = (BusinessObject)SqlDatabaseHelper.GetObjectFromDataRow(row, this.dal.ObjectType);
                    businessObjectList.Add(objectFromDataRow);
                }
            }
            return businessObjectList;
        }

        public virtual DataSet GetAllDataByForeignColumn(string strForeignColumnName, object objForeignColumnValue)
        {
            return this.dal.GetAllDataByForeignColumn(strForeignColumnName, objForeignColumnValue);
        }

        public virtual BusinessObject GetFirstObjectByForeignColumn(string strForeignColumnName, object objForeignColumnValue)
        {
            return (BusinessObject)this.dal.GetSingleObject(this.GetAllDataByForeignColumn(strForeignColumnName, objForeignColumnValue).Tables[0]);
        }

        public virtual DataSet GetAllObjectsByObjectParentID(int iObjectParentID)
        {
            return this.dal.GetAllObjectsByObjectParentID(iObjectParentID);
        }

        public void DeleteAllObjectsByObjectParentID(int iObjectParentID)
        {
            this.dal.DeleteAllObjectsByObjectParentID(iObjectParentID);
        }

        public bool IsExist(int iObjectID)
        {
            return this.GetObjectByID(iObjectID) != null;
        }

        public bool IsExistObjectName(string strObjectName)
        {
            return this.GetObjectByName(strObjectName) != null;
        }

        public bool IsExist(string strObjectNo)
        {
            return this.GetObjectByNo(strObjectNo) != null;
        }

        public virtual DataSet GetAllFromOwner(string strOwnerTable, int iOwnerID, string strSwitcherTable)
        {
            return this.dal.GetMembersFromOwner(strOwnerTable, iOwnerID, this.dal.TableName, strSwitcherTable);
        }

        public virtual void DeleteFromOwner(string strOwnerTable, int iOwnerID, string strSwitcherTable)
        {
            this.dal.DeleteMembersFromOwner(strOwnerTable, iOwnerID, this.dal.TableName, strSwitcherTable);
        }

        public virtual DataSet SearchObject(object objSearch)
        {
            return this.dal.SearchObject(objSearch);
        }

        public virtual int GetRecordsCount()
        {
            int num = -1;
            DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("select count(" + (this.dal.TableName.Substring(0, this.dal.TableName.Length - 1) + "ID") + ") as count from " + this.dal.TableName + " where AAStatus = 'Alive' ")));
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
            return num;
        }
    }
}
