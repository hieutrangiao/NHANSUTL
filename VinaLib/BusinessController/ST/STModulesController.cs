using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class STModulesController : BaseBusinessController
    {
        public STModulesController()
        {
            dal = new DALBaseProvider("STModules", typeof(STModulesInfo));
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<STModulesInfo> moduleList = new List<STModulesInfo>();
            STModulesInfo objModulesInfo = new STModulesInfo();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    objModulesInfo = (STModulesInfo)GetObjectFromDataRow(row);
                    moduleList.Add(objModulesInfo);
                }
            }
            return moduleList;
        }

        public List<STModulesInfo> GetAllModulesByUserName(string username)
        {
            DataSet ds = dal.GetDataSet("STModules_GetAllModulesByUserName", username);
            return (List<STModulesInfo>)GetListFromDataSet(ds);
        }

    }
}
