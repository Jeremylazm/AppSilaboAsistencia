using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_DialogoPregunta : Form
    {
        public P_DialogoPregunta(string Mensaje, bool TipoPregunta)
        {
            InitializeComponent();
            lblMensaje.Text = Mensaje;
            
            if (TipoPregunta)
            {
                btnVerdadero.Text = "Sí";
                btnFalso.Text = "No";
            }
        }

        public static void Mostrar(string Mensaje, bool TipoPregunta = false)
        {
            P_DialogoPregunta Dialogo = new P_DialogoPregunta(Mensaje, TipoPregunta);
            Dialogo.ShowDialog();
        }

        private void P_DialogoPregunta_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            FormAparicion.Start();
        }

        private void FormAparicion_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.2;
            if (this.Opacity == 1)
            {
                FormAparicion.Stop();
                ImagenAparicion.ShowSync(pbImagen);
                btnVerdadero.Visible = true;
                btnFalso.Visible = true;
            }
        }

        private void btnVerdadero_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFalso_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
