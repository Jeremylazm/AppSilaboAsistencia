using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace Ayudas
{
    public class A_Paso
    {
        private Control Contenedor(Form Formulario)
        {
            return Formulario.Controls.Find("pnContenedor", false)[0];
        }

        public void Siguiente(Form FormularioPadre, string Actual, string Siguiente, string NombrePaginaSiguiente)
        {
            BunifuPictureBox PictureActual = (BunifuPictureBox)Contenedor(FormularioPadre).Controls.Find("pb" + Actual, false)[0];
            PictureActual.Image = Properties.Resources.Circulo_Checked;

            BunifuPictureBox PictureSiguiente = (BunifuPictureBox)Contenedor(FormularioPadre).Controls.Find("pb" + Siguiente, false)[0];
            PictureSiguiente.Image = Properties.Resources.Circulo_Unchecked;

            BunifuLabel LabelSiguiente = (BunifuLabel)Contenedor(FormularioPadre).Controls.Find("lbl" + Siguiente, false)[0];
            LabelSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));

            BunifuSeparator SeparatorSiguiente = (BunifuSeparator)Contenedor(FormularioPadre).Controls.Find("ln" + Siguiente, false)[0];
            SeparatorSiguiente.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));

            Contenedor(FormularioPadre).Controls.Find("pnPasos", false)[0].Controls.Find(NombrePaginaSiguiente, false)[0].BringToFront();
            FormularioPadre.ActiveControl = Contenedor(FormularioPadre).Controls.Find("pnPasos", false)[0].Controls.Find(NombrePaginaSiguiente, false)[0];
        }

        public void Atras(Form FormularioPadre, string Actual, string Anterior, string NombrePaginaAnterior)
        {
            BunifuPictureBox PictureActual = (BunifuPictureBox)Contenedor(FormularioPadre).Controls.Find("pb" + Actual, false)[0];
            PictureActual.Image = Properties.Resources.Circulo;

            BunifuLabel LabelActual = (BunifuLabel)Contenedor(FormularioPadre).Controls.Find("lbl" + Actual, false)[0];
            LabelActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));

            BunifuSeparator SeparatorActual = (BunifuSeparator)Contenedor(FormularioPadre).Controls.Find("ln" + Actual, false)[0];
            SeparatorActual.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));

            BunifuPictureBox PictureAnterior = (BunifuPictureBox)Contenedor(FormularioPadre).Controls.Find("pb" + Anterior, false)[0];
            PictureAnterior.Image = Properties.Resources.Circulo_Unchecked;

            Contenedor(FormularioPadre).Controls.Find("pnPasos", false)[0].Controls.Find(NombrePaginaAnterior, false)[0].BringToFront();
        }
    }
}
