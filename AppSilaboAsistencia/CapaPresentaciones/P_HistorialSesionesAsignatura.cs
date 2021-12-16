using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_HistorialSesionesAsignatura : Form
    {
        public string CodAsignatura;
        public string CodDocente;

        public string CodSemestre;
        public string LimtFechaInf = "14/12/2021";
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();

        public P_HistorialSesionesAsignatura(string pCodAsignatura, string pCodDocente)
        {
            CodAsignatura = pCodAsignatura;
            CodDocente = pCodDocente;
            CodSemestre = "2021-II";
            InitializeComponent();
            MostrarRegistros();

            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
        }
        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 3;

            dgvDatos.Columns[1].HeaderText = "Fecha";
            dgvDatos.Columns[2].HeaderText = "Hora";
            dgvDatos.Columns[3].HeaderText = "TEMA(S)";

        }
        public void MostrarRegistros()
        {
            DataTable HoraInicioThAsg = N_HorarioAsignatura.BuscarHorarioAsignatura("2021-II", CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6), CodAsignatura.Substring(5, 1));
            string horainicioAsignatura = HoraInicioThAsg.Rows[0][6].ToString();
            dgvDatos.DataSource = N_AsistenciaDocente.AsistenciaDocenteAsignatura(CodSemestre, "IF", CodDocente, CodAsignatura, horainicioAsignatura, LimtFechaInf, LimtFechaSup);
            AccionesTabla();
        }
        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }
        public void BuscarRegistros()
        {
            //dgvDatos.DataSource = N_Asignatura.BuscarAsignaturas("IF", txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void btnAgregar_Click(object sender, EventArgs e)
		{
            P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente);
            NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistroAsistencia.ShowDialog();
            NuevoRegistroAsistencia.Dispose();
        }

		private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
        }
	}
}
