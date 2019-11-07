using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;

namespace VinaERP.Modules.Invoice.UI
{
    public partial class guiChooseShipmentItem : VinaERPScreen
    {
        private GridControlHelper GridControlHelper;
        private List<ICShipmentItemsInfo> SaleOrderItemList { get; set; }
        public IList SelectedObjects { get; set; }
        public guiChooseShipmentItem(List<ICShipmentItemsInfo> saleOrderItemList)
        {
            InitializeComponent();
            SaleOrderItemList = saleOrderItemList;
            
        }

        private void guiChooseSaleOrderItem_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            SelectedObjects = new List<ICShipmentItemsInfo>();
            fld_dgcICShipmentItems.InvalidateDataSource(SaleOrderItemList);

            GridView gridView = (GridView)fld_dgcICShipmentItems.MainView;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsMenu.EnableFooterMenu = false;
            GridControlHelper = new GridControlHelper(gridView);
            gridView.ExpandAllGroups();
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            SelectedObjects = GridControlHelper.Selection.OfType<ICShipmentItemsInfo>().ToList();
            if (SelectedObjects.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((SelectedObjects as List<ICShipmentItemsInfo>).Any(o=>o.FK_ARSaleOrderID != (SelectedObjects[0] as ICShipmentItemsInfo).FK_ARSaleOrderID))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cũng đơn bán hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}