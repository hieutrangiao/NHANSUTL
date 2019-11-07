using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public interface IBaseModuleERP
    {
        SortedList GetLookupTableCollection();

        SortedList<string, GELookupTablesInfo> GetLookupTableObjects();

        DataSet GetLookupTableData(string lookupTableName);
    }
}
