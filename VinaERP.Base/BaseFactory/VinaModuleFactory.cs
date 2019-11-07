using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaERP
{
    public class VinaModuleFactory
    {
        public static BaseModuleERP GetModule(String strModuleName)
        {
            try
            {
                Type moduleType = VinaApp.VinaAssembly.GetType("VinaERP.Modules." + strModuleName + "." + strModuleName + "Module");
                return (BaseModuleERP)moduleType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
