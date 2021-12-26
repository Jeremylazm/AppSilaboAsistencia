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
            Comando.Parameters.AddWithValue("@Fecha", Fecha); // Formato: dd/mm/yyyy o dd-mm-yyyy
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar los registros de las sesiones para una asignatura en un rango de fechas.
        public DataTable MostrarSesionesAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarSesionesAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar un registro de una sesión para una asignatura dado el tema y en un rango de fechas.
        public DataTable BuscarSesionAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarSesionAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@Texto", Texto); // Tema de avance
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
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDocente.Hora); // Hora: hh:mm:ss
            Comando.Parameters.AddWithValue("@CodDocente", AsistenciaDocente.CodDocente);
            Comando.Parameters.AddWithValue("@NombreTema", AsistenciaDocente.NombreTema); 
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la asistencia de un docente:
        public void ActualizarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente, string NNombreTema)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsistenciaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha);
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDocente.Hora);
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
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha);
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDocente.Hora);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
