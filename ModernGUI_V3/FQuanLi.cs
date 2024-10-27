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
    public partial class FQuanLi : Form
    {
        public FQuanLi()
        {
            InitializeComponent();
            Enable_Control_banDau();
        }

        void Enable_Control_banDau()
        {
            control_DanhMuc.btnAdd.Enabled = true;
            control_CungUng.btnAdd.Enabled = true;
            control_NCC.btnAdd.Enabled = true;
            control_NhanVien.btnAdd.Enabled = true;
            control_SanPham.btnAdd.Enabled = true;
            control_ThuongHieu.btnAdd.Enabled = true;
        }

    }
}
