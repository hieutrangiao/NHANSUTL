using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP
{
    public class ARSaleOrdersController : BaseBusinessController
    {
        public ARSaleOrdersController()
        {
            dal = new DALBaseProvider("ARSaleOrders", typeof(ARSaleOrdersInfo));
        }

    }
}
