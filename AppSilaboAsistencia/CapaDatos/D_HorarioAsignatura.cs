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
        public DataTable BuscarHorarioAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarHorarioAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@Texto1", Texto1); // código (ej. IF065) o nombre de la asignatura
            Comando.Parameters.AddWithValue("@Texto2", Texto2); // EP donde se enseña la asignatura
            Comando.Parameters.AddWithValue("@Grupo", Grupo);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para obtener el horario semanal (por registros) de las asignaturas asignadas a un docente. 
        public DataTable HorarioSemanalDocente(string CodSemestre, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuHorarioSemanalDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@Texto", Texto); // código o nombre de un docente
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para obtener el horario (concatenado) de una asignatura asignada a un docente.
        // Formato salida: IF614AIN T:MA 7 -9 VIRT 7 IN; T:VI 8 -9 VIRT 7 IN; P:JU 7 -9 VIRT 7 IN
        public DataTable HorarioAsignaturaDocente(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuHorarioAsignaturaDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodSemestre); // código(ej.IF065AIN), obtener de BuscarAsignaturasDocente
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
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
            Comando.Parameters.AddWithValue("@CodAsignatura", HorarioAsignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEscuelaP", HorarioAsignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Grupo", HorarioAsignatura.Grupo);
            Comando.Parameters.AddWithValue("@CodDocente", HorarioAsignatura.CodDocente);
            Comando.Parameters.AddWithValue("@Dia", HorarioAsignatura.Dia);
            Comando.Parameters.AddWithValue("@Tipo", HorarioAsignatura.Tipo);
            Comando.Parameters.AddWithValue("@HorasTeoria", HorarioAsignatura.HorasTeoria);
            Comando.Parameters.AddWithValue("@HorasPractica", HorarioAsignatura.HorasPractica);
            Comando.Parameters.AddWithValue("@HoraInicio", HorarioAsignatura.HoraInicio);
            Comando.Parameters.AddWithValue("@HoraFin", HorarioAsignatura.HoraFin);
            Comando.Parameters.AddWithValue("@Aula", HorarioAsignatura.Aula);
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
            Comando.Parameters.AddWithValue("@CodAsignatura", HorarioAsignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEscuelaP", HorarioAsignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Grupo", HorarioAsignatura.Grupo);
            Comando.Parameters.AddWithValue("@CodDocente", HorarioAsignatura.CodDocente);
            Comando.Parameters.AddWithValue("@Dia", HorarioAsignatura.Dia);
            Comando.Parameters.AddWithValue("@Tipo", HorarioAsignatura.Tipo);
            Comando.Parameters.AddWithValue("@HorasTeoria", HorarioAsignatura.HorasTeoria);
            Comando.Parameters.AddWithValue("@HorasPractica", HorarioAsignatura.HorasPractica);
            Comando.Parameters.AddWithValue("@HoraInicio", HorarioAsignatura.HoraInicio);
            Comando.Parameters.AddWithValue("@HoraFin", HorarioAsignatura.HoraFin);
            Comando.Parameters.AddWithValue("@Aula", HorarioAsignatura.Aula);
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
            Comando.Parameters.AddWithValue("@CodAsignatura", HorarioAsignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEscuelaP", HorarioAsignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Grupo", HorarioAsignatura.Grupo);
            Comando.Parameters.AddWithValue("@CodDocente", HorarioAsignatura.CodDocente);
            Comando.Parameters.AddWithValue("@Dia", HorarioAsignatura.Dia);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
