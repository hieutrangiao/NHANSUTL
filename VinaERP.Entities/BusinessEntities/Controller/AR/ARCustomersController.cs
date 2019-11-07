using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP
{
    public class ARCustomersController : BaseBusinessController
    {
        public ARCustomersController()
        {
            dal = new DALBaseProvider("ARCustomers", typeof(ARCustomersInfo));
        }

    }
}
