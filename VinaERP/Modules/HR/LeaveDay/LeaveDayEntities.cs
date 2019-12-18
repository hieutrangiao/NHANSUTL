using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.LeaveDay
{
    public class LeaveDayEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HRLeaveDaysInfo> LeaveDaysList { get; set; }

        #endregion

        #region Constructor
        public LeaveDayEntities()
            : base()
        {
            LeaveDaysList = new VinaList<HRLeaveDaysInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
        }

        public override void InitModuleObjectList()
        {
            LeaveDaysList.InitVinaList(this,
                                             string.Empty,
                                             TableName.HRLeaveDaysTableName,
                                             VinaList<HRLeaveDaysInfo>.cstRelationNone);
        }

        public override void InitGridControlInVinaList()
        {
            LeaveDaysList.InitVinaListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                LeaveDaysList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion
    }
}
