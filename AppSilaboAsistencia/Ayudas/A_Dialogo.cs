using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayudas
{
    public class A_Dialogo
    {
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
    }
}
