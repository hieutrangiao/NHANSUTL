using BOSLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class BusinessObject : ICloneable, INotifyPropertyChanged
    {
        public String TableName = String.Empty;

        public bool Selected { get; set; }

        public static readonly string DefaultAAStatus = "Alive";

        public static readonly string DeletedAAStatus = "Delete";

        public static DateTime DefaultDate = DateTime.MaxValue;

        public const int DefaultNumber = 0;

        public static readonly string DefaultActive = "true";

        public static readonly string DefaultStatus = "New";

        public static readonly string DefaultObjectNo = "***NEW***";

        public BusinessObject OldObject { get; set; }

        public BusinessObject BackupObject { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<BusinessRule> BusinessRuleCollections;

        public BusinessObject()
        {
            this.Selected = false;
        }

        public object Clone()
        {
            BusinessObject obj = (BusinessObject)this.MemberwiseClone();
            obj.TableName = this.TableName;
            return obj;
        }

        #region "Event, delegate functions"

        public delegate void EventHandler(object sender, EventArgs e);
        //public event EventHandler OnValid;
        //public event EventHandler OnInvalid;
        //public event EventHandler OnChanged;

        public void RaiseEvent(EventHandler handler, EventArgs e)
        {
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }

        protected virtual void NotifyChanged(params string[] propertyNames)
        {
            if (this.PropertyChanged == null)
                return;

            foreach (string name in propertyNames)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
