using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaERP.Modules.PayRoll.UI;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.PayRoll
{

    public class PayRollModule : BaseModuleERP
    {
        #region Constant
        public const string PayRollTypeLookupEditName = "fld_lkeHRPayRollType";
        public const string PayRollValueTextBoxName = "fld_txtHRPayRollValue";
        #endregion
        public PayRollModule()
        {
            CurrentModuleName = "PayRoll";
            CurrentModuleEntity = new PayRollEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            return base.ActionSave();

        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            SetMaskForTextBox();
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HRPayRollsInfo mainObject = (HRPayRollsInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.HRPayRollID > 0)
            {
                if (mainObject.HRPayRollStatus == PayRollStatus.New.ToString())
                {
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, true);
                }
                else
                {
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
                }
            }

        }

        public void RemoveSelectedItemFromPayRollItemList()
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            entity.EmployeePayRollsList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HRPayRollsInfo objPayRollsInfo = (HRPayRollsInfo)entity.MainObject;
            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeePayRollsList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    if (!entity.EmployeePayRollsList.Exists("FK_HREmployeeID", objEmployeesInfo.HREmployeeID))
                    {
                        HRTimesheetConfigsController objTimesheetConfigsController = new HRTimesheetConfigsController();
                        HRDepartmentRoomGroupItemsController objDepartmentRoomGroupItemsController = new HRDepartmentRoomGroupItemsController();
                        HREmployeePayRollsInfo employeePayRoll = new HREmployeePayRollsInfo();
                        //SetDefaultValuesFromEmployee(employeePayRoll, objEmployeesInfo);
                        employeePayRoll.HRDepartmentRoomName = objEmployeesInfo.HRDepartmentRoomName;
                        employeePayRoll.HRDepartmentName = objEmployeesInfo.HRDepartmentName;
                        employeePayRoll.HRLevelName = objEmployeesInfo.HRLevelName;
                        employeePayRoll.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                        HREmployeesInfo objEmployeesInfo3 = new HREmployeesInfo();
                        objEmployeesInfo3 = UpdateWorkingForm(objEmployeesInfo);
                        employeePayRoll.HREmployeeStatusCombo = objEmployeesInfo3.HREmployeeStatusCombo;
                        employeePayRoll.HREmployeeWorkingForm = objEmployeesInfo3.HREmployeeWorkingForm;

                        DateTime lastDate = new DateTime(objPayRollsInfo.HRPayRollDate.Year, objPayRollsInfo.HRPayRollDate.Month, DateTime.DaysInMonth(objPayRollsInfo.HRPayRollDate.Year, objPayRollsInfo.HRPayRollDate.Month));
                        DateTime firstDate = new DateTime(objPayRollsInfo.HRPayRollDate.Year, objPayRollsInfo.HRPayRollDate.Month, 1);

                        objPayRollsInfo.FromDate = firstDate;
                        objPayRollsInfo.ToDate = lastDate;


                        HRTimeSheetsController objTimeSheetsController = new HRTimeSheetsController();
                        HREmployeeTimeSheetsController objEmployeeTimeSheetsController = new HREmployeeTimeSheetsController();
                        HREmployeeTranfersController objEmployeeTranfersController = new HREmployeeTranfersController();
                        HRTimeSheetEntrysController objTimeSheetEntrysController = new HRTimeSheetEntrysController();

                        List<HRTimeSheetEntrysInfo> employeeTimeSheetEntryList = new List<HRTimeSheetEntrysInfo>();
                        List<HRTimeSheetEntrysInfo> employeeTimeSheetEntryList1 = new List<HRTimeSheetEntrysInfo>();
                        List<HRTimeSheetEntrysInfo> employeeTimeSheetEntryList2 = new List<HRTimeSheetEntrysInfo>();
                        HREmployeesInfo objEmployeesInfo2;
                        HREmployeePayRollsInfo employeePayRoll2 = new HREmployeePayRollsInfo();
                        //HREmployeeTimeSheets_GetEmployeeTimeSheetBySomeCriteria
                        HREmployeeTimeSheetsInfo employeeTimeSheet = objEmployeeTimeSheetsController.GetEmployeeTimeSheetBySomeCriteria(objEmployeesInfo.HREmployeeID, objPayRollsInfo.HRPayRollDate);
                        if (employeeTimeSheet == null)
                            continue;
                        HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)objTimeSheetsController.GetObjectByID(employeeTimeSheet.FK_HRTimeSheetID);
                        HREmployeeTranfersInfo objEmployeeTranfersInfo = objEmployeeTranfersController.GetEmployeeTranfersByEmployeeIDAndDate(objEmployeesInfo.HREmployeeID, objPayRollsInfo.FromDate, objPayRollsInfo.ToDate);

                        if (objEmployeesInfo.FK_HREmployeePayrollFormulaID > 0)
                        {
                            objEmployeesInfo.HREmployeeDaysPerMonth = objTimesheetConfigsController.GetDaysPerMonthByEmployeeFormullaID(objEmployeesInfo.FK_HREmployeePayrollFormulaID, objPayRollsInfo.HRPayRollDate.Month, objPayRollsInfo.HRPayRollDate.Year);
                            if (objEmployeesInfo.HREmployeeDaysPerMonth == 0)
                            {
                                objEmployeesInfo.HREmployeeDaysPerMonth = CalculationWorkDay(objPayRollsInfo.HRPayRollDate);
                            }
                            SetDefaultValuesFromEmployee(employeePayRoll, objEmployeesInfo);
                            employeePayRoll.HRDepartmentRoomName = objEmployeesInfo.HRDepartmentRoomName;
                            employeePayRoll.HRDepartmentName = objEmployeesInfo.HRDepartmentName;
                            employeePayRoll.HRLevelName = objEmployeesInfo.HRLevelName;
                            employeePayRoll.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                            employeePayRoll.FK_HRDepartmentID = objEmployeesInfo.FK_HRDepartmentID;
                            employeePayRoll.HREmployeePayRollResponsibilityAllowance = objEmployeesInfo.HREmployeeAllowanceResponsibility;
                            //employeePayRoll.HREmployeePayRollKPIAllowance = objEmployeesInfo.HREmployeeAllowanceKPI;
                            employeePayRoll.HREmployeePayRollProgressAllowance = objEmployeesInfo.HREmployeeAllowanceProgress;

                            if (objEmployeeTranfersInfo != null)
                            {
                                // phase 1
                                employeeTimeSheetEntryList = objTimeSheetEntrysController.GetTotalTimeSheetEntryByTimeSheetIDAndEmployeeTimeSheetID(objTimeSheetsInfo.HRTimeSheetID, employeeTimeSheet.HREmployeeTimeSheetID);
                                employeeTimeSheetEntryList1 = employeeTimeSheetEntryList.Where(x => x.HRTimeSheetEntryDate < objEmployeeTranfersInfo.HREmployeeTranferDateFrom).ToList();
                                decimal totalSalaryFactor = 0;
                                decimal totalApprenticeSalaryFactor = 0;
                                decimal totalProbationarySalaryFactor = 0;
                                decimal totalSalaryOTHours = 0;
                                decimal totalApprenticeSalaryOTHours = 0;
                                decimal totalProbationarySalaryOTHours = 0;
                                decimal nghihuongluong = 0;
                                decimal nghihuongluongTV = 0;
                                decimal nghihuongluongHV = 0;
                                decimal nghikhongluong = 0;
                                decimal nghiPN = 0;
                                decimal nghiLe = 0;
                                decimal totalLate = 0;
                                HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();

                                foreach (HRTimeSheetEntrysInfo objTimeSheetEntrysInfo in employeeTimeSheetEntryList1)
                                {
                                    if (objTimeSheetEntrysInfo.IsOT == false)
                                    {
                                        {
                                            totalSalaryFactor += objTimeSheetEntrysInfo.HRTimeSheetEntryWorkingQty;
                                        }
                                    }
                                    else
                                    {
                                        {
                                            totalSalaryOTHours += objTimeSheetEntrysInfo.HRTimeSheetEntryWorkingHours;
                                        }
                                    }
                                    HRTimeSheetParamsInfo objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectByID(objTimeSheetEntrysInfo.FK_HRTimeSheetParamID);
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamType.Equals("Common"))
                                    {
                                        if (objTimeSheetParamsInfo.HRTimeSheetParamValue1 * objTimeSheetParamsInfo.HRTimeSheetParamValue2 > 0)
                                        {
                                            {
                                                nghihuongluong += objTimeSheetParamsInfo.HRTimeSheetParamValue1 * objTimeSheetParamsInfo.HRTimeSheetParamValue2 / 8;
                                            }
                                        }
                                        else
                                        {
                                            nghikhongluong++;
                                        }
                                    }
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamNo.Equals("NPN"))
                                    {
                                        nghiPN++;
                                    }
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamType.Equals(TimeSheetParamType.LE.ToString()))
                                    {
                                        nghiLe++;
                                    }
                                }
                                employeePayRoll.HREmployeePayRollNgayNghiHuongLuong = nghihuongluong + nghihuongluongHV + nghihuongluongTV;
                                employeePayRoll.HREmployeePayRollNgayNghiKhongLuong = nghikhongluong;
                                employeePayRoll.HREmployeePayrollNghiPhepNam = nghiPN;
                                employeePayRoll.HREmployeePayrollNghiLe = nghiLe;
                                // Công thực tế
                                employeePayRoll.HREmployeeRealDaysPerMonth = totalSalaryFactor - nghihuongluong;
                                employeePayRoll.HREmployeePayRollProbationaryRealDaysPerMonth = totalProbationarySalaryFactor - nghihuongluongTV;
                                employeePayRoll.HREmployeePayRollApprenticeRealDaysPerMonth = totalApprenticeSalaryFactor - nghihuongluongHV;

                                employeePayRoll.HREmployeePayRollSubtractLateAmount = totalLate * 30000;
                                // Giờ tăng ca
                                employeePayRoll.HREmployeeHoursOT = totalSalaryOTHours + totalApprenticeSalaryOTHours + totalProbationarySalaryOTHours;
                                //Ngày tăng ca
                                employeePayRoll.HREmployeePayRollDayOT = employeePayRoll.HREmployeeHoursOT > 0 ? (decimal)employeePayRoll.HREmployeeHoursOT / 8 : 0;

                                employeePayRoll.HREmployeePayRollTongNgayCong =
                                    totalSalaryFactor + employeePayRoll.HREmployeePayRollDayOT + totalApprenticeSalaryFactor + totalProbationarySalaryFactor;
                                //SetDefaultValuesFromEmployee(employeePayRoll, objEmployeesInfo);
                                // Lương công việc
                                //employeePayRoll.HREmployeePayRollWorkingSalary = objEmployeesInfo.HREmployeeWorkingSlrAmt;
                                employeePayRoll.HREmployeePayRollWorkingSalary = objEmployeesInfo.HREmployeeContractSlrAmt;
                                // Lương tháng
                                employeePayRoll.HREmployeePayRollLuongThang = employeePayRoll.HREmployeePayRollWorkingSalary * totalSalaryFactor / employeePayRoll.HREmployeeDaysPerMonth;
                                // Lương chưa trừ
                                //employeePayRoll.HREmployeeWorkingSlrAmtFull = employeePayRoll.HREmployeePayRollWorkingSalary * totalSalaryFactor / employeePayRoll.HREmployeeDaysPerMonth;
                                // Lương tăng ca
                                employeePayRoll.HREmployeePayRollOTSalary = (employeePayRoll.HREmployeePayRollWorkingSalary / employeePayRoll.HREmployeeDaysPerMonth / 8) * employeePayRoll.HREmployeeHoursOT * (decimal)1.5;
                                // Bù lương
                                employeePayRoll.HREmployeeOffsetSalary = 0;
                                CalculatePayRoll(employeePayRoll, objEmployeesInfo);
                                //CalculatePayRollTotalAmounts(employeePayRoll);
                                // end phase 1
                                // phase 2
                                objEmployeesInfo2 = new HREmployeesInfo();
                                VinaUtil.CopyObject(employeePayRoll, employeePayRoll2);
                                VinaUtil.CopyObject(objEmployeesInfo, objEmployeesInfo2);

                                employeeTimeSheetEntryList = objTimeSheetEntrysController.GetTotalTimeSheetEntryByTimeSheetIDAndEmployeeTimeSheetID(objTimeSheetsInfo.HRTimeSheetID, employeeTimeSheet.HREmployeeTimeSheetID);
                                employeeTimeSheetEntryList2 = employeeTimeSheetEntryList.Where(x => x.HRTimeSheetEntryDate >= objEmployeeTranfersInfo.HREmployeeTranferDateFrom).ToList();
                                totalSalaryFactor = 0;
                                totalSalaryOTHours = 0;
                                nghihuongluong = 0;
                                nghikhongluong = 0;
                                nghiLe = 0;
                                nghiPN = 0;
                                totalApprenticeSalaryFactor = 0;
                                totalProbationarySalaryFactor = 0;
                                totalApprenticeSalaryOTHours = 0;
                                totalProbationarySalaryOTHours = 0;
                                nghihuongluongTV = 0;
                                nghihuongluongHV = 0;
                                totalLate = 0;
                                foreach (HRTimeSheetEntrysInfo objTimeSheetEntrysInfo in employeeTimeSheetEntryList2)
                                {
                                    if (objTimeSheetEntrysInfo.IsOT == false)
                                    {
                                        {
                                            totalSalaryFactor += objTimeSheetEntrysInfo.HRTimeSheetEntryWorkingQty;
                                        }
                                    }
                                    else
                                    {
                                        {
                                            totalSalaryOTHours += objTimeSheetEntrysInfo.HRTimeSheetEntryWorkingHours;
                                        }
                                    }
                                    HRTimeSheetParamsInfo objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectByID(objTimeSheetEntrysInfo.FK_HRTimeSheetParamID);
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamType.Equals("Common"))
                                    {
                                        if (objTimeSheetParamsInfo.HRTimeSheetParamValue1 * objTimeSheetParamsInfo.HRTimeSheetParamValue2 > 0)
                                        {
                                            {
                                                nghihuongluong += objTimeSheetParamsInfo.HRTimeSheetParamValue1 * objTimeSheetParamsInfo.HRTimeSheetParamValue2 / 8;
                                            }
                                        }
                                        else
                                        {
                                            nghikhongluong++;
                                        }
                                    }
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamNo.Equals("NPN"))
                                    {
                                        nghiPN++;
                                    }
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamType.Equals(TimeSheetParamType.LE.ToString()))
                                    {
                                        nghiLe++;
                                    }
                                }
                                employeePayRoll2.HREmployeePayRollNgayNghiHuongLuong = nghihuongluong + nghihuongluongHV + nghihuongluongTV;
                                employeePayRoll2.HREmployeePayRollNgayNghiKhongLuong = nghikhongluong;
                                employeePayRoll2.HREmployeePayrollNghiPhepNam = nghiPN;
                                employeePayRoll2.HREmployeePayrollNghiLe = nghiLe;
                                // Công thực tế
                                employeePayRoll2.HREmployeeRealDaysPerMonth = totalSalaryFactor - nghihuongluong;
                                employeePayRoll2.HREmployeePayRollProbationaryRealDaysPerMonth = totalProbationarySalaryFactor - nghihuongluongTV;
                                employeePayRoll2.HREmployeePayRollApprenticeRealDaysPerMonth = totalApprenticeSalaryFactor - nghihuongluongHV;

                                employeePayRoll2.HREmployeePayRollSubtractLateAmount = totalLate * 30000;
                                // Giờ tăng ca
                                employeePayRoll2.HREmployeeHoursOT = totalSalaryOTHours + totalApprenticeSalaryOTHours + totalProbationarySalaryOTHours;
                                //Ngày tăng ca
                                employeePayRoll2.HREmployeePayRollDayOT = (decimal)employeePayRoll2.HREmployeeHoursOT > 0 ? (decimal)employeePayRoll2.HREmployeeHoursOT / 8 : 0;

                                employeePayRoll2.HREmployeePayRollTongNgayCong =
                                    totalSalaryFactor + employeePayRoll2.HREmployeePayRollDayOT + totalApprenticeSalaryFactor + totalProbationarySalaryFactor;
                                SetDefaultValuesFromEmployeeTransfer(employeePayRoll2, objEmployeeTranfersInfo);
                                // Lương công việc
                                employeePayRoll2.HREmployeePayRollWorkingSalary = employeePayRoll2.HREmployeeContractSlrAmt;
                                // Lương tháng
                                employeePayRoll2.HREmployeePayRollLuongThang = employeePayRoll2.HREmployeePayRollWorkingSalary * totalSalaryFactor / employeePayRoll2.HREmployeeDaysPerMonth;
                                // Lương chưa trừ
                                //employeePayRoll2.HREmployeeWorkingSlrAmtFull = employeePayRoll2.HREmployeePayRollWorkingSalary * totalSalaryFactor / employeePayRoll2.HREmployeeDaysPerMonth;
                                // Lương tăng ca
                                employeePayRoll2.HREmployeePayRollOTSalary = (employeePayRoll2.HREmployeePayRollWorkingSalary / employeePayRoll2.HREmployeeDaysPerMonth / 8) * employeePayRoll2.HREmployeeHoursOT * (decimal)1.5;
                                // Bù lương
                                employeePayRoll2.HREmployeeOffsetSalary = 0;
                                CalculatePayRoll(employeePayRoll2, objEmployeesInfo);
                                //CalculatePayRollTotalAmounts(employeePayRoll2);
                                // end phase 2
                            }
                            else
                            {
                                employeeTimeSheetEntryList = objTimeSheetEntrysController.GetTotalTimeSheetEntryByTimeSheetIDAndEmployeeTimeSheetID(objTimeSheetsInfo.HRTimeSheetID, employeeTimeSheet.HREmployeeTimeSheetID);

                                decimal totalSalaryFactor = 0;
                                decimal totalApprenticeSalaryFactor = 0;
                                decimal totalProbationarySalaryFactor = 0;
                                decimal totalSalaryOTHours = 0;
                                decimal totalApprenticeSalaryOTHours = 0;
                                decimal totalProbationarySalaryOTHours = 0;
                                decimal nghihuongluong = 0;
                                decimal nghihuongluongTV = 0;
                                decimal nghihuongluongHV = 0;
                                decimal nghikhongluong = 0;
                                decimal nghiPN = 0;
                                decimal nghiLe = 0;
                                decimal totalLate = 0;
                                HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
                                foreach (HRTimeSheetEntrysInfo objTimeSheetEntrysInfo in employeeTimeSheetEntryList)
                                {
                                    if (objTimeSheetEntrysInfo.IsOT == false)
                                    {
                                        {
                                            totalSalaryFactor += objTimeSheetEntrysInfo.HRTimeSheetEntryWorkingQty;
                                        }
                                    }
                                    else
                                    {
                                        {
                                            totalSalaryOTHours += objTimeSheetEntrysInfo.HRTimeSheetEntryWorkingHours;
                                        }
                                    }
                                    HRTimeSheetParamsInfo objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectByID(objTimeSheetEntrysInfo.FK_HRTimeSheetParamID);
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamType.Equals("Common"))
                                    {
                                        if (objTimeSheetParamsInfo.HRTimeSheetParamValue1 * objTimeSheetParamsInfo.HRTimeSheetParamValue2 > 0)
                                        {
                                            {
                                                nghihuongluong += objTimeSheetParamsInfo.HRTimeSheetParamValue1 * objTimeSheetParamsInfo.HRTimeSheetParamValue2 / 8;
                                            }
                                        }
                                        else
                                        {
                                            nghikhongluong++;
                                        }
                                    }
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamNo.Equals("NPN"))
                                    {
                                        nghiPN++;
                                    }
                                    if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamType.Equals(TimeSheetParamType.LE.ToString()))
                                    {
                                        nghiLe++;
                                    }
                                }
                                // Công thực tế
                                employeePayRoll.HREmployeeRealDaysPerMonth = totalSalaryFactor - nghihuongluong;
                                employeePayRoll.HREmployeePayRollProbationaryRealDaysPerMonth = totalProbationarySalaryFactor - nghihuongluongTV;
                                employeePayRoll.HREmployeePayRollApprenticeRealDaysPerMonth = totalApprenticeSalaryFactor - nghihuongluongHV;
                                // Giờ tăng ca
                                employeePayRoll.HREmployeeHoursOT = totalSalaryOTHours + totalApprenticeSalaryOTHours + totalProbationarySalaryOTHours;

                                employeePayRoll.HREmployeePayRollDayOT = (decimal)totalSalaryOTHours > 0 ? (decimal)totalSalaryOTHours / 8 : 0;

                                //SetDefaultValuesFromEmployee(employeePayRoll, objEmployeesInfo);
                                HREmployeeTimeSheetOTDetailsController objEmployeeTimeSheetOTDetailsController = new HREmployeeTimeSheetOTDetailsController();
                                employeeTimeSheet.HREmployeeTimeSheetOTDetailsList = objEmployeeTimeSheetOTDetailsController.GetListTimeSheetOTDetailByEmployeeTimeSheet(employeeTimeSheet.HREmployeeTimeSheetID);
                                List<HREmployeePayrollDetailsInfo> employeePayrollDetails = new List<HREmployeePayrollDetailsInfo>();
                                List<HRTimeSheetParamsInfo> OTFactorlist = objTimeSheetParamsController.GetDistinctOTTimeSheetParamsList();
                                foreach (var otfactor in OTFactorlist)
                                {
                                    HREmployeePayrollDetailsInfo objEmployeePayrollDetailsInfo = new HREmployeePayrollDetailsInfo();
                                    objEmployeePayrollDetailsInfo.HREmployeeTimeSheetOTDetailFactor = otfactor.HRTimeSheetParamValue2;
                                    objEmployeePayrollDetailsInfo.HREmployeeTimeSheetOTDetailName = otfactor.HRTimeSheetParamValue2.ToString();
                                    foreach (var item in employeeTimeSheet.HREmployeeTimeSheetOTDetailsList)
                                    {
                                        if (otfactor.HRTimeSheetParamValue2 == item.HREmployeeTimeSheetOTDetailFactor)
                                        {
                                            objEmployeePayrollDetailsInfo.HREmployeePayrollHours = item.HREmployeeTimeSheetOTDetailHours;
                                            objEmployeePayrollDetailsInfo.HREmployeePayrollBasicSalary = objEmployeesInfo.HREmployeeWorkingSlrAmt;
                                            objEmployeePayrollDetailsInfo.HREmployeePayrollSalaryFactor =
                                                Convert.ToDecimal(VinaUtil.RoundToThousand(Convert.ToDouble((objEmployeePayrollDetailsInfo.HREmployeePayrollBasicSalary / employeePayRoll.HREmployeeDaysPerMonth / (decimal)8) * (objEmployeePayrollDetailsInfo.HREmployeePayrollHours * objEmployeePayrollDetailsInfo.HREmployeeTimeSheetOTDetailFactor))));
                                        }
                                    }
                                    employeePayrollDetails.Add(objEmployeePayrollDetailsInfo);
                                }

                                employeePayRoll.HREmployeePayRollSubtractLateAmount = totalLate * 30000;
                                employeePayRoll.HREmployeePayrollDetailsList = employeePayrollDetails;
                                employeePayRoll.HREmployeePayRollNgayNghiHuongLuong = nghihuongluong + nghihuongluongHV + nghihuongluongTV;
                                employeePayRoll.HREmployeePayRollNgayNghiKhongLuong = nghikhongluong;
                                employeePayRoll.HREmployeePayrollNghiPhepNam = nghiPN;
                                employeePayRoll.HREmployeePayrollNghiLe = nghiLe;
                                employeePayRoll.HREmployeePayRollTongNgayCong =
                                    employeePayRoll.HREmployeePayRollDayOT + employeePayRoll.HREmployeeRealDaysPerMonth
                                    + employeePayRoll.HREmployeePayRollNgayNghiHuongLuong
                                    + employeePayRoll.HREmployeePayRollProbationaryRealDaysPerMonth
                                    + employeePayRoll.HREmployeePayRollApprenticeSalaryAmount;
                                //28/01/2019
                                //SetDefaultValuesFromEmployee(employeePayRoll, objEmployeesInfo);
                                //END
                                // Lương công việc
                                employeePayRoll.HREmployeePayRollWorkingSalary = objEmployeesInfo.HREmployeeContractSlrAmt;
                                // Lương tháng
                                employeePayRoll.HREmployeePayRollLuongThang = employeePayRoll.HREmployeePayRollWorkingSalary * totalSalaryFactor / employeePayRoll.HREmployeeDaysPerMonth;
                                employeePayRoll.HREmployeePayRollApprenticeSalaryAmount = objEmployeesInfo.HREmployeeApprenticeSalaryAmount * totalApprenticeSalaryFactor / employeePayRoll.HREmployeeDaysPerMonth;
                                employeePayRoll.HREmployeePayRollProbationarySalaryAmount = objEmployeesInfo.HREmployeeProbationarySalaryAmount * totalProbationarySalaryFactor / employeePayRoll.HREmployeeDaysPerMonth;
                                // Lương chưa trừ
                                //employeePayRoll.HREmployeeWorkingSlrAmtFull = employeePayRoll.HREmployeePayRollWorkingSalary * employeePayRoll.HREmployeeRealDaysPerMonth / employeePayRoll.HREmployeeDaysPerMonth;
                                // Lương tăng ca
                                employeePayRoll.HREmployeePayRollOTSalary = (decimal)VinaUtil.RoundToThousand(Convert.ToDouble(((employeePayRoll.HREmployeePayRollWorkingSalary
                                    / employeePayRoll.HREmployeeDaysPerMonth / 8) * employeePayRoll.HREmployeeHoursOT * (decimal)1.5)));
                                // Bù lương
                                employeePayRoll.HREmployeeOffsetSalary = 0;
                                CalculatePayRoll(employeePayRoll, objEmployeesInfo);
                                //CalculatePayRollTotalAmounts(employeePayRoll);
                            }
                        }
                        else
                        {
                            employeePayRoll.HRDepartmentRoomName = objEmployeesInfo.HRDepartmentRoomName;
                            employeePayRoll.HRDepartmentName = objEmployeesInfo.HRDepartmentName;
                            employeePayRoll.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                            employeePayRoll.FK_HRDepartmentID = objEmployeesInfo.FK_HRDepartmentID;
                            employeePayRoll.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
                            employeePayRoll.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
                            employeePayRoll.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
                            employeePayRoll.HREmployeeName = objEmployeesInfo.HREmployeeName;
                            objEmployeesInfo3 = UpdateWorkingForm(objEmployeesInfo);
                            employeePayRoll.HREmployeeStatusCombo = objEmployeesInfo3.HREmployeeStatusCombo;
                            employeePayRoll.HREmployeeWorkingForm = objEmployeesInfo3.HREmployeeWorkingForm;

                            // Ngày công qui định
                            employeePayRoll.HREmployeeDaysPerMonth = 0;
                            // Hệ số
                            employeePayRoll.HREmployeeSalaryFactor = 0;
                            // Lương cơ bản
                            employeePayRoll.HREmployeeContractSlrAmt = 0;
                            // Lương công việc
                            employeePayRoll.HREmployeePayRollWorkingSalary = 0;
                        }
                        entity.EmployeePayRollsList.Add(employeePayRoll);
                        if (objEmployeeTranfersInfo != null)
                        {
                            entity.EmployeePayRollsList.Add(employeePayRoll2);
                        }
                    }
                }
                entity.EmployeePayRollsList.GridControl.RefreshDataSource();
            }
        }

        public void UpdateValue()
        {

        }

        public void UpdateItemDate()
        {

        }

        public void SetMaskForTextBox()
        {


        }

        public override void ActionComplete()
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            entity.CompleteTransaction();
            InvalidateToolbar();
        }

        public void RemoveEmployeeFromPayRollList()
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            BandedGridView bandedView = (BandedGridView)entity.EmployeePayRollsList.GridControl.MainView;
            if (bandedView.FocusedRowHandle >= 0)
            {
                int index = bandedView.GetDataSourceRowIndex(bandedView.FocusedRowHandle);
                entity.EmployeePayRollsList.RemoveAt(index);
                bandedView.RefreshData();
            }
        }

        public void CalculatePayRollTotalAmounts(HREmployeePayRollsInfo objEmployeePayRollsInfo)
        {
            if (objEmployeePayRollsInfo != null)
            {
                PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
                HRPayRollsInfo objPayRollsInfo = (HRPayRollsInfo)entity.MainObject;
                HREmployeesController employeeController = new HREmployeesController();
                HREmployeesInfo employee = employeeController.GetObjectByID(objEmployeePayRollsInfo.FK_HREmployeeID) as HREmployeesInfo;
                HREmployeePayrollFormulasController employeePayrollFormulaController = new HREmployeePayrollFormulasController();

                // Phạt / Trừ = Tạm ứng (xăng dầu) + Kỷ luật
                objEmployeePayRollsInfo.HREmployeePayRollTotalDeductedAmt = objEmployeePayRollsInfo.HREmployeePayRollAdvance +
                    objEmployeePayRollsInfo.HREmployeePayRollDiscipline;
                // Các khoản bảo hiểm
                objEmployeePayRollsInfo.HREmployeePayRollTotalInsAmt =
                    objEmployeePayRollsInfo.HREmployeePayRollSocialInsAmount
                    + objEmployeePayRollsInfo.HREmployeePayRollHealthInsAmount
                    + objEmployeePayRollsInfo.HREmployeePayRollIncomeTaxAmount
                    + objEmployeePayRollsInfo.HREmployeePayRollOutOfWorkInsAmount;
                //+ objEmployeePayRollsInfo.HREmployeePayRollSyndicateFee;
                // Lương đã trừ = Lương thu nhập + Phụ cấp + Khen thưởng - Bù lương - (Phạt / Trừ) - BHXH   
                decimal realDaysPerMonth = 0;
                if (objEmployeePayRollsInfo.HREmployeeRealDaysPerMonthBackup > objEmployeePayRollsInfo.HREmployeeRealDaysPerMonth)
                {
                    realDaysPerMonth = objEmployeePayRollsInfo.HREmployeeRealDaysPerMonthBackup;
                }
                else
                {
                    realDaysPerMonth = objEmployeePayRollsInfo.HREmployeeRealDaysPerMonth;
                }

                objEmployeePayRollsInfo.HREmployeePayrollTongCacKhoanTru =
                    objEmployeePayRollsInfo.HREmployeeOffsetSalary
                    + objEmployeePayRollsInfo.HREmployeePayRollTotalDeductedAmt
                    + objEmployeePayRollsInfo.HREmployeePayRollTotalInsAmt
                    + objEmployeePayRollsInfo.HREmployeePayRollSyndicateFee
                    + objEmployeePayRollsInfo.HREmployeePayrollPhiAo
                    + objEmployeePayRollsInfo.HREmployeePayrollPhiTheATM
                    + objEmployeePayRollsInfo.HREmployeePayrollPhiTheTu
                    + objEmployeePayRollsInfo.HREmployeePayrollBHTaiNan
                    + objEmployeePayRollsInfo.HREmployeePayRollSubtractLateAmount
                    + objEmployeePayRollsInfo.HREmployeePayRollSubtractPhoneAmount
                    + objEmployeePayRollsInfo.HREmployeePayRollPersonalIncomeTax
                    + objEmployeePayRollsInfo.HREmployeePayRollDaysOffAmount
                    + objEmployeePayRollsInfo.HREmployeePayrollTruKhac
                    + objEmployeePayRollsInfo.HREmployeePayRollTheChan;

                objEmployeePayRollsInfo.HREmployeePayRollTongPhuCap =
                    objEmployeePayRollsInfo.HREmployeePayRollAllowaceNight +
                    objEmployeePayRollsInfo.HREmployeePayRollOthersAllowance +
                    objEmployeePayRollsInfo.HREmployeePayRollAllowanceGasoline +
                    objEmployeePayRollsInfo.HREmployeePayRollAllowanceMotel +
                    objEmployeePayRollsInfo.HREmployeePayRollAllowanceRise +
                    objEmployeePayRollsInfo.HREmployeePayRollPerennialAllowance +
                    objEmployeePayRollsInfo.HREmployeePayRollExtraSalary +
                    objEmployeePayRollsInfo.HREmployeePayRollResponsibilityAllowance +
                    objEmployeePayRollsInfo.HREmployeePayRollAllowanceVehicleMaintenance +
                    objEmployeePayRollsInfo.HREmployeePayRollProbationaryExtraSalary +
                    objEmployeePayRollsInfo.HREmployeePayRollAllowanceWorkSchedule +
                    objEmployeePayRollsInfo.HREmployeePayRollProvinceAllowance;

                objEmployeePayRollsInfo.HREmployeePayRollTongTienThuong =
                    objEmployeePayRollsInfo.HREmployeePayRollTongKhenThuong +
                    objEmployeePayRollsInfo.HREmployeePayRollKPIAllowance +
                    objEmployeePayRollsInfo.HREmployeePayRollTongCongKhac;

                objEmployeePayRollsInfo.HREmployeeLuongDaTru = 0;
                objEmployeePayRollsInfo.HREmployeePayRollLuongThang = 0;
                if (objEmployeePayRollsInfo.HREmployeePayrollDetailsList != null)
                {
                    objEmployeePayRollsInfo.HREmployeePayRollOTSalary = (decimal)objEmployeePayRollsInfo.HREmployeePayrollDetailsList.Where(o => o.IsOT == true).Sum(o => o.HREmployeePayrollSalaryFactor);
                    objEmployeePayRollsInfo.HREmployeePayRollLuongThang = (decimal)objEmployeePayRollsInfo.HREmployeePayrollDetailsList.Where(o => o.IsOT == false).Sum(o => o.HREmployeePayrollSalaryFactor);
                }

                objEmployeePayRollsInfo.HREmployeePayRollLuongThang += objEmployeePayRollsInfo.HREmployeePayrollNghiLeAmount + objEmployeePayRollsInfo.HREmployeePayRollCommission;
                objEmployeePayRollsInfo.HREmployeeLuongDaTru = objEmployeePayRollsInfo.HREmployeePayRollLuongThang + objEmployeePayRollsInfo.HREmployeePayRollOTSalary;

                objEmployeePayRollsInfo.HREmployeeLuongDaTru += objEmployeePayRollsInfo.HREmployeePayRollTongTienThuong
                                                                + objEmployeePayRollsInfo.HREmployeePayRollOthersAllowance
                                                                + objEmployeePayRollsInfo.HREmployeePayRollAllowaceNight;

                objEmployeePayRollsInfo.HREmployeePayRollThamNien = (int)((objPayRollsInfo.HRPayRollDate - employee.HREmployeeStartWorkingDate).Days / 365);
                objEmployeePayRollsInfo.HREmployeePayRollMucKPI = employee.HREmployeeAllowanceKPI;
                objEmployeePayRollsInfo.HREmployeePayRollCongLamViec = objEmployeePayRollsInfo.HREmployeeRealDaysPerMonth + objEmployeePayRollsInfo.HREmployeePayRollProbationaryRealDaysPerMonth + objEmployeePayRollsInfo.HREmployeePayRollApprenticeRealDaysPerMonth;

                //objEmployeePayRollsInfo.HREmployeePayRollEmployeeLoanMonthlyAmount = (decimal)list.Sum(o => o.HRAdvanceRequestItemLoanDetailTotalAmount); 
                objEmployeePayRollsInfo.HREmployeePayRollEmployeeLoanMonthlyAmount = 0;
                List<string> dsLoanMonthlyID = new List<string>();
                if (dsLoanMonthlyID != null && dsLoanMonthlyID.Count() > 0)
                {
                    objEmployeePayRollsInfo.FK_HREmployeePayRollAdvanceRequestItemLoanDetails = string.Join(",", dsLoanMonthlyID.ToArray());
                }

                //objEmployeePayRollsInfo.HREmployeePayRollEmployeeLoanMonthlyAmount = GetEmployeeLoanMonthlyAmount(objEmployeePayRollsInfo.FK_HREmployeeID, objPayRollsInfo.HRPayRollDate, AdvanceRequestType.Loan.ToString());
                // Tổng lương thực nhận = Lương đã trừ + Doanh số + Nợ lũy tiến
                objEmployeePayRollsInfo.HREmployeePayRollTotalSalary =
                    objEmployeePayRollsInfo.HREmployeeLuongDaTru
                    - objEmployeePayRollsInfo.HREmployeePayRollEmployeeLoanMonthlyAmount
                    - objEmployeePayRollsInfo.HREmployeePayrollTongCacKhoanTru;
            }
        }

        public HREmployeesInfo UpdateWorkingForm(HREmployeesInfo objEmployeesInfo)
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            DateTime currentDay = DateTime.Now;
            if (objEmployeesInfo != null)
            {
                if (currentDay.Date >= objEmployeesInfo.HREmployeeApprenticeStartDate.Date && currentDay <= objEmployeesInfo.HREmployeeApprenticeEndDate.Date)
                {
                    objEmployeesInfo.HREmployeeWorkingForm = EmployeeWorkingForm.Apprentice.ToString();
                }
                else if (currentDay.Date >= objEmployeesInfo.HREmployeeProbationaryStartDate.Date && currentDay <= objEmployeesInfo.HREmployeeProbationaryEndDate.Date)
                {
                    objEmployeesInfo.HREmployeeWorkingForm = EmployeeWorkingForm.Probationary.ToString();
                }
                else if (currentDay.Date >= objEmployeesInfo.HREmployeeStartWorkingDate.Date && currentDay <= objEmployeesInfo.HREmployeeStopWorkingDate.Date)
                {
                    objEmployeesInfo.HREmployeeWorkingForm = EmployeeWorkingForm.Official.ToString();
                }

                objEmployeesController.UpdateObject(objEmployeesInfo);
            }
            return objEmployeesInfo;
        }

        public int CalculationWorkDay(DateTime date)
        {
            int dem = 0;
            int loop = 1;
            DateTime f = new DateTime(date.Year, date.Month, 01);
            int x = DateTime.DaysInMonth(date.Year, date.Month);
            while (loop <= x)
            {
                dem = dem + 1;
                if (f.DayOfWeek == DayOfWeek.Sunday)
                {
                    dem = dem - 1;
                }
                f = f.AddDays(1);
                loop++;
            }

            return dem;
        }

        public void SetDefaultValuesFromEmployee(HREmployeePayRollsInfo objEmployeePayRollsInfo, HREmployeesInfo objEmployeesInfo)
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HRPayRollsInfo objPayRollsInfo = (HRPayRollsInfo)entity.MainObject;
            objEmployeePayRollsInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
            objEmployeePayRollsInfo.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
            objEmployeePayRollsInfo.FK_HRLevelID = objEmployeesInfo.FK_HRLevelID;
            objEmployeePayRollsInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
            objEmployeePayRollsInfo.HREmployeeName = objEmployeesInfo.HREmployeeName;
            HREmployeesInfo objEmployeesInfo2 = new HREmployeesInfo();
            objEmployeesInfo2 = UpdateWorkingForm(objEmployeesInfo);
            objEmployeePayRollsInfo.HREmployeeStatusCombo = objEmployeesInfo2.HREmployeeStatusCombo;
            objEmployeePayRollsInfo.HREmployeeWorkingForm = objEmployeesInfo2.HREmployeeWorkingForm;
            // Ngày công qui định
            objEmployeePayRollsInfo.HREmployeeDaysPerMonth = objEmployeesInfo.HREmployeeDaysPerMonth;
            // Hệ số
            objEmployeePayRollsInfo.HREmployeeSalaryFactor = objEmployeesInfo.HREmployeeSalaryFactor;
            // Lương cơ bản
            objEmployeePayRollsInfo.HREmployeeContractSlrAmt = objEmployeesInfo.HREmployeeContractSlrAmt;
            // Lương công việc
            objEmployeePayRollsInfo.HREmployeeWorkingSlrAmt = objEmployeesInfo.HREmployeeWorkingSlrAmt;
            CalculatePayRoll(objEmployeePayRollsInfo, objEmployeesInfo);
            entity.EmployeePayRollsList.GridControl.RefreshDataSource();
        }

        public void CalculatePayRoll(HREmployeePayRollsInfo employeePayRoll, HREmployeesInfo employee)
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HRPayRollsInfo payroll = (HRPayRollsInfo)entity.MainObject;
            if (payroll.FromDate == DateTime.MinValue && payroll.ToDate == DateTime.MinValue)
            {
                if (payroll.FK_HRTimeSheetID > 0)
                {
                    HRTimeSheetsController objTimeSheetsController = new HRTimeSheetsController();
                    HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)objTimeSheetsController.GetObjectByID(payroll.FK_HRTimeSheetID);
                    payroll.FromDate = objTimeSheetsInfo.HRTimeSheetFromDate;
                    payroll.ToDate = objTimeSheetsInfo.HRTimeSheetToDate;
                }
                else
                {
                    DateTime lastDate = new DateTime(payroll.HRPayRollDate.Year, payroll.HRPayRollDate.Month, DateTime.DaysInMonth(payroll.HRPayRollDate.Year, payroll.HRPayRollDate.Month));
                    DateTime firstDate = new DateTime(payroll.HRPayRollDate.Year, payroll.HRPayRollDate.Month, 1);

                    payroll.FromDate = firstDate;
                    payroll.ToDate = lastDate;

                }
            }
            int daysInMonth = DateTime.DaysInMonth(payroll.HRPayRollDate.Year, payroll.HRPayRollDate.Month);
            int endOfWeekCount = 0;
            if (employee.HREmployeeDaysPerMonth == -1)
            {
                for (int i = 1; i <= daysInMonth; i++)
                {
                    DateTime date = new DateTime(payroll.HRPayRollDate.Year, payroll.HRPayRollDate.Month, i);
                    if (VinaApp.IsEndOfWeek(date.DayOfWeek))
                    {
                        endOfWeekCount++;
                    }
                }
            }
            else
            {
                endOfWeekCount = Convert.ToInt32(employee.HREmployeeDaysPerMonth);
            }
            // Lương = Công thức tính lương
            DateTime dateFrom = payroll.FromDate;
            DateTime dateTo = payroll.ToDate;
            decimal totalWorkingSalary = 0;
            HREmployeePayrollFormulasController payrollController = new HREmployeePayrollFormulasController();
            HREmployeePayrollFormulasInfo objEmployeePayrollFormulasInfo = (HREmployeePayrollFormulasInfo)payrollController.GetObjectByID(employee.FK_HREmployeePayrollFormulaID);
            HREmployeePayrollFormulaItemsController objEPFIController = new HREmployeePayrollFormulaItemsController();
            List<HREmployeePayrollFormulaItemsInfo> payrollFormulaItemList = objEPFIController.GetEmployeePayrollFormulaItemsByEmployeePayrollFormullaID(employee.FK_HREmployeePayrollFormulaID);

            employeePayRoll.HREmployeePayRollOtherReward = 0;
            employeePayRoll.HREmployeePayRollTongCongKhac = 0;

            foreach (HREmployeePayrollFormulaItemsInfo obj in payrollFormulaItemList)
            {
                // Khen thưởng  
                if (obj.HREmployeePayrollFormulaSalaryType.Equals("Khenthuong"))
                {
                    totalWorkingSalary = employeePayRoll.HREmployeePayRollWorkingSalary;
                    employeePayRoll.HREmployeePayRollReward = 0;
                    employeePayRoll.FK_HREmployeePayRollAllowance = "";
                    employeePayRoll.HREmployeePayRollTongKhenThuong = 0;
                    employeePayRoll.HREmployeePayRollDiligenceAllowance = 0;
                    employeePayRoll.HREmployeePayRollBackTheChan = 0;
                    HRRewardsController objRewardsController = new HRRewardsController();
                    HREmployeeRewardsController objEmployeeRewardsController = new HREmployeeRewardsController();
                    //DataSet dsReward = objEmployeeRewardsController.GetEmployeeRewardByEmployeeIDAndDate(employee.HREmployeeID, payroll.HRPayRollDate);
                    DataSet dsReward = objRewardsController.GetRewardListByEmployeeIDAndRewardFromDate(employee.HREmployeeID, dateFrom, dateTo);
                    decimal rewardValue = 0;
                    if (dsReward.Tables[0].Rows.Count > 0)
                    {
                        HREmployeeRewardsInfo objEmployeeRewardsInfo = new HREmployeeRewardsInfo();
                        HRRewardsInfo objRewardsInfo = new HRRewardsInfo();
                        List<string> dsRewardID = new List<string>();
                        foreach (DataRow row in dsReward.Tables[0].Rows)
                        {
                            objRewardsInfo = (HRRewardsInfo)objRewardsController.GetObjectFromDataRow(row);
                            objEmployeeRewardsInfo = (HREmployeeRewardsInfo)objEmployeeRewardsController.GetEmployeeRewardsInfoByEmployeeIDAndRewardID(employee.HREmployeeID, objRewardsInfo.HRRewardID);
                            if (objRewardsInfo.HRRewardOption.Equals("AddToSalary"))
                            {
                                dsRewardID.Add(objRewardsInfo.HRRewardID.ToString());
                                if (objRewardsInfo.HRRewardType.Equals(RewardType.TichLuy.ToString()))
                                {
                                    //employeePayRoll.HREmployeePayRollReward += Convert.ToDouble(objEmployeeRewardsInfo.HREmployeeRewardValue);
                                    employeePayRoll.HREmployeePayRollReward += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                    employeePayRoll.HREmployeePayRollTongKhenThuong += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                                else if (objRewardsInfo.HRRewardType.Equals(RewardType.ChuyenCan.ToString()))
                                {
                                    employeePayRoll.HREmployeePayRollDiligenceAllowance += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                    employeePayRoll.HREmployeePayRollTongKhenThuong += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                                else if (objRewardsInfo.HRRewardType.Equals(RewardType.Other.ToString()))
                                {
                                    employeePayRoll.HREmployeePayRollOtherReward += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                    employeePayRoll.HREmployeePayRollTongKhenThuong += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                                else if (objRewardsInfo.HRRewardType.Equals(RewardType.RefundTheChan.ToString()))
                                {
                                    employeePayRoll.HREmployeePayRollBackTheChan += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                    employeePayRoll.HREmployeePayRollTongKhenThuong += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                            }
                            else
                            {
                                dsRewardID.Add(objRewardsInfo.HRRewardID.ToString());
                                if (objRewardsInfo.HRRewardType.Equals(RewardType.TichLuy.ToString()))
                                {
                                    employeePayRoll.HREmployeePayRollReward += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                                else if (objRewardsInfo.HRRewardType.Equals(RewardType.ChuyenCan.ToString()))
                                {
                                    employeePayRoll.HREmployeePayRollDiligenceAllowance += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                                else if (objRewardsInfo.HRRewardType.Equals(RewardType.Other.ToString()))
                                {
                                    employeePayRoll.HREmployeePayRollOtherReward += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                                else if (objRewardsInfo.HRRewardType.Equals(RewardType.RefundTheChan.ToString()))
                                {
                                    employeePayRoll.HREmployeePayRollBackTheChan += objEmployeeRewardsInfo.HREmployeeRewardValueAmount;
                                }
                            }
                        }
                        if (dsRewardID != null && dsRewardID.Count() > 0)
                        {
                            employeePayRoll.FK_HREmployeePayRollAllowance = string.Join(",", dsRewardID.ToArray());
                        }
                        employeePayRoll.HREmployeePayRollReward = employeePayRoll.HREmployeePayRollReward;
                    }
                }
                // Kỷ luật
                if (obj.HREmployeePayrollFormulaSalaryType.Equals("Kyluat"))
                {
                    employeePayRoll.HREmployeePayRollDiscipline = 0;
                    employeePayRoll.HREmployeePayRollSubtractPhoneAmount = 0;
                    employeePayRoll.HREmployeePayrollTruKhac = 0;
                    employeePayRoll.FK_HREmployeePayRollDiscipline = "";
                    employeePayRoll.HREmployeePayRollTheChan = 0;

                    HREmployeeDisciplinesController objEmployeeDisciplinesController = new HREmployeeDisciplinesController();
                    HRDisciplinesController objDisciplinesController = new HRDisciplinesController();
                    //DataSet dsDiscipline = objEmployeeDisciplinesController.GetEmployeeDisciplinedByEmployeeIDAndDate(employee.HREmployeeID, payroll.HRPayRollDate);
                    DataSet dsDiscipline = objDisciplinesController.GetDisciplineListByEmployeeIDAndDisciplineFromDate(employee.HREmployeeID, dateFrom, dateTo);
                    if (dsDiscipline.Tables[0].Rows.Count > 0)
                    {
                        HREmployeeDisciplinesInfo objEmployeeDisciplinesInfo = new HREmployeeDisciplinesInfo();
                        HRDisciplinesInfo objDisciplinesInfo = new HRDisciplinesInfo();
                        List<string> dsDisciplineID = new List<string>();
                        foreach (DataRow row in dsDiscipline.Tables[0].Rows)
                        {
                            objDisciplinesInfo = (HRDisciplinesInfo)objDisciplinesController.GetObjectFromDataRow(row);
                            objEmployeeDisciplinesInfo = (HREmployeeDisciplinesInfo)objEmployeeDisciplinesController.GetEmployeeDisciplinesInfoByEmployeeIDAndDisciplineID(employee.HREmployeeID, objDisciplinesInfo.HRDisciplineID);
                            if (objDisciplinesInfo.HRDisciplineOption.Equals("AddToSalary"))
                            {
                                dsDisciplineID.Add(objDisciplinesInfo.HRDisciplineID.ToString());

                                if (objDisciplinesInfo.HRDisciplineDocumentType == DisciplineDocumentType.Phone.ToString())
                                {
                                    employeePayRoll.HREmployeePayRollSubtractPhoneAmount += objEmployeeDisciplinesInfo.HREmployeeDisciplineValueAmount;
                                }
                                else
                                {
                                    if (objDisciplinesInfo.HRDisciplineType.Equals(DisciplineType.Other.ToString()))
                                    {
                                        employeePayRoll.HREmployeePayrollTruKhac += objEmployeeDisciplinesInfo.HREmployeeDisciplineValueAmount;
                                    }
                                    else if (objDisciplinesInfo.HRDisciplineType.Equals(DisciplineType.TheChan.ToString()))
                                    {
                                        employeePayRoll.HREmployeePayRollTheChan += objEmployeeDisciplinesInfo.HREmployeeDisciplineValueAmount;
                                    }
                                    else if (!string.IsNullOrEmpty(objDisciplinesInfo.HRDisciplineType))
                                    {
                                        employeePayRoll.HREmployeePayRollDiscipline += objEmployeeDisciplinesInfo.HREmployeeDisciplineValueAmount;
                                    }
                                }
                                //TNDLoc [ADD][26/01/2016][Issue discipline],END
                            }
                        }
                        if (dsDisciplineID != null && dsDisciplineID.Count() > 0)
                        {
                            employeePayRoll.FK_HREmployeePayRollDiscipline = string.Join(",", dsDisciplineID.ToArray());
                        }
                        employeePayRoll.HREmployeePayRollDiscipline = employeePayRoll.HREmployeePayRollDiscipline;
                    }
                }

                // Phụ cấp
                if (obj.HREmployeePayrollFormulaSalaryType.Equals("Phucap"))
                {
                    decimal conglamviec = employeePayRoll.HREmployeeRealDaysPerMonth + employeePayRoll.HREmployeePayRollProbationaryRealDaysPerMonth + employeePayRoll.HREmployeePayRollApprenticeRealDaysPerMonth;

                    HRAllowancesController objAllowancesController = new HRAllowancesController();
                    HREmployeeAllowancesController objEmployeeAllowancesController = new HREmployeeAllowancesController();
                    HRFormAllowancesController objFormAllowancesController = new HRFormAllowancesController();
                    HRAllowanceConfigsController objAllowanceConfigsController = new HRAllowanceConfigsController();
                    List<HRAllowanceConfigsInfo> objAllowanceConfigs = new List<HRAllowanceConfigsInfo>();
                    objAllowanceConfigs = objAllowanceConfigsController.GetAllowanceConfigByFKEmployeePayrollFormula(employee.FK_HREmployeePayrollFormulaID);

                    //DateTime currentDay = BOSApp.GetCurrentServerDate();
                    DateTime currentDay = payroll.ToDate;

                    List<HRFormAllowancesInfo> objFormAllowances = new List<HRFormAllowancesInfo>();
                    objFormAllowances = (List<HRFormAllowancesInfo>)objFormAllowancesController.GetListFromDataSet(objFormAllowancesController.GetAllObjects());

                    employeePayRoll.HREmployeePayRollOthersAllowance = 0;
                    employeePayRoll.HREmployeePayRollAllowanceGasoline = 0;
                    employeePayRoll.HREmployeePayRollAllowanceMotel = 0;
                    employeePayRoll.HREmployeePayRollAllowanceRise = 0;
                    //employeePayRoll.HREmployeePayRollDiligenceAllowance = 0;
                    employeePayRoll.HREmployeePayRollPerennialAllowance = 0;
                    employeePayRoll.HREmployeePayRollExtraSalary = 0;
                    //Trách nhiệm quản lý
                    employeePayRoll.HREmployeePayRollResponsibilityAllowance = 0;
                    employeePayRoll.HREmployeePayRollAllowanceVehicleMaintenance = 0;
                    employeePayRoll.HREmployeePayRollProbationaryExtraSalary = 0;
                    employeePayRoll.HREmployeePayRollAllowanceWorkSchedule = 0;
                    employeePayRoll.HREmployeePayRollProvinceAllowance = 0;
                    employeePayRoll.HREmployeePayRollAllowaceNight = 0;


                    //Trách nhiệm hàng hoá
                    employeePayRoll.HREmployeePayRollResponsibilityCommodityAllowance = 0;
                    //Lành nghề
                    employeePayRoll.HREmployeePayRollEffectiveAllowance = 0;
                    //khác
                    employeePayRoll.HREmployeePayRollOtherAllowance = 0;


                    objFormAllowances.ForEach(o =>
                    {
                        if (o.HRFormAllowanceType == HRFormAllowanceType.CoDinh.ToString())
                        {
                            if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapdienthoai.ToString())
                            {
                                employeePayRoll.HREmployeePayRollExtraSalary += employee.HREmployeeExtraSalary1;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaptrachnhiem.ToString())
                            {
                                employeePayRoll.HREmployeePayRollResponsibilityAllowance += employee.HREmployeeAllowanceResponsibility;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapnhao.ToString())
                            {
                                employeePayRoll.HREmployeePayRollAllowanceMotel += employee.HREmployeeAllowanceMotel;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapxang.ToString())
                            {
                                employeePayRoll.HREmployeePayRollAllowanceGasoline += employee.HREmployeeAllowanceGasoline;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.PCBaoduongxe.ToString())
                            {
                                employeePayRoll.HREmployeePayRollAllowanceVehicleMaintenance += employee.HREmployeeAllowanceVehicleMaintenance;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapthuviec.ToString())
                            {
                                employeePayRoll.HREmployeePayRollProbationaryExtraSalary += employee.HREmployeeProbationaryExtraSalary;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaptrachnhiemhanghoa.ToString())
                            {
                                employeePayRoll.HREmployeePayRollResponsibilityCommodityAllowance += employee.HREmployeeAllowanceProgress;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Khac.ToString())
                            {
                                employeePayRoll.HREmployeePayRollOtherAllowance += employee.HREmployeeAllowanceOther;
                            }
                            else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaplanhnghe.ToString())
                            {
                                employeePayRoll.HREmployeePayRollEffectiveAllowance += employee.HREmployeeAllowanceEffective;
                            }
                        }
                        else if (o.HRFormAllowanceType == HRFormAllowanceType.MucChung.ToString())
                        {
                            if (objAllowanceConfigs.Count() > 0)
                            {
                                objAllowanceConfigs.ForEach(x =>
                                {
                                    if (o.HRFormAllowanceID == x.FK_HRFormAllowanceID)
                                    {
                                        decimal amount = x.HRAllowanceConfigAmount;
                                        if (x.HRAllowanceConfigIsTimeKeeping)
                                        {
                                            amount = x.HRAllowanceConfigAmount * conglamviec;
                                        }

                                        if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapthamnien.ToString())
                                        {
                                            int sub = (currentDay - employee.HREmployeeStartWorkingDate).Days;
                                            if (sub > 0)
                                            {
                                                if ((sub / 365 >= x.HRAllowanceConfigFromDate) && (sub / 365 <= x.HRAllowanceConfigToDate))
                                                {
                                                    employeePayRoll.HREmployeePayRollPerennialAllowance = amount;
                                                }
                                                else if ((sub / 365 >= x.HRAllowanceConfigFromDate) && (x.HRAllowanceConfigToDate == 0))
                                                {
                                                    employeePayRoll.HREmployeePayRollPerennialAllowance = amount;
                                                }
                                            }
                                        }
                                        else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Khac.ToString())
                                        {
                                            employeePayRoll.HREmployeePayRollOtherAllowance += amount;
                                        }
                                        else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaptrachnhiemhanghoa.ToString())
                                        {
                                            employeePayRoll.HREmployeePayRollResponsibilityCommodityAllowance += amount;
                                        }
                                        else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaplanhnghe.ToString())
                                        {
                                            employeePayRoll.HREmployeePayRollEffectiveAllowance += amount;
                                        }
                                        else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapcadem.ToString())
                                        {
                                            decimal totalNightWorkingShift = 0;
                                            if (employeePayRoll.HREmployeePayrollDetailsList != null)
                                            {
                                                employeePayRoll.HREmployeePayrollDetailsList.ForEach(y =>
                                                {
                                                    if (y.IsNight)
                                                    {
                                                        totalNightWorkingShift++;
                                                    }
                                                });
                                            }
                                            if (x.HRAllowanceConfigIsTimeKeeping)
                                            {
                                                employeePayRoll.HREmployeePayRollAllowaceNight += x.HRAllowanceConfigAmount * totalNightWorkingShift;
                                            }
                                            else
                                            {
                                                employeePayRoll.HREmployeePayRollAllowaceNight += x.HRAllowanceConfigAmount;
                                            }
                                        }
                                        else if (o.HRFormAllowanceNameType == HRFormAllowanceNameType.Tienantangca.ToString())
                                        {
                                            if (employeePayRoll.HRTimeSheetEntrysList != null)
                                            {
                                                DateTime dateTemp = dateFrom.Date;
                                                while (dateTemp.Date <= dateTo.Date)
                                                {
                                                    decimal totalOTHour = employeePayRoll.HRTimeSheetEntrysList.Where(z => z.IsOT && z.HRTimeSheetEntryDate.Date == dateTemp.Date).Sum(z => z.HRTimeSheetParamValue1);
                                                    if (((totalOTHour >= x.HRAllowanceConfigFromDate) && (totalOTHour <= x.HRAllowanceConfigToDate))
                                                        || ((totalOTHour >= x.HRAllowanceConfigFromDate) && (x.HRAllowanceConfigToDate == 0)))
                                                    {
                                                        employeePayRoll.HREmployeePayRollOtherReward += amount;
                                                        employeePayRoll.HREmployeePayRollTongCongKhac += amount;
                                                    }
                                                    dateTemp = dateTemp.AddDays(1);
                                                }
                                            }
                                        }
                                    }
                                });
                            }
                        }
                    });
                    DataSet dsAllowances = objAllowancesController.GetAllowanceListByEmployeeIDAndAllowanceFromDate(employee.HREmployeeID, dateFrom, dateTo);
                    decimal allowanceValue = 0;
                    if (dsAllowances.Tables[0].Rows.Count > 0)
                    {
                        HREmployeeAllowancesInfo objEmployeeAllowancesInfo = new HREmployeeAllowancesInfo();
                        HRAllowancesInfo objAllowancesInfo = new HRAllowancesInfo();
                        HRFormAllowancesInfo objFormAllowancesInfo = new HRFormAllowancesInfo();
                        foreach (DataRow row in dsAllowances.Tables[0].Rows)
                        {
                            objAllowancesInfo = (HRAllowancesInfo)objAllowancesController.GetObjectFromDataRow(row);
                            objFormAllowancesInfo = (HRFormAllowancesInfo)objFormAllowancesController.GetObjectByID(objAllowancesInfo.FK_HRFormAllowanceID);

                            objEmployeeAllowancesInfo = (HREmployeeAllowancesInfo)objEmployeeAllowancesController.GetEmployeeAllowancesInfoByEmployeeIDAndAllowanceID(employee.HREmployeeID, objAllowancesInfo.HRAllowanceID);
                            if (objFormAllowancesInfo != null && objFormAllowancesInfo.HRFormAllowanceType == HRFormAllowanceType.CaNhan.ToString())
                            {
                                if (objAllowancesInfo.HRAllowanceOption.Equals("AddToSalary"))
                                {
                                    decimal amount = objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount;
                                    if (objAllowancesInfo.HRAllowanceByWorkDay)
                                    {
                                        amount = objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount * conglamviec;
                                    }

                                    if (objFormAllowancesInfo.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapthamnien.ToString())
                                    {
                                        employeePayRoll.HREmployeePayRollPerennialAllowance += amount;
                                    }
                                    else if (objFormAllowancesInfo.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaplanhnghe.ToString())
                                    {
                                        employeePayRoll.HREmployeePayRollEffectiveAllowance += amount;
                                    }
                                    else if (objFormAllowancesInfo.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaptrachnhiem.ToString())
                                    {
                                        employeePayRoll.HREmployeePayRollResponsibilityAllowance += amount;
                                    }
                                    else if (objFormAllowancesInfo.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucaptrachnhiemhanghoa.ToString())
                                    {
                                        employeePayRoll.HREmployeePayRollResponsibilityCommodityAllowance += amount;
                                    }
                                    else if (objFormAllowancesInfo.HRFormAllowanceNameType == HRFormAllowanceNameType.Khac.ToString())
                                    {
                                        employeePayRoll.HREmployeePayRollOtherAllowance += amount;
                                    }
                                    else if (objFormAllowancesInfo.HRFormAllowanceNameType == HRFormAllowanceNameType.Phucapcadem.ToString())
                                    {
                                        decimal totalNightWorkingShift = 0;
                                        if (employeePayRoll.HREmployeePayrollDetailsList != null)
                                        {
                                            employeePayRoll.HREmployeePayrollDetailsList.ForEach(y =>
                                            {
                                                if (y.IsNight)
                                                {
                                                    totalNightWorkingShift++;
                                                }
                                            });
                                        }
                                        if (objAllowancesInfo.HRAllowanceByWorkDay)
                                        {
                                            employeePayRoll.HREmployeePayRollAllowaceNight += objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount * totalNightWorkingShift;
                                        }
                                        else
                                        {
                                            employeePayRoll.HREmployeePayRollAllowaceNight += objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount;
                                        }
                                    }
                                    else if (objFormAllowancesInfo.HRFormAllowanceNameType == HRFormAllowanceNameType.Tienantangca.ToString())
                                    {
                                        employeePayRoll.HREmployeePayRollOtherReward += amount;
                                        employeePayRoll.HREmployeePayRollTongCongKhac += amount;
                                    }
                                }
                            }
                        }
                        //employeePayRoll.HREmployeePayRollOthersAllowance += employeePayRoll.HREmployeePayRollOthersAllowance;
                    }
                }
                // Bảo hiểm xã hội, bảo hiểm y tế, bảo hiểm thu nhập
                if (obj.HREmployeePayrollFormulaSalaryType.Equals("BHXHBHYTBHTN"))
                {
                    decimal contractSalary = 0;
                    employeePayRoll.HREmployeePayRollSyndicateFee = 0;
                    if (employee.HREmployeeHasSocialInsurance)
                    {
                        contractSalary = employee.HREmployeeContractSlrAmt;
                        //if (employee.HREmployeeIsUnionMember)
                        employeePayRoll.HREmployeePayRollSyndicateFee = employee.HREmployeeSyndicatePaymentAmount;
                    }

                    employeePayRoll.HREmployeePayRollSocialInsAmount = employee.HREmployeeSocialInsPaymentPercent * contractSalary / 100;
                    employeePayRoll.HREmployeePayRollHealthInsAmount = employee.HREmployeeHealthInsPaymentPercent * contractSalary / 100;
                    employeePayRoll.HREmployeePayRollOutOfWorkInsAmount = employee.HREmployeeOutOfWorkInsPaymentPercent * contractSalary / 100;
                    employeePayRoll.HREmployeePayRollIncomeTaxAmount = employee.HREmployeeTaxPaymentPercent * contractSalary / 100;

                    employeePayRoll.HREmployeePayRollSocialInsDNAmount = employee.HREmployeeSocialInsPaymentPercentDN * contractSalary / 100;
                    employeePayRoll.HREmployeePayRollHealthInsDNAmount = employee.HREmployeeHealthInsPaymentPercentDN * contractSalary / 100;
                    employeePayRoll.HREmployeePayRollOutOfWorkInsDNAmount = employee.HREmployeeOutOfWorkInsPaymentPercentDN * contractSalary / 100;
                }
            }
            decimal luongcoban = employee.HREmployeeWorkingSlrAmtDate;
            employeePayRoll.HREmployeeBasicSalary = luongcoban;
            employeePayRoll.HREmployeePayRollUnitPrice = employeePayRoll.HREmployeeBasicSalary +
                                                        employeePayRoll.HREmployeePayRollPerennialAllowance +
                                                        employeePayRoll.HREmployeePayRollEffectiveAllowance +
                                                        employeePayRoll.HREmployeePayRollResponsibilityCommodityAllowance +
                                                        employeePayRoll.HREmployeePayRollOtherAllowance +
                                                        employeePayRoll.HREmployeePayRollResponsibilityAllowance;

            CalculatePayRollTotalAmounts(employeePayRoll);
        }

        public void SetDefaultValuesFromEmployeeTransfer(HREmployeePayRollsInfo objEmployeePayRollsInfo, HREmployeeTranfersInfo objEmployeeTranfersInfo)
        {
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HRPayRollsInfo objPayRollsInfo = (HRPayRollsInfo)entity.MainObject;
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(objEmployeeTranfersInfo.FK_HREmployeeID);
            objEmployeesInfo.FK_HRDepartmentRoomID = objEmployeeTranfersInfo.FK_HRDepartmentRoomID;
            objEmployeesInfo.FK_HRLevelID = objEmployeeTranfersInfo.FK_HRLevelID;
            objEmployeesInfo.HREmployeeSalaryFactor = objEmployeeTranfersInfo.HREmployeeTranferSalaryFactor;
            objEmployeesInfo.HREmployeeContractSlrAmt = objEmployeeTranfersInfo.HREmployeeTranferSalary;
            objEmployeesInfo.HREmployeeWorkingSlrAmt = objEmployeeTranfersInfo.HREmployeeTranferExtraSalary;
            objEmployeesInfo.HREmployeeExtraSalary1 = objEmployeeTranfersInfo.HREmployeeTranferAllowances;

            objEmployeePayRollsInfo.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
            objEmployeePayRollsInfo.FK_HRLevelID = objEmployeesInfo.FK_HRLevelID;
            objEmployeePayRollsInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
            objEmployeePayRollsInfo.HREmployeeName = objEmployeesInfo.HREmployeeName;
            HREmployeesInfo objEmployeesInfo2 = new HREmployeesInfo();
            objEmployeesInfo2 = UpdateWorkingForm(objEmployeesInfo);
            objEmployeePayRollsInfo.HREmployeeStatusCombo = objEmployeesInfo2.HREmployeeStatusCombo;
            objEmployeePayRollsInfo.HREmployeeWorkingForm = objEmployeesInfo2.HREmployeeWorkingForm;
            // Ngày công qui định
            objEmployeePayRollsInfo.HREmployeeDaysPerMonth = objEmployeesInfo.HREmployeeDaysPerMonth;
            // Hệ số
            objEmployeePayRollsInfo.HREmployeeSalaryFactor = objEmployeesInfo.HREmployeeSalaryFactor;
            // Lương cơ bản
            objEmployeePayRollsInfo.HREmployeeContractSlrAmt = objEmployeesInfo.HREmployeeContractSlrAmt;
            // Lương công việc
            objEmployeePayRollsInfo.HREmployeeWorkingSlrAmt = objEmployeesInfo.HREmployeeWorkingSlrAmt;
            entity.EmployeePayRollsList.GridControl.RefreshDataSource();
        }

        public override void ActionNew()
        {
            base.ActionNew();
            PayRollEntities entity = (PayRollEntities)CurrentModuleEntity;
            HRPayRollsInfo objPayRollsInfo = (HRPayRollsInfo)entity.MainObject;
            HRTimeSheetsController objTimeSheetsController = new HRTimeSheetsController();
            List<HRTimeSheetsInfo> timeSheetList = objTimeSheetsController.GetTimeSheetsForPayRoll();
            guiChooseTimeSheets guiFind = new guiChooseTimeSheets(timeSheetList);
            guiFind.Module = this;
            DialogResult rs = guiFind.ShowDialog();
            if (rs != DialogResult.OK)
            {
                ActionCancel();
                return;
            }
            List<HRTimeSheetsInfo> result = guiFind.SelectedObjects as List<HRTimeSheetsInfo>;
            HRTimeSheetsInfo objRefTimeSheetsInfo = result.FirstOrDefault();
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)objTimeSheetsController.GetObjectByID(objRefTimeSheetsInfo.HRTimeSheetID);
            //Set default main object
            objPayRollsInfo.HRPayRollType = objTimeSheetsInfo.HRTimeSheetType;
            objPayRollsInfo.HRPayRollDate = objTimeSheetsInfo.HRTimeSheetDate;
            objPayRollsInfo.FromDate = objTimeSheetsInfo.HRTimeSheetFromDate;
            objPayRollsInfo.ToDate = objTimeSheetsInfo.HRTimeSheetToDate;
            objPayRollsInfo.FK_HRTimeSheetID = objTimeSheetsInfo.HRTimeSheetID;
            if (objTimeSheetsInfo != null)
            {
                //Add employee time sheet info to employee payroll list
                // CTChinh - PayRoll BEGIN
                HREmployeeTimeSheetsController objEmployeeTimeSheetsController = new HREmployeeTimeSheetsController();
                HRTimeSheetEntrysController objTimeSheetEntrysController = new HRTimeSheetEntrysController();
                HREmployeeTranfersController objEmployeeTranfersController = new HREmployeeTranfersController();
                HREmployeesController objEmployeesController = new HREmployeesController();


                List<HREmployeeTimeSheetsInfo> employeeTimeSheets = objEmployeeTimeSheetsController.GetEmployeeTimeSheetByTimeSheetIDAndUserGroup(objTimeSheetsInfo.HRTimeSheetID, VinaApp.CurrentUserInfo.FK_ADUserGroupID);
                //TNDLoc [ADD][19/04/2016][Employee permission],END
                HREmployeePayRollsInfo employeePayRoll;
                HREmployeePayRollsInfo employeePayRoll2 = new HREmployeePayRollsInfo();
                HREmployeesInfo objEmployeesInfo;
                List<HRTimeSheetEntrysInfo> employeeTimeSheetEntryList = new List<HRTimeSheetEntrysInfo>();
                List<HRTimeSheetEntrysInfo> employeeTimeSheetEntryList1 = new List<HRTimeSheetEntrysInfo>();
                List<HRTimeSheetEntrysInfo> employeeTimeSheetEntryList2 = new List<HRTimeSheetEntrysInfo>();
                HRTimesheetConfigsController objTimesheetConfigsController = new HRTimesheetConfigsController();

                HREmployeeTimeSheetOTDetailsController objEmployeeTimeSheetOTDetailsController = new HREmployeeTimeSheetOTDetailsController();
                ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
                ADWorkingShiftGroupsController objWorkingShiftGroupsController = new ADWorkingShiftGroupsController();
                ADOTFactorsController objOTFactorsController = new ADOTFactorsController();
                HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();

                List<ADWorkingShiftsInfo> listWorkingShifts = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());
                List<ADWorkingShiftGroupsInfo> list = (List<ADWorkingShiftGroupsInfo>)objWorkingShiftGroupsController.GetListFromDataSet(objWorkingShiftGroupsController.GetAllObjects());
                List<HRTimeSheetParamsInfo> listTimeSheetParams = objTimeSheetParamsController.GetTimeSheetParamsList(TimeSheetParamType.Day.ToString());

                foreach (HREmployeeTimeSheetsInfo employeeTimeSheet in employeeTimeSheets)
                {
                    employeePayRoll = new HREmployeePayRollsInfo();
                    employeePayRoll.FK_HREmployeeID = employeeTimeSheet.FK_HREmployeeID;
                    objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetEmployeeByID(employeeTimeSheet.FK_HREmployeeID);
                    List<HREmployeeTranfersInfo> listEmployeeTranfers = (List<HREmployeeTranfersInfo>)objEmployeeTranfersController.GetEmployeeTranfersByEmployeeIDAndDateTo(objEmployeesInfo.HREmployeeID, objPayRollsInfo.ToDate);
                    if (objEmployeesInfo.FK_HREmployeePayrollFormulaID > 0)
                    {
                        objEmployeesInfo.HREmployeeDaysPerMonth = objTimesheetConfigsController.GetDaysPerMonthByEmployeeFormullaID(objEmployeesInfo.FK_HREmployeePayrollFormulaID, objPayRollsInfo.HRPayRollDate.Month, objPayRollsInfo.HRPayRollDate.Year);
                        if (objEmployeesInfo.HREmployeeDaysPerMonth == 0)
                        {
                            objEmployeesInfo.HREmployeeDaysPerMonth = CalculationWorkDay(objPayRollsInfo.HRPayRollDate);
                        }
                        SetDefaultValuesFromEmployee(employeePayRoll, objEmployeesInfo);
                        employeePayRoll.HRDepartmentRoomName = objEmployeesInfo.HRDepartmentRoomName;
                        employeePayRoll.HRDepartmentName = objEmployeesInfo.HRDepartmentName;
                        employeePayRoll.HRLevelName = objEmployeesInfo.HRLevelName;
                        employeePayRoll.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                        employeePayRoll.FK_HRDepartmentID = objEmployeesInfo.FK_HRDepartmentID;

                        //if (listEmployeeTranfers != null && listEmployeeTranfers.Count > 0)
                        //{
                        //    decimal luongcoban = 0;
                        //    HREmployeeTranfersInfo objEmployeeTranfersInfo = (HREmployeeTranfersInfo)listEmployeeTranfers.Where(o => o.HREmployeeTranferDateFrom.Date < objPayRollsInfo.FromDate.Date).FirstOrDefault();
                        //    List<HREmployeeTranfersInfo> listEmployeeTranfer2 = listEmployeeTranfers.Where(o => o.HREmployeeTranferDateFrom.Date >= objPayRollsInfo.FromDate.Date && o.HREmployeeTranferDateFrom.Date <= objPayRollsInfo.ToDate.Date).ToList();
                        //    employeeTimeSheetEntryList = objTimeSheetEntrysController.GetTotalTimeSheetEntryByTimeSheetIDAndEmployeeTimeSheetID(objTimeSheetsInfo.HRTimeSheetID, employeeTimeSheet.HREmployeeTimeSheetID);

                        //    if (objEmployeeTranfersInfo == null)
                        //    {
                        //        luongcoban = objEmployeesInfo.HREmployeeWorkingSlrAmtDate;
                        //    }
                        //    else
                        //    {
                        //        luongcoban = objEmployeeTranfersInfo.HREmployeeTranferExtraSalaryDate;
                        //    }

                        //    if (listEmployeeTranfer2 != null && listEmployeeTranfer2.Count > 0)
                        //    {
                        //        //luongcoban = (decimal)((listEmployeeTranfer2[0].HREmployeeTranferDateFrom.Date - objPayRollsInfo.FromDate.Date).TotalDays) * luongcoban;
                        //        decimal ngaycong = 0;
                        //        if (employeeTimeSheetEntryList != null)
                        //        {
                        //            ngaycong = CheckWorkingDay(employeeTimeSheetEntryList, objPayRollsInfo.FromDate.Date,
                        //                listEmployeeTranfer2[0].HREmployeeTranferDateFrom.Date, objEmployeesInfo, false);

                        //            if (ngaycong > 0)
                        //            {
                        //                luongcoban = luongcoban * ngaycong;
                        //            }
                        //            else
                        //            {
                        //                luongcoban = 0;
                        //            }
                        //            if (listEmployeeTranfer2.Count >= 2)
                        //            {
                        //                for (int i = 0; i < listEmployeeTranfer2.Count - 1; i++)
                        //                {
                        //                    ngaycong = CheckWorkingDay(employeeTimeSheetEntryList, listEmployeeTranfer2[i].HREmployeeTranferDateFrom.Date,
                        //                    listEmployeeTranfer2[i + 1].HREmployeeTranferDateFrom.Date, objEmployeesInfo, false);

                        //                    if (ngaycong > 0)
                        //                    {
                        //                        luongcoban += ngaycong * listEmployeeTranfer2[i].HREmployeeTranferExtraSalaryDate;
                        //                    }
                        //                    //luongcoban += (decimal)((listEmployeeTranfer2[i + 1].HREmployeeTranferDateFrom.Date - listEmployeeTranfer2[i].HREmployeeTranferDateFrom.Date).TotalDays) * listEmployeeTranfer2[i].HREmployeeTranferExtraSalaryDate;
                        //                }
                        //            }

                        //            ngaycong = CheckWorkingDay(employeeTimeSheetEntryList, listEmployeeTranfer2[listEmployeeTranfer2.Count - 1].HREmployeeTranferDateFrom.Date,
                        //                objPayRollsInfo.ToDate.Date, objEmployeesInfo, true);

                        //            if (ngaycong > 0)
                        //            {
                        //                luongcoban += ngaycong * listEmployeeTranfer2[listEmployeeTranfer2.Count - 1].HREmployeeTranferExtraSalaryDate;
                        //            }
                        //        }
                        //    }

                        //    UpdateEmployeePayrollDetailsList(employeePayRoll, employeeTimeSheetEntryList, listEmployeeTranfers, objEmployeesInfo, true, employeeTimeSheet, listWorkingShifts, list, listTimeSheetParams);

                        //    if (employeePayRoll.HREmployeeRealDaysPerMonth > 0)
                        //    {
                        //        if (listEmployeeTranfer2 != null && listEmployeeTranfer2.Count > 0)
                        //        {
                        //            employeePayRoll.HREmployeeBasicSalary = luongcoban / employeePayRoll.HREmployeeRealDaysPerMonth;
                        //        }
                        //        else
                        //        {
                        //            employeePayRoll.HREmployeeBasicSalary = luongcoban;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        employeePayRoll.HREmployeeBasicSalary = luongcoban;
                        //    }

                        //    CalculatePayRoll(employeePayRoll, objEmployeesInfo);
                        //}
                        //else
                        //{
                        employeeTimeSheetEntryList = objTimeSheetEntrysController.GetTotalTimeSheetEntryByTimeSheetIDAndEmployeeTimeSheetID(objTimeSheetsInfo.HRTimeSheetID, employeeTimeSheet.HREmployeeTimeSheetID);
                        UpdateEmployeePayrollDetailsList(employeePayRoll, employeeTimeSheetEntryList, null, objEmployeesInfo, false, employeeTimeSheet, listWorkingShifts, list, listTimeSheetParams);
                        employeePayRoll.HREmployeeBasicSalary = objEmployeesInfo.HREmployeeWorkingSlrAmtDate;
                        CalculatePayRoll(employeePayRoll, objEmployeesInfo);
                        //}
                    }
                    else
                    {
                        employeePayRoll.HRDepartmentRoomName = objEmployeesInfo.HRDepartmentRoomName;
                        employeePayRoll.HRDepartmentName = objEmployeesInfo.HRDepartmentName;
                        employeePayRoll.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                        employeePayRoll.FK_HRDepartmentID = objEmployeesInfo.FK_HRDepartmentID;
                        employeePayRoll.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
                        employeePayRoll.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
                        employeePayRoll.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
                        employeePayRoll.HREmployeeName = objEmployeesInfo.HREmployeeName;
                        HREmployeesInfo objEmployeesInfo3 = new HREmployeesInfo();
                        objEmployeesInfo3 = UpdateWorkingForm(objEmployeesInfo);
                        employeePayRoll.HREmployeeStatusCombo = objEmployeesInfo3.HREmployeeStatusCombo;
                        employeePayRoll.HREmployeeWorkingForm = objEmployeesInfo3.HREmployeeWorkingForm;

                        // Ngày công qui định
                        employeePayRoll.HREmployeeDaysPerMonth = 0;
                        // Hệ số
                        employeePayRoll.HREmployeeSalaryFactor = 0;
                        // Lương cơ bản
                        employeePayRoll.HREmployeeContractSlrAmt = 0;
                        // Lương công việc
                        employeePayRoll.HREmployeePayRollWorkingSalary = 0;
                    }
                    entity.EmployeePayRollsList.Add(employeePayRoll);
                }
                // CTChinh - PayRoll END
            }
            entity.EmployeePayRollsList.GridControl.RefreshDataSource();
        }
        public decimal CheckWorkingDay(List<HRTimeSheetEntrysInfo> list, DateTime dateFrom, DateTime dateTo, HREmployeesInfo objEmployeesInfo, bool isEndMonth)
        {
            List<HRTimeSheetEntrysInfo> list2 = new List<HRTimeSheetEntrysInfo>();
            if (isEndMonth)
            {
                list2 = list.Where(o => o.FK_HREmployeeID == objEmployeesInfo.HREmployeeID
                                            && o.HRTimeSheetEntryDate.Date <= dateTo
                                            && o.HRTimeSheetEntryDate >= dateFrom).ToList();
            }
            else
            {
                list2 = list.Where(o => o.FK_HREmployeeID == objEmployeesInfo.HREmployeeID
                                                            && o.HRTimeSheetEntryDate.Date < dateTo
                                                            && o.HRTimeSheetEntryDate >= dateFrom).ToList();
            }
            decimal ngaycong = 0;
            if (list2 != null && list2.Count > 0)
            {
                list2.ForEach(o =>
                {
                    if (o.IsOT == false && o.FK_ADWorkingShiftID > 0)
                    {
                        ngaycong += o.HRTimeSheetEntryWorkingQty;
                    }
                });
            }
            return ngaycong;
        }
        public void UpdateEmployeePayrollDetailsList(HREmployeePayRollsInfo employeePayRoll,
                                                    List<HRTimeSheetEntrysInfo> employeeTimeSheetEntryList,
                                                    List<HREmployeeTranfersInfo> listEmployeeTranfers,
                                                    HREmployeesInfo objEmployeesInfo,
                                                    bool check,
                                                    HREmployeeTimeSheetsInfo employeeTimeSheet,
                                                    List<ADWorkingShiftsInfo> listWorkingShifts,
                                                    List<ADWorkingShiftGroupsInfo> list,
                                                    List<HRTimeSheetParamsInfo> listTimeSheetParams)
        {
            //check: true => Nhân viên có lịch sử thuyển chuyển.
            //check: false => Nhân viên không có lịch sử thuyên chuyển.

            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            ADWorkingShiftGroupsController objWorkingShiftGroupsController = new ADWorkingShiftGroupsController();
            ADOTFactorsController objOTFactorsController = new ADOTFactorsController();

            List<HREmployeePayrollDetailsInfo> employeePayrollDetails = new List<HREmployeePayrollDetailsInfo>();
            ADWorkingShiftsInfo objDWorkingShiftsInfo = new ADWorkingShiftsInfo();

            HRWorkingShiftsController objHRWorkingShiftsController = new HRWorkingShiftsController();
            List<HRWorkingShiftsInfo> listHRWorkingShifts = new List<HRWorkingShiftsInfo>();
            HRWorkingShiftsInfo objHRWorkingShiftsInfo = new HRWorkingShiftsInfo();
            HREmployeePayrollFormulasController objEmployeePayrollFormulasController = new HREmployeePayrollFormulasController();
            HREmployeePayrollFormulasInfo objEmployeePayrollFormulasInfo = new HREmployeePayrollFormulasInfo();
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            HRTimeSheetParamsInfo objTimeSheetParamsInfo = new HRTimeSheetParamsInfo();
            //decimal workingAdd = 0;
            //if (objEmployeesInfo != null)
            //{
            //    listHRWorkingShifts = objHRWorkingShiftsController.GetWorkingShiftByPayrollFormulaID(objEmployeesInfo.FK_HREmployeePayrollFormulaID);
            //    if (objEmployeesInfo.FK_HREmployeePayrollFormulaID > 0)
            //    {
            //        objEmployeePayrollFormulasInfo = (HREmployeePayrollFormulasInfo)objEmployeePayrollFormulasController.GetObjectByID(objEmployeesInfo.FK_HREmployeePayrollFormulaID);
            //        if (objEmployeePayrollFormulasInfo != null)
            //        {
            //            workingAdd = objEmployeePayrollFormulasInfo.HREmployeePayrollFormulaWorkingDiff;
            //        }
            //    }
            //}
            //if (workingAdd > 0 && employeeTimeSheetEntryList != null)
            //{
            //    decimal totalTongCong = 0;
            //    totalTongCong = employeeTimeSheetEntryList.Where(o => !o.IsOT && o.FK_ADWorkingShiftID > 0
            //                                                     && (o.HRTimeSheetParamType == TimeSheetParamType.Day.ToString()
            //                                                     || o.HRTimeSheetParamType == TimeSheetParamType.Hour.ToString())).Sum(o => o.HRTimeSheetParamValue1);
            //    if (totalTongCong >= 1)
            //    {
            //        decimal dem = workingAdd;
            //        decimal workingAddRedundancy = workingAdd - Math.Floor(dem);
            //        HRTimeSheetEntrysInfo objTimeSheetEntrysInfo = (HRTimeSheetEntrysInfo)employeeTimeSheetEntryList.LastOrDefault(o => !o.IsOT && o.FK_ADWorkingShiftID > 0
            //                                                                                                                        && (o.HRTimeSheetParamType == TimeSheetParamType.Day.ToString()
            //                                                                                                                        || o.HRTimeSheetParamType == TimeSheetParamType.Hour.ToString()));
            //        List<HRTimeSheetParamsInfo> listParams = (List<HRTimeSheetParamsInfo>)listTimeSheetParams.Where(o => o.FK_ADWorkingShiftID == objTimeSheetEntrysInfo.FK_ADWorkingShiftID
            //                                                                                                        && (o.HRTimeSheetParamType == TimeSheetParamType.Day.ToString()
            //                                                                                                        || o.HRTimeSheetParamType == TimeSheetParamType.Hour.ToString())).ToList();
            //        if (listParams != null && listParams.Count > 0 && objTimeSheetEntrysInfo != null)
            //        {
            //            while (dem > 0)
            //            {
            //                HRTimeSheetEntrysInfo objTimeSheetEntrysInfo2 = (HRTimeSheetEntrysInfo)objTimeSheetEntrysInfo.Clone();
            //                objTimeSheetParamsInfo = GetTimeSheetParam(listParams, dem, objTimeSheetEntrysInfo.FK_ADWorkingShiftID);
            //                if (objTimeSheetParamsInfo != null && objTimeSheetEntrysInfo2 != null && objTimeSheetParamsInfo.HRTimeSheetParamID > 0)
            //                {
            //                    objTimeSheetEntrysInfo2.FK_ADWorkingShiftID = objTimeSheetParamsInfo.FK_ADWorkingShiftID;
            //                    objTimeSheetEntrysInfo2.FK_HRTimeSheetParamID = objTimeSheetParamsInfo.HRTimeSheetParamID;
            //                    objTimeSheetEntrysInfo2.HRTimeSheetEntryWorkingQty = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
            //                    objTimeSheetEntrysInfo2.HRTimeSheetEntryWorkingHours = objTimeSheetParamsInfo.HRTimeSheetParamValue1 * 8;

            //                    employeeTimeSheetEntryList.Add(objTimeSheetEntrysInfo2);
            //                    dem -= objTimeSheetParamsInfo.HRTimeSheetParamValue1;
            //                }
            //                else
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            decimal congChuan = 0;
            decimal congVuot = 0;
            foreach (var item2 in list)
            {
                congChuan = 0;
                congVuot = 0;
                if (item2.ADWorkingShiftGroupID > 0)
                {
                    foreach (var item in employeeTimeSheetEntryList)
                    {
                        if (item.FK_ADWorkingShiftID > 0
                            && (item.HRTimeSheetParamType == TimeSheetParamType.Day.ToString() || item.HRTimeSheetParamType == TimeSheetParamType.Hour.ToString()))
                        {
                            if (listWorkingShifts != null)
                            {
                                objDWorkingShiftsInfo = (ADWorkingShiftsInfo)listWorkingShifts.FirstOrDefault(o => o.ADWorkingShiftID == item.FK_ADWorkingShiftID);
                            }
                            if (objDWorkingShiftsInfo != null)
                            {
                                if (objDWorkingShiftsInfo.FK_ADWorkingShiftGroupID == item2.ADWorkingShiftGroupID)
                                {
                                    if (listHRWorkingShifts != null)
                                    {
                                        objHRWorkingShiftsInfo = (HRWorkingShiftsInfo)listHRWorkingShifts.FirstOrDefault(o => o.FK_ADWorkingShiftID == objDWorkingShiftsInfo.ADWorkingShiftID);
                                    }
                                    congChuan += item.HRTimeSheetEntryWorkingQty;
                                    HREmployeePayrollDetailsInfo objEmployeePayrollDetailsInfo = new HREmployeePayrollDetailsInfo();
                                    objEmployeePayrollDetailsInfo.HREmployeeTimeSheetOTDetailFactor = item2.ADWorkingShiftGroupID;
                                    objEmployeePayrollDetailsInfo.HREmployeeTimeSheetOTDetailName = item2.ADWorkingShiftGroupID.ToString();
                                    objEmployeePayrollDetailsInfo.HREmployeePayrollHours = item.HRTimeSheetEntryWorkingQty;
                                    objEmployeePayrollDetailsInfo.HREmployeePayrollDetailPrecentAmount = item2.ADWorkingShiftGroupPrecentLess;
                                    objEmployeePayrollDetailsInfo.HREmployeePayrollDetailAllowanceWorkingShift = 0;
                                    if (objHRWorkingShiftsInfo != null)
                                    {
                                        objEmployeePayrollDetailsInfo.HREmployeePayrollDetailAllowanceWorkingShift = objHRWorkingShiftsInfo.HRWorkingShiftAllowance;
                                    }
                                    if (check)
                                    {
                                        objEmployeePayrollDetailsInfo.HREmployeePayrollBasicSalary = CheckSalaryBasic(listEmployeeTranfers, item.HRTimeSheetEntryDate, objEmployeesInfo);
                                    }
                                    else
                                    {
                                        objEmployeePayrollDetailsInfo.HREmployeePayrollBasicSalary = objEmployeesInfo.HREmployeeWorkingSlrAmtDate;
                                    }
                                    if (congChuan > employeePayRoll.HREmployeeDaysPerMonth)
                                    {
                                        congVuot = congChuan - employeePayRoll.HREmployeeDaysPerMonth;
                                        if (congVuot > 0 && congVuot < 1)
                                        {
                                            objEmployeePayrollDetailsInfo.HREmployeePayrollHours = item.HRTimeSheetEntryWorkingQty - congVuot;
                                        }
                                        else
                                        {
                                            objEmployeePayrollDetailsInfo.HREmployeePayrollDetailPrecentExceed = item2.ADWorkingShiftGroupPrecentExceed - item2.ADWorkingShiftGroupPrecentLess;
                                        }

                                    }

                                    if (objDWorkingShiftsInfo.FK_HRTimeSheetParamFactorID == item.FK_HRTimeSheetParamID && objDWorkingShiftsInfo.ADWorkingShiftNight)
                                    {
                                        objEmployeePayrollDetailsInfo.IsNight = true;
                                    }
                                    else
                                    {
                                        objEmployeePayrollDetailsInfo.IsNight = false;
                                    }

                                    if (congVuot > 0 && congVuot < 1 && congChuan > employeePayRoll.HREmployeeDaysPerMonth)
                                    {
                                        HREmployeePayrollDetailsInfo objEmployeePayrollDetailsInfo2 = (HREmployeePayrollDetailsInfo)objEmployeePayrollDetailsInfo.Clone();
                                        objEmployeePayrollDetailsInfo2.HREmployeePayrollHours = congVuot;
                                        objEmployeePayrollDetailsInfo2.HREmployeePayrollDetailPrecentExceed = item2.ADWorkingShiftGroupPrecentExceed - item2.ADWorkingShiftGroupPrecentLess;
                                        employeePayrollDetails.Add(objEmployeePayrollDetailsInfo2);
                                    }
                                    employeePayrollDetails.Add(objEmployeePayrollDetailsInfo);
                                }
                            }
                        }
                    }
                }
            }

            List<ADOTFactorsInfo> OTFactorlist = (List<ADOTFactorsInfo>)objOTFactorsController.GetListFromDataSet(objOTFactorsController.GetAllObjects());
            List<string> param2 = new List<string>();
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            decimal hoursPerDay = Convert.ToDecimal(objConfigValuesController.GetObjectByConfigKey("HoursPerDay").ADConfigKeyValue);

            decimal totalSalaryFactor = 0;
            decimal totalApprenticeSalaryFactor = 0;
            decimal totalProbationarySalaryFactor = 0;
            decimal totalSalaryOTHours = 0;
            decimal totalApprenticeSalaryOTHours = 0;
            decimal totalProbationarySalaryOTHours = 0;
            decimal nghihuongluong = 0;
            decimal nghihuongluongTV = 0;
            decimal nghihuongluongHV = 0;
            decimal nghikhongluong = 0;
            decimal nghiPN = 0;
            decimal nghiLe = 0;
            decimal totalLate = 0;
            decimal nghiKP = 0;
            decimal truNghiKPTheoCa = 0;
            employeePayRoll.HREmployeePayRollDaysOffAmount = 0;
            employeePayRoll.HREmployeePayrollNghiLeAmount = 0;

            decimal totalAmountAllowance = employeePayRoll.HREmployeePayRollPerennialAllowance +
                                            employeePayRoll.HREmployeePayRollEffectiveAllowance +
                                            employeePayRoll.HREmployeePayRollResponsibilityCommodityAllowance +
                                            employeePayRoll.HREmployeePayRollOtherAllowance +
                                            employeePayRoll.HREmployeePayRollResponsibilityAllowance;

            ADOTFactorsInfo objOTFactorsInfo = new ADOTFactorsInfo();
            List<ADOTFactorsInfo> listOTFactors = new List<ADOTFactorsInfo>();

            foreach (var item in employeeTimeSheetEntryList)
            {
                if (item.IsOT)
                {
                    totalSalaryOTHours += item.HRTimeSheetEntryWorkingHours;
                    if (OTFactorlist != null && OTFactorlist.Count > 0)
                    {
                        listOTFactors = OTFactorlist.Where(o => o.ADOTFactorValue == item.HRTimeSheetParamValue2).ToList();
                        if (listOTFactors != null)
                        {
                            objOTFactorsInfo = GetOTFactors(listOTFactors, item);
                            if (objOTFactorsInfo != null)
                            {
                                HREmployeePayrollDetailsInfo objEmployeePayrollDetailsInfo = new HREmployeePayrollDetailsInfo();
                                objEmployeePayrollDetailsInfo.HREmployeeTimeSheetOTDetailFactor = objOTFactorsInfo.ADOTFactorValue;
                                objEmployeePayrollDetailsInfo.HREmployeeTimeSheetOTDetailName = objOTFactorsInfo.ADOTFactorID.ToString();
                                objEmployeePayrollDetailsInfo.IsOT = true;
                                objEmployeePayrollDetailsInfo.HREmployeePayrollHours = item.HRTimeSheetParamValue1 / hoursPerDay;
                                objEmployeePayrollDetailsInfo.HREmployeePayrollHourFactor = item.HRTimeSheetParamValue1;
                                if (check)
                                {
                                    objEmployeePayrollDetailsInfo.HREmployeePayrollBasicSalary = CheckSalaryBasic(listEmployeeTranfers, item.HRTimeSheetEntryDate, objEmployeesInfo);
                                }
                                else
                                {
                                    objEmployeePayrollDetailsInfo.HREmployeePayrollBasicSalary = objEmployeesInfo.HREmployeeWorkingSlrAmtDate;
                                }
                                employeePayrollDetails.Add(objEmployeePayrollDetailsInfo);
                            }
                        }
                    }
                }
                else if (item.FK_ADWorkingShiftID > 0 && (item.HRTimeSheetParamType == TimeSheetParamType.Day.ToString() || item.HRTimeSheetParamType == TimeSheetParamType.Hour.ToString()))
                {
                    totalSalaryFactor += item.HRTimeSheetEntryWorkingQty;
                }

                if (item.HRTimeSheetParamType.Equals("Common"))
                {
                    if (item.HRTimeSheetParamValue1 * item.HRTimeSheetParamValue2 > 0)
                    {
                        nghihuongluong += item.HRTimeSheetParamValue1 * item.HRTimeSheetParamValue2 / 8;
                    }
                    else if (item.HRTimeSheetParamValue1 * item.HRTimeSheetParamValue2 < 0)
                    {
                        nghiKP += Math.Abs(item.HRTimeSheetParamValue1 * item.HRTimeSheetParamValue2 / 8);
                        decimal workingShiftAllowance = 0;
                        if (listHRWorkingShifts != null)
                        {
                            objHRWorkingShiftsInfo = (HRWorkingShiftsInfo)listHRWorkingShifts.LastOrDefault(o => o.FK_ADWorkingShiftID == item.FK_ADWorkingShiftForParamID);
                            if (objHRWorkingShiftsInfo != null)
                            {
                                truNghiKPTheoCa += objHRWorkingShiftsInfo.HRWorkingShiftAllowance;
                                workingShiftAllowance = objHRWorkingShiftsInfo.HRWorkingShiftAllowance;
                            }
                        }
                        if (check)
                        {
                            employeePayRoll.HREmployeePayRollDaysOffAmount += Math.Abs(item.HRTimeSheetParamValue1 * item.HRTimeSheetParamValue2 / 8)
                                                                            * CheckSalaryBasic(listEmployeeTranfers, item.HRTimeSheetEntryDate, objEmployeesInfo)
                                                                            + totalAmountAllowance
                                                                            + workingShiftAllowance;
                        }
                    }
                    else
                    {
                        nghikhongluong++;
                    }
                }
                //if (item.HRTimeSheetParamNo.Equals("NPN"))
                //{
                //    nghiPN++;
                //}
                if (item.HRTimeSheetParamType.Equals(TimeSheetParamType.LE.ToString()))
                {
                    nghiLe += item.HRTimeSheetParamValue1 * item.HRTimeSheetParamValue2 / (hoursPerDay > 0 ? hoursPerDay : 8);
                    if (check)
                    {
                        employeePayRoll.HREmployeePayrollNghiLeAmount += item.HRTimeSheetParamValue1 * item.HRTimeSheetParamValue2 / (hoursPerDay > 0 ? hoursPerDay : 8)
                                                                        * (CheckSalaryBasic(listEmployeeTranfers, item.HRTimeSheetEntryDate, objEmployeesInfo) +
                                                                            totalAmountAllowance);
                    }
                }
            }

            employeePayRoll.HREmployeePayrollDetailsList = employeePayrollDetails;

            if (employeePayRoll.HREmployeePayrollDetailsList != null)
            {
                employeePayRoll.HREmployeePayRollCommission = 0;
                employeePayRoll.HREmployeePayrollDetailsList.ForEach(o =>
                {
                    try
                    {
                        if (o.IsOT)
                        {
                            o.HREmployeePayrollBasicSalary += totalAmountAllowance;
                            o.HREmployeePayrollBasicSalary = o.HREmployeePayrollBasicSalary * o.HREmployeeTimeSheetOTDetailFactor;
                            o.HREmployeePayrollSalaryFactor = o.HREmployeePayrollBasicSalary * o.HREmployeePayrollHours;
                        }
                        else
                        {
                            o.HREmployeePayrollBasicSalary += totalAmountAllowance;
                            //o.HREmployeePayrollSalaryFactor = o.HREmployeePayrollBasicSalary * o.HREmployeePayrollHours;
                            o.HREmployeePayrollSalaryFactor = (o.HREmployeePayrollBasicSalary + o.HREmployeePayrollDetailAllowanceWorkingShift) * o.HREmployeePayrollDetailPrecentAmount / 100 * o.HREmployeePayrollHours;
                            employeePayRoll.HREmployeePayRollCommission += (o.HREmployeePayrollBasicSalary + o.HREmployeePayrollDetailAllowanceWorkingShift) * o.HREmployeePayrollDetailPrecentExceed / 100 * o.HREmployeePayrollHours;
                            //o.HREmployeePayrollSalaryFactor = o.HREmployeePayrollBasicSalary * o.HREmployeePayrollDetailPrecentAmount / 100 * o.HREmployeePayrollHours;
                            //employeePayRoll.HREmployeePayRollCommission += o.HREmployeePayrollBasicSalary * o.HREmployeePayrollDetailPrecentExceed / 100 * o.HREmployeePayrollHours;
                        }
                    }
                    catch (Exception)
                    {
                        o.HREmployeePayrollSalaryFactor = 0;
                    }
                });
            }

            employeePayRoll.HREmployeePayrollNghiKPhep = nghiKP;
            employeePayRoll.HREmployeePayRollNgayNghiHuongLuong = nghihuongluong + nghihuongluongHV + nghihuongluongTV;
            employeePayRoll.HREmployeePayRollNgayNghiKhongLuong = nghikhongluong;
            employeePayRoll.HREmployeePayrollNghiPhepNam = nghiPN;
            employeePayRoll.HREmployeePayrollNghiLe = nghiLe;
            // Công thực tế
            employeePayRoll.HREmployeeRealDaysPerMonth = totalSalaryFactor;
            employeePayRoll.HREmployeePayRollProbationaryRealDaysPerMonth = totalProbationarySalaryFactor - nghihuongluongTV;
            employeePayRoll.HREmployeePayRollApprenticeRealDaysPerMonth = totalApprenticeSalaryFactor - nghihuongluongHV;
            employeePayRoll.HREmployeePayRollSubtractLateAmount = totalLate * 30000;
            if (!check)
            {
                employeePayRoll.HREmployeePayRollDaysOffAmount = nghiKP * (objEmployeesInfo.HREmployeeWorkingSlrAmtDate + totalAmountAllowance) + truNghiKPTheoCa;
                employeePayRoll.HREmployeePayrollNghiLeAmount = employeePayRoll.HREmployeePayrollNghiLe *
                                                            (objEmployeesInfo.HREmployeeWorkingSlrAmtDate +
                                                            totalAmountAllowance);
            }
            // Giờ tăng ca
            employeePayRoll.HREmployeeHoursOT = totalSalaryOTHours + totalApprenticeSalaryOTHours + totalProbationarySalaryOTHours;
            //Ngày tăng ca
            employeePayRoll.HREmployeePayRollDayOT = employeePayRoll.HREmployeeHoursOT > 0 ? (decimal)employeePayRoll.HREmployeeHoursOT / 8 : 0;

            employeePayRoll.HREmployeePayRollTongNgayCong = totalSalaryFactor;

            // Lương công việc
            employeePayRoll.HREmployeePayRollWorkingSalary = objEmployeesInfo.HREmployeeWorkingSlrAmt;
            // Lương khoán

            employeePayRoll.HREmployeePieceworkSalary = 0;
            // Bù lương
            employeePayRoll.HREmployeeOffsetSalary = 0;
            employeePayRoll.HRTimeSheetEntrysList = employeeTimeSheetEntryList;
        }

        public decimal CheckSalaryBasic(List<HREmployeeTranfersInfo> listEmployeeTranfers, DateTime date, HREmployeesInfo objEmployeesInfo)
        {
            if (listEmployeeTranfers != null)
            {
                HREmployeeTranfersInfo objEmployeeTranfersInfo = (HREmployeeTranfersInfo)listEmployeeTranfers.Where(o => o.HREmployeeTranferDateFrom.Date <= date.Date).LastOrDefault();
                if (objEmployeeTranfersInfo != null)
                {
                    return objEmployeeTranfersInfo.HREmployeeTranferExtraSalaryDate;
                }
                else
                {
                    return objEmployeesInfo.HREmployeeWorkingSlrAmtDate;
                }
            }
            else
            {
                return 0;
            }
        }

        public ADOTFactorsInfo GetOTFactors(List<ADOTFactorsInfo> list, HRTimeSheetEntrysInfo entry)
        {
            List<ADOTFactorsInfo> workingDayFactors = list.Where(f => f.ADOTFactorType == OTFactorType.WorkingDay.ToString()).ToList();
            List<ADOTFactorsInfo> holidayFactors = list.Where(f => f.ADOTFactorType == OTFactorType.Holiday.ToString()).ToList();
            List<ADOTFactorsInfo> endOfWeekFactors = list.Where(f => f.ADOTFactorType == OTFactorType.EndOfWeek.ToString()).ToList();

            if (VinaApp.IsHoliday(entry.HRTimeSheetEntryDate))
            {
                if (holidayFactors.Count > 0)
                {
                    return holidayFactors.FirstOrDefault();
                }
            }

            if (VinaApp.IsEndOfWeek(entry.HRTimeSheetEntryDate.DayOfWeek))
            {
                if (endOfWeekFactors.Count > 0)
                {
                    return endOfWeekFactors.FirstOrDefault();
                }
            }

            if (workingDayFactors.Count > 0)
            {
                return workingDayFactors.FirstOrDefault();
            }
            else return null;
        }

        private HRTimeSheetParamsInfo GetTimeSheetParam(List<HRTimeSheetParamsInfo> timeSheetParamsList, decimal val, int workingID)
        {
            HRTimeSheetParamsInfo obj = timeSheetParamsList.Where(p => (p.HRTimeSheetParamValue1 <= val && p.FK_ADWorkingShiftID == workingID))
                .OrderByDescending(p => p.HRTimeSheetParamValue1).FirstOrDefault();
            if (obj == null) obj = new HRTimeSheetParamsInfo();
            return obj;
        }
    }
}
