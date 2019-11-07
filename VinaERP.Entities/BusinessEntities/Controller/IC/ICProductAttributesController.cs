using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP
{
  
    public class ICProductAttributesController : BaseBusinessController
    {
        public ICProductAttributesController()
        {
            dal = new DALBaseProvider("ICProductAttributes", typeof(ICProductAttributesInfo));
        }

        public List<ICProductAttributesInfo> GetListFromDataSet(DataSet ds)
        {
            List<ICProductAttributesInfo> productAttributes = new List<ICProductAttributesInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ICProductAttributesInfo objProductAttributesInfo = (ICProductAttributesInfo)GetObjectFromDataRow(row);
                    productAttributes.Add(objProductAttributesInfo);
                }
            }
            return productAttributes;
        }

        public List<ICProductAttributesInfo> GetProductAttributeByGroup(string strProductAttributeGroup)
        {
            DataSet ds = dal.GetDataSet("ICProductAttributes_GetProductAttributeByGroup", strProductAttributeGroup);
            return GetListFromDataSet(ds);
        }

        public List<ICProductAttributesInfo> GetAllProductAttribute()
        {
            DataSet ds = GetAllObjects();
            return GetListFromDataSet(ds);
        }
    }
}
