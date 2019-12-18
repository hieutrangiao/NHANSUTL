using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;

namespace VinaERP.Modules.LeaveDay
{
    public partial class HRLeaveDaysGridControl : VinaGridControl
    {
        public int RowHandle { get; set; }
        public GridView GridViewMain { get; set; }
        public DateTime ViewDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override void InitGridControlDataSource()
        {
            LeaveDayEntities entity = (LeaveDayEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.LeaveDaysList;
            this.DataSource = bds;
        }

        public override void InitializeControl()
        {
            base.InitializeControl();

            //Init banded view and make it the main view
            BandedGridView bandedView = InitializeBandedGridView(GridViewMain);
            MainView = bandedView;
            ViewCollection.AddRange(new BaseView[] { bandedView });
            ShowOnlyPredefinedDetails = true;
            UseEmbeddedNavigator = false;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            GridViewMain = gridView;
            return gridView;
        }

        /// <summary>
        /// Initialize BandedGridView
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns></returns>
        private BandedGridView InitializeBandedGridView(GridView gridView)
        {
            //Creat a banded grid view
            BandedGridView bandedView = new BandedGridView();
            GridBand gridBand1 = new GridBand();
            GridBand gridBand2 = new GridBand();
            GridBand gridBand3 = new GridBand();
            bandedView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gridBand1,
            gridBand2,
            gridBand3});
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                bandedView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                        ConvertToBandedColumn(gridView.Columns[i], false)});
            }
            bandedView.GridControl = this;
            bandedView.Name = "bandedGridView1";
            bandedView.OptionsCustomization.AllowFilter = false;
            bandedView.OptionsView.ColumnAutoWidth = false;
            bandedView.OptionsView.ShowGroupPanel = false;

            //GridBand1
            gridBand1.Caption = "Thông tin nhân viên";
            gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridBand1.Name = "gridBand1";

            //GridBand2
            gridBand2.Caption = "Ngày trong tháng";
            gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand2.Name = "gridBand2";

            //GridBand3
            gridBand3.Caption = "Tổng cộng";
            gridBand3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            gridBand3.Name = "gridBand3";

            // Assigning columns to bands
            GridColumn column = gridView.Columns["HREmployeeCardNumber"];
            if (column != null)
            {
                BandedGridColumn bandedColumn = ConvertToBandedColumn(column, false);
                bandedColumn.OwnerBand = gridBand1;
                bandedColumn.Width = 80;
            }

            column = gridView.Columns["HREmployeeNo"];
            if (column != null)
                ConvertToBandedColumn(column, false).OwnerBand = gridBand1;
            column = gridView.Columns["HREmployeeName"];
            if (column != null)
            {
                BandedGridColumn bandedColumn = ConvertToBandedColumn(column, false);
                bandedColumn.OwnerBand = gridBand1;
                bandedColumn.Width = 150;
            }

            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            List<HRTimeSheetParamsInfo> commonParams = objTimeSheetParamsController.GetTimeSheetParamsByTimeSheetType(TimeSheetParamType.Common.ToString());
            //commonParams.Insert(0, new HRTimeSheetParamsInfo());

            for (int i = 1; i <= 31; i++)
            {
                column = gridView.Columns[String.Format("{0}{1}", "HRLeaveDayDate", i.ToString())];
                if (column != null)
                {
                    BandedGridColumn bandedColumn = ConvertToBandedColumn(column, true);
                    InitColumnRepository(bandedColumn, commonParams);
                    bandedColumn.OwnerBand = gridBand2;
                    bandedColumn.Width = 30;
                }
            }

            column = gridView.Columns["TotalLeaveDays"];
            if (column != null)
            {
                ConvertToBandedColumn(column, false).OwnerBand = gridBand3;
            }

            bandedView.CustomDrawCell += new RowCellCustomDrawEventHandler(BandedView_CustomDrawCell);
            bandedView.CellValueChanged += new CellValueChangedEventHandler(BandedView_CellValueChanged);
            bandedView.RowClick += new RowClickEventHandler(BandedView_RowClick);
            bandedView.OptionsView.ShowAutoFilterRow = true;
            return bandedView;
        }


        private void BandedView_RowClick(object sender, RowClickEventArgs e)
        {
            RowHandle = e.RowHandle;
        }

        protected void BandedView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView gridView = (GridView)MainView;
                HRLeaveDaysInfo objLeaveDaysInfo = (HRLeaveDaysInfo)gridView.GetRow(e.RowHandle);
                //Update time sheet total quantity
                ((LeaveDayModule)Screen.Module).UpdateTotalLeaveDays(objLeaveDaysInfo);
            }
        }

        protected void BandedView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            BandedGridView bandedView = (BandedGridView)MainView;
            if (!bandedView.IsValidRowHandle(e.RowHandle))
                return;
            int parent = bandedView.GetParentRowHandle(e.RowHandle);
            if (bandedView.IsGroupRow(parent))
            {
                for (int i = 0; i < bandedView.GetChildRowCount(parent); i++)
                    if (bandedView.GetChildRowHandle(parent, i) == e.RowHandle)
                        e.Appearance.BackColor = i % 2 == 0 ? Color.White : Color.WhiteSmoke;
            }
            else e.Appearance.BackColor = e.RowHandle % 2 == 0 ? Color.White : Color.WhiteSmoke;
            e.Appearance.ForeColor = Color.Black;

            // fill column if holiday
            //List<string> columnFieldNameList = ((LeaveDayModule)Screen.Module).GetColumnFieldNameByTypeEndOfWeek();
            //if (columnFieldNameList.Count > 0)
            //{
            //    for (int i = 0; i < columnFieldNameList.Count; i++)
            //    {
            //        if (e.Column.FieldName.Equals(columnFieldNameList[i]))
            //        {
            //            e.Appearance.BackColor = Color.Red;
            //        }
            //    }
            //}
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = "Mã nhân viên";
            column.FieldName = "HREmployeeNo";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Tên nhân viên";
            column.FieldName = "HREmployeeName";
            gridView.Columns.Add(column);
            column = new GridColumn();
            column.Caption = "Mã ID";
            column.FieldName = "HREmployeeCardNumber";
            gridView.Columns.Add(column);

            //int numDays = DateTime.DaysInMonth(ViewDate.Year, ViewDate.Month);  
            int numDays = (int)(ToDate.Date - FromDate.Date).TotalDays + 1;
            for (int i = 1; i <= numDays; i++)
            {
                //GridColumn columnDays = new GridColumn();
                //columnDays.Caption = i.ToString();
                //columnDays.FieldName = String.Format("{0}{1}", "HRLeaveDayDate", i.ToString());
                //gridView.Columns.Add(columnDays);      
                GridColumn columnDays = new GridColumn();
                DateTime dt = FromDate.Date.AddDays(i - 1);
                columnDays.Caption = dt.ToString("dd/MM");
                columnDays.FieldName = String.Format("{0}{1}", "HRLeaveDayDate", i.ToString());
                //columnDays.FieldName = String.Format("{0}{1}", "HRLeaveDayDate", dt.Day.ToString());
                gridView.Columns.Add(columnDays);
            }

            column = new GridColumn();
            column.Caption = "Số ngày nghỉ";
            column.FieldName = "TotalLeaveDays";
            gridView.Columns.Add(column);
        }

        /// <summary>
        /// Convert GridColumn to BandedGridColumn
        /// </summary>
        /// <param name="gridColumn">Column of GridView</param>
        /// <param name="isAllowEdit">Allow column edit or not</param>
        /// <returns></returns>
        public BandedGridColumn ConvertToBandedColumn(GridColumn gridColumn, bool isAllowEdit)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = gridColumn.Name;
            bandedColumn.FieldName = gridColumn.FieldName;
            bandedColumn.Caption = gridColumn.Caption;
            bandedColumn.OptionsColumn.AllowEdit = isAllowEdit;
            bandedColumn.Visible = true;
            bandedColumn.Width = gridColumn.Width;
            return bandedColumn;
        }

        /// <summary>
        /// Init the repository lookup edit for a banded column
        /// </summary>        
        /// <param name="column">Banded column</param>
        /// <param name="dataSource">Data source of repository</param>
        public void InitColumnRepository(BandedGridColumn column, List<HRTimeSheetParamsInfo> dataSource)
        {
            //RepositoryItemBOSLookupEdit rep = new RepositoryItemBOSLookupEdit();
            //rep.DataSource = dataSource;
            //rep.DisplayMember = "HRTimeSheetParamNo";
            //rep.ValueMember = "HRTimeSheetParamNo";
            //rep.ShowHeader = false;
            //rep.TextEditStyle = TextEditStyles.Standard;
            //rep.NullText = string.Empty;
            //LookUpColumnInfo lookupColumn = new LookUpColumnInfo();
            //lookupColumn.FieldName = "HRTimeSheetParamNo";
            //rep.Columns.Add(lookupColumn);
            //column.ColumnEdit = rep;  

            RepositoryItemCheckedComboBoxEdit rep = new RepositoryItemCheckedComboBoxEdit();
            rep.DataSource = dataSource;
            rep.DisplayMember = "HRTimeSheetParamNo";
            rep.ValueMember = "HRTimeSheetParamNo";
            rep.TextEditStyle = TextEditStyles.Standard;
            rep.NullText = string.Empty;
            //LookUpColumnInfo lookupColumn = new LookUpColumnInfo();
            //lookupColumn.FieldName = "HRTimeSheetParamNo";
            //rep.Columns.Add(lookupColumn);
            column.ColumnEdit = rep;
        }
    }
}
