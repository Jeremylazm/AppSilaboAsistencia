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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*//agregar una fecha actual
            DataTable DocentesDA = N_Docente.MostrarDocentesDepartamento(CodDepartamentoA);
            try
            {
                foreach (DataGridViewRow dr in dgvDatos.Rows)
                {
                    if (dr.Cells[2].Value.ToString() != "00000")
                    {
                        ObjEntidadDoc.CodSemestre = CodSemestre;
                        ObjEntidadDoc.CodDepartamentoA = "IF";
                        ObjEntidadDoc.Fecha = txtFecha.Text.ToString();
                        ObjEntidadDoc.Hora = hora;
                        ObjEntidadDoc.CodDocente = dr.Cells[2].Value.ToString();
                        ObjEntidadDoc.Asistio = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";
                        ObjEntidadDoc.Observacion = (dr.Cells[1].Value == null) ? "" : dr.Cells[1].Value.ToString();

                        ObjNegocioDoc.RegistrarAsistenciaDiariaDocente(ObjEntidadDoc);
                    }

                }
                A_Dialogo.DialogoConfirmacion("Se ha registrado correctamente la asistencia" + Environment.NewLine + " del los Docentes");
                Program.Evento = 0;
                Close();


            }
            catch (Exception)
            {
                A_Dialogo.DialogoError("Error al insertar el registro...");
            }*/
            //recuperar el valor de motivo
            string Fecha = dpFecha.Value.ToString("dd/MM/yyyy");
            string Dia = dpFecha.Value.ToString("dddd").Substring(0, 2).ToUpper();
            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea registrar que "+Fecha+" se declare como "+cxtMotivo.SelectedItem.ToString()) == DialogResult.Yes)
			{
                AsistenciaGeneral(Fecha,Dia,"00","23","NO",cxtMotivo.SelectedItem.ToString());
                A_Dialogo.DialogoConfirmacion("Se ha Editado correctamente la asistencia" + Environment.NewLine + " del los Docentes");

                Close();
            }

        }
    }
}
