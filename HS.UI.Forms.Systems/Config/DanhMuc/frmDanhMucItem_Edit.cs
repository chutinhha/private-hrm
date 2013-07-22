using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.UI.Common;
using HS.UI.Common.Service;
using HS.UI.Connection.HSService;

namespace HS.UI.Forms.Systems.Config.DanhMuc
{
    public partial class frmDanhMucItem_Edit : Form
    {
        private SystemWraper db = new SystemWraper();

        public DanhMucItemData RefData = null;
        private string _maLoaiDanhMuc;

        private int _actions = 0;

        public frmDanhMucItem_Edit()
        {
            InitializeComponent();

            SetEvents();
        }

        public frmDanhMucItem_Edit(string maLoaiDanhMuc)
        {
            InitializeComponent();

            _maLoaiDanhMuc = maLoaiDanhMuc;

            SetEvents();
        }

        private void SetEvents()
        {
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            this.Load += new EventHandler(frmDanhMucItem_Edit_Load);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frmDanhMucItem_Edit_Load(object sender, EventArgs e)
        {
            SetDataBindings();
        }

        private void SetDataBindings()
        {
            if (RefData != null)
            {
                txtMaDanhMuc.Text = RefData.MaDanhMuc;
                txtTenDanhMuc.Text = RefData.TenDanhMuc;
                txtThuTu.Value = RefData.ThuTu.Value;
                txtInt1.Value = RefData.IntVal1;
                txtInt2.Value = RefData.IntVal2;
                txtInt3.Value = RefData.IntVal3;
                txtDec1.Value = RefData.DecVal1;
                txtDec2.Value = RefData.DecVal2;
                txtDec3.Value = RefData.DecVal3;
                txtString1.Text = RefData.StrVal1;
                txtString2.Text = RefData.StrVal2;
                txtString3.Text = RefData.StrVal3;

                _actions = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            bool isOk = true;

            if (CheckInput())
            {
                if (_actions == 0)
                {
                    RefData = new DanhMucItemData();
                    RefData.MaLoaiDanhMuc = _maLoaiDanhMuc;
                    RefData.ID = Guid.NewGuid();
                }

                RefData.MaDanhMuc = txtMaDanhMuc.Text;
                RefData.TenDanhMuc = txtTenDanhMuc.Text;
                RefData.ThuTu = txtThuTu.IntValue;
                RefData.IntVal1 = txtInt1.IntValue;
                RefData.IntVal2 = txtInt2.IntValue;
                RefData.IntVal3 = txtInt3.IntValue;
                RefData.DecVal1 = txtDec1.Value;
                RefData.DecVal2 = txtDec2.Value;
                RefData.DecVal3 = txtDec3.Value;
                RefData.StrVal1 = txtString1.Text;
                RefData.StrVal2 = txtString2.Text;
                RefData.StrVal3 = txtString3.Text;
                RefData.Active = true;

                if (_actions == 1)
                {
                    isOk = db.ChangeDanhMucItem(RefData) >= 1;
                }
                else
                {
                    isOk = db.AddDanhMucItem(RefData) >= 1;
                }

                if (isOk)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Đã có lỗi khi Lưu dữ liệu! Hãy thử lại.", Common.Variables.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckInput()
        {
            try
            {
                string lackControl = "";
                if (String.IsNullOrWhiteSpace(txtMaDanhMuc.Text))
                {
                    lackControl += " - Mã Danh Mục\n";
                }
                if (String.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
                {
                    lackControl += " - Tên Danh Mục\n";
                }

                if (lackControl != "")
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ các mục:\n" + lackControl, Common.Variables.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[ChechInput]", ex);
                return false;
            }
        }
    }
}
