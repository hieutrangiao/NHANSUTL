using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region ADWorkingShiftGroups

    public class ADWorkingShiftGroupsInfo : BusinessObject
    {
        public ADWorkingShiftGroupsInfo()
        {
        }
        #region Variables
        protected int _aDWorkingShiftGroupID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected String _aDWorkingShiftGroupNo = String.Empty;
        protected String _aDWorkingShiftGroupName = String.Empty;
        protected String _aDWorkingShiftGroupDesc = String.Empty;
        protected decimal _aDWorkingShiftGroupDayPerMonth;
        protected decimal _aDWorkingShiftGroupPrecentLess;
        protected decimal _aDWorkingShiftGroupPrecentExceed;
        #endregion

        #region Public properties
        public int ADWorkingShiftGroupID
        {
            get { return _aDWorkingShiftGroupID; }
            set
            {
                if (value != this._aDWorkingShiftGroupID)
                {
                    _aDWorkingShiftGroupID = value;
                    NotifyChanged("ADWorkingShiftGroupID");
                }
            }
        }
        public String AAStatus
        {
            get { return _aAStatus; }
            set
            {
                if (value != this._aAStatus)
                {
                    _aAStatus = value;
                    NotifyChanged("AAStatus");
                }
            }
        }
        public DateTime AACreatedDate
        {
            get { return _aACreatedDate; }
            set
            {
                if (value != this._aACreatedDate)
                {
                    _aACreatedDate = value;
                    NotifyChanged("AACreatedDate");
                }
            }
        }
        public String AACreatedUser
        {
            get { return _aACreatedUser; }
            set
            {
                if (value != this._aACreatedUser)
                {
                    _aACreatedUser = value;
                    NotifyChanged("AACreatedUser");
                }
            }
        }
        public DateTime AAUpdatedDate
        {
            get { return _aAUpdatedDate; }
            set
            {
                if (value != this._aAUpdatedDate)
                {
                    _aAUpdatedDate = value;
                    NotifyChanged("AAUpdatedDate");
                }
            }
        }
        public String AAUpdatedUser
        {
            get { return _aAUpdatedUser; }
            set
            {
                if (value != this._aAUpdatedUser)
                {
                    _aAUpdatedUser = value;
                    NotifyChanged("AAUpdatedUser");
                }
            }
        }
        public String ADWorkingShiftGroupNo
        {
            get { return _aDWorkingShiftGroupNo; }
            set
            {
                if (value != this._aDWorkingShiftGroupNo)
                {
                    _aDWorkingShiftGroupNo = value;
                    NotifyChanged("ADWorkingShiftGroupNo");
                }
            }
        }
        public String ADWorkingShiftGroupName
        {
            get { return _aDWorkingShiftGroupName; }
            set
            {
                if (value != this._aDWorkingShiftGroupName)
                {
                    _aDWorkingShiftGroupName = value;
                    NotifyChanged("ADWorkingShiftGroupName");
                }
            }
        }
        public String ADWorkingShiftGroupDesc
        {
            get { return _aDWorkingShiftGroupDesc; }
            set
            {
                if (value != this._aDWorkingShiftGroupDesc)
                {
                    _aDWorkingShiftGroupDesc = value;
                    NotifyChanged("ADWorkingShiftGroupDesc");
                }
            }
        }
        public decimal ADWorkingShiftGroupDayPerMonth
        {
            get { return _aDWorkingShiftGroupDayPerMonth; }
            set
            {
                if (value != this._aDWorkingShiftGroupDayPerMonth)
                {
                    _aDWorkingShiftGroupDayPerMonth = value;
                    NotifyChanged("ADWorkingShiftGroupDayPerMonth");
                }
            }
        }
        public decimal ADWorkingShiftGroupPrecentLess
        {
            get { return _aDWorkingShiftGroupPrecentLess; }
            set
            {
                if (value != this._aDWorkingShiftGroupPrecentLess)
                {
                    _aDWorkingShiftGroupPrecentLess = value;
                    NotifyChanged("ADWorkingShiftGroupPrecentLess");
                }
            }
        }
        public decimal ADWorkingShiftGroupPrecentExceed
        {
            get { return _aDWorkingShiftGroupPrecentExceed; }
            set
            {
                if (value != this._aDWorkingShiftGroupPrecentExceed)
                {
                    _aDWorkingShiftGroupPrecentExceed = value;
                    NotifyChanged("ADWorkingShiftGroupPrecentExceed");
                }
            }
        }
        #endregion
    }
    #endregion
}