using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Linq;
using VinaERP;
using VinaERP.Modules.TimeSheet;

namespace BOSERP.Modules.TimeSheet
{
    public partial class HREmployeeTimeSheetsGridControl : VinaGridControl
    {
        /// <summary>
        /// Gets or sets the grid view main
        /// </summary>
        public GridView GridViewMain { get; set; }
        /// <summary>
        /// Gets or sets the row hanle of current row selected
        /// </summary>
        public int RowHandle { get; set; }
        public List<ADWorkingShiftsInfo> WorkingShiftList = new List<ADWorkingShiftsInfo>();
        ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
        public override void InitGridControlDataSource()
        {
            TimeSheetEntities entity = (TimeSheetEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.EmployeeTimeSheetsList;
            DataSource = bds;
        }

        public override void InitializeControl()
        {
            GridViewMain = new GridView();
            this.EmbeddedNavigator.Buttons.CustomButtons.Clear();
            base.InitializeControl();
            //Init banded view and make it the main view
            BandedGridView bandedView = InitializeBandedGridView(GridViewMain);
            MainView = bandedView;
            ViewCollection.AddRange(new BaseView[] { bandedView });
            ShowOnlyPredefinedDetails = false;
            WorkingShiftList = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());
            //UseEmbeddedNavigator = false;
        }

        /// <summary>
        /// Initialize BandedGridView
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns></returns>
        private BandedGridView InitializeBandedGridView(GridView gridView)
        {
            TimeSheetEntities entity = (TimeSheetEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;

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
                        ConvertToBandedGridColumn(gridView.Columns[i], false)});
            }
            bandedView.GridControl = this;
            bandedView.Name = "bandedGridView1";
            bandedView.OptionsCustomization.AllowFilter = false;
            bandedView.OptionsView.ShowAutoFilterRow = true;
            bandedView.OptionsView.ColumnAutoWidth = false;
            bandedView.OptionsView.ShowGroupPanel = false;
            bandedView.OptionsCustomization.AllowSort = true;
            bandedView.OptionsView.ShowChildrenInGroupPanel = false;
            bandedView.OptionsView.ShowDetailButtons = false;

            //GridBand1
            gridBand1.Caption = "Thông tin nhân viên";
            gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridBand1.Name = "gridBand1";

            //GridBand2
            gridBand2.Caption = "Danh sách ngày";
            gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand2.Name = "gridBand2";

            //GridBand3
            gridBand3.Caption = "Quy ra công";
            gridBand3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand3.Name = "gridBand3";

            // Assigning columns to bands
            GridColumn column = gridView.Columns["HREmployeeCardNumber"];
            if (column != null)
            {
                CreateNewColumn(column, gridBand1, false);
            }
            column = gridView.Columns["HREmployeeName"];
            if (column != null)
            {
                CreateNewColumn(column, gridBand1, false);
            }

            column = gridView.Columns["HRDepartmentRoomName"];
            if (column != null)
                CreateNewColumn(column, gridBand1, false);

            //int dateStart = objTimeSheetsInfo.HRTimeSheetFromDate.Day;
            for (int i = 1; i <= 31; i++)
            {
                column = gridView.Columns[String.Format("{0}{1}", "HREmployeeTimeSheetDate", i.ToString())];
                if (column != null)
                {
                    CreateNewColumn(column, gridBand2, false);
                }
            }

            column = gridView.Columns["HREmployeeTimeSheetWorkingQty"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand3, false, "n1");
            }

            if (WorkingShiftList != null)
            {
                WorkingShiftList.ForEach(o =>
                {
                    column = gridView.Columns["CONG" + o.ADWorkingShiftID.ToString()];
                    if (column != null)
                    {
                        column.Caption = "Công " + o.ADWorkingShiftName;
                        CreateNumericColumn(column, gridBand3, false, "n5");
                    }
                });
            }

            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            List<HRTimeSheetParamsInfo> OTFactorlist = objTimeSheetParamsController.GetDistinctOTTimeSheetParamsList();
            foreach (var item in OTFactorlist)
            {
                column = gridView.Columns[item.HRTimeSheetParamValue2.ToString()];
                if (column != null)
                {
                    column.Caption = "TC HS " + item.HRTimeSheetParamValue2.ToString();
                    CreateNumericColumn(column, gridBand3, false, "n3");
                }
            }
            column = gridView.Columns["HREmployeeTimeSheetOTQty"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand3, false, "n3");
            }

            column = gridView.Columns["HREmployeeTimeSheetLeaveQty"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand3, false, "n1");
            }

            column = gridView.Columns["HREmployeeTimeSheetNghiLe"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand3, false, "n1");
            }

            bandedView.CustomDrawCell += new RowCellCustomDrawEventHandler(BandedView_CustomDrawCell);
            bandedView.CellValueChanged += new CellValueChangedEventHandler(BandedView_CellValueChanged);
            bandedView.RowClick += new RowClickEventHandler(BandedView_RowClick);
            bandedView.KeyUp += new KeyEventHandler(BandedView_KeyUp);
            return bandedView;
        }

        private void BandedView_RowClick(object sender, RowClickEventArgs e)
        {
            RowHandle = e.RowHandle;
        }

        private void BandedView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((TimeSheetModule)Screen.Module).RemoveEmployeeFromTimeSheetList();
            }
        }

        protected void BandedView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView gridView = (GridView)MainView;
                HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo = (HREmployeeTimeSheetsInfo)gridView.GetRow(e.RowHandle);
                //Update time sheet total quantity
                ((TimeSheetModule)Screen.Module).UpdateTimeSheetTotalQty(objEmployeeTimeSheetsInfo);
            }
        }

        protected void BandedView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            BandedGridView bandedView = (BandedGridView)MainView;
            if (!bandedView.IsValidRowHandle(e.RowHandle))
                return;
            int focusedRowHandle = e.RowHandle;
            if (focusedRowHandle >= 0)
            {
                HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo = bandedView.GetRow(focusedRowHandle) as HREmployeeTimeSheetsInfo;
                if (objEmployeeTimeSheetsInfo != null)
                {
                    if (objEmployeeTimeSheetsInfo.HREmployeeTimeSheetOTDetailsList != null)
                    {
                        foreach (var item in objEmployeeTimeSheetsInfo.HREmployeeTimeSheetOTDetailsList)
                        {
                            if (e.Column.FieldName == item.HREmployeeTimeSheetOTDetailName)
                            {
                                e.DisplayText = item.HREmployeeTimeSheetOTDetailHours.ToString();
                                e.CellValue = item.HREmployeeTimeSheetOTDetailHours;
                            }
                        }
                    }
                    if (objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList != null)
                    {
                        objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.ForEach(o =>
                        {
                            if (e.Column.FieldName == "CONG" + o.FK_ADWorkingShiftID.ToString())
                            {
                                decimal total = (decimal)objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.
                                        Where(x => x.FK_ADWorkingShiftID == o.FK_ADWorkingShiftID
                                                && !x.IsCommonParam)
                                        .Sum(x => x.HRTimeSheetEntryWorkingQty);

                                e.DisplayText = total.ToString("n5");
                            }
                        });
                    }
                }
            }
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowAutoFilterRow = true;
            GridViewMain = gridView;
            return gridView;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column = new GridColumn();
            column.Caption = "Mã nhân viên";
            column.FieldName = "HREmployeeNo";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Mã ID";
            column.FieldName = "HREmployeeCardNumber";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Chi nhánh";
            column.FieldName = "BRBranchName";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Bộ phận";
            column.FieldName = "HRDepartmentRoomName";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Phòng ban";
            column.FieldName = "HRDepartmentName";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Tên nhân viên";
            column.FieldName = "HREmployeeName";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Tổ";
            column.FieldName = "HRDepartmentRoomGroupItemName";
            gridView.Columns.Add(column);

            int numDays = ((TimeSheetModule)Screen.Module).NumOfDayInMonth();
            TimeSheetEntities entity = (TimeSheetEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            for (int i = 1; i <= numDays; i++)
            {
                GridColumn columnDays = new GridColumn();
                DateTime dt = objTimeSheetsInfo.HRTimeSheetFromDate.Date.AddDays(i - 1);
                columnDays.Caption = dt.ToString("dd/MM");
                bool isDayOfWeek = (VinaApp.IsEndOfWeek(dt.DayOfWeek));
                if (isDayOfWeek)
                {
                    columnDays.Caption = "CN (" + dt.ToString("dd/MM") + ")";
                }
                columnDays.FieldName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", i.ToString());
                gridView.Columns.Add(columnDays);
            }
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            List<HRTimeSheetParamsInfo> OTFactorlist = objTimeSheetParamsController.GetDistinctOTTimeSheetParamsList();
            foreach (var item in OTFactorlist)
            {
                column = new GridColumn();
                column.Caption = "TC HS " + item.HRTimeSheetParamValue2.ToString();
                column.FieldName = item.HRTimeSheetParamValue2.ToString();
                column.Tag = item.HRTimeSheetParamValue2;
                gridView.Columns.Add(column);
            }

            if (WorkingShiftList != null)
            {
                WorkingShiftList.ForEach(o =>
                {
                    column = new GridColumn();
                    column.Caption = "Công " + o.ADWorkingShiftName;
                    column.FieldName = "CONG" + o.ADWorkingShiftID.ToString();
                    column.Tag = "CONG" + o.ADWorkingShiftID.ToString();
                    gridView.Columns.Add(column);
                });
            }
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
            if (isAllowEdit)
            {
                RepositoryItemTextEdit rep = new RepositoryItemTextEdit();
                rep.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                rep.Mask.EditMask = "n2";
                rep.Mask.UseMaskAsDisplayFormat = true;
                bandedColumn.ColumnEdit = rep;
            }
            return bandedColumn;
        }

        /// <summary>
        /// Create a new banded column from a grid one
        /// </summary>
        /// <param name="column">Given grid column</param>
        /// <param name="owner">The grid band</param>
        /// <param name="allowEdit">A variable indicates whether the column is editable</param>
        /// <returns>The banded grid column</returns>
        private BandedGridColumn CreateNewColumn(GridColumn column, GridBand owner, bool allowEdit)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = column.Name;
            bandedColumn.Caption = column.Caption;
            bandedColumn.FieldName = column.FieldName;
            bandedColumn.Visible = true;
            //bandedColumn.Width = column.Width;
            bandedColumn.Width = 60;
            bandedColumn.OptionsColumn.AllowEdit = allowEdit;
            bandedColumn.OwnerBand = owner;
            return bandedColumn;
        }

        /// <summary>
        /// Create a new banded column from a grid one in numeric format
        /// </summary>
        /// <param name="column">Given grid column</param>
        /// <param name="owner">The grid band</param>
        /// <param name="allowEdit">A variable indicates whether the column is editable</param>
        /// <returns>The banded grid column</returns>
        private BandedGridColumn CreateNumericColumn(GridColumn column, GridBand owner, bool allowEdit, string formatType)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = column.Name;
            bandedColumn.Caption = column.Caption;
            bandedColumn.FieldName = column.FieldName;
            bandedColumn.Visible = true;
            bandedColumn.Width = 60;
            bandedColumn.OptionsColumn.AllowEdit = allowEdit;
            RepositoryItemTextEdit rep = new RepositoryItemTextEdit();
            rep.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            rep.Mask.EditMask = "n2";
            rep.Mask.UseMaskAsDisplayFormat = true;
            bandedColumn.ColumnEdit = rep;
            bandedColumn.OwnerBand = owner;

            return bandedColumn;
        }

        /// <summary>
        /// Convert a column to a banded column one
        /// </summary>
        /// <param name="gridColumn">Column of GridView</param>
        /// <param name="isAllowEdit">A variable indicates whether the column is editable</param>
        /// <returns>Banded grid column</returns>
        public BandedGridColumn ConvertToBandedGridColumn(GridColumn gridColumn, bool isAllowEdit)
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
    }
}
