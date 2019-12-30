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

namespace VinaERP.Modules.PayRoll
{
    public class PayRollEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeePayRollsInfo> EmployeePayRollsList { get; set; }
        #endregion

        #region Constructor
        public PayRollEntities()
            : base()
        {
            EmployeePayRollsList = new VinaList<HREmployeePayRollsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRPayRollsInfo();
            SearchObject = new HRPayRollsInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeePayRollsList.InitVinaList(this,
                                             TableName.HRPayRollsTableName,
                                             TableName.HREmployeePayRollsTableName,
                                             VinaList<HREmployeePayRollsInfo>.cstRelationForeign);
            EmployeePayRollsList.ItemTableForeignKey = "FK_HRPayRollID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeePayRollsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRPayRollsInfo objPayRollsInfo = (HRPayRollsInfo)MainObject;
            objPayRollsInfo.HRPayRollStatus = PayRollStatus.New.ToString();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeePayRollsList.SetDefaultListAndRefreshGridControl();
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
            HREmployeePayRollsController objEmployeePayRollsController = new HREmployeePayRollsController();
            HREmployeesController objEmployeesController = new HREmployeesController();
            //TNDLoc [ADD][19/04/2016][Employee Permission],START
            // Origin: List<HREmployeePayRollsInfo> employeePayRollList = objEmployeePayRollsController.GetEmployeePayRollListByPayRollID(iObjectID);
            List<HREmployeePayRollsInfo> employeePayRollList = objEmployeePayRollsController.GetEmployeePayRollByPayRollIDAndUserGroup(iObjectID, VinaApp.CurrentUserInfo.FK_ADUserGroupID);
            //TNDLoc [ADD][19/04/2016][Employee Permission],END
            EmployeePayRollsList.Invalidate(employeePayRollList);
            HREmployeePayrollDetailsController objEmployeePayrollDetailsController = new HREmployeePayrollDetailsController();
            foreach (HREmployeePayRollsInfo obj in EmployeePayRollsList)
            {
                obj.HREmployeePayrollDetailsList = objEmployeePayrollDetailsController.GetListEmployeePayrollDetailByEmployeePayroll(
                                                                               obj.HREmployeePayRollID);
            }
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            EmployeePayRollsList.SaveItemObjects();
            HREmployeePayrollDetailsController objEmployeePayrollDetailsController = new HREmployeePayrollDetailsController();
            foreach (HREmployeePayRollsInfo objEmployeePayRollsInfo in EmployeePayRollsList)
            {
                objEmployeePayrollDetailsController.DeleteByForeignColumn("FK_HREmployeePayRollID", objEmployeePayRollsInfo.HREmployeePayRollID);
                if (objEmployeePayRollsInfo.HREmployeePayrollDetailsList != null)
                {
                    foreach (HREmployeePayrollDetailsInfo obj in objEmployeePayRollsInfo.HREmployeePayrollDetailsList)
                    {
                        obj.FK_HREmployeePayrollID = objEmployeePayRollsInfo.HREmployeePayRollID;
                        objEmployeePayrollDetailsController.CreateObject(obj);
                    }
                }
            }
        }
        #endregion

        public void SetDefaultValuesFromEmployee(HREmployeePayRollsInfo objEmployeePayRollsInfo, HREmployeesInfo objEmployeesInfo)
        {
        }

        public void CompleteTransaction()
        {
            HRPayRollsInfo objPayRollsInfo = (HRPayRollsInfo)MainObject;
            HRPayRollsController objPayRollsController = new HRPayRollsController();
            HRPayRollsInfo objReferrencePayRollsInfo = (HRPayRollsInfo)objPayRollsController.GetObjectByID(objPayRollsInfo.HRPayRollID);
            if(objReferrencePayRollsInfo != null)
            {
                objReferrencePayRollsInfo.HRPayRollStatus = PayRollStatus.Complete.ToString();
                objPayRollsController.UpdateObject(objReferrencePayRollsInfo);

                objPayRollsInfo.HRPayRollStatus = PayRollStatus.Complete.ToString();
                UpdateMainObjectBindingSource();
            }
        }
    }
}
