using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Recursos
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

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

        // Método para descargar la plantilla del plan de sesiones de 2 y 3 créditos.
        public DataTable DescargarPlantillaPlanSesiones2y3()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuDescargarPlantillaPlanSesiones2y3", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para descargar la plantilla del plan de sesiones de 4 créditos.
        public DataTable DescargarPlantillaPlanSesiones4()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuDescargarPlantillaPlanSesiones4", Conectar)
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

        // Método para actualizar la plantilla del plan de sesiones de 2 y 3 créditos
        public void ActualizarPlantillaPlanSesiones2y3(E_Recursos Recursos)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarPlantillaPlanSesiones2y3", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@PlantillaPlanSesiones2y3", Recursos.PlantillaPlanSesiones2y3);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la plantilla del plan de sesiones de 4 créditos
        public void ActualizarPlantillaPlanSesiones4(E_Recursos Recursos)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarPlantillaPlanSesiones4", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@PlantillaPlanSesiones4", Recursos.PlantillaPlanSesiones4);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
        
    }
}
