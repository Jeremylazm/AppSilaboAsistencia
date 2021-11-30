using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Asignatura
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar las asignaturas de un departamento académico.
        public DataTable MostrarAsignaturas(string CodDepartamentoA)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarAsignaturas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamento", CodDepartamentoA);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }


        // Método para buscar una asignatura.
        public DataTable BuscarAsignatura(string CodDepartamentoA, string CodAsignatura)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamento", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar por cualquier atributo las asignaturas de una escuela profesional.
        public DataTable BuscarAsignaturas(string CodDepartamentoA, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignaturas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamento", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        //Método para obtener horas de teoría y práctica de una asignatura.
        public DataTable ObtenerHorasAsignatura(string CodAsignatura)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuObtenerHorasAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        //Método para obtener el código de una asignatura por su nombre.
        public DataTable ObtenerCódigoAsignatura(string NombreAsignatura)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuObtenerCodigoAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            Comando.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        //Método para obtener el código de una asignatura por su nombre.
        public DataTable ObtenerPrimeraAsignatura()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuObtenerPrimeraAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
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
            Comando.Parameters.AddWithValue("@CodAsignatura", Asignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@NombreAsignatura", Asignatura.NombreAsignatura);
            Comando.Parameters.AddWithValue("@Creditos", Asignatura.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Asignatura.Categoria);
            Comando.Parameters.AddWithValue("@HorasTeoria", Asignatura.HorasTeoria);
            Comando.Parameters.AddWithValue("@HorasPractica", Asignatura.HorasPractica);
            Comando.Parameters.AddWithValue("@Prerrequisito", Asignatura.Prerrequisito);
            Comando.Parameters.AddWithValue("@Sumilla", Asignatura.Sumilla);
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
            Comando.Parameters.AddWithValue("@CodAsignatura", Asignatura.CodAsignatura);
            Comando.Parameters.AddWithValue("@NombreAsignatura", Asignatura.NombreAsignatura);
            Comando.Parameters.AddWithValue("@Creditos", Asignatura.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Asignatura.Categoria);
            Comando.Parameters.AddWithValue("@HorasTeoria", Asignatura.HorasTeoria);
            Comando.Parameters.AddWithValue("@HorasPractica", Asignatura.HorasPractica);
            Comando.Parameters.AddWithValue("@Prerrequisito", Asignatura.Prerrequisito);
            Comando.Parameters.AddWithValue("@Sumilla", Asignatura.Sumilla);
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
            Comando.Parameters.AddWithValue("@CodAsignatura", Asignatura.CodAsignatura);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
