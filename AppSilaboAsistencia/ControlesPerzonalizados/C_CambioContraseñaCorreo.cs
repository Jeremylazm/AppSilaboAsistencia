using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Ayudas;

namespace ControlesPerzonalizados
{
    public partial class C_CambioContraseñaCorreo : UserControl
    {
        string codigo_verificacion = "";
        string Usuario;
        string Correo;
        string CorreoVálido;
        bool Usuario_Lleno = false;
        readonly A_Validador Validador;
        public C_CambioContraseñaCorreo(string pUsuario, string pCorreoVálido)
        {
            Usuario = pUsuario;
            CorreoVálido = pCorreoVálido;
            Validador = new A_Validador();
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Siguiente_Paso();
        }

        public void Verificar()
        {
            string correoIngresado = Correo;

            string ans = validarpanelEnviarCodigo(correoIngresado);

            if (ans == "Error Enviar Código")
            {
                A_Dialogo.DialogoError("Error al enviar el código de verificación");
                //MessageBox.Show("El código no se pudo enviar");
            }
            else if (ans == "Correo no Válido")
            {
                A_Dialogo.DialogoError("El correo ingresado no es igual al correo que aparece en el perfil");
            }
            else if (ans == "Correo Vacío")
            {
                Validador.EnfocarCursor(txtUsuario);
            }
            else
            {
                A_Dialogo.DialogoInformacion("El código de verificación fue enviado, revise su correo institucional");

                codigo_verificacion = ans;
                BunifuLabel CorreoCC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCorreo", false)[0];
                CorreoCC.Text = Correo;
                BunifuLabel UsuarioCC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblUsuario", false)[0];
                UsuarioCC.Text = Usuario;
                BunifuLabel CodigoVerificacionCC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCodVerificacion", false)[0];
                CodigoVerificacionCC.Text = codigo_verificacion;
                new A_Paso().Siguiente(ParentForm, "Paso1", "Paso2", "C_CambioContraseñaCodigo");
            }
        }

        public string validarpanelEnviarCodigo(string correoIngresado) //Cambiar
        {
            if (Usuario_Lleno)
            {
                if (correoIngresado == CorreoVálido)
                    return EnviarCodigo(correoIngresado);
                else
                    return "Correo no Válido";
            }
            else
            {
                return "Correo Vacío";
            }
        }

        public string EnviarCodigo(string Correo)
        {
            // Enviar un correo con un codigo de verificiacion random
            try
            {
                // Crear codigo random de 6 caracteres
                Random r = new Random();
                var x = r.Next(0, 1000000);
                string s = x.ToString("000000");

                // Enviar codigo de verificacion
                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential("elvis.ff.jorge@gmail.com", "ingdesoftware");

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress("elvis.ff.jorge@gmail.com");
                mailDetails.To.Add(Correo);
                mailDetails.Subject = "Cambio de contraseña de Sistema de Silabos y Asistencia UNSAAC";
                mailDetails.IsBodyHtml = true;

                // Llenamos el contenido de la solicitud
                string TextoSolicitud = "<!DOCTYPE html>";
                TextoSolicitud += "<html lang='es'>";
                TextoSolicitud += "<body style='background - color: black '>";
                TextoSolicitud += "<tr>";
                TextoSolicitud += "<h2 style='color: #000000; text-align: center; margin: 0 0 7px'>" + "Solicitud de cambio de contraseña de Silabo-Asistencia UNSAAC" + "</h2>";
                TextoSolicitud += "<p style='color: #000000; margin: 2px; font - size: 15px'>";
                TextoSolicitud += "<br/>";
                TextoSolicitud += "<b>" + "CÓDIGO DE VERIFICACIÓN: " + "<span style='font-size: 45px'>" + s + "</span>" + "</b>" + "<br/>";
                TextoSolicitud += "</p>";
                TextoSolicitud += "<p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>Atte. Dream Team UNSAAC</p>";

                TextoSolicitud += "</tr>";
                TextoSolicitud += "</body>";
                TextoSolicitud += "</html>";

                mailDetails.Body = TextoSolicitud;
                clientDetails.Send(mailDetails);
                return s;
            }
            catch (Exception)
            {
                // Mostrar error
                A_Dialogo.DialogoError("Error al enviar el código de verificación");
                //MessageBox.Show(ex.Message);
                return "Error Enviar Código";
            }
        }

        private void txtUsuario_TextChange(object sender, EventArgs e)
        {
            Usuario_Lleno = Validador.ValidarCampoLleno(txtUsuario, lblErrorUsuario, pbErrorUsuario);
            if (Usuario_Lleno)
            {
                lblErrorUsuario.Visible = false;
                pbErrorUsuario.Visible = false;
            }
        }

        private void btnSiguiente_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Siguiente_Paso();
        }

        public void Siguiente_Paso()
        {
            Correo = txtUsuario.Text + lblDominio.Text;
            Verificar();
        }
    }
}
