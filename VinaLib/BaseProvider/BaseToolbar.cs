using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaLib
{
    public class BaseToolbar
    {
        #region ToolbarGroupType
        public const string ToolbarAction = "Action";

        public const string ToolbarUtility = "Utility";

        public const string ToolbarExtra = "Extra";

        public const string ToolbarInfo = "Info";

        #endregion 

        #region Toolbar Defaut Action

        public const string ToolbarButtonComplete = "Complete";

        public const string ToolbarButtonCancel = "Cancel";

        public const string ToolbarButtonEdit = "Edit";

        public const string ToolbarButtonNew = "New";

        public const string ToolbarButtonPrint = "Print";

        public const string ToolbarButtonSave = "Save";

        public const string ToolbarButtonApproved = "Approved";

        #endregion

        #region Toolbar Defaut Action
        public const string ModuleEdit = "Edit";

        public const string ModuleNew = "New";

        public const string ModuleNone = "None";
        #endregion

        public DataSet ObjectCollection { get; set; }

        public int CurrentIndex { get; set; }

        public string ModuleAction { get; set; }

        public BaseToolbar()
        {
            this.ModuleAction = "None";
        }

        public virtual void SetToolbar(DataSet ds)
        {
            this.ObjectCollection = ds;
            if (this.ObjectCollection.Tables.Count > 0)
            {
                this.ObjectCollection.Tables[0].PrimaryKey = new DataColumn[1]
                {
                    this.ObjectCollection.Tables[0].Columns[0]
                };
                if (this.ObjectCollection.Tables[0].Rows.Count > 0)
                    this.CurrentIndex = 0;
            }
            this.CurrentIndex = 0;
        }

        public virtual int GetCurrentIndex(int iObjectID)
        {
            return this.ObjectCollection.Tables[0].Rows.IndexOf(this.ObjectCollection.Tables[0].Rows.Find((object)iObjectID));
        }

        public virtual int GetCurrentIndex(DataRow currentRow)
        {
            return this.ObjectCollection.Tables[0].Rows.IndexOf(currentRow);
        }

        public int CurrentObjectID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.ObjectCollection.Tables[0].Rows[this.CurrentIndex][0]);
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public int ObjectCollectionLength
        {
            get
            {
                return this.ObjectCollection.Tables[0].Rows.Count;
            }
        }

        public bool IsNullOrNoneAction()
        {
            bool flag = true;
            if (this.ModuleAction == "Edit" || this.ModuleAction == "New")
                flag = false;
            return flag;
        }

        public bool IsNewAction()
        {
            bool flag = true;
            if (this.IsNullOrNoneAction())
                flag = false;
            else if (this.ModuleAction != "New")
                return false;
            return flag;
        }

        public bool IsEditAction()
        {
            bool flag = true;
            if (this.IsNullOrNoneAction())
                flag = false;
            else if (this.ModuleAction != "Edit")
                return false;
            return flag;
        }

        public virtual void New()
        {
            this.ModuleAction = nameof(New);
            this.NewEvent();
        }

        public virtual bool Edit()
        {
            if (this.ObjectCollection != null)
            {
                if (this.ObjectCollection.Tables[0].Rows.Count > 0 && this.CurrentIndex >= 0)
                {
                    this.ModuleAction = nameof(Edit);
                    this.InvalidateEvent(this.CurrentObjectID);
                    return true;
                }
                int num = (int)MessageBox.Show("Thông báo", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            int num1 = (int)MessageBox.Show("Thông báo", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        public virtual void Cancel()
        {
            if (this.ObjectCollection != null && this.CurrentObjectID > 0)
                this.InvalidateEvent(this.CurrentObjectID);
            this.ModuleAction = "None";
        }

        public virtual int Save()
        {
            return this.SaveEvent();
        }

        public virtual void Delete()
        {
            if (this.DeleteEvent(this.CurrentObjectID) && this.CurrentIndex > 0)
            {
                --this.CurrentIndex;
                this.InvalidateEvent(this.CurrentObjectID);
            }
            this.ModuleAction = "None";
        }

        public virtual void Invalidate()
        {
            this.InvalidateEvent(this.CurrentObjectID);
        }

        public virtual void Next()
        {
            if (this.IsNullOrNoneAction())
            {
                if (this.ObjectCollectionLength <= 0)
                    return;
                if (this.CurrentIndex < this.ObjectCollectionLength - 1)
                    ++this.CurrentIndex;
                this.InvalidateEvent(this.CurrentObjectID);
            }
            else
            {
                int num = (int)MessageBox.Show("Thông báo", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public virtual void Previous()
        {
            if (this.IsNullOrNoneAction())
            {
                if (this.ObjectCollectionLength <= 0)
                    return;
                if (this.CurrentIndex > 0)
                    --this.CurrentIndex;
                this.InvalidateEvent(this.CurrentObjectID);
            }
            else
            {
                int num = (int)MessageBox.Show("Thông báo", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public virtual void First()
        {
            if (this.IsNullOrNoneAction())
            {
                if (this.ObjectCollectionLength <= 0)
                    return;
                this.CurrentIndex = 0;
                this.InvalidateEvent(this.CurrentObjectID);
            }
            else
            {
                int num = (int)MessageBox.Show("", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public virtual void Print()
        {
            this.PrintEvent();
        }

        public event BaseToolbar.InvalidateHandler InvalidateEvent;

        public event BaseToolbar.NewHandler NewEvent;

        public event BaseToolbar.DeleteHandler DeleteEvent;

        public event BaseToolbar.SaveHandler SaveEvent;

        public event BaseToolbar.PrintHandler PrintEvent;

        public delegate void InvalidateHandler(int iObjectID);

        public delegate void NewHandler();

        public delegate bool DeleteHandler(int iObjectID);

        public delegate int SaveHandler();

        public delegate void PrintHandler();
    }
}
