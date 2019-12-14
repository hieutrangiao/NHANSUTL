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

namespace VinaERP.Modules.Reward
{
    public class RewardEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeeRewardsInfo> EmployeeRewardsList { get; set; }
        public List<HREmployeesInfo> EmployeesList { get; set; }
        #endregion

        #region Constructor
        public RewardEntities()
            : base()
        {
            EmployeeRewardsList = new VinaList<HREmployeeRewardsInfo>();
            EmployeesList = new List<HREmployeesInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRRewardsInfo();
            SearchObject = new HRRewardsInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeeRewardsList.InitVinaList(this,
                                             TableName.HRRewardsTableName,
                                             TableName.HREmployeeRewardsTableName,
                                             VinaList<HREmployeeRewardsInfo>.cstRelationForeign);
            EmployeeRewardsList.ItemTableForeignKey = "FK_HRRewardID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeeRewardsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRRewardsInfo objRewardsInfo = (HRRewardsInfo)MainObject;
            objRewardsInfo.FK_HREmployeeRequest = VinaApp.CurrentUserInfo.FK_HREmployeeID;
            objRewardsInfo.HRRewardStatus = RewardStatus.New.ToString();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeeRewardsList.SetDefaultListAndRefreshGridControl();
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
            HREmployeeRewardsController objEmployeeRewardsController = new HREmployeeRewardsController();
            DataSet ds = objEmployeeRewardsController.GetRewardListByRewardID(iObjectID);
            EmployeeRewardsList.Invalidate(ds);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            EmployeeRewardsList.SaveItemObjects();
        }
        #endregion

        public void SetDefaultValuesFromEmployee(HREmployeeRewardsInfo objEmployeeRewardsInfo, HREmployeesInfo objEmployeesInfo)
        {
            HRRewardsInfo objRewardsInfo = (HRRewardsInfo)MainObject;
            objEmployeeRewardsInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
            objEmployeeRewardsInfo.HREmployeeRewardValue = objRewardsInfo.HRRewardValue;
            objEmployeeRewardsInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
            objEmployeeRewardsInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            objEmployeeRewardsInfo.HREmployeeRewardDate = objRewardsInfo.HRRewardFromDate;
        }

        public void CompleteTransaction()
        {
            HRRewardsInfo objRewardsInfo = (HRRewardsInfo)MainObject;
            HRRewardsController objRewardsController = new HRRewardsController();
            HRRewardsInfo objReferrenceRewardsInfo = (HRRewardsInfo)objRewardsController.GetObjectByID(objRewardsInfo.HRRewardID);
            if(objReferrenceRewardsInfo != null)
            {
                objReferrenceRewardsInfo.HRRewardStatus = RewardStatus.Approved.ToString();
                objRewardsController.UpdateObject(objReferrenceRewardsInfo);

                objRewardsInfo.HRRewardStatus = RewardStatus.Approved.ToString();
                UpdateMainObjectBindingSource();
            }
        }
    }
}
