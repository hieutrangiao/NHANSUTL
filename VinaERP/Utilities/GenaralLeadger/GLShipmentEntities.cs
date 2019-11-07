using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;

namespace VinaERP.Utilities.GenaralLeadger
{
    public class GLShipmentEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties

        public VinaList<ICShipmentItemsInfo> ShipmentItemsList { get; set; }

        #endregion

        #region Constructor
        public GLShipmentEntities()
            : base()
        {
            ShipmentItemsList = new VinaList<ICShipmentItemsInfo>();
        }
        #endregion
    }
}
