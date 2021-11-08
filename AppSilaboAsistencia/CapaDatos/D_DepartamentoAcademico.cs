using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_DepartamentoAcademico
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para mostrar las escuelas profesionales.
        public DataTable MostrarDepartamentos()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarDepartamentos", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }
    }
}
