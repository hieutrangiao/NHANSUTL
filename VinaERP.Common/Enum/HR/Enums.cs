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
    public enum AllowanceType
    {
        Percent,
        Amount,
        Other,
        WorkingQty,
        OTHours,
        WorkingQtyNight,
        WorkingQtyTotal,
        OTQty,
        C,
        CD,
        Bus,
        DH,
        CNight,
        Effective,
        Diligence,
        HeavyToxic,
        Perennial
    }
    public enum AllowanceConfigName
    {
        Productivity,
        Quality,
        Manage,
        Diligence,
        HeavyToxic,
        Perennial,
        Other
    }
    public enum HRFormAllowanceType
    {
        CaNhan,
        CoDinh,
        MucChung
    }
    public enum OverTimeStatus
    {
        New,
        Approved
    }

    public enum TimeSheetType
    {
        Day,
        Hour
    }

    public enum TimeSheetStatus
    {
        New,
        SalaryCalculated,
        Approved
    }

    public enum OTFactorType
    {
        Holiday,
        EndOfWeek,
        WorkingDay
    }

    public enum CalendarType
    {
        Holiday
    }

    public enum TimesheetEmployeeLateConfigType
    {
        BackSoon,
        ComeLate
    }

    public enum WorkingShiftDayOffWeek
    {
        T2 = 1,
        T3 = 2,
        T4 = 3,
        T5 = 4,
        T6 = 5,
        T7 = 6,
        CN = 0,
        All = -1
    }
    public enum EmployeePayRollCalculatedWorkType
    {
        Default,
        TableWork
    }

    public enum PayRollStatus
    {
        New,
        Posted,
        Complete
    }

    public enum EmployeeWorkingForm
    {
        Probationary,
        Apprentice,
        Official
    }

    public enum DisciplineDocumentType
    {
        Phone,
        Other
    }

    public enum HRFormAllowanceNameType
    {
        Phucapdienthoai,
        Phucapchuyencan,
        Phucapxang,
        Phucapnhao,
        ThuongKPI,
        Phucaptrachnhiem,
        Phucapthuviec,
        Phucapthamnien,
        Phucapcongtac,
        Phucapcom,
        Phucapcadem,
        PCBaoduongxe,
        PhuCapDiTinh,
        Phucaplanhnghe,
        Phucaptrachnhiemhanghoa,
        Khac,
        Tienantangca
    }

    public enum EmployeePayrollFormulaHandleTypeCombo
    {
        FirstLast,
        Double
    }
}
