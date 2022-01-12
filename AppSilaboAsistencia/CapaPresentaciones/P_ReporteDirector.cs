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
    public partial class P_ReporteDirector : Form
    {
        public P_ReporteDirector()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void P_ReporteDirector_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {

        }

        private void cxtTipoReporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                lblCriterioSeleccion.Visible = true;
                cxtCriterioSeleccion.Visible = true;

                lblFechaInicial.Visible = true;
                dpFechaInicial.Visible = true;

                lblFechaFinal.Visible = true;
                dpFechaFinal.Visible = true;

                if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
                {
                    lblCodEstudiante.Visible = true;
                    txtCodEstudiante.Visible = true;
                    lnCodEstudiante.Visible = true;
                    lblEstudiante.Visible = true;
                    txtEstudiante.Visible = true;
                    lnEstudiante.Visible = true;

                    lblCodigo.Visible = false;
                    txtCodigo.Visible = false;
                    lnCodigo.Visible = false;
                    pnCajas.Visible = false;

                    btnGeneral.Visible = false;
                    btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);
                }
                else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Asignaturas"))
                {
                    lblCodEstudiante.Visible = false;
                    txtCodEstudiante.Visible = false;
                    lnCodEstudiante.Visible = false;
                    lblEstudiante.Visible = false;
                    txtEstudiante.Visible = false;
                    lnEstudiante.Visible = false;

                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;
                    lnCodigo.Visible = true;
                    pnCajas.Visible = true;

                    btnGeneral.Visible = true;
                    btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);
                }
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                lblCriterioSeleccion.Visible = false;
                cxtCriterioSeleccion.Visible = false;

                lblFechaInicial.Visible = false;
                dpFechaInicial.Visible = false;

                lblFechaFinal.Visible = false;
                dpFechaFinal.Visible = false;

                btnGeneral.Visible = true;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);
            }
        }

        private void cxtCriterioSeleccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
            {
                lblCodEstudiante.Visible = true;
                txtCodEstudiante.Visible = true;
                lnCodEstudiante.Visible = true;
                lblEstudiante.Visible = true;
                txtEstudiante.Visible = true;
                lnEstudiante.Visible = true;

                lblCodigo.Visible = false;
                txtCodigo.Visible = false;
                lnCodigo.Visible = false;
                pnCajas.Visible = false;

                btnGeneral.Visible = false;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);
            }
            else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Asignaturas"))
            {
                lblCodEstudiante.Visible = false;
                txtCodEstudiante.Visible = false;
                lnCodEstudiante.Visible = false;
                lblEstudiante.Visible = false;
                txtEstudiante.Visible = false;
                lnEstudiante.Visible = false;

                lblCodigo.Visible = true;
                txtCodigo.Visible = true;
                lnCodigo.Visible = true;
                pnCajas.Visible = true;

                btnGeneral.Visible = true;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);
            }
        }
    }
}
