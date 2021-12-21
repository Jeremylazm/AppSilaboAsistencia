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
    public class D_Estudiante
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar los estudiantes de una escuela profesional. 
        public DataTable MostrarEstudiantes(string CodEscuelaP)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Resources/Perfil Estudiante.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        // Método para buscar un estudiante (por su código) de una escuela profesional.
        public DataTable BuscarEstudiante(string CodEscuelaP, string CodEstudiante)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodEstudiante", CodEstudiante);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Resources/Perfil Estudiante.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        // Método para buscar por cualquier atributo los estudiantes de una escuela profesional.
        public DataTable BuscarEstudiantes(string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Resources/Perfil Estudiante.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        // Método para insertar un nuevo registro de un estudiante en la dase de batos.
        public void InsertarEstudiante(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Estudiante.Perfil);
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Estudiante.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Estudiante.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            Comando.Parameters.AddWithValue("@Email", Estudiante.Email);
            Comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Estudiante.Telefono);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Estudiante.CodEscuelaP);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el registro de un estudiante de la base de datos.
        public void ActualizarEstudiante(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Estudiante.Perfil);
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Estudiante.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Estudiante.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            Comando.Parameters.AddWithValue("@Email", Estudiante.Email);
            Comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Estudiante.Telefono);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Estudiante.CodEscuelaP);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar el registro de un estudiante de la base de datos.
        public void EliminarEstudiante(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
