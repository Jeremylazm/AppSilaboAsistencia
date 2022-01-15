using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using Ayudas;
namespace CapaPresentaciones
{
    public partial class P_HistorialAsistenciasDocentes : Form
    {
        readonly E_AsistenciaDiariaDocente ObjEntidadAsistDiariaDocente;
        readonly N_AsistenciaDiariaDocente ObjNegocioAsistDiariaDocente;
        readonly E_AsistenciaDocentePorAsignatura ObjEntidadAsistDocentePorAsignatura;
        readonly N_AsistenciaDocentePorAsignatura ObjNegocioiAsisDocentePorAsignatura;
        readonly E_AsistenciaEstudiante ObjEntidadAsistEstudiante;
        readonly N_AsistenciaEstudiante ObjNegocioAsistEstudiante;

        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();

        public P_HistorialAsistenciasDocentes()
        {
            ObjEntidadAsistDiariaDocente = new E_AsistenciaDiariaDocente();
            ObjNegocioAsistDiariaDocente = new N_AsistenciaDiariaDocente();
            ObjEntidadAsistDocentePorAsignatura = new E_AsistenciaDocentePorAsignatura();
            ObjNegocioiAsisDocentePorAsignatura = new N_AsistenciaDocentePorAsignatura();
            ObjEntidadAsistEstudiante = new E_AsistenciaEstudiante();
            ObjNegocioAsistEstudiante = new N_AsistenciaEstudiante();

            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LimtFechaInf = Semestre.Rows[0][1].ToString();
            CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
            InitializeComponent();
            MostrarRegistros();
        }

        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 4;
            dgvDatos.Columns[1].HeaderText = "Fecha";
            dgvDatos.Columns[2].HeaderText = "Total Asistieron";
            dgvDatos.Columns[3].HeaderText = "Total Faltaron";
            dgvDatos.Columns[4].HeaderText = "Observacion";
        }

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDiariaDocente.AsistenciaDocentesPorFechas(CodSemestre,LimtFechaInf,LimtFechaSup);
            AccionesTabla();
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        public string NombreCompletoJD()
		{
            DataTable DocentesDepartamentoA = N_Docente.MostrarTodosDocentesDepartamento(CodDepartamentoA);
            foreach (DataRow fila in DocentesDepartamentoA.Rows)
            {          
                if (fila[0].Equals(CodDocente))
                {
                    return fila[1].ToString();
                }
            }
            return "N";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void AsistenciaGeneral(string Fecha, string Dia, string HoraInicio, string HoraFin, string Asistio, string Observacion)
        {
            // Observacion: FERIADO, SUSPENSIÓN
            string Hora = DateTime.Now.ToString("HH:mm:ss");

            // Marcar asistencia diaria de los docentes:
            DataTable Docentes = N_Docente.MostrarTodosDocentesDepartamento(CodDepartamentoA);
            foreach (DataRow docente in Docentes.Rows)
            {
                ObjEntidadAsistDiariaDocente.CodSemestre = CodSemestre;
                ObjEntidadAsistDiariaDocente.CodDepartamentoA = CodDepartamentoA;
                ObjEntidadAsistDiariaDocente.Fecha = Fecha;
                ObjEntidadAsistDiariaDocente.Hora = Hora;
                ObjEntidadAsistDiariaDocente.CodDocente = docente[0].ToString();
                ObjEntidadAsistDiariaDocente.Asistio = Asistio;
                ObjEntidadAsistDiariaDocente.Observacion = Observacion;
                ObjNegocioAsistDiariaDocente.RegistrarAsistenciaDiariaDocente(ObjEntidadAsistDiariaDocente);
            }

            // Marcar asistencia diaria de los docentes por asignatura:
            DataTable AsignaturasAfectadas = N_HorarioAsignatura.BuscarAsignaturasDiaHora(CodSemestre, CodDepartamentoA, Dia, HoraInicio, HoraFin);
            foreach (DataRow asignatura in AsignaturasAfectadas.Rows)
            {
                string CodAsignatura = asignatura[0].ToString();
                string CodDocente = asignatura[1].ToString();
                ObjEntidadAsistDocentePorAsignatura.CodSemestre = CodSemestre;
                ObjEntidadAsistDocentePorAsignatura.CodDepartamentoA = CodDepartamentoA;
                ObjEntidadAsistDocentePorAsignatura.CodAsignatura = CodAsignatura;
                ObjEntidadAsistDocentePorAsignatura.Fecha = Fecha;
                ObjEntidadAsistDocentePorAsignatura.Hora = Hora;
                ObjEntidadAsistDocentePorAsignatura.CodDocente = CodDocente;
                ObjEntidadAsistDocentePorAsignatura.Asistio = Asistio;
                ObjEntidadAsistDocentePorAsignatura.TipoSesion = "";
                ObjEntidadAsistDocentePorAsignatura.NombreTema = "";
                ObjEntidadAsistDocentePorAsignatura.Observacion = Observacion;
                ObjNegocioiAsisDocentePorAsignatura.RegistrarAsistenciaDocentePorAsignatura(ObjEntidadAsistDocentePorAsignatura);

                // Marcar asistencia de los estudiantes:
                DataTable EscuelaP = N_Catalogo.VerEscuelaAsignatura(CodSemestre, CodAsignatura);
                DataTable Matriculados = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, EscuelaP.Rows[0][0].ToString(), CodAsignatura);
                foreach (DataRow estudiante in Matriculados.Rows)
                {
                    string CodEstudiante = estudiante[1].ToString();
                    ObjEntidadAsistEstudiante.CodSemestre = CodSemestre;
                    ObjEntidadAsistEstudiante.CodEscuelaP = EscuelaP.Rows[0][0].ToString();
                    ObjEntidadAsistEstudiante.CodAsignatura = CodAsignatura;
                    ObjEntidadAsistEstudiante.Fecha = Fecha;
                    ObjEntidadAsistEstudiante.Hora = Hora;
                    ObjEntidadAsistEstudiante.CodEstudiante = CodEstudiante;
                    ObjEntidadAsistEstudiante.Asistio = Asistio;
                    ObjEntidadAsistEstudiante.Observacion = Observacion;
                    ObjNegocioAsistEstudiante.RegistrarAsistenciaEstudiante(ObjEntidadAsistEstudiante);
                }
            }
        }

		private void btnAgregarD_Click(object sender, EventArgs e)
		{
            // Por discutir

            DataTable Resultados = N_AsistenciaDiariaDocente.AsistenciaDiariaDocentes(CodSemestre, CodDepartamentoA, LimtFechaSup);
            if (Resultados.Rows.Count == 0)
            {
                DataTable DocentesDepartamentoA = N_Docente.MostrarTodosDocentesDepartamento(CodDepartamentoA);
                Form Fondo = new Form();
                P_TablaAsistenciaDiariaDocente NuevoRegistroAsistenciaDocente = new P_TablaAsistenciaDiariaDocente(DocentesDepartamentoA);
                NuevoRegistroAsistenciaDocente.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                NuevoRegistroAsistenciaDocente.txtFecha.Text = LimtFechaSup;
                NuevoRegistroAsistenciaDocente.hora = DateTime.Now.ToString("HH:mm:ss");
                NuevoRegistroAsistenciaDocente.txtJD.Text = NombreCompletoJD();
                NuevoRegistroAsistenciaDocente.Owner = Fondo;
                NuevoRegistroAsistenciaDocente.ShowDialog();
                NuevoRegistroAsistenciaDocente.Dispose();
            }
            else
            {
                A_Dialogo.DialogoInformacion("El registro de Hoy, ¡Ya existe!");
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {

        }
    }
}
