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
        private readonly string CodSemestre;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();
        public string HoraRegistro= DateTime.Now.ToString("hh:mm:ss");

        public P_HistorialSesionesAsignatura(string pCodAsignatura)
        {
            CodAsignatura = pCodAsignatura;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LimtFechaInf = Semestre.Rows[0][1].ToString();
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
            dgvDatos.DataSource = N_AsistenciaDocente.MostrarSesionesAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaInf, LimtFechaSup);
            AccionesTabla();
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        public void BuscarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDocente.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaInf, LimtFechaSup,txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void btnAgregar_Click(object sender, EventArgs e)
		{
            DataTable EstudiantesAsigantura = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, CodAsignatura.Substring(6), CodAsignatura);

            Form Fondo = new Form();
            /*using (P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura))
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
                NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
                NuevoRegistroAsistencia.hora = HoraRegistro;
                NuevoRegistroAsistencia.Owner = Fondo;
                NuevoRegistroAsistencia.ShowDialog();
                NuevoRegistroAsistencia.Dispose();

                Fondo.Dispose();
            }*/
            P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura);
            NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
            NuevoRegistroAsistencia.hora = HoraRegistro;
            NuevoRegistroAsistencia.Owner = Fondo;
            NuevoRegistroAsistencia.ShowDialog();
            NuevoRegistroAsistencia.Dispose();
        }

		private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                
                DataTable AsistenciaEstudiantesAsignatura = N_AsistenciaEstudiante.AsistenciaEstudiantes(CodSemestre, CodAsignatura, dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString());

                Form Fondo = new Form();
                /*using (P_TablaAsistenciaEstudiantes EditarRegistro = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, AsistenciaEstudiantesAsignatura))
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
                    EditarRegistro.txtFecha.Text = dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    EditarRegistro.txtTema.Text = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    EditarRegistro.hora = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    EditarRegistro.Owner = Fondo;
                    EditarRegistro.ShowDialog();
                    EditarRegistro.Dispose();

                    Fondo.Dispose();
                }*/
                P_TablaAsistenciaEstudiantes EditarRegistro = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, AsistenciaEstudiantesAsignatura);
                Program.Evento = 1;
                EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                EditarRegistro.txtFecha.Text = dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                EditarRegistro.txtTema.Text = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                EditarRegistro.hora = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                EditarRegistro.Owner = Fondo;
                EditarRegistro.ShowDialog();
                EditarRegistro.Dispose();
            }
        }

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
            BuscarRegistros();
		}
	}
}
