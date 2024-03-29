﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLNS.Common;

namespace QLNS.Data.DataAccessLayer
{
    public class TaiKhoanManager
    {
        string ConnectionString = "";
        public TaiKhoanManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public bool Add(QLNS.Data.TaiKhoan item)
        {
            try
            {
                MainDataContext context = new MainDataContext(ConnectionString);

                context.TaiKhoans.InsertOnSubmit(item);
                context.SubmitChanges();

                context.Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(QLNS.Data.TaiKhoan item)
        {
            try
            {
                MainDataContext context = new MainDataContext(ConnectionString);

                var itemUpdate = context.TaiKhoans.SingleOrDefault(p => p.ID == item.ID);

                if (itemUpdate != null)
                {
                    itemUpdate.HoTen = item.HoTen;
                    itemUpdate.MatKhau = item.MatKhau;
                    itemUpdate.TrangThai = item.TrangThai;
                }

                context.SubmitChanges();

                context.Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(QLNS.Data.TaiKhoan item)
        {
            try
            {
                MainDataContext context = new MainDataContext(ConnectionString);

                var itemDelete = context.TaiKhoans.SingleOrDefault(p => p.ID == item.ID);

                if (itemDelete != null)
                {
                    context.TaiKhoans.DeleteOnSubmit(itemDelete);
                }

                context.SubmitChanges();

                context.Connection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TaiKhoan> GetAll()
        {
            try
            {
                MainDataContext context = new MainDataContext(ConnectionString);

                var listReturn = context.TaiKhoans.ToList();

                context.Connection.Close();

                return listReturn;
            }
            catch (Exception)
            {
                return new List<TaiKhoan>();
            }
        }

        public TaiKhoan Get(Guid ID)
        {
            try
            {
                MainDataContext context = new MainDataContext(ConnectionString);

                var taiKhoan = context.TaiKhoans.SingleOrDefault(p => p.ID == ID);

                context.Connection.Close();

                return taiKhoan;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Login(string TaiKhoan, string MatKhau, ref string error)
        {
            try
            {
                MainDataContext context = new MainDataContext(ConnectionString);

                var taiKhoan = context.TaiKhoans.SingleOrDefault(p => p.TenTaiKhoan == TaiKhoan && p.MatKhau == MatKhau.MD5());
                if (taiKhoan == null)
                {
                    error = "Tài khoản không tồn tại HOẶC Thông tin đăng nhập không chính xác.";
                    return false;
                }

                if (taiKhoan.TrangThai == 0)
                {
                    error = "Tài khoản đã bị khóa.";
                    return false;
                }

                taiKhoan.LastLogin = DateTime.Now;

                context.SubmitChanges();
                context.Connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
