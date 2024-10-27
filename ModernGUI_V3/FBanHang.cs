using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public partial class FBanHang : Form
    {
        public FBanHang()
        {
            InitializeComponent();
        }
        string manv;
        private void FBanHang_Load(object sender, EventArgs e)
        {
            FormPrincipal mainForm = this.Owner as FormPrincipal;
            manv = mainForm.manv;
            txtMaNV.Text = mainForm.manv;
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            FormPrincipal mainForm = this.Owner as FormPrincipal;
            if (mainForm != null)
            {
                mainForm.MoForm_KH();
                this.Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy FormPrincipal.");
            }
        }

    }
}
