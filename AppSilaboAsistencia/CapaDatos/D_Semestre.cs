using CapaEntidades;
using ImageMagick;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace CapaDatos
{
    public class D_Semestre
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar el semestre actual.
        public DataTable SemestreActual()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuSemestreActual", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }

        // Método para mostrar la relación de semestres.
        public DataTable MostrarSemestres()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarSemestres", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }

        // Método para insertar los datos de un semestre.
        public void InsertarSemestre(E_Semestre Semestre)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarSemestre", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Denominacion", Semestre.Denominacion);
            Comando.Parameters.AddWithValue("@FechaInicio", Semestre.FechaInicio); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar los datos de un semestre.
        public void ActualizarSemestre(E_Semestre Semestre, string NDenominacion, string NFechaInicio)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarSemestre", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Denominacion", Semestre.Denominacion);
            Comando.Parameters.AddWithValue("@NDenominacion", NDenominacion); // Nueva Denoinacion (ej. 2021-II)
            Comando.Parameters.AddWithValue("@NFechaInicio", NFechaInicio); // Nueva FechaInicio (Formato: dd/mm/yyyy o dd-mm-yyyy)
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar el registro de un semestre.
        public void EliminarSemestre(E_Semestre Semestre)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarSemestre", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Denominacion", Semestre.Denominacion);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
