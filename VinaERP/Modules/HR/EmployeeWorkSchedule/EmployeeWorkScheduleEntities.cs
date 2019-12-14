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

namespace VinaERP.Modules.EmployeeWorkSchedule
{
    public class EmployeeWorkScheduleEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeeWorkScheduleItemsInfo> EmployeeWorkScheduleItemsList { get; set; }
        public List<HREmployeesInfo> EmployeesList { get; set; }
        #endregion

        #region Constructor
        public EmployeeWorkScheduleEntities()
            : base()
        {
            EmployeeWorkScheduleItemsList = new VinaList<HREmployeeWorkScheduleItemsInfo>();
            EmployeesList = new List<HREmployeesInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HREmployeeWorkSchedulesInfo();
            SearchObject = new HREmployeeWorkSchedulesInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeeWorkScheduleItemsList.InitVinaList(this,
                                             TableName.HREmployeeWorkSchedulesTableName,
                                             TableName.HREmployeeWorkScheduleItemsTableName,
                                             VinaList<HREmployeeWorkScheduleItemsInfo>.cstRelationForeign);
            EmployeeWorkScheduleItemsList.ItemTableForeignKey = "FK_HREmployeeWorkScheduleID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeeWorkScheduleItemsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HREmployeeWorkSchedulesInfo objEmployeeWorkSchedulesInfo = (HREmployeeWorkSchedulesInfo)MainObject;
            objEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleStatus = EmployeeWorkScheduleStatus.New.ToString();
            DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            objEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleFromDate = d;
            objEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleToDate = d;
            objEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleDateFrom = d;
            objEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleDateTo = d;
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeeWorkScheduleItemsList.SetDefaultListAndRefreshGridControl();
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
            HREmployeeWorkScheduleItemsController objEmployeeWorkSchedulesController = new HREmployeeWorkScheduleItemsController();
            DataSet ds = objEmployeeWorkSchedulesController.GetAllDataByOverTimeID(iObjectID);
            EmployeeWorkScheduleItemsList.Invalidate(ds);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            EmployeeWorkScheduleItemsList.SaveItemObjects();
        }
        #endregion

        public void SetDefaultValuesFromEmployee(HREmployeeWorkScheduleItemsInfo objEmployeeWorkScheduleItemsInfo, HREmployeesInfo objEmployeesInfo)
        {
            HREmployeeWorkSchedulesInfo objEmployeeWorkSchedulesInfo = (HREmployeeWorkSchedulesInfo)MainObject;
            objEmployeeWorkScheduleItemsInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
            objEmployeeWorkScheduleItemsInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
            objEmployeeWorkScheduleItemsInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
        }

        public void CompleteTransaction()
        {
            HREmployeeWorkSchedulesInfo objEmployeeWorkSchedulesInfo = (HREmployeeWorkSchedulesInfo)MainObject;
            HREmployeeWorkSchedulesController objEmployeeWorkSchedulesController = new HREmployeeWorkSchedulesController();
            HREmployeeWorkSchedulesInfo objReferrenceEmployeeWorkSchedulesInfo = (HREmployeeWorkSchedulesInfo)objEmployeeWorkSchedulesController.GetObjectByID(objEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleID);
            if(objReferrenceEmployeeWorkSchedulesInfo != null)
            {
                objReferrenceEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleStatus = EmployeeWorkScheduleStatus.Approved.ToString();
                objEmployeeWorkSchedulesController.UpdateObject(objReferrenceEmployeeWorkSchedulesInfo);

                objEmployeeWorkSchedulesInfo.HREmployeeWorkScheduleStatus = EmployeeWorkScheduleStatus.Approved.ToString();
                UpdateMainObjectBindingSource();
            }
        }
    }
}
