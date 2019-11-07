using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP
{
    public class ICProductsController : BaseBusinessController
    {
        public ICProductsController()
        {
            dal = new DALBaseProvider("ICProducts", typeof(ICProductsInfo));
        }

        public List<ICProductsInfo> GetListFromDataSet(DataSet ds)
        {
            List<ICProductsInfo> stockList = new List<ICProductsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ICProductsInfo objStocksInfo = (ICProductsInfo)GetObjectFromDataRow(row);
                    stockList.Add(objStocksInfo);
                }
            }
            return stockList;
        }

    }
}
