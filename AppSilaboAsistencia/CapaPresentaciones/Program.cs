using System;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. :v
        /// </summary>

        public static int Evento = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new P_Menu());
        }
    }
}
