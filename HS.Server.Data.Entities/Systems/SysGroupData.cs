using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HS.Server.Data.Entities.Systems
{
    /// <summary>
    /// SysGroupData object for Entity mapped table SysGroup.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  24/07/2013 02:38:26 PM
    /// </summary>
    [DataContract]
    public class SysGroupData : INotifyPropertyChanged
    {
        private System.Int32 _ID;
        private System.Int32? _ID_Creator;
        private System.String _Name;
        private System.String _Description;
        private System.Boolean _Active;


        #region INotifyPropertyChanged Members

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public SysGroupData()
        {
        }
        [DataMember]
        public System.Int32 ID
        {
            get { return _ID; }
            set
            {
                if (ID != value)
                {
                    _ID = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        [DataMember]
        public System.Int32? ID_Creator
        {
            get { return _ID_Creator; }
            set
            {
                if (ID_Creator != value)
                {
                    _ID_Creator = value;
                    OnPropertyChanged("ID_Creator");
                }
            }
        }
        [DataMember]
        public System.String Name
        {
            get { return _Name; }
            set
            {
                if (Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        [DataMember]
        public System.String Description
        {
            get { return _Description; }
            set
            {
                if (Description != value)
                {
                    _Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        [DataMember]
        public System.Boolean Active
        {
            get { return _Active; }
            set
            {
                if (Active != value)
                {
                    _Active = value;
                    OnPropertyChanged("Active");
                }
            }
        }



    }
}
