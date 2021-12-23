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
        private readonly string CodDocente = E_InicioSesion.Usuario;
        //public string CodDocente;

        public string CodSemestre;
        public string LimtFechaInf = "2021/01/01";
        public string LimtFechaSup = DateTime.Now.ToString("yyyy/MM/dd").ToString();

        public P_HistorialSesionesAsignatura(string pCodAsignatura, string pCodDocente)
        {
            CodAsignatura = pCodAsignatura;
            //CodDocente = pCodDocente;
            CodSemestre = "2021-II";
            InitializeComponent();
            MostrarRegistros();

            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
        }
        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 5;

            dgvDatos.Columns[1].HeaderText = "Fecha";
            dgvDatos.Columns[2].HeaderText = "Hora";
            dgvDatos.Columns[3].HeaderText = "Tema(s)";
            dgvDatos.Columns[4].HeaderText = "TotalAsistieron";
            dgvDatos.Columns[5].HeaderText = "TotalFaltaron";

        }
        public void MostrarRegistros()
        {
            DataTable HoraInicioThAsg = N_HorarioAsignatura.BuscarHorarioAsignatura(CodSemestre, CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6), CodAsignatura.Substring(5, 1));
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
            DataTable EstudiantesAsigantura = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, CodAsignatura.Substring(6), CodAsignatura);
            DataTable HoraInicioThAsg = N_HorarioAsignatura.BuscarHorarioAsignatura(CodSemestre, CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6), CodAsignatura.Substring(5, 1));
            string horainicioAsignatura = HoraInicioThAsg.Rows[0][6].ToString();

            Form Fondo = new Form();
            using (P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura))
            {
                Fondo.StartPosition = FormStartPosition.Manual;
                Fondo.FormBorderStyle = FormBorderStyle.None;
                Fondo.Opacity = .70d;
                Fondo.BackColor = Color.Black;
                Fondo.WindowState = FormWindowState.Maximized;
                Fondo.TopMost = true;
                Fondo.Location = this.Location;
                Fondo.ShowInTaskbar = false;
                Fondo.Show();

                NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);

                NuevoRegistroAsistencia.txtFecha.Text = DateTime.Now.ToString("yyyy/MM/dd").ToString();
                NuevoRegistroAsistencia.horainicioAsignatura = horainicioAsignatura;


                NuevoRegistroAsistencia.Owner = Fondo;
                NuevoRegistroAsistencia.ShowDialog();
                NuevoRegistroAsistencia.Dispose();

                Fondo.Dispose();
            }
        }

		private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                DataTable HoraInicioThAsg = N_HorarioAsignatura.BuscarHorarioAsignatura(CodSemestre, CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6), CodAsignatura.Substring(5, 1));
                string horainicioAsignatura = HoraInicioThAsg.Rows[0][6].ToString();
                DataTable AsistenciaEstudiantesAsignatura = N_AsistenciaEstudiante.AsistenciaEstudiantes(CodSemestre, "IF", CodAsignatura, horainicioAsignatura, Convert.ToDateTime(dgvDatos.Rows[e.RowIndex].Cells[1].Value).ToString("yyyy/MM/dd"));

                Form Fondo = new Form();
                using (P_TablaAsistenciaEstudiantes EditarRegistro = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, AsistenciaEstudiantesAsignatura))
                {
                    Fondo.StartPosition = FormStartPosition.Manual;
                    Fondo.FormBorderStyle = FormBorderStyle.None;
                    Fondo.Opacity = .70d;
                    Fondo.BackColor = Color.Black;
                    Fondo.WindowState = FormWindowState.Maximized;
                    Fondo.TopMost = true;
                    Fondo.Location = this.Location;
                    Fondo.ShowInTaskbar = false;
                    Fondo.Show();

                    Program.Evento = 1;

                    EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);

                    EditarRegistro.txtFecha.Text = Convert.ToDateTime(dgvDatos.Rows[e.RowIndex].Cells[1].Value).ToString("yyyy/MM/dd");
                    EditarRegistro.txtTema.Text = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    EditarRegistro.horainicioAsignatura = horainicioAsignatura;


                    EditarRegistro.Owner = Fondo;
                    EditarRegistro.ShowDialog();
                    EditarRegistro.Dispose();

                    Fondo.Dispose();
                }
            }
        }
	}
}
