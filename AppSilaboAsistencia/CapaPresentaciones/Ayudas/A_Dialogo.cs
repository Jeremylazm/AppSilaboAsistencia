using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones.Ayudas
{
    public class A_Dialogo
    {
        public static DialogResult DialogoPreguntaAceptarCancelar(string Pregunta)
        {
            P_DialogoRespuesta2 Dialogo = new P_DialogoRespuesta2(Pregunta, "Aceptar", "Cancelar");
            Dialogo.ShowDialog();
            return Dialogo.DialogResult;
        }

        public static DialogResult DialogoPreguntaSiNo(string Pregunta)
        {
            P_DialogoRespuesta2 Dialogo = new P_DialogoRespuesta2(Pregunta, "Sí", "No");
            Dialogo.ShowDialog();
            return Dialogo.DialogResult;
        }

        public static void DialogoConfirmacion(string Mensaje)
        {
            P_DialogoRespuesta1.Mostrar(Mensaje, (Image)Properties.Resources.Circulo_Checked);
        }

        public static void DialogoError(string Mensaje)
        {
            P_DialogoRespuesta1.Mostrar(Mensaje, (Image)Properties.Resources.Dialogo_Error);
        }

        public static void DialogoInformacion(string Mensaje)
        {
            P_DialogoRespuesta1.Mostrar(Mensaje, (Image)Properties.Resources.Dialogo_Informacion);
        }
    }
}
