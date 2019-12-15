using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaERP.Common
{
    public class TableName
    {
        #region GE
        public const string GEPaymentTermsTableName = "GEPaymentTerms";
        public const string GEPaymentTermItemsTableName = "GEPaymentTermItems";
        #endregion

        #region HR
        public const string HRDepartmentsTableName = "HRDepartments";
        public const string HRDepartmentRoomsTableName = "HRDepartmentRooms";
        public const string HRDepartmentRoomGroupsTableName = "HRDepartmentRoomGroups";
        public const string HRDepartmentRoomGroupItemsTableName = "HRDepartmentRoomGroupItems";
        public const string HRRewardsTableName = "HRRewards";
        public const string HREmployeeRewardsTableName = "HREmployeeRewards";
        public const string HRDisciplinesTableName = "HRDisciplines";
        public const string HREmployeeDisciplinesTableName = "HREmployeeDisciplines";
        public const string HREmployeeWorkSchedulesTableName = "HREmployeeWorkSchedules";
        public const string HREmployeeWorkScheduleItemsTableName = "HREmployeeWorkScheduleItems";
        public const string HRAllowancesTableName = "HRAllowances";
        public const string HREmployeeAllowancesTableName = "HREmployeeAllowances";
        public const string HROverTimesTableName = "HROverTimes";
        public const string HREmployeeOTsTableName = "HREmployeeOTs";
        #endregion

        #region IC
        public const string ICProductsTableName = "ICProducts";
        public const string ICProductMeasureUnitsTableName = "ICProductMeasureUnits";
        #endregion
    }
}
