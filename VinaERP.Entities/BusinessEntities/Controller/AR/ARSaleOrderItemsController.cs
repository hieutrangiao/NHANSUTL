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

    public class ARSaleOrderItemsController : BaseBusinessController
    {
        public ARSaleOrderItemsController()
        {
            dal = new DALBaseProvider("ARSaleOrderItems", typeof(ARSaleOrderItemsInfo));
        }

        public List<ARSaleOrderItemsInfo> GetSaleOrderItemForSaleOrderShipment()
        {
            DataSet ds = dal.GetDataSet("ARSaleOrderItems_GetSaleOrderItemForSaleOrderShipment");
            return (List<ARSaleOrderItemsInfo>)GetListFromDataSet(ds);
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<ARSaleOrderItemsInfo> saleOrderList = new List<ARSaleOrderItemsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ARSaleOrderItemsInfo objSaleOrderItemsInfo = (ARSaleOrderItemsInfo)GetObjectFromDataRow(row);
                    saleOrderList.Add(objSaleOrderItemsInfo);
                }
            }
            return saleOrderList;
        }

        public List<ARSaleOrderItemsInfo> GetItemForSaleOrderReport(int saleOrderID)
        {
            DataSet ds = dal.GetDataSet("ARSaleOrderItems_GetItemForSaleOrderReport", saleOrderID);
            return (List<ARSaleOrderItemsInfo>)GetListFromDataSet(ds);
        }
    }
}
