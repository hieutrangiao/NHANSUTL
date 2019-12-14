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


namespace VinaERP.Modules.EmployeeWorkSchedule.UI
{
    public partial class DMWS100 : VinaERPScreen
    {
        public DMWS100()
        {
            InitializeComponent();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ((EmployeeWorkScheduleModule)Module).AddEmployee();
        }

        private void fld_txtHREmployeeWorkScheduleValue_Validated(object sender, EventArgs e)
        {

        }

        private void fld_dteHREmployeeWorkScheduleFromDate_Validated(object sender, EventArgs e)
        {

        }

        private void fld_txtHREmployeeWorkScheduleType_Validated(object sender, EventArgs e)
        {

        }

        private void fld_lkeHREmployeeWorkScheduleOption_Validated(object sender, EventArgs e)
        {

        }
    }
}