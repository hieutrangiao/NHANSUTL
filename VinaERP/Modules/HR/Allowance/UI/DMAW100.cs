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
using VinaCommon;

namespace VinaERP.Modules.Allowance.UI
{
    public partial class DMAW100 : VinaERPScreen
    {
        public DMAW100()
        {
            InitializeComponent();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ((AllowanceModule)Module).AddEmployee();
        }

        private void fld_txtHRAllowanceValue_Validated(object sender, EventArgs e)
        {
            ((AllowanceModule)Module).UpdateValue();
        }

        private void fld_dteHRAllowanceFromDate_Validated(object sender, EventArgs e)
        {
            ((AllowanceModule)Module).UpdateItemDate();
        }

        private void fld_txtHRAllowanceType_Validated(object sender, EventArgs e)
        {
        }

        private void fld_lkeHRAllowanceOption_Validated(object sender, EventArgs e)
        {
        }

        private void fld_lkeFK_HRFormAllowanceID_QueryPopUp(object sender, CancelEventArgs e)
        {
            HRFormAllowancesController objFormAllowancesController = new HRFormAllowancesController();
            List<HRFormAllowancesInfo> list = new List<HRFormAllowancesInfo>();
            list = objFormAllowancesController.GetHRFormAllowancesByFormAllowancesType(HRFormAllowanceType.CaNhan.ToString());
            fld_lkeFK_HRFormAllowanceID.Properties.DataSource = list;
        }
    }
}