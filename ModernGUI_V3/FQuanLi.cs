using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public  partial class FQuanLi : Form
    {
        QLShopDataContext qlshop = new QLShopDataContext();
        ValidateHelper val=new ValidateHelper();
        QLShopDataContext qlss = new QLShopDataContext();
        List<NhaCungCap> List_NCC = new List<NhaCungCap>();
        QLShopDataContext qlkm = new QLShopDataContext();

        public FQuanLi()
        {
            InitializeComponent();
            Enable_Control_banDau();
            loadDanhmuc();
            loadThuonghieu();
            loadnhanvien();
            loadSanpham();
            load_grvNCC();
            load_KM();
            Enable_KM();
        }

        void Enable_Control_banDau()
        {
            // Danh mục
            control_DanhMuc.btnAdd.Enabled = true;

            // Cung ứng
            control_CungUng.btnAdd.Enabled = true;

            // Nhà cung cấp
            control_NCC.btnAdd.Enabled = true;
            control_NCC.btnDelete.Enabled = true;
            control_NCC.btnEdit.Enabled = true;

            // Nhân viên
            control_NhanVien.btnAdd.Enabled = true;

            // Sản phẩm
            control_SanPham.btnAdd.Enabled = true;

            // Thương hiệu
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

        #region KhuyenMai
        void Enable_KM()
        {
            control_KM.btnAdd.Enabled = true;
            control_KM.btnEdit.Enabled = true;
            control_KM.btnDelete.Enabled = true;
            control_KM.btnSubmit.Enabled = false;
            control_KM.btnCancel.Enabled = true;
            control_KM.btnClose.Enabled = false;
        }

        void on_txtKM()
        {
            txt_TenPKM.Enabled = true;
            txt_GiamGia.Enabled = true;
            txt_LoaiGiaGiam.Enabled = true;
        }

        int flag_km = 0;
        private void control_KM_BtnAddClicked(object sender, EventArgs e)
        {
            tao_MaKH();
            control_KM.btnCancel.Enabled = true;
            control_KM.btnSubmit.Enabled = true;
            control_KM.btnClose.Enabled = true;
            on_txtKM();
            control_KM.btnEdit.Enabled = false;
            control_KM.btnDelete.Enabled = false;
            flag_km = 1;
        }

        private void them_KM()
        {
            try
            {
                // Kiểm tra tất cả các trường đầu vào có được điền hay chưa
                if (string.IsNullOrEmpty(txt_GiamGia.Text) ||
                    string.IsNullOrEmpty(txt_LoaiGiaGiam.Text) ||
                    string.IsNullOrEmpty(txt_TenPKM.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                PhieuGiamGia pgg = new PhieuGiamGia();
                pgg.MaPhieuGiamGia = txt_MaKM.Text;
                pgg.TenPhieuGiamGia = txt_TenPKM.Text;
                if (!decimal.TryParse(txt_GiamGia.Text, out decimal giaTri))
                {
                    MessageBox.Show("Giá trị giảm giá phải là số hợp lệ.");
                    return;
                }
                pgg.GiaTri = giaTri;

                pgg.LoaiGiamGia = txt_LoaiGiaGiam.Text;
                if (dateNgayBatDau.Value > dateNgayKetThuc.Value)
                {
                    MessageBox.Show("Ngày không hợp lệ. Ngày kết thúc phải lớn hơn ngày bắt đầu.");
                    return;
                }

                pgg.NgayBatDau = dateNgayBatDau.Value;
                pgg.NgayKetThuc = dateNgayKetThuc.Value;

                // Thêm phiếu giảm giá vào cơ sở dữ liệu
                qlkm.PhieuGiamGias.InsertOnSubmit(pgg);
                qlkm.SubmitChanges();
                MessageBox.Show("Tạo phiếu khuyến mãi thành công");
            }
            catch (Exception ex)
            {
                // Hiển thị chi tiết lỗi cho người dùng
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void tao_MaKH()
        {
            DateTime ngayHienTai = DateTime.Today;
            var slpn = qlkm.PhieuGiamGias.Count(item =>
                item.NgayBatDau.HasValue && item.NgayBatDau.Value.Date == ngayHienTai);
            slpn += 1;
            txt_MaKM.Text = "KM" + DateTime.Today.ToString("ddMMyyyy") + slpn.ToString("D3");
        }

        private void load_KM()
        {
            var allKm = from km in qlkm.PhieuGiamGias
                        select new
                        {
                            MaPhieuGiamGia = km.MaPhieuGiamGia,
                            LoaiGiamGia = km.LoaiGiamGia,
                            GiaTri = km.GiaTri,
                            NgayBatDau = km.NgayBatDau,
                            NgayKetThuc = km.NgayKetThuc,
                            TenPhieuGiamGia = km.TenPhieuGiamGia
                        };
            grv_KM.DataSource = allKm;
        }

        private void clear_txtKM()
        {
            txt_MaKM.Clear();
            txt_GiamGia.Clear();
            txt_findMKM.Clear();
            txt_TenPKM.Clear();

        }
        private void control_KM_BtnSubmitClicked(object sender, EventArgs e)
        {
            if (flag_km == 1)
            {
                them_KM();
            }
            else
            {
                edit_KM();
            }
            Enable_KM();
            load_KM();
            clear_txtKM();

        }

        private void btn_timMKM_Click(object sender, EventArgs e)
        {
            var x = qlkm.PhieuGiamGias.Where(item => item.MaPhieuGiamGia == txt_findMKM.Text).FirstOrDefault();
            if (x != null)
            {
                txt_MaKM.Text = x.MaPhieuGiamGia.ToString();
                txt_TenPKM.Text = x.TenPhieuGiamGia.ToString();
                txt_GiamGia.Text = x.GiaTri.Value.ToString();
                dateNgayBatDau.Value = x.NgayBatDau.Value;
                dateNgayKetThuc.Value = x.NgayKetThuc.Value;
            }
            else
            {
                MessageBox.Show("Không tồn tại phiếu giảm giá");
            }

        }

        private void txt_GiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void control_KM_BtnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_MaKM.Text))
                {
                    var findKh = qlkm.PhieuGiamGias.Where(item => item.MaPhieuGiamGia == txt_MaKM.Text).FirstOrDefault();
                    if (findKh != null)
                    {

                        qlkm.PhieuGiamGias.DeleteOnSubmit(findKh);
                        qlkm.SubmitChanges();
                        MessageBox.Show("Xóa phiếu khuyến mãi thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!");
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn mã");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được");
            }
            load_KM();
            clear_txtKM();
        }

        private void grv_KM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txt_MaKM.Text = grv_KM.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_TenPKM.Text = grv_KM.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_GiamGia.Text = grv_KM.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateNgayBatDau.Text = grv_KM.Rows[e.RowIndex].Cells[3].Value.ToString();
                dateNgayKetThuc.Text = grv_KM.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void control_KM_BtnCancelClicked(object sender, EventArgs e)
        {
            clear_txtKM();
            Enable_KM();
        }

        private void control_KM_BtnEditClicked(object sender, EventArgs e)
        {
            dateNgayBatDau.Enabled = false;
            txt_TenPKM.Enabled = false;
            txt_GiamGia.Enabled = true;
            control_KM.btnCancel.Enabled = true;
            control_KM.btnCancel.Enabled = true;
            control_KM.btnSubmit.Enabled = true;
            control_KM.btnClose.Enabled = true;
            control_KM.btnAdd.Enabled = false;
            control_KM.btnDelete.Enabled = false;
            flag_km = 2;

        }

        private void edit_KM()
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_MaKM.Text))
                {

                    var findKh = qlkm.PhieuGiamGias.Where(item => item.MaPhieuGiamGia == txt_MaKM.Text).FirstOrDefault();
                    if (findKh != null)
                    {

                        findKh.NgayKetThuc = dateNgayKetThuc.Value;
                        findKh.GiaTri = decimal.Parse(txt_GiamGia.Text);
                        qlkm.SubmitChanges();
                        MessageBox.Show("Cập nhật thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khuyến mãi");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void control_KM_BtnCloseClicked(object sender, EventArgs e)
        {

        }
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

        #region nhà cung cấp

        void load_grvNCC()
        {
            var tbl_ncc = from ncc in qlss.NhaCungCaps select ncc;
            List_NCC = tbl_ncc.ToList();
            grvNCC.DataSource = List_NCC;
        }

        private void btnTimTenNCC_NCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimTen_NCC.Text.Trim()))
            {
                load_grvNCC();
            }
            else
            {
                var Tim_NCC = qlss.NhaCungCaps
                                .Where(t => t.TenNhaCungCap.ToLower().Contains(txtTimTen_NCC.Text.ToLower()))
                                .ToList();
                if (Tim_NCC != null)
                {
                    grvNCC.DataSource = Tim_NCC;
                }
            }
        }

        void enable_control_NCC(bool x)
        {
            control_NCC.btnAdd.Enabled = !x;
            control_NCC.btnDelete.Enabled = !x;
            control_NCC.btnEdit.Enabled = !x;
            control_NCC.btnCancel.Enabled = x;
            control_NCC.btnClose.Enabled = x;
            control_NCC.btnSubmit.Enabled = x;
        }

        bool flag = true;
        private string TaoMaNCC()
        {
            var lastRow = grvNCC.Rows.Cast<DataGridViewRow>()
                                .Where(row => row.Cells["MaNhaCungCap"].Value != null)
                                .OrderByDescending(row => row.Cells["MaNhaCungCap"].Value.ToString())
                                .FirstOrDefault();

            int nextNumber = 1;
            if (lastRow != null)
            {
                string lastCode = lastRow.Cells["MaNhaCungCap"].Value.ToString();
                string numberPart = lastCode.Substring(3); 
                if (int.TryParse(numberPart, out nextNumber))
                {
                    nextNumber++;
                }
            }

            return "NCC" + nextNumber.ToString("D2");
        }


        private void control_NCC_BtnAddClicked(object sender, EventArgs e)
        {
            txtMaNCC.Text = TaoMaNCC();

            txtTenNCC.Focus();
            string maNCC = txtMaNCC.Text.Trim();
            string tenNCC = txtTenNCC.Text.Trim();
            string diaChiNCC = txtDiaChi_NCC.Text.Trim();
            string sdtNCC = txtDT_NCC.Text.Trim();
            string emailNCC = txtEmail_NCC.Text.Trim();

            if (flag)
                flag = false;
            else
            {
                if (string.IsNullOrEmpty(maNCC) || string.IsNullOrEmpty(tenNCC) || string.IsNullOrEmpty(emailNCC) ||
                    string.IsNullOrEmpty(diaChiNCC) || string.IsNullOrEmpty(sdtNCC))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                }
                else
                {
                    NhaCungCap newNCC = new NhaCungCap
                    {
                        MaNhaCungCap = maNCC,
                        TenNhaCungCap = tenNCC,
                        Diachi = diaChiNCC,
                        DienThoai = sdtNCC,
                        Email = emailNCC
                    };

                    List_NCC.Add(newNCC);
                    grvNCC.DataSource = List_NCC.ToList();
                    clear_txtbox();
                    txtMaNCC.Text = TaoMaNCC();
                }
            }
            enable_control_NCC(true);
            control_NCC.btnAdd.Enabled = true;
            enable_txtbox(true);
        }

        int rowIndex = 0;
        private void control_NCC_BtnDeleteClicked(object sender, EventArgs e)
        {
            string MaNCC = txtMaNCC.Text;
            NhaCungCap ncc = List_NCC.FirstOrDefault(t => t.MaNhaCungCap == MaNCC);
            if (ncc != null)
            {
                List_NCC.Remove(ncc);

                grvNCC.DataSource = List_NCC.ToList();

                MessageBox.Show("Xóa thành công!");
                enable_control_NCC(true);
                control_NCC.btnDelete.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng muốn xóa!");
            }
        }

        private void control_NCC_BtnEditClicked(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text.Trim();
            string tenNCC = txtTenNCC.Text.Trim();
            string diaChiNCC = txtDiaChi_NCC.Text.Trim();
            string sdtNCC = txtDT_NCC.Text.Trim();
            string emailNCC = txtEmail_NCC.Text.Trim();

            enable_control_NCC(true);
            control_NCC.btnEdit.Enabled = true;
            enable_txtbox(true);
            txtMaNCC.Enabled = false;

            if (flag)
                flag = false;
            else
            {
                if (string.IsNullOrEmpty(maNCC) || string.IsNullOrEmpty(tenNCC) || string.IsNullOrEmpty(diaChiNCC) ||
                string.IsNullOrEmpty(sdtNCC) || string.IsNullOrEmpty(emailNCC))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                }

                NhaCungCap ncc = List_NCC.FirstOrDefault(t => t.MaNhaCungCap == maNCC);
                if (ncc != null)
                {
                    ncc.TenNhaCungCap = tenNCC;
                    ncc.Diachi = diaChiNCC;
                    ncc.DienThoai = sdtNCC;
                    ncc.Email = emailNCC;

                    grvNCC.DataSource = List_NCC.ToList();

                    MessageBox.Show("Sửa thành công!");
                    clear_txtbox();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công");
                }
            }
        }


        void enable_txtbox(bool x)
        {
            txtTenNCC.Enabled = x;
            txtDiaChi_NCC.Enabled = x;
            txtDT_NCC.Enabled = x;
            txtEmail_NCC.Enabled = x;
        }

        void clear_txtbox()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi_NCC.Clear();
            txtDT_NCC.Clear();
            txtEmail_NCC.Clear();
        }

        private void control_NCC_BtnCancelClicked(object sender, EventArgs e)
        {
            clear_txtbox();
        }

        private void control_NCC_BtnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                if (control_NCC.btnAdd.Enabled)
                {
                    foreach (var NCC in List_NCC)
                    {
                        var existingNCC = qlss.NhaCungCaps.Where(t => t.MaNhaCungCap == NCC.MaNhaCungCap).FirstOrDefault();
                        if (existingNCC == null)
                        {
                            qlss.NhaCungCaps.InsertOnSubmit(NCC);
                        }
                    }
                }
                if (control_NCC.btnDelete.Enabled)
                {
                    List<NhaCungCap> allNCC = qlss.NhaCungCaps.ToList();
                    foreach (var NCC in allNCC)
                    {
                        bool existingNCC = List_NCC.Any(t => t.MaNhaCungCap == NCC.MaNhaCungCap);
                        if (!existingNCC)
                        {
                            qlss.NhaCungCaps.DeleteOnSubmit(NCC);
                        }
                    }
                }
                if(control_NCC.btnEdit.Enabled)
                {


                }

                qlss.SubmitChanges();
                MessageBox.Show("Lưu thành công");

                load_grvNCC();
                clear_txtbox();
                enable_control_NCC(false);
                enable_txtbox(false);
                flag = true;
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

        private void control_NCC_BtnCloseClicked(object sender, EventArgs e)
        {
            clear_txtbox();
            enable_txtbox(false);
            enable_control_NCC(false);
            flag = true;
        }

        private void grvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    rowIndex = grvNCC.SelectedRows[0].Index;
                    DataGridViewRow row = grvNCC.Rows[e.RowIndex];
                    txtMaNCC.Text = row.Cells["MaNhaCungCap"].Value.ToString();
                    txtTenNCC.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                    txtDiaChi_NCC.Text = row.Cells["DiaChi_NCC"].Value.ToString();
                    txtEmail_NCC.Text = row.Cells["Email_NCC"].Value.ToString();
                    txtDT_NCC.Text = row.Cells["DienThoai"].Value.ToString();
                }
            }
            catch
            {
                
            }
        }

        #endregion

    }
}
