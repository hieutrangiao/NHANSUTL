using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Calender
{

    public class CalenderModule : BaseModuleERP
    {
        #region Constant
        public const string CalenderTypeLookupEditName = "fld_lkeHRCalenderType";
        public const string CalenderValueTextBoxName = "fld_txtHRCalenderValue";
        #endregion
        public CalenderModule()
        {
            CurrentModuleName = "Calender";
            CurrentModuleEntity = new CalenderEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            CalenderEntities entity = (CalenderEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
        }

        public override int ActionSave()
        {
            CalenderEntities entity = (CalenderEntities)CurrentModuleEntity;
            return base.ActionSave();

        }

        public void RemoveDateFromCalendar()
        {
            CalenderEntities entity = (CalenderEntities)CurrentModuleEntity;
            entity.CalendarEntrysList.RemoveSelectedRowObjectFromList();
        }
    }
}
