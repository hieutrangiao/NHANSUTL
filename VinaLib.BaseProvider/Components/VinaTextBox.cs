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

namespace VinaLib.BaseProvider
{
    public partial class VinaTextBox : DevExpress.XtraEditors.TextEdit, IVinaControl
    {
        public VinaTextBox()
        {
            InitializeComponent();
            this.Size = new Size(150, 20);
        }

        [Browsable(true)]
        [Category("Vina")]
        public string VinaDataSource { get; set; }
        [Category("Vina")]
        public string VinaDataMember { get; set; }
        [Category("Vina")]
        public string VinaPropertyName { get; set; }

        public VinaScreen Screen { get; set; }

        public void InitializeControl()
        {
            if (!string.IsNullOrEmpty(this.VinaDataSource) && !string.IsNullOrEmpty(this.VinaDataMember))
            {
                this.Screen.BindingDataControl((Control)this);
            }
            //this.Click += new System.EventHandler(((IBaseModuleERP)this.Screen.Module).Control_Click);
            //this.KeyUp += new KeyEventHandler(((IBaseModuleERP)this.Screen.Module).Control_KeyUp);
            //this.Spin += new SpinEventHandler(this.VinaTextBox_Spin);
        }
    }
}