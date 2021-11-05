using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Asignatura
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para mostrar las asignaturas de una escuela profesional.
        public DataTable MostrarAsignaturas(string CodEscuelaP)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarAsignaturas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar una asignatura de una escuela profesional.
        public DataTable BuscarAsignatura(string CodEscuelaP, string CodAsignatura)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar por cualquier atributo las asignaturas de una escuela profesional.
        public DataTable BuscarAsignaturas(string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignaturas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para insertar un nuevo registro de una asignatura en la dase de datos.
        public void InsertarAsignatura(E_Asignatura Asignatura)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEscuelaP", Asignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Asignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@NombreAsignatura", Asignatura.NombreAsignatura);
            Comando.Parameters.AddWithValue("@Creditos", Asignatura.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Asignatura.Categoria);
            Comando.Parameters.AddWithValue("@HorasTeoria", Asignatura.HorasTeoria);
            Comando.Parameters.AddWithValue("@HorasPractica", Asignatura.HorasPractica);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el registro de una asignatura de la base de datos.
        public void ActualizarAsignatura(E_Asignatura Asignatura)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEscuelaP", Asignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Asignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@NombreAsignatura", Asignatura.NombreAsignatura);
            Comando.Parameters.AddWithValue("@Creditos", Asignatura.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Asignatura.Categoria);
            Comando.Parameters.AddWithValue("@HorasTeoria", Asignatura.HorasTeoria);
            Comando.Parameters.AddWithValue("@HorasPractica", Asignatura.HorasPractica);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar el registro de una asignatura de la base de datos.
        public void EliminarAsignatura(E_Asignatura Asignatura)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEscuelaP", Asignatura.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Asignatura.CodAsignatura);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
