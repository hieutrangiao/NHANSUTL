using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common.Constant.AR;
using VinaLib;

namespace VinaERP.Modules.Proposal
{
    public class ProposalModule : BaseModuleERP
    {
        public ProposalModule()
        {
            this.CurrentModuleName = "Proposal";
            CurrentModuleEntity = new ProposalEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }
        public void AddItemFromProposalItemsList(int productID)
        {
            if (Toolbar.IsNullOrNoneAction() || productID <= 0)
                return;

            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = objProductsController.GetObjectByID(productID) as ICProductsInfo;
            if (objProductsInfo == null)
                return;

            ProposalEntities entity = CurrentModuleEntity as ProposalEntities;
            entity.ProposalItemList.Add(
                new ARProposalItemsInfo()
                {
                    FK_ICProductID = objProductsInfo.ICProductID,
                    FK_ICMeasureUnitID = objProductsInfo.FK_ICProductBasicUnitID,
                    ARProposalItemProductNo = objProductsInfo.ICProductNo,
                    ARProposalItemProductName = objProductsInfo.ICProductName,
                    ARProposalItemDesc = objProductsInfo.ICProductDesc,
                    ARProposalItemProductType = objProductsInfo.ICProductTemplateType,
                    ARProposalItemProductUnitPrice = objProductsInfo.ICProductPrice,
                    ARProposalItemPrice = objProductsInfo.ICProductPrice,
                    ARProposalItemQty = 1,
                    ARProposalItemTotalAmount = objProductsInfo.ICProductPrice
                });
            UpdateTotalAmount();
            entity.ProposalItemList.GridControl.RefreshDataSource();
        }

        public override void ActionNew()
        {
            base.ActionNew();

            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)CurrentModuleEntity.MainObject;
            mainObject.ARProposalStatus = ProposalStatus.New;
            entity.UpdateMainObject();
        }

        public override int ActionSave()
        {
            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)CurrentModuleEntity.MainObject;

            if(mainObject.FK_ARCustomerID == 0)
            {
                MessageBox.Show("Khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if(string.IsNullOrEmpty(mainObject.ARProposalName))
            {
                MessageBox.Show("Tên báo giá không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return base.ActionSave();
        }

        public void ChangeCustomer(int customerID)
        {
            if (Toolbar.IsNullOrNoneAction() || customerID <= 0)
                return;

            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)CurrentModuleEntity.MainObject;
            ARCustomersController objCustomersController = new ARCustomersController();
            ARCustomersInfo objCustomersInfo = objCustomersController.GetObjectByID(customerID) as ARCustomersInfo;
            if (objCustomersInfo == null)
                return;
            if (objCustomersInfo.ARCustomerActiveCheck == false)
            {
                MessageBox.Show("Khách hàng này đã bỏ hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mainObject.FK_ARCustomerID = customerID;
            mainObject.ARProposalCustomerName = objCustomersInfo.ARCustomerName;
            mainObject.FK_GECurrencyID = objCustomersInfo.FK_GECurrencyID;
            mainObject.ARProposalPaymentMethod = string.IsNullOrEmpty(objCustomersInfo.ARCustomerPaymentMethod) ? string.Empty : objCustomersInfo.ARCustomerPaymentMethod;
            entity.UpdateMainObjectBindingSource();
            SetDefaultProposalName();
        }


        public void DeleteItemFromProposalItemList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;
            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            entity.ProposalItemList.RemoveSelectedRowObjectFromList();
            UpdateTotalAmount();
        }

        public void UpdateTotalAmount()
        {
            if (!Toolbar.IsNullOrNoneAction())
            {
                ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
                entity.UpdateTotalAmount();
            }
        }

        public void ChangeDiscountPercent()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            UpdateTotalAmount();
        }

        public void ChangeTaxPercent()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            UpdateTotalAmount();
        }

        public void ChangeDiscountAmount()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)entity.MainObject;
            if (mainObject.ARProposalSubTotalAmount > 0)
                mainObject.ARProposalDiscountPerCent = mainObject.ARProposalDiscountAmount / mainObject.ARProposalSubTotalAmount * 100;
            UpdateTotalAmount();
        }

        public void ChangeTaxAmount()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)entity.MainObject;
            if (mainObject.ARProposalSubTotalAmount > 0)
                mainObject.ARProposalDiscountPerCent = mainObject.ARProposalTaxAmount / mainObject.ARProposalSubTotalAmount * 100;
            UpdateTotalAmount();
        }

        public void ChangeItemFromProposalItemsList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)CurrentModuleEntity.MainObject;
            if (entity.ProposalItemList.CurrentIndex < 0)
                return;

            ARProposalItemsInfo objProposalItemsInfo = entity.ProposalItemList[entity.ProposalItemList.CurrentIndex];
            if (objProposalItemsInfo == null)
                return;

            entity.UpdateTotalAmountProposalItemList(mainObject.FK_GECurrencyID);
            UpdateTotalAmount();
            entity.ProposalItemList.GridControl.RefreshDataSource();
            entity.UpdateMainObjectBindingSource();
        }

        public void SetDefaultProposalName()
        {
            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)CurrentModuleEntity.MainObject;

            if (!String.IsNullOrWhiteSpace(mainObject.ARProposalName))
                return;

            if (mainObject.FK_ARCustomerID == 0)
                return;

            mainObject.ARProposalName = string.Format("Bán hàng cho {0}", mainObject.ARProposalCustomerName);

            entity.UpdateMainObjectBindingSource();
        }

        public override void ActionApproved()
        {
            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)entity.MainObject;

            ARProposalsController objProposalsController = new ARProposalsController();
            mainObject.ARProposalStatus = "Approved";
            entity.UpdateMainObject();
            InvalidateToolbar();
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)entity.MainObject;
            ParentScreen.SetEnableOfToolbarButton("Approve", false);
            if (mainObject.ARProposalID > 0)
            {
                ParentScreen.SetEnableOfToolbarButton("Approve", true);
                if (mainObject.ARProposalStatus == "Approve")
                {
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                    ParentScreen.SetEnableOfToolbarButton("Approve", false);
                }
            }
        }

        public void ChangeCurrency(int currencyID)
        {
            ProposalEntities entity = (ProposalEntities)CurrentModuleEntity;
            ARProposalsInfo mainObject = (ARProposalsInfo)entity.MainObject;

            mainObject.FK_GECurrencyID = currencyID;
            entity.UpdatePriceBelongCurrency(currencyID);
            entity.UpdateMainObjectBindingSource();
        }
    }
}
