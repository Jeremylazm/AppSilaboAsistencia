using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Recursos
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para descargar la plantilla del silabo.
        public DataTable DescargarPlantillaSilabo()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuDescargarPlantillaSilabo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para descargar la plantilla del plan de sesiones.
        public DataTable DescargarPlantillaPlanSesiones()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuDescargarPlantillaPlanSesiones", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para actualizar la plantilla del silabo
        public void ActualizarPlantillaSilabo(E_Recursos Recursos)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarPlantillaSilabo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@PlantillaSilabo", Recursos.PlantillaSilabo);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la plantilla del plan de sesiones
        public void ActualizarPlantillaPlanSesiones(E_Recursos Recursos)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarPlantillaPlanSesiones", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@PlantillaPlanSesiones", Recursos.PlantillaPlanSesiones);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
