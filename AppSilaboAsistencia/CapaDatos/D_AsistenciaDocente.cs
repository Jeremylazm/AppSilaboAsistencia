using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_AsistenciaDocente
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para mostrar el registro de asistencia de los docentes en una fecha especifica.
        public DataTable AsistenciaDocentes(string CodSemestre, string CodDepartamentoA, string Fecha)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaDocentes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@Fecha", Fecha); // formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el registro de asistencias de un docente que dicta una asignatura en un rango de fechas.
        public DataTable AsistenciaDocenteAsignatura(string CodSemestre, string CodDepartamentoA, string Texto1, string Texto2, 
                                                     string HoraInicio, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaDocenteAsignatura", Conectar)
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

        // Método para registrar la asistencia de un docente.
        public void RegistrarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente)
        {
            SqlCommand Comando = new SqlCommand("spuRegistrarAsistenciaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura);
            Comando.Parameters.AddWithValue("@HoraInicio", AsistenciaDocente.HoraInicio); // Hora inicio de la asignatura (obtener de THorarioAsignatura)
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha); // formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDocente.Hora); // hora: hh:mm:ss
            Comando.Parameters.AddWithValue("@CodDocente", AsistenciaDocente.CodDocente);
            Comando.Parameters.AddWithValue("@NombreTema", AsistenciaDocente.NombreTema); 
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la asistencia de un docente:
        public void ActualizarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente,
                                                string NCodSemestre,   // Atributo nuevo
                                                string NCodAsignatura, // Atributo nuevo
                                                string NHoraInicio,    // Atributo nuevo
                                                string NFecha,         // Atributo nuevo: solo se puede actualizar fecha, no la hora
                                                string NCodDocente,    // Atributo nuevo
                                                string NNombreTema)    // Atributo nuevo
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsistenciaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura);
            Comando.Parameters.AddWithValue("@HoraInicio", AsistenciaDocente.HoraInicio);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha);
            Comando.Parameters.AddWithValue("@NCodSemestre", NCodSemestre);
            Comando.Parameters.AddWithValue("@NCodAsignatura", NCodAsignatura);
            Comando.Parameters.AddWithValue("@NHoraInicio",NHoraInicio);
            Comando.Parameters.AddWithValue("@NFecha", NFecha); // formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@NCodDocente", NCodDocente);
            Comando.Parameters.AddWithValue("@NNombreTema", NNombreTema);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar la asistencia de un docente.
        public void EliminarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsistenciaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura);
            Comando.Parameters.AddWithValue("@HoraInicio", AsistenciaDocente.HoraInicio);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
