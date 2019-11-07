using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class STScreensController : BaseBusinessController
    {
        public STScreensController()
        {
            dal = new DALBaseProvider("STScreens", typeof(STScreensInfo));
        }

    }
}
