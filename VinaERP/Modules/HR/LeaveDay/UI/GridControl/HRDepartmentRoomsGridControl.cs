using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaERP.Modules.Department
{
    public partial class HRDepartmentRoomsGridControl : VinaGridControl
    {

        public override void InitGridControlDataSource()
        {
            DepartmentEntities entity = (DepartmentEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.DepartmentRoomsList;
            this.DataSource = bds;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((DepartmentModule)Screen.Module).RemoveSelectedItemFromDepartmentItemList();
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

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);

            DepartmentEntities entity = (DepartmentEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;

            if (entity.DepartmentRoomsList.CurrentIndex >= 0)
            {
                HRDepartmentRoomsInfo item = entity.DepartmentRoomsList[entity.DepartmentRoomsList.CurrentIndex];
                if (e.Column.FieldName == "HRDepartmentRoomWoMenBoundary")
                {
                    item.HRDepartmentRoomBoundary = item.HRDepartmentRoomMenBoundary + item.HRDepartmentRoomWoMenBoundary;
                    ((DepartmentModule)Screen.Module).ChangeDepartmentRoomBoundary();
                }
                if (e.Column.FieldName == "HRDepartmentRoomMenBoundary")
                {
                    item.HRDepartmentRoomBoundary = item.HRDepartmentRoomMenBoundary + item.HRDepartmentRoomWoMenBoundary;
                    ((DepartmentModule)Screen.Module).ChangeDepartmentRoomBoundary();
                }

            }
        }
    }
}
