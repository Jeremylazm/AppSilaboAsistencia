using CapaEntidades;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
    public class D_InicioSesion
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Método para el inicio de sesión.
        public bool IniciarSesion(string Usuario, string Contraseña)
        {
            SqlCommand Comando = new SqlCommand("spuIniciarSesion", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Usuario", Usuario);
            Comando.Parameters.AddWithValue("@Contraseña", Contraseña);

            SqlDataReader LeerFilas = Comando.ExecuteReader();
            if (LeerFilas.HasRows)
            {
                while (LeerFilas.Read())
                {
                    if (LeerFilas.GetValue(0).GetType() == Type.GetType("System.DBNull"))
                    {
                        E_InicioSesion.Perfil = null;
                    }
                    else
                    {
                        E_InicioSesion.Perfil = (byte[])LeerFilas.GetValue(0);
                    }
                    E_InicioSesion.Usuario = LeerFilas.GetString(1);
                    E_InicioSesion.Contraseña = LeerFilas.GetString(2);
                    E_InicioSesion.Acceso = LeerFilas.GetString(3);
                    E_InicioSesion.Datos = LeerFilas.GetString(4);
                }
                Conectar.Close();
                return true;
            }
            else
            {
                Conectar.Close();
                return false;
            }
        }

        // Método para cambiar de contraseña.
        public bool CambiarContraseña(string Usuario, string Contraseña)
        {
            SqlCommand Comando = new SqlCommand("spuCambiarContraseña", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            Conectar.Open();
            try
            {
                Comando.Parameters.AddWithValue("@Usuario", Usuario);
                Comando.Parameters.AddWithValue("@NuevaContrasenia", Contraseña);
                Comando.ExecuteNonQuery();

                Conectar.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("D_inicio_sesion | Error al cambiar la contraseña | Error de conexión" + ex);
                Conectar.Close();
                return false;
            }
        }

        // Método para obtener la contraseña.
        public string RetornarContraseña(string Usuario)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuRetornarContraseña", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            try
            {
                Comando.Parameters.AddWithValue("@Usuario", Usuario);
                SqlDataAdapter Data = new SqlDataAdapter(Comando);
                Data.Fill(Resultado);

                if (Resultado.Rows.Count >= 1)
                {
                    return Resultado.Rows[0][0].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al retornar la contraseña" + ex);
                return null;
            }
            finally
            {
                Conectar.Close();
            }
        }
    }
}
