using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HS.Server.Data.Entities.Systems
{
    /// <summary>
    /// SysAccountData object for Entity mapped table SysAccount.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  24/07/2013 02:11:42 PM
    /// </summary>
    [DataContract]
    public class SysAccountData : INotifyPropertyChanged
    {
        private System.Int32 _ID;
        private System.String _Username;
        private System.String _Password;
        private System.String _RealName;
        private System.String _Email;
        private System.String _ID_DonVis;
        private System.DateTime? _LastAccess;
        private System.Boolean? _Active;
        private System.Byte? _AccountType;
        private System.Int32? _Creator_ID;
        private System.Int32? _ID_DonViGoc;
        private System.Boolean? _IsUpdate;


        #region INotifyPropertyChanged Members

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public SysAccountData()
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
        public System.String Username
        {
            get { return _Username; }
            set
            {
                if (Username != value)
                {
                    _Username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        [DataMember]
        public System.String Password
        {
            get { return _Password; }
            set
            {
                if (Password != value)
                {
                    _Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        [DataMember]
        public System.String RealName
        {
            get { return _RealName; }
            set
            {
                if (RealName != value)
                {
                    _RealName = value;
                    OnPropertyChanged("RealName");
                }
            }
        }
        [DataMember]
        public System.String Email
        {
            get { return _Email; }
            set
            {
                if (Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        [DataMember]
        public System.String ID_DonVis
        {
            get { return _ID_DonVis; }
            set
            {
                if (ID_DonVis != value)
                {
                    _ID_DonVis = value;
                    OnPropertyChanged("ID_DonVis");
                }
            }
        }
        [DataMember]
        public System.DateTime? LastAccess
        {
            get { return _LastAccess; }
            set
            {
                if (LastAccess != value)
                {
                    _LastAccess = value;
                    OnPropertyChanged("LastAccess");
                }
            }
        }
        [DataMember]
        public System.Boolean? Active
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
        [DataMember]
        public System.Byte? AccountType
        {
            get { return _AccountType; }
            set
            {
                if (AccountType != value)
                {
                    _AccountType = value;
                    OnPropertyChanged("AccountType");
                }
            }
        }
        [DataMember]
        public System.Int32? Creator_ID
        {
            get { return _Creator_ID; }
            set
            {
                if (Creator_ID != value)
                {
                    _Creator_ID = value;
                    OnPropertyChanged("Creator_ID");
                }
            }
        }
        [DataMember]
        public System.Int32? ID_DonViGoc
        {
            get { return _ID_DonViGoc; }
            set
            {
                if (ID_DonViGoc != value)
                {
                    _ID_DonViGoc = value;
                    OnPropertyChanged("ID_DonViGoc");
                }
            }
        }
        [DataMember]
        public System.Boolean? IsUpdate
        {
            get { return _IsUpdate; }
            set
            {
                if (IsUpdate != value)
                {
                    _IsUpdate = value;
                    OnPropertyChanged("IsUpdate");
                }
            }
        }
    }
}
