using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace QLNS.Main.NhanSu
{
    public partial class ctrlThemMoi : BaseControl.ControlBase
    {
        public ctrlThemMoi()
        {
            InitializeComponent();

            this.PageCaption = "Thêm Mới Nhân Sự";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show("Chắc chắn bạn muốn Hủy bỏ?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
               ((frmMain)this.ParentForm).CloseCurrentTab();
            }
        }
    }
}
