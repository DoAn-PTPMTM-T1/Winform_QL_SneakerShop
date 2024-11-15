using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sunny.UI;

namespace ModernGUI_V3
{
    public partial class FThongKe : Form
    {
        QLShopDataContext qlss = new QLShopDataContext();

        public FThongKe()
        {
            InitializeComponent();
            int currentYear = DateTime.Now.Year;
            Load_SanPham_TheoNam(currentYear);
            Load_BarChart(currentYear);
        }

        // Doanh thu 
        void Load_BarChart(int selectedYear)
        {
            var doanhThuThang = from hd in qlss.HoaDons
                                where hd.NgayHoaDon.HasValue && hd.NgayHoaDon.Value.Year == selectedYear
                                group hd by hd.NgayHoaDon.Value.Month into g
                                select new
                                {
                                    Thang = g.Key,
                                    DoanhThu = g.Sum(hd => hd.TongTien),
                                    TongTienSauGiamGia = g.Sum(hd => hd.TongTienSauGiamGia)
                                };

            var giaVonThang = from pn in qlss.PhieuNhaps
                              where pn.NgayPhieuNhap.HasValue && pn.NgayPhieuNhap.Value.Year == selectedYear
                              group pn by pn.NgayPhieuNhap.Value.Month into g
                              select new
                              {
                                  Thang = g.Key,
                                  GiaVon = g.Sum(pn => pn.TongTien)
                              };

            // Chuẩn bị dữ liệu cho biểu đồ
            UIBarOption option = new UIBarOption();
            option.Title = new UITitle();
            option.Title.Text = "Thống kê năm " + selectedYear;
            option.Title.SubText = "";

            // Thiết lập Legend
            option.Legend = new UILegend();
            option.Legend.Orient = UIOrient.Horizontal;
            option.Legend.Top = UITopAlignment.Top;
            option.Legend.Left = UILeftAlignment.Left;
            option.Legend.AddData("Doanh Thu");
            option.Legend.AddData("Giá Vốn");
            option.Legend.AddData("Lợi Nhuận");
            option.Legend.AddData("Giảm Giá");

            var seriesDoanhThu = new UIBarSeries();
            seriesDoanhThu.Name = "Doanh Thu";

            var seriesGiaVon = new UIBarSeries();
            seriesGiaVon.Name = "Giá Vốn";

            var seriesLoiNhuan = new UIBarSeries();
            seriesLoiNhuan.Name = "Lợi Nhuận";

            var seriesGiamGia = new UIBarSeries();
            seriesGiamGia.Name = "Giảm Giá";

            decimal LoiNhuanMax = 0;

            for (int i = 1; i <= 12; i++)
            {
                var thangDoanhThu = doanhThuThang.FirstOrDefault(d => d.Thang == i);
                var thangGiaVon = giaVonThang.FirstOrDefault(g => g.Thang == i);

                decimal doanhThu = thangDoanhThu != null ? (decimal)thangDoanhThu.DoanhThu : 0;
                decimal giaVon = thangGiaVon != null ? (decimal)thangGiaVon.GiaVon : 0;
                decimal loiNhuan = doanhThu - giaVon;
                decimal giamGia = thangDoanhThu != null ? (decimal)(thangDoanhThu.DoanhThu - thangDoanhThu.TongTienSauGiamGia) : 0;

                if (loiNhuan > LoiNhuanMax)
                {
                    LoiNhuanMax = loiNhuan;
                }

                seriesDoanhThu.AddData((double)doanhThu);
                seriesGiaVon.AddData((double)giaVon);
                seriesLoiNhuan.AddData((double)loiNhuan);
                seriesGiamGia.AddData((double)giamGia);
            }

            option.Series.Add(seriesDoanhThu);
            option.Series.Add(seriesGiaVon);
            option.Series.Add(seriesLoiNhuan);
            option.Series.Add(seriesGiamGia);

            string[] thangLabels = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            foreach (var label in thangLabels)
            {
                option.XAxis.Data.Add(label);
            }

            option.ToolTip.Visible = true;
            option.YAxis.Scale = true;

            option.XAxis.Name = "Tháng";
            option.XAxis.AxisLabel.Angle = 0; // (0° ~ 90°)

            option.YAxis.Name = "Giá trị";

            if (doanhThuThang.Any())
            {
                decimal DoanhThuMax = (decimal)doanhThuThang.Max(d => d.DoanhThu);
                decimal VonMax = (decimal)giaVonThang.Max(g => g.GiaVon);

                var doanhThuScaleLine = new UIScaleLine()
                {
                    Color = Color.Red,
                    Name = "Doanh thu cao nhất",
                    Value = (double)DoanhThuMax,
                    Left = UILeftAlignment.Left
                };

                var vonScaleLine = new UIScaleLine()
                {
                    Color = Color.Blue,
                    Name = "Vốn nhập hàng cao nhất",
                    Value = (double)VonMax,
                    Left = UILeftAlignment.Center
                };

                var loiNhuanScaleLine = new UIScaleLine()
                {
                    Color = Color.DarkGray,
                    Name = "Lợi nhuận cao nhất",
                    Value = (double)LoiNhuanMax,
                    Left = UILeftAlignment.Right
                };

                // Thêm các ScaleLine vào biểu đồ
                option.YAxisScaleLines.Add(doanhThuScaleLine);
                option.YAxisScaleLines.Add(vonScaleLine);
                option.YAxisScaleLines.Add(loiNhuanScaleLine);
            }

            option.ToolTip.AxisPointer.Type = UIAxisPointerType.Shadow;

            option.ShowValue = true;

            BarChart_DoanhThu.SetOption(option);
        }

        // Sản phẩm
        void Load_PieChart_TheoThang(int selectedYear, int selectedMonth)
        {
            var soLuongSanPham = from cthd in qlss.ChiTietHoaDons
                                 join sp in qlss.SanPhams on cthd.MaSanPham equals sp.MaSanPham
                                 where cthd.HoaDon.NgayHoaDon.HasValue && cthd.HoaDon.NgayHoaDon.Value.Year == selectedYear
                                 && (selectedMonth == 0 || cthd.HoaDon.NgayHoaDon.Value.Month == selectedMonth)
                                 group cthd by sp.TenSanPham into g
                                 select new
                                 {
                                     TenSanPham = g.Key,
                                     SoLuong = g.Sum(cthd => cthd.SoLuong)
                                 };

            var option = new UIPieOption();
            option.Title = new UITitle();
            option.Title.Text = "Số lượng sản phẩm " + selectedMonth + "/" + selectedYear;
            option.Title.SubText = "";
            option.Title.Left = UILeftAlignment.Center;

            option.ToolTip.Visible = true;

            option.Legend = new UILegend();
            option.Legend.Orient = UIOrient.Vertical;
            option.Legend.Top = UITopAlignment.Top;
            option.Legend.Left = UILeftAlignment.Left;

            var series = new UIPieSeries();
            series.Name = "Số Lượng";
            series.Center = new UICenter(50, 55);
            series.Radius = 50;
            series.Label.Show = true;

            foreach (var item in soLuongSanPham)
            {
                option.Legend.AddData(item.TenSanPham);
                series.AddData(item.TenSanPham, (double)item.SoLuong);
            }

            option.Series.Clear();
            option.Series.Add(series);

            PieChart_DoanhThu.SetOption(option);
        }

        void Load_SanPham_TheoNam(int selectedYear)
        {
            var soLuongSanPham = from cthd in qlss.ChiTietHoaDons
                                 join sp in qlss.SanPhams on cthd.MaSanPham equals sp.MaSanPham
                                 where cthd.HoaDon.NgayHoaDon.HasValue && cthd.HoaDon.NgayHoaDon.Value.Year == selectedYear
                                 group cthd by sp.TenSanPham into g
                                 select new
                                 {
                                     TenSanPham = g.Key,
                                     SoLuong = g.Sum(cthd => cthd.SoLuong)
                                 };

            var option = new UIPieOption();
            option.Title = new UITitle();
            option.Title.Text = "Số lượng sản phẩm năm " + selectedYear;
            option.Title.SubText = "";
            option.Title.Left = UILeftAlignment.Center;

            option.ToolTip.Visible = true;

            option.Legend = new UILegend();
            option.Legend.Orient = UIOrient.Vertical;
            option.Legend.Top = UITopAlignment.Top;
            option.Legend.Left = UILeftAlignment.Left;

            var series = new UIPieSeries();
            series.Name = "Số Lượng";
            series.Center = new UICenter(50, 55);
            series.Radius = 50;
            series.Label.Show = true;

            foreach (var item in soLuongSanPham)
            {
                option.Legend.AddData(item.TenSanPham);
                series.AddData(item.TenSanPham, (double)item.SoLuong);
            }

            option.Series.Clear();
            option.Series.Add(series);

            PieChart_DoanhThu.SetOption(option);
        }

        private void DatePicker_Year_DoanhThu_ValueChanged(object sender, DateTime value)
        {
            int selectedYear = value.Year;

            Load_BarChart(selectedYear);
        }

        private void DatePicker_MY_SanPham_ValueChanged(object sender, DateTime value)
        {
            int selectedYear = value.Year;
            int selectedMonth = value.Month;

            Load_PieChart_TheoThang(selectedYear, selectedMonth);
        }

        private void DatePicker_Year_SanPham_ValueChanged(object sender, DateTime value)
        {
            int selectedYear = value.Year;
            Load_SanPham_TheoNam(selectedYear);
        }
    }
}
