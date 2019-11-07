using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using VinaLib;
using DevExpress.Utils.Menu;
using VinaLib.BaseProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data;
using System.Collections;
using DevExpress.XtraEditors.Controls;

namespace VinaERP
{
    public partial class VinaSearchResultsGridControl : GridControl, IVinaControl, ICloneable
    {
        public VinaScreen Screen { get; set; }

        public string VinaDataSource { get; set; }

        public string VinaDataMember { get; set; }

        public string VinaPropertyName { get; set; }

        protected SortedList LookupTables;

        protected SortedList<string, GELookupTablesInfo> LookupTableObjects;


        #region Constructors
        public VinaSearchResultsGridControl()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Function Init Search Result GridControl

        public void InitializeControl()
        {
            this.LookupTables = ((IBaseModuleERP)this.Screen.Module).GetLookupTableCollection();
            this.LookupTableObjects = ((IBaseModuleERP)this.Screen.Module).GetLookupTableObjects();
            GridView dgvSearchResults = InitializeSearchResultsGridView();
            this.ViewCollection.Add(dgvSearchResults);
            this.MainView = dgvSearchResults;
            dgvSearchResults.GridControl = this;
            this.MouseDoubleClick += new MouseEventHandler(GridControlSearchResults_MouseDoubleClick);
            //this.KeyUp += new KeyEventHandler(((IBaseModuleERP)Screen.Module).Control_KeyUp);

            //Using embedded Navigator
            this.UseEmbeddedNavigator = true;
            this.EmbeddedNavigator.Name = "navigator_" + this.Name;
            NavigatorCustomButton customizeColumnButton = new NavigatorCustomButton(8, "Cấu hình hiển thị");
            customizeColumnButton.Tag = "CustomizeColumn";
            NavigatorCustomButton saveColumnCustomizationButton = new NavigatorCustomButton(9, "Lưu cấu hình");
            saveColumnCustomizationButton.Tag = "SaveColumnCustomization";
            this.EmbeddedNavigator.Buttons.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
                                                                      customizeColumnButton,
                                                                      saveColumnCustomizationButton});
            this.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.EmbeddedNavigator.Buttons.Append.Visible = false;

            //Add events to navigator buttons
            this.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(NavigatorButton_Click);
        }

        protected virtual GridView InitializeSearchResultsGridView()
        {
            GridView dgvSearchResults = new GridView();
            dgvSearchResults.Name = "fld_dgv" + string.Empty;
            dgvSearchResults.OptionsSelection.EnableAppearanceFocusedCell = false;
            dgvSearchResults.OptionsSelection.EnableAppearanceFocusedRow = true;
            dgvSearchResults.OptionsView.ColumnAutoWidth = false;
            dgvSearchResults.OptionsCustomization.AllowFilter = true;
            dgvSearchResults.OptionsView.ShowAutoFilterRow = true;
            dgvSearchResults.OptionsView.ShowGroupPanel = false;
            dgvSearchResults.OptionsView.ShowIndicator = false;

            dgvSearchResults.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(GridViewSearchResults_FocusedRowChanged);
            dgvSearchResults.KeyUp += new KeyEventHandler(GridViewSearchResults_KeyUp);
            dgvSearchResults.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewSearchResults_CustomDrawCell);
            dgvSearchResults.OptionsBehavior.Editable = false;
            AddColumnsToGridViewResults(dgvSearchResults, VinaDataSource);
            InitGridViewVisibleIndex(dgvSearchResults, Screen.Module.CurrentModuleName, VinaDataSource);
            dgvSearchResults.ShowGridMenu += new GridMenuEventHandler(gridView_ShowGridMenu);
            return dgvSearchResults;
        }

        protected virtual void AddColumnsToGridViewResults(GridView gridView, string tableName)
        {
            gridView.Columns.Clear();
            VinaDbUtil dbUtil = new VinaDbUtil();
            AAColumnAliasController objAAColumnAliasController = new AAColumnAliasController();
            List<AAColumnAliasInfo> columnAliasList = objAAColumnAliasController.GetColumnAliasByTableName(tableName);

            if (columnAliasList.Count() == 0)
                return;
            int visibleIndex = 0;
            columnAliasList.ForEach(o =>
            {
                if (gridView.Columns.ColumnByFieldName(o.AAColumnAliasName) == null)
                {
                    GridColumn column = this.InitGridColumn(tableName, -1, o.AAColumnAliasName, o.AAColumnAliasCaption, 50);
                    if (dbUtil.IsForeignKey(tableName, o.AAColumnAliasName))
                    {
                        RepositoryItemLookUpEdit itemBosLookupEdit = this.InitColumnLookupEdit(tableName, o.AAColumnAliasName, o.AAColumnAliasCaption);
                        if (itemBosLookupEdit != null)
                            column.ColumnEdit = (DevExpress.XtraEditors.Repository.RepositoryItem)itemBosLookupEdit;
                    }
                    else
                    {
                        string empty = string.Empty;
                        string groupName = o.AAColumnAliasName.Substring(2, o.AAColumnAliasName.Length - 2);
                        if (VinaUtil.ADConfigValueUtility.ContainsKey(groupName))
                        {
                            RepositoryItemLookUpEdit itemLookUpEdit = this.InitRepositoryForConfigValues(VinaUtil.ADConfigValueUtility[groupName]);
                            column.ColumnEdit = itemLookUpEdit;
                        }
                        else
                        {
                            //column.ColumnEdit = this.InitColumnRepositoryFromFieldFormatGroup(strTableName, objectFromDataRow.AAColumnAliasName);
                            //if (column.ColumnEdit != null)
                            //    column.ColumnEdit.MouseWheel += new MouseEventHandler(this.ColumnEdit_MouseWheel);
                        }
                    }
                    column.Name = "col" + o.AAColumnAliasName;
                    column.FieldName = o.AAColumnAliasName;
                    column.Caption = o.AAColumnAliasCaption;
                    column.Width = 100;
                    column.VisibleIndex = visibleIndex++;
                    column.OptionsColumn.AllowEdit = false;
                    gridView.Columns.Add(column);
                }
                else
                    gridView.Columns[o.AAColumnAliasName].Caption = o.AAColumnAliasCaption;
                //column = new GridColumn();
                //column.Name = "col" + o.AAColumnAliasName;
                //column.FieldName = o.AAColumnAliasName;
                //column.Caption = o.AAColumnAliasCaption;
                //column.Width = 100;
                //column.VisibleIndex = visibleIndex++;
                //gridView.Columns.Add(column);
            });

        }

        protected virtual GridColumn InitGridColumn(string strTableName, int iVisibleIndex, string strFieldName, string strCaption, int iWidth)
        {
            return new GridColumn()
            {
                Name = "col" + strFieldName,
                Caption = strCaption,
                FieldName = strFieldName,
                VisibleIndex = iVisibleIndex,
                Width = iWidth,
                UnboundType = UnboundColumnType.Object
            };
        }

        protected virtual RepositoryItemLookUpEdit InitColumnLookupEdit(string strTableName, string strColumnName, string columnCaption)
        {
            return this.InitColumnLookupEdit(new VinaDbUtil().GetPrimaryTableWhichForeignColumnReferenceTo(strTableName, strColumnName), columnCaption);
        }

        protected virtual RepositoryItemLookUpEdit InitColumnLookupEdit(string lookupTableName, string columnCaption)
        {
            if (!this.LookupTables.ContainsKey((object)lookupTableName))
            {
                GELookupTablesInfo objectByTableName = new GELookupTablesController().GetObjectByTableName(lookupTableName);
                if (objectByTableName != null)
                {
                    DataSet lookupTableData = ((IBaseModuleERP)this.Screen.Module).GetLookupTableData(lookupTableName);
                    this.LookupTables.Add((object)lookupTableName, (object)lookupTableData);
                    this.LookupTableObjects.Add(lookupTableName, objectByTableName);
                }
            }
            if (this.LookupTables[(object)lookupTableName] == null)
                return (RepositoryItemLookUpEdit)null;
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemLookUpEdit.SearchMode = SearchMode.AutoFilter;
            repositoryItemLookUpEdit.TextEditStyle = TextEditStyles.Standard;
            repositoryItemLookUpEdit.NullText = string.Empty;
            repositoryItemLookUpEdit.Tag = (object)lookupTableName;
            string tablePrimaryColumn = vinaDbUtil.GetTablePrimaryColumn(lookupTableName);
            string tableDisplayColumn = this.GetLookupTableDisplayColumn(lookupTableName);
            repositoryItemLookUpEdit.ValueMember = tablePrimaryColumn;
            repositoryItemLookUpEdit.DisplayMember = tableDisplayColumn;
            repositoryItemLookUpEdit.DataSource = (object)((DataSet)this.LookupTables[(object)lookupTableName]).Tables[0];
            repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo()
            {
                Caption = columnCaption,
                FieldName = repositoryItemLookUpEdit.DisplayMember,
                Width = 100
            });
            //rep.QueryPopUp += new CancelEventHandler(this.RepositoryItemLookupEdit_QueryPopup);
            repositoryItemLookUpEdit.Leave += new System.EventHandler(this.RepositoryItemLookupEdit_Leave);
            //rep.QueryCloseUp += new CancelEventHandler(this.RepositoryItemLookupEdit_QueryCloseUp);
            repositoryItemLookUpEdit.KeyDown += new KeyEventHandler(this.RepositoryItemLookUpEdit_KeyDown);
            return repositoryItemLookUpEdit;
        }

        private void RepositoryItemLookupEdit_Leave(object sender, EventArgs e)
        {
            LookUpEdit lookupEdit = (LookUpEdit)sender;
            object dataSource = lookupEdit.Properties.DataSource;
            lookupEdit.Properties.DataSource = (object)null;
            lookupEdit.Properties.DataSource = dataSource;
        }

        private void RepositoryItemLookUpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F10 && (!e.Control || e.KeyCode != Keys.F10))
                return;
            GridView defaultView = (GridView)this.DefaultView;
            // this.ShowModule(defaultView.FocusedColumn, defaultView);
        }

        protected virtual string GetLookupTableDisplayColumn(string strLookupTableName)
        {
            try
            {
                VinaDbUtil vinaDbUtil = new VinaDbUtil();
                GELookupTablesInfo lookupTablesInfo;
                if (this.LookupTableObjects.ContainsKey(strLookupTableName))
                {
                    lookupTablesInfo = this.LookupTableObjects[strLookupTableName];
                }
                else
                {
                    lookupTablesInfo = new GELookupTablesController().GetObjectByTableName(strLookupTableName);
                    this.LookupTableObjects.Add(strLookupTableName, lookupTablesInfo);
                }
                if (lookupTablesInfo != null && !string.IsNullOrEmpty(lookupTablesInfo.GELookupTableDisplayColumn))
                    return lookupTablesInfo.GELookupTableDisplayColumn;
                string tablePrimaryColumn = vinaDbUtil.GetTablePrimaryColumn(strLookupTableName);
                string str = tablePrimaryColumn.Substring(0, tablePrimaryColumn.Length - 2);
                if (vinaDbUtil.ColumnIsExist(strLookupTableName, str + "Name"))
                    return str + "Name";
                if (vinaDbUtil.ColumnIsExist(strLookupTableName, str + "No"))
                    return str + "No";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return string.Empty;
        }

        protected RepositoryItemLookUpEdit InitRepositoryForConfigValues(IEnumerable enumerable)
        {
            RepositoryItemLookUpEdit itemLookUpEdit = new RepositoryItemLookUpEdit();
            itemLookUpEdit.DataSource = enumerable;
            itemLookUpEdit.ValueMember = "ADConfigKeyValue";
            itemLookUpEdit.DisplayMember = "ADConfigText";
            itemLookUpEdit.ShowHeader = false;
            itemLookUpEdit.TextEditStyle = TextEditStyles.Standard;
            itemLookUpEdit.NullText = String.Empty;
            LookUpColumnInfo column = new LookUpColumnInfo();
            column.FieldName = "ADConfigText";
            column.Width = 100;
            itemLookUpEdit.Columns.Add(column);
            itemLookUpEdit.PopupWidth = column.Width;
            return itemLookUpEdit;
        }

        /// <summary>
        /// Add default columns to grid view
        /// </summary>
        /// <param name="gridView">Grid view needs to be added columns</param>
        /// <param name="tableName">Table name of the grid view's data source</param>
        protected virtual void AddDefaultColumnsToGridView(GridView gridView, string tableName)
        {

        }

        //public DevExpress.XtraEditors.Repository.RepositoryItem InitColumnRepositoryFromFieldFormatGroup(String strTableName, String strColumnName)
        //{
        //    STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
        //    STFieldFormatGroupsInfo objFieldFormatGroupsInfo = objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
        //    if (objFieldFormatGroupsInfo != null)
        //    {
        //        if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupRepository))
        //        {
        //            return BOSUtil.GetRepositoryItemFromText(objFieldFormatGroupsInfo.STFieldFormatGroupRepository);
        //        }
        //    }
        //    return null;
        //}

        //public void InitColumnRepositoryFormat(DevExpress.XtraGrid.Columns.GridColumn column, String strTableName, String strColumnName)
        //{
        //    STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
        //    STFieldFormatGroupsInfo objFieldFormatGroupsInfo = objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
        //    if (objFieldFormatGroupsInfo != null)
        //    {
        //        DevExpress.XtraEditors.Repository.RepositoryItem rep = column.ColumnEdit;
        //        if (objFieldFormatGroupsInfo.STFieldFormatGroupBackColor > 0)
        //        {
        //            rep.Appearance.BackColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupBackColor);
        //            rep.Appearance.Options.UseBackColor = true;
        //        }
        //        if (objFieldFormatGroupsInfo.STFieldFormatGroupForeColor > 0)
        //        {
        //            rep.Appearance.ForeColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupForeColor);
        //            rep.Appearance.Options.UseForeColor = true;
        //        }

        //        String strDefaultFontName = "Tahoma";
        //        float fDefaultFontSize = 8.25F;
        //        if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFontName))
        //            strDefaultFontName = objFieldFormatGroupsInfo.STFieldFormatGroupFontName;
        //        if (objFieldFormatGroupsInfo.STFieldFormatGroupFontSize > 0)
        //            fDefaultFontSize = objFieldFormatGroupsInfo.STFieldFormatGroupFontSize;
        //        rep.Appearance.Font = new Font(strDefaultFontName, fDefaultFontSize);
        //        rep.Appearance.Options.UseFont = true;

        //        if (BOSUtil.IsEditRepository(rep))
        //        {
        //            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repText = (DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)rep;
        //            if (objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound > 0)
        //            {
        //                repText.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        //                repText.Mask.EditMask = String.Format("n{0}", objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound);
        //                repText.Mask.UseMaskAsDisplayFormat = true;
        //            }
        //            else
        //            {
        //                if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType))
        //                {
        //                    repText.Mask.MaskType = BOSUtil.GetMaskTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType);
        //                    repText.Mask.EditMask = objFieldFormatGroupsInfo.STFieldFormatGroupMaskEdit;
        //                    repText.Mask.UseMaskAsDisplayFormat = true;
        //                }
        //                if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType))
        //                {
        //                    repText.DisplayFormat.FormatType = BOSUtil.GetFormatTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType);
        //                    repText.DisplayFormat.FormatString = objFieldFormatGroupsInfo.STFieldFormatGroupFormatString;
        //                }
        //            }
        //        }
        //    }
        //}

        //public void InitColumnFormat(DevExpress.XtraGrid.Columns.GridColumn column, String strTableName, String strColumnName)
        //{
        //    STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
        //    STFieldFormatGroupsInfo objFieldFormatGroupsInfo = objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
        //    if (objFieldFormatGroupsInfo != null)
        //    {
        //        if (objFieldFormatGroupsInfo.STFieldFormatGroupBackColor > 0)
        //        {
        //            column.AppearanceCell.BackColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupBackColor);
        //            column.AppearanceCell.Options.UseBackColor = true;
        //        }
        //        if (objFieldFormatGroupsInfo.STFieldFormatGroupForeColor > 0)
        //        {
        //            column.AppearanceCell.ForeColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupForeColor);
        //            column.AppearanceCell.Options.UseForeColor = true;
        //        }

        //        String strDefaultFontName = "Tahoma";
        //        float fDefaultFontSize = 8.25F;
        //        if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFontName))
        //            strDefaultFontName = objFieldFormatGroupsInfo.STFieldFormatGroupFontName;
        //        if (objFieldFormatGroupsInfo.STFieldFormatGroupFontSize > 0)
        //            fDefaultFontSize = objFieldFormatGroupsInfo.STFieldFormatGroupFontSize;
        //        column.AppearanceCell.Font = new Font(strDefaultFontName, fDefaultFontSize);
        //        column.AppearanceCell.Options.UseFont = true;

        //        if (objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound > 0)
        //        {
        //            column.ColumnEdit = BOSUtil.GetRepositoryItemFromText("RepositoryItemTextEdit");
        //            InitColumnRepositoryFormat(column, strTableName, strColumnName);
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType))
        //            {
        //                column.DisplayFormat.FormatType = BOSUtil.GetFormatTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType);
        //                column.DisplayFormat.FormatString = objFieldFormatGroupsInfo.STFieldFormatGroupFormatString;
        //            }
        //        }
        //    }
        //}

        //protected virtual DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit InitColumnLookupEdit(String strTableName, String strColumnName, string columnCaption)
        //{
        //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
        //    rep.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        //    rep.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
        //    rep.NullText = String.Empty;

        //    String strLookupTable = new BOSDbUtil().GetPrimaryTableWhichForeignColumnReferenceTo(strTableName, strColumnName);
        //    DataSet ds;

        //    //[NUThao] [Improve Speed] [2014-09-09]
        //    if (!BOSApp.LookupTables.ContainsKey(strLookupTable))
        //    {
        //        GELookupTablesController lookupTableController = new GELookupTablesController();
        //        GELookupTablesInfo lookupTable = lookupTableController.GetObjectByTableName(strLookupTable);
        //        if (lookupTable != null)
        //        {
        //            ds = ((IBaseModuleERP)Screen.Module).GetLookupTableData(strLookupTable);
        //            BOSApp.LookupTables.Add(strLookupTable, ds);
        //            BOSApp.LookupTablesUpdatedDate.Add(strLookupTable, DateTime.Now);
        //            BOSApp.LookupTableObjects.Add(strLookupTable, lookupTable);
        //        }
        //    }
        //    //[NUThao] [Improve Speed] [2014-09-09]

        //    if (BOSApp.LookupTables[strLookupTable] == null)
        //        return null;

        //    ds = (DataSet)BOSApp.LookupTables[strLookupTable];
        //    rep.DataSource = ds.Tables[0];
        //    String strPrimaryColumn = new BOSDbUtil().GetTablePrimaryColumn(strLookupTable);
        //    String strDisplayColumn = GetLookupTableDisplayColumn(strLookupTable);
        //    rep.ValueMember = strPrimaryColumn;
        //    rep.DisplayMember = strDisplayColumn;
        //    rep.ShowHeader = false;
        //    rep.QueryPopUp += new CancelEventHandler(RepositoryItemLookupEdit_QueryPopup);

        //    LookUpColumnInfo colName = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
        //    colName.Caption = columnCaption;
        //    colName.FieldName = rep.DisplayMember;
        //    colName.Width = 100;
        //    rep.Columns.Add(colName);

        //    return rep;
        //}

        //protected virtual RepositoryItemBOSLookupEdit InitColumnLookupEdit(String strTableName, String strColumnName, string columnCaption)
        //{
        //    RepositoryItemBOSLookupEdit rep = new RepositoryItemBOSLookupEdit();
        //    rep.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        //    rep.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
        //    rep.NullText = String.Empty;

        //    String strLookupTable = new BOSDbUtil().GetPrimaryTableWhichForeignColumnReferenceTo(strTableName, strColumnName);
        //    DataSet ds;

        //    //[NUThao] [Improve Speed] [2014-09-09]
        //    if (!BOSApp.LookupTables.ContainsKey(strLookupTable))
        //    {
        //        GELookupTablesController lookupTableController = new GELookupTablesController();
        //        GELookupTablesInfo lookupTable = lookupTableController.GetObjectByTableName(strLookupTable);
        //        if (lookupTable != null)
        //        {
        //            ds = ((IBaseModuleERP)Screen.Module).GetLookupTableData(strLookupTable);
        //            BOSApp.LookupTables.Add(strLookupTable, ds);
        //            BOSApp.LookupTablesUpdatedDate.Add(strLookupTable, DateTime.Now);
        //            BOSApp.LookupTableObjects.Add(strLookupTable, lookupTable);
        //        }
        //    }
        //    //[NUThao] [Improve Speed] [2014-09-09]

        //    if (BOSApp.LookupTables[strLookupTable] == null)
        //        return null;

        //    ds = (DataSet)BOSApp.LookupTables[strLookupTable];
        //    rep.DataSource = ds.Tables[0];
        //    String strPrimaryColumn = new BOSDbUtil().GetTablePrimaryColumn(strLookupTable);
        //    String strDisplayColumn = GetLookupTableDisplayColumn(strLookupTable);
        //    rep.ValueMember = strPrimaryColumn;
        //    rep.DisplayMember = strDisplayColumn;
        //    rep.ShowHeader = false;
        //    rep.QueryPopUp += new CancelEventHandler(RepositoryItemLookupEdit_QueryPopup);

        //    LookUpColumnInfo colName = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
        //    colName.Caption = columnCaption;
        //    colName.FieldName = rep.DisplayMember;
        //    colName.Width = 100;
        //    rep.Columns.Add(colName);

        //    return rep;
        //}

        //protected virtual String GetLookupTableDisplayColumn(String strLookupTableName)
        //{
        //    //Get GELookupTableDisplayColumn from GELookupTables
        //    GELookupTablesController objLookupTablesController = new GELookupTablesController();
        //    GELookupTablesInfo objLookupTablesInfo = objLookupTablesController.GetObjectByTableName(strLookupTableName);
        //    if (objLookupTablesInfo != null && !String.IsNullOrEmpty(objLookupTablesInfo.GELookupTableDisplayColumn))
        //        return objLookupTablesInfo.GELookupTableDisplayColumn;
        //    //If not exist, get default display column
        //    BOSDbUtil dbUtil = new BOSDbUtil();
        //    String strPrimaryColumn = dbUtil.GetTablePrimaryColumn(strLookupTableName);
        //    String prefix = strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2);
        //    if (dbUtil.ColumnIsExist(strLookupTableName, prefix + "Name"))
        //        return prefix + "Name";
        //    else if (dbUtil.ColumnIsExist(strLookupTableName, prefix + "No"))
        //        return prefix + "No";
        //    return String.Empty;
        //}

        //protected virtual void RepositoryItemLookupEdit_QueryPopup(object sender, CancelEventArgs e)
        //{
        //    BOSDbUtil dbUtil = new BOSDbUtil();
        //    DevExpress.XtraEditors.LookUpEdit lke = (DevExpress.XtraEditors.LookUpEdit)sender;
        //    String strLookupTable = lke.Properties.ValueMember.Substring(0, lke.Properties.ValueMember.Length - 2) + "s";
        //    DateTime dtLastCreatedDate = dbUtil.GetLastCreatedDateOfTable(strLookupTable);
        //    DateTime dtLastUpdatedDate = dbUtil.GetLastUpdatedDateOfTable(strLookupTable);

        //    if (dtLastCreatedDate.CompareTo(((DateTime)BOSApp.LookupTablesUpdatedDate[strLookupTable])) > 0 ||
        //        dtLastUpdatedDate.CompareTo(((DateTime)BOSApp.LookupTablesUpdatedDate[strLookupTable])) > 0)
        //    {
        //        //Refesh Data Source
        //        BaseBusinessController objLookupTableController = BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");
        //        if (objLookupTableController != null)
        //        {
        //            //DataSet ds = objLookupTableController.GetAllObjects();
        //            DataSet ds = ((IBaseModuleERP)Screen.Module).GetLookupTableData(strLookupTable);
        //            if (ds.Tables.Count > 0)
        //            {
        //                // Update Last Updated Date of Lookup Table
        //                BOSApp.LookupTablesUpdatedDate[strLookupTable] = DateTime.Now;
        //                //((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Clear();
        //                //((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
        //                BOSApp.LookupTables[strLookupTable] = ds;
        //            }
        //        }
        //    }

        //    lke.Properties.DataSource = ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables[0];
        //}

        private void GridViewSearchResults_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            String strMainTable = ((BaseModuleERP)Screen.Module).CurrentModuleEntity.MainObject.GetType().Name.Substring(0, ((BaseModuleERP)Screen.Module).CurrentModuleEntity.MainObject.GetType().Name.Length - 4);
            DataRow dataRow = dgvSearchResults.GetDataRow(dgvSearchResults.FocusedRowHandle);
            if (dataRow == null || e.FocusedRowHandle < 0)
                return;

            int currentObjectID = 0;
            string primaryKeyName = strMainTable.Substring(0, strMainTable.Length - 1) + "ID";
            Int32.TryParse(dgvSearchResults.GetRowCellValue(e.FocusedRowHandle, primaryKeyName).ToString(), out currentObjectID);
            if (currentObjectID < 0)
                return;

            this.Screen.Module.Toolbar.CurrentIndex = this.Screen.Module.Toolbar.ObjectCollection.Tables[0].Rows.IndexOf(dataRow);
            this.Screen.Module.Toolbar.Invalidate();
        }

        private void GridViewSearchResults_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                //((BaseModuleERP)Screen.Module).ActivateDataMainScreen();
            }
        }

        private void GridViewSearchResults_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.VisibleIndex >= 0)
            //{
            //    try
            //    {
            //        String strTableName = BOSUtil.GetTableNameFromBusinessObject(((BaseModuleERP)Screen.Module).CurrentModuleEntity.MainObject);
            //        String strColumnName = e.Column.FieldName;
            //        BOSDbUtil dbUtil = new BOSDbUtil();
            //        if (strTableName.StartsWith("FA"))
            //            if (strColumnName.Contains("FA" + Screen.Module.Name + "Type"))
            //                if (ADConfigValueUtility.ConfigValues.Tables[Screen.Module.Name + "Type"] != null)
            //                    if (e.CellValue != null)
            //                    {
            //                        String strValue = e.CellValue.ToString();
            //                        DataRow row = ADConfigValueUtility.ConfigValues.Tables[Screen.Module.Name + "Type"].Rows.Find(strValue);
            //                        if (row != null)
            //                            e.DisplayText = row["Text"].ToString();
            //                    }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //        (sender as GridView).Columns.Remove(e.Column);
            //    }
            //}
        }

        private void GridControlSearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.GridControl dgcSearchResults = (DevExpress.XtraGrid.GridControl)sender;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = ((GridView)dgcSearchResults.MainView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.RowHandle >= 0)
            {
                //VinaERPScreen _guiDataMainScreen = ((BaseModuleERP)Screen.Module).GetDataMainScreen(null, String.Empty);
                //if (_guiDataMainScreen != null)
                //{
                //    _guiDataMainScreen.Activate();
                //    Screen.Module.ActiveScreen = _guiDataMainScreen;
                //}
            }
        }

        private void AddMenu(GridView gr, GridViewMenu grm, bool isCreate)
        {
            if (!isCreate)
            {
                DXMenuItem menu = new DXMenuItem();
                menu.BeginGroup = true;
                menu.Caption = "Export to Excel";
                menu.Tag = "ExportExcel";
                //menu.Click += new EventHandler(excel_Click);
                grm.Items.Add(menu);
            }
        }

        //public virtual void excel_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = App.ExcelDialogFilter;
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        this.ExportToXls(sfd.FileName);
        //        Process.Start(sfd.FileName);
        //    }
        //}
        void gridView_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView gr = (GridView)sender;
            if (e.Menu == null) return;
            if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnPanel ||
                e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnEdge ||
                e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnFilterButton ||
                e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Column)
            {
                bool isExcel = false;
                foreach (DevExpress.Utils.Menu.DXMenuItem item in e.Menu.Items)
                {
                    if (item.Tag.ToString() == "ExportExcel")
                    {
                        isExcel = true;
                        continue;
                    }
                }
                AddMenu(gr, e.Menu, isExcel);
            }
        }
        #endregion

        #region Add Search Results To GridControl Functions
        #region Utilities For Data GridControl View
        public static void BindingSearchResultGridControl(DevExpress.XtraGrid.GridControl gridControl, DataSet dsSearchResults)
        {
            if (dsSearchResults.Tables.Count > 0)
            {
                GridView gridView = (GridView)gridControl.ViewCollection[0];
                gridView.OptionsBehavior.AutoPopulateColumns = false;

                BindingSource bdsSearchResults = new BindingSource();
                bdsSearchResults.DataSource = dsSearchResults.Tables[0];
                gridControl.DataSource = bdsSearchResults;
            }
        }

        protected virtual void InitGridViewVisibleIndex(GridView gridView, String strModuleName, String strTableName)
        {
            //STGridResultColumnDisplaysController objGridResultColumnDisplayController = new STGridResultColumnDisplaysController();

            //DataSet dsColumns = objGridResultColumnDisplayController.GetGridResultColumnDisplaysByModuleName(strModuleName);
            //if (dsColumns.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow rowColumn in dsColumns.Tables[0].Rows)
            //    {
            //        STGridResultColumnDisplaysInfo objGridResultColumnDisplayInfo = (STGridResultColumnDisplaysInfo)objGridResultColumnDisplayController.GetObjectFromDataRow(rowColumn);
            //        if (gridView.Columns[objGridResultColumnDisplayInfo.STGridResultColumnFieldName] != null)
            //        {
            //            gridView.Columns[objGridResultColumnDisplayInfo.STGridResultColumnFieldName].VisibleIndex = objGridResultColumnDisplayInfo.STGridResultSortOrder;
            //            gridView.Columns[objGridResultColumnDisplayInfo.STGridResultColumnFieldName].Width = objGridResultColumnDisplayInfo.STGridResultColumnWidth;
            //        }
            //    }
            //}
            //else
            //{
            //    InitDefaultGridViewVisibleIndex(gridView, strTableName);
            //}
        }

        protected virtual void InitDefaultGridViewVisibleIndex(GridView gridView, String strTableName)
        {

        }
        #endregion
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Customize columns of BOSGridSearchResultsControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigatorButton_Click(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "CustomizeColumn")
                    CustomizeColumnGridSearchResults();
                else
                    if (e.Button.Tag.ToString() == "SaveColumnCustomization")
                    SaveCustomizeColumnGridSearchResults();
            }
        }

        /// <summary type="Customize">
        /// Customize Column on Search Results Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        private void CustomizeColumnGridSearchResults()
        {
            ((GridView)this.MainView).ColumnsCustomization();
        }

        /// <summary type="Save">
        /// Save customize column of Search Results Control
        /// </summary>
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        private void SaveCustomizeColumnGridSearchResults()
        {
            //STGridResultColumnDisplaysController objSTGridResultColumnDisplaysController = new STGridResultColumnDisplaysController();
            //objSTGridResultColumnDisplaysController.DeleteGridResultColumnDisplayByModuleName(Screen.Module.Name);

            //foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in ((GridView)this.MainView).Columns)
            //{
            //    if (gridColumn.Visible)
            //    {
            //        STGridResultColumnDisplaysInfo objSTGridResultColumnDisplaysInfo = new STGridResultColumnDisplaysInfo();
            //        objSTGridResultColumnDisplaysInfo.STGridResultColumnName = gridColumn.Name;
            //        objSTGridResultColumnDisplaysInfo.STGridResultColumnFieldName = gridColumn.FieldName;
            //        objSTGridResultColumnDisplaysInfo.STGridResultColumnCaption = gridColumn.Caption;
            //        objSTGridResultColumnDisplaysInfo.STGridResultColumnWidth = gridColumn.Width;
            //        objSTGridResultColumnDisplaysInfo.STModuleID = new STModulesController().GetObjectIDByName(Screen.Module.Name);
            //        objSTGridResultColumnDisplaysInfo.STGridResultSortOrder = gridColumn.VisibleIndex;
            //        objSTGridResultColumnDisplaysController.CreateObject(objSTGridResultColumnDisplaysInfo);
            //    }
            //}
            //MessageBox.Show(BaseLocalizedResources.SaveSuccessfullyMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Invalidate lookup edit columns to reflect all changes of lookup table
        /// </summary>
        //public virtual void InvalidateLookupEditColumns()
        //{
        //    GridView gridView = (GridView)this.MainView;
        //    foreach (GridColumn column in gridView.Columns)
        //    {
        //        if (column.ColumnEdit != null && column.ColumnEdit is RepositoryItemLookUpEdit)
        //        {
        //            BOSDbUtil dbUtil = new BOSDbUtil();
        //            RepositoryItemLookUpEdit rep = (RepositoryItemLookUpEdit)column.ColumnEdit;
        //            String strLookupTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(BOSDataSource, column.FieldName);
        //            if (!string.IsNullOrEmpty(strLookupTable))
        //            {
        //                //Update lookup table if there is any changes to it
        //                DateTime dtLastCreatedDate = dbUtil.GetLastCreatedDateOfTable(strLookupTable);
        //                DateTime dtLastUpdatedDate = dbUtil.GetLastUpdatedDateOfTable(strLookupTable);
        //                if (dtLastCreatedDate.CompareTo(((DateTime)BOSApp.LookupTablesUpdatedDate[strLookupTable])) > 0 ||
        //                    dtLastUpdatedDate.CompareTo(((DateTime)BOSApp.LookupTablesUpdatedDate[strLookupTable])) > 0)
        //                {
        //                    //Refesh Data Source
        //                    BaseBusinessController objLookupTableController = BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");
        //                    if (objLookupTableController != null)
        //                    {
        //                        //DataSet ds = objLookupTableController.GetAllObjects();
        //                        DataSet ds = ((IBaseModuleERP)Screen.Module).GetLookupTableData(strLookupTable);
        //                        if (ds.Tables.Count > 0)
        //                        {
        //                            // Update Last Updated Date of Lookup Table
        //                            BOSApp.LookupTablesUpdatedDate[strLookupTable] = DateTime.Now;
        //                            //((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Clear();
        //                            //((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
        //                            BOSApp.LookupTables[strLookupTable] = ds;
        //                        }
        //                    }
        //                }

        //                rep.DataSource = ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables[0];
        //            }
        //        }
        //    }
        //}
    }
}

