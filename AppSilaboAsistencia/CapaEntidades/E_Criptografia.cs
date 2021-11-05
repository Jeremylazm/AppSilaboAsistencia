using System;
using System.Security.Cryptography; //Libreria necesaria
using System.Text;

namespace CapaEntidades
{
    public class E_Criptografia
    {
        public static string EncriptarRSA(string Mensaje, string Clave)
        {
            //NOTA: El mensaje debe tener como máximo 117 caracteres
            try
            {
                CspParameters CSApars = new CspParameters(); //Política de Seguridad del Contenido (CSP)
                CSApars.KeyContainerName = Clave;
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(CSApars);
                byte[] Msg = Encoding.UTF8.GetBytes(Mensaje);
                byte[] MsgEncriptado = RSA.Encrypt(Msg, false); // Encriptar mensaje
                return Convert.ToBase64String(MsgEncriptado);
            }
            catch (Exception e)
            {
                Console.WriteLine("El mensaje debe tener 117 caracteres como máximo: " + e);
                return null;
            }
        }
        public static string DesencriptarRSA(string MensajeEncriptado, string Clave)
        {
            try
            {
                CspParameters CSApars = new CspParameters(); // Política de Seguridad del Contenido (CSP)
                CSApars.KeyContainerName = Clave;
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(CSApars);
                byte[] MsgEncriptado = Convert.FromBase64String(MensajeEncriptado);
                byte[] Msg = RSA.Decrypt(MsgEncriptado, false); // Desencriptar mensaje
                return Encoding.UTF8.GetString(Msg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Clave incorrecta" + e);
                return null;
            }
        }

        public static string CifradoMD5(string Contraseña)
        {
            byte[] ContraseñaBytes = new UTF8Encoding().GetBytes(Contraseña); // Aplicar MD5 para generar hash
            byte[] Hash = System.Security.Cryptography.MD5.Create().ComputeHash(ContraseñaBytes);
            string ContraseñaCifrada = BitConverter.ToString(Hash)
               .Replace("-", "") //Sin guiones
               .ToLower();       //En minusculas
            return ContraseñaCifrada;
        }
    }
}
