using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_HorarioAsignatura
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para buscar el horario de una asignatura en un catálogo. 
        public DataTable BuscarHorarioAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarHorarioAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto); // código o nombre de la asignatura
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para obtener el horario semanal de las asignaturas asignadas a un docente. 
        public DataTable HorarioSemanalDocente(string CodSemestre, string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuHorarioSemanalDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto); // código o nombre de un docente
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para insertar el horario de una asignatura en un catálogo.
        public void InsertarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarHorarioAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", HorarioAsignatura.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", HorarioAsignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", HorarioAsignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodDocente", HorarioAsignatura.CodDocente);
            Comando.Parameters.AddWithValue("@Dia", HorarioAsignatura.Dia);
            Comando.Parameters.AddWithValue("@Horario", HorarioAsignatura.Horario);
            Comando.Parameters.AddWithValue("@Tipo", HorarioAsignatura.Tipo);
            Comando.Parameters.AddWithValue("@Aula", HorarioAsignatura.Aula);
            Comando.Parameters.AddWithValue("@Horas", HorarioAsignatura.Horas);
            Comando.Parameters.AddWithValue("@Modalidad", HorarioAsignatura.Modalidad);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el horario de una asignatura en un catálogo.
        public void ActualizarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarHorarioAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", HorarioAsignatura.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", HorarioAsignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", HorarioAsignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodDocente", HorarioAsignatura.CodDocente);
            Comando.Parameters.AddWithValue("@Dia", HorarioAsignatura.Dia);
            Comando.Parameters.AddWithValue("@Horario", HorarioAsignatura.Horario);
            Comando.Parameters.AddWithValue("@Tipo", HorarioAsignatura.Tipo);
            Comando.Parameters.AddWithValue("@Aula", HorarioAsignatura.Aula);
            Comando.Parameters.AddWithValue("@Horas", HorarioAsignatura.Horas);
            Comando.Parameters.AddWithValue("@Modalidad", HorarioAsignatura.Modalidad);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar el horario de una asignatura en un catálogo.
        public void EliminarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarHorarioAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", HorarioAsignatura.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", HorarioAsignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", HorarioAsignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodDocente", HorarioAsignatura.CodDocente);
            Comando.Parameters.AddWithValue("@Dia", HorarioAsignatura.Dia);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
