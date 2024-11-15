using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ModernGUI_V3
{
    public partial class FKhachHang : Form
    {
        QLShopDataContext qlkh = new QLShopDataContext();
        int flag = 0;
        public FKhachHang()
        {
            InitializeComponent();
            load_KH();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load_KH()
        {
            var kh = from Kh in qlkh.KhachHangs
                     select new
                     {
                         MaKH = Kh.MaKhachHang,
                         HoTen = Kh.HoTen,
                         DiaChi = Kh.DiaChi,
                         SDT = Kh.SoDienThoai,
                         Email = Kh.Email
                     };
            grvKhachHang.DataSource = kh;

        }

        private void text_on()
        {
            txtHoTen.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            txtTimSDT_KH.Enabled = false;
            btnTimKH.Enabled = false;
        }

        private void text_off()
        {
            txtHoTen.Enabled = false;
            txtEmail.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            txtTimSDT_KH.Enabled = false;
            btnTimKH.Enabled = false;
        }

        private void clear_text()
        {
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtMaKH.Clear();
            txtSDT.Clear();
            txtTimSDT_KH.Clear();
        }
        private void btnThem_KH_Click(object sender, EventArgs e)
        {
            clear_text();
            btnLuu_KH.Enabled = true;
            btnSua_KH.Enabled = false;
            btnThem_KH.Enabled = true;
            btnXoa_KH.Enabled = false;
            txtMaKH.Text = MaKh();
            text_on();
            flag = 1;

        }


        private string MaKh()
        {
            var slpn = qlkh.KhachHangs.Count();
            slpn += 1;
            return "KH" + slpn;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^0\d{9}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        private bool ktraTrung_E(string E)
        {
            var sdt = qlkh.KhachHangs.Where(item => item.Email == E).FirstOrDefault();
            if (sdt == null)
                return true;
            else
                return false;
        }

        private bool ktraTrung_SDT(string SDT)
        {
            var sdt = qlkh.KhachHangs.Where(item => item.SoDienThoai == SDT).FirstOrDefault();
            if (sdt == null)
                return true;
            else
                return false;
        }
        private void btnXoa_KH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) || !string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    var findKh = qlkh.KhachHangs.Where(item => item.MaKhachHang == txtMaKH.Text).FirstOrDefault();
                    if (findKh != null)
                    {

                        qlkh.KhachHangs.DeleteOnSubmit(findKh);
                        qlkh.SubmitChanges();
                        MessageBox.Show("Xóa khách hàng thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!");
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn khách hàng");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSua_KH_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            txtDiaChi.Enabled = true;
            btnThem_KH.Enabled = false;
            btnXoa_KH.Enabled = false;
            btnLuu_KH.Enabled = true;
            flag = 2;
        }

        private void btnLuu_KH_Click(object sender, EventArgs e)
        {
            text_off();
            btnThem_KH.Enabled = true;
            btnSua_KH.Enabled = true;
            btnXoa_KH.Enabled = true;
            btnLuu_KH.Enabled = false;

            if (flag == 1)
            {
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    string email = txtEmail.Text;
                    string sdt = txtSDT.Text;
                    if (!IsValidEmail(email) || !IsValidPhoneNumber(sdt))
                    {
                        MessageBox.Show("Email hoặc số điện thoại hợp lệ.");
                        return;
                    }
                    else if (!ktraTrung_E(email) && !ktraTrung_SDT(sdt))
                    {
                        MessageBox.Show("Bị trùng số điện thoại hoặc Email");
                        return;
                    }
                    else
                    {
                        KhachHang khachHang = new KhachHang();
                        khachHang.MaKhachHang = txtMaKH.Text;
                        khachHang.HoTen = txtHoTen.Text;
                        khachHang.DiaChi = txtDiaChi.Text;
                        khachHang.SoDienThoai = txtSDT.Text;
                        khachHang.Email = txtEmail.Text;
                        qlkh.KhachHangs.InsertOnSubmit(khachHang);
                        qlkh.SubmitChanges();
                        MessageBox.Show("Thêm thành công");

                    }

                }
                else
                    MessageBox.Show("Thiếu thông tin");
            }
            else if (flag == 2)
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) || !string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    var findKh = qlkh.KhachHangs.Where(item => item.MaKhachHang == txtMaKH.Text).FirstOrDefault();
                    if (findKh != null)
                    {
                        // Cập nhật các thuộc tính của khách hàng
                        findKh.HoTen = txtHoTen.Text;
                        findKh.DiaChi = txtDiaChi.Text;

                        //findKh.SoDienThoai = txtSDT.Text.Trim();
                        //findKh.Email = txtEmail.Text;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        qlkh.SubmitChanges();

                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công");
                    }
                }
            }
            load_KH();
            clear_text();
        }



        private void grvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            var findkh = qlkh.KhachHangs.Where(item => item.SoDienThoai == txtTimSDT_KH.Text).FirstOrDefault();
            if (findkh != null)
            {
                txtSDT.Text = findkh.SoDienThoai.ToString();
                txtMaKH.Text = findkh.MaKhachHang.ToString();
                txtHoTen.Text = findkh.HoTen.ToString();
                txtDiaChi.Text = findkh.DiaChi.ToString();
                grvKhachHang.DataSource = new List<KhachHang> { findkh };
            }
            else
            {
                MessageBox.Show("Không tồn tại khách hàng");
            }

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            load_KH();
            clear_text();
            btnSua_KH.Enabled = true;
            btnThem_KH.Enabled = true;
            btnTimKH.Enabled = true;
            txtTimSDT_KH.Enabled = true;
            btnXoa_KH.Enabled = true;

        }

    }
}
