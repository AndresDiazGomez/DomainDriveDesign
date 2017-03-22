using Infrastructure.Data;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SessionFactory.Init(ConfigurationManager.ConnectionStrings["DDDInPractice"].ConnectionString);
            Application.Run(new Form1());
        }
    }
}