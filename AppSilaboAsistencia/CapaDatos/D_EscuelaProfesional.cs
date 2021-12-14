using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_EscuelaProfesional
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para mostrar las escuelas profesionales.
        public DataTable MostrarEscuelas()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarEscuelas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }

        public string BuscarNombreEscuela(string CodEscuelaP)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarNombreEscuela", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado.Rows[0]["Nombre"].ToString();
        }
    }
}
