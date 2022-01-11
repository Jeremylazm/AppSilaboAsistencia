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

                btnGeneral.Visible = false;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);

                //CriterioSeleccionAsistenciaEstudiantes();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                lblCriterioSeleccion.Visible = false;
                cxtCriterioSeleccion.Visible = false;

                btnGeneral.Visible = true;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);

                //fnReporte5();
            }
        }

        private void cxtCriterioSeleccion_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
