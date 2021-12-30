using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_AsistenciaDiariaDocente
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para mostrar el registro de asistencia diaria de los docentes en una fecha especifica.
        public DataTable AsistenciaDiariaDocentes(string CodSemestre, string CodDepartamentoA, string Fecha)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaDiariaDocentes", Conectar)
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

        // Método para registrar la asistencia diaria de un docente.
        public void RegistrarAsistenciaDiariaDocente(E_AsistenciaDiariaDocente AsistenciaDiariaDocente)
        {
            SqlCommand Comando = new SqlCommand("spuRegistrarAsistenciaDiariaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDiariaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", AsistenciaDiariaDocente.CodDepartamentoA);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDiariaDocente.Fecha); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDiariaDocente.Hora); // Hora: hh:mm:ss
            Comando.Parameters.AddWithValue("@CodDocente", AsistenciaDiariaDocente.CodDocente);
            Comando.Parameters.AddWithValue("@Asistió", AsistenciaDiariaDocente.Asistio); // SI/NO
            Comando.Parameters.AddWithValue("@Observación", AsistenciaDiariaDocente.Observacion);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la asistencia diaria de un docente:
        public void ActualizarAsistenciaDiariaDocente(E_AsistenciaDiariaDocente AsistenciaDiariaDocente, string NObservacion)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsistenciaDiariaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDiariaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDiariaDocente.Fecha);
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDiariaDocente.Hora);
            Comando.Parameters.AddWithValue("@NObservación", NObservacion);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar la asistencia de un docente.
        public void EliminarAsistenciaDiariaDocente(E_AsistenciaDiariaDocente AsistenciaDiariaDocente)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsistenciaDiariaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDiariaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDiariaDocente.Fecha);
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDiariaDocente.Hora);
            Comando.Parameters.AddWithValue("@CodDocente", AsistenciaDiariaDocente.CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
