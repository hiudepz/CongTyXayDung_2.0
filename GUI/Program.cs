using GUI.Admin;
using GUI.NhanVienKeToan;
using GUI.NhanVienKho;
using GUI.Login;
using System;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using GUI.Report;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuanLyNguoiDung());
        }
    }
}
