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
    public partial class FNhapHang : Form
    {
        QLShopDataContext qlshop = new QLShopDataContext();
        public FNhapHang()
        {
            InitializeComponent();
            load_NCC();
            grvCTPN.AllowUserToAddRows = false;

        }
        string manv;
        private void FNhapHang_Load(object sender, EventArgs e)
        {
            FormPrincipal mainForm = this.Owner as FormPrincipal;
            manv = mainForm.manv;
            txtMaNV.Text = mainForm.manv;
        }

        private void load_NCC()
        {
            var load = from ncc in qlshop.NhaCungCaps
                       select ncc;
            cboNCC.DataSource = load.ToList();
            cboNCC.ValueMember = "MaNhaCungCap";
            cboNCC.DisplayMember = "MaNhaCungCap";
        }

        private void load_grv_SanPham(string x)
        {
            var sp = from s in qlshop.SanPhams
                     join svs in qlshop.CUNGUNGs on s.MaSanPham equals svs.MaSP
                     join ncc in qlshop.NhaCungCaps on svs.MaNCC equals ncc.MaNhaCungCap
                     join mdm in qlshop.DanhMucs on s.MaDanhMuc equals mdm.MaDanhMuc
                     join mth in qlshop.ThuongHieus on s.MaThuongHieu equals mth.MaThuongHieu
                     where ncc.MaNhaCungCap == x
                     select new
                     {
                         MaSP = s.MaSanPham,
                         TenSP = s.TenSanPham,
                         GiaBan = s.Gia,
                         MoTa = s.MoTa,
                         Size = s.Size,
                         MauSac = s.MauSac,
                         ThuongHieu = mth.TenThuongHieu,
                         DanhMuc = mdm.TenDanhMuc,
                         SoLuongTon_SP = s.TonKho
                     };

            grvSanPham.DataSource = sp;
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNCC.SelectedValue != null)
            {
                string t = cboNCC.SelectedValue.ToString();
                load_grv_SanPham(t);
            }
        }

        private void sinh_PN()
        {
            DateTime ngayHienTai = DateTime.Today;
            var slpn = qlshop.PhieuNhaps.Count(item =>
                item.NgayPhieuNhap.HasValue && item.NgayPhieuNhap.Value.Date == ngayHienTai);
            slpn += 1;
            txtMaPN.Text = "PN" + DateTime.Today.ToString("ddMMyyyy") + slpn.ToString("D3");
        }


        private void btnTaoPN_Click(object sender, EventArgs e)
        {
            cboNCC.Enabled = true;
            btnTimPN.Enabled = false;
            btn_LuuPN.Enabled = true;
            btnTaoPN.Enabled = false;
            btnHuyPN.Enabled = true;
            ThemSp.Enabled = true;
            sinh_PN();
            int r = grv_TTPN.Rows.Add();
            grv_TTPN.Rows[0].Cells[0].Value = txtMaPN.Text;
            grv_TTPN.Rows[0].Cells[1].Value = dateNgayNhap.Value.ToString("dd/MM/yyyy"); // Đặt tên đúng cho cột ngày
            grv_TTPN.Rows[0].Cells[2].Value = txtTongTien.Text;

        }

        private void btnTimPN_Click(object sender, EventArgs e)
        {
            btnTaoPN.Enabled = false;
            grv_TTPN.Enabled = true;
            btnHuyPN.Enabled = true;
            btnInPN.Enabled = true;
            try
            {

                if (DateTuNgay.Value > DateDenNgay.Value)
                {
                    MessageBox.Show("Lỗi");
                }
                else
                {
                    locPhieuNhap(DateTuNgay.Value, DateDenNgay.Value);
                }
            }
            catch
            {
            }
        }

        private void locPhieuNhap(DateTime st, DateTime en)
        {
            var x = from pn in qlshop.PhieuNhaps
                    where pn.NgayPhieuNhap > st && pn.NgayPhieuNhap < en
                    select new
                    {
                        MaPN = pn.MaPhieuNhap,
                        NgayNhap = pn.NgayPhieuNhap,
                        TongTien = pn.TongTien,
                    };
            grv_TTPN.DataSource = x;
        }
        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            if (grvSanPham.Rows.Count > 0)
            {
                txtTongTien.Text = grv_TTPN.Rows[0].Cells[2].Value.ToString();
                cboNCC.Enabled = false;
            }
            try
            {
                foreach (DataGridViewRow i in grvSanPham.Rows)
                {
                    bool ce = i.Cells[0].Value != null && (bool)i.Cells[0].Value;
                    if (ce)
                    {
                        foreach (DataGridViewRow j in grvCTPN.Rows)
                        {
                            string ma = i.Cells[1].Value.ToString();
                            if (j.Cells[1].Value != null && j.Cells[1].Value.Equals(ma))
                            {
                                MessageBox.Show("Sản phẩm đã tồn tại");
                                return;
                            }
                        }
                        int r = grvCTPN.Rows.Add();
                        grvCTPN.Rows[r].Cells[0].Value = txtMaPN.Text;
                        grvCTPN.Rows[r].Cells[1].Value = i.Cells[1].Value;
                        grvCTPN.Rows[r].Cells[2].Value = i.Cells[3].Value;
                        grvCTPN.Rows[r].Cells[3].Value = 1;
                        float x = float.Parse(grvCTPN.Rows[r].Cells[3].Value.ToString());
                        float z = float.Parse(i.Cells[3].Value.ToString());
                        float tt = z * x;


                        grvCTPN.Rows[r].Cells[4].Value = tt;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuyPN_Click(object sender, EventArgs e)
        {
            cboNCC.Enabled = true;
            txtMaPN.Text = string.Empty;
            btn_LuuPN.Enabled = false;
            btnTaoPN.Enabled = true;
            ThemSp.Enabled = false;
            grv_TTPN.Enabled = false;
            btnHuyPN.Enabled = false;
            btnInPN.Enabled = false;
            btnTimPN.Enabled = true;

            // Clear dữ liệu trong cả 3 DataGridView mà vẫn giữ lại header
            ClearDataGridViewRows(grv_TTPN);
            ClearDataGridViewRows(grvCTPN);
            ClearDataGridViewRows(grvSanPham);
        }


        private void btn_LuuPN_Click(object sender, EventArgs e)
        {
            cboNCC.Enabled = true;
            if (string.IsNullOrEmpty(txtMaPN.Text))
            {
                MessageBox.Show("Không có mã phiếu nhập");
            }
            else
            {
                savePN();
                saveCTPN();
            }
            btnTimPN.Enabled = true;
            txtMaPN.Text = string.Empty;
            btn_LuuPN.Enabled = false;
            btnHuyPN.Enabled = false;
            btnTaoPN.Enabled = true;
            ThemSp.Enabled = false;
            grvCTPN.Rows.Clear();
            grv_TTPN.Rows.Clear();
            grvSanPham.Rows.Clear();
        }
        private void ClearDataGridViewRows(DataGridView dgv)
        {
            var columns = dgv.Columns.Cast<DataGridViewColumn>().Select(c => new { c.Name, c.HeaderText, c.ValueType }).ToList();
            dgv.DataSource = null; // Gán về null để xóa dữ liệu

            dgv.Columns.Clear(); // Xóa tất cả cột trước khi thêm lại
            foreach (var col in columns)
            {
                dgv.Columns.Add(col.Name, col.HeaderText); // Thêm lại cột với tên và header ban đầu
                dgv.Columns[col.Name].ValueType = col.ValueType;
            }
        }
        private void savePN()
        {
            try
            {
                txtTongTien.Text = grv_TTPN.Rows[0].Cells[2].Value.ToString();
                decimal t = decimal.Parse(txtTongTien.Text);
                PhieuNhap pn = new PhieuNhap();
                pn.MaPhieuNhap = txtMaPN.Text;
                pn.NgayPhieuNhap = DateTime.Today;
                pn.MaNhanVien = txtMaNV.Text;
                pn.MaNhaCungCap = cboNCC.SelectedValue.ToString();
                pn.TongTien = t;
                qlshop.PhieuNhaps.InsertOnSubmit(pn);
                qlshop.SubmitChanges();
                MessageBox.Show("Tạo phiếu nhập thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void saveCTPN()
        {
            try
            {
                if (grvCTPN.Rows.Count > 0)
                {
                    foreach (DataGridViewRow r in grvCTPN.Rows)
                    {
                        string ma = r.Cells[1].Value.ToString();
                        int sl = int.Parse(r.Cells[3].Value.ToString());
                        decimal tt = decimal.Parse(r.Cells[4].Value.ToString());
                        ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                        ctpn.MaPhieuNhap = txtMaPN.Text.Trim();
                        ctpn.MaSanPham = ma;
                        ctpn.SoLuong = sl;
                        ctpn.GiaVon = tt;
                        qlshop.ChiTietPhieuNhaps.InsertOnSubmit(ctpn);
                    }
                    qlshop.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            saveCTPN();
            ThemSp.Enabled = false;
        }

        private void grv_TTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị của ô được chọn
                var cellValue = grv_TTPN.Rows[e.RowIndex].Cells[0].Value;
                var find = (from pn in qlshop.PhieuNhaps
                            where pn.MaPhieuNhap == cellValue
                            select new
                            {
                                MaPhieuNhap = pn.MaPhieuNhap,
                                Manv = pn.MaNhanVien,
                                NgayNhap = pn.NgayPhieuNhap
                            }).FirstOrDefault();
                txtMaNV.Text = find.Manv;
                txtMaPN.Text = find.MaPhieuNhap;
                dateNgayNhap.Text = find.NgayNhap.ToString();

                // Truy vấn dữ liệu và lấy kết quả dưới dạng danh sách
                var ctpnList = (from CTPN in qlshop.ChiTietPhieuNhaps
                                join PN in qlshop.PhieuNhaps on CTPN.MaPhieuNhap equals PN.MaPhieuNhap
                                join SP in qlshop.SanPhams on CTPN.MaSanPham equals SP.MaSanPham
                                where CTPN.MaPhieuNhap == cellValue
                                select new
                                {
                                    MaPN = CTPN.MaPhieuNhap,
                                    DonGia = SP.Gia,
                                    MaSP = CTPN.MaSanPham,
                                    Soluong = CTPN.SoLuong,
                                    ThanhTien = CTPN.GiaVon
                                }).ToList(); // Sử dụng ToList() để tạo danh sách

                // Gán danh sách vào DataGridView
                grvCTPN.DataSource = ctpnList;
            }
        }

        private void grvCTPN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {

                    // Lấy giá trị từ các ô và kiểm tra null
                    var cell3Value = grvCTPN.Rows[e.RowIndex].Cells[3].Value?.ToString();
                    var cell2Value = grvCTPN.Rows[e.RowIndex].Cells[2].Value?.ToString();

                    if (float.TryParse(cell3Value, out float x) && float.TryParse(cell2Value, out float z))
                    {
                        float tt = z * x;
                        grvCTPN.Rows[e.RowIndex].Cells[4].Value = tt;
                    }
                    else
                    {
                        grvCTPN.Rows[e.RowIndex].Cells[4].Value = 0; // Gán giá trị mặc định nếu có lỗi chuyển đổi
                    }
                    grv_TTPN.Rows[0].Cells[2].Value = total_PN();

                    txtTongTien.Text = grv_TTPN.Rows[0].Cells[2].Value.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private float total_PN()
        {
            try
            {
                float tt = 0;
                foreach (DataGridViewRow row in grvCTPN.Rows)
                {
                    tt += float.Parse(row.Cells[4].Value.ToString());
                }
                return tt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private void btnInPN_Click(object sender, EventArgs e)
        {
            var mancc = (from ncc in qlshop.NhaCungCaps
                         where ncc.MaNhaCungCap == cboNCC.SelectedValue.ToString()
                         select ncc).FirstOrDefault();
            var tbl_PhieuNhap = from rows in qlshop.v_PNs
                                where rows.MaPhieuNhap == txtMaPN.Text
                                select rows;
            DataTable PN = new PN.v_PNDataTable();
            PN = ConvertUltil.ConvertListToDataTable<v_PN>(tbl_PhieuNhap.ToList<v_PN>());
            Dictionary<string, string> dic = new Dictionary<string, string>();
            PN.PrimaryKey = null;
            PN.Columns.Remove("MaPhieuNhap");
            PN.Columns.Remove("MaNhaCungCap");
            //tao stt
            DataColumn dc = new DataColumn("STT", typeof(int));
            PN.Columns.Add(dc);
            dc.SetOrdinal(0);
            int len = PN.Rows.Count;
            for (int i = 0; i < len; ++i)
            {
                PN.Rows[i]["STT"] = i + 1;
            }
            PN.Columns["MaSanPham"].SetOrdinal(1);
            PN.Columns["TenSanPham"].SetOrdinal(2);
            PN.Columns["SoLuong"].SetOrdinal(3);
            PN.Columns["GiaVon"].SetOrdinal(4);
            MessageBox.Show(PN.Rows.Count.ToString());
            var mapn = (from r in qlshop.PhieuNhaps
                        where r.MaPhieuNhap == txtMaPN.Text
                        select r).FirstOrDefault();
            dic.Add("MPN", txtMaPN.Text);
            dic.Add("NCC", cboNCC.SelectedText.ToString());
            dic.Add("DiaChi", mancc.Diachi);
            dic.Add("SDT", mancc.DienThoai);
            dic.Add("TongTien", mapn.TongTien.ToString());
            dic.Add("MaNV", mapn.MaNhanVien);
            WordExport wd = new WordExport(Application.StartupPath + "/PhieuNhap.dotx", true);
            wd.WriteFields(dic);
            wd.WriteTable(PN, 1);
            MessageBox.Show("Done");

            // lấy chi tiết phiếu nhập -> tổng tiền 
            // lấy mã nhân viên 
            // Lấy bảng mới
            // tạo datatable mới
            //
            // Dictionary
        }
    }
}
