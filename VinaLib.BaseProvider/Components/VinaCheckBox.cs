using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaLib.BaseProvider
{
    public partial class VinaCheckBox : CheckEdit, IVinaControl
    {
        [Browsable(true)]
        [Category("Vina")]
        public string VinaDataSource { get; set; }
        [Category("Vina")]
        public string VinaDataMember { get; set; }
        [Category("Vina")]
        public string VinaPropertyName { get; set; }

        public VinaScreen Screen { get; set; }

        public VinaCheckBox()
        {
            this.InitializeComponent();
            VinaPropertyName = "EditValue";
        }

        public void InitializeControl()
        {
            if (!string.IsNullOrEmpty(this.VinaDataSource) && !string.IsNullOrEmpty(this.VinaDataMember))
                this.Screen.BindingDataControl((Control)this);
        }
    }
}
