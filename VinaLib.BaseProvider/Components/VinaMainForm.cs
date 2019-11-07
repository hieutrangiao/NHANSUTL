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
    public partial class VinaMainForm : DevExpress.XtraEditors.XtraForm
    {
        #region Constant for Control type
        private CustomMdiClientSubclasser MdiSubclasser;

        public const int cstAutoScrollMinSizeWidth = 1280;

        public const int cstAutoScrollMinSizeHeight = 720;

        #endregion

        public VinaMainForm()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            try
            {
                MdiSubclasser = new CustomMdiClientSubclasser(GetMdiClient(this), new CustomMdiClientSubclasserOwner());
            }
            catch (Exception){ }
        }

        private MdiClient GetMdiClient(Form frm)
        {
            if (frm == null)
                return null;
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is MdiClient)
                    return (MdiClient)ctrl;
            }
            return null;
        }
    }
}