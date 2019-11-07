using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib.BaseProvider
{
    public interface IVinaControl
    {
        VinaScreen Screen { get; set; }

        string VinaDataSource { get; set; }

        string VinaDataMember { get; set; }

        string VinaPropertyName { get; set; }

        void InitializeControl();
    }
}
