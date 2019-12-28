using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;

namespace VinaERP.Modules.ManagerTimeKeeper
{
    public partial class HRTimeKeeperCompleteViewsGridControl : VinaGridControl
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;

        public override void InitGridControlDataSource()
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.TimeKeeperCompleteListView;
            this.DataSource = bds;
        }

        public override void InitializeControl()
        {
            base.InitializeControl();


        }
        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column = new GridColumn();
            column.Caption = "Tên nhân viên";
            column.FieldName = "EmployeeName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Thứ";
            column.FieldName = "ThName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Bộ phận";
            column.FieldName = "HRDepartmentRoomName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Tổ";
            column.FieldName = "HRDepartmentRoomGroupItemName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Nhóm chấm công";
            column.FieldName = "HREmployeePayrollFormulaName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Vào/Ra";
            column.FieldName = "HRTimeKeeperCompleteInOutMode";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Xóa dữ liệu";
            column.FieldName = "DiscardItem";
            RepositoryItemHyperLinkEdit rep = new RepositoryItemHyperLinkEdit();
            rep.NullText = "Hủy";
            rep.LinkColor = Color.Blue;
            rep.Click += new EventHandler(rep_Click);
            column.ColumnEdit = rep;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column = gridView.Columns["HRTimeKeeperCompletesEmployeeCardNo"];
            if (column != null)
            {
                column.Group();
            }

            column = new GridColumn();
            column = gridView.Columns["HRTimeKeeperCompleteDate"];
            if (column != null)
            {
                column.Group();
            }

            column = new GridColumn();
            column.Caption = "Ca làm việc";
            column.FieldName = "FK_ADWorkingShiftID";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = gridView.Columns["FK_ADWorkingShiftID"];
            if (column != null)
            {
                column.Group();
            }
        }

        void rep_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)MainView;
            HRTimeKeeperCompletesController objTimeKeepersController = new HRTimeKeeperCompletesController();
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            if (gridView.FocusedRowHandle >= 0)
            {
                HRTimeKeeperCompletesInfo item = (HRTimeKeeperCompletesInfo)gridView.GetRow(gridView.FocusedRowHandle);
                entity.SaveHistory("HRTimeKeeperCompletes", item, item, "Cancel");
                gridView.DeleteRow(gridView.FocusedRowHandle);
                //objTimeKeepersController.DeleteObject(item.HRTimeKeeperCompleteID);
                entity.TimeKeeperCompleteListView.Remove(item);
            }
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            // repositoryItemDateEdit
            repositoryItemDateEdit.AutoHeight = false;
            repositoryItemDateEdit.DisplayFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.Mask.EditMask = "HH:mm:ss";
            repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit.Name = "repositoryItemDateEdit1";
            GridColumn column = gridView.Columns["HRTimeKeeperCompleteTimeCheck"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }
            column = gridView.Columns["HRTimeKeeperCompleteInOutMode"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                //column.ColumnEdit = repositoryItemDateEdit;
            }
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            gridView.RowStyle += new RowStyleEventHandler(gridView_RowStyle);
            gridView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);
            return gridView;
        }

        private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "FK_ADWorkingShiftID")
            {
                if (e.Value != null)
                {
                    int id = int.Parse(e.Value.ToString());
                    ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
                    ADWorkingShiftsInfo objWorkingShiftsInfo = (ADWorkingShiftsInfo)objWorkingShiftsController.GetObjectByID(id);
                    if (objWorkingShiftsInfo != null)
                    {
                        e.DisplayText = objWorkingShiftsInfo.ADWorkingShiftName;
                    }
                }
            }
        }

        void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            GridView view = sender as GridView;
            GridView gridView = (GridView)MainView;
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle == gridView.FocusedRowHandle)
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }

    }
}
