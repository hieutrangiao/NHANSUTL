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

namespace VinaERP.Modules.Discipline
{
    public class DisciplineEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeeDisciplinesInfo> EmployeeDisciplinesList { get; set; }
        public List<HREmployeesInfo> EmployeesList { get; set; }
        #endregion

        #region Constructor
        public DisciplineEntities()
            : base()
        {
            EmployeeDisciplinesList = new VinaList<HREmployeeDisciplinesInfo>();
            EmployeesList = new List<HREmployeesInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRDisciplinesInfo();
            SearchObject = new HRDisciplinesInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeeDisciplinesList.InitVinaList(this,
                                             TableName.HRDisciplinesTableName,
                                             TableName.HREmployeeDisciplinesTableName,
                                             VinaList<HREmployeeDisciplinesInfo>.cstRelationForeign);
            EmployeeDisciplinesList.ItemTableForeignKey = "FK_HRDisciplineID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeeDisciplinesList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRDisciplinesInfo objDisciplinesInfo = (HRDisciplinesInfo)MainObject;
            objDisciplinesInfo.FK_HREmployeeRequest = VinaApp.CurrentUserInfo.FK_HREmployeeID;
            objDisciplinesInfo.HRDisciplineStatus = DisciplineStatus.New.ToString();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeeDisciplinesList.SetDefaultListAndRefreshGridControl();
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
            HREmployeeDisciplinesController objEmployeeDisciplinesController = new HREmployeeDisciplinesController();
            DataSet ds = objEmployeeDisciplinesController.GetEmployeeDisciplineListByDisciplineID(iObjectID);
            EmployeeDisciplinesList.Invalidate(ds);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            EmployeeDisciplinesList.SaveItemObjects();
        }
        #endregion

        public void SetDefaultValuesFromEmployee(HREmployeeDisciplinesInfo objEmployeeDisciplinesInfo, HREmployeesInfo objEmployeesInfo)
        {
            HRDisciplinesInfo objDisciplinesInfo = (HRDisciplinesInfo)MainObject;
            objEmployeeDisciplinesInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
            objEmployeeDisciplinesInfo.HREmployeeDisciplineValue = objDisciplinesInfo.HRDisciplineValue;
            objEmployeeDisciplinesInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
            objEmployeeDisciplinesInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            objEmployeeDisciplinesInfo.HREmployeeDisciplineDate = objDisciplinesInfo.HRDisciplineFromDate;
        }

        public void CompleteTransaction()
        {
            HRDisciplinesInfo objDisciplinesInfo = (HRDisciplinesInfo)MainObject;
            HRDisciplinesController objDisciplinesController = new HRDisciplinesController();
            HRDisciplinesInfo objReferrenceDisciplinesInfo = (HRDisciplinesInfo)objDisciplinesController.GetObjectByID(objDisciplinesInfo.HRDisciplineID);
            if(objReferrenceDisciplinesInfo != null)
            {
                objReferrenceDisciplinesInfo.HRDisciplineStatus = DisciplineStatus.Approved.ToString();
                objDisciplinesController.UpdateObject(objReferrenceDisciplinesInfo);

                objDisciplinesInfo.HRDisciplineStatus = DisciplineStatus.Approved.ToString();
                UpdateMainObjectBindingSource();
            }
        }
    }
}
