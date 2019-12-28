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
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace VinaERP
{
    public partial class VinaGridControl : GridControl, IVinaControl, ICloneable
    {
        public VinaScreen Screen { get; set; }

        public string VinaDataSource { get; set; }

        public string VinaDataMember { get; set; }

        public string VinaPropertyName { get; set; }

        protected SortedList LookupTables;

        protected SortedList<string, GELookupTablesInfo> LookupTableObjects;

        #region Constructors
        public VinaGridControl()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Function Init Search Result GridControl

        public virtual void InitializeControl()
        {
            this.LookupTables = ((IBaseModuleERP)this.Screen.Module).GetLookupTableCollection();
            this.LookupTableObjects = ((IBaseModuleERP)this.Screen.Module).GetLookupTableObjects();
            GridView gridView = this.InitializeGridView();
            this.MainView = (BaseView)gridView;
            this.InitGridControlDataSource();
            this.UseEmbeddedNavigator = true;

            this.EmbeddedNavigator.Name = "navigator_" + this.Name;
            NavigatorCustomButton navigatorCustomButton1 = new NavigatorCustomButton(8, "Cấu hình hiển thị");
            navigatorCustomButton1.Tag = (object)"CustomizeColumn";
            NavigatorCustomButton navigatorCustomButton2 = new NavigatorCustomButton(9, "Lưu cấu hình");
            navigatorCustomButton2.Tag = (object)"SaveColumnCustomization";
            this.EmbeddedNavigator.Buttons.CustomButtons.AddRange(new NavigatorCustomButton[2]
            {
                navigatorCustomButton1,
                navigatorCustomButton2
            });
            this.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(this.NavigatorButton_Click);
            gridView.ValidateRow += new ValidateRowEventHandler(this.GridView_ValidateRow);
        }


        protected virtual GridView InitializeGridView()
        {
            GridView view = (GridView)this.ViewCollection[0];
            view.Name = "fld_dgv" + this.Name.Substring(7);
            view.OptionsBehavior.Editable = true;
            view.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
            view.OptionsBehavior.Editable = true;
            view.OptionsBehavior.AutoSelectAllInEditor = false;
            view.OptionsNavigation.AutoFocusNewRow = true;

            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.ShowDetailButtons = false;
            view.OptionsNavigation.EnterMoveNextColumn = true;
            view.OptionsSelection.EnableAppearanceFocusedCell = true;
            view.OptionsSelection.EnableAppearanceFocusedRow = false;
            view.OptionsCustomization.AllowFilter = true;
            view.OptionsNavigation.UseTabKey = false;
            view.GridControl = (GridControl)this;

            this.InitGridViewColumns(view);
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            try
            {
                //view.CustomDrawCell += new RowCellCustomDrawEventHandler(this.GridView_CustomDrawCell);
                view.InitNewRow += new InitNewRowEventHandler(this.GridView_InitNewRow);
                view.FocusedRowChanged += new FocusedRowChangedEventHandler(this.GridView_FocusedRowChanged);
                //view.Click += new System.EventHandler(this.GridView_Click);
                view.CellValueChanged += new CellValueChangedEventHandler(this.GridView_CellValueChanged);
                view.KeyUp += new KeyEventHandler(this.GridView_KeyUp);
                //view.ValidateRow += new ValidateRowEventHandler(this.GridView_ValidateRow);
                //view.InvalidRowException += new InvalidRowExceptionEventHandler(this.GridView_InvalidRowException);
                view.ValidatingEditor += new BaseContainerValidateEditorEventHandler(this.GridView_ValidatingEditor);
                view.ShownEditor += new System.EventHandler(this.GridView_ShownEditor);
                //view.ShowingEditor += new CancelEventHandler(this.gridView_ShowingEditor); 
                view.InvalidValueException += new InvalidValueExceptionEventHandler(GridView_InvalidValueException);
            }
            catch (Exception)
            {
            }
            //view.GridMenuItemClick += new GridMenuItemClickEventHandler(this.gridView_GridMenuItemClick);
            //view.ShowGridMenu += new GridMenuEventHandler(this.gridView_ShowGridMenu);
            //view.CustomSummaryExists += new CustomSummaryExistEventHandler(this.gridView_CustomSummaryExists);
            //this.InvalidateLookupEditColumns();
            return view;
        }

        private void View_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            //Do not perform any default action 
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            //Show the message with the error text specified 
            //MessageBox.Show(e.ErrorText);
        }

        protected virtual void GridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {

            DevExpress.XtraGrid.GridControl gridctrl = sender as DevExpress.XtraGrid.GridControl;
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)this.DefaultView;


            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {

                if (gridView.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle)
                {
                    gridView.AddNewRow();
                }

                gridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
                gridView.FocusedColumn = gridView.VisibleColumns[0];
                gridView.ShowEditor();
            }
        }

        protected virtual void GridView_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.TextEdit;
                if (edit != null)
                    edit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(edit_Spin);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public virtual BusinessObject GetBusinessObject()
        {
            return GetBusinessObject((MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle);
        }
        public virtual BusinessObject GetBusinessObject(int pRowHandle)
        {
            return GetBusinessObject(pRowHandle, BusinessControllerFactory.GetBusinessController(VinaDataSource + "Controller"));
        }
        public virtual BusinessObject GetBusinessObject(int pRowHandle, BaseBusinessController objCtrl)
        {
            if (pRowHandle < 0)
                return null;
            if (string.IsNullOrWhiteSpace(VinaDataSource))
            {
                if (objCtrl != null)
                    return (BusinessObject)objCtrl.GetObjectFromDataRow((MainView as DevExpress.XtraGrid.Views.Grid.GridView).GetDataRow(pRowHandle));
                return null;
            }
            return (BusinessObject)(MainView as DevExpress.XtraGrid.Views.Grid.GridView).GetRow(pRowHandle);
        }
        public virtual BusinessObject GetBusinessObject(int pRowHandle, params string[] pProperties)
        {
            if (pRowHandle < 0)
                return null;
            if (string.IsNullOrWhiteSpace(VinaDataSource))
            {
                VinaDbUtil vinaDbUtil = new VinaDbUtil();
                BusinessObject obj = BusinessObjectFactory.GetBusinessObject(VinaDataSource + "Info");
                if (obj != null)
                {
                    System.Threading.Tasks.Parallel.For(0, pProperties.Length, i =>
                    {
                        object objProp = (MainView as DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(pRowHandle, pProperties[i]);
                        if (objProp != DBNull.Value)
                            vinaDbUtil.SetPropertyValue(obj, pProperties[i], objProp);
                    });
                }
                return obj;
            }
            return (BusinessObject)(MainView as DevExpress.XtraGrid.Views.Grid.GridView).GetRow(pRowHandle);
        }

        void edit_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        protected virtual void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        protected virtual void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView == null)
                return;
            var obj = gridView.GetDataRow(e.RowHandle);
        }

        protected virtual void GridView_KeyUp(object sender, KeyEventArgs e)
        {

        }

        protected virtual void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {

        }

        protected virtual void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {

        }

        protected virtual void InitGridViewColumns(GridView gridView)
        {
            this.InitDefaultGridViewColumns(gridView);
            this.AddColumnsToGridView(this.VinaDataSource, gridView);
            this.InitGridColumnsVisibleIndex(gridView);
        }

        protected virtual void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            AAColumnAliasController objColumnAliasController = new AAColumnAliasController();
            List<AAColumnAliasInfo> columnAlias = objColumnAliasController.GetColumnAliasByTableName(strTableName);
            columnAlias.ForEach(o =>
            {
                if (gridView.Columns.ColumnByFieldName(o.AAColumnAliasName) == null)
                {
                    GridColumn column = this.InitGridColumn(strTableName, -1, o.AAColumnAliasName, o.AAColumnAliasCaption, 50);
                    if (vinaDbUtil.IsForeignKey(strTableName, o.AAColumnAliasName))
                    {
                        RepositoryItemLookUpEdit itemBosLookupEdit = this.InitColumnLookupEdit(strTableName, o.AAColumnAliasName, o.AAColumnAliasCaption);
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
                    column.OptionsColumn.AllowEdit = false;
                    gridView.Columns.Add(column);
                }
                else
                    gridView.Columns[o.AAColumnAliasName].Caption = o.AAColumnAliasCaption;
            });
        }

        private void gridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (!view.IsNewItemRow(view.FocusedRowHandle))
                e.Cancel = true;
        }

        public DevExpress.XtraEditors.Repository.RepositoryItem InitColumnRepositoryFromFieldFormatGroup(string strTableName, string strColumnName)
        {
            return (DevExpress.XtraEditors.Repository.RepositoryItem)null;
        }

        private void ColumnEdit_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
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
        private void RepositoryItemLookUpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F10 && (!e.Control || e.KeyCode != Keys.F10))
                return;
            GridView defaultView = (GridView)this.DefaultView;
            // this.ShowModule(defaultView.FocusedColumn, defaultView);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            try
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.C)
                {
                    GridView defaultView = (GridView)this.DefaultView;
                    if (defaultView.GetFocusedValue() == null)
                        return;
                    Clipboard.SetText(defaultView.GetFocusedValue().ToString());
                }
                else if (e.Control && e.KeyCode == Keys.C)
                    Clipboard.SetText(((ColumnView)this.DefaultView).GetFocusedDisplayText());
                else if (e.KeyCode == Keys.Insert)
                    this.DefaultView.CopyToClipboard();
                else if (e.KeyCode == Keys.F10 || e.Control && e.KeyCode == Keys.F10)
                {
                    GridView defaultView = (GridView)this.DefaultView;
                    //this.ShowModule(defaultView.FocusedColumn, defaultView);
                }
                else
                {
                    if (!e.Control || !e.Shift || e.KeyCode != Keys.D)
                        return;
                    Clipboard.SetText(((ColumnView)this.DefaultView).FocusedColumn.FieldName);
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void RepositoryItemLookupEdit_Leave(object sender, EventArgs e)
        {
            LookUpEdit lookupEdit = (LookUpEdit)sender;
            object dataSource = lookupEdit.Properties.DataSource;
            lookupEdit.Properties.DataSource = (object)null;
            lookupEdit.Properties.DataSource = dataSource;
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

        protected virtual void InitGridColumnsVisibleIndex(GridView gridView)
        {
            STColumnsController objColumnsController = new STColumnsController();
            List<STColumnsInfo> columns = objColumnsController.GetColumnsByScreenIDAndControlName(Screen.ScreenID, this.Name);
            if (columns.Count() > 0)
            {
                columns.ForEach(o =>
                {
                    if (gridView.Columns[o.STColumnFieldName] != null)
                    {
                        gridView.Columns[o.STColumnFieldName].VisibleIndex = o.STColumnVisibleIndex;
                        gridView.Columns[o.STColumnFieldName].Width = o.STColumnWidth;
                    }
                });
            }
            else
                this.InitDefaultGridColumnsVisibleIndex(gridView);
        }

        protected virtual void InitDefaultGridViewColumns(GridView gridView)
        {

        }

        public virtual void InitGridControlDataSource()
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual void InvalidateLookupEditColumns()
        {
            foreach (GridColumn column in (CollectionBase)((ColumnView)this.MainView).Columns)
            {
                if (column.ColumnEdit != null && column.ColumnEdit is RepositoryItemLookUpEdit)
                {
                    VinaDbUtil bosDbUtil = new VinaDbUtil();
                    RepositoryItemLookUpEdit columnEdit = (RepositoryItemLookUpEdit)column.ColumnEdit;
                    string columnReferenceTo = bosDbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(this.VinaDataSource, column.FieldName);
                    if (!string.IsNullOrEmpty(columnReferenceTo) && this.LookupTables.ContainsKey((object)columnReferenceTo))
                    {
                        columnEdit.DataSource = (object)((DataSet)this.LookupTables[(object)columnReferenceTo]).Tables[0];
                    }
                }
            }
        }

        private void NavigatorButton_Click(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;
            if (e.Button.Tag.ToString() == "CustomizeColumn")
                this.CustomizeColumnGridControl();
            else if (e.Button.Tag.ToString() == "SaveColumnCustomization")
                this.SaveCustomizeColumnGridControl();
        }

        private void SaveCustomizeColumnGridControl()
        {
            STColumnsController columnsController = new STColumnsController();
            if (Screen.ScreenID > 0)
                columnsController.DeleteByScreenIDAndControlName(Screen.ScreenID, this.Name);
            foreach (GridColumn column in (CollectionBase)((ColumnView)this.ViewCollection[0]).Columns)
            {
                if (column.Visible)
                    columnsController.CreateObject((BusinessObject)new STColumnsInfo()
                    {
                        FK_STScreenID = Screen.ScreenID,
                        STColumnFieldName = column.FieldName,
                        STColumnControlName = this.Name,
                        STColumnName = column.Name,
                        STColumnWidth = column.Width,
                        STColumnVisibleIndex = column.VisibleIndex
                    });
            }
            int num = (int)MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void CustomizeColumnGridControl()
        {
            ((GridView)this.MainView).ColumnsCustomization();
        }

        protected virtual void InitDefaultGridColumnsVisibleIndex(GridView gridView)
        {

        }

        protected virtual void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            
        }

        protected virtual void FormatNumbericColumn(GridColumn column, bool allowEdit, string formatType)
        {
            RepositoryItemTextEdit repositoryItemTextEdit = new RepositoryItemTextEdit()
            {
                Mask =
                {
                    MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric,
                    EditMask = formatType,
                    UseMaskAsDisplayFormat = true
                }
            };
            repositoryItemTextEdit.DisplayFormat.FormatType = FormatType.Numeric;
            repositoryItemTextEdit.DisplayFormat.FormatString = formatType;
            column.OptionsColumn.AllowEdit = allowEdit;
            column.ColumnEdit = repositoryItemTextEdit;
            column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }
        #endregion
    }
}