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
    public partial class P_DialogoAsistenciaDocenteAsignatura : Form
    {
        public P_DialogoAsistenciaDocenteAsignatura()
        {
            InitializeComponent();
            Control[] Controles = { pbImagen, lblTitulo, lblPregunta };
            Docker.SubscribeControlsToDragEvents(Controles);
            cxtObservaciones.SelectedIndex = 0;
        }

        private void P_DialogoAsistenciaDocenteAsignatura_Load(object sender, EventArgs e)
        {
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
                AparicionImagen.ShowSync(pbImagen);
                lblTitulo.Visible = true;
                lblPregunta.Visible = true;
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
            // Animar los controles
            AparicionOtrosControles.HideSync(btnVerdadero);
            AparicionOtrosControles.HideSync(btnFalso);
            btnVerdadero.Visible = false;
            btnFalso.Visible = false;
            this.Height = 528;
            AparicionOtrosControles.ShowSync(lblJustificacion);
            AparicionOtrosControles.ShowSync(txtJustificacion);
            AparicionOtrosControles.ShowSync(lblObservaciones);
            AparicionOtrosControles.ShowSync(cxtObservaciones);
            AparicionOtrosControles.ShowSync(btnAtras);
            AparicionOtrosControles.ShowSync(btnGuardar);
            lblJustificacion.Visible = true;
            txtJustificacion.Visible = true;
            lblObservaciones.Visible = true;
            cxtObservaciones.Visible = true;
            btnAtras.Visible = true;
            btnGuardar.Visible = true;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Animar los controles
            AparicionOtrosControles.HideSync(btnGuardar);
            AparicionOtrosControles.HideSync(btnAtras);
            AparicionOtrosControles.HideSync(cxtObservaciones);
            AparicionOtrosControles.HideSync(lblObservaciones);
            AparicionOtrosControles.HideSync(txtJustificacion);
            AparicionOtrosControles.HideSync(lblJustificacion);
            lblJustificacion.Visible = false;
            txtJustificacion.Visible = false;
            lblObservaciones.Visible = false;
            cxtObservaciones.Visible = false;
            btnAtras.Visible = false;
            btnGuardar.Visible = false;
            this.Height = 354;
            AparicionOtrosControles.ShowSync(btnVerdadero);
            AparicionOtrosControles.ShowSync(btnFalso);
            btnVerdadero.Visible = true;
            btnFalso.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtJustificacion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
