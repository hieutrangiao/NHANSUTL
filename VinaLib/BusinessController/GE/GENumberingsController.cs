using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class GENumberingsController : BaseBusinessController
    {
        public GENumberingsController()
        {
            dal = new DALBaseProvider("GENumberings", typeof(GENumberingsInfo));
        }
    }
}
