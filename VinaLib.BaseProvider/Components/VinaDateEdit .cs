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
    public partial class VinaDateEdit : DevExpress.XtraEditors.DateEdit, IVinaControl
    {
        [Browsable(true)]
        [Category("Vina")]
        public string VinaDataSource { get; set; }
        [Category("Vina")]
        public string VinaDataMember { get; set; }
        [Category("Vina")]
        public string VinaPropertyName { get; set; }

        public VinaScreen Screen { get; set; }

        public VinaDateEdit()
        {
            this.Size = new Size(150, 20);
        }

        public void InitializeControl()
        {
            if (!string.IsNullOrEmpty(this.VinaDataSource) && !string.IsNullOrEmpty(this.VinaDataMember))
                this.Screen.BindingDataControl((Control)this);
            if ((this.Name.Contains("SearchFrom") || this.Name.Contains("SearchTo")) && (this.Tag != null && this.Tag.ToString() == "SC"))
            {
                if (this.Name.Contains("SearchFrom"))
                    this.EditValue = (object)(new DateTime(DateTime.Now.Year, 1, 1));
                else if (this.Name.Contains("SearchTo"))
                    this.EditValue = (object)(new DateTime(DateTime.Now.Year, 12, 31));
            }
            this.Properties.NullDate = (object)DateTime.MaxValue;
            //this.Click += new System.EventHandler(((IBaseModuleERP)this.Screen.Module).Control_Click);
            //this.KeyUp += new KeyEventHandler(((IBaseModuleERP)this.Screen.Module).Control_KeyUp);
            //this.Spin += new SpinEventHandler(this.VinaDateEdit_Spin);
        }
    }
}