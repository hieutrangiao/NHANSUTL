using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaERP.Modules.CompanyConstant
{
    public partial class RewardTypesGridControl : VinaGridControl
    {

        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.RewardTypesList;
            this.DataSource = bds;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedItemFromRewardTypesList();
            }
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            foreach (GridColumn columnedit in gridView.Columns)
            {
                columnedit.OptionsColumn.AllowEdit = true;
            }

            return gridView;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = "Loại khen thưởng";
            column.FieldName = "ADConfigText";
            column.OptionsColumn.AllowEdit = true;
            column.Visible = true;
            gridView.Columns.Add(column);
        }
    }
}
