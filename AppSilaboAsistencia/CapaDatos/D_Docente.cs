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
    public class D_Docente
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar los docentes de un departamento académico
        public DataTable MostrarTodosDocentesDepartamento(string CodDepartamentoA)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarTodosDocentesDepartamento", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

          
            return Resultado;
        }
        // Segundo Método para mostrar los docentes de un departamento académico
        public DataTable DosMostrarTodosDocentesDepartamento(string CodDepartamentoA)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuDosMostrarTodosDocentesDepartamento", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);


            return Resultado;
        }

        // Método para mostrar los docentes de un departamento académico
        public DataTable MostrarDocentesDepartamento(string CodDepartamentoA)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarDocentesDepartamento", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Resources/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
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

        // Método para buscar un docente (por su código) de un departamento académico
        public DataTable BuscarDocente(string CodDepartamentoA, string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Resources/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
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

        // Método para buscar por cualquier atributo los docentes de un departamento académico.
        public DataTable BuscarDocentes(string CodDepartamentoA, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarDocentes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Resources/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
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

        // Método para obtener el código de un docente por su nombre.
        public DataTable ObtenerCodigoDocente(string Nombre)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuObtenerCodigoDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@Nombre", Nombre);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }

        // Método para insertar un nuevo registro de un docente en la dase de batos.
        public void InsertarDocente(E_Docente Docente)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Docente.Perfil);
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Docente.Nombre);
            Comando.Parameters.AddWithValue("@Email", Docente.Email);
            Comando.Parameters.AddWithValue("@Direccion", Docente.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Comando.Parameters.AddWithValue("@Categoria", Docente.Categoria);
            Comando.Parameters.AddWithValue("@Subcategoria", Docente.Subcategoria);
            Comando.Parameters.AddWithValue("@Regimen", Docente.Regimen);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", Docente.CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Docente.CodEscuelaP);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el registro de un docente de la base de datos.
        public void ActualizarDocente(E_Docente Docente)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Docente.Perfil);
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Docente.Nombre);
            Comando.Parameters.AddWithValue("@Email", Docente.Email);
            Comando.Parameters.AddWithValue("@Direccion", Docente.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Comando.Parameters.AddWithValue("@Categoria", Docente.Categoria);
            Comando.Parameters.AddWithValue("@Subcategoria", Docente.Subcategoria);
            Comando.Parameters.AddWithValue("@Regimen", Docente.Regimen);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", Docente.CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Docente.CodEscuelaP);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar el registro de un docente de la base de datos.
        public void EliminarDocente(E_Docente Docente)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
