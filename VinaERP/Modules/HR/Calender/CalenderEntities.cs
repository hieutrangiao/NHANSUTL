using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCommon;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.Calender
{
    public class CalenderEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HRCalendarEntrysInfo> CalendarEntrysList { get; set; }
        #endregion

        #region Constructor
        public CalenderEntities()
            : base()
        {
            CalendarEntrysList = new VinaList<HRCalendarEntrysInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRCalendarsInfo();
            SearchObject = new HRCalendarsInfo();
        }

        public override void InitModuleObjectList()
        {
            CalendarEntrysList.InitVinaList(this,
                                             TableName.HRCalendarsTableName,
                                             TableName.HRCalendarEntrysTableName,
                                             VinaList<HRCalendarEntrysInfo>.cstRelationForeign);
            CalendarEntrysList.ItemTableForeignKey = "FK_HRCalendarID";
        }

        public override void InitGridControlInVinaList()
        {
            CalendarEntrysList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRCalendarsInfo objCalendersInfo = (HRCalendarsInfo)MainObject;
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                CalendarEntrysList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            CalendarEntrysList.Invalidate(iObjectID);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            CalendarEntrysList.SaveItemObjects();
        }
        #endregion
    }
}
