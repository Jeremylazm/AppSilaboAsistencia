using System;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static int Evento = 0;

        [System.Runtime.InteropServices.DllImport("Shcore.dll")]
        static extern int SetProcessDpiAwareness(int PROCESS_DPI_AWARENESS);

        // According to https://msdn.microsoft.com/en-us/library/windows/desktop/dn280512(v=vs.85).aspx
        private enum DpiAwareness
        {
            None = 0,
            SystemAware = 1,
            PerMonitorAware = 2
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SetProcessDpiAwareness((int)DpiAwareness.PerMonitorAware);

            Application.Run(new P_ReporteDocente());
        }
    }
}
