using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace ModernGUI_V3
{
    public partial class FormPrincipal : Form
    {
        public string manv, hoten, chucvu;
        public FormPrincipal(string manv, string hoten, string chucvu)
        {
            InitializeComponent();
            UIStyles.CultureInfo = CultureInfos.en_US;

            this.manv = manv;
            this.hoten = hoten;
            this.chucvu = chucvu;
            txtTenNhanVien.Text = hoten;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        #region Load Form
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = false;
            btnRestaurar. Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(1200, 700);
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int x = (workingArea.Width - this.Width) / 2;
            int y = (workingArea.Height - this.Height) / 2;
            this.Location = new Point(x, y);
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region Đóng form khi mở form khác
        FBanHang form_BanHang = null;
        FQuanLi form_QuanLi = null;
        FKhachHang form_KhachHang = null;
        FNhapHang form_NhapHang = null;
        FThongKe form_ThongKe = null;
        FCaiDat form_CaiDat = null;
        void DongForm()
        {
            if (form_BanHang != null)
            {
                panelformularios.Controls.Remove(form_BanHang);
                form_BanHang = null;
            }

            if (form_QuanLi != null)
            {
                panelformularios.Controls.Remove(form_QuanLi);
                form_QuanLi = null;
            }

            if (form_KhachHang != null)
            {
                panelformularios.Controls.Remove(form_KhachHang);
                form_KhachHang = null;
            }

            if (form_NhapHang != null)
            {
                panelformularios.Controls.Remove(form_NhapHang);
                form_NhapHang = null;
            }

            if (form_ThongKe != null)
            {
                panelformularios.Controls.Remove(form_ThongKe);
                form_ThongKe = null;
            }

            if (form_CaiDat != null)
            {
                panelformularios.Controls.Remove(form_CaiDat);
                form_CaiDat = null;
            }
        }
        #endregion

        #region Xử lí mở form
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            DongForm();

            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm { Owner = this };
                formulario.TopLevel = false;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();

                switch (formulario)
                {
                    case FBanHang banHangForm:
                        form_BanHang = banHangForm;
                        break;
                    case FQuanLi quanLiForm:
                        form_QuanLi = quanLiForm;
                        break;
                    case FKhachHang khachHangForm:
                        form_KhachHang = khachHangForm;
                        break;
                    case FNhapHang NhapHangForm:
                        form_NhapHang = NhapHangForm;
                        break;
                    case FThongKe ThongKeForm:
                        form_ThongKe = ThongKeForm;
                        break;
                    case FCaiDat CaiDatForm:
                        form_CaiDat = CaiDatForm;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                formulario.Activate();
            }
        }


        private void btnBanHang_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FBanHang>(); 
        }

        private void btnQuanLi_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FQuanLi>();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FKhachHang>();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FNhapHang>();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FThongKe>();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Visible = true;
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FCaiDat>();
        }

        public void MoForm_KH()
        {
            panelformularios.Controls.Remove(form_BanHang);
            FKhachHang kh = new FKhachHang();
            kh.TopLevel = false;
            kh.Dock = DockStyle.Fill;
            panelformularios.Controls.Add(kh);
            panelformularios.Tag = kh;
            kh.Show();

            form_KhachHang = kh;
        }

        #endregion

    }
}
