using System;
using System.Windows.Forms;
using ThumbtackBot.Service;

namespace ThumbtackBot
{
    static class Program
    {
        static ManagerThumbtack managerThumbtack = new ManagerThumbtack();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
