using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Utilities.GenaralLeadger;
using VinaLib;

namespace VinaERP.Modules.Receipt
{
    public class ReceiptEntities : GLReceiptEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables

        #endregion

        #region Public Properties

        #endregion

        #region Constructor
        public ReceiptEntities()
        {
            ReceiptItemsList = new VinaList<ICReceiptItemsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ICReceiptsInfo();
            SearchObject = new ICReceiptsInfo();
        }

        public override void InitModuleObjectList()
        {
            ReceiptItemsList.InitVinaList(this,
                                            "ICReceipts",
                                            "ICReceiptItems",
                                            VinaList<ICReceiptItemsInfo>.cstRelationForeign);
            ReceiptItemsList.ItemTableForeignKey = "FK_ICReceiptID";
        }

        public override void InitGridControlInVinaList()
        {
            ReceiptItemsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            ICReceiptsInfo mainObject = (ICReceiptsInfo)MainObject;
            mainObject.ICReceiptDate = DateTime.Now;
            mainObject.FK_HREmployeeID = VinaApp.CurrentUserInfo.FK_HREmployeeID;
            mainObject.ICReceiptProductLotNo = GetStockLotNo();
            UpdateMainObjectBindingSource();
        }

        public override int SaveMainObject()
        {
            int iObjectID = base.SaveMainObject();
            if(iObjectID > 0)
            {
                UpdateStockLotNo();
            }
            return iObjectID;
        }

        public string GetStockLotNo()
        {
            GENumberingsController objNumberingsController = new GENumberingsController();
            GENumberingsInfo objNumberingsInfo = (GENumberingsInfo)objNumberingsController.GetObjectByName("ProductLotNo");
            if (objNumberingsInfo == null)
                return string.Empty;

            return string.Format("{0}{1}{2}", objNumberingsInfo.GENumberingPrefix
                                            , objNumberingsInfo.GENumberingPrefixHaveYear ? DateTime.Now.Year.ToString("YY") + "." : string.Empty
                                            , objNumberingsInfo.GENumberingNumber.ToString().PadLeft(objNumberingsInfo.GENumberingLength,'0'));
        }

        public void UpdateStockLotNo()
        {
            GENumberingsController objNumberingsController = new GENumberingsController();
            GENumberingsInfo objNumberingsInfo = (GENumberingsInfo)objNumberingsController.GetObjectByName("ProductLotNo");
            if (objNumberingsInfo == null)
                return;

            objNumberingsInfo.GENumberingNumber++;
            objNumberingsController.UpdateObject(objNumberingsInfo);
        }
        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ReceiptItemsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {
            ReceiptItemsList.Invalidate(iObjectID);
        }

        public override void SaveModuleObjects()
        {
            ICStockLotsController objStockLotsController = new ICStockLotsController();
            ICStockLotsInfo objStockLotsInfo = new ICStockLotsInfo();

            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = new ICProductsInfo();
            ReceiptItemsList.ForEach(o =>
            {
                objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(o.FK_ICProductID);
                if (objProductsInfo == null)
                    return;

                objStockLotsInfo = objStockLotsController.GetStockLotByProductAndLotNo(o.FK_ICProductID, o.ICReceiptItemStockLotNo);
                if(objStockLotsInfo == null)
                {

                    objStockLotsInfo = new ICStockLotsInfo()
                    {
                        ICStockLotNo = o.ICReceiptItemStockLotNo,
                        FK_ICProductID = o.FK_ICProductID,
                        ICStockLotProductNo = objProductsInfo.ICProductNo,
                        ICStockLotProductName = objProductsInfo.ICProductName,
                        ICStockLotProductDesc = objProductsInfo.ICProductDesc,
                        ICStockLotProductLength = objProductsInfo.ICProductLength,
                        ICStockLotProductWidth = objProductsInfo.ICProductWidth,
                        ICStockLotProductHeight = objProductsInfo.ICProductHeight
                    };
                    objStockLotsController.CreateObject(objStockLotsInfo);
                }
                o.FK_ICStockLotID = objStockLotsInfo.ICStockLotID;
            });
            ReceiptItemsList.SaveItemObjects();
        }

        public void UpdateTotalAmount()
        {
            ICReceiptsInfo mainobject = (ICReceiptsInfo)MainObject;
            mainobject.ICReceiptSubTotalAmount = ReceiptItemsList.Sum(o => o.ICReceiptItemTotalAmount);
            mainobject.ICReceiptDiscountAmount = mainobject.ICReceiptSubTotalAmount * mainobject.ICReceiptDiscountPercent / 100;
            mainobject.ICReceiptTaxAmount = (mainobject.ICReceiptSubTotalAmount - mainobject.ICReceiptDiscountAmount) * mainobject.ICReceiptTaxPercent / 100;
            mainobject.ICReceiptTotalAmount = mainobject.ICReceiptSubTotalAmount - mainobject.ICReceiptDiscountAmount + mainobject.ICReceiptTaxAmount;
            UpdateMainObjectBindingSource();
        }
    }
}
