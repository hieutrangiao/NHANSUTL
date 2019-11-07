using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class BusinessObjectFactory
    {
        public static BusinessObject GetBusinessObject(string strBusinessObjectName)
        {
            return (BusinessObject)(BaseClassFactory.GetClass("VinaERP." + strBusinessObjectName) ?? BaseClassFactory.GetClass("VinaLib." + strBusinessObjectName));
        }

        public static Type GetBusinessObjectType(string strBusinessObjectName)
        {
            return BusinessObjectFactory.GetBusinessObject(strBusinessObjectName)?.GetType();
        }
    }
}
