using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP
{
    public class ICMeasureUnitsController : BaseBusinessController
    {
        public ICMeasureUnitsController()
        {
            dal = new DALBaseProvider("ICMeasureUnits", typeof(ICMeasureUnitsInfo));
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<ICMeasureUnitsInfo> measureUnits = new List<ICMeasureUnitsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ICMeasureUnitsInfo objMeasureUnitsInfo = (ICMeasureUnitsInfo)GetObjectFromDataRow(row);
                    measureUnits.Add(objMeasureUnitsInfo);
                }
            }
            return measureUnits;
        }

        public List<ICMeasureUnitsInfo> GetMeasureUnitByProductID(int productID)
        {
            DataSet ds = dal.GetDataSet("ICMeasureUnits_GetMeasureUnitByProductID", productID);
            return (List<ICMeasureUnitsInfo>)GetListFromDataSet(ds);
        }
    }
}
