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
using System.Globalization;
using SpreadsheetLight;
using System.IO;

namespace CapaPresentaciones
{
    public partial class P_HistorialSesionesAsignatura : Form
    {
        private readonly DataTable PlanSesion;
        public readonly string CodAsignatura;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodSemestre;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString();
        public DateTime HoraIniAsignatura;
        public DateTime HoraLimiteR;
        //public string HoraRegistro= DateTime.Now.ToString("HH:mm:ss");

        public P_HistorialSesionesAsignatura(string pCodAsignatura)
        {
            CodAsignatura = pCodAsignatura;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            //LimtFechaInf = DateTime.Parse(Semestre.Rows[0][1].ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
            LimtFechaInf=DateTime.ParseExact(Semestre.Rows[0][1].ToString(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
            InitializeComponent();
            MostrarRegistros();
            PlanSesion = N_Catalogo.RecuperarPlanDeSesionAsignatura(CodSemestre, CodAsignatura, CodDocente);
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
        }

        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 8;
            dgvDatos.Columns[1].HeaderText = "Fecha";
            dgvDatos.Columns[2].HeaderText = "Hora";
            dgvDatos.Columns[3].HeaderText = "Sesión Dictada";
            dgvDatos.Columns[4].HeaderText = "Tipo";
            dgvDatos.Columns[5].HeaderText = "Tema";
            dgvDatos.Columns[6].HeaderText = "Asistieron";
            dgvDatos.Columns[7].HeaderText = "Faltaron";
            dgvDatos.Columns[8].HeaderText = "Observación";
        }

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDocentePorAsignatura.MostrarSesionesAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaInf, DateTime.Parse(LimtFechaSup).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
            //atributos del las columnas del datagridview
            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                Columna.AutoSizeMode= DataGridViewAutoSizeColumnMode.None;

            }
            dgvDatos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvDatos.Columns[0].MinimumWidth = 60;
            dgvDatos.Columns[0].Width = 60;
            dgvDatos.Columns[1].MinimumWidth = 100;
            dgvDatos.Columns[1].Width = 100;
            dgvDatos.Columns[2].MinimumWidth = 90;
            dgvDatos.Columns[2].Width = 90;
            dgvDatos.Columns[3].MinimumWidth = 110;
            dgvDatos.Columns[3].Width = 110;
            dgvDatos.Columns[4].MinimumWidth = 90;
            dgvDatos.Columns[4].Width = 90;
            dgvDatos.Columns[5].MinimumWidth = 350;
            dgvDatos.Columns[5].Width = 350;
            dgvDatos.Columns[6].MinimumWidth = 85;
            dgvDatos.Columns[6].Width = 85;
            dgvDatos.Columns[7].MinimumWidth = 85;
            dgvDatos.Columns[7].Width = 85;
            dgvDatos.Columns[8].MinimumWidth = 105;
            dgvDatos.Columns[8].Width = 105;
            //dgvDatos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            
            AccionesTabla();
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        public void BuscarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, LimtFechaInf, DateTime.Parse(LimtFechaSup).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), txtBuscar.Text);
            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvDatos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvDatos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvDatos.Columns[0].MinimumWidth = 60;
            dgvDatos.Columns[0].Width = 60;
            dgvDatos.Columns[1].MinimumWidth = 100;
            dgvDatos.Columns[1].Width = 100;
            dgvDatos.Columns[2].MinimumWidth = 90;
            dgvDatos.Columns[2].Width = 90;
            dgvDatos.Columns[3].MinimumWidth = 110;
            dgvDatos.Columns[3].Width = 110;
            dgvDatos.Columns[4].MinimumWidth = 90;
            dgvDatos.Columns[4].Width = 90;
            dgvDatos.Columns[5].MinimumWidth = 350;
            dgvDatos.Columns[5].Width = 350;
            dgvDatos.Columns[6].MinimumWidth = 85;
            dgvDatos.Columns[6].Width = 85;
            dgvDatos.Columns[7].MinimumWidth = 85;
            dgvDatos.Columns[7].Width = 85;
            dgvDatos.Columns[8].MinimumWidth = 105;
            dgvDatos.Columns[8].Width = 105;
            AccionesTabla();
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
        public List<sesionesViewModel> TemasPendientes()
		{
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "/temp/";
            string fullFilePath = folder + "temp.xlsx";


            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }

            byte[] archivo = PlanSesion.Rows[0]["PlanSesiones"] as byte[];

            File.WriteAllBytes(fullFilePath, archivo);
            //string Direccion = @"D:\Yo\Plantilla Sesion Pruebas.xlsx";
            SLDocument sl = new SLDocument(fullFilePath);
            int IRow = 9;
            List<sesionesViewModel> lst = new List<sesionesViewModel>();
            DateTime A = DateTime.Now;
            //

            while (sl.GetCellValueAsDateTime(IRow, 5) < A)
            {
                if (sl.GetCellValueAsString(IRow, 8) != "Hecho" && sl.GetCellValueAsString(IRow, 3) != "")
                {
                    sesionesViewModel oSesion = new sesionesViewModel();
                    oSesion.Sesion = sl.GetCellValueAsString(IRow, 3);
                    oSesion.Fecha = sl.GetCellValueAsDateTime(IRow, 5);
                    lst.Add(oSesion);
                }
                IRow++;

            }
            return lst;
		}
        public string nombre_Dia_Actual()
		{
            DateTime fechaActual = DateTime.Now;
            string dia = fechaActual.ToString("dddd", new CultureInfo("es-ES")).ToUpper().Substring(0, 2);
            return dia;
		}
        //busacar un registro entre un intervalo de tiempo
        public bool buscarUnRegistro(DateTime pHoraIni,DateTime pHoraLimte)
		{
            DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, DateTime.Parse(LimtFechaSup).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), DateTime.Parse(LimtFechaSup).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), "");
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
            if(PlanSesion.Rows.Count > 0)
			{
                if (TemasPendientes().Count != 0)
                {
                    string DiaActual = nombre_Dia_Actual();
                    string HoraCompletaActual = DateTime.Now.ToString("HH:mm:ss");
                    DataTable EstudiantesAsigantura = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, CodAsignatura.Substring(6), CodAsignatura);
                    DataTable busacarAsistenciaDiaraActual = N_AsistenciaDiariaDocente.AsistenciaDocentesPorFechas(CodSemestre, DateTime.Parse(LimtFechaSup).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), DateTime.Parse(LimtFechaSup).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
                    if (busacarAsistenciaDiaraActual.Rows.Count == 0)
                    {
                        if (validarHoraDeRegistro(HoraCompletaActual, DiaActual))
                        {
                            //registrar como sesion normal
                            if (buscarUnRegistro(HoraIniAsignatura, HoraLimiteR) != true)
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
                            if (A_Dialogo.DialogoPreguntaAceptarCancelar(" Se encuentra fuera del Horario de la Asignatura" + Environment.NewLine + "¿Desea Recuperar una Sesion?") == DialogResult.Yes)
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
                    }
                    else
                    {
                        if (busacarAsistenciaDiaraActual.Rows[0][3].Equals("FERIADO") || busacarAsistenciaDiaraActual.Rows[0][3].Equals("SUSPENSION"))
                        {
                            A_Dialogo.DialogoInformacion("Hoy es un día de " + busacarAsistenciaDiaraActual.Rows[0][3].ToString() + Environment.NewLine + "Tómese un descanso");
                        }
                        else
                        {
                            if (validarHoraDeRegistro(HoraCompletaActual, DiaActual))
                            {
                                //registrar como sesion normal
                                if (buscarUnRegistro(HoraIniAsignatura, HoraLimiteR) != true)
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
                                if (A_Dialogo.DialogoPreguntaAceptarCancelar(" Se encuentra fuera del Horario de la Asignatura" + Environment.NewLine + "¿Desea Recuperar una Sesion?") == DialogResult.Yes)
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
                        }
                    }

                }
                else
                {
                    A_Dialogo.DialogoError("Ya no hay temas pendiantes");
                }
            }
            else
			{
                A_Dialogo.DialogoInformacion("Aun no subio un plan de sesiones");
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
                if(dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString()=="SI")
				{
                    DataTable AsistenciaEstudiantesAsignatura = N_AsistenciaEstudiante.AsistenciaEstudiantes(CodSemestre, CodAsignatura, DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString());

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
                    EditarRegistro.txtFecha.Text = DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                    EditarRegistro.txtTipoSesion.Text = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    EditarRegistro.txtTema.Text = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    EditarRegistro.hora = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    EditarRegistro.Owner = Fondo;
                    EditarRegistro.ShowDialog();
                    EditarRegistro.Dispose();
                }
				else
				{
                    A_Dialogo.DialogoInformacion("Ud. No Tiene Permiso para Editar este tipo de Registros");
                }
                
            }
        }

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
            BuscarRegistros();
		}
	}
}
