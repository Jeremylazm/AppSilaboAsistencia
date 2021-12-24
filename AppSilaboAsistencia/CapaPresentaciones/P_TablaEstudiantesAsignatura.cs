using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_TablaEstudiantesAsignatura : Form
    {
        public string CodAsignatura;

        public P_TablaEstudiantesAsignatura(string pCodAsignatura)
        {
            CodAsignatura = pCodAsignatura;
            InitializeComponent();
            Control[] Controles = { this, lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
            MostrarEstudiantes();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].HeaderText = "Id.";
            dgvDatos.Columns[1].HeaderText = "Código";
            dgvDatos.Columns[2].HeaderText = "Apellido Paterno";
            dgvDatos.Columns[3].HeaderText = "Apellido Materno";
            dgvDatos.Columns[4].HeaderText = "Nombre";
        }

        private void MostrarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.BuscarEstudiantesAsignatura("2021-II", CodAsignatura.Substring(6), CodAsignatura);
            AccionesTabla();
        }

        public void BuscarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.BuscarEstudiantesMatriculadosAsignatura("2021-II", CodAsignatura.Substring(6), CodAsignatura, txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEstudiantes();
        }
    }
}
