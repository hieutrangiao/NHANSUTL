using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class AAColumnAliasController : BaseBusinessController
    {
        public AAColumnAliasController()
        {
            dal = new DALBaseProvider("AAColumnAlias", typeof(AAColumnAliasInfo));
        }

        public  List<AAColumnAliasInfo> GetListFromDataSet(DataSet ds)
        {
            List<AAColumnAliasInfo> columnAliasList = new List<AAColumnAliasInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    AAColumnAliasInfo objColumnAliasInfo = (AAColumnAliasInfo)GetObjectFromDataRow(row);
                    columnAliasList.Add(objColumnAliasInfo);
                }
            }
            return columnAliasList;
        }

        public List<AAColumnAliasInfo> GetColumnAliasByTableName(string tableName)
        {
            DataSet ds = dal.GetDataSet("AAColumnAlias_GetColumnAliasByTableName", tableName);
            return GetListFromDataSet(ds);
        }
    }
}
