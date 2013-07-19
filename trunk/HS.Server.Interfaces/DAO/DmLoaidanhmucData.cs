using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HS.Server.Interfaces.DAO
{
    /// <summary>
    /// DmLoaidanhmucData object for Entity mapped table DM_LoaiDanhMuc.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  19/07/2013 03:31:13 PM
    /// </summary>
    [DataContract]
    public class DmLoaidanhmucData : INotifyPropertyChanged
    {
        private System.Int32 _ID;
        private System.String _MaLoaiDanhMuc;
        private System.String _TenLoaiDanhMuc;
        private System.Int32? _ThuTu;
        private System.Boolean? _System;


        #region INotifyPropertyChanged Members

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public DmLoaidanhmucData()
        {
        }

        public DmLoaidanhmucData(System.Int32 iD)
        {
            this.ID = iD;
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
        public System.String TenLoaiDanhMuc
        {
            get { return _TenLoaiDanhMuc; }
            set
            {
                if (TenLoaiDanhMuc != value)
                {
                    _TenLoaiDanhMuc = value;
                    OnPropertyChanged("TenLoaiDanhMuc");
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
        public System.Boolean? System
        {
            get { return _System; }
            set
            {
                if (System != value)
                {
                    _System = value;
                    OnPropertyChanged("System");
                }
            }
        }


        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

    }
}
