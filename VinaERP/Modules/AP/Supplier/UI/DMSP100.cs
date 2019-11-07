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
using VinaERP.Common;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Supplier.UI
{
    public partial class DMSP100 : VinaERPScreen
    {
        public DMSP100()
        {
            InitializeComponent();
        }

        private void fld_lkeFK_ICProductGroupID_QueryPopUp(object sender, CancelEventArgs e)
        {
            VinaLookupEdit lke = sender as VinaLookupEdit;
            if (lke == null)
                return;

            //lke.Properties.DataSource = ((ProductModule)Module).GetProductGroupByDepartmentForDataSource();
        }
    }
}