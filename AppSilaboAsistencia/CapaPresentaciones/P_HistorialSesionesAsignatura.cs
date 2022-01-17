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
        public DateTime HoraIniAsignatura;
        public DateTime HoraLimiteR;
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
        public bool validarHoraDeRegistro(string HoraSolicitadaRegistro,string Dia)
		{

            DataTable Horario = N_HorarioAsignatura.BuscarHorarioAsignatura(CodSemestre, CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6), CodAsignatura.Substring(5, 1));
            
            DateTime HoraCompletaInicio;
            DateTime HoraCompletaFinal;
            
            foreach (DataRow fila in Horario.Rows)
			{
                HoraCompletaInicio =Convert.ToDateTime(fila[6].ToString()+":00:00");
                HoraCompletaFinal = Convert.ToDateTime(fila[7].ToString() + ":10:59");
                if (fila[2].Equals(Dia)&& ((Convert.ToDateTime(HoraSolicitadaRegistro)>=HoraCompletaInicio)&&(Convert.ToDateTime(HoraSolicitadaRegistro)<=HoraCompletaFinal)))
				{
                    
                    HoraIniAsignatura =HoraCompletaInicio;
                    HoraLimiteR = HoraCompletaFinal;
                    return true;
				}
			}
            return false;
        }
        public string nombre_Dia_Actual()
		{
            DateTime fechaActual = DateTime.Now;
            string dia = fechaActual.ToString("dddd");
            return dia.Substring(0,2).ToUpper();
		}
        //busacar un registro entre un intervalo de tiempo
        public bool buscarUnRegistro(DateTime pHoraIni,DateTime pHoraLimte)
		{
            DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaSup, LimtFechaSup, "");
            foreach (DataRow fila in Resultado.Rows)
            {
                DateTime horaRegistrada =Convert.ToDateTime(fila[1].ToString());

                if ((horaRegistrada<=pHoraLimte)&&(horaRegistrada >= pHoraIni))
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
            //string Hora = HoraCompletaActual.Substring(0,2);

            DataTable EstudiantesAsigantura = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, CodAsignatura.Substring(6), CodAsignatura);
            
            if (validarHoraDeRegistro(HoraCompletaActual,DiaActual))
			{
                //DateTime Horalimite = validarHoraDeRegistro(HoraCompletaActual, DiaActual);
                
                
                //registrar la asistencia Normal
                    
                if (buscarUnRegistro(HoraIniAsignatura,HoraLimiteR) != true)
				{

                    Form Fondo = new Form();
                    P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura);
                    NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                    NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
                    NuevoRegistroAsistencia.txtTipoSesion.Text = "NORMAL";
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
                // registrar la asistencia como recuperacion
                if (A_Dialogo.DialogoPreguntaAceptarCancelar(" Seee encuentra fuera del Horario de la Asignatura" + Environment.NewLine + "¿Desea Recuperar una Sesion?") == DialogResult.Yes)
                {
                    Form Fondo = new Form();
                    P_TablaAsistenciaEstudiantes NuevoRegistroAsistencia = new P_TablaAsistenciaEstudiantes(CodAsignatura, CodDocente, EstudiantesAsigantura);
                    NuevoRegistroAsistencia.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                    NuevoRegistroAsistencia.txtFecha.Text = LimtFechaSup;
                    NuevoRegistroAsistencia.txtTipoSesion.Text = "RECUPERACIÓN";
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
                EditarRegistro.txtTipoSesion.Text = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
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
