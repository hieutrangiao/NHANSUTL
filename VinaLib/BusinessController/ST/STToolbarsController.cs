using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class STToolbarsController : BaseBusinessController
    {
        public STToolbarsController()
        {
            dal = new DALBaseProvider("STToolbarsInfo", typeof(STToolbarsInfo));
        }

        public List<STToolbarsInfo> GetAllToolbarByModuleID(int moduleID, int userGroupID)
        {
            List<STToolbarsInfo> toolbarsList = new List<STToolbarsInfo>();
            DataSet ds = dal.GetDataSet("STToolbars_GetAllToolbarByModuleID", moduleID, userGroupID);
            return (List<STToolbarsInfo>)GetListFromDataSet(ds);
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<STToolbarsInfo> toolbars = new List<STToolbarsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STToolbarsInfo objToolbarsInfo = (STToolbarsInfo)GetObjectFromDataRow(row);
                    toolbars.Add(objToolbarsInfo);
                }
            }
            return toolbars;
        }
    }
}
