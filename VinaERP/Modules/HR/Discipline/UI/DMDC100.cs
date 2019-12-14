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


namespace VinaERP.Modules.Discipline.UI
{
    public partial class DMDC100 : VinaERPScreen
    {
        public DMDC100()
        {
            InitializeComponent();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ((DisciplineModule)Module).AddEmployee();
        }

        private void fld_txtHRDisciplineValue_Validated(object sender, EventArgs e)
        {
            ((DisciplineModule)Module).UpdateValue();
        }

        private void fld_dteHRDisciplineFromDate_Validated(object sender, EventArgs e)
        {
            ((DisciplineModule)Module).UpdateItemDate();
        }

        private void fld_txtHRDisciplineType_Validated(object sender, EventArgs e)
        {
            ((DisciplineModule)Module).SetMaskForTextBox();
        }

        private void fld_lkeHRDisciplineOption_Validated(object sender, EventArgs e)
        {
            ((DisciplineModule)Module).SetMaskForTextBox();
        }
    }
}