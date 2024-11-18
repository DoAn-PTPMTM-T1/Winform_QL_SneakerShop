using System;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace ModernGUI_V3
{
    public partial class FCaiDat : Form
    {
        QLShopDataContext qlshop = new QLShopDataContext();
        string manv = "";

        public FCaiDat()
        {
            InitializeComponent();
        }

        private void FCaiDat_Load(object sender, EventArgs e)
        {
            FormPrincipal mainForm = this.Owner as FormPrincipal;
            manv = mainForm.manv;
            txtTenDangNhap.Text = mainForm.manv;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhauHienTai = txtMatKhau.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string matKhauNhapLai = txtNhapLai.Text;

            if (string.IsNullOrWhiteSpace(matKhauHienTai) || string.IsNullOrWhiteSpace(matKhauMoi) || string.IsNullOrWhiteSpace(matKhauNhapLai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (matKhauMoi != matKhauNhapLai)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nhanVien = qlshop.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == manv);

            if (nhanVien != null)
            {
                // Băm mật khẩu hiện tại để so sánh
                string hashedMatKhauHienTai = HashPassword(matKhauHienTai);

                if (nhanVien.MatKhau == hashedMatKhauHienTai)
                {
                    // Băm mật khẩu mới trước khi lưu
                    nhanVien.MatKhau = HashPassword(matKhauMoi);
                    qlshop.SubmitChanges();
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormPrincipal mainForm = this.Owner as FormPrincipal;
                    if (mainForm != null)
                    {
                        mainForm.Close();
                    }
                    this.Close();
                    Login login = new Login();
                    login.Visible = true;
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLai.Clear();
        }

        public static string HashPassword(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
