using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayudas
{
    public class A_Dialogo
    {
        private static int Tiempo { get; set; }

        public static DialogResult DialogoPreguntaAceptarCancelar(string Pregunta)
        {
            Form Fondo = new Form();
            using (A_DialogoRespuesta2 Dialogo = new A_DialogoRespuesta2(Pregunta, "Aceptar", "Cancelar"))
            {
                Fondo.StartPosition = FormStartPosition.Manual;
                Fondo.FormBorderStyle = FormBorderStyle.None;
                Fondo.Opacity = .70d;
                Fondo.BackColor = Color.Black;
                Fondo.WindowState = FormWindowState.Maximized;
                Fondo.TopMost = true;
                //Fondo.Location = Formulario.Location;
                Fondo.ShowInTaskbar = false;
                Fondo.Show();

                Dialogo.Owner = Fondo;
                Dialogo.ShowDialog();
                Dialogo.Dispose();

                Fondo.Dispose();

                return Dialogo.DialogResult;
            }
        }

        public static DialogResult DialogoPreguntaSiNo(string Pregunta)
        {
            Form Fondo = new Form();
            using (A_DialogoRespuesta2 Dialogo = new A_DialogoRespuesta2(Pregunta, "Sí", "No"))
            {
                Fondo.StartPosition = FormStartPosition.Manual;
                Fondo.FormBorderStyle = FormBorderStyle.None;
                Fondo.Opacity = .70d;
                Fondo.BackColor = Color.Black;
                Fondo.WindowState = FormWindowState.Maximized;
                Fondo.TopMost = true;
                //Fondo.Location = Formulario.Location;
                Fondo.ShowInTaskbar = false;
                Fondo.Show();

                Dialogo.Owner = Fondo;
                Dialogo.ShowDialog();
                Dialogo.Dispose();

                Fondo.Dispose();

                return Dialogo.DialogResult;
            }
        }

        public static void DialogoConfirmacion(string Mensaje)
        {
            A_DialogoRespuesta1.Mostrar(Mensaje, (Image)Properties.Resources.Dialogo_Confirmacion);
        }

        public static void DialogoError(string Mensaje)
        {
            A_DialogoRespuesta1.Mostrar(Mensaje, (Image)Properties.Resources.Dialogo_Error);
        }

        public static void DialogoInformacion(string Mensaje)
        {
            A_DialogoRespuesta1.Mostrar(Mensaje, (Image)Properties.Resources.Dialogo_Informacion);
        }

        private static void TiempoCarga()
        {
            for (int K = 0; K <= 1000; K++)
            {
                Thread.Sleep(Tiempo);
            }
        }

        public static void DialogoCargando(Form Formulario, int pTiempo)
        {
            //Tiempo = pTiempo;
            //using (A_DialogoCargando Dialogo = new A_DialogoCargando(TiempoCarga))
            //{
            //    Dialogo.ShowDialog(Formulario);
            //}
        }

        private void EstablecerCarga(Form Formulario, bool displayLoader)
        {
            if (displayLoader)
            {
                Formulario.Invoke((MethodInvoker)delegate
                {
                    //EnProceso = true;
                    //Dialogo.Mostrar();
                });
            }
            else
            {
                Formulario.Invoke((MethodInvoker)delegate
                {
                    //Dialogo.Ocultar();
                    //EnProceso = false;
                });
            }
        }
    }
}
