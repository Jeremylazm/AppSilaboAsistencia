using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Catalogo
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para mostrar el catálogo de asignaturas de una escuela profesional.
        public DataTable MostrarCatalogo(string CodSemestre, string CodEscuelaP)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar los docentes que enseñan una asignatura. 
        public DataTable BuscarDocentesAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarDocentesAsignatura", Conectar)
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

        // Método para buscar las asignaturas asignadas a un docente.
        public DataTable BuscarAsignaturasDocente(string CodSemestre, string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignaturasDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto); // código o nombre del docente
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar el silabo de una asignatura.
        public DataTable BuscarSilaboAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarSilaboAsignatura", Conectar)
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

        // Método para insertar una asignatura en un catálogo.
        public void InsertarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarAsignaturaCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Catalogo.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Catalogo.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Catalogo.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodDocente", Catalogo.CodDocente);
            Comando.Parameters.AddWithValue("@Silabo", Catalogo.Silabo);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar una asignatura de un catálogo.
        public void ActualizarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsignaturaCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Catalogo.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Catalogo.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Catalogo.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodDocente", Catalogo.CodDocente);
            Comando.Parameters.AddWithValue("@Silabo", Catalogo.Silabo);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar una asignatura de un catálogo
        public void EliminarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsignaturaCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Catalogo.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Catalogo.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Catalogo.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodDocente", Catalogo.CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
