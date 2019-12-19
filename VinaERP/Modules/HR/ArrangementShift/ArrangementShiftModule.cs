using BOSERP.Modules.ArrangementShift;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.ArrangementShift
{

    public class ArrangementShiftModule : BaseModuleERP
    {
        #region Constant
        public const string ArrangementShiftTypeLookupEditName = "fld_lkeHRArrangementShiftType";
        public const string ArrangementShiftValueTextBoxName = "fld_txtHRArrangementShiftValue";

        public object HRArrangementShiftModule { get; private set; }
        #endregion
        public ArrangementShiftModule()
        {
            CurrentModuleName = "ArrangementShift";
            CurrentModuleEntity = new ArrangementShiftEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            return base.ActionSave();

        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            HRDepartmentsController objDepartmentsController = new HRDepartmentsController();
            HRDepartmentRoomsController objDepartmentRoomsController = new HRDepartmentRoomsController();
            HREmployeesController objEmployeesController = new HREmployeesController();
            foreach (var objEmployeeArrangementShiftsInfo in entity.EmployeeArrangementShiftsList)
            {
                HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(objEmployeeArrangementShiftsInfo.FK_HREmployeeID);
                HRDepartmentsInfo objDepartmentsInfo = (HRDepartmentsInfo)objDepartmentsController.GetObjectByID(objEmployeesInfo.FK_HRDepartmentID);
                if (objDepartmentsInfo != null)
                {
                    objEmployeeArrangementShiftsInfo.HRDepartmentName = objDepartmentsInfo.HRDepartmentName;
                }
                HRDepartmentRoomsInfo objDepartmentRoomsInfo = (HRDepartmentRoomsInfo)objDepartmentRoomsController.GetObjectByID(objEmployeesInfo.FK_HRDepartmentRoomID);
                if (objDepartmentRoomsInfo != null)
                {
                    objEmployeeArrangementShiftsInfo.HRDepartmentRoomName = objDepartmentRoomsInfo.HRDepartmentRoomName;
                }
            }
            InitializeArrangementShiftEntryGridControl();
        }

        public void InitializeArrangementShiftEntryGridControl()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            HRArrangementShiftsInfo objArrangementShiftsInfo = (HRArrangementShiftsInfo)entity.MainObject;
            HREmployeeArrangementShiftsGridControl gridControl = (HREmployeeArrangementShiftsGridControl)Controls["fld_dgcHREmployeeArrangementShifts"];
            gridControl.InitializeControl();
            InitColumnRepository();
        }

        public void InitColumnRepository()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            VinaGridControl employeeArrangementShiftsGridControl = (VinaGridControl)Controls["fld_dgcHREmployeeArrangementShifts"];
            RepositoryItemCheckedComboBoxEdit reposItemCheckedCombo = new RepositoryItemCheckedComboBoxEdit();

            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            List<ADWorkingShiftsInfo> mainParams = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());

            reposItemCheckedCombo.DataSource = mainParams;

            reposItemCheckedCombo.DisplayMember = "ADWorkingShiftName";
            reposItemCheckedCombo.ValueMember = "ADWorkingShiftName";
            employeeArrangementShiftsGridControl.RepositoryItems.Add(reposItemCheckedCombo);
            GridView gridView = (GridView)employeeArrangementShiftsGridControl.MainView;
            for (int i = 4; i < gridView.Columns.Count; i++)
            {
                gridView.Columns[i].ColumnEdit = reposItemCheckedCombo;
            }
            reposItemCheckedCombo.EditValueChanged += new EventHandler(ReposItemCheckedCombo_EditValueChanged);
        }

        private void ReposItemCheckedCombo_EditValueChanged(object sender, EventArgs e)
        {
            CheckedComboBoxEdit checkCombo = (CheckedComboBoxEdit)sender;
            string value = checkCombo.EditValue.ToString();
            string comboText = String.Empty;
            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            string[] arrayValue = value.Split(',');
            for (int i = 0; i < arrayValue.Length; i++)
            {
                if (arrayValue[i].Trim() != String.Empty)
                {
                    comboText += String.Format("{0}, ", arrayValue[i].Trim());
                }
            }
            if (comboText.Length > 2)
            {
                checkCombo.Text = comboText.Substring(0, comboText.Length - 2);
            }
            else if (comboText.Length <= 2)
            {
                checkCombo.Text = "";
            }
        }

        public void RemoveSelectedItemFromArrangementShiftItemList()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            entity.EmployeeArrangementShiftsList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;

            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeeArrangementShiftsList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    HREmployeeArrangementShiftsInfo objEmployeeArrangementShiftsInfo = SetEmployeeArrangementShiftsInfoFromEmployee(objEmployeesInfo);
                    AddDefaulArrangementShiftEntries(objEmployeeArrangementShiftsInfo, objEmployeesInfo);
                    List<HRArrangementShiftEntrysInfo> arrangementShiftEntrys = objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList.Where(o => o.FK_HREmployeeID == objEmployeeArrangementShiftsInfo.FK_HREmployeeID).ToList();
                    objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList = arrangementShiftEntrys;
                    entity.SetEmployeeArrangementShiftValue(objEmployeeArrangementShiftsInfo);
                    entity.EmployeeArrangementShiftsList.Add(objEmployeeArrangementShiftsInfo);
                }
                entity.EmployeeArrangementShiftsList.GridControl.RefreshDataSource();
            }
        }

        public int NumOfDayInMonth()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            HRArrangementShiftsInfo objArrangementShiftsInfo = (HRArrangementShiftsInfo)entity.MainObject;
            int numDays = (int)(objArrangementShiftsInfo.HRArrangementShiftToDate.Date - objArrangementShiftsInfo.HRArrangementShiftFromDate.Date).TotalDays + 1;
            return numDays;
        }

        public List<string> GetColumnFieldNameByTypeEndOfWeek()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            HRArrangementShiftsInfo objArrangementShiftsInfo = (HRArrangementShiftsInfo)entity.MainObject;
            List<string> list = new List<string>();
            int numDays = NumOfDayInMonth();
            for (int i = 1; i <= numDays; i++)
            {
                DateTime dt = objArrangementShiftsInfo.HRArrangementShiftFromDate.Date.AddDays(i - 1);
                bool isDayOfWeek = (VinaApp.IsEndOfWeek(objArrangementShiftsInfo.HRArrangementShiftFromDate.Date.AddDays(i - 1).DayOfWeek));
                if (isDayOfWeek)
                {
                    string columnName = String.Format("{0}{1}", "HREmployeeArrangementShiftDate", i.ToString());
                    list.Add(columnName);
                }
            }
            return list;
        }

        public void RemoveEmployeeFromArrangementShiftList()
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            BandedGridView bandedView = (BandedGridView)entity.EmployeeArrangementShiftsList.GridControl.MainView;
            if (bandedView.FocusedRowHandle >= 0)
            {
                int index = bandedView.GetDataSourceRowIndex(bandedView.FocusedRowHandle);
                entity.EmployeeArrangementShiftsList.RemoveAt(index);
                bandedView.RefreshData();
            }
        }

        public void UpdateArrangementShift(HREmployeeArrangementShiftsInfo objEmployeeArrangementShiftsInfo)
        {
            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            HRArrangementShiftsInfo objArrangementShiftsInfo = (HRArrangementShiftsInfo)entity.MainObject;
            List<string> employeeArrangementShiftValueList = new List<string> {   objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate1, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate2,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate3, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate4,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate5, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate6,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate7, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate8,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate9, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate10,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate11, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate12,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate13, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate14,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate15, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate16,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate17, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate18,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate19, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate20,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate21, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate22,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate23, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate24,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate25, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate26,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate27, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate28,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate29, objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate30,
                                                                        objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftDate31
                                                                         };
            objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList.ForEach(o => o.FK_HRArrangementShiftID = 0);
            objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList.Clear();
            int numDays = NumOfDayInMonth();
            for (int i = 0; i < numDays; i++)
            {
                string[] paramNumbers = employeeArrangementShiftValueList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                DateTime currentDate = objArrangementShiftsInfo.HRArrangementShiftFromDate.AddDays(i);
                decimal mainEntryValue = 0;

                for (int j = 0; j < paramNumbers.Length; j++)
                {
                    string paramNo = paramNumbers[j].Trim();
                    ADWorkingShiftsInfo param = entity.WorkingShifts.Where(o => o.ADWorkingShiftName == paramNo).FirstOrDefault();
                    if (param != null)
                    {
                        HRArrangementShiftEntrysInfo arrangementShiftEntrys = objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList.Where(o => o.HRArrangementShiftEntryDate.Date == currentDate.Date &&
                            o.FK_ADWorkingShiftID == param.ADWorkingShiftID &&
                                                                                                                                                    objEmployeeArrangementShiftsInfo.FK_HREmployeeID == o.FK_HREmployeeID)
                                                                                                                                                    .FirstOrDefault();
                        if (arrangementShiftEntrys == null)
                        {
                            arrangementShiftEntrys = new HRArrangementShiftEntrysInfo();
                            arrangementShiftEntrys.FK_HREmployeeArrangementShiftID = objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftID;
                            arrangementShiftEntrys.FK_HRArrangementShiftID = objEmployeeArrangementShiftsInfo.FK_HRArrangementShiftID;
                            arrangementShiftEntrys.FK_HREmployeeID = objEmployeeArrangementShiftsInfo.FK_HREmployeeID;
                            arrangementShiftEntrys.HRArrangementShiftEntryDate = currentDate;

                            arrangementShiftEntrys.FK_ADWorkingShiftID = param.ADWorkingShiftID;
                            objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList.Add(arrangementShiftEntrys);
                        }
                        else
                        {
                            arrangementShiftEntrys.FK_HREmployeeArrangementShiftID = objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftID;
                            arrangementShiftEntrys.FK_HRArrangementShiftID = objEmployeeArrangementShiftsInfo.FK_HRArrangementShiftID;
                            arrangementShiftEntrys.FK_HREmployeeID = objEmployeeArrangementShiftsInfo.FK_HREmployeeID;
                            arrangementShiftEntrys.FK_ADWorkingShiftID = param.ADWorkingShiftID;
                            arrangementShiftEntrys.HRArrangementShiftEntryDate = currentDate;
                        }
                    }
                }
            }
            entity.EmployeeArrangementShiftsList.GridControl.RefreshDataSource();
            entity.UpdateMainObjectBindingSource();
        }

        private HREmployeeArrangementShiftsInfo SetEmployeeArrangementShiftsInfoFromEmployee(HREmployeesInfo objEmployeesInfo)
        {
            HREmployeeArrangementShiftsInfo objEmployeeArrangementShiftsInfo = new HREmployeeArrangementShiftsInfo();

            if (objEmployeesInfo != null)
            {
                objEmployeeArrangementShiftsInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
                objEmployeeArrangementShiftsInfo.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
                objEmployeeArrangementShiftsInfo.HRDepartmentName = objEmployeesInfo.HRDepartmentName;
                objEmployeeArrangementShiftsInfo.HRDepartmentRoomName = objEmployeesInfo.HRDepartmentRoomName;
                objEmployeeArrangementShiftsInfo.HRDepartmentRoomGroupName = objEmployeesInfo.HRDepartmentRoomGroupItemName;
                objEmployeeArrangementShiftsInfo.HREmployeeName = objEmployeesInfo.HREmployeeName;
                objEmployeeArrangementShiftsInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
                objEmployeeArrangementShiftsInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            }
            return objEmployeeArrangementShiftsInfo;
        }

        public void AddDefaulArrangementShiftEntries(HREmployeeArrangementShiftsInfo objEmployeeArrangementShiftsInfo, HREmployeesInfo objEmployeesInfo)
        {
            objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList.Clear();

            ArrangementShiftEntities entity = (ArrangementShiftEntities)CurrentModuleEntity;
            HRArrangementShiftsInfo objArrangementShiftsInfo = (HRArrangementShiftsInfo)entity.MainObject;
            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            List<ADWorkingShiftsInfo> workingShifts = entity.WorkingShifts;
            ADWorkingShiftsInfo defaultParam = (ADWorkingShiftsInfo)workingShifts.Where(o => o.ADWorkingShiftID == objEmployeesInfo.FK_ADWorkingShiftID).FirstOrDefault();

            if (defaultParam != null)
            {
                VinaDbUtil dbUtil = new VinaDbUtil();
                int numDays = NumOfDayInMonth();
                for (int i = 1; i <= numDays; i++)
                {
                    DateTime currentDate = objArrangementShiftsInfo.HRArrangementShiftFromDate.Date.AddDays(i - 1);
                    HRArrangementShiftEntrysInfo entry = new HRArrangementShiftEntrysInfo();
                    entry.FK_HREmployeeID = objEmployeeArrangementShiftsInfo.FK_HREmployeeID;
                    entry.FK_HRArrangementShiftID = objEmployeeArrangementShiftsInfo.FK_HRArrangementShiftID;
                    entry.FK_HREmployeeArrangementShiftID = objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftID;
                    entry.HRArrangementShiftEntryDate = currentDate;
                    entry.FK_ADWorkingShiftID = defaultParam.ADWorkingShiftID;

                    //String propertyName = String.Format("{0}{1}", "HREmployeeArrangementShiftDate", i);
                    objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList.Add(entry);
                }
            }
        }
    }
}
