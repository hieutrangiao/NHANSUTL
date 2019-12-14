using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Common;
using VinaERP.Modules.Employee;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Employee
{
    public class EmployeeModule : BaseModuleERP
    {

        public EmployeeModule()
        {
            this.CurrentModuleName = "Employee";
            CurrentModuleEntity = new EmployeeEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();

        }

        public override int ActionSave()
        {
            return base.ActionSave();
        }

        public override void ActionNew()
        {
            base.ActionNew();
        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
        }

        public void UpdateWorkingSlrAmtDateTotal()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            EmployeeEntities entity = (EmployeeEntities)CurrentModuleEntity;
            HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)entity.MainObject;
            objEmployeesInfo.HREmployeeWorkingSlrAmtDateTotal = objEmployeesInfo.HREmployeeAllowanceProgress +
                                                                objEmployeesInfo.HREmployeeAllowanceResponsibility +
                                                                objEmployeesInfo.HREmployeeAllowanceEffective +
                                                                objEmployeesInfo.HREmployeeAllowancePerennial +
                                                                objEmployeesInfo.HREmployeeAllowanceOther +
                                                                objEmployeesInfo.HREmployeeWorkingSlrAmtDate;
            entity.UpdateMainObjectBindingSource();
        }

        public void UpdateInsPaymentAmt()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            EmployeeEntities entity = (EmployeeEntities)CurrentModuleEntity;
            HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)entity.MainObject;

            objEmployeesInfo.HREmployeeSocialInsPaymentAmount = objEmployeesInfo.HREmployeeSocialInsPaymentPercent * objEmployeesInfo.HREmployeeContractSlrAmt / 100;
            objEmployeesInfo.HREmployeeHealthInsPaymentAmount = objEmployeesInfo.HREmployeeHealthInsPaymentPercent * objEmployeesInfo.HREmployeeContractSlrAmt / 100;
            objEmployeesInfo.HREmployeeOutOfWorkInsPaymentAmount = objEmployeesInfo.HREmployeeOutOfWorkInsPaymentPercent * objEmployeesInfo.HREmployeeContractSlrAmt / 100;
            objEmployeesInfo.HREmployeeSocialInsPaymentAmountDN = objEmployeesInfo.HREmployeeSocialInsPaymentPercentDN * objEmployeesInfo.HREmployeeContractSlrAmt / 100;
            objEmployeesInfo.HREmployeeHealthInsPaymentAmountDN = objEmployeesInfo.HREmployeeHealthInsPaymentPercentDN * objEmployeesInfo.HREmployeeContractSlrAmt / 100;
            objEmployeesInfo.HREmployeeOutOfWorkInsPaymentAmountDN = objEmployeesInfo.HREmployeeOutOfWorkInsPaymentPercentDN * objEmployeesInfo.HREmployeeContractSlrAmt / 100;
            objEmployeesInfo.HREmployeeInsPaymentTotalAmount = objEmployeesInfo.HREmployeeSocialInsPaymentAmount
                                                                + objEmployeesInfo.HREmployeeHealthInsPaymentAmount
                                                                + objEmployeesInfo.HREmployeeOutOfWorkInsPaymentAmount;
            objEmployeesInfo.HREmployeeInsPaymentTotalAmountDN = objEmployeesInfo.HREmployeeSocialInsPaymentAmountDN
                                                                + objEmployeesInfo.HREmployeeHealthInsPaymentAmountDN
                                                                + objEmployeesInfo.HREmployeeOutOfWorkInsPaymentAmountDN;
            objEmployeesInfo.HREmployeeSyndicatePaymentAmount = objEmployeesInfo.HREmployeeSyndicatePaymentPercent * objEmployeesInfo.HREmployeeContractSlrAmt / 100;
            entity.UpdateMainObjectBindingSource();
        }

        public void UpdateWorkingSlrAmt()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            EmployeeEntities entity = (EmployeeEntities)CurrentModuleEntity;
            HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)entity.MainObject;

            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            ADConfigValuesInfo objConfigValuesInfo = new ADConfigValuesInfo();
            objConfigValuesInfo = objConfigValuesController.GetObjectByConfigKey("DaysPerMonth");
            decimal dateWorking = 0;
            if (objConfigValuesInfo != null)
            {
                Decimal.TryParse(objConfigValuesInfo.ADConfigKeyValue, out dateWorking);
                objEmployeesInfo.HREmployeeWorkingSlrAmt = objEmployeesInfo.HREmployeeWorkingSlrAmtDate * dateWorking;
            }
            entity.UpdateMainObjectBindingSource();
        }
    }
}
