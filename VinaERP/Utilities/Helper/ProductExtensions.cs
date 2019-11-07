using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaERP.Utilities.Helper
{
    public static class ProductExtensions
    {
        public static ICReceiptItemsInfo ToReceiptItem(this ICProductsInfo objProductsInfo)
        {
            return new ICReceiptItemsInfo()
            {
                FK_ICProductID = objProductsInfo.ICProductID,
                FK_ICDepartmentID = objProductsInfo.FK_ICDepartmentID,
                FK_ICProductGroupID = objProductsInfo.FK_ICProductGroupID,
                FK_ICProductAttributeColorID = objProductsInfo.FK_ICProductAttributeColorID,
                FK_ICMeasureUnitID = objProductsInfo.FK_ICProductBasicUnitID,
                FK_ICProductAttributeWoodTypeID = objProductsInfo.FK_ICProductAttributeWoodTypeID,
                ICReceiptItemProductNo = objProductsInfo.ICProductNo,
                ICReceiptItemProductName = objProductsInfo.ICProductName,
                ICReceiptItemProductDesc = objProductsInfo.ICProductDesc,
                ICReceiptItemProductQty = 1,
                ICReceiptItemProductFactor = 1,
                ICReceiptItemProductExchangeQty = 1,
                ICReceiptItemProductType = objProductsInfo.ICProductType,
                ICReceiptItemProductUnitPrice = objProductsInfo.ICProductSupplierPrice,
                ICReceiptItemTotalAmount = objProductsInfo.ICProductSupplierPrice,
                ICReceiptItemProductBasicPrice = objProductsInfo.ICProductSupplierPrice
            };
        }

        public static ICShipmentItemsInfo ToShipmentItem(this ICProductsInfo objProductsInfo)
        {
            return new ICShipmentItemsInfo()
            {
                FK_ICProductID = objProductsInfo.ICProductID,
                FK_ICDepartmentID = objProductsInfo.FK_ICDepartmentID,
                FK_ICProductGroupID = objProductsInfo.FK_ICProductGroupID,
                FK_ICProductAttributeColorID = objProductsInfo.FK_ICProductAttributeColorID,
                FK_ICMeasureUnitID = objProductsInfo.FK_ICProductBasicUnitID,
                FK_ICProductAttributeWoodTypeID = objProductsInfo.FK_ICProductAttributeWoodTypeID,
                ICShipmentItemProductNo = objProductsInfo.ICProductNo,
                ICShipmentItemProductName = objProductsInfo.ICProductName,
                ICShipmentItemProductDesc = objProductsInfo.ICProductDesc,
                ICShipmentItemProductQty = 1,
                ICShipmentItemProductFactor = 1,
                ICShipmentItemProductExchangeQty = 1,
                ICShipmentItemProductType = objProductsInfo.ICProductType,
                ICShipmentItemProductUnitPrice = objProductsInfo.ICProductPrice,
                ICShipmentItemTotalAmount = objProductsInfo.ICProductPrice,
                ICShipmentItemProductBasicPrice = objProductsInfo.ICProductPrice
            };
        }

        public static ARSaleOrderItemsInfo ToSaleOrderItem(this ICProductsInfo objProductsInfo)
        {
            return new ARSaleOrderItemsInfo()
            {
                FK_ICProductID = objProductsInfo.ICProductID,
                FK_ICDepartmentID = objProductsInfo.FK_ICDepartmentID,
                FK_ICProductGroupID = objProductsInfo.FK_ICProductGroupID,
                FK_ICMeasureUnitID = objProductsInfo.FK_ICProductBasicUnitID,
                ARSaleOrderItemProductNo = objProductsInfo.ICProductNo,
                ARSaleOrderItemProductName = objProductsInfo.ICProductName,
                ARSaleOrderItemProductDesc = objProductsInfo.ICProductDesc,
                ARSaleOrderItemProductType = objProductsInfo.ICProductTemplateType,
                ARSaleOrderItemProductUnitPrice = objProductsInfo.ICProductPrice,
                ARSaleOrderItemGrantedFrom = objProductsInfo.ICProductGrantedFrom,
                ARSaleOrderItemProductQty = 1,
                ARSaleOrderItemTotalAmount = objProductsInfo.ICProductPrice,
                ARSaleOrderItemProductBasicPrice = objProductsInfo.ICProductPrice,
            };
        }
    }
}
