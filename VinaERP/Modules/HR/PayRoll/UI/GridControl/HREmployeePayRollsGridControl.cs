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
using DevExpress.Utils;
using VinaLib;
using VinaCommon;
using System.Linq;
using VinaERP;
using VinaERP.Modules.PayRoll;

namespace BOSERP.Modules.PayRoll
{
    public partial class HREmployeePayRollsGridControl : VinaGridControl
    {
        /// <summary>
        /// Gets or sets the grid view main
        /// </summary>
        public GridView GridViewMain { get; set; }
        ADWorkingShiftGroupsController objWorkingShiftGroupsController = new ADWorkingShiftGroupsController();
        ADOTFactorsController objOTFactorsController = new ADOTFactorsController();

        List<ADWorkingShiftGroupsInfo> WorkingShiftGroupsList = new List<ADWorkingShiftGroupsInfo>();
        List<ADOTFactorsInfo> OTFactorlist = new List<ADOTFactorsInfo>();


        public override void InitGridControlDataSource()
        {
            PayRollEntities entity = (PayRollEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.EmployeePayRollsList;
            DataSource = bds;
        }

        public override void InitializeControl()
        {
            base.InitializeControl();
            //Init banded view and make it the main view
            BandedGridView bandedView = InitializeBandedGridView(GridViewMain);
            MainView = bandedView;
            ViewCollection.AddRange(new BaseView[] { bandedView });
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
            GridBand gridBand4 = new GridBand();
            GridBand gridBand5 = new GridBand();
            GridBand gridBand6 = new GridBand();
            GridBand gridBand7 = new GridBand();
            GridBand gridBand8 = new GridBand();
            GridBand gridBand9 = new GridBand();
            GridBand gridBand10 = new GridBand();
            GridBand gridBand11 = new GridBand();
            GridBand gridBand12 = new GridBand();
            bandedView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gridBand1,
            gridBand10,
            gridBand11,
            gridBand12,
            //gridBand2,
            gridBand7,
            //gridBand8,
            //gridBand3,
            gridBand4,
            gridBand9,
            gridBand5,
            gridBand6});
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                bandedView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                        ConvertToBandedGridColumn(gridView.Columns[i], false)});
            }

            bandedView.GridControl = this;
            bandedView.Name = "bandedGridView1";
            bandedView.OptionsCustomization.AllowFilter = false;
            bandedView.OptionsView.ColumnAutoWidth = false;
            bandedView.OptionsView.ShowGroupPanel = false;
            bandedView.OptionsView.ShowDetailButtons = false;
            bandedView.OptionsView.ShowChildrenInGroupPanel = false;

            //GridBand1
            gridBand1.Caption = "Thông tin nhân viên";
            gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridBand1.Name = "gridBand1";

            //GridBand10
            gridBand10.Caption = "Mức lương";
            gridBand10.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand10.Name = "gridBand10";

            //GridBand11
            gridBand11.Caption = "Công làm việc trong tháng";
            gridBand11.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand11.Name = "gridBand11";

            //GridBand12
            gridBand12.Caption = "Tiền lương chi tiết";
            gridBand12.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand12.Name = "gridBand12";

            //GridBand2
            gridBand2.Caption = "Thông tin lương";
            gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand2.Name = "gridBand2";

            //GridBand7
            gridBand7.Caption = string.Empty;
            gridBand7.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand7.Name = "gridBand7";

            //GridBand8
            //gridBand8.Caption = "Khối lượng bốc xếp";
            //gridBand8.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            //gridBand8.Name = "gridBand8";

            //GridBand3
            //gridBand3.Caption = PayRollLocalizedResources.PayRollByTimeSheet;
            //gridBand3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            //gridBand3.Name = "gridBand3";

            //GridBand4
            gridBand4.Caption = "Các khoản cộng thêm";
            gridBand4.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand4.Name = "gridBand4";

            //GridBand5
            gridBand5.Caption = "Các khoản cấn trừ";
            gridBand5.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand5.Name = "gridBand5";

            //GridBand6
            gridBand6.Caption = "Tổng cộng";
            gridBand6.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand6.Name = "gridBand6";

            //GridBand9
            gridBand9.Caption = string.Empty;
            gridBand9.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            gridBand9.Name = "gridBand9";

            // Assigning columns to bands
            GridColumn column;

            column = gridView.Columns["HRDepartmentName"];
            if (column != null)
            {
                CreateNewColumn(column, gridBand1, false);
            }

            column = gridView.Columns["HREmployeeCardNumber"];
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
            {
                CreateNewColumn(column, gridBand1, false);
            }

            column = gridView.Columns["HRLevelName"];
            if (column != null)
            {
                CreateNewColumn(column, gridBand1, false);
            }

            //column = gridView.Columns["HREmployeeStatusCombo"];
            //if (column != null)
            //{
            //    CreateNewColumn(column, gridBand1, false);
            //}

            //column = gridView.Columns["HREmployeeWorkingForm"];
            //if (column != null)
            //{
            //    CreateNewColumn(column, gridBand1, false);
            //}

            //column = gridView.Columns["HREmployeePayRollWorkingSalary"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand1, false);
            //}

            //column = gridView.Columns["HREmployeeCardNumber"];
            //if (column != null)
            //{
            //    CreateNewColumn(column, gridBand1, false);
            //}

            // Ngày công qui định
            //column = gridView.Columns["HREmployeeDaysPerMonth"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand2, false);
            //}

            // Ngày công thử việc
            //column = gridView.Columns["HREmployeePayRollProbationaryRealDaysPerMonth"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand2, false);
            //}

            //// Ngày công học việc
            //column = gridView.Columns["HREmployeePayRollApprenticeRealDaysPerMonth"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand2, false);
            //}

            // Ngày nghỉ hưởng lương
            //column = gridView.Columns["HREmployeePayRollNgayNghiHuongLuong"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand2, false);
            //}

            //// Ngày nghỉ không lương
            //column = gridView.Columns["HREmployeePayRollNgayNghiKhongLuong"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand2, false);
            //}

            //column = gridView.Columns["HREmployeePayrollNghiPhepNam"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand2, false);
            //}

            // Tăng ca
            //column = gridView.Columns["HREmployeePayRollDayOT"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand2, false);
            //}

            // Trực đêm
            //column = gridView.Columns["HREmployeeRealNightsPerMonth"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand2, true);
            //}

            // Lương tháng
            column = gridView.Columns["HREmployeePayRollLuongThang"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand7, false);
            }

            // Lương thử việc
            //column = gridView.Columns["HREmployeePayRollProbationarySalaryAmount"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //// Lương học việc
            //column = gridView.Columns["HREmployeePayRollApprenticeSalaryAmount"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //Lương tăng ca
            column = gridView.Columns["HREmployeePayRollOTSalary"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand7, true);
            }

            // chuyên cần
            //column = gridView.Columns["HREmployeePayRollDiligenceAllowance"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //// Phụ cấp cơm
            //column = gridView.Columns["HREmployeePayRollAllowanceRise"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            // Thưởng KPIs
            //column = gridView.Columns["HREmployeePayRollKPIAllowance"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //Các khoản cộng
            //column = gridView.Columns["HREmployeePayRollOthersAllowance"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //// Phụ cấp điện thoại
            //column = gridView.Columns["HREmployeePayRollExtraSalary"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //// Phụ cấp xăng
            //column = gridView.Columns["HREmployeePayRollAllowanceGasoline"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //// Nhà ở
            //column = gridView.Columns["HREmployeePayRollAllowanceMotel"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            ////Phụ cấp bảo dưỡng xe
            //column = gridView.Columns["HREmployeePayRollAllowanceVehicleMaintenance"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            ////Phụ cấp thử việc
            //column = gridView.Columns["HREmployeePayRollProbationaryExtraSalary"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            ////Phụ cấp công tác
            //column = gridView.Columns["HREmployeePayRollAllowanceWorkSchedule"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            //// Phụ cấp đi tỉnh
            //column = gridView.Columns["HREmployeePayRollProvinceAllowance"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand4, false);
            //}

            // Lương tăng ca
            //foreach (var item in OTFactorlist)
            //{
            //    column = gridView.Columns["t" + item.HRTimeSheetParamValue2.ToString()];
            //    if (column != null)
            //    {
            //        column.Caption = "Tiền TC hệ số " + item.HRTimeSheetParamValue2.ToString();
            //        CreateNumericColumn(column, gridBand4, false);
            //    }
            //}

            // Khen thưởng
            column = gridView.Columns["HREmployeePayRollReward"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand4, true);
            }

            // chuyên cần
            column = gridView.Columns["HREmployeePayRollDiligenceAllowance"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand4, false);
            }

            // Bồi dưỡng ca đêm
            column = gridView.Columns["HREmployeePayRollAllowaceNight"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand4, false);
            }

            CreateN0ColumnVisible(gridBand4, false, true, "Cộng khác", "HREmployeePayRollOtherReward");

            CreateN0ColumnVisible(gridBand4, false, true, "Hoàn tiền thế chân", "HREmployeePayRollBackTheChan");
            // Bù lương
            //column = gridView.Columns["HREmployeeOffsetSalary"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand5, true);
            //}

            // BHXH

            column = gridView.Columns["HREmployeePayRollTotalInsAmt"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, true);
            }

            // Trừ lương trả nợ vay
            column = gridView.Columns["HREmployeePayRollEmployeeLoanMonthlyAmount"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, false);
            }

            // Tạm ứng
            column = gridView.Columns["HREmployeePayRollAdvance"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, true);
            }

            column = gridView.Columns["HREmployeePayRollSyndicateFee"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, true);
            }
            //column = gridView.Columns["HREmployeePayrollBHTaiNan"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand5, true);
            //}

            //column = gridView.Columns["HREmployeePayrollTruThueTNCN"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand5, true);
            //}

            //column = gridView.Columns["HREmployeePayRollSubtractPhoneAmount"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand5, true);
            //}

            //column = gridView.Columns["HREmployeePayRollSubtractLateAmount"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand5, true);
            //}


            //column = gridView.Columns["HREmployeePayRollPurchaseOrder"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand5, true);
            //}

            // Tổng thu nhập
            column = gridView.Columns["HREmployeeLuongDaTru"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand9, false);
            }

            // Nợ lũy tiến
            //column = gridView.Columns["HREmployeeNoLuyTien"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand5, true);
            //}

            //Thực nhận
            column = gridView.Columns["HREmployeePayRollTotalSalary"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand6, false);
            }

            column = gridView.Columns["HREmployeePayRollComment"];
            if (column != null)
            {
                BandedGridColumn bandedColumn = CreateNewColumn(column, gridBand6, true);
                bandedColumn.Width = 150;
            }

            //Khối lượng bốc xếp
            //column = gridView.Columns["HREmployeePayRollSoLuongBoc"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand8, false);
            //}

            //column = gridView.Columns["HREmployeePieceworkSalary"];
            //if (column != null)
            //{
            //    CreateNumericColumn(column, gridBand8, false);
            //}

            //column = gridView.Columns["HREmployeePayRollWarning"];
            //if (column != null)
            //{
            //    CreateClickColumn(column, gridBand6, true);
            //}

            //CreateN0ColumnVisible(gridBand5, false, false, "BHXH doanh nghiệp", "HREmployeePayRollSocialInsDNAmount");

            //CreateN0ColumnVisible(gridBand5, false, false, "BHYT doanh nghiệp", "HREmployeePayRollHealthInsDNAmount");

            //CreateN0ColumnVisible(gridBand5, false, false, "BHTN doanh nghiệp", "HREmployeePayRollOutOfWorkInsDNAmount");

            //CreateN0ColumnVisible(gridBand5, false, false, "BHXH cá nhân", "HREmployeePayRollSocialInsAmount");

            //CreateN0ColumnVisible(gridBand5, false, false, "BHYT cá nhân", "HREmployeePayRollHealthInsAmount");

            //CreateN0ColumnVisible(gridBand5, false, false,"BHTN cá nhân", "HREmployeePayRollOutOfWorkInsAmount");

            //CreateN0ColumnVisible(gridBand5, false, true, "Mức thu nhập chịu thuế", "HREmployeePayRollTaxableIncomeLevel");

            //CreateN0ColumnVisible(gridBand5, false, true, "Thuế TNCN", "HREmployeePayRollPersonalIncomeTax");


            //Mức lương
            CreateN0ColumnVisible(gridBand10, false, true, "Lương cơ bản", "HREmployeeBasicSalary");
            CreateN0ColumnVisible(gridBand10, false, true, "Thâm niên", "HREmployeePayRollPerennialAllowance");
            CreateN0ColumnVisible(gridBand10, false, true, "Bồi dưỡng nghiệp vụ", "HREmployeePayRollEffectiveAllowance");
            CreateN0ColumnVisible(gridBand10, false, true, "Trách nhiệm hàng hoá", "HREmployeePayRollResponsibilityCommodityAllowance");
            CreateN0ColumnVisible(gridBand10, false, true, "Trách nhiệm quản lý", "HREmployeePayRollResponsibilityAllowance");
            CreateN0ColumnVisible(gridBand10, false, true, "Khác", "HREmployeePayRollOtherAllowance");

            //Công làm việc trong tháng
            //ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            //List<ADWorkingShiftsInfo> list = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());
            //HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            //List<int> param = new List<int>();

            //foreach (var item in list)
            //{
            //    if (item.FK_HRTimeSheetParamFactorID > 0)
            //    {
            //        if (!param.Exists(o => o == item.FK_HRTimeSheetParamFactorID))
            //        {
            //            param.Add(item.FK_HRTimeSheetParamFactorID);
            //            column = gridView.Columns[item.FK_HRTimeSheetParamFactorID.ToString()];
            //            if (column != null)
            //            {
            //                HRTimeSheetParamsInfo objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectByID(item.FK_HRTimeSheetParamFactorID);
            //                if (objTimeSheetParamsInfo != null)
            //                {
            //                    column.AppearanceCell.Options.UseTextOptions = true;
            //                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; 
            //                    column.Caption = objTimeSheetParamsInfo.HRTimeSheetParamNo.ToString();
            //                    CreateNumericColumn(column, gridBand11, false);
            //                }
            //            }

            //            column = gridView.Columns["L" + item.FK_HRTimeSheetParamFactorID.ToString()];
            //            if (column != null)
            //            {
            //                HRTimeSheetParamsInfo objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectByID(item.FK_HRTimeSheetParamFactorID);
            //                if (objTimeSheetParamsInfo != null)
            //                {
            //                    column.AppearanceCell.Options.UseTextOptions = true;
            //                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //                    column.Caption = "Lương "+ objTimeSheetParamsInfo.HRTimeSheetParamNo.ToString();
            //                    CreateNumericColumn(column, gridBand12, false);
            //                }
            //            }
            //        }
            //    }
            //}

            foreach (var item in WorkingShiftGroupsList)
            {
                if (item.ADWorkingShiftGroupID > 0)
                {
                    column = gridView.Columns[item.ADWorkingShiftGroupID.ToString()];
                    if (column != null)
                    {
                        column.AppearanceCell.Options.UseTextOptions = true;
                        column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        column.Caption = item.ADWorkingShiftGroupName;
                        CreateNumericColumn(column, gridBand11, false);
                    }

                    column = gridView.Columns["L" + item.ADWorkingShiftGroupID.ToString()];
                    if (column != null)
                    {
                        column.AppearanceCell.Options.UseTextOptions = true;
                        column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        column.Caption = "Lương " + item.ADWorkingShiftGroupName;
                        CreateNumericColumn(column, gridBand12, false);
                    }
                }
            }

            //Phụ cấp công vượt
            column = gridView.Columns["HREmployeePayRollCommission"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand12, false);
            }

            column = gridView.Columns["HREmployeePayrollNghiLeAmount"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand12, false);
            }

            //Tiền ngày
            column = gridView.Columns["HREmployeePayRollUnitPrice"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand10, false);
            }

            //Lương tăng ca
            foreach (var item in OTFactorlist)
            {
                //column = gridView.Columns[item.ADOTFactorValue.ToString()];
                //if (column != null)
                //{
                //    column.AppearanceCell.Options.UseTextOptions = true;
                //    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; 
                //    column.Caption = item.ADOTFactorName.ToString();
                //    CreateNumericColumn(column, gridBand11, false);
                //}

                //column = gridView.Columns["L" + item.ADOTFactorValue.ToString()];
                //if (column != null)
                //{
                //    column.AppearanceCell.Options.UseTextOptions = true;
                //    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                //    column.Caption = "Lương " + item.ADOTFactorName.ToString();
                //    CreateNumericColumn(column, gridBand12, false);
                //}

                column = gridView.Columns["TC" + item.ADOTFactorID.ToString()];
                if (column != null)
                {
                    column.AppearanceCell.Options.UseTextOptions = true;
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    column.Caption = item.ADOTFactorName.ToString();
                    CreateNumericColumn(column, gridBand11, false);
                }

                column = gridView.Columns["LTC" + item.ADOTFactorID.ToString()];
                if (column != null)
                {
                    column.AppearanceCell.Options.UseTextOptions = true;
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    column.Caption = "Lương " + item.ADOTFactorName.ToString();
                    CreateNumericColumn(column, gridBand12, false);
                }
            }

            //Tổng ngày công
            column = gridView.Columns["HREmployeePayRollTongNgayCong"];
            if (column != null)
            {
                CreateN3Column(column, gridBand11, false);
            }

            column = gridView.Columns["HREmployeePayrollNghiLe"];
            if (column != null)
            {
                CreateN3Column(column, gridBand11, false);
            }

            column = gridView.Columns["HREmployeePayrollNghiKPhep"];
            if (column != null)
            {
                CreateN3Column(column, gridBand11, false);
            }

            //trừ KP
            column = gridView.Columns["HREmployeePayRollDaysOffAmount"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, false);
            }

            // Kỷ luật
            column = gridView.Columns["HREmployeePayRollDiscipline"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, true);
            }
            //Trừ khác
            column = gridView.Columns["HREmployeePayrollTruKhac"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, false);
            }
            //Thế chân
            column = gridView.Columns["HREmployeePayRollTheChan"];
            if (column != null)
            {
                CreateNumericColumn(column, gridBand5, false);
            }

            // Ngày công thực tế
            //column = gridView.Columns["HREmployeeRealDaysPerMonth"];
            //if (column != null)
            //{
            //    CreateN3Column(column, gridBand12, false);
            //}


            //[Trần Giao Hiếu][29/03/2019],START
            //thêm trường nào là tiền thì chạy giùm SP này EXEC dbo.EXEC dbo.AAPayRollColumnAlias_InsertByColumnNameAndCaption @columnName = N'HREmployeePayRollSocialInsDNAmount', -- nvarchar(100)
            //@caption = N'BHXH doanh nghiệp'
            //nhớ bỏ trường đó vào ColumnAlias trước rồi hãy chạy SP này,Cảm ơn
            //[Trần Giao Hiếu][29/03/2019],END

            bandedView.CustomDrawCell += new RowCellCustomDrawEventHandler(BandedView_CustomDrawCell);
            bandedView.CellValueChanged += new CellValueChangedEventHandler(BandedView_CellValueChanged);
            bandedView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);
            bandedView.KeyUp += new KeyEventHandler(BandedView_KeyUp);
            return bandedView;
        }

        private void BandedView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                BandedGridView bandedView = (BandedGridView)MainView;
                if (bandedView.FocusedRowHandle >= 0)
                {
                    ((PayRollModule)Screen.Module).RemoveEmployeeFromPayRollList();
                }
            }
        }

        protected void BandedView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            PayRollEntities entity = (PayRollEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BandedGridView bandedView = (BandedGridView)MainView;
            if (bandedView.FocusedRowHandle >= 0)
            {
                HREmployeePayRollsInfo objEmployeePayRollsInfo = (HREmployeePayRollsInfo)bandedView.GetRow(bandedView.FocusedRowHandle);
                ((PayRollModule)Screen.Module).CalculatePayRollTotalAmounts(objEmployeePayRollsInfo);
            }
        }

        protected void BandedView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            BandedGridView bandedView = (BandedGridView)MainView;
            //05-09-2019
            //ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            //List<ADWorkingShiftsInfo> list = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());
            //End

            //Hiển thị lương theo nhóm ca
            int focusedRowHandle = e.RowHandle;
            if (focusedRowHandle >= 0)
            {
                HREmployeePayRollsInfo objEmployeePayRollsInfo = bandedView.GetRow(focusedRowHandle) as HREmployeePayRollsInfo;
                if (objEmployeePayRollsInfo != null)
                {
                    if (e.Column.FieldName == "HREmployeePayRollWarning")
                    {
                        HRPayRollConfigsController objPayRollConfigsController = new HRPayRollConfigsController();
                        HRPayRollConfigsInfo objPayRollConfigsInfo = (HRPayRollConfigsInfo)objPayRollConfigsController.GetPayRollConfigByEmployeeID(objEmployeePayRollsInfo.FK_HREmployeeID);
                        if (objPayRollConfigsInfo != null)
                        {
                            if (objEmployeePayRollsInfo.HREmployeePayRollTotalSalary < objPayRollConfigsInfo.HRPayRollConfigMin)
                            {
                                objEmployeePayRollsInfo.HREmployeePayRollWarning = "Lương thực nhận nhỏ hơn mức lương tối thiểu!";
                                e.Appearance.BackColor = Color.Red;
                            }
                            else if (objEmployeePayRollsInfo.HREmployeePayRollTotalSalary > objPayRollConfigsInfo.HRPayRollConfigMax)
                            {
                                objEmployeePayRollsInfo.HREmployeePayRollWarning = "Lương thực nhận lớn hơn mức lương tối đa!";
                                e.Appearance.BackColor = Color.Red;
                            }
                            else
                            {
                                objEmployeePayRollsInfo.HREmployeePayRollWarning = "";
                            }
                        }
                    }
                    else
                    {

                        foreach (var item in WorkingShiftGroupsList)
                        {
                            if (item.ADWorkingShiftGroupID > 0)
                            {
                                if (e.Column.FieldName == item.ADWorkingShiftGroupID.ToString())
                                {
                                    decimal total = (decimal)objEmployeePayRollsInfo.HREmployeePayrollDetailsList.
                                        Where(o => o.HREmployeeTimeSheetOTDetailName == item.ADWorkingShiftGroupID.ToString()
                                        && !o.IsOT).
                                        Sum(o => o.HREmployeePayrollHours);

                                    e.DisplayText = total.ToString("n4");
                                }
                                else if (e.Column.FieldName == "L" + item.ADWorkingShiftGroupID.ToString())
                                {
                                    decimal total = (decimal)objEmployeePayRollsInfo.HREmployeePayrollDetailsList.
                                        Where(o => o.HREmployeeTimeSheetOTDetailName == item.ADWorkingShiftGroupID.ToString()
                                        && !o.IsOT).
                                        Sum(o => o.HREmployeePayrollSalaryFactor);

                                    e.DisplayText = total.ToString("n0");
                                }
                            }
                        }

                        foreach (var item in OTFactorlist)
                        {
                            if (e.Column.FieldName == string.Format("TC{0}", item.ADOTFactorID.ToString()))
                            {
                                decimal total = (decimal)objEmployeePayRollsInfo.HREmployeePayrollDetailsList.
                                        Where(o => o.HREmployeeTimeSheetOTDetailName == item.ADOTFactorID.ToString()
                                        && o.IsOT).
                                        Sum(o => o.HREmployeePayrollHourFactor);
                                e.DisplayText = total.ToString("n5");
                            }
                            else if (e.Column.FieldName == string.Format("LTC{0}", item.ADOTFactorID.ToString()))
                            {
                                decimal total = (decimal)objEmployeePayRollsInfo.HREmployeePayrollDetailsList.
                                        Where(o => o.HREmployeeTimeSheetOTDetailName == item.ADOTFactorID.ToString()
                                        && o.IsOT).
                                        Sum(o => o.HREmployeePayrollSalaryFactor);

                                e.DisplayText = total.ToString("n0");
                            }
                        }
                    }
                }
            }
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            GridViewMain = gridView;
            WorkingShiftGroupsList = (List<ADWorkingShiftGroupsInfo>)objWorkingShiftGroupsController.GetListFromDataSet(objWorkingShiftGroupsController.GetAllObjects());
            OTFactorlist = (List<ADOTFactorsInfo>)objOTFactorsController.GetListFromDataSet(objOTFactorsController.GetAllObjects());
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
            column.Caption = "Tên nhân viên";
            column.FieldName = "HREmployeeName";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Hệ số lương";
            column.FieldName = "HREmployeeSalaryFactor";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Lương căn bản";
            column.FieldName = "HREmployeeContractSlrAmt";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Lương căn bản";
            column.FieldName = "HREmployeeWorkingSlrAmt";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Thành tiền";
            column.FieldName = "HREmployeePayRollTotalWorkingSalary";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Thành tiền";
            column.FieldName = "HREmployeePayRollTotalAddAmt";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Thành tiền";
            column.FieldName = "HREmployeePayRollTotalDeductedAmt";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Số lượng bốc";
            column.FieldName = "HREmployeePayRollTotalDeductedAmt1";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Lương đầu tấn";
            column.FieldName = "HREmployeePayRollTotalDeductedAmt2";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Tình trạng";
            column.FieldName = "HREmployeeStatusCombo";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Hình thức làm việc";
            column.FieldName = "HREmployeeWorkingForm";
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Thế chân";
            column.FieldName = "HREmployeePayRollTheChan";
            gridView.Columns.Add(column);

            //List<HRTimeSheetParamsInfo> OTFactorlist = objTimeSheetParamsController.GetDistinctOTTimeSheetParamsList();

            OTFactorlist = (List<ADOTFactorsInfo>)objOTFactorsController.GetListFromDataSet(objOTFactorsController.GetAllObjects());
            foreach (var item in OTFactorlist)
            {
                column = new GridColumn();
                column.Caption = item.ADOTFactorName.ToString();
                column.FieldName = string.Format("TC{0}", item.ADOTFactorID.ToString());
                column.Tag = string.Format("TC{0}", item.ADOTFactorID.ToString());
                gridView.Columns.Add(column);

                column = new GridColumn();
                column.Caption = "Lương " + item.ADOTFactorName.ToString();
                column.FieldName = string.Format("LTC{0}", item.ADOTFactorID.ToString());
                column.Tag = string.Format("LTC{0}", item.ADOTFactorID.ToString());
                gridView.Columns.Add(column);
            }

            WorkingShiftGroupsList = (List<ADWorkingShiftGroupsInfo>)objWorkingShiftGroupsController.GetListFromDataSet(objWorkingShiftGroupsController.GetAllObjects());
            foreach (var item in WorkingShiftGroupsList)
            {
                if (item.ADWorkingShiftGroupID > 0)
                {
                    column = new GridColumn();
                    column.Caption = item.ADWorkingShiftGroupName;
                    column.FieldName = item.ADWorkingShiftGroupID.ToString();
                    column.Tag = item.ADWorkingShiftGroupID;
                    gridView.Columns.Add(column);

                    column = new GridColumn();
                    column.Caption = "Lương " + item.ADWorkingShiftGroupName;
                    column.FieldName = "L" + item.ADWorkingShiftGroupID.ToString();
                    column.Tag = "L" + item.ADWorkingShiftGroupID.ToString();
                    gridView.Columns.Add(column);
                }
            }
        }

        private void RpItemComponent_Click(object sender, EventArgs e)
        {
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
            bandedColumn.Width = column.Width;
            bandedColumn.OptionsColumn.AllowEdit = allowEdit;
            bandedColumn.OwnerBand = owner;
            return bandedColumn;
        }

        private BandedGridColumn CreateClickColumn(GridColumn column, GridBand owner, bool allowEdit)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = column.Name;
            bandedColumn.Caption = column.Caption;
            bandedColumn.FieldName = column.FieldName;
            bandedColumn.Visible = true;
            bandedColumn.Width = 200;
            bandedColumn.OptionsColumn.AllowEdit = allowEdit;
            RepositoryItemButtonEdit rpItemComponent = new RepositoryItemButtonEdit();
            rpItemComponent.Name = "Chi tiết";
            rpItemComponent.NullText = "Chi tiết";
            rpItemComponent.Click += new EventHandler(RpItemComponent_Click);
            bandedColumn.ColumnEdit = rpItemComponent;
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
        private BandedGridColumn CreateNumericColumn(GridColumn column, GridBand owner, bool allowEdit)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = column.Name;
            bandedColumn.Caption = column.Caption;
            bandedColumn.FieldName = column.FieldName;
            bandedColumn.Visible = true;
            bandedColumn.Width = 100;
            bandedColumn.OptionsColumn.AllowEdit = allowEdit;
            bandedColumn.AppearanceCell.Options.UseTextOptions = true;
            bandedColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            RepositoryItemTextEdit rep = new RepositoryItemTextEdit();
            rep.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            rep.Mask.EditMask = "n0";
            rep.Mask.UseMaskAsDisplayFormat = true;
            bandedColumn.ColumnEdit = rep;
            bandedColumn.OwnerBand = owner;
            return bandedColumn;
        }

        private BandedGridColumn CreateN0ColumnVisible(GridBand owner, bool allowEdit, bool visible, string caption, string name)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = "col" + name;
            bandedColumn.Caption = caption;
            bandedColumn.FieldName = name;
            bandedColumn.Visible = visible;
            bandedColumn.Width = 100;
            bandedColumn.OptionsColumn.AllowEdit = allowEdit;
            RepositoryItemTextEdit rep = new RepositoryItemTextEdit();
            rep.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            rep.Mask.EditMask = "n0";
            rep.Mask.UseMaskAsDisplayFormat = true;
            bandedColumn.ColumnEdit = rep;
            bandedColumn.OwnerBand = owner;
            return bandedColumn;
        }

        private BandedGridColumn CreateN3Column(GridColumn column, GridBand owner, bool allowEdit)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = column.Name;
            bandedColumn.Caption = column.Caption;
            bandedColumn.FieldName = column.FieldName;
            bandedColumn.Visible = true;
            bandedColumn.Width = 100;
            bandedColumn.OptionsColumn.AllowEdit = allowEdit;
            RepositoryItemTextEdit rep = new RepositoryItemTextEdit();
            rep.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            rep.Mask.EditMask = "n3";
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

        private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "HREmployeeWorkingForm")
            //{
            //    if (e.Value != null)
            //    {
            //        ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            //        ADConfigValuesInfo objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByGroupAndValue("EmployeeWorkingForm", e.Value.ToString());
            //        if (objConfigValuesInfo != null)
            //        {
            //            e.DisplayText = objConfigValuesInfo.ADConfigText;
            //        }
            //    }
            //}
            //if (e.Column.FieldName == "HREmployeeStatusCombo")
            //{
            //    if (e.Value != null)
            //    {
            //        ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            //        ADConfigValuesInfo objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByGroupAndValue("EmployeeStatus", e.Value.ToString());
            //        if (objConfigValuesInfo != null)
            //        {
            //            e.DisplayText = objConfigValuesInfo.ADConfigText;
            //        }
            //    }
            //}
        }
    }
}
