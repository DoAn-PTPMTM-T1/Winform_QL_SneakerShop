using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ModernGUI_V3
{
    public partial class FConfig : Form
    {
        public FConfig()
        {
            InitializeComponent();
        }

        private void cboServer_Name_DropDown(object sender, EventArgs e)
        {
            cboServer_Name.DataSource = GetServerName();
            cboServer_Name.DisplayMember = "ServerName";
        }
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        private void cboDatabase_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboServer_Name.Text) || string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
                MessageBox.Show("Vui lòng điền đủ thông tin ở trên!");
            else
            {
                cboDatabase.DataSource = GetDBName(cboServer_Name.Text, txtUser.Text, txtPass.Text);
                cboDatabase.DisplayMember = "name";
            }
        }
        public DataTable GetDBName(string server, string user, string pass)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", "Data source = " + server +
                                    "; Initial Catalog = master; User ID = " + user + "; pwd = " + pass);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra các thông tin ở trên!");
            }
            return dt;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboServer_Name.Text) || string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(cboDatabase.Text))
                MessageBox.Show("Vui lòng điền đủ thông tin ở trên!");
            else
            {
                SaveConfig(cboServer_Name.Text, txtUser.Text, txtPass.Text, cboDatabase.Text);
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }
        public void SaveConfig(string server, string user, string pass, string DBName)
        {
            Properties.Settings.Default.STRConn = "Data Source=" + server + "; Initial Catalog=" + DBName +
                                                  "; User ID=" + user + "; pwd=" + pass + "";
            Properties.Settings.Default.Save();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboServer_Name.Clear();
            txtPass.Clear();
            txtUser.Clear();
            cboDatabase.Clear();
        }
    }
}
