using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaLib
{
    public partial class VinaScreen : DevExpress.XtraEditors.XtraForm
    {
        #region Constant for Control type

        public const string cstBindingPropertyName = "VinaPropertyName";
        public const string cstDataMemberPropertyName = "VinaDataMember";
        public const string cstDataSourcePropertyName = "VinaDataSource";
        public const string DataControl = "DC";
        public const string SearchControl = "SC";
        public const string SearchResultControl = "SR";
        public const string SearchInfo = "SI";
        public const int cstAutoScrollMinSizeWidth = 1280;
        public const int cstAutoScrollMinSizeHeight = 720;
        public int ScreenID { get; set; }

        public string ScreenCode { get; set; }

        public string ScreenName { get; set; }

        #endregion

        public BaseModule Module { get; set; }

        public VinaScreen()
        {
            InitializeComponent();
        }

        public virtual void BindingDataControl(Control ctrl)
        {
        }

        public bool IsDataMainScreen()
        {
            bool flag = false;
            if (this.ScreenCode.StartsWith("DM"))
                flag = true;
            return flag;
        }
    }
}