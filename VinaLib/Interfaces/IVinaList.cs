using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public interface IVinaList<T> : IEnumerable<T>, IEnumerable, ICloneable where T : BusinessObject
    {
        IList<T> BackupList { get; set; }
        int CurrentIndex { get; }
        string ItemTableForeignKey { get; set; }
        string ItemTableName { get; set; }
        IList<T> OriginalList { get; set; }
        string ParentTableName { get; set; }
        string Relation { get; set; }

        void AddObjectToList();
        void ChangeObjectFromList();
        void DeleteAllItemObjects();
        void DeleteItemObjects();
        bool Exists(string strPropertyName, object objPropertyValue);
        int GetFrequence(string strPropertyName, object objPropertyValue);
        int GetParentObjectID();
        void InitBOSList(object entity, string parentTableName, string itemTableName);
        void InitBOSList(object entity, string parentTableName, string itemTableName, string relation);
        void Invalidate(DataSet ds);
        void Invalidate(IList<T> lst);
        void Invalidate(int iObjectID);
        void RemoveObjectFromList(int iIndex);
        void RemoveSelectedRowObjectFromList();
        void SaveItemObjects();
        T SaveObjectToList(bool isNew);
    }
}
