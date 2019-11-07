using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaLib.BaseProvider
{
    public partial class VinaPictureEdit : PictureEdit, IVinaControl
    {
        [Browsable(true)]
        [Category("Vina")]
        public string VinaDataSource { get; set; }

        [Category("Vina")]
        public string VinaDataMember { get; set; }

        [Category("Vina")]
        public string VinaPropertyName { get; set; }

        [Category("Vina")]
        public VinaScreen Screen { get; set; }

        public VinaPictureEdit()
        {
            this.InitializeComponent();
            this.Properties.SizeMode = PictureSizeMode.Zoom;
            this.Properties.PictureStoreMode = PictureStoreMode.ByteArray;
        }

        public void InitializeControl()
        {
            if (!string.IsNullOrEmpty(this.VinaDataSource) && !string.IsNullOrEmpty(this.VinaDataMember))
                this.Screen.BindingDataControl((Control)this);
        }
    }
}
