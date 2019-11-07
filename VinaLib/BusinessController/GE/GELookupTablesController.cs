using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class GELookupTablesController : BaseBusinessController
    {
        public GELookupTablesController()
        {
            this.dal = new DALBaseProvider("GELookupTables", typeof(GELookupTablesInfo));
        }

        public GELookupTablesInfo GetObjectByTableName(string tableName)
        {
            DataSet dataSet = this.GetDataSet(string.Format("SELECT * FROM GELookupTables WHERE AAStatus = 'Alive' AND GELookupTableName = '{0}'", (object)tableName));
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                return (GELookupTablesInfo)this.GetObjectFromDataRow(dataSet.Tables[0].Rows[0]);
            return (GELookupTablesInfo)null;
        }
    }
}
