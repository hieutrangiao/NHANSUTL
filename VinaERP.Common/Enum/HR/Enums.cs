using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaCommon
{
    public enum TimeSheetParamType
    {
        Day,
        Hour,
        Common,
        LE
    }
    public enum RewardStatus
    {
        New,
        Approved
    }
    public enum RewardType
    {
        Percent,
        Amount,
        Other,
        WorkingQytFull,
        WorkDay,
        ChuyenCan,
        TichLuy,
        CaDem,
        RefundTheChan
    }
    public enum DisciplineStatus
    {
        New,
        Approved
    }

    public enum DisciplineType
    {
        Percent,
        Amount,
        WorkDay,
        Other,
        Absence,
        BHTN,
        PhiTheTu,
        PhiTheATM,
        PhiAo,
        Canhcao,
        Dinhchivothoihan,
        TheChan,
        Khientrach,
        Sathai
    }
    public enum EmployeeWorkScheduleStatus
    {
        New,
        Approved
    }
}
