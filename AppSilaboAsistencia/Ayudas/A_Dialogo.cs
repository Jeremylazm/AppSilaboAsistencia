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
            A_DialogoRespuesta2 Dialogo = new A_DialogoRespuesta2(Pregunta, "Aceptar", "Cancelar");
            Dialogo.ShowDialog();
            return Dialogo.DialogResult;
        }

        public static DialogResult DialogoPreguntaSiNo(string Pregunta)
        {
            A_DialogoRespuesta2 Dialogo = new A_DialogoRespuesta2(Pregunta, "Sí", "No");
            Dialogo.ShowDialog();
            return Dialogo.DialogResult;
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
