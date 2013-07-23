using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HS.Server.Data.Entities.Systems
{
    /// <summary>
    /// DmLoaidanhmucData object for Entity mapped table DM_LoaiDanhMuc.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  19/07/2013 03:31:13 PM
    /// </summary>
    [DataContract]
    public class DanhMucData : INotifyPropertyChanged
    {
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

        public DanhMucData()
        {
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

    }
}
