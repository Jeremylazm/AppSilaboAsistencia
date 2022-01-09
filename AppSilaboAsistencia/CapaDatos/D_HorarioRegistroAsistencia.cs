using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_HorarioRegistroAsistencia
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método buscar el horario de registro de asistencia diaria de los docentes.
        public DataTable BuscarHorarioRegistroAsistencia(string CodSemestre, string CodDepartamentoA, string CodJefeDepartamentoA)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarHorarioRegistroAsistencia", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); 
            Comando.Parameters.AddWithValue("@CodJefeDepartamentoA", CodJefeDepartamentoA);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para registrar el horario de registro de asistencia diaria de los docentes.
        public void InsertarHorarioRegistroAsistencia(E_HorarioRegistroAsistencia HorarioRegistroAsistencia)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarHorarioRegistroAsistencia", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", HorarioRegistroAsistencia.CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", HorarioRegistroAsistencia.CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodJefeDepartamentoA", HorarioRegistroAsistencia.CodJefeDepartamentoA);
            Comando.Parameters.AddWithValue("@HoraInicio", HorarioRegistroAsistencia.HoraInicio); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@HoraFin", HorarioRegistroAsistencia.HoraFin); // Formato: hh: mm: ss (Hora del control de asistencia)
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el horario de registro de asistencia diaria de los docentes.
        public void ActualizarHorarioRegistroAsistencia(E_HorarioRegistroAsistencia HorarioRegistroAsistencia, string NHoraInicio, string NHoraFin)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarHorarioRegistroAsistencia", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", HorarioRegistroAsistencia.CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", HorarioRegistroAsistencia.CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodJefeDepartamentoA", HorarioRegistroAsistencia.CodJefeDepartamentoA);
            Comando.Parameters.AddWithValue("@NHoraInicio", NHoraInicio); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@NHoraFin", NHoraFin); // Formato: hh: mm: ss (Hora del control de asistencia)
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar el horario de registro de asistencia diaria de los docentes. 
        public void EliminarHorarioRegistroAsistencia(E_HorarioRegistroAsistencia HorarioRegistroAsistencia)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarHorarioRegistroAsistencia", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", HorarioRegistroAsistencia.CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", HorarioRegistroAsistencia.CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodJefeDepartamentoA", HorarioRegistroAsistencia.CodJefeDepartamentoA);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
