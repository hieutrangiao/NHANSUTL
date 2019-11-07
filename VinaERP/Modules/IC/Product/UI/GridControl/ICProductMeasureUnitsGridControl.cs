using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace VinaERP.Modules.Product
{
    public class ICProductMeasureUnitsGridControl : VinaGridControl
    {
        public override void InitGridControlDataSource()
        {
            ProductEntities entity = (ProductEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ProductMeasureUnitList;
            this.DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            foreach(GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            GridColumn gridColumn = gridView.Columns["ICProductMeasureUnitFactor"];
            if(gridColumn != null)
            {
                FormatNumbericColumn(gridColumn,true, "n3");
            }
            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                //((ProductModule)Screen.Module).DeleteItemFromICProductMeasureUnitList();
            }
        }

        //protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler e)
        //{
        //    base.GridView_CellValueChanged(sender, e);
        //    ProductEntities entity = (ProductEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;
        //    if (entity.ProductMeasureUnitList.CurrentIndex >= 0)
        //    {
        //        //((ProductModule)Screen.Module).ChangeItemFromICProductMeasureUnitsList();
        //    }
        //}
    }
}
