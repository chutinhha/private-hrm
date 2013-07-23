using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HS.Server.Data.Entities.Systems
{
    /// <summary>
    /// DmDanhmucitemData object for Entity mapped table DM_DanhMucItem.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  19/07/2013 04:37:32 PM
    /// </summary>
    [DataContract]
    public class DanhMucItemData : INotifyPropertyChanged
    {
        private System.Guid _ID;
        private System.String _MaLoaiDanhMuc;
        private System.String _MaDanhMuc;
        private System.String _TenDanhMuc;
        private System.Int32? _ThuTu;
        private System.Int32? _IntVal1;
        private System.Int32? _IntVal2;
        private System.Int32? _IntVal3;
        private System.Decimal? _DecVal1;
        private System.Decimal? _DecVal2;
        private System.Decimal? _DecVal3;
        private System.String _StrVal1;
        private System.String _StrVal2;
        private System.String _StrVal3;
        private System.Boolean _Active;


        #region INotifyPropertyChanged Members

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public DanhMucItemData()
        {
        }

        [DataMember]
        public System.Guid ID
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
        public System.String MaLoaiDanhMuc
        {
            get { return _MaLoaiDanhMuc; }
            set
            {
                if (MaLoaiDanhMuc != value)
                {
                    _MaLoaiDanhMuc = value;
                    OnPropertyChanged("MaLoaiDanhMuc");
                }
            }
        }
        [DataMember]
        public System.String MaDanhMuc
        {
            get { return _MaDanhMuc; }
            set
            {
                if (MaDanhMuc != value)
                {
                    _MaDanhMuc = value;
                    OnPropertyChanged("MaDanhMuc");
                }
            }
        }
        [DataMember]
        public System.String TenDanhMuc
        {
            get { return _TenDanhMuc; }
            set
            {
                if (TenDanhMuc != value)
                {
                    _TenDanhMuc = value;
                    OnPropertyChanged("TenDanhMuc");
                }
            }
        }
        [DataMember]
        public System.Int32? ThuTu
        {
            get { return _ThuTu; }
            set
            {
                if (ThuTu != value)
                {
                    _ThuTu = value;
                    OnPropertyChanged("ThuTu");
                }
            }
        }
        [DataMember]
        public System.Int32? IntVal1
        {
            get { return _IntVal1; }
            set
            {
                if (IntVal1 != value)
                {
                    _IntVal1 = value;
                    OnPropertyChanged("IntVal1");
                }
            }
        }
        [DataMember]
        public System.Int32? IntVal2
        {
            get { return _IntVal2; }
            set
            {
                if (IntVal2 != value)
                {
                    _IntVal2 = value;
                    OnPropertyChanged("IntVal2");
                }
            }
        }
        [DataMember]
        public System.Int32? IntVal3
        {
            get { return _IntVal3; }
            set
            {
                if (IntVal3 != value)
                {
                    _IntVal3 = value;
                    OnPropertyChanged("IntVal3");
                }
            }
        }
        [DataMember]
        public System.Decimal? DecVal1
        {
            get { return _DecVal1; }
            set
            {
                if (DecVal1 != value)
                {
                    _DecVal1 = value;
                    OnPropertyChanged("DecVal1");
                }
            }
        }
        [DataMember]
        public System.Decimal? DecVal2
        {
            get { return _DecVal2; }
            set
            {
                if (DecVal2 != value)
                {
                    _DecVal2 = value;
                    OnPropertyChanged("DecVal2");
                }
            }
        }
        [DataMember]
        public System.Decimal? DecVal3
        {
            get { return _DecVal3; }
            set
            {
                if (DecVal3 != value)
                {
                    _DecVal3 = value;
                    OnPropertyChanged("DecVal3");
                }
            }
        }
        [DataMember]
        public System.String StrVal1
        {
            get { return _StrVal1; }
            set
            {
                if (StrVal1 != value)
                {
                    _StrVal1 = value;
                    OnPropertyChanged("StrVal1");
                }
            }
        }
        [DataMember]
        public System.String StrVal2
        {
            get { return _StrVal2; }
            set
            {
                if (StrVal2 != value)
                {
                    _StrVal2 = value;
                    OnPropertyChanged("StrVal2");
                }
            }
        }
        [DataMember]
        public System.String StrVal3
        {
            get { return _StrVal3; }
            set
            {
                if (StrVal3 != value)
                {
                    _StrVal3 = value;
                    OnPropertyChanged("StrVal3");
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
