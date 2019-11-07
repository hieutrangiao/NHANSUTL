using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class STToolbarFunctionsController : BaseBusinessController
    {
        public STToolbarFunctionsController()
        {
            dal = new DALBaseProvider("STToolbarFunctions", typeof(STToolbarFunctionsInfo));
        }

        public List<STToolbarFunctionsInfo> GetListFromDataSet(DataSet ds)
        {
            List<STToolbarFunctionsInfo> toolbarFunctions = new List<STToolbarFunctionsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STToolbarFunctionsInfo objToolbarFunctionsInfo = (STToolbarFunctionsInfo)GetObjectFromDataRow(row);
                    toolbarFunctions.Add(objToolbarFunctionsInfo);
                }
            }
            return toolbarFunctions;
        }

        public STToolbarFunctionsInfo GetLastToolbarFunctionByModuleIDAndToolbarTagAndGroup(int CurrentModuleID, string strToolbarTag, string strToolbarGroup)
        {
            return dal.GetDataObject("STToolbarFunctions_GetLastToolbarFunctionByModuleIDAndToolbarTagAndGroup", CurrentModuleID, strToolbarTag, strToolbarGroup) as STToolbarFunctionsInfo;
        }
    }
}
