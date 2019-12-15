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

namespace VinaERP.Modules.OverTime
{
    public class OverTimeEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeeOTsInfo> EmployeeOTsList { get; set; }
        public List<HREmployeesInfo> EmployeesList { get; set; }
        #endregion

        #region Constructor
        public OverTimeEntities()
            : base()
        {
            EmployeeOTsList = new VinaList<HREmployeeOTsInfo>();
            EmployeesList = new List<HREmployeesInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HROverTimesInfo();
            SearchObject = new HROverTimesInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeeOTsList.InitVinaList(this,
                                             TableName.HROverTimesTableName,
                                             TableName.HREmployeeOTsTableName,
                                             VinaList<HREmployeeOTsInfo>.cstRelationForeign);
            EmployeeOTsList.ItemTableForeignKey = "FK_HROverTimeID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeeOTsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)MainObject;
            objOverTimesInfo.HROverTimeDate = DateTime.Now.Date;
            objOverTimesInfo.HROverTimeFromDate = DateTime.Now.Date;
            objOverTimesInfo.HROverTimeToDate = DateTime.Now.Date;
            objOverTimesInfo.HROverTimeDateEnd = DateTime.Now.Date;
            objOverTimesInfo.HROverTimeStatus = OverTimeStatus.New.ToString();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeeOTsList.SetDefaultListAndRefreshGridControl();
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
            HREmployeeOTsController objEmployeeOTsController = new HREmployeeOTsController();
            DataSet ds = objEmployeeOTsController.GetAllDataByOverTimeID(iObjectID);
            EmployeeOTsList.Invalidate(ds);
            HREmployeesController objEmployeesController = new HREmployeesController();
            foreach (var item in EmployeeOTsList)
            {
                HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(item.FK_HREmployeeID);
                if (objEmployeesInfo != null)
                    item.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            }
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            EmployeeOTsList.SaveItemObjects();
        }
        #endregion

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
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)MainObject;
            HROverTimesController objOverTimesController = new HROverTimesController();
            HROverTimesInfo objReferrenceOverTimesInfo = (HROverTimesInfo)objOverTimesController.GetObjectByID(objOverTimesInfo.HROverTimeID);
            if (objReferrenceOverTimesInfo != null)
            {
                objReferrenceOverTimesInfo.HROverTimeStatus = OverTimeStatus.Approved.ToString();
                objOverTimesController.UpdateObject(objReferrenceOverTimesInfo);

                objOverTimesInfo.HROverTimeStatus = OverTimeStatus.Approved.ToString();
                UpdateMainObjectBindingSource();
            }
        }

        public void SetDefaultValuesFromEmployee(HREmployeeOTsInfo objEmployeeOTsInfo, HREmployeesInfo objEmployeesInfo)
        {
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)MainObject;
            objEmployeeOTsInfo.HREmployeeOTDate = objOverTimesInfo.HROverTimeDate;
            objEmployeeOTsInfo.HREmployeeOTDateEnd = objOverTimesInfo.HROverTimeDateEnd;
            DateTime employeeOTDate = objEmployeeOTsInfo.HREmployeeOTDate;
            DateTime employeeOTDateEnd = objEmployeeOTsInfo.HREmployeeOTDateEnd;
            objEmployeeOTsInfo.HREmployeeOTFromDate = new DateTime(employeeOTDate.Year, employeeOTDate.Month, employeeOTDate.Day, objOverTimesInfo.HROverTimeFromDate.Hour, objOverTimesInfo.HROverTimeFromDate.Minute, 0);
            objEmployeeOTsInfo.HREmployeeOTToDate = new DateTime(employeeOTDateEnd.Year, employeeOTDateEnd.Month, employeeOTDateEnd.Day, objOverTimesInfo.HROverTimeToDate.Hour, objOverTimesInfo.HROverTimeToDate.Minute, 0);
            objEmployeeOTsInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
            objEmployeeOTsInfo.HREmployeeName = objEmployeesInfo.HREmployeeName;
            objEmployeeOTsInfo.FK_HRDepartmentID = objEmployeesInfo.FK_HRDepartmentID;
            objEmployeeOTsInfo.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
            objEmployeeOTsInfo.FK_HRDepartmentRoomGroupItemID = objEmployeesInfo.FK_HRDepartmentRoomGroupItemID;
            objEmployeeOTsInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            objEmployeeOTsInfo.FK_HRTimeSheetParamID = objOverTimesInfo.FK_HRTimeSheetParamID;
            objEmployeeOTsInfo.FK_ADWorkingShiftID = objOverTimesInfo.FK_ADWorkingShiftID;
            objEmployeeOTsInfo.HREmployeeOTFactor = objOverTimesInfo.HROverTimeFactor;
        }
    }
}
