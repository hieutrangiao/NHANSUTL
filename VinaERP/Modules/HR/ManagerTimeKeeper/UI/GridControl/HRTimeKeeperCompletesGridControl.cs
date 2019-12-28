using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaERP.Modules.ManagerTimeKeeper;

namespace VinaERP.Modules.ManagerTimeKeeper
{
    public partial class HRTimeKeeperCompletesGridControl : VinaGridControl
    {
        public override void InitGridControlDataSource()
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.TimeKeeperCompletesList;
            this.DataSource = bds;
        }

        ContextMenu menu = new ContextMenu();
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        public override void InitializeControl()
        {
            base.InitializeControl();
            MenuItem item = new MenuItem();
            item.Text = "Nhân đôi dòng";
            item.Click += new EventHandler(item_Click);
            menu.MenuItems.Add(item);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            GridView view = (GridView)this.DefaultView;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info != null && (info.HitTest == GridHitTest.RowCell || info.HitTest == GridHitTest.RowIndicator)
                && e.Button == MouseButtons.Right)
            {
                menu.Show(this, pt);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            GridView view = (GridView)this.DefaultView;
            int index = view.GetDataSourceRowIndex(view.FocusedRowHandle);
            if (index >= 0)
            {
                List<HRTimeKeeperCompletesInfo> timeKeeperCompleteList = (List<HRTimeKeeperCompletesInfo>)this.DataSource;
                HRTimeKeeperCompletesInfo obj = (HRTimeKeeperCompletesInfo)timeKeeperCompleteList[index].Clone();
                timeKeeperCompleteList.Insert(index, obj);
                this.RefreshDataSource();
            }
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column = new GridColumn();
            column.Caption = "Tên nhân viên";
            column.FieldName = "EmployeeName";
            column.OptionsColumn.AllowEdit = false;
            column.Group();
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Thứ";
            column.FieldName = "ThName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Vào/Ra";
            column.FieldName = "HRTimeKeeperCompleteInOutMode";
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column = gridView.Columns["HRTimeKeeperCompleteTimeCheck"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
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
            column = gridView.Columns["HRTimeKeeperCompleteDateCheck"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = new GridColumn();
            column = gridView.Columns["HRTimeKeeperCompleteComment"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = new GridColumn();
            column = gridView.Columns["FK_HRDepartmentID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
            }
            column = new GridColumn();
            column = gridView.Columns["FK_HRLevelID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
            }

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
            column.Caption = "Trùng giờ";
            column.FieldName = "SameDateTime";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            // repositoryItemDateEdit
            repositoryItemDateEdit.AutoHeight = false;
            repositoryItemDateEdit.DisplayFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.Mask.EditMask = "HH:mm:ss";
            repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit.Name = "repositoryItemDateEdit1";

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
            column.Caption = "Mã màu";
            column.FieldName = "RowColor";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }

        private void gridView1_ShowFilterPopupListBox(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs e)
        {
            if (e.Column.FieldName == "RowColor")
                e.ComboBox.DrawItem += ComboBox_DrawItem;
        }

        public void ComboBox_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
            try
            {
                int argb = Convert.ToInt32((e.Item as DevExpress.XtraGrid.Views.Grid.FilterItem).Value);
                Color clr = Color.FromArgb(argb);
                e.Graphics.FillRectangle(new SolidBrush(clr), e.Bounds);
                e.Handled = true;
            }
            catch { }
        }

        void rep_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)MainView;
            HRTimeKeepersController objTimeKeepersController = new HRTimeKeepersController();
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            if (gridView.FocusedRowHandle >= 0)
            {
                HRTimeKeeperCompletesInfo item = (HRTimeKeeperCompletesInfo)gridView.GetRow(gridView.FocusedRowHandle);
                entity.SaveHistory("HRTimeKeeperCompletes", item, item, "Cancel");
                gridView.DeleteRow(gridView.FocusedRowHandle);
            }
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
        }
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView.ShowFilterPopupListBox += new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(this.gridView1_ShowFilterPopupListBox);
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
            }
            column = gridView.Columns["HRTimeKeeperCompleteDate"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gridView_InvalidRowException);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            gridView.RowStyle += new RowStyleEventHandler(gridView_RowStyle);
            gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_CellValueChanged);
            return gridView;
        }

        void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            GridView gridView = (GridView)MainView;
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            if (e.RowHandle >= 0)
            {
                HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo = (HRTimeKeeperCompletesInfo)gridView.GetRow(e.RowHandle);
                ((ManagerTimeKeeperModule)Screen.Module).AddBackupList(objTimeKeeperCompletesInfo);

                if (e.Column.FieldName == "HRTimeKeeperCompleteTimeCheck")
                {
                    //1.CheckSameTime
                    ((ManagerTimeKeeperModule)Screen.Module).CheckSameTime(objTimeKeeperCompletesInfo, entity.TimeKeeperCompletesList.ToList());
                    //2.CheckNotInOverTime
                    ((ManagerTimeKeeperModule)Screen.Module).CheckNotInOverTime(objTimeKeeperCompletesInfo, 60, true);
                    //2.CheckNotInOverTime
                    ((ManagerTimeKeeperModule)Screen.Module).CheckOverTimeAbsence(objTimeKeeperCompletesInfo, 60, true);
                }
                if (e.Column.FieldName == "HRTimeKeeperCompleteDate")
                {
                    ((ManagerTimeKeeperModule)Screen.Module).ChangeCompleteDate(objTimeKeeperCompletesInfo);
                }
            }
        }

        void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            GridView gridView = (GridView)MainView;
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle == gridView.FocusedRowHandle)
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }


                HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo = (HRTimeKeeperCompletesInfo)gridView.GetRow(e.RowHandle);
                if (objTimeKeeperCompletesInfo != null)
                {
                    bool isSameTime = ((ManagerTimeKeeperModule)Screen.Module).CheckSameTime(objTimeKeeperCompletesInfo, entity.TimeKeeperCompletesList.ToList());
                    if (isSameTime)
                    {
                        e.Appearance.BackColor2 = Color.Pink;
                        e.Appearance.BackColor = Color.Pink;
                        objTimeKeeperCompletesInfo.RowColor = Color.Pink.ToArgb();
                    }

                    if (objTimeKeeperCompletesInfo.NotInOverTime == "False")
                    {
                        e.Appearance.BackColor2 = Color.Orange;
                        e.Appearance.BackColor = Color.Orange;
                        objTimeKeeperCompletesInfo.RowColor = Color.Orange.ToArgb();
                    }
                    if (objTimeKeeperCompletesInfo.OverTimeAbsence == "False")
                    {
                        e.Appearance.BackColor2 = Color.Green;
                        e.Appearance.BackColor = Color.Green;
                        objTimeKeeperCompletesInfo.RowColor = Color.Green.ToArgb();
                    }
                    if (objTimeKeeperCompletesInfo.NotInWorkingShift == "False")
                    {
                        e.Appearance.BackColor2 = Color.Blue;
                        e.Appearance.BackColor = Color.Blue;
                        objTimeKeeperCompletesInfo.RowColor = Color.Blue.ToArgb();
                    }
                    if (objTimeKeeperCompletesInfo.LateForWork == "False")
                    {
                        e.Appearance.BackColor2 = Color.Orange;
                        e.Appearance.BackColor = Color.Orange;
                        objTimeKeeperCompletesInfo.RowColor = Color.Orange.ToArgb();
                    }
                    if (objTimeKeeperCompletesInfo.GoEarly == "False")
                    {
                        e.Appearance.BackColor2 = Color.Yellow;
                        e.Appearance.BackColor = Color.Yellow;
                        objTimeKeeperCompletesInfo.RowColor = Color.Yellow.ToArgb();
                    }
                }

            }
        }

        void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
