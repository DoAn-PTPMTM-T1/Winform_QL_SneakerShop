
namespace ModernGUI_V3
{
    partial class FNhapHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNhapHang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSoLuong = new Sunny.UI.UIIntegerUpDown();
            this.btnThem = new Sunny.UI.UISymbolButton();
            this.txtGiaVon = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.txtMaSP = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.btnLuu = new Sunny.UI.UISymbolButton();
            this.btnSua = new Sunny.UI.UISymbolButton();
            this.btnXoa = new Sunny.UI.UISymbolButton();
            this.cboTenSP = new Sunny.UI.UIComboBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.pnlHoaDon = new Sunny.UI.UITitlePanel();
            this.btnTaoPN = new Sunny.UI.UISymbolButton();
            this.dateNgayNhap = new Sunny.UI.UIDatePicker();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtTenNV = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtMaPN = new Sunny.UI.UITextBox();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.grvCTPN = new Sunny.UI.UIDataGridView();
            this.cboNhaCungCap = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtTongTien = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.btnInPN = new Sunny.UI.UISymbolButton();
            this.btnHuyPN = new Sunny.UI.UISymbolButton();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaVon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHoaDon.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCTPN)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtSoLuong.Location = new System.Drawing.Point(861, 49);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSoLuong.Maximum = 1000;
            this.txtSoLuong.Minimum = 0;
            this.txtSoLuong.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ShowText = false;
            this.txtSoLuong.Size = new System.Drawing.Size(150, 29);
            this.txtSoLuong.TabIndex = 116;
            this.txtSoLuong.Text = "_uiIntegerUpDown1";
            this.txtSoLuong.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThem.Location = new System.Drawing.Point(27, 125);
            this.btnThem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(132, 35);
            this.btnThem.Symbol = 61543;
            this.btnThem.TabIndex = 115;
            this.btnThem.Text = "Thêm";
            this.btnThem.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // txtGiaVon
            // 
            this.txtGiaVon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGiaVon.Enabled = false;
            this.txtGiaVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGiaVon.Location = new System.Drawing.Point(861, 88);
            this.txtGiaVon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGiaVon.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtGiaVon.Name = "txtGiaVon";
            this.txtGiaVon.Padding = new System.Windows.Forms.Padding(5);
            this.txtGiaVon.ShowText = false;
            this.txtGiaVon.Size = new System.Drawing.Size(248, 29);
            this.txtGiaVon.TabIndex = 111;
            this.txtGiaVon.Text = "0.00";
            this.txtGiaVon.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtGiaVon.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtGiaVon.Watermark = "";
            // 
            // uiLabel7
            // 
            this.uiLabel7.AutoSize = true;
            this.uiLabel7.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Location = new System.Drawing.Point(723, 92);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(79, 25);
            this.uiLabel7.TabIndex = 110;
            this.uiLabel7.Text = "Giá vốn";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaSP.Enabled = false;
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaSP.Location = new System.Drawing.Point(166, 88);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaSP.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Padding = new System.Windows.Forms.Padding(5);
            this.txtMaSP.ShowText = false;
            this.txtMaSP.Size = new System.Drawing.Size(248, 29);
            this.txtMaSP.TabIndex = 109;
            this.txtMaSP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMaSP.Watermark = "";
            // 
            // uiLabel8
            // 
            this.uiLabel8.AutoSize = true;
            this.uiLabel8.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel8.Location = new System.Drawing.Point(22, 92);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(131, 25);
            this.uiLabel8.TabIndex = 108;
            this.uiLabel8.Text = "Mã sản phẩm";
            // 
            // btnLuu
            // 
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1004, 125);
            this.btnLuu.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnLuu.Size = new System.Drawing.Size(105, 35);
            this.btnLuu.Style = Sunny.UI.UIStyle.Custom;
            this.btnLuu.StyleCustomMode = true;
            this.btnLuu.Symbol = 61530;
            this.btnLuu.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnLuu.TabIndex = 120;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSua.Location = new System.Drawing.Point(677, 125);
            this.btnSua.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(132, 35);
            this.btnSua.Symbol = 61508;
            this.btnSua.TabIndex = 119;
            this.btnSua.Text = "Sửa";
            this.btnSua.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoa.Location = new System.Drawing.Point(352, 125);
            this.btnXoa.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(132, 35);
            this.btnXoa.Symbol = 61544;
            this.btnXoa.TabIndex = 118;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // cboTenSP
            // 
            this.cboTenSP.DataSource = null;
            this.cboTenSP.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cboTenSP.FillColor = System.Drawing.Color.White;
            this.cboTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboTenSP.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboTenSP.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboTenSP.Location = new System.Drawing.Point(166, 49);
            this.cboTenSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTenSP.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboTenSP.Name = "cboTenSP";
            this.cboTenSP.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboTenSP.Size = new System.Drawing.Size(248, 29);
            this.cboTenSP.SymbolSize = 24;
            this.cboTenSP.TabIndex = 117;
            this.cboTenSP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboTenSP.Watermark = "";
            // 
            // uiLabel10
            // 
            this.uiLabel10.AutoSize = true;
            this.uiLabel10.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel10.Location = new System.Drawing.Point(723, 53);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(90, 25);
            this.uiLabel10.TabIndex = 108;
            this.uiLabel10.Text = "Số lượng";
            // 
            // uiLabel11
            // 
            this.uiLabel11.AutoSize = true;
            this.uiLabel11.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel11.Location = new System.Drawing.Point(22, 53);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(138, 25);
            this.uiLabel11.TabIndex = 106;
            this.uiLabel11.Text = "Tên sản phẩm";
            // 
            // pnlHoaDon
            // 
            this.pnlHoaDon.Controls.Add(this.btnHuyPN);
            this.pnlHoaDon.Controls.Add(this.btnInPN);
            this.pnlHoaDon.Controls.Add(this.txtTongTien);
            this.pnlHoaDon.Controls.Add(this.uiLabel4);
            this.pnlHoaDon.Controls.Add(this.cboNhaCungCap);
            this.pnlHoaDon.Controls.Add(this.uiLabel3);
            this.pnlHoaDon.Controls.Add(this.btnTaoPN);
            this.pnlHoaDon.Controls.Add(this.dateNgayNhap);
            this.pnlHoaDon.Controls.Add(this.uiLabel2);
            this.pnlHoaDon.Controls.Add(this.txtTenNV);
            this.pnlHoaDon.Controls.Add(this.uiLabel1);
            this.pnlHoaDon.Controls.Add(this.txtMaPN);
            this.pnlHoaDon.Controls.Add(this.uiLabel12);
            this.pnlHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlHoaDon.Location = new System.Drawing.Point(13, 14);
            this.pnlHoaDon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHoaDon.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlHoaDon.Name = "pnlHoaDon";
            this.pnlHoaDon.ShowText = false;
            this.pnlHoaDon.Size = new System.Drawing.Size(1181, 175);
            this.pnlHoaDon.TabIndex = 2;
            this.pnlHoaDon.Text = "Phiếu nhập";
            this.pnlHoaDon.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTaoPN
            // 
            this.btnTaoPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTaoPN.Location = new System.Drawing.Point(517, 127);
            this.btnTaoPN.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTaoPN.Name = "btnTaoPN";
            this.btnTaoPN.Size = new System.Drawing.Size(191, 35);
            this.btnTaoPN.Symbol = 61543;
            this.btnTaoPN.TabIndex = 115;
            this.btnTaoPN.Text = "Tạo phiếu nhập";
            this.btnTaoPN.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.FillColor = System.Drawing.Color.White;
            this.dateNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateNgayNhap.Location = new System.Drawing.Point(166, 127);
            this.dateNgayNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateNgayNhap.MaxLength = 10;
            this.dateNgayNhap.MinimumSize = new System.Drawing.Size(63, 0);
            this.dateNgayNhap.Name = "dateNgayNhap";
            this.dateNgayNhap.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dateNgayNhap.Size = new System.Drawing.Size(248, 33);
            this.dateNgayNhap.SymbolDropDown = 61555;
            this.dateNgayNhap.SymbolNormal = 61555;
            this.dateNgayNhap.SymbolSize = 24;
            this.dateNgayNhap.TabIndex = 110;
            this.dateNgayNhap.Text = "2024-10-18";
            this.dateNgayNhap.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dateNgayNhap.Value = new System.DateTime(2024, 10, 18, 21, 13, 6, 512);
            this.dateNgayNhap.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(22, 131);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(107, 25);
            this.uiLabel2.TabIndex = 108;
            this.uiLabel2.Text = "Ngày nhập";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenNV.Enabled = false;
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenNV.Location = new System.Drawing.Point(166, 88);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenNV.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Padding = new System.Windows.Forms.Padding(5);
            this.txtTenNV.ShowText = false;
            this.txtTenNV.Size = new System.Drawing.Size(248, 29);
            this.txtTenNV.TabIndex = 109;
            this.txtTenNV.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTenNV.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(22, 92);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(137, 25);
            this.uiLabel1.TabIndex = 108;
            this.uiLabel1.Text = "Tên nhân viên";
            // 
            // txtMaPN
            // 
            this.txtMaPN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaPN.Enabled = false;
            this.txtMaPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaPN.Location = new System.Drawing.Point(166, 49);
            this.txtMaPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaPN.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Padding = new System.Windows.Forms.Padding(5);
            this.txtMaPN.ShowText = false;
            this.txtMaPN.Size = new System.Drawing.Size(248, 29);
            this.txtMaPN.TabIndex = 107;
            this.txtMaPN.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMaPN.Watermark = "";
            // 
            // uiLabel12
            // 
            this.uiLabel12.AutoSize = true;
            this.uiLabel12.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel12.Location = new System.Drawing.Point(22, 53);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(142, 25);
            this.uiLabel12.TabIndex = 106;
            this.uiLabel12.Text = "Mã phiếu nhập";
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.grvCTPN);
            this.uiTitlePanel1.Controls.Add(this.btnLuu);
            this.uiTitlePanel1.Controls.Add(this.btnSua);
            this.uiTitlePanel1.Controls.Add(this.btnXoa);
            this.uiTitlePanel1.Controls.Add(this.cboTenSP);
            this.uiTitlePanel1.Controls.Add(this.txtSoLuong);
            this.uiTitlePanel1.Controls.Add(this.btnThem);
            this.uiTitlePanel1.Controls.Add(this.txtGiaVon);
            this.uiTitlePanel1.Controls.Add(this.uiLabel7);
            this.uiTitlePanel1.Controls.Add(this.txtMaSP);
            this.uiTitlePanel1.Controls.Add(this.uiLabel8);
            this.uiTitlePanel1.Controls.Add(this.uiLabel10);
            this.uiTitlePanel1.Controls.Add(this.uiLabel11);
            this.uiTitlePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiTitlePanel1.Location = new System.Drawing.Point(13, 209);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(1181, 609);
            this.uiTitlePanel1.TabIndex = 3;
            this.uiTitlePanel1.Text = "Chi tiết phiếu nhập";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grvCTPN
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvCTPN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grvCTPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvCTPN.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.grvCTPN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvCTPN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grvCTPN.ColumnHeadersHeight = 32;
            this.grvCTPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grvCTPN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.MaPN,
            this.SoLuong,
            this.GiaVon});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvCTPN.DefaultCellStyle = dataGridViewCellStyle3;
            this.grvCTPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvCTPN.EnableHeadersVisualStyles = false;
            this.grvCTPN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvCTPN.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grvCTPN.Location = new System.Drawing.Point(0, 166);
            this.grvCTPN.Name = "grvCTPN";
            this.grvCTPN.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvCTPN.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvCTPN.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.grvCTPN.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grvCTPN.RowTemplate.Height = 23;
            this.grvCTPN.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCTPN.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCTPN.ScrollBarStyleInherited = false;
            this.grvCTPN.SelectedIndex = -1;
            this.grvCTPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvCTPN.Size = new System.Drawing.Size(1181, 443);
            this.grvCTPN.TabIndex = 122;
            this.grvCTPN.TagString = "";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DataSource = null;
            this.cboNhaCungCap.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cboNhaCungCap.FillColor = System.Drawing.Color.White;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboNhaCungCap.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboNhaCungCap.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboNhaCungCap.Location = new System.Drawing.Point(857, 49);
            this.cboNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboNhaCungCap.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboNhaCungCap.Size = new System.Drawing.Size(248, 29);
            this.cboNhaCungCap.SymbolSize = 24;
            this.cboNhaCungCap.TabIndex = 119;
            this.cboNhaCungCap.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboNhaCungCap.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(717, 53);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(133, 25);
            this.uiLabel3.TabIndex = 118;
            this.uiLabel3.Text = "Nhà cung cấp";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTongTien.Location = new System.Drawing.Point(857, 88);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTongTien.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Padding = new System.Windows.Forms.Padding(5);
            this.txtTongTien.ShowText = false;
            this.txtTongTien.Size = new System.Drawing.Size(248, 29);
            this.txtTongTien.TabIndex = 113;
            this.txtTongTien.Text = "0.00";
            this.txtTongTien.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTongTien.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtTongTien.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(717, 92);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(94, 25);
            this.uiLabel4.TabIndex = 112;
            this.uiLabel4.Text = "Tổng tiền";
            // 
            // btnInPN
            // 
            this.btnInPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnInPN.Image = ((System.Drawing.Image)(resources.GetObject("btnInPN.Image")));
            this.btnInPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInPN.Location = new System.Drawing.Point(934, 127);
            this.btnInPN.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnInPN.Name = "btnInPN";
            this.btnInPN.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnInPN.Size = new System.Drawing.Size(171, 35);
            this.btnInPN.Style = Sunny.UI.UIStyle.Custom;
            this.btnInPN.StyleCustomMode = true;
            this.btnInPN.Symbol = 61530;
            this.btnInPN.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnInPN.TabIndex = 122;
            this.btnInPN.Text = "In phiếu nhập";
            this.btnInPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInPN.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnHuyPN
            // 
            this.btnHuyPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyPN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHuyPN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHuyPN.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnHuyPN.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHuyPN.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHuyPN.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyPN.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnHuyPN.Location = new System.Drawing.Point(763, 127);
            this.btnHuyPN.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHuyPN.Name = "btnHuyPN";
            this.btnHuyPN.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHuyPN.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnHuyPN.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHuyPN.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHuyPN.Size = new System.Drawing.Size(116, 35);
            this.btnHuyPN.Style = Sunny.UI.UIStyle.Custom;
            this.btnHuyPN.StyleCustomMode = true;
            this.btnHuyPN.Symbol = 61453;
            this.btnHuyPN.TabIndex = 123;
            this.btnHuyPN.Text = "Hủy";
            this.btnHuyPN.TipsFont = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã sản phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            // 
            // MaPN
            // 
            this.MaPN.DataPropertyName = "MaPN";
            this.MaPN.HeaderText = "Mã phiếu nhập";
            this.MaPN.MinimumWidth = 6;
            this.MaPN.Name = "MaPN";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            // 
            // GiaVon
            // 
            this.GiaVon.HeaderText = "Giá vốn";
            this.GiaVon.MinimumWidth = 6;
            this.GiaVon.Name = "GiaVon";
            // 
            // FNhapHang
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 832);
            this.Controls.Add(this.pnlHoaDon);
            this.Controls.Add(this.uiTitlePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FNhapHang";
            this.Text = "NhapHang";
            this.pnlHoaDon.ResumeLayout(false);
            this.pnlHoaDon.PerformLayout();
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCTPN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIIntegerUpDown txtSoLuong;
        private Sunny.UI.UISymbolButton btnThem;
        private Sunny.UI.UITextBox txtGiaVon;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txtMaSP;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UISymbolButton btnLuu;
        private Sunny.UI.UISymbolButton btnSua;
        private Sunny.UI.UISymbolButton btnXoa;
        private Sunny.UI.UIComboBox cboTenSP;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITitlePanel pnlHoaDon;
        private Sunny.UI.UISymbolButton btnTaoPN;
        private Sunny.UI.UIDatePicker dateNgayNhap;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtTenNV;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtMaPN;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UIDataGridView grvCTPN;
        private Sunny.UI.UIComboBox cboNhaCungCap;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtTongTien;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UISymbolButton btnInPN;
        private Sunny.UI.UISymbolButton btnHuyPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaVon;
    }
}