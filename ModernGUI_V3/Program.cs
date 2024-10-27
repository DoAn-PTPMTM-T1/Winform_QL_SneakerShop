using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = Properties.Settings.Default.STRConn;
            if (connectionString.Contains("Initial Catalog=ShopSneaker"))
            {
                Application.Run(new Login());
            }
            else
            {
                Application.Run(new FConfig());
            }
        }
    }
}
