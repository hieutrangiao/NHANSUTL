using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCommon;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.Allowance
{
    public class AllowanceEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeeAllowancesInfo> EmployeeAllowancesList { get; set; }
        public List<HREmployeesInfo> EmployeesList { get; set; }
        #endregion

        #region Constructor
        public AllowanceEntities()
            : base()
        {
            EmployeeAllowancesList = new VinaList<HREmployeeAllowancesInfo>();
            EmployeesList = new List<HREmployeesInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRAllowancesInfo();
            SearchObject = new HRAllowancesInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeeAllowancesList.InitVinaList(this,
                                             TableName.HRAllowancesTableName,
                                             TableName.HREmployeeAllowancesTableName,
                                             VinaList<HREmployeeAllowancesInfo>.cstRelationForeign);
            EmployeeAllowancesList.ItemTableForeignKey = "FK_HRAllowanceID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeeAllowancesList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRAllowancesInfo objAllowancesInfo = (HRAllowancesInfo)MainObject;
            objAllowancesInfo.FK_HREmployeeRequest = VinaApp.CurrentUserInfo.FK_HREmployeeID;
            //objAllowancesInfo.HRAllowanceStatus = AllowanceStatus.New.ToString();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeeAllowancesList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            EmployeeAllowancesList.Invalidate(iObjectID);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            EmployeeAllowancesList.SaveItemObjects();
        }
        #endregion

        public void SetDefaultValuesFromEmployee(HREmployeeAllowancesInfo objEmployeeAllowancesInfo, HREmployeesInfo objEmployeesInfo)
        {
            HRAllowancesInfo objAllowancesInfo = (HRAllowancesInfo)MainObject;
            objEmployeeAllowancesInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
            objEmployeeAllowancesInfo.FK_HRAllowanceID = objAllowancesInfo.HRAllowanceID;
            objEmployeeAllowancesInfo.HREmployeeAllowanceValue = objAllowancesInfo.HRAllowanceValue;
            objEmployeeAllowancesInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
            objEmployeeAllowancesInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = objAllowancesInfo.HRAllowanceConfigValue;
            objEmployeeAllowancesInfo.HREmployeeAllowanceDate = DateTime.Now;

            // Set default config
            int timeSpan = GetTimeSpan(objEmployeesInfo.HREmployeeStartWorkingDate);
            HRAllowanceConfigsController objAllowanceConfigsController = new HRAllowanceConfigsController();
            List<HRAllowanceConfigsInfo> listAllowanceConfigsInfo = objAllowanceConfigsController.GetAllowanceConfigByFKEmployeePayrollFormula(objEmployeesInfo.FK_HREmployeePayrollFormulaID);
            if (listAllowanceConfigsInfo != null)
            {
                HREmployeeTimeSheetsController objEmployeeTimeSheetsController = new HREmployeeTimeSheetsController();
                HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo = objEmployeeTimeSheetsController.GetEmployeeTimeSheetBySomeCriteria(objEmployeesInfo.HREmployeeID, objAllowancesInfo.HRAllowanceFromDate);
                HRTimesheetConfigsController objTimesheetConfigsController = new HRTimesheetConfigsController();
                int dateQty = objTimesheetConfigsController.GetDaysPerMonthByEmployeeFormullaID(objEmployeesInfo.FK_HREmployeePayrollFormulaID, objAllowancesInfo.HRAllowanceFromDate.Month, objAllowancesInfo.HRAllowanceFromDate.Year);

                foreach (HRAllowanceConfigsInfo item in listAllowanceConfigsInfo)
                {
                    if (item.HRAllowanceConfigName == AllowanceConfigName.Diligence.ToString() && objAllowancesInfo.HRAllowanceType == AllowanceType.Diligence.ToString())
                    {
                        objEmployeeAllowancesInfo.HREmployeeAllowanceAmount = item.HRAllowanceConfigAmount;
                        if (objEmployeeTimeSheetsInfo != null && objEmployeeTimeSheetsInfo.HREmployeeTimeSheetWorkingQty + objEmployeeTimeSheetsInfo.HREmployeeTimeSheetLeaveQty >= dateQty)
                        {
                            if (!item.HRAllowanceConfigIsTimeKeeping)
                                objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = item.HRAllowanceConfigAmount;
                            else
                                objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = item.HRAllowanceConfigAmount * objEmployeeTimeSheetsInfo.HREmployeeTimeSheetWorkingQty;
                        }
                    }
                    if (item.HRAllowanceConfigName == AllowanceConfigName.HeavyToxic.ToString() && objAllowancesInfo.HRAllowanceType == AllowanceType.HeavyToxic.ToString())
                    {
                        objEmployeeAllowancesInfo.HREmployeeAllowanceAmount = item.HRAllowanceConfigAmount;
                        if (item.HRAllowanceConfigIsTimeKeeping)
                        {
                            if (objEmployeeTimeSheetsInfo != null)
                                objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetWorkingQty * item.HRAllowanceConfigAmount;
                        }
                        else
                            objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = item.HRAllowanceConfigAmount;
                    }
                    if (item.HRAllowanceConfigName == AllowanceConfigName.Perennial.ToString() && objAllowancesInfo.HRAllowanceType == AllowanceType.Perennial.ToString())
                    {
                        if (timeSpan >= item.HRAllowanceConfigFromDate && timeSpan < item.HRAllowanceConfigToDate)
                        {
                            objEmployeeAllowancesInfo.HREmployeeAllowanceAmount = item.HRAllowanceConfigAmount;
                            if (item.HRAllowanceConfigIsTimeKeeping)
                            {
                                if (objEmployeeTimeSheetsInfo != null)
                                    objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetWorkingQty * item.HRAllowanceConfigAmount;
                            }
                            else
                            {
                                objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = item.HRAllowanceConfigAmount;
                            }
                        }
                    }
                    //TNDLoc [ADD][22/12/2015][Other allowance],START
                    if (item.HRAllowanceConfigName == AllowanceConfigName.Other.ToString() && objAllowancesInfo.HRAllowanceType == AllowanceType.Other.ToString())
                    {
                        objEmployeeAllowancesInfo.HREmployeeAllowanceAmount = item.HRAllowanceConfigAmount;
                        if (item.HRAllowanceConfigIsTimeKeeping)
                        {
                            if (objEmployeeTimeSheetsInfo != null)
                                objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetWorkingQty * item.HRAllowanceConfigAmount;
                        }
                        else
                            objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = item.HRAllowanceConfigAmount;
                    }
                    //TNDLoc [ADD][22/12/2015][Other allowance],END
                }
            }

            float result;
            // Set Amount Bus
            if (objAllowancesInfo.HRAllowanceType == AllowanceType.Bus.ToString())
            {
                if (!objAllowancesInfo.HRAllowanceValue.Equals(String.Empty) && Single.TryParse(objAllowancesInfo.HRAllowanceValue, out result))
                {
                    objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = Convert.ToDecimal(Convert.ToSingle(objAllowancesInfo.HRAllowanceValue));
                }
                else
                {
                    objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = 0;
                }
            }

            if (objAllowancesInfo.HRAllowanceType.Contains("Amount"))
            {
                if (!objAllowancesInfo.HRAllowanceValue.Equals(String.Empty) && Single.TryParse(objAllowancesInfo.HRAllowanceValue, out result))
                {
                    objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = Convert.ToDecimal(Convert.ToSingle(objAllowancesInfo.HRAllowanceValue));
                }
                else
                {
                    objEmployeeAllowancesInfo.HREmployeeAllowanceValueAmount = 0;
                }
            }
        }

        public int GetTimeSpan(DateTime startDate)
        {
            DateTime currentDate = DateTime.Now;
            int result = currentDate.Year - startDate.Year;
            if (result <= 0)
                return 0;
            if (currentDate.Month < startDate.Month)
                result--;
            if (currentDate.Month == startDate.Month)
                if (currentDate.Day < startDate.Day)
                    result--;
            return result;
        }

        public void CompleteTransaction()
        {
            //HRAllowancesInfo objAllowancesInfo = (HRAllowancesInfo)MainObject;
            //HRAllowancesController objAllowancesController = new HRAllowancesController();
            //HRAllowancesInfo objReferrenceAllowancesInfo = (HRAllowancesInfo)objAllowancesController.GetObjectByID(objAllowancesInfo.HRAllowanceID);
            //if(objReferrenceAllowancesInfo != null)
            //{
            //    objReferrenceAllowancesInfo.HRAllowanceStatus = AllowanceStatus.Approved.ToString();
            //    objAllowancesController.UpdateObject(objReferrenceAllowancesInfo);

            //    objAllowancesInfo.HRAllowanceStatus = AllowanceStatus.Approved.ToString();
            //    UpdateMainObjectBindingSource();
            //}
        }
    }
}
