using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace VinaLib
{

    public class ADConfigValuesController : BaseBusinessController
    {
        public ADConfigValuesController()
        {
            dal = new DALBaseProvider("ADConfigValues", typeof(ADConfigValuesInfo));
        }

        public DataSet GetADConfigValuesByGroup(String strADConfigKeyGroup)
        {
            return dal.GetDataSet("ADConfigValues_SelectByADConfigKeyGroup", strADConfigKeyGroup);
        }
    }
}
