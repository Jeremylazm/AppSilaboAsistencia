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
using System.IO;
using SpreadsheetLight;
using Ayudas;
namespace CapaPresentaciones
{
    public partial class P_DialogoAgregarAsistenciaDocente : Form
    {
        readonly E_AsistenciaDiariaDocente ObjEntidadDoc;
        readonly N_AsistenciaDiariaDocente ObjNegocioDoc;

        readonly E_AsistenciaDiariaDocente ObjEntidadAsistDiariaDocente;
        readonly N_AsistenciaDiariaDocente ObjNegocioAsistDiariaDocente;
        readonly E_AsistenciaDocentePorAsignatura ObjEntidadAsistDocentePorAsignatura;
        readonly N_AsistenciaDocentePorAsignatura ObjNegocioiAsisDocentePorAsignatura;
        readonly E_AsistenciaEstudiante ObjEntidadAsistEstudiante;
        readonly N_AsistenciaEstudiante ObjNegocioAsistEstudiante;

        private readonly string CodDocente = E_InicioSesion.Usuario;
        //dpFechaInicial.Value.ToString("dd/MM/yyyy")
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();
        public P_DialogoAgregarAsistenciaDocente()
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
            ObjEntidadDoc = new E_AsistenciaDiariaDocente();
            ObjNegocioDoc = new N_AsistenciaDiariaDocente();
            CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

            InitializeComponent();
            cxtMotivo.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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
                string pCodAsignatura = asignatura[0].ToString();
                string pCodDocente = asignatura[1].ToString();
                ObjEntidadAsistDocentePorAsignatura.CodSemestre = CodSemestre;
                ObjEntidadAsistDocentePorAsignatura.CodDepartamentoA = CodDepartamentoA;
                ObjEntidadAsistDocentePorAsignatura.CodAsignatura = pCodAsignatura;
                ObjEntidadAsistDocentePorAsignatura.Fecha = Fecha;
                ObjEntidadAsistDocentePorAsignatura.Hora = Hora;
                ObjEntidadAsistDocentePorAsignatura.CodDocente = pCodDocente;
                ObjEntidadAsistDocentePorAsignatura.Asistio = Asistio;
                ObjEntidadAsistDocentePorAsignatura.TipoSesion = "";
                ObjEntidadAsistDocentePorAsignatura.NombreTema = "";
                ObjEntidadAsistDocentePorAsignatura.Observacion = Observacion;
                ObjNegocioiAsisDocentePorAsignatura.RegistrarAsistenciaDocentePorAsignatura(ObjEntidadAsistDocentePorAsignatura);
                
                //A_Dialogo.DialogoInformacion("se registró docente"+pCodDocente+"correctamente "+(n).ToString());
                // Marcar asistencia de los estudiantes:
                DataTable EscuelaP = N_Catalogo.VerEscuelaAsignatura(CodSemestre, pCodAsignatura);
                DataTable Matriculados = N_Matricula.BuscarEstudiantesAsignatura(CodSemestre, EscuelaP.Rows[0][0].ToString(), pCodAsignatura);
                int i = 0;
                if(Matriculados.Rows.Count!=0)
				{
                    foreach (DataRow estudiante in Matriculados.Rows)
                    {

                        string pCodEstudiante = estudiante[1].ToString();
                        ObjEntidadAsistEstudiante.CodSemestre = CodSemestre;
                        ObjEntidadAsistEstudiante.CodEscuelaP = EscuelaP.Rows[0][0].ToString();
                        ObjEntidadAsistEstudiante.CodAsignatura = pCodAsignatura;
                        ObjEntidadAsistEstudiante.Fecha = Fecha;
                        ObjEntidadAsistEstudiante.Hora = Hora;
                        ObjEntidadAsistEstudiante.CodEstudiante = pCodEstudiante;
                        ObjEntidadAsistEstudiante.Asistio = Asistio;
                        ObjEntidadAsistEstudiante.Observacion = Observacion;
                        ObjNegocioAsistEstudiante.RegistrarAsistenciaEstudiante(ObjEntidadAsistEstudiante);
                        
                        //A_Dialogo.DialogoInformacion("se registró estudiante" + pCodEstudiante + "correctamente " + (i).ToString());
                    }
                }
                else
				{
                    A_Dialogo.DialogoInformacion("Actualizar. No hay estudiantes matriculados para la sigantura "+pCodAsignatura);
                }
                
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Fecha = dpFecha.Value.ToString("dd/MM/yyyy");
            string Dia = dpFecha.Value.ToString("dddd").Substring(0, 2).ToUpper();
            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea registrar que "+Fecha+ Dia+ " se declare como "+cxtMotivo.SelectedItem.ToString()) == DialogResult.Yes)
			{
                AsistenciaGeneral(Fecha,Dia,"00","23","NO",cxtMotivo.SelectedItem.ToString());
                A_Dialogo.DialogoConfirmacion("Se ha Editadopipi correctamente la asistencia" + Environment.NewLine + " del los Docentes");

                Close();
            }

        }
    }
}
