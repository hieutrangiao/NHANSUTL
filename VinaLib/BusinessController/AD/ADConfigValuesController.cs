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

        public ADConfigValuesInfo GetObjectByConfigKey(String configKey)
        {
            String sql = String.Format("SELECT * FROM ADConfigValues WHERE AAStatus = 'Alive' AND ADConfigKey = N'{0}'", configKey);
            DataSet ds = dal.GetDataSet(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ADConfigValuesInfo objConfigValuesInfo = (ADConfigValuesInfo)dal.GetObjectFromDataRow(ds.Tables[0].Rows[0]);
                ds.Dispose();
                return objConfigValuesInfo;
            }
            return null;
        }

        public object GetValueByConfigKey(string configKey)
        {
            ADConfigValuesInfo configValue = GetObjectByConfigKey(configKey);
            if (configKey != null)
            {
                return configValue.ADConfigKeyValue;
            }
            return null;
        }

        public ADConfigValuesInfo GetObjectByGroupAndValue(string group, string value)
        {
            DataSet ds = dal.GetDataSet("ADConfigValues_GetObjectByGroupAndValue", group, value);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ADConfigValuesInfo objConfigValuesInfo = (ADConfigValuesInfo)dal.GetObjectFromDataRow(ds.Tables[0].Rows[0]);
                ds.Dispose();
                return objConfigValuesInfo;
            }
            return null;
        }
    }
}
