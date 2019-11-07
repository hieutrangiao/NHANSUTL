using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaLib
{
    public class BaseClassFactory
    {
        public static object GetClass(string strClassName)
        {
            return BaseClassFactory.GetClassType(strClassName)?.InvokeMember("", BindingFlags.CreateInstance, (Binder)null, (object)null, (object[])null);
        }

        public static System.Type GetClassType(string strClassName)
        {
            return (((BaseClassFactory.GetClassTypeFromAssembly("VinaERP.exe", strClassName) ?? BaseClassFactory.GetClassTypeFromAssembly("VinaLib.BaseProvider.dll", strClassName)) ?? BaseClassFactory.GetClassTypeFromAssembly("VinaERP.Entities.dll", strClassName)) ?? BaseClassFactory.GetClassTypeFromAssembly("VinaERP.Base.dll", strClassName)) ?? BaseClassFactory.GetClassTypeFromAssembly("VinaLib.dll", strClassName);
        }

        private static System.Type GetClassTypeFromAssembly(string assemblyName, string className)
        {
            System.Type type = (System.Type)null;
            try
            {
                type = Assembly.LoadFrom(Application.StartupPath + "\\" + assemblyName).GetType(className);
            }
            catch (Exception ex)
            {
            }
            return type;
        }
    }
}
