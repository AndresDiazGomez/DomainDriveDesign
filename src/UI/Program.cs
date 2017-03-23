using Infrastructure.Data;
using System;
using System.Configuration;
using System.Windows.Forms;
using UI.Utils;

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
            Initer.Init();
            Application.Run(new AtmForm());
        }
    }
}