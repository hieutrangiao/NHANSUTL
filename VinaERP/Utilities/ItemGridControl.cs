using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP.Utilities
{
    public class ItemGridControl : VinaGridControl
    {
        private string SerieColumnName = string.Empty;

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            return base.InitializeGridView();
        }
    }
}
