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

namespace VinaERP.Modules.SaleOrderShipment.UI
{
    public partial class guiChooseSaleOrderItem : VinaERPScreen
    {
        private GridControlHelper GridControlHelper;
        private List<ARSaleOrderItemsInfo> SaleOrderItemList { get; set; }
        public List<ARSaleOrderItemsInfo> SelectedObjects { get; set; }
        public guiChooseSaleOrderItem(List<ARSaleOrderItemsInfo> saleOrderItemList)
        {
            InitializeComponent();
            SaleOrderItemList = saleOrderItemList;
            
        }

        private void guiChooseSaleOrderItem_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            SelectedObjects = new List<ARSaleOrderItemsInfo>();
            fld_dgcARSaleOrderItems.InvalidateDataSource(SaleOrderItemList);

            GridView gridView = (GridView)fld_dgcARSaleOrderItems.MainView;
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
            SelectedObjects = GridControlHelper.Selection.OfType<ARSaleOrderItemsInfo>().ToList();
            if (SelectedObjects.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((SelectedObjects as List<ARSaleOrderItemsInfo>).Any(o=>o.FK_ARSaleOrderID != (SelectedObjects[0] as ARSaleOrderItemsInfo).FK_ARSaleOrderID))
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