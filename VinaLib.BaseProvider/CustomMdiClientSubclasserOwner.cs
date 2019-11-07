using DevExpress.Utils.Mdi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaLib
{
    internal class CustomMdiClientSubclasserOwner : IMdiClientSubclasserOwner
    {
        public bool AllowMdiLayout
        {
            get { return true; }
        }
        public bool AllowMdiSystemMenu
        {
            get { return false; }
        }
        public System.Drawing.Rectangle CalculateNC(System.Drawing.Rectangle bounds)
        {
            return bounds;
        }
        public void DrawNC(DevExpress.Utils.Drawing.DXPaintEventArgs e)
        {

        }

        public void EraseBackground(System.Drawing.Graphics g)
        {

        }

        public void HandleCreated()
        {

        }

        public void HandleDestroyed()
        {

        }

        public void InvalidateNC()
        {

        }

        public void OnContextMenu()
        {

        }

        public void OnSetNextMdiChild(DevExpress.XtraTabbedMdi.SetNextMdiChildEventArgs e)
        {

        }

        public void Paint(System.Drawing.Graphics g)
        {

        }
    }

    class CustomMdiClientSubclasser : MdiClientSubclasser
    {
        public CustomMdiClientSubclasser(System.Windows.Forms.MdiClient client, CustomMdiClientSubclasserOwner owner)
            : base(client, owner)
        {
        }

    }
}
