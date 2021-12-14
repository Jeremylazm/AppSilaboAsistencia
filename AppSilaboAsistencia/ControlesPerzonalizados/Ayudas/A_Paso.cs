using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace CapaPresentaciones.Ayudas
{
    public class A_Paso
    {
        public void Siguiente(Form FormularioPadre, string ImagenActual, string ImagenSiguiente, string NombrePaginaSiguiente)
        {
            BunifuPictureBox PictureActual = (BunifuPictureBox)FormularioPadre.Controls.Find("pnContenedor", false)[0].Controls.Find(ImagenActual, false)[0];
            PictureActual.Image = ControlesPerzonalizados.Properties.Resources.Circulo_Checked;

            BunifuPictureBox PictureSiguiente = (BunifuPictureBox)FormularioPadre.Controls.Find("pnContenedor", false)[0].Controls.Find(ImagenSiguiente, false)[0];
            PictureSiguiente.Image = ControlesPerzonalizados.Properties.Resources.Circulo_Unchecked;

            FormularioPadre.Controls.Find("pnContenedor", false)[0].Controls.Find("pnPasos", false)[0].Controls.Find(NombrePaginaSiguiente, false)[0].BringToFront();
        }

        public void Atras(Form FormularioPadre, string ImagenActual, string ImagenAnterior, string NombrePaginaAnterior)
        {
            BunifuPictureBox PictureActual = (BunifuPictureBox)FormularioPadre.Controls.Find("pnContenedor", false)[0].Controls.Find(ImagenActual, false)[0];
            PictureActual.Image = ControlesPerzonalizados.Properties.Resources.Circulo;

            BunifuPictureBox PictureSiguiente = (BunifuPictureBox)FormularioPadre.Controls.Find("pnContenedor", false)[0].Controls.Find(ImagenAnterior, false)[0];
            PictureSiguiente.Image = ControlesPerzonalizados.Properties.Resources.Circulo_Unchecked;

            FormularioPadre.Controls.Find("pnContenedor", false)[0].Controls.Find("pnPasos", false)[0].Controls.Find(NombrePaginaAnterior, false)[0].BringToFront();
        }
    }
}
