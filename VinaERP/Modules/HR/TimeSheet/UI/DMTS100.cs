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
using VinaLib;

namespace VinaERP.Modules.TimeSheet.UI
{
    public partial class DMTS100 : VinaERPScreen
    {
        public DMTS100()
        {
            InitializeComponent();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ((TimeSheetModule)Module).AddEmployee();
        }

        private void fld_txtHRRewardValue_Validated(object sender, EventArgs e)
        {
        }

        private void fld_dteHRRewardFromDate_Validated(object sender, EventArgs e)
        {
            int n1 = fld_dteHRTimeSheetDate.DateTime.Year;
            int n2 = fld_dteHRTimeSheetDate.DateTime.Month;
            DateTime date = new DateTime(n1, n2, 1);
            DateTime dateEndMonth = VinaUtil.GetMonthEndDate(date);

            fld_dteHRTimeSheetToDate.DateTime = dateEndMonth;
            fld_dteHRTimeSheetFromDate.DateTime = date;
            ((TimeSheetModule)Module).ChangeTimeSheetTime();
        }

        private void fld_txtHRRewardType_Validated(object sender, EventArgs e)
        {
        }

        private void fld_lkeHRRewardOption_Validated(object sender, EventArgs e)
        {
        }

        private void fld_lkeHRTimeSheetType_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            VinaLookupEdit lke = (VinaLookupEdit)sender;
            if (e.Value != null && lke.OldEditValue != e.Value)
            {
                ((TimeSheetModule)Module).ChangeTimeSheetType(e.Value.ToString());
            }
        }

        private void fld_dteHRTimeSheetFromDate_Validated(object sender, EventArgs e)
        {
            ((TimeSheetModule)Module).ChangeTimeSheetTime();
        }

        private void fld_dteHRTimeSheetToDate_Validated(object sender, EventArgs e)
        {
            ((TimeSheetModule)Module).ChangeTimeSheetTime();
        }
    }
}