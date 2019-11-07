using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;

namespace VinaERP.Utilities.GenaralLeadger
{
    public class GLReceiptEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties

        public VinaList<ICReceiptItemsInfo> ReceiptItemsList { get; set; }

        #endregion

        #region Constructor
        public GLReceiptEntities()
            : base()
        {
            ReceiptItemsList = new VinaList<ICReceiptItemsInfo>();
        }
        #endregion
    }
}
