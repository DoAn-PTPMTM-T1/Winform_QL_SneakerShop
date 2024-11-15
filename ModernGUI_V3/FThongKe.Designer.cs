
namespace ModernGUI_V3
{
    partial class FThongKe
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
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DatePicker_Year_DoanhThu = new Sunny.UI.UIDatePicker();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.BarChart_DoanhThu = new Sunny.UI.UIBarChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DatePicker_Year_SanPham = new Sunny.UI.UIDatePicker();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.DatePicker_MY_SanPham = new Sunny.UI.UIDatePicker();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.PieChart_DoanhThu = new Sunny.UI.UIPieChart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PieChart_XuHuong = new Sunny.UI.UIPieChart();
            this.DatePicker_MY_XuHuong = new Sunny.UI.UIDatePicker();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(1348, 832);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DatePicker_Year_DoanhThu);
            this.tabPage1.Controls.Add(this.uiLabel12);
            this.tabPage1.Controls.Add(this.BarChart_DoanhThu);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1348, 792);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doanh thu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DatePicker_Year_DoanhThu
            // 
            this.DatePicker_Year_DoanhThu.FillColor = System.Drawing.Color.White;
            this.DatePicker_Year_DoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DatePicker_Year_DoanhThu.Location = new System.Drawing.Point(102, 8);
            this.DatePicker_Year_DoanhThu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DatePicker_Year_DoanhThu.MaxLength = 4;
            this.DatePicker_Year_DoanhThu.MinimumSize = new System.Drawing.Size(63, 0);
            this.DatePicker_Year_DoanhThu.Name = "DatePicker_Year_DoanhThu";
            this.DatePicker_Year_DoanhThu.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.DatePicker_Year_DoanhThu.ShowType = Sunny.UI.UIDateType.Year;
            this.DatePicker_Year_DoanhThu.Size = new System.Drawing.Size(87, 29);
            this.DatePicker_Year_DoanhThu.SymbolDropDown = 61555;
            this.DatePicker_Year_DoanhThu.SymbolNormal = 61555;
            this.DatePicker_Year_DoanhThu.SymbolSize = 24;
            this.DatePicker_Year_DoanhThu.TabIndex = 117;
            this.DatePicker_Year_DoanhThu.Text = "2024";
            this.DatePicker_Year_DoanhThu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DatePicker_Year_DoanhThu.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.DatePicker_Year_DoanhThu.Watermark = "";
            this.DatePicker_Year_DoanhThu.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.DatePicker_Year_DoanhThu_ValueChanged);
            // 
            // uiLabel12
            // 
            this.uiLabel12.AutoSize = true;
            this.uiLabel12.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel12.Location = new System.Drawing.Point(12, 12);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(103, 25);
            this.uiLabel12.TabIndex = 111;
            this.uiLabel12.Text = "Chọn năm";
            // 
            // BarChart_DoanhThu
            // 
            this.BarChart_DoanhThu.ChartStyleType = Sunny.UI.UIChartStyleType.Default;
            this.BarChart_DoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarChart_DoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BarChart_DoanhThu.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BarChart_DoanhThu.Location = new System.Drawing.Point(0, 52);
            this.BarChart_DoanhThu.MinimumSize = new System.Drawing.Size(1, 1);
            this.BarChart_DoanhThu.Name = "BarChart_DoanhThu";
            this.BarChart_DoanhThu.Size = new System.Drawing.Size(1348, 740);
            this.BarChart_DoanhThu.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BarChart_DoanhThu.TabIndex = 4;
            this.BarChart_DoanhThu.Text = "uiBarChart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DatePicker_Year_SanPham);
            this.tabPage2.Controls.Add(this.uiLabel1);
            this.tabPage2.Controls.Add(this.DatePicker_MY_SanPham);
            this.tabPage2.Controls.Add(this.uiLabel2);
            this.tabPage2.Controls.Add(this.PieChart_DoanhThu);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1348, 792);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sản phẩm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DatePicker_Year_SanPham
            // 
            this.DatePicker_Year_SanPham.FillColor = System.Drawing.Color.White;
            this.DatePicker_Year_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DatePicker_Year_SanPham.Location = new System.Drawing.Point(1228, 8);
            this.DatePicker_Year_SanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DatePicker_Year_SanPham.MaxLength = 4;
            this.DatePicker_Year_SanPham.MinimumSize = new System.Drawing.Size(63, 0);
            this.DatePicker_Year_SanPham.Name = "DatePicker_Year_SanPham";
            this.DatePicker_Year_SanPham.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.DatePicker_Year_SanPham.ShowType = Sunny.UI.UIDateType.Year;
            this.DatePicker_Year_SanPham.Size = new System.Drawing.Size(87, 29);
            this.DatePicker_Year_SanPham.SymbolDropDown = 61555;
            this.DatePicker_Year_SanPham.SymbolNormal = 61555;
            this.DatePicker_Year_SanPham.SymbolSize = 24;
            this.DatePicker_Year_SanPham.TabIndex = 119;
            this.DatePicker_Year_SanPham.Text = "2024";
            this.DatePicker_Year_SanPham.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DatePicker_Year_SanPham.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.DatePicker_Year_SanPham.Watermark = "";
            this.DatePicker_Year_SanPham.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.DatePicker_Year_SanPham_ValueChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(1109, 12);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(130, 25);
            this.uiLabel1.TabIndex = 118;
            this.uiLabel1.Text = "Lọc theo năm";
            // 
            // DatePicker_MY_SanPham
            // 
            this.DatePicker_MY_SanPham.DateYearMonthFormat = "MM-yyyy";
            this.DatePicker_MY_SanPham.FillColor = System.Drawing.Color.White;
            this.DatePicker_MY_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DatePicker_MY_SanPham.Location = new System.Drawing.Point(180, 8);
            this.DatePicker_MY_SanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DatePicker_MY_SanPham.MaxLength = 7;
            this.DatePicker_MY_SanPham.MinimumSize = new System.Drawing.Size(63, 0);
            this.DatePicker_MY_SanPham.Name = "DatePicker_MY_SanPham";
            this.DatePicker_MY_SanPham.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.DatePicker_MY_SanPham.ShowType = Sunny.UI.UIDateType.YearMonth;
            this.DatePicker_MY_SanPham.Size = new System.Drawing.Size(110, 29);
            this.DatePicker_MY_SanPham.SymbolDropDown = 61555;
            this.DatePicker_MY_SanPham.SymbolNormal = 61555;
            this.DatePicker_MY_SanPham.SymbolSize = 24;
            this.DatePicker_MY_SanPham.TabIndex = 116;
            this.DatePicker_MY_SanPham.Text = "11-2024";
            this.DatePicker_MY_SanPham.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DatePicker_MY_SanPham.Value = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.DatePicker_MY_SanPham.Watermark = "";
            this.DatePicker_MY_SanPham.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.DatePicker_MY_SanPham_ValueChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(12, 12);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(180, 25);
            this.uiLabel2.TabIndex = 115;
            this.uiLabel2.Text = "Chọn mốc thời gian";
            // 
            // PieChart_DoanhThu
            // 
            this.PieChart_DoanhThu.ChartStyleType = Sunny.UI.UIChartStyleType.Default;
            this.PieChart_DoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PieChart_DoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PieChart_DoanhThu.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PieChart_DoanhThu.Location = new System.Drawing.Point(0, 58);
            this.PieChart_DoanhThu.MinimumSize = new System.Drawing.Size(1, 1);
            this.PieChart_DoanhThu.Name = "PieChart_DoanhThu";
            this.PieChart_DoanhThu.Size = new System.Drawing.Size(1348, 734);
            this.PieChart_DoanhThu.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PieChart_DoanhThu.TabIndex = 6;
            this.PieChart_DoanhThu.Text = "uiPieChart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PieChart_XuHuong);
            this.tabPage3.Controls.Add(this.DatePicker_MY_XuHuong);
            this.tabPage3.Controls.Add(this.uiLabel3);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1348, 792);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Xu hướng";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // PieChart_XuHuong
            // 
            this.PieChart_XuHuong.ChartStyleType = Sunny.UI.UIChartStyleType.Default;
            this.PieChart_XuHuong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PieChart_XuHuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PieChart_XuHuong.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PieChart_XuHuong.Location = new System.Drawing.Point(0, 58);
            this.PieChart_XuHuong.MinimumSize = new System.Drawing.Size(1, 1);
            this.PieChart_XuHuong.Name = "PieChart_XuHuong";
            this.PieChart_XuHuong.Size = new System.Drawing.Size(1348, 734);
            this.PieChart_XuHuong.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PieChart_XuHuong.TabIndex = 119;
            this.PieChart_XuHuong.Text = "uiPieChart1";
            // 
            // DatePicker_MY_XuHuong
            // 
            this.DatePicker_MY_XuHuong.DateYearMonthFormat = "MM-yyyy";
            this.DatePicker_MY_XuHuong.FillColor = System.Drawing.Color.White;
            this.DatePicker_MY_XuHuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DatePicker_MY_XuHuong.Location = new System.Drawing.Point(331, 8);
            this.DatePicker_MY_XuHuong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DatePicker_MY_XuHuong.MaxLength = 7;
            this.DatePicker_MY_XuHuong.MinimumSize = new System.Drawing.Size(63, 0);
            this.DatePicker_MY_XuHuong.Name = "DatePicker_MY_XuHuong";
            this.DatePicker_MY_XuHuong.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.DatePicker_MY_XuHuong.ReadOnly = true;
            this.DatePicker_MY_XuHuong.ShowType = Sunny.UI.UIDateType.YearMonth;
            this.DatePicker_MY_XuHuong.Size = new System.Drawing.Size(110, 29);
            this.DatePicker_MY_XuHuong.SymbolDropDown = 61555;
            this.DatePicker_MY_XuHuong.SymbolNormal = 61555;
            this.DatePicker_MY_XuHuong.SymbolSize = 24;
            this.DatePicker_MY_XuHuong.TabIndex = 118;
            this.DatePicker_MY_XuHuong.Text = "11-2024";
            this.DatePicker_MY_XuHuong.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DatePicker_MY_XuHuong.Value = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.DatePicker_MY_XuHuong.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(12, 12);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(340, 25);
            this.uiLabel3.TabIndex = 117;
            this.uiLabel3.Text = "Thông tin dự đoán số lượng sản phẩm";
            // 
            // FThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 832);
            this.Controls.Add(this.uiTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FThongKe";
            this.Text = "FThongKe";
            this.Load += new System.EventHandler(this.FThongKe_Load);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UIBarChart BarChart_DoanhThu;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UIPieChart PieChart_DoanhThu;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIDatePicker DatePicker_MY_SanPham;
        private Sunny.UI.UIDatePicker DatePicker_Year_DoanhThu;
        private Sunny.UI.UIDatePicker DatePicker_Year_SanPham;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.TabPage tabPage3;
        private Sunny.UI.UIPieChart PieChart_XuHuong;
        private Sunny.UI.UIDatePicker DatePicker_MY_XuHuong;
        private Sunny.UI.UILabel uiLabel3;
    }
}