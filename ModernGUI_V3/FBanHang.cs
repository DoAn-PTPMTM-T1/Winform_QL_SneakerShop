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
    public partial class FBanHang : Form
    {
        QLShopDataContext qlshop = new QLShopDataContext();
        public FBanHang()
        {
            InitializeComponent();
            loadHTTT();
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

        void loadHTTT()
        {
            var ht = from h in qlshop.HinhThucThanhToans
                     select h;
            cboHinhThucThanhToan.DataSource = ht;
            cboHinhThucThanhToan.DisplayMember= "TenHinhThuc";
            cboHinhThucThanhToan.ValueMember = "MaHinhThuc";
        }
        private Dictionary<string, int> tempStock = new Dictionary<string, int>();

        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    
                    var sanpham = (from sp in qlshop.SanPhams
                                   where sp.MaSanPham == txtMaSP.Text
                                   select sp).FirstOrDefault();

                    if (sanpham != null)
                    {
                       
                        txtTenSP.Text = sanpham.TenSanPham;
                        txtDonGia.Text = sanpham.Gia.ToString();
                        txtTonKho.Text = sanpham.TonKho.ToString();

                        if (!tempStock.ContainsKey(sanpham.MaSanPham))
                        {
                            tempStock[sanpham.MaSanPham] = int.Parse(sanpham.TonKho.ToString());
                        }

                        // Luôn cập nhật tồn kho từ tempStock
                        txtTonKho.Text = tempStock[sanpham.MaSanPham].ToString();
                        if (!string.IsNullOrEmpty(sanpham.HinhAnh))
                        {
                            try
                            {
                                string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                                string imagePath = Path.Combine(projectDirectory, sanpham.HinhAnh);

                                if (File.Exists(imagePath))
                                {
                                    // Giải phóng hình ảnh cũ nếu có
                                    if (picHinhAnh.Image != null)
                                    {
                                        picHinhAnh.Image.Dispose();
                                        picHinhAnh.Image = null;
                                    }

                                    picHinhAnh.Image = Image.FromFile(imagePath);
                                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                                else
                                {
                                    picHinhAnh.Image = null;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message);
                                picHinhAnh.Image = null;
                            }
                        }
                        else
                        {
                            picHinhAnh.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm với mã " + txtMaSP.Text);
                       
                        txtTenSP.Text = "";
                        txtDonGia.Text = "";
                        txtTonKho.Text = "";
                        picHinhAnh.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMaKH.Text))
                {

                    txtMaSP.Enabled = true;
                    txtMaGiamGia.Enabled = true;
                    dateNgayBan.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    string maHD = TaoMaHoaDon();
                    txtMaHD.Text = maHD;
                    btnTaoHD.Enabled = false;
                    panelCTHD.Enabled = true;
                }
                else
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoMaHoaDon()
        {
            
                string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");
                string prefix = "HD" + ngayHienTai;

 
                var hoaDonCuoiCung = qlshop.HoaDons
                    .Where(h => h.MaHoaDon.StartsWith(prefix))
                    .OrderByDescending(h => h.MaHoaDon)
                    .FirstOrDefault();

                if (hoaDonCuoiCung != null)
                {
           
                    string soThuTu = hoaDonCuoiCung.MaHoaDon.Substring(prefix.Length);
                    int soMoi = int.Parse(soThuTu) + 1;
                    return $"{prefix}{soMoi:D2}"; 
                }
                else
                {
                    
                    return $"{prefix}00";
                }
            
        }

        private void txtSDT_KH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var khach = (from kh in qlshop.KhachHangs
                            where kh.SoDienThoai == txtSDT_KH.Text
                            select kh).FirstOrDefault();
                if(khach!=null)
                {
                    txtMaKH.Text=khach.MaKhachHang;
                }
                else
                {
                    txtMaKH.Text = "KHVL";
                }    
       
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            txtTongTienSauGiam.Clear();
            txtThanhTien.Clear();
            txtMaKH.Clear();
            txtMaGiamGia.Clear();
            btnTaoHD.Enabled = true;
            panelCTHD.Enabled = false;
        }
      

        
        private void btnAdd_CTHD_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(txtMaSP.Text)||string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrEmpty(txtSoLuong.Value.ToString()))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm và số lượng!");
                    return;
                }

                
                if (!int.TryParse(txtSoLuong.Value.ToString(), out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ!");
                    return;
                }

                string maSP = txtMaSP.Text;
                int tonKhoHienTai = tempStock[maSP];

                if (soLuong > tonKhoHienTai)
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho!");
                    return;
                }


                // Kiểm tra sản phẩm đã tồn tại trong grid chưa
                bool daTonTai = false;
                foreach (DataGridViewRow row in grvCTHD.Rows)
                {
                    if (row.Cells["MaSanPham"].Value?.ToString() == txtMaSP.Text)
                    {
                        // Nếu đã tồn tại, cập nhật số lượng
                        int soLuongCu = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        if (soLuongCu + soLuong > tonKhoHienTai)
                        {
                            MessageBox.Show("Tổng số lượng vượt quá tồn kho!");
                            return;
                        }

                        row.Cells["SoLuong"].Value = soLuongCu + soLuong;
                        decimal donGia = decimal.Parse(txtDonGia.Text);
                        row.Cells["Thanhtien"].Value = (soLuongCu + soLuong) * donGia;
                        tempStock[maSP] -= soLuong;
                        txtTonKho.Text = tempStock[maSP].ToString();
                        daTonTai = true;
                        break;
                    }
                }

                // Nếu sản phẩm chưa tồn tại, thêm mới vào grid
                if (!daTonTai)
                {
                    decimal donGia = decimal.Parse(txtDonGia.Text);
                    decimal thanhTien = soLuong * donGia;

                    grvCTHD.Rows.Add(
                        txtMaHD.Text,
                        txtMaSP.Text,
                        txtTenSP.Text,
                        soLuong,
                        donGia,
                        thanhTien
                    );
                    tempStock[maSP] -= soLuong;
                    txtTonKho.Text = tempStock[maSP].ToString();
                }


                TinhTongTien();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in grvCTHD.Rows)
            {
                if (row.Cells["Thanhtien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["Thanhtien"].Value);
                }
            }
            txtThanhTien.Text = tongTien.ToString("#,##0.00");
        }

        private void ClearInputFields()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtTonKho.Text = "";
            picHinhAnh.Image = null;
            txtMaSP.Focus();
        }

        private void btnDelete_CTHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvCTHD.SelectedRows.Count > 0)
                {
                   
                    DataGridViewRow selectedRow = grvCTHD.SelectedRows[0];
                    string maSP = selectedRow.Cells["MaSanPham"].Value.ToString();
                    int soLuong = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);
                   

                    if (tempStock.ContainsKey(maSP))
                    {
                        tempStock[maSP] += soLuong; 
                        txtTonKho.Text = tempStock[maSP].ToString(); 
                    }

                    
                    grvCTHD.Rows.Remove(selectedRow);

                    
                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }


        private void btnEditCTHD_Click(object sender, EventArgs e)
        {
            try
            {
            
                if (grvCTHD.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = grvCTHD.SelectedRows[0];
                    string maSP = selectedRow.Cells["MaSanPham"].Value.ToString();
                    int soLuongCu = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(selectedRow.Cells["DonGia"].Value);

                    int soLuongMoi = Convert.ToInt32(txtSoLuong.Value);

                    
                    if (tempStock.ContainsKey(maSP))
                    {
                      
                        if (soLuongMoi > soLuongCu)
                        {
                            // Tăng số lượng, trừ tồn kho
                            int soLuongTang = soLuongMoi - soLuongCu;
                            if (tempStock[maSP] >= soLuongTang)
                            {
                                tempStock[maSP] -= soLuongTang;
                            }
                            else
                            {
                                MessageBox.Show("Số lượng không đủ trong kho!");
                                return;
                            }
                        }
                        else if (soLuongMoi < soLuongCu)
                        {
                            // Giảm số lượng, cộng vào tồn kho
                            int soLuongGiam = soLuongCu - soLuongMoi;
                            tempStock[maSP] += soLuongGiam;
                        }
                    }

                    // Cập nhật lại thông tin trong DataGridView
                    selectedRow.Cells["SoLuong"].Value = soLuongMoi;
                    selectedRow.Cells["Thanhtien"].Value = soLuongMoi * donGia; 
                    txtTonKho.Text = tempStock[maSP].ToString(); // Cập nhật tồn kho tạm thời

                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sản phẩm: " + ex.Message);
            }
        }



        private void grvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grvCTHD.Rows.Count)
            {
                DataGridViewRow row = grvCTHD.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSanPham"].Value?.ToString() ?? "";
                txtTenSP.Text = row.Cells["TenSanPham"].Value?.ToString() ?? "";
                txtDonGia.Text = row.Cells["Dongia"].Value?.ToString() ?? "";
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString() ?? "";
                string maSP = row.Cells["MaSanPham"].Value.ToString();
                if (tempStock.ContainsKey(maSP))
                {
                    txtTonKho.Text = tempStock[maSP].ToString(); 
                }
                else
                {
                    txtTonKho.Text = "0"; 
                }

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hoaDon = new HoaDon
                {
                    MaHoaDon = txtMaHD.Text,
                    MaNhanVien = txtMaNV.Text,
                    MaKhachHang = txtMaKH.Text,
                    NgayHoaDon = DateTime.Now,
                    TongTien = Convert.ToDecimal(txtThanhTien.Text.Replace(",", "")),
                    TongTienSauGiamGia = Convert.ToDecimal(txtTongTienSauGiam.Text.Replace(",", "")),
                    MaHinhThucThanhToan = cboHinhThucThanhToan.SelectedValue.ToString()
                };

                qlshop.HoaDons.InsertOnSubmit(hoaDon);

                foreach (DataGridViewRow row in grvCTHD.Rows)
                {
                    if (row.Cells["MaSanPham"].Value != null)
                    {
                        ChiTietHoaDon chiTiet = new ChiTietHoaDon
                        {
                            MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                            MaHoaDon = txtMaHD.Text,
                            SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                            Gia = Convert.ToDecimal(row.Cells["DonGia"].Value),
                            Thanhtien = Convert.ToDecimal(row.Cells["Thanhtien"].Value)
                        };

                        qlshop.ChiTietHoaDons.InsertOnSubmit(chiTiet);
                    }
                }

                if (grvCTHD.Rows.Count > 0)
                {
                    qlshop.SubmitChanges();
                    MessageBox.Show("Lưu hóa đơn thành công!");

                    
                    foreach (DataGridViewRow row in grvCTHD.Rows)
                    {
                        if (row.Cells["MaSanPham"].Value != null)
                        {
                            string maSP = row.Cells["MaSanPham"].Value.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                         
                            var sanPham = qlshop.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSP);
                            if (sanPham != null)
                            {
                                // Cập nhật tồn kho
                                sanPham.TonKho -= soLuong; 
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(txtMaGiamGia.Text))
                    {
                        var phieuGiamGia = (from p in qlshop.PhieuGiamGias
                                            where p.MaPhieuGiamGia == txtMaGiamGia.Text
                                            select p).FirstOrDefault();

                        if (phieuGiamGia != null)
                        {
                            ChiTietPhieuGiamGia chiTietGiamGia = new ChiTietPhieuGiamGia
                            {
                                MaHoaDon = txtMaHD.Text,
                                MaPhieuGiamGia = txtMaGiamGia.Text
                            };

                            qlshop.ChiTietPhieuGiamGias.InsertOnSubmit(chiTietGiamGia);
                        }
                    }
                   
                    qlshop.SubmitChanges();
                    MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInHD.Enabled = true;
                    btnTaoHD.Enabled = true;
                    panelCTHD.Enabled = false;
                }
                else
                {
                    qlshop.HoaDons.DeleteOnSubmit(hoaDon);
                    MessageBox.Show("Không có chi tiết hóa đơn để lưu. Hóa đơn không được lưu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

       

        private void btnInHD_Click(object sender, EventArgs e)
        {
            try
            {
                var hoadon = qlshop.HoaDons.Where(h => h.MaHoaDon == txtMaHD.Text).FirstOrDefault();
                if (hoadon == null)
                {
                    MessageBox.Show("Không tồn tại hóa đơn");
                    return;
                }
                string makh = hoadon.MaKhachHang;
                var kh = qlshop.KhachHangs.Where(k => k.MaKhachHang == makh).FirstOrDefault();
                if (kh == null)
                {
                    MessageBox.Show("Không tòn tại khách hàng");
                    return;
                }
                var tbl_cthd_hd = from row in qlshop.ThongTinHoaDons
                                  where row.MaHoaDon == txtMaHD.Text
                                  select row;
                DataTable tblhd = new db_qlhd.ThongTinHoaDonDataTable();
                tblhd = ConvertUltil.ConvertListToDataTable<ThongTinHoaDon>(tbl_cthd_hd.ToList<ThongTinHoaDon>());
                tblhd.PrimaryKey = null;
                tblhd.Columns.Remove("MaHoaDon");
                tblhd.Columns.Remove("MaSanPham");
                DataColumn col = new DataColumn("STT", typeof(int));
                tblhd.Columns.Add(col);
                col.SetOrdinal(0);
                int len = tblhd.Rows.Count;
                for (int i = 0; i < len; i++)
                {
                    tblhd.Rows[i]["STT"] = i + 1;
                }
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("MaPhieu", txtMaHD.Text);
                dic.Add("TenKhachHang", kh.HoTen);
                dic.Add("SDT", kh.SoDienThoai);
                dic.Add("NgayLap", hoadon.NgayHoaDon.Value.ToString());
                dic.Add("NhanVien", hoadon.MaNhanVien.ToString());
                dic.Add("tongtien", hoadon.TongTien.ToString());
                dic.Add("giamgia", hoadon.TongTienSauGiamGia.ToString());
                WordExport wd = new WordExport(Application.StartupPath + "/Template/SNEAKER SHOP.dotx", true);
                wd.WriteFields(dic);
                wd.WriteTable(tblhd, 1);
                MessageBox.Show("IN HÓA ĐƠN THÀNH CÔNG");
                resetForm();
                btnInHD.Enabled = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
        }
        private void ApplyDiscount()
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaGiamGia.Text))
                {
                    txtTongTienSauGiam.Text = txtThanhTien.Text;
                    return;
                }

                var phieuGiamGia = (from p in qlshop.PhieuGiamGias
                                    where p.MaPhieuGiamGia == txtMaGiamGia.Text
                                    && p.NgayBatDau <= DateTime.Now
                                    && p.NgayKetThuc >= DateTime.Now
                                    select p).FirstOrDefault();

                if (phieuGiamGia == null)
                {
                    MessageBox.Show("Mã giảm giá không hợp lệ hoặc đã hết hạn!");
                    txtTongTienSauGiam.Text = txtThanhTien.Text;
                    return;
                }

                decimal tongTien = decimal.Parse(txtThanhTien.Text.Replace(",", ""));
                decimal tienGiam = 0;

                if (phieuGiamGia.LoaiGiamGia == "TIEN")
                {
                    tienGiam = phieuGiamGia.GiaTri.Value;
                }
                else if (phieuGiamGia.LoaiGiamGia == "PERCENT")
                {
                    tienGiam = (tongTien * phieuGiamGia.GiaTri.Value) / 100;
                }

                decimal tongTienSauGiam = tongTien - tienGiam;
                if (tongTienSauGiam < 0)
                    tongTienSauGiam = 0;

                txtTongTienSauGiam.Text = tongTienSauGiam.ToString("#,##0.00");

                ChiTietPhieuGiamGia chiTietGiamGia = new ChiTietPhieuGiamGia
                {
                    MaHoaDon = txtMaHD.Text,
                    MaPhieuGiamGia = phieuGiamGia.MaPhieuGiamGia
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng mã giảm giá: " + ex.Message);
                txtTongTienSauGiam.Text = txtThanhTien.Text;
            }
        }
        private void txtMaGiamGia_TextChanged(object sender, EventArgs e)
        {
            ApplyDiscount();
        }
        void resetForm()
        {
            txtMaHD.Clear();
            txtSDT_KH.Clear();
            txtTongTienSauGiam.Text = "0.00";
            txtThanhTien.Text="0.00";
            txtMaKH.Clear();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Text="0.00";
            grvCTHD.Rows.Clear();
            txtMaSP.Enabled = false;
        }
    }
}
