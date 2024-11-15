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
    public partial class Login : Form
    {
        QLShopDataContext qlshop = new QLShopDataContext();
        int ViTriBanDau_lblEx2 = 0;
        int ViTriBanDau_btn = 0;
        int ViTriBanDau_pass = 0;

        bool flag = false;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            ViTriBanDau_lblEx2 = lblEx2.Top;
            ViTriBanDau_btn = btnDangNhap.Top;
            ViTriBanDau_pass = panelPass.Top;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblLoiPass.Visible = false;
            lblEx1.Visible = false;
            lblEx2.Visible = false;
            lblEx2.Top = ViTriBanDau_lblEx2;
            btnDangNhap.Top = ViTriBanDau_btn;
            panelPass.Top = ViTriBanDau_pass;

            if (txtUser.IsEmpty && txtPass.IsEmpty)
            {
                lblEx1.Visible = true;
                lblEx2.Visible = true;
                panelPass.Top += (lblEx1.Height - 8);
                lblEx2.Top += lblEx1.Height - 8;
                btnDangNhap.Top += (lblEx1.Height);
                flag = true;
            }
            else if (txtUser.IsEmpty)
            {
                lblEx1.Visible = true;
                panelPass.Top += (lblEx1.Height - 8);
                flag = true;
            }
            else if (txtPass.IsEmpty)
            {
                lblEx2.Visible = true;
                btnDangNhap.Top += (lblEx1.Height - 11);
                flag = true;
            }
            else
            {
                try
                {
                    string tenDangNhap = txtUser.Text;
                    string matKhau = txtPass.Text;
                    var user = qlshop.NhanViens.FirstOrDefault(t => t.MaNhanVien == tenDangNhap && t.MatKhau == matKhau);

                    if (user != null)
                    {
                        FormPrincipal nv = new FormPrincipal(user.MaNhanVien, user.HoTen, user.MaChucVu, user.MaLoaiTaiKhoan);
                        nv.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Bạn không có quyền truy cập hệ thống!");
                }
                catch (Exception ex)
                {
                    lblLoiPass.Visible = true;
                    txtPass.Clear();
                    txtUser.Clear();
                    txtUser.Focus();
                }
            }
        }
    }
}
