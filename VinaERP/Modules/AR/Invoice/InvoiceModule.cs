using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Modules.Invoice.UI;
using VinaERP.Report;
using VinaLib;

namespace VinaERP.Modules.Invoice
{
    public class InvoiceModule : BaseModuleERP
    {
        public InvoiceModule()
        {
            this.CurrentModuleName = "Invoice";
            CurrentModuleEntity = new InvoiceEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            SetDefaultInvoiceName();
            return base.ActionSave();
        }

        public void ActionNewFromSaleOrederShipment()
        {
            base.ActionNew();
            InvoiceEntities entity = CurrentModuleEntity as InvoiceEntities;
            ARInvoicesInfo mainObject = entity.MainObject as ARInvoicesInfo;

            ICShipmentItemsController objShipmentItemsController = new ICShipmentItemsController();
            List<ICShipmentItemsInfo> shipmentItems = objShipmentItemsController.GetShipmentItemForInvoice();

            guiChooseShipmentItem guiFind = new guiChooseShipmentItem(shipmentItems);
            guiFind.Module = this;
            DialogResult rs = guiFind.ShowDialog();
            if (rs != DialogResult.OK)
            {
                ActionCancel();
                return;
            }
            shipmentItems = guiFind.SelectedObjects as List<ICShipmentItemsInfo>;

            ICShipmentItemsInfo objShipmentItemsInfo = shipmentItems.FirstOrDefault();
            ARSaleOrdersController objSaleOrdersController = new ARSaleOrdersController();
            ARSaleOrdersInfo objSaleOrdersInfo = objSaleOrdersController.GetObjectByID(objShipmentItemsInfo.FK_ARSaleOrderID) as ARSaleOrdersInfo;

            mainObject.FK_ARSaleOrderID = objSaleOrdersInfo.ARSaleOrderID;
            mainObject.ARInvoiceCustomerAddress = objSaleOrdersInfo.ARSaleOrderCustomerAddress;
            mainObject.ARInvoiceCustomerDeliveryAddress = objSaleOrdersInfo.ARSaleOrderCustomerDeliveryAddress;
            mainObject.ARInvoiceCustomerDeliveryName = objSaleOrdersInfo.ARSaleOrderCustomerDeliveryName;
            mainObject.ARInvoiceCustomerDeliveryPhone = objSaleOrdersInfo.ARSaleOrderCustomerDeliveryPhone;
            mainObject.ARInvoiceCustomerName = objSaleOrdersInfo.ARSaleOrderCustomerName;
            mainObject.ARInvoiceCustomerPhone = objSaleOrdersInfo.ARSaleOrderCustomerPhone;
            mainObject.ARInvoiceCustomerTaxCode = objSaleOrdersInfo.ARSaleOrderCustomerTaxCode;
            mainObject.ARInvoiceDiscountPercent = objSaleOrdersInfo.ARSaleOrderDiscountPercent;
            mainObject.ARInvoiceTaxPercent = objSaleOrdersInfo.ARSaleOrderTaxPercent;
            mainObject.ARInvoiceExchangeRate = objSaleOrdersInfo.ARSaleOrderExchangeRate;
            mainObject.ARInvoiceDeliveryDate = objSaleOrdersInfo.ARSaleOrderDeliveryDate;
            mainObject.ARInvoiceInternalComment = objSaleOrdersInfo.ARSaleOrderInternalComment;
            mainObject.ARInvoiceComment = objSaleOrdersInfo.ARSaleOrderComment;
            mainObject.FK_GECurrencyID = objSaleOrdersInfo.FK_GECurrencyID;
            mainObject.FK_ARCustomerID = objSaleOrdersInfo.FK_ARCustomerID;
            mainObject.FK_HRSellerEmployeeID = objSaleOrdersInfo.FK_HRSellerEmployeeID;

            entity.GenerateInvoiceItemList(shipmentItems);
            UpdateTotalAmount();
            entity.UpdateMainObjectBindingSource();
        }

        public void AddItemToInvoiceItemList(int productID)
        {
            if (Toolbar.IsNullOrNoneAction() || productID <= 0)
                return;

            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = objProductsController.GetObjectByID(productID) as ICProductsInfo;
            if (objProductsInfo == null)
                return;

            InvoiceEntities entity = CurrentModuleEntity as InvoiceEntities;
            entity.InvoiceItemList.Add(
                new ARInvoiceItemsInfo()
                {
                    FK_ICProductID = objProductsInfo.ICProductID,
                    FK_ICMeasureUnitID = objProductsInfo.FK_ICProductBasicUnitID,
                    ARInvoiceItemProductNo = objProductsInfo.ICProductNo,
                    ARInvoiceItemProductName = objProductsInfo.ICProductName,
                    ARInvoiceItemProductDesc = objProductsInfo.ICProductDesc,
                    ARInvoiceItemProductType = objProductsInfo.ICProductType,
                    ARInvoiceItemProductUnitPrice = objProductsInfo.ICProductPrice
                });
            entity.InvoiceItemList.GridControl.RefreshDataSource();
        }

        public void ChangeCustomer(int customerID)
        {
            if (Toolbar.IsNullOrNoneAction() || customerID <= 0)
                return;

            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            ARInvoicesInfo mainObject = (ARInvoicesInfo)CurrentModuleEntity.MainObject;
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
            mainObject.ARInvoiceCustomerName = objCustomersInfo.ARCustomerName;
            mainObject.ARInvoiceCustomerPhone = string.IsNullOrEmpty(objCustomersInfo.ARCustomerContactPhone1) ? (string.IsNullOrEmpty(objCustomersInfo.ARCustomerContactPhone2) ? string.Empty : objCustomersInfo.ARCustomerContactPhone2) : objCustomersInfo.ARCustomerContactPhone1;
            mainObject.FK_GECurrencyID = objCustomersInfo.FK_GECurrencyID;
            mainObject.ARInvoiceCustomerTaxCode = objCustomersInfo.ARCustomerTaxNumber;
            mainObject.ARInvoiceCustomerAddress = objCustomersInfo.ARCustomerContactAddress;
            mainObject.ARInvoiceCustomerDeliveryName = objCustomersInfo.ARCustomerName;
            mainObject.ARInvoiceCustomerDeliveryPhone = mainObject.ARInvoiceCustomerPhone;
            mainObject.ARInvoiceCustomerDeliveryAddress = mainObject.ARInvoiceCustomerAddress;
            entity.UpdateMainObjectBindingSource();
        }

        public void DeleteItemFromInvoiceItemList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;
            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            entity.InvoiceItemList.RemoveSelectedRowObjectFromList();
        }

        public void UpdateTotalAmount()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            entity.UpdateTotalAmount();
        }

        public void ChangeDiscountPercent()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            UpdateTotalAmount();
        }

        public void ChangeDiscountAmount()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            ARInvoicesInfo mainObject = (ARInvoicesInfo)entity.MainObject;
            if (mainObject.ARInvoiceSubTotalAmount > 0)
                mainObject.ARInvoiceDiscountPercent = mainObject.ARInvoiceDiscountAmount / mainObject.ARInvoiceSubTotalAmount * 100;
            UpdateTotalAmount();
        }

        public void ChangeTaxPercent()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            UpdateTotalAmount();
        }

        public void ChangeTaxAmount()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            ARInvoicesInfo mainObject = (ARInvoicesInfo)entity.MainObject;
            if (mainObject.ARInvoiceSubTotalAmount > 0)
                mainObject.ARInvoiceDiscountPercent = mainObject.ARInvoiceTaxAmount / mainObject.ARInvoiceSubTotalAmount * 100;
            UpdateTotalAmount();
        }

        public void SetDefaultInvoiceName()
        {
            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            ARInvoicesInfo mainObject = (ARInvoicesInfo)entity.MainObject;

            if (!String.IsNullOrWhiteSpace(mainObject.ARInvoiceName))
                return;

            if (mainObject.FK_ARCustomerID == 0)
                return;

            if (mainObject.FK_ARSaleOrderID == 0)
                return;

            ARSaleOrdersController objSaleOrdersController = new ARSaleOrdersController();
            ARSaleOrdersInfo objSaleOrdersInfo = objSaleOrdersController.GetObjectByID(mainObject.FK_ARSaleOrderID) as ARSaleOrdersInfo;
            if (objSaleOrdersInfo == null)
                return;

            mainObject.ARInvoiceName = string.Format("Hóa đơn bán hàng của {0} cho đơn bán hàng {1}", mainObject.ARInvoiceCustomerName, objSaleOrdersInfo.ARSaleOrderNo);
        }

        public override void InvalidateToolbar()
        {
            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            ARInvoicesInfo mainObject = (ARInvoicesInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.ARInvoiceID > 0)
            {
                ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
            }
            base.InvalidateToolbar();
        }

        public override void ActionPrint()
        {
            ARInvoice report = new ARInvoice();
            InitializeInvoiceReport(report);
            guiReportPreview reportPreview = new guiReportPreview(report);
            reportPreview.Show();
        }

        private void InitializeInvoiceReport(ARInvoice report)
        {
            InvoiceEntities entity = (InvoiceEntities)CurrentModuleEntity;
            ARInvoicesInfo mainObject = (ARInvoicesInfo)entity.MainObject;

            ARInvoiceItemsController objInvoiceController = new ARInvoiceItemsController();
            List<ARInvoiceItemsInfo> invoiceItemList = objInvoiceController.GetInvoiceItemByInvoiceIDForReport(mainObject.ARInvoiceID);
            report.bsARInvoiceItems.DataSource = invoiceItemList;

            XRLabel label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["pnlTitle"].Controls["fld_xrInvoiceDate"];
            if (label != null)
            {
                label.Text = string.Format(label.Text,
                                           mainObject.ARInvoiceDate.Day,
                                           mainObject.ARInvoiceDate.Month,
                                           mainObject.ARInvoiceDate.Year);
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["pnlToDate"].Controls["xr_lblToDate"];
            if (label != null)
            {
                label.Text = string.Format(label.Text,
                                           DateTime.Now.Day,
                                           DateTime.Now.Month,
                                           DateTime.Now.Year);
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["pnlInvoiceNo"].Controls["fld_lblInvoiceNo"];
            if (label != null)
            {
                label.Text = mainObject.ARInvoiceNo;
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["fld_xrCustomerName"];
            if (label != null)
            {
                label.Text = mainObject.ARInvoiceCustomerName;
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["xr_lbPhone"];
            if (label != null)
            {
                label.Text = mainObject.ARInvoiceCustomerPhone;
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["xr_lblCustomerAddress"];
            if (label != null)
            {
                label.Text = mainObject.ARInvoiceCustomerAddress;
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["xr_lblCustomerDeliveryAddress"];
            if (label != null)
            {
                label.Text = mainObject.ARInvoiceCustomerDeliveryAddress;
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["fld_lblEmployeeSeller"];
            if (label != null)
            {
                HREmployeesController objEmployeesController = new HREmployeesController();
                label.Text = objEmployeesController.GetObjectNameByID(mainObject.FK_HRSellerEmployeeID);
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["fld_lblDeliveryDate"];
            if (label != null)
            {
                label.Text = mainObject.ARInvoiceDeliveryDate.ToString("dd/MM/yyyy");
            }

            label = (XRLabel)report.Bands[BandKind.ReportHeader].Controls["fld_InvoiceDesc"];
            if (label != null)
            {
                label.Text = mainObject.ARInvoiceDesc;
            }
        }
    }
}
