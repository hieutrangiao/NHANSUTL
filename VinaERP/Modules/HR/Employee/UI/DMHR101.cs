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

namespace VinaERP.Modules.Employee.UI
{
    public partial class DMHR101 : VinaERPScreen
    {
        public DMHR101()
        {
            InitializeComponent();
        }

        private void fld_txtHREmployeeContractSlrAmt_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }

        private void fld_txtHREmployeeWorkingSlrAmtDate_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateWorkingSlrAmt();
        }

        private void fld_txtHREmployeeAllowanceProgress_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateWorkingSlrAmtDateTotal();
        }

        private void fld_txtHREmployeeAllowanceEffective_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateWorkingSlrAmtDateTotal();
        }

        private void fld_txtHREmployeeAllowanceResponsibility_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateWorkingSlrAmtDateTotal();
        }

        private void fld_txtHREmployeeAllowanceOther_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateWorkingSlrAmtDateTotal();
        }

        private void fld_txtHREmployeeSocialInsPaymentPercent_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }

        private void fld_txtHREmployeeHealthInsPaymentPercent_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }

        private void fld_txtHREmployeeOutOfWorkInsPaymentPercent_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }

        private void fld_txtHREmployeeSocialInsPaymentPercentDN_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }

        private void fld_txtHREmployeeHealthInsPaymentPercentDN_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }

        private void fld_txtHREmployeeOutOfWorkInsPaymentPercentDN_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }

        private void fld_txtHREmployeeSyndicatePaymentPercent_Validated(object sender, EventArgs e)
        {
            ((EmployeeModule)Module).UpdateInsPaymentAmt();
        }
    }
}