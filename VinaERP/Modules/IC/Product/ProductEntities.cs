using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.Product
{
    public class ProductEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties

        public VinaList<ICProductMeasureUnitsInfo> ProductMeasureUnitList { get; set; }
        #endregion

        #region Constructor
        public ProductEntities()
        {
            ProductMeasureUnitList = new VinaList<ICProductMeasureUnitsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ICProductsInfo();
            SearchObject = new ICProductsInfo();
        }

        public override void InitModuleObjects()
        {
            ProductMeasureUnitList.InitVinaList(this
                                                , TableName.ICProductsTableName
                                                , TableName.ICProductMeasureUnitsTableName
                                                , VinaList<ICProductMeasureUnitsInfo>.cstRelationForeign);
            ProductMeasureUnitList.ItemTableForeignKey = "FK_ICProductID";
        }

        public override void InitGridControlInVinaList()
        {
            ProductMeasureUnitList.InitVinaListGridControl("fld_dgcICProductMeasureUnits");
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ProductMeasureUnitList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception) { }
        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {
            ProductMeasureUnitList.Invalidate(iObjectID);
        }

        public override void SaveModuleObjects()
        {
            ProductMeasureUnitList.SaveItemObjects();
        }
    }
}
