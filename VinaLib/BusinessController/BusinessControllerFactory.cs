using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class BusinessControllerFactory
    {

        public static BaseBusinessController GetBusinessController(string strBusinessControllerName)
        {
            return (BaseBusinessController)(BaseClassFactory.GetClass("VinaERP." + strBusinessControllerName) ?? BaseClassFactory.GetClass("VinaLib." + strBusinessControllerName));
        }

        public static Type GetBusinessControllerType(string strBusinessControllerName)
        {
            return BusinessControllerFactory.GetBusinessController(strBusinessControllerName)?.GetType();
        }
    }
}
