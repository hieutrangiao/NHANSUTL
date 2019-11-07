using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaLib;

namespace VinaERP.Modules.Proposal
{
    public class ProposalEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<ARProposalItemsInfo> ProposalItemList { get; set; }

        #endregion

        #region Constructor
        public ProposalEntities()
        {
            ProposalItemList = new VinaList<ARProposalItemsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ARProposalsInfo();
            SearchObject = new ARProposalsInfo();
        }

        public override void InitModuleObjectList()
        {
            ProposalItemList.InitVinaList(this,
                                            "ARProposals",
                                            "ARProposalItems",
                                            VinaList<ARProposalItemsInfo>.cstRelationForeign);
            ProposalItemList.ItemTableForeignKey = "FK_ARProposalID";
        }

        public override void InitGridControlInVinaList()
        {
            ProposalItemList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            ARProposalsInfo mainObject = (ARProposalsInfo)MainObject;
            mainObject.ARProposalDate = DateTime.Now;
            mainObject.ARProposalDeliveryDate = DateTime.Now;
            mainObject.ARProposalValidateDate = DateTime.Now.AddDays(7);
            mainObject.FK_HREmployeeID = VinaApp.CurrentUserInfo.FK_HREmployeeID;
            mainObject.ARProposalExchangeRate = 1;
            mainObject.FK_GECurrencyID = 1;
            UpdateMainObjectBindingSource();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ProposalItemList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {
            ProposalItemList.Invalidate(iObjectID);
        }

        public override void SaveModuleObjects()
        {
            ProposalItemList.SaveItemObjects();
        }

        public void UpdateTotalAmount()
        {
            ARProposalsInfo mainObject = (ARProposalsInfo)MainObject;

            mainObject.ARProposalSubTotalAmount = ProposalItemList.Sum(o => o.ARProposalItemTotalAmount);
            VinaApp.RoundByCurrency(mainObject, "ARProposalSubTotalAmount", mainObject.FK_GECurrencyID);

            mainObject.ARProposalDiscountAmount = mainObject.ARProposalDiscountPerCent / 100 * mainObject.ARProposalSubTotalAmount;
            VinaApp.RoundByCurrency(mainObject, "ARProposalDiscountAmount", mainObject.FK_GECurrencyID);

            mainObject.ARProposalTaxAmount = mainObject.ARProposalTaxPercent / 100 * (mainObject.ARProposalSubTotalAmount - mainObject.ARProposalDiscountAmount);
            VinaApp.RoundByCurrency(mainObject, "ARProposalTaxAmount", mainObject.FK_GECurrencyID);

            mainObject.ARProposalTotalAmount = mainObject.ARProposalSubTotalAmount - mainObject.ARProposalDiscountAmount + mainObject.ARProposalTaxAmount;
            VinaApp.RoundByCurrency(mainObject, "ARProposalTotalAmount", mainObject.FK_GECurrencyID);

            UpdateMainObjectBindingSource();
        }

        public void UpdatePriceBelongCurrency(int currencyID)
        {
            ARProposalsInfo mainObject = (ARProposalsInfo)MainObject;

            ProposalItemList.ForEach(o =>
            {
                if(mainObject.ARProposalExchangeRate != mainObject.ARProposalExchangeRateOld)
                {
                    o.ARProposalItemProductUnitPrice = o.ARProposalItemProductUnitPrice * mainObject.ARProposalExchangeRate;
                    o.ARProposalItemPrice = o.ARProposalItemPrice * mainObject.ARProposalExchangeRate;
                }
                VinaApp.RoundByCurrency(o, "ARProposalItemProductUnitPrice", currencyID);
                VinaApp.RoundByCurrency(o, "ARProposalItemPrice", currencyID);
            });

            mainObject.ARProposalExchangeRateOld = mainObject.ARProposalExchangeRate;

            UpdateTotalAmountProposalItemList(currencyID);
            UpdateTotalAmount();
        }

        public void UpdateTotalAmountProposalItemList(int currencyID)
        {
            ProposalItemList.ForEach(o =>
            {
                o.ARProposalItemDiscountAmount = o.ARProposalItemPrice * o.ARProposalItemQty * o.ARProposalItemDiscountPercent / 100;
                VinaApp.RoundByCurrency(o, "ARProposalItemDiscountAmount", currencyID);
                o.ARProposalItemTaxAmount = (o.ARProposalItemPrice * o.ARProposalItemQty - o.ARProposalItemDiscountAmount) * o.ARProposalItemTaxPercent / 100;
                VinaApp.RoundByCurrency(o, "ARProposalItemTaxAmount", currencyID);
                o.ARProposalItemTotalAmount = o.ARProposalItemPrice * o.ARProposalItemQty - o.ARProposalItemDiscountAmount + o.ARProposalItemTaxAmount;
                VinaApp.RoundByCurrency(o, "ARProposalItemTotalAmount", currencyID);
            });
            ProposalItemList.GridControl.RefreshDataSource();
        }
    }
}