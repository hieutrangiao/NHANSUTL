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


namespace VinaERP.Modules.OverTime.UI
{
    public partial class DMOT100 : VinaERPScreen
    {
        public DMOT100()
        {
            InitializeComponent();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ((OverTimeModule)Module).AddEmployee();
        }

        private void fld_txtHROverTimeFromDate_Validated(object sender, EventArgs e)
        {
            ((OverTimeModule)Module).UpdateDateEnd();
        }

        private void vinaTextBox2_Validated(object sender, EventArgs e)
        {
            if (fld_txtHROverTimeDate.EditValue != fld_txtHROverTimeDate.OldEditValue)
                if (!((OverTimeModule)Module).ChangeFromTimeOT())
                {
                    fld_txtHROverTimeDate.EditValue = fld_txtHROverTimeDate.OldEditValue;
                }
        }

        private void fld_dteHROverTimeDateEnd_Validated(object sender, EventArgs e)
        {
            ((OverTimeModule)Module).UpdateDateTo();
        }

        private void fld_txtHROverTimeToDate_Validated(object sender, EventArgs e)
        {
            if (fld_txtHROverTimeToDate.EditValue != fld_txtHROverTimeToDate.OldEditValue)
                if (!((OverTimeModule)Module).ChangeToTimeOT())
                {
                    fld_txtHROverTimeToDate.EditValue = fld_txtHROverTimeToDate.OldEditValue;
                }
        }

        private void fld_txtHROverTimeFactor_Validated(object sender, EventArgs e)
        {
            ((OverTimeModule)Module).UpdateHREmployeeOTByOTFactor();
        }

        private void fld_lkeFK_ADWorkingShiftID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            VinaLookupEdit lke = (VinaLookupEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                ((OverTimeModule)Module).UpdateHREmployeeOTByWorkingShift(Convert.ToInt32(e.Value));
            }
        }
    }
}