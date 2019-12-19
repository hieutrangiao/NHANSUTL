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
using VinaLib.BaseProvider;


namespace VinaERP.Modules.PayRoll.UI
{
    public partial class DMPR100 : VinaERPScreen
    {
        public DMPR100()
        {
            InitializeComponent();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ((PayRollModule)Module).AddEmployee();
        }

        private void fld_txtHRRewardValue_Validated(object sender, EventArgs e)
        {
            ((PayRollModule)Module).UpdateValue();
        }

        private void fld_dteHRRewardFromDate_Validated(object sender, EventArgs e)
        {
            ((PayRollModule)Module).UpdateItemDate();
        }

        private void fld_txtHRRewardType_Validated(object sender, EventArgs e)
        {
            ((PayRollModule)Module).SetMaskForTextBox();
        }

        private void fld_lkeHRRewardOption_Validated(object sender, EventArgs e)
        {
            ((PayRollModule)Module).SetMaskForTextBox();
        }
    }
}