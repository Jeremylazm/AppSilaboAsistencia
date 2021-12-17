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
        private bool TipoPregunta { get; set; }

        public P_DialogoPregunta(string Mensaje, bool pTipoPregunta = false)
        {
            InitializeComponent();
            Control[] Controles = { pbImagen, lblNombre, lblMensaje };
            Docker.SubscribeControlsToDragEvents(Controles);
            lblMensaje.Text = Mensaje;
            TipoPregunta = pTipoPregunta;

            if (TipoPregunta)
            {
                btnVerdadero.Text = "Sí";
                btnFalso.Text = "No";
            }
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
                lblNombre.Visible = true;
                lblMensaje.Visible = true;
                btnVerdadero.Visible = true;
                btnFalso.Visible = true;
            }
        }

        private void btnVerdadero_Click(object sender, EventArgs e)
        {
            if (TipoPregunta)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.OK;
        }

        private void btnFalso_Click(object sender, EventArgs e)
        {
            if (TipoPregunta)
                DialogResult = DialogResult.No;
            else
                DialogResult = DialogResult.Cancel;
        }
    }
}
