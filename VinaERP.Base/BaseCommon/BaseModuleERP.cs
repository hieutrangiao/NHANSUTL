using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using VinaERP.Base.UI;
using VinaERP.Common.Constant.IC;
using VinaLib;

namespace VinaERP
{
    public class BaseModuleERP : BaseModule, IBaseModuleERP
    {
        public ModuleParentScreen ParentScreen { get; set; }

        public ERPModuleEntities CurrentModuleEntity { get; set; }

        public int CurrentObjectID { get; set; }

        protected DataTable ErrorTable = new DataTable();

        protected GuiErrorMessage ErrorMessageScreen;

        public string MainTablePrefix { get; set; }

        private String MainTableName { get; set; }
        public BaseModuleERP()
        {
            ParentScreen = new ModuleParentScreen();
            ParentScreen.Module = this;
            ParentScreen.MdiParent = VinaApp.MainScreen;
        }

        public virtual void InitializeModule()
        {

            STModulesController objModulesController = new STModulesController();

            CurrentModuleID = objModulesController.GetObjectIDByName(CurrentModuleName);

            CurrentModuleEntity.InitModuleEntity();

            InitModuleToolbarEvents();

            InitializeScreens();

            CurrentModuleEntity.InitGridControlInVinaList();

            MainTableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);

            MainTablePrefix = MainTableName.Substring(0, MainTableName.Length - 1);

        }

        public override string GetAssemblyName()
        {
            return "VinaERP";
        }

        public override Type GetClassType(String strClassName)
        {
            return BaseClassFactory.GetClassType(strClassName);
        }

        public virtual void InitializeScreens()
        {
            STScreensController objScreensController = new STScreensController();
            DataSet dsScreens = objScreensController.GetAllDataByForeignColumn("FK_STModuleID", CurrentModuleID);
            if (dsScreens.Tables.Count > 0)
            {
                foreach (DataRow row in dsScreens.Tables[0].Rows)
                {
                    STScreensInfo objSTScreensInfo = (STScreensInfo)objScreensController.GetObjectFromDataRow(row);
                    if (!objSTScreensInfo.STScreenIsVisible)
                        return;
                    if (objSTScreensInfo.STScreenCode.StartsWith("DM") || objSTScreensInfo.STScreenCode.StartsWith("SM"))
                        InitializeNewScreen(objSTScreensInfo);
                }
            }
            dsScreens.Dispose();
        }

        private void InitializeNewScreen(STScreensInfo objScreensInfo)
        {
            VinaERPScreen screen = VinaERPScreenFactory.GetScreen(this.CurrentModuleName, objScreensInfo.STScreenCode);
            if (screen == null)
                return;

            screen.Module = this;
            screen.ScreenInfo = objScreensInfo;
            screen.ScreenID = objScreensInfo.STScreenID;
            screen.Text = objScreensInfo.STScreenDesc;

            screen.InitializeScreen(objScreensInfo);

            Screens.Add(screen);

            InitializeScreenControls(screen);
        }

        private void InitializeScreenControls(VinaERPScreen screen)
        {
            screen.AddControlsToParentScreen();
        }

        protected void SetDefaultEmployee()
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "FK_HREmployeeID", VinaApp.CurrentUserInfo.FK_HREmployeeID);
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo objHREmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(VinaApp.CurrentUserInfo.FK_HREmployeeID);
            if (objHREmployeesInfo != null)
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, String.Format("{0}EmployeePicture", MainTablePrefix), objHREmployeesInfo.HREmployeePicture);
                CurrentModuleEntity.UpdateMainObjectBindingSource();
            }
        }

        protected void InvalidateEmployee()
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            int employeeID = dbUtil.GetPropertyIntValue(CurrentModuleEntity.MainObject, "FK_HREmployeeID");
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo objHREmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(employeeID);
            if (objHREmployeesInfo != null)
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, String.Format("{0}EmployeePicture", MainTablePrefix), objHREmployeesInfo.HREmployeePicture);
                CurrentModuleEntity.UpdateMainObjectBindingSource();
            }
        }

        public void Show()
        {
            ParentScreen.ModuleParentScreen_Init();
            ParentScreen.ShowInTaskbar = false;

            if (VinaApp.OpenModules.ContainsKey(VinaApp.CurrentModuleName))
                ((BaseModuleERP)VinaApp.OpenModules[VinaApp.CurrentModuleName]).ParentScreen.WindowState = FormWindowState.Minimized;
            ParentScreen.Show();
            ParentScreen.Focus();
            //ActionInvalidate();

            //ParentScreen.ShowSearchResultsPanel();
            if (ParentScreen.IsExistsGridSearchResult() && Toolbar.CurrentObjectID <= 0)
            {
                //ResetSearch();
                Search();
            }
        }

        public virtual void Search()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                String strMainObjectControllerName = VinaUtil.GetBusinessControllerNameFromBusinessObject(CurrentModuleEntity.MainObject);
                String strMainObjectTableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                BaseBusinessController objCurrentObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectControllerName);
                Cursor.Current = Cursors.WaitCursor;

                string searchQuery = string.Empty;
                DataSet ds = GetSearchData();
                Toolbar.SetToolbar(ds);
                InvalidateAfterSearch(null, String.Empty);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        }

        public virtual void InvalidateAfterSearch(object sender, String strEventName)
        {
            Cursor.Current = Cursors.WaitCursor;

            Control searchResultControl = null;
            foreach (Control ctrl in Controls.Values)
            {
                if (ctrl.Tag == VinaScreen.SearchResultControl)
                {
                    searchResultControl = ctrl;
                    break;
                }
            }

            if (searchResultControl != null)
            {
                if (searchResultControl is GridControl)
                {
                    VinaSearchResultsGridControl.BindingSearchResultGridControl((DevExpress.XtraGrid.GridControl)searchResultControl, Toolbar.ObjectCollection);
                }
                //if (Toolbar.ObjectCollectionLength > 0 && !Toolbar.IsNewAction())
                //    Invalidate(Toolbar.CurrentObjectID);
            }
            Cursor.Current = Cursors.Default;
        }

        public virtual void ActionInvalidate()
        {
            Toolbar.Invalidate();
        }

        public virtual void ActionInvalidate(int objectID)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            string tableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            string primaryKey = dbUtil.GetTablePrimaryColumn(tableName);
            if (Toolbar.ObjectCollection != null)
            {
                for (int i = 0; i < Toolbar.ObjectCollection.Tables[0].Rows.Count; i++)
                {
                    if (objectID == Convert.ToInt32(Toolbar.ObjectCollection.Tables[0].Rows[i][primaryKey]))
                    {
                        Toolbar.CurrentIndex = i;
                        //FocusRowOfGridSearchResultByToolbarCurrentIndex();
                        return;
                    }
                }
            }

            //If can't find the object in toolbar's collection
            BaseBusinessController controller = BusinessControllerFactory.GetBusinessController(tableName + "Controller");
            if (controller != null)
            {
                DataSet ds = controller.GetDataSetByID(objectID);
                Toolbar.SetToolbar(ds);
                //InvalidateAfterSearch(null, String.Empty);
            }
        }



        public static void BindingSearchResultGridControl(GridControl gridControl, DataSet dsSearchResults)
        {
            if (dsSearchResults.Tables.Count <= 0)
                return;
            ((GridView)gridControl.ViewCollection[0]).OptionsBehavior.AutoPopulateColumns = false;
            gridControl.DataSource = (object)new BindingSource()
            {
                DataSource = (object)dsSearchResults.Tables[0]
            };
        }

        protected virtual DataSet GetSearchData()
        {
            String mainObjectTableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            BaseBusinessController objCurrentObjectController = BusinessControllerFactory.GetBusinessController(mainObjectTableName + "Controller");
            return objCurrentObjectController.GetAllObjects();
        }

        public virtual void Invalidate(int iObjectID)
        {
            string strTableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            BaseBusinessController objBaseBusinessController = BusinessControllerFactory.GetBusinessController(strTableName + "Controller");
            BusinessObject mainObject = (BusinessObject)objBaseBusinessController.GetObjectByID(iObjectID);
            if (mainObject != null)
            {
                CurrentModuleEntity.Invalidate(iObjectID);

                CurrentModuleEntity.MainObject.OldObject = (BusinessObject)CurrentModuleEntity.MainObject.Clone();

                InvalidateToolbar();
            }
            InvalidateEmployee();
        }

        public virtual void InvalidateToolbar()
        {
            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, true);
        }


        #region Toolbar Action

        public virtual void ActionCancel()
        {
            this.Toolbar.Cancel();
            this.ParentScreen.InvalidateToolbarAfterActionCancel();
            //this.SaveUserAudit("Nothing");
            //this.InvalidateFieldGroupControls("None");
            this.InvalidateToolbar();
            //if (this.Owner == null)
            //    return;
            //ModuleParentScreen parentScreen = this.Owner.ParentScreen;
            //this.Owner = (BaseModuleERP)null;
            //parentScreen.Activate();
        }

        public virtual void ActionNew()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Toolbar.New();
            this.ParentScreen.InvalidateToolbarAfterActionNew();

            //this.SaveUserAudit("Create");
            //this.InvalidateFieldGroupControls("New");
            //if (this.ParentScreen.IsObjectListExpanded)
            //    this.ParentScreen.CollapseObjectList();
            VinaUtil.GetTableNameFromBusinessObject(this.CurrentModuleEntity.MainObject);
            SetDefaultEmployee();
            Cursor.Current = Cursors.Default;
        }

        public virtual int ActionSave()
        {
            int iObjectID = 0;
            if (!this.Toolbar.IsNullOrNoneAction())
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!this.IsInvalidInput())
                {
                    using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        try
                        {
                            iObjectID = this.Toolbar.Save();
                            transactionScope.Complete();
                        }
                        catch (Exception ex)
                        {
                            transactionScope.Dispose();
                            int num = (int)MessageBox.Show(ex.ToString(), "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
                if (iObjectID > 0)
                {
                    ModuleAfterSaved(iObjectID);
                }
                Cursor.Current = Cursors.Default;
            }
            //if (this.Owner != null)
            //{
            //    ModuleParentScreen parentScreen = this.Owner.ParentScreen;
            //    this.Owner = (BaseModuleERP)null;
            //    parentScreen.Activate();
            //}
            return iObjectID;
        }

        public virtual void ActionEdit()
        {
            //if (ObjectIsEditingByOtherUser(this.Name, Toolbar.CurrentObjectID))
            //{
            //    return;
            //}

            if (Toolbar.Edit())
            {
                ParentScreen.InvalidateToolbarAfterActionEdit();
            }
            else
            {
                DevExpress.XtraBars.BarButtonItem barbtnEdit = (BarButtonItem)ParentScreen.GetToolbarButton(BaseToolbar.ToolbarButtonEdit);
                barbtnEdit.Down = false;
            }
        }

        public virtual void ActionComplete()
        {

        }

        public virtual void ActionPrint()
        {

        }

        public virtual void ActionApproved()
        {

        }
        #endregion

        public virtual void ModuleAfterSaved(int iObjectID)
        {
            ParentScreen.Focus();

            //Invalidate Toolbar button after save
            ParentScreen.InvalidateToolbarAfterActionSave();

            //Invalidate toolbar in the module's context
            InvalidateToolbar();

            //Invalidate controls
            //InvalidateFieldGroupControls(BaseToolbar.ModuleNone);

            //Invalidate search result control
            InvalidateSearchResultsControl(null, string.Empty);

            //Save User Audit is Nothing

            //Set modus action of toolbar to none
            Toolbar.ModuleAction = BaseToolbar.ModuleNone;
        }

        public void Close()
        {
            VinaApp.MainScreen.OpenModulesToolStrip.Items.RemoveByKey(CurrentModuleName);
            VinaApp.RemoveOpenedModule(CurrentModuleName);

            //Active last open modules
            if (VinaApp.MainScreen.OpenModulesToolStrip.Items.Count > 0)
            {
                int index = VinaApp.MainScreen.OpenModulesToolStrip.Items.Count - 1;
                String strModuleName = VinaApp.MainScreen.OpenModulesToolStrip.Items[index].Name;
                VinaApp.ShowModule(strModuleName);
            }
        }

        public VinaScreen GetDataMainScreen()
        {
            throw new NotImplementedException();
        }

        public VinaScreen GetDataSubScreen()
        {
            throw new NotImplementedException();
        }

        public VinaScreen GetSearchMainScreen()
        {
            throw new NotImplementedException();
        }

        public VinaScreen GetSearchResultScreen()
        {
            throw new NotImplementedException();
        }

        public VinaScreen InitializeScreen(string strScreenName, string strScreenNumber)
        {
            throw new NotImplementedException();
        }

        public DataSet GetLookupTableData(string lookupTableName)
        {
            return VinaApp.GetLookupTableData(lookupTableName);
        }

        public SortedList GetLookupTableCollection()
        {
            return VinaApp.LookupTables;
        }

        public SortedList<string, GELookupTablesInfo> GetLookupTableObjects()
        {
            return VinaApp.LookupTableObjects;
        }

        #region "Delegate Functions for Toolbar Events"
        /// <summary type="Toolbar">
        /// Initialize the delegate functions and events for toolbar buttons
        /// </summary>
        /// <functiontype>Toolbar Function</functiontype>
        public void InitModuleToolbarEvents()
        {
            BaseToolbar.InvalidateHandler InvalidateHandler = new BaseToolbar.InvalidateHandler(Invalidate);
            BaseToolbar.NewHandler NewHandler = new BaseToolbar.NewHandler(New);
            BaseToolbar.SaveHandler SaveHandler = new BaseToolbar.SaveHandler(Save);
            //BaseToolbar.DeleteHandler DeleteHandler = new BaseToolbar.DeleteHandler(Delete);
            //BaseToolbar.PrintHandler PrintHandler = new BaseToolbar.PrintHandler(Print);

            Toolbar.InvalidateEvent += InvalidateHandler;
            Toolbar.NewEvent += NewHandler;
            Toolbar.SaveEvent += SaveHandler;
            //Toolbar.DeleteEvent += DeleteHandler;
            //Toolbar.PrintEvent += PrintHandler;
        }

        public virtual void InvalidateSearchResultsControl(object sender, String strEventName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                VinaDbUtil dbUtil = new VinaDbUtil();
                String strMainTableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                string mainTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(strMainTableName);
                BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainTableName + "Controller");

                //Invalidate toolbar collection
                PropertyInfo[] properties;
                DataRow newRow;
                String strMainObjectTableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                int iObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, SqlDatabaseHelper.GetPrimaryKeyColumn(strMainObjectTableName)));

                if (Toolbar.ObjectCollection == null)
                {
                    DataSet ds = objMainObjectController.GetDataSetByID(iObjectID);
                    Toolbar.SetToolbar(ds);
                }
                else
                {
                    //if Toolbar.ModusAction is new, add new object to object collection of toolbar
                    if (Toolbar.ModuleAction == BaseToolbar.ModuleNew)
                    {
                        newRow = Toolbar.ObjectCollection.Tables[0].NewRow();
                        newRow = objMainObjectController.GetDataRowFromBusinessObject(newRow, CurrentModuleEntity.MainObject);
                        Toolbar.ObjectCollection.Tables[0].Rows.Add(newRow);
                        Toolbar.CurrentIndex = Toolbar.ObjectCollection.Tables[0].Rows.Count - 1;
                    }
                    else
                    {
                        //Update object in object collection of toolbar
                        properties = CurrentModuleEntity.MainObject.GetType().GetProperties();
                        int iCurrIndex = Toolbar.CurrentIndex;
                        for (int i = 0; i < properties.Length; i++)
                        {
                            if (Toolbar.ObjectCollection.Tables[0].Columns[properties[i].Name] != null)
                            {
                                Toolbar.ObjectCollection.Tables[0].Rows[iCurrIndex][properties[i].Name] = properties[i].GetValue(CurrentModuleEntity.MainObject, null);
                            }
                        }
                    }
                }


                //Invalidate search result control                
                Control searchResultControl = null;
                foreach (Control ctrl in Controls.Values)
                {
                    if (ctrl.Tag == VinaScreen.SearchResultControl)
                    {
                        searchResultControl = ctrl;
                        break;
                    }
                }

                if (searchResultControl != null)
                {
                    if (searchResultControl is GridControl)
                    {
                        VinaSearchResultsGridControl gridControl = searchResultControl as VinaSearchResultsGridControl;
                        GridView gridView = gridControl.Views[0] as GridView;
                        if (gridControl.DataSource == null)
                        {
                            VinaSearchResultsGridControl.BindingSearchResultGridControl(gridControl, Toolbar.ObjectCollection);
                        }
                        //gridControl.InvalidateLookupEditColumns();
                        gridView.RefreshData();
                        gridView.FocusedRowHandle = gridView.GetRowHandle(Toolbar.CurrentIndex);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Functions for New Action

        /// <summary type="New">
        /// New object in module
        /// </summary>
        public virtual void New()
        {
            CurrentModuleEntity.New();

            //VinaERPScreen _guiDataMainScreen = GetDataMainScreen(null, String.Empty);
            //if (_guiDataMainScreen != null)
            //{
            //    ActiveScreen = _guiDataMainScreen;
            //}
        }


        public virtual int Save()
        {
            int iObjectID = 0;
            bool isContinue = true;

            VinaDbUtil dbUtil = new VinaDbUtil();
            String strMainTable = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);

            String strMainTablePrimaryColumn = strMainTable.Substring(0, strMainTable.Length - 1) + "ID";
            String strMainTableNoColumn = strMainTablePrimaryColumn.Substring(0, strMainTablePrimaryColumn.Length - 2) + "No";
            String strObjectNo = dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, strMainTableNoColumn);

            isContinue = IsValidObjectNo(strObjectNo);
            if (isContinue)
            {
                iObjectID = CurrentModuleEntity.SaveMainObject();

                if (iObjectID > 0)
                {
                    CurrentModuleEntity.SaveModuleObjects();
                }
                return iObjectID;
            }
            else
                return 0;
        }

        protected virtual bool IsValidObjectNo(string objectNo)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            BaseBusinessController objCurrentObjectController = BusinessControllerFactory.GetBusinessController(CurrentModuleEntity.MainObject.GetType().Name.Substring(0, CurrentModuleEntity.MainObject.GetType().Name.Length - 4) + "Controller");
            String mainTable = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            String mainTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(mainTable);
            bool isValid = true;

            if (!String.IsNullOrEmpty(objectNo))
            {
                if (this.Toolbar.ModuleAction == BaseToolbar.ModuleNew)
                {
                    if (objCurrentObjectController.IsExist(objectNo))
                    {
                        MessageBox.Show("Mã đã tồn tại trong hệ thống vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }
                }
                else if (this.Toolbar.ModuleAction == BaseToolbar.ModuleEdit)
                {
                    BusinessObject objMainObject = (BusinessObject)objCurrentObjectController.GetObjectByNo(objectNo);
                    if (objMainObject != null)
                    {
                        int iMainObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(objMainObject, mainTablePrimaryColumn));
                        if (iMainObjectID != Toolbar.CurrentObjectID)
                        {
                            MessageBox.Show("Mã đã tồn tại trong hệ thống vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isValid = false;
                        }
                    }
                }
            }
            return isValid;
        }
        #endregion

        #region Function For Save Action
        protected virtual bool IsInvalidInput()
        {
            this.ErrorTable = this.InitErrorTable();
            this.CheckExtraInput();
            if (this.CurrentModuleEntity.MainObject != null)
            {
                VinaDbUtil bosDbUtil = new VinaDbUtil();
                this.ErrorTable.Rows.Clear();
                //TODO Check Error From Database
            }
            if (this.ErrorTable.Rows.Count == 0)
                return false;

            if (this.ErrorMessageScreen == null)
            {
                this.ErrorMessageScreen = new GuiErrorMessage(this.ErrorTable);
                this.ErrorMessageScreen.Module = (BaseModule)this;
            }
            else if (this.ErrorMessageScreen.IsDisposed)
            {
                this.ErrorMessageScreen = new GuiErrorMessage(this.ErrorTable);
                this.ErrorMessageScreen.Module = (BaseModule)this;
            }
            this.ErrorMessageScreen.Show();
            return true;
        }

        protected virtual void CheckExtraInput()
        {

        }

        private DataTable InitErrorTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "Error";
            DataColumn column1 = new DataColumn();
            column1.ColumnName = "Control";
            column1.DataType = typeof(string);
            dataTable.Columns.Add(column1);
            dataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "Message",
                DataType = typeof(string)
            });
            DataColumn column2 = new DataColumn();
            column2.ColumnName = "Position";
            column2.DataType = typeof(int);
            dataTable.Columns.Add(column2);
            DataColumn column3 = new DataColumn();
            column3.ColumnName = "Comment";
            column3.DataType = typeof(string);
            dataTable.Columns.Add(column3);
            DataColumn[] dataColumnArray = new DataColumn[3]
            {
                column1,
                column2,
                column3
            };
            dataTable.PrimaryKey = dataColumnArray;
            return dataTable;
        }


        public void ShowInventory(int productID, string productDesc)
        {
            guiShowInventoryStock guiShowInventoryStock = new guiShowInventoryStock(productID, productDesc);
            guiShowInventoryStock.Module = this;
            guiShowInventoryStock.ShowDialog();
        }

        public void InvalidateSerieColumn(GridColumn column, BusinessObject item, string itemTableName)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();

            String mainTableName = VinaUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            String columnName = mainTableName.Substring(0, mainTableName.Length - 1) + "Date";
            DateTime date = Convert.ToDateTime(dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, columnName));

            ICStockLotsController objStockLotsController = new ICStockLotsController();
            int productID = dbUtil.GetPropertyIntValue(item, "FK_ICProductID");
            int stockID = dbUtil.GetPropertyIntValue(item, "FK_ICStockID");

            columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductDesc";
            string desc = dbUtil.GetPropertyStringValue(item, columnName);

            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo == null)
                return;

            RepositoryItemComboBox rep = new RepositoryItemComboBox();
            if (objProductsInfo.ICPriceCalculationMethodType == PriceCalculationMethod.Specific)
            {

                List<ICStockLotsInfo> series = objStockLotsController.GetSeriesByProductIDAndStockID(productID, stockID, desc, date);
                if (series.Count > 0)
                {
                    series.Insert(0, new ICStockLotsInfo());
                }
                foreach (ICStockLotsInfo serie in series)
                {
                    rep.Items.Add(serie.ICStockLotNo);
                }
            }
            column.ColumnEdit = rep;
        }
        #endregion

        public virtual bool IsEditable()
        {
            BarItem barItem = ParentScreen.GetToolbarButton(BaseToolbar.ToolbarButtonEdit);
            if (barItem != null && barItem.Visibility != BarItemVisibility.Never && barItem.Enabled)
            {
                if (Toolbar.IsNullOrNoneAction() && Toolbar.CurrentObjectID > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
