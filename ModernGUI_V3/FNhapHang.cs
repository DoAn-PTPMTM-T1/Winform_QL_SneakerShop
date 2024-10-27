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
        public FNhapHang()
        {
            InitializeComponent();
        }
        string manv;
        private void FNhapHang_Load(object sender, EventArgs e)
        {
            FormPrincipal mainForm = this.Owner as FormPrincipal;
            manv = mainForm.manv;
            txtMaNV.Text = mainForm.manv;
        }
    }
}
