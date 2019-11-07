using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP
{
    public class ICDepartmentsController : BaseBusinessController
    {
        public ICDepartmentsController()
        {
            dal = new DALBaseProvider("ICDepartments", typeof(ICDepartmentsInfo));
        }

    }
}
