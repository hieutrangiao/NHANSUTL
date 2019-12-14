using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.Employee
{
    public class EmployeeEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties

        #endregion

        #region Constructor
        public EmployeeEntities()
        {

        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HREmployeesInfo();
            SearchObject = new HREmployeesInfo();
        }

        public override void InitModuleObjects()
        {

        }

        public override void InitGridControlInVinaList()
        {

        }

        public override void SetDefaultModuleObjectsList()
        {

        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {

        }

        public override void SaveModuleObjects()
        {

        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
        }

    }
}
