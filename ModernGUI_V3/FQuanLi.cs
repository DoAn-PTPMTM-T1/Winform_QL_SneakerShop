using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public partial class FQuanLi : Form
    {
        QLShopDataContext qlss = new QLShopDataContext();
        List<NhaCungCap> List_NCC = new List<NhaCungCap>();

        public FQuanLi()
        {
            InitializeComponent();
            Enable_Control_banDau();
            load_grvNCC();
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
