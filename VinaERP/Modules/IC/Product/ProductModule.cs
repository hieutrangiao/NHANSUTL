using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Common;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Product
{
    public class ProductModule : BaseModuleERP
    {
        public const string WoodTypeCheckedComboBoxControlName = "fld_ccbeICProductAttributeWoodType";

        public const string ColorCheckedComboBoxControlName = "fld_ccbeICProductAttributeColor";

        public const string WoodTypeLookupEditName = "fld_lkeFK_ICProductAttributeWoodTypeID";

        public const string ColorLookupEditName = "fld_lkeFK_ICProductAttributeColorID";

        public const string ProductGroupLookupEditName = "fld_lkeFK_ICProductGroupID";

        public CheckedComboBoxEdit WoodTypeCheckedComboBoxControl { get; set; }

        public CheckedComboBoxEdit ColorCheckedComboBoxControl { get; set; }

        public VinaLookupEdit WoodTypeLookupEditControl { get; set; }

        public VinaLookupEdit ColorLookupEditControl { get; set; }

        public VinaLookupEdit ProductGroupLookupEditControl { get; set; }

        public ProductModule()
        {
            this.CurrentModuleName = "Product";
            CurrentModuleEntity = new ProductEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();


            WoodTypeLookupEditControl = (VinaLookupEdit)Controls[WoodTypeLookupEditName];
            WoodTypeLookupEditControl.Properties.DataSource = GetProductAttributesByGroup(ProductAttributeGroup.WoodType);

            ColorLookupEditControl = (VinaLookupEdit)Controls[ColorLookupEditName];
            ColorLookupEditControl.Properties.DataSource = GetProductAttributesByGroup(ProductAttributeGroup.Color);

            ProductGroupLookupEditControl = (VinaLookupEdit)Controls[ProductGroupLookupEditName];

            WoodTypeCheckedComboBoxControl = (CheckedComboBoxEdit)Controls[WoodTypeCheckedComboBoxControlName];
            WoodTypeCheckedComboBoxControl.Properties.DataSource = GetProductAttributesByGroup(ProductAttributeGroup.WoodType);
            WoodTypeCheckedComboBoxControl.Properties.DisplayMember = "ICProductAttributeName";
            WoodTypeCheckedComboBoxControl.Properties.ValueMember = "ICProductAttributeID";

            ColorCheckedComboBoxControl = (CheckedComboBoxEdit)Controls[ColorCheckedComboBoxControlName];
            ColorCheckedComboBoxControl.Properties.DataSource = GetProductAttributesByGroup(ProductAttributeGroup.Color);
            ColorCheckedComboBoxControl.Properties.DisplayMember = "ICProductAttributeName";
            ColorCheckedComboBoxControl.Properties.ValueMember = "ICProductAttributeID";


        }

        public List<ICProductAttributesInfo> GetProductAttributesByGroup(string strProductAttributeGroup)
        {
            ICProductAttributesController objProductAttributesController = new ICProductAttributesController();
            List<ICProductAttributesInfo> productAttributes = objProductAttributesController.GetProductAttributeByGroup(strProductAttributeGroup);

            return productAttributes;
        }

        public override int ActionSave()
        {
            SetProductExtraWoodTypeAndColor();
            return base.ActionSave();
        }

        public override void ActionNew()
        {
            base.ActionNew();

            ICProductsInfo objProductsInfo = (ICProductsInfo)((ProductEntities)CurrentModuleEntity).MainObject;
            WoodTypeCheckedComboBoxControl.SetEditValue(objProductsInfo.ICProductAttributeWoodType);
            ColorCheckedComboBoxControl.SetEditValue(objProductsInfo.ICProductAttributeColor);
        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);

            ICProductsInfo objProductsInfo = (ICProductsInfo)((ProductEntities)CurrentModuleEntity).MainObject;
            WoodTypeCheckedComboBoxControl.SetEditValue(objProductsInfo.ICProductAttributeWoodType);
            ColorCheckedComboBoxControl.SetEditValue(objProductsInfo.ICProductAttributeColor);
            ProductGroupLookupEditControl.Properties.DataSource = GetProductGroupByDepartmentForDataSource();
        }
        public void SetProductExtraWoodTypeAndColor()
        {
            ProductEntities entity = (ProductEntities)CurrentModuleEntity;
            ICProductsInfo objProductsInfo = (ICProductsInfo)entity.MainObject;
            if (objProductsInfo != null)
            {
                if (WoodTypeCheckedComboBoxControl.EditValue != null)
                {
                    string woodTypes = WoodTypeCheckedComboBoxControl.EditValue.ToString();
                    objProductsInfo.ICProductAttributeWoodType = woodTypes;
                }

                if (ColorCheckedComboBoxControl.EditValue != null)
                {
                    string colors = ColorCheckedComboBoxControl.EditValue.ToString();
                    objProductsInfo.ICProductAttributeColor = colors;
                }
            }
        }
        public List<ICProductGroupsInfo> GetProductGroupByDepartmentForDataSource()
        {
            ProductEntities entity = (ProductEntities)CurrentModuleEntity;
            ICProductsInfo objProductsInfo = (ICProductsInfo)entity.MainObject;
            ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
            return objProductGroupsController.GetProductGroupByDepartmentID(objProductsInfo.FK_ICDepartmentID);
        }
    }
}
