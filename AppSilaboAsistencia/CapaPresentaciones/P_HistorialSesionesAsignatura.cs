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
using Ayudas;
namespace CapaPresentaciones
{
    public partial class P_HistorialSesionesAsignatura : Form
    {
        public string CodAsignatura;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodSemestre;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();
        //public string HoraRegistro= DateTime.Now.ToString("HH:mm:ss");

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
            dgvDatos.Columns[0].DisplayIndex = 8;
            dgvDatos.Columns[1].HeaderText = "Fecha";
            dgvDatos.Columns[2].HeaderText = "Hora";
            dgvDatos.Columns[3].HeaderText = "Sesión Dictada";
            dgvDatos.Columns[4].HeaderText = "Tipo de Sesión";
            dgvDatos.Columns[5].HeaderText = "Nombre del Tema";
            dgvDatos.Columns[6].HeaderText = "TotalAsistieron";
            dgvDatos.Columns[7].HeaderText = "TotalFaltaron";
            dgvDatos.Columns[8].HeaderText = "Observación";
        }

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDocentePorAsignatura.MostrarSesionesAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaInf, LimtFechaSup);
            AccionesTabla();
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        public void BuscarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaInf, LimtFechaSup,txtBuscar.Text);
        }
        public string validarHoraDeRegistro(string HoraSolicitadaRegistro,string Dia)
		{

            DataTable Horario = N_HorarioAsignatura.BuscarHorarioAsignatura(CodSemestre, CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6), CodAsignatura.Substring(5, 1));
            string dia;
            string HoraInicio;
            string HoraFin;
            
            foreach (DataRow fila in Horario.Rows)
			{
				if (fila[2].Equals(Dia)&& (fila[6].Equals(HoraSolicitadaRegistro)|| fila[7].Equals(HoraSolicitadaRegistro)))
				{
                    HoraFin = fila[7].ToString();
                    return HoraFin;
				}
			}
            return null;
        }
        public string nombre_Dia_Actual()
		{
            DateTime fechaActual = DateTime.Now;
            string dia = fechaActual.ToString("dddd");
            return dia.Substring(0,2).ToUpper();
		}
        public bool buscarUnRegistro(string HoraLimte)
		{
            DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaSup, LimtFechaSup, "");
            foreach (DataRow fila in Resultado.Rows)
            {
                string horaRegistrada = fila[1].ToString();

                if (Convert.ToDateTime(horaRegistrada)<=Convert.ToDateTime(HoraLimte))
                {
                    return true;
                }
            }
            return false;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
		private void btnAgregar_Click(object sender, EventArgs e)
		{
            string DiaActual = nombre_Dia_Actual();
            string HoraCompletaActual= DateTime.Now.ToString("HH:mm:ss");
            string Hora = HoraCompletaActual.Substring(0,2);

            DataTable EstudiantesAsigantura = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, CodAsignatura.Substring(6), CodAsignatura);
            
            if (validarHoraDeRegistro(Hora,DiaActual)!=null)
			{
                string Horalimite = validarHoraDeRegistro(Hora, DiaActual)+":10:00";
                if (Convert.ToDateTime(HoraCompletaActual) <= Convert.ToDateTime(Horalimite))
                {
                    //registrar la asistencia Normal
                    
                    if (buscarUnRegistro(Horalimite) != true)
					{

                        Form Fondo = new Form();
                        P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura);
                        NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                        NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
                        NuevoRegistroAsistencia.hora = HoraCompletaActual;
                        NuevoRegistroAsistencia.Owner = Fondo;
                        NuevoRegistroAsistencia.ShowDialog();
                        NuevoRegistroAsistencia.Dispose();
                    }
					else
					{
                        A_Dialogo.DialogoInformacion("El registro de Hoy, ¡Ya existe!");
                    }
                }
                else
				{
                    //registrar la sistencia como Recuperacion
                    if(A_Dialogo.DialogoPreguntaAceptarCancelar("¿Desea Recuperar una Sesion?") == DialogResult.Yes)
					{
                        Form Fondo = new Form();
                        P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura);
                        NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                        NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
                        NuevoRegistroAsistencia.hora = HoraCompletaActual;
                        NuevoRegistroAsistencia.Owner = Fondo;
                        NuevoRegistroAsistencia.ShowDialog();
                        NuevoRegistroAsistencia.Dispose();
                    }
                }
                    
			}
			else
			{
                // registrar la asistencia como recuperacion
                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Desea Recuperar una Sesion?") == DialogResult.Yes)
                {
                    Form Fondo = new Form();
                    P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura);
                    NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                    NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
                    NuevoRegistroAsistencia.hora = HoraCompletaActual;
                    NuevoRegistroAsistencia.Owner = Fondo;
                    NuevoRegistroAsistencia.ShowDialog();
                    NuevoRegistroAsistencia.Dispose();
                }
            }
            //DataTable EstudiantesAsigantura = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, CodAsignatura.Substring(6), CodAsignatura);

            //Form Fondo = new Form();
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
            /*P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura);
            NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
            NuevoRegistroAsistencia.hora = HoraRegistro;
            NuevoRegistroAsistencia.Owner = Fondo;
            NuevoRegistroAsistencia.ShowDialog();
            NuevoRegistroAsistencia.Dispose();*/
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
                EditarRegistro.txtTema.Text = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
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
