using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public  partial class FQuanLi : Form
    {
        QLShopDataContext qlshop = new QLShopDataContext();
        ValidateHelper val=new ValidateHelper();
        public FQuanLi()
        {
            InitializeComponent();
            Enable_Control_banDau();
            loadDanhmuc();
            loadThuonghieu();
            loadnhanvien();
            loadSanpham();
        }

        void Enable_Control_banDau()
        {
            control_DanhMuc.btnAdd.Enabled = true;
            control_CungUng.btnAdd.Enabled = true;
            control_NCC.btnAdd.Enabled = true;
            control_NhanVien.btnAdd.Enabled = true;
            control_SanPham.btnAdd.Enabled = true;
            control_ThuongHieu.btnAdd.Enabled = true;
            control_DanhMuc.btnEdit.Enabled = true;
            control_DanhMuc.btnCancel.Enabled = true;
            control_DanhMuc.btnDelete.Enabled = true;
            control_ThuongHieu.btnEdit.Enabled = true;
            control_ThuongHieu.btnCancel.Enabled = true;
            control_ThuongHieu.btnDelete.Enabled = true;
            control_NhanVien.btnDelete.Enabled = true;
            control_NhanVien.btnEdit.Enabled = true;
            control_NhanVien.btnCancel.Enabled = true;
            control_SanPham.btnDelete.Enabled = true;
            control_SanPham.btnEdit.Enabled = true;
            control_SanPham.btnCancel.Enabled = true;
        }

        #region quanlidanhmuc
        #region method
        void loadDanhmuc()
        {
            var dm = from d in qlshop.DanhMucs
                     select d;
            grvDanhMuc.DataSource = dm.ToList();
        }
        public string GenerateMaDanhMuc()
        {
            
            var lastCode = qlshop.DanhMucs
                .Where(dm => dm.MaDanhMuc.StartsWith("DM"))
                .OrderByDescending(dm => dm.MaDanhMuc)
                .Select(dm => dm.MaDanhMuc)
                .FirstOrDefault();

            int newNumber = 1;

            if (lastCode != null)
            {
                
                var lastNumber = int.Parse(lastCode.Substring(2)); 
                newNumber = lastNumber + 1;
            }
            return $"DM{newNumber:D2}";
        }
        void searchDm(string tendm)
        {
            var search=qlshop.DanhMucs.Where(dm=>dm.TenDanhMuc.Contains(tendm)).ToList();
            grvDanhMuc.DataSource=search; 
            if(search.Count==0)
            {
                MessageBox.Show("Không tìm thấy danh mục phù hợp");
            }    
        }
        #endregion
        #region sự kiện
        private void tabPage1_Click(object sender, EventArgs e)
        {
            loadDanhmuc();
        }
        private void grvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grvDanhMuc.Rows.Count)
            {
                DataGridViewRow row = grvDanhMuc.Rows[e.RowIndex];
                txtMaDanhMuc.Text = row.Cells["MaDanhMuc"].Value?.ToString() ?? "";
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value?.ToString() ?? "";
            }
        }

        private void control_DanhMuc_Load(object sender, EventArgs e)
        {

        }

        private void control_DanhMuc_BtnAddClicked(object sender, EventArgs e)
        {
            txtMaDanhMuc.Enabled = true;
            txtTenDanhMuc.Enabled = true;
            txtMaDanhMuc.Text = GenerateMaDanhMuc();
            control_DanhMuc.btnSubmit.Enabled = true;
            control_DanhMuc.btnDelete.Enabled = false;
            control_DanhMuc.btnEdit.Enabled = false;
        }

        private void control_DanhMuc_BtnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDanhMuc.Enabled)
                {
                    if (string.IsNullOrEmpty(txtMaDanhMuc.Text) || string.IsNullOrEmpty(txtTenDanhMuc.Text))
                    {
                        MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
                    }
                    else
                    {
                        var exist = qlshop.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == txtMaDanhMuc.Text);
                        if (exist != null)
                        {
                            MessageBox.Show("Mã  đã tồn tại");
                        }
                        else
                        {
                            DanhMuc dm = new DanhMuc();
                            dm.MaDanhMuc = txtMaDanhMuc.Text;
                            dm.TenDanhMuc = txtTenDanhMuc.Text.Trim();
                            qlshop.DanhMucs.InsertOnSubmit(dm);
                            qlshop.SubmitChanges();
                            loadDanhmuc();
                            MessageBox.Show("Thêm Thành danh mục công");
                            txtMaDanhMuc.Clear();
                            txtTenDanhMuc.Clear();
                            txtTenDanhMuc.Enabled = false;
                            txtMaDanhMuc.Enabled = false;
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtMaDanhMuc.Text))
                    {
                        string madm = txtMaDanhMuc.Text.Trim();
                        DanhMuc dm = qlshop.DanhMucs.Where(t => t.MaDanhMuc == madm).FirstOrDefault();
                        dm.TenDanhMuc = txtTenDanhMuc.Text.Trim();
                        qlshop.SubmitChanges();
                        loadDanhmuc();

                        MessageBox.Show("Cập nhật danh mục thành công");
                        txtTenDanhMuc.Enabled = false;
                        txtMaDanhMuc.Clear();
                        txtTenDanhMuc.Clear();
                    }
                }
                control_DanhMuc.btnSubmit.Enabled = false;
                control_DanhMuc.btnDelete.Enabled = true;
                control_DanhMuc.btnEdit.Enabled = true;
                control_DanhMuc.btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void control_DanhMuc_BtnEditClicked(object sender, EventArgs e)
        {
            txtTenDanhMuc.Clear();
            txtTenDanhMuc.Enabled = true;
            control_DanhMuc.btnSubmit.Enabled = true;
            control_DanhMuc.btnDelete.Enabled = false;
            control_DanhMuc.btnAdd.Enabled = false;
        }

        private void control_DanhMuc_BtnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                
                string madm = txtMaDanhMuc.Text.Trim();
                DanhMuc dm = qlshop.DanhMucs.Where(x => x.MaDanhMuc == madm).FirstOrDefault();
                qlshop.DanhMucs.DeleteOnSubmit(dm);
                qlshop.SubmitChanges();
                loadDanhmuc();
                MessageBox.Show("Xóa thành công");
                txtMaDanhMuc.Clear();
                txtTenDanhMuc.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void control_DanhMuc_BtnCancelClicked(object sender, EventArgs e)
        {
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
            txtMaDanhMuc.Enabled = false;
            txtTenDanhMuc.Enabled = false;
            control_DanhMuc.btnAdd.Enabled = true;
            control_DanhMuc.btnDelete.Enabled = true;
            control_DanhMuc.btnEdit.Enabled = true;
            control_DanhMuc.btnSubmit.Enabled = true;
        }

        private void btnTimDM_Click(object sender, EventArgs e)
        {
            string key = txtTimTenDM.Text.Trim();
            if (!string.IsNullOrEmpty(txtTimTenDM.Text))
            {
                searchDm(key);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm");
                loadDanhmuc();
            }
        }
        #endregion

        #endregion



        #region thuonghieu
        #region method
        void loadThuonghieu()
        {
            var thuonghieu = from th in qlshop.ThuongHieus
                             select th;
            grvThuongHieu.DataSource=thuonghieu;
        }
        public string GenerateThuongHieu()
        {

            var lastCode = qlshop.ThuongHieus
                .Where(dm => dm.MaThuongHieu.StartsWith("TH"))
                .OrderByDescending(dm => dm.MaThuongHieu)
                .Select(dm => dm.MaThuongHieu)
                .FirstOrDefault();

            int newNumber = 1;

            if (lastCode != null)
            {

                var lastNumber = int.Parse(lastCode.Substring(2));
                newNumber = lastNumber + 1;
            }
            return $"TH{newNumber:D2}";
        }
        void searchTH(string tenth)
        {
            var search = qlshop.ThuongHieus.Where(dm => dm.TenThuongHieu.Contains(tenth)).ToList();
            grvThuongHieu.DataSource = search;
            if (search.Count == 0)
            {
                MessageBox.Show("Không tìm thấy danh mục phù hợp");
            }
        }
        #endregion

        #region event
        private void grvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grvThuongHieu.Rows.Count)
            {
                DataGridViewRow row = grvThuongHieu.Rows[e.RowIndex];
                txtmathuonghieu.Text = row.Cells["MaTH"].Value?.ToString() ?? "";
                txttenthuonghieu.Text = row.Cells["TenTH"].Value?.ToString() ?? "";
            }
        }

        private void control_ThuongHieu_BtnAddClicked(object sender, EventArgs e)
        {
            txtmathuonghieu.Enabled = true;
            txttenthuonghieu.Enabled = true;
            txttenthuonghieu.Clear();
            txtmathuonghieu.Text = GenerateThuongHieu();
            control_ThuongHieu.btnSubmit.Enabled = true;
            control_ThuongHieu.btnEdit.Enabled = false;
            control_ThuongHieu.btnDelete.Enabled=false;
        }

        private void control_ThuongHieu_BtnEditClicked(object sender, EventArgs e)
        {
            txttenthuonghieu.Enabled = true;
            txttenthuonghieu.Clear();
            control_ThuongHieu.btnSubmit.Enabled = true;
            control_ThuongHieu.btnAdd.Enabled = false;
            control_ThuongHieu.btnDelete.Enabled = false;
        }

        private void control_ThuongHieu_BtnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                if (txtmathuonghieu.Enabled)
                {
                    if (string.IsNullOrEmpty(txtmathuonghieu.Text) || string.IsNullOrEmpty(txttenthuonghieu.Text))
                    {
                        MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
                    }
                    else
                    {
                        var exist = qlshop.ThuongHieus.FirstOrDefault(x => x.MaThuongHieu == txtmathuonghieu.Text);
                        if (exist != null)
                        {
                            MessageBox.Show("Mã  đã tồn tại");
                        }
                        else
                        {
                            ThuongHieu th = new ThuongHieu();
                            th.MaThuongHieu = txtmathuonghieu.Text;
                            th.TenThuongHieu = txttenthuonghieu.Text.Trim();
                            qlshop.ThuongHieus.InsertOnSubmit(th);
                            qlshop.SubmitChanges();
                            loadThuonghieu();
                            MessageBox.Show("Thêm Thương hiệu thành công");
                            txtmathuonghieu.Clear();
                            txttenthuonghieu.Clear();
                            txttenthuonghieu.Enabled = false;
                            txtmathuonghieu.Enabled = false;
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtmathuonghieu.Text))
                    {
                        string math = txtmathuonghieu.Text.Trim();
                        ThuongHieu th = qlshop.ThuongHieus.Where(t => t.MaThuongHieu == math).FirstOrDefault();
                        th.TenThuongHieu = txttenthuonghieu.Text.Trim();
                        qlshop.SubmitChanges();
                        loadThuonghieu();

                        MessageBox.Show("Cập nhật thương hiệu thành công");
                        txttenthuonghieu.Enabled = false;
                        txtmathuonghieu.Clear();
                        txttenthuonghieu.Clear();
                    }
                }
                control_ThuongHieu.btnSubmit.Enabled = false;
                control_ThuongHieu.btnEdit.Enabled = true;
                control_ThuongHieu.btnDelete.Enabled = true;
                control_ThuongHieu.btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void control_ThuongHieu_BtnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                string math = txtmathuonghieu.Text.Trim();
                ThuongHieu th = qlshop.ThuongHieus.Where(x => x.MaThuongHieu == math).FirstOrDefault();
                qlshop.ThuongHieus.DeleteOnSubmit(th);
                qlshop.SubmitChanges();
                loadThuonghieu();
                MessageBox.Show("Xóa thành công");
                txtmathuonghieu.Clear();
                txttenthuonghieu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void control_ThuongHieu_BtnCancelClicked(object sender, EventArgs e)
        {
            txtmathuonghieu.Clear();
            txttenthuonghieu.Clear();
            txtmathuonghieu.Enabled = false;
            control_ThuongHieu.btnEdit.Enabled = true;
            control_ThuongHieu.btnDelete.Enabled = true;
            control_ThuongHieu.btnAdd.Enabled = true;
        }

        private void btnTim_TH_Click(object sender, EventArgs e)
        {
            string key = txtTimTen_TH.Text.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                searchTH(key);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm");
                loadThuonghieu();
            }
        }
        #endregion

        #endregion

        #region Nhanvien
        #region method
        void loadnhanvien()
        {
            var nv = from nhanvien in qlshop.NhanViens
                     select new {
                         nhanvien.MaNhanVien,
                         nhanvien.HoTen,
                         nhanvien.SoDienThoai,
                         nhanvien.SoCMND,
                         nhanvien.Email,
                         nhanvien.DiaChi,
                         nhanvien.MaLoaiTaiKhoan,
                         nhanvien.MaChucVu
                     };
            grvNhanVien.DataSource= nv;
            loadcbchucvu();
            loadcbloaiTk();
        }
        public string GenerateNhanVien()
        {

            var lastCode = qlshop.NhanViens
                .Where(dm => dm.MaNhanVien.StartsWith("NV"))
                .OrderByDescending(dm => dm.MaNhanVien)
                .Select(dm => dm.MaNhanVien)
                .FirstOrDefault();

            int newNumber = 1;

            if (lastCode != null)
            {

                var lastNumber = int.Parse(lastCode.Substring(2));
                newNumber = lastNumber + 1;
            }
            return $"NV{newNumber:D2}";
        }
        void searchNV(string manv)
        {
            var search = qlshop.NhanViens.Where(dm => dm.MaNhanVien.ToString()==manv).ToList();
            grvNhanVien.DataSource = search;
            if (search.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
            }
        }
        void loadcbchucvu ()
        {
            var chucvu = from cv in qlshop.ChucVus select cv;
            cboChucVu.DataSource = chucvu;
            cboChucVu.ValueMember = "MaChucVu";
            cboChucVu.DisplayMember = "TenChucVu";
        }

        void loadcbloaiTk()
        {
            var taikhoan = from tk in qlshop.LoaiTaiKhoans select tk;
            cboLoaiTK.DataSource= taikhoan;
            cboLoaiTK.ValueMember = "MaLoaiTaiKhoan";
            cboLoaiTK.DisplayMember = "TenLoaiTaiKhoan";
        }
        #endregion

        #region event
        private void control_NhanVien_BtnAddClicked(object sender, EventArgs e)
        {
            txtMaNV.Enabled=true;
            txtMaNV.Text = GenerateNhanVien();
            control_NhanVien.btnSubmit.Enabled = true;
            control_NhanVien.btnEdit.Enabled = false;
            control_NhanVien.btnDelete.Enabled = false;

        }

        private void control_NhanVien_BtnCancelClicked(object sender, EventArgs e)
        {
            control_NhanVien.btnEdit.Enabled = true;
            control_NhanVien.btnDelete.Enabled = true;
            control_NhanVien.btnAdd.Enabled = true;
            control_NhanVien.btnSubmit.Enabled = false;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtCCCD.Clear();
            txtSDT_NV.Clear();
            txtEmail_NV.Clear();
            txtDiaChi_NV.Clear();
        }

        private void control_NhanVien_BtnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text.Trim();
                NhanVien nv = qlshop.NhanViens.Where(x => x.MaNhanVien == manv).FirstOrDefault();
                qlshop.NhanViens.DeleteOnSubmit(nv);
                qlshop.SubmitChanges();
                loadnhanvien();
                MessageBox.Show("Xóa thành công");
                txtMaNV.Clear();
                txtTenNV.Clear();
                txtSDT_NV.Clear();
                txtCCCD.Clear();
                txtDiaChi_NV.Clear();
                txtEmail_NV.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void control_NhanVien_BtnEditClicked(object sender, EventArgs e)
        {
            
            
            control_NhanVien.btnSubmit.Enabled = true;
          
            control_NhanVien.btnDelete.Enabled = false;
            control_NhanVien.btnAdd.Enabled = false;
        }

        private void control_NhanVien_BtnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Enabled)
                {
                    if (string.IsNullOrEmpty(txtSDT_NV.Text) || string.IsNullOrEmpty(txtTenNV.Text))
                    {
                        MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
                    }
                    else
                    {
                        var exist = qlshop.NhanViens.FirstOrDefault(x => x.MaNhanVien == txtMaNV.Text);
                        if (exist != null)
                        {
                            MessageBox.Show("Mã  đã tồn tại");
                        }
                        else
                        {
                            NhanVien nv = new NhanVien();
                            if (!val.IsValidPhoneNumber(txtSDT_NV.Text))
                            {
                                MessageBox.Show("Số điện thoại không hợp lệ.");
                                return;
                            }

                            if (!val.IsValidCCCD(txtCCCD.Text))
                            {
                                MessageBox.Show("Số CCCD không hợp lệ.");
                                return;
                            }

                            if (!val.IsValidEmail(txtEmail_NV.Text))
                            {
                                MessageBox.Show("Email không hợp lệ.");
                                return;
                            }
                            nv.MaNhanVien=txtMaNV.Text;
                            nv.HoTen = txtTenNV.Text.Trim();
                            nv.SoDienThoai = txtSDT_NV.Text.Trim();
                            nv.Email=txtEmail_NV.Text.Trim();
                            nv.DiaChi = txtDiaChi_NV.Text.Trim();
                            nv.SoCMND=txtCCCD.Text.Trim();
                            nv.MatKhau = "12345678";
                            nv.MaLoaiTaiKhoan=cboLoaiTK.SelectedValue.ToString();
                            nv.MaChucVu=cboChucVu.SelectedValue.ToString();
                            qlshop.NhanViens.InsertOnSubmit(nv);
                            qlshop.SubmitChanges();
                            loadnhanvien();
                            MessageBox.Show("Thêm nhân viên thành công");
                            txtMaNV.Clear();
                            txtTenNV.Clear();
                            txtSDT_NV.Clear();
                            txtCCCD.Clear();
                            txtDiaChi_NV.Clear();
                            txtEmail_NV.Clear();
                            txtMaNV.Enabled = false;
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtMaNV.Text))
                    {
                        string manv = txtMaNV.Text.Trim();
                        NhanVien nv = qlshop.NhanViens.Where(t => t.MaNhanVien == manv).FirstOrDefault();
                        if (!val.IsValidPhoneNumber(txtSDT_NV.Text))
                        {
                            MessageBox.Show("Số điện thoại không hợp lệ.");
                            return;
                        }

                        if (!val.IsValidCCCD(txtCCCD.Text))
                        {
                            MessageBox.Show("Số CCCD không hợp lệ.");
                            return;
                        }

                        if (!val.IsValidEmail(txtEmail_NV.Text))
                        {
                            MessageBox.Show("Email không hợp lệ.");
                            return;
                        }
                      
                        nv.HoTen = txtTenNV.Text.Trim();
                        nv.SoDienThoai = txtSDT_NV.Text.Trim();
                        nv.Email = txtEmail_NV.Text.Trim();
                        nv.DiaChi = txtDiaChi_NV.Text.Trim();
                        nv.SoCMND = txtCCCD.Text.Trim();
                        nv.MatKhau = "12345678";
                        nv.MaLoaiTaiKhoan = cboLoaiTK.SelectedValue.ToString() ;
                        nv.MaChucVu = cboChucVu.SelectedValue.ToString();
                        qlshop.SubmitChanges();
                        loadnhanvien();

                        MessageBox.Show("Cập nhật nhân viên thành công");
                        txtMaNV.Clear();
                        txtTenNV.Clear();
                        txtSDT_NV.Clear();
                        txtCCCD.Clear();
                        txtDiaChi_NV.Clear();
                        txtEmail_NV.Clear();
                    }
                }
                control_NhanVien.btnSubmit.Enabled = false;
                control_NhanVien.btnEdit.Enabled = true;
                control_NhanVien.btnDelete.Enabled = true;
                control_NhanVien.btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grvNhanVien.Rows.Count)
            {
                DataGridViewRow row = grvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                txtTenNV.Text = row.Cells["TenNV"].Value?.ToString() ?? "";
                txtSDT_NV.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                txtEmail_NV.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtDiaChi_NV.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
                cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString() ?? "";
                cboLoaiTK.Text = row.Cells["LoaiTK"].Value?.ToString() ?? "";
            }
        }

        private void btnTim_NV_Click(object sender, EventArgs e)
        {
            string key = txtTimNV.Text;
            if (!string.IsNullOrEmpty(key))
            {
                searchNV(key);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm");
                loadnhanvien();
            }
        }
        private void txtSDT_NV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #endregion

        #region sanpham
        #region method
        void loadSanpham()
        {
            var sanpham = from sp in qlshop.SanPhams 
                          select new {
                              sp.MaSanPham,
                              sp.TenSanPham,
                              sp.MaDanhMuc,
                              sp.MaThuongHieu,
                              sp.MoTa,
                              sp.Gia,
                              sp.TonKho,
                              sp.Size,
                              sp.MauSac,
                              sp.HinhAnh
            };
            grvSanPham.DataSource= sanpham;
            loadcbThuonghieu();
            loadcbDanhmuc();
        }
        void loadcbThuonghieu()
        {
            var thuonghieu= from th in qlshop.ThuongHieus select th;
            cboThuongHieu.DataSource= thuonghieu;
            cboThuongHieu.DisplayMember = "TenThuongHieu";
            cboThuongHieu.ValueMember = "MaThuongHieu";
        }
        void loadcbDanhmuc()
        {
            var danhmuc = from dm in qlshop.DanhMucs select dm;
            cboDanhMuc.DataSource=danhmuc;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
        }
        public string GenerateSanpham()
        {

            var lastCode = qlshop.SanPhams
                .Where(dm => dm.MaSanPham.StartsWith("SP"))
                .OrderByDescending(dm => dm.MaSanPham)
                .Select(dm => dm.MaSanPham)
                .FirstOrDefault();

            int newNumber = 1;

            if (lastCode != null)
            {

                var lastNumber = int.Parse(lastCode.Substring(2));
                newNumber = lastNumber + 1;
            }
            return $"SP{newNumber:D2}";
        }
        void searchSP(string tenth)
        {
            var search = qlshop.SanPhams.Where(dm => dm.MaSanPham.ToString()==txtTimSP.Text).ToList();
            grvSanPham.DataSource = search;
            if (search.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp");
            }
        }
        #endregion

        #region event
        private void btnTimSP_Click(object sender, EventArgs e)
        {
            string key = txtTimSP.Text.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                searchSP(key);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm");
                loadSanpham();
            }
        }

        #endregion

        #endregion

        private void control_SanPham_BtnAddClicked(object sender, EventArgs e)
        {
            txtMaSP.Text = this.GenerateSanpham();
            txtMaSP.Enabled=true;
            control_SanPham.btnSubmit.Enabled = true;
            control_SanPham.btnEdit.Enabled = false;
            control_SanPham.btnDelete.Enabled = false;
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private string imageLocation = "";
       
        private void btnThemHinh_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();

          
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Chọn hình ảnh";

            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imageLocation = openFileDialog.FileName;
                    // Load hình ảnh vào PictureBox
                    picHinhAnh.Image = Image.FromFile(openFileDialog.FileName);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi load hình: " + ex.Message, "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void control_SanPham_BtnSubmitClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
                return;
            }

            try
            {
                // Đường dẫn đến thư mục Images trong project
                string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string imagesPath = Path.Combine(projectDirectory, "Images");

                // Tạo thư mục Images nếu chưa có
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }

                string fileName = "";
                if (!string.IsNullOrEmpty(imageLocation))
                {
                    // Tạo tên file mới
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageLocation);
                    string savedPath = Path.Combine(imagesPath, fileName);
                    // Copy file hình vào thư mục Images
                    File.Copy(imageLocation, savedPath, true);
                }

                if (txtMaSP.Enabled) // Thêm mới
                {
                    var exist = qlshop.SanPhams.FirstOrDefault(x => x.MaSanPham == txtMaSP.Text);
                    if (exist != null)
                    {
                        MessageBox.Show("Mã đã tồn tại");
                        return;
                    }

                    SanPham sp = new SanPham();
                    sp.MaSanPham = txtMaSP.Text;
                    sp.TenSanPham = txtTenSP.Text.Trim();
                    sp.MoTa = txtMoTa.Text.Trim();
                    sp.Gia = Decimal.Parse(txtGiaBan.Text);
                    sp.Size = Decimal.Parse(txtSize.Text);
                    sp.MauSac = txtMau.Text.Trim();
                    sp.MaThuongHieu = cboThuongHieu.SelectedValue.ToString();
                    sp.MaDanhMuc = cboDanhMuc.SelectedValue.ToString();
                    sp.HinhAnh = !string.IsNullOrEmpty(fileName) ? "Images\\" + fileName : null;

                    qlshop.SanPhams.InsertOnSubmit(sp);
                    qlshop.SubmitChanges();
                    MessageBox.Show("Thêm Sản phẩm thành công");
                }
                else 
                {
                    var sp = qlshop.SanPhams.FirstOrDefault(x => x.MaSanPham == txtMaSP.Text);
                    if (sp != null)
                    {
                        sp.TenSanPham = txtTenSP.Text.Trim();
                        sp.MoTa = txtMoTa.Text.Trim();
                        sp.Gia = Decimal.Parse(txtGiaBan.Text);
                        sp.Size = Decimal.Parse(txtSize.Text);
                        sp.MauSac = txtMau.Text.Trim();
                        sp.MaThuongHieu = cboThuongHieu.SelectedValue.ToString();
                        sp.MaDanhMuc = cboDanhMuc.SelectedValue.ToString();

                        
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            
                            if (!string.IsNullOrEmpty(sp.HinhAnh))
                            {
                                string oldImagePath = Path.Combine(projectDirectory, sp.HinhAnh);
                                if (File.Exists(oldImagePath))
                                {
                                    try
                                    {
                                        File.Delete(oldImagePath);
                                    }
                                    catch { } 
                                }
                            }
                            sp.HinhAnh = "Images\\" + fileName;
                        }

                        qlshop.SubmitChanges();
                        MessageBox.Show("Cập nhật Sản phẩm thành công");
                    }
                }

               
                loadSanpham();
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtGiaBan.Clear();
                txtSize.Clear();
                txtMau.Clear();
                txtMoTa.Clear();
                picHinhAnh.Image = null;
                imageLocation = "";
                txtMaSP.Enabled = false;
                control_SanPham.btnAdd.Enabled = true;
                control_SanPham.btnSubmit.Enabled = false;
                control_SanPham.btnEdit.Enabled = true;
                control_SanPham.btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void grvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grvSanPham.Rows.Count)
            {
                DataGridViewRow row = grvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value?.ToString() ?? "";
                txtTenSP.Text = row.Cells["TenSP"].Value?.ToString() ?? "";
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
                txtGiaBan.Text = row.Cells["Gia"].Value?.ToString() ?? "";
                txtSize.Text = row.Cells["Size"].Value?.ToString() ?? "";
                txtMau.Text = row.Cells["MauSac"].Value?.ToString() ?? "";
                cboThuongHieu.Text = row.Cells["ThuongHieu"].Value?.ToString() ?? "";
                cboDanhMuc.Text = row.Cells["DanhMuc"].Value?.ToString() ?? "";

                // Hiển thị hình ảnh
                string hinhAnh = row.Cells["HinhAnh"].Value?.ToString();
                if (!string.IsNullOrEmpty(hinhAnh))
                {
                    try
                    {
                        string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                        string imagePath = Path.Combine(projectDirectory, hinhAnh);
                        if (File.Exists(imagePath))
                        {
                            picHinhAnh.Image = Image.FromFile(imagePath);
                            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            picHinhAnh.Image = null;
                        }
                    }
                    catch
                    {
                        picHinhAnh.Image = null;
                    }
                }
                else
                {
                    picHinhAnh.Image = null;
                }

                
                
            }
        }

        private void control_SanPham_BtnEditClicked(object sender, EventArgs e)
        {
            control_SanPham.btnSubmit.Enabled = true;
            control_SanPham.btnAdd.Enabled = false;
            control_SanPham.btnDelete.Enabled = false;
        }

        private void control_SanPham_BtnDeleteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            try
            {
               
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                   
                    var sp = qlshop.SanPhams.FirstOrDefault(x => x.MaSanPham == txtMaSP.Text);
                    if (sp != null)
                    {
                        
                        if (!string.IsNullOrEmpty(sp.HinhAnh))
                        {
                            string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                            string imagePath = Path.Combine(projectDirectory, sp.HinhAnh);
                            if (File.Exists(imagePath))
                            {
                                try
                                {
                                    File.Delete(imagePath);
                                }
                                catch { } 
                            }
                        }

                       
                        qlshop.SanPhams.DeleteOnSubmit(sp);
                        qlshop.SubmitChanges();

                      
                        loadSanpham();
                        txtMaSP.Clear();
                        txtTenSP.Clear();
                        txtGiaBan.Clear();
                        txtSize.Clear();
                        txtMau.Clear();
                        txtMoTa.Clear();
                        picHinhAnh.Image = null;
                        imageLocation = "";
                        txtMaSP.Enabled = false;

                        MessageBox.Show("Xóa sản phẩm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                
                if (ex.Message.Contains("foreign key"))
                {
                    MessageBox.Show("Không thể xóa sản phẩm này vì đang được sử dụng ở nơi khác!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
                }
            }
        }
    }
}
