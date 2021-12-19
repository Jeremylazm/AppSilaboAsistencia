using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_AsistenciaEstudiante
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para mostrar el registro de asistencia de los estudiantes de una asignatura en una fecha especifica. 
        public DataTable AsistenciaEstudiantes(string CodSemestre, string CodDepartamentoA, string Texto, string HoraInicio, string Fecha)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@Texto", Texto); // código(ej.IF085AIN) o nombre de la asignatura
            Comando.Parameters.AddWithValue("@HoraInicio", HoraInicio); // Hora inicio de la asignatura (obtener de THorarioAsignatura)
            Comando.Parameters.AddWithValue("@Fecha", Fecha); // formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el registro de asistencias de un estudiante en una asignatura en un rango de fechas.
        public DataTable AsistenciaEstudianteAsignatura(string CodSemestre, string CodDepartamentoA, string Texto1, string Texto2, 
                                                        string HoraInicio, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaEstudianteAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@Texto1", Texto1); // código o nombre del estudiante
            Comando.Parameters.AddWithValue("@Texto2", Texto2); // código(ej.IF085AIN) o nombre de la asignatura
            Comando.Parameters.AddWithValue("@HoraInicio", HoraInicio); // Hora inicio de la asignatura (obtener de THorarioAsignatura)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para registrar la asistencia de un estudiante.
        public void RegistrarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            SqlCommand Comando = new SqlCommand("spuRegistrarAsistenciaEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaEstudiante.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaEstudiante.CodAsignatura);
            Comando.Parameters.AddWithValue("@HoraInicio", AsistenciaEstudiante.HoraInicio); // Hora inicio de la asignatura (obtener de THorarioAsignatura)
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaEstudiante.Fecha); // formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@Hora", AsistenciaEstudiante.Hora); // hora: hh:mm:ss
            Comando.Parameters.AddWithValue("@CodEstudiante", AsistenciaEstudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@Estado", AsistenciaEstudiante.Estado); // SI/NO (Presente/No presente)
            Comando.Parameters.AddWithValue("@Observación", AsistenciaEstudiante.Observacion); // tardanza, permiso
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la asistencia de un estudiante.
        public void ActualizarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante,
                                                   string NCodSemestre,   // Atributo nuevo
                                                   string NCodAsignatura, // Atributo nuevo
                                                   string NHoraInicio,    // Atributo nuevo
                                                   string NFecha,         // Atributo nuevo: solo se puede actualizar fecha, no la hora
                                                   string NCodEstudiante, // Atributo nuevo
                                                   string NEstado,        // Atributo nuevo
                                                   string NObservacion)   // Atributo nuevo
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsistenciaEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaEstudiante.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaEstudiante.CodAsignatura);
            Comando.Parameters.AddWithValue("@HoraInicio", AsistenciaEstudiante.HoraInicio);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaEstudiante.Fecha);
            Comando.Parameters.AddWithValue("@CodEstudiante", AsistenciaEstudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@NCodSemestre", NCodSemestre);
            Comando.Parameters.AddWithValue("@NCodAsignatura", NCodAsignatura);
            Comando.Parameters.AddWithValue("@NHoraInicio", NHoraInicio);
            Comando.Parameters.AddWithValue("@NFecha", NFecha); // formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@NCodEstudiante", NCodEstudiante);
            Comando.Parameters.AddWithValue("@NEstado", NEstado); // SI/NO (Presente/No presente)
            Comando.Parameters.AddWithValue("@NObservación", NObservacion); // tardanza, permiso
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar la asistencia de un estudiante.
        public void EliminarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsistenciaEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaEstudiante.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaEstudiante.CodAsignatura);
            Comando.Parameters.AddWithValue("@HoraInicio", AsistenciaEstudiante.HoraInicio);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaEstudiante.Fecha);
            Comando.Parameters.AddWithValue("@CodEstudiante", AsistenciaEstudiante.CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
