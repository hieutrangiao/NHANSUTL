using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP.Modules.Department
{
    public class DepartmentEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties


        #endregion

        #region Constructor
        public DepartmentEntities()
        {

        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ICDepartmentsInfo();
            SearchObject = new ICDepartmentsInfo();
        }

        public override void InitModuleObjects()
        {
            
        }

        public override void InitModuleObjectList()
        {
            
        }

        //public override void InitGridControlInBOSList()
        //{
            
        //}

        //public override void SetDefaultModuleObjectsList()
        //{
        //    try
        //    {
        //        CanceledDeliveryPlanItemsList.SetDefaultListAndRefreshGridControl();
        //    }
        //    catch (Exception)
        //    {
        //        return;
        //    }
        //}

        #endregion

    }
}
