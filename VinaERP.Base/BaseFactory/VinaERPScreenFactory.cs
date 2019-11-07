using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VinaERP
{
 
    public class VinaERPScreenFactory
    {
        public static VinaERPScreen GetScreen(string strModuleName, string strScreenNumber)
        {
            try
            {
                Type screenType = VinaApp.VinaAssembly.GetType(string.Format("VinaERP.Modules.{0}.UI.{1}", strModuleName, strScreenNumber));
                return (VinaERPScreen)screenType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception)
            {
                return new VinaERPScreen();
            }

        }
    }
}
