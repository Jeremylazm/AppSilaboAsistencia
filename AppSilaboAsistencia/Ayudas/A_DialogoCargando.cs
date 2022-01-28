using System;
using System.Windows.Forms;

namespace Ayudas
{
    public partial class A_DialogoCargando : Form
    {
        public A_DialogoCargando()
        {
            InitializeComponent();
        }

        public void Mostrar()
        {
            this.TopMost = true;
            this.Show();
            this.Opacity = 0.0;
            AparicionFormulario.Start();
        }

        private void AparicionFormulario_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.2;
            if (this.Opacity == 1)
            {
                AparicionFormulario.Stop();
                pbProgreso.Visible = true;
                lblTitulo.Visible = true;
                lblMensaje.Visible = true;
            }
        }

        public void Ocultar()
        {
            this.TopMost = false;
            this.Hide();
        }
    }
}
