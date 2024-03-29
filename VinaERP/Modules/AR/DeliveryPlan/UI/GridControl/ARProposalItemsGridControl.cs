﻿using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;

namespace VinaERP.Modules.Proposal
{
    public class ARProposalItemsGridControl : VinaGridControl
    {
        public override void InitGridControlDataSource()
        {
            ProposalEntities entity = (ProposalEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ProposalItemList;
            this.DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["ARProposalItemProductUnitPrice"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARProposalItemDiscountPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ARProposalItemDiscountAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARProposalItemTaxPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ARProposalItemTaxAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARProposalItemTotalAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARProposalItemProductQty"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n0");
            }
            foreach (GridColumn columnedit in gridView.Columns)
            {
                columnedit.OptionsColumn.AllowEdit = true;
            }

            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((ProposalModule)Screen.Module).DeleteItemFromProposalItemList();
            }
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
            ProposalEntities entity = (ProposalEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;
            if (entity.ProposalItemList.CurrentIndex >= 0)
            {
                ((ProposalModule)Screen.Module).ChangeItemFromProposalItemsList();
            }
        }
    }
}
