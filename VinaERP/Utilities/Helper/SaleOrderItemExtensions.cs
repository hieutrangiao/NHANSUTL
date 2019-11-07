using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaERP.Utilities.Helper
{
    public static class SaleOrderItemExtensions
    {
        public static ICShipmentItemsInfo ToShipmentItem(this ARSaleOrderItemsInfo objSaleOrderItemsInfo)
        {
            ICStockLotsController objStockLotsController = new ICStockLotsController();
            return new ICShipmentItemsInfo()
            {
                FK_ARSaleOrderID = objSaleOrderItemsInfo.FK_ARSaleOrderID,
                FK_ARSaleOrderItemID = objSaleOrderItemsInfo.ARSaleOrderItemID,
                FK_ICDepartmentID = objSaleOrderItemsInfo.FK_ICDepartmentID,
                FK_ICProductGroupID = objSaleOrderItemsInfo.FK_ICProductGroupID,
                FK_ICMeasureUnitID = objSaleOrderItemsInfo.FK_ICMeasureUnitID,
                FK_ICProductID = objSaleOrderItemsInfo.FK_ICProductID,
                FK_ICStockID = objSaleOrderItemsInfo.FK_ICStockID,
                FK_ICStockLotID = objStockLotsController.GetObjectIDByNo(objSaleOrderItemsInfo.ARSaleOrderItemStockLotNo),
                ICShipmentItemProductBasicPrice = objSaleOrderItemsInfo.ARSaleOrderItemProductBasicPrice,
                ICShipmentItemProductQty = objSaleOrderItemsInfo.ARSaleOrderItemProductQty,
                ICShipmentItemProductFactor = 1,
                ICShipmentItemProductExchangeQty = objSaleOrderItemsInfo.ARSaleOrderItemProductQty,
                ICShipmentItemProductNo = objSaleOrderItemsInfo.ARSaleOrderItemProductNo,
                ICShipmentItemProductName = objSaleOrderItemsInfo.ARSaleOrderItemProductName,
                ICShipmentItemProductDesc = objSaleOrderItemsInfo.ARSaleOrderItemProductDesc,
                ICShipmentItemProductUnitPrice = objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice,
                ICShipmentItemStockLotNo = objSaleOrderItemsInfo.ARSaleOrderItemStockLotNo,
                ICShipmentItemDiscountPercent = objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent,
                ICShipmentItemDiscountAmount = (objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice * objSaleOrderItemsInfo.ARSaleOrderItemProductQty) * objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent / 100,
                ICShipmentItemTaxPercent = objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent,
                ICShipmentItemTaxAmount = ((objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice * objSaleOrderItemsInfo.ARSaleOrderItemProductQty)
                                            - (objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice * objSaleOrderItemsInfo.ARSaleOrderItemProductQty) * objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent / 100)
                                            * objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent / 100,
                ICShipmentItemTotalAmount = (objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice * objSaleOrderItemsInfo.ARSaleOrderItemProductQty)
                                            - (objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice * objSaleOrderItemsInfo.ARSaleOrderItemProductQty) * objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent / 100
                                            + ((objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice * objSaleOrderItemsInfo.ARSaleOrderItemProductQty)
                                                - (objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice * objSaleOrderItemsInfo.ARSaleOrderItemProductQty) * objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent / 100)
                                                * objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent / 100

            };
        }
    }
}
