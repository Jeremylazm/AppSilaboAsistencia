using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Ayudas;
using Bunifu.UI.WinForms;

namespace ControlesPerzonalizados
{
    public partial class C_CambioContraseñaCodigo : UserControl
    {
        public string codigo_verificacion;
        public string Email;
        public string Usuario;
        bool CodigoVerificacion_Lleno = false;
        readonly A_Validador Validador;
        public C_CambioContraseñaCodigo()
        {
            Validador = new A_Validador();
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Siguiente_Paso();
        }

        private bool ValidarCodigo()
        {
            string ans = validarpanelVerificarCodigo(codigo_verificacion, txtCodigoVerificacion.Text);
            if (ans == "Código no Coincide") // codigo ingresado incorrecto
            {
                A_Dialogo.DialogoError("Los códigos no coinciden, intente de nuevo");
                txtCodigoVerificacion.Text = "";
                return false;
            }
            else // validacion correcta
            {
                return true;
            }
        }

        public string validarpanelVerificarCodigo(string codigoValido, string codigoIngresado)
        {
            if (codigoIngresado == codigoValido)
                return "Código Válido";
            // Codigo no coincide
            else
                return "Código no Coincide";
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

        private void C_CambioContraseñaCodigo_Enter(object sender, EventArgs e)
        {      
            BunifuLabel CorreoCC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCorreo", false)[0];
            Email = CorreoCC.Text;
            BunifuLabel UsuarioCC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblUsuario", false)[0];
            Usuario = UsuarioCC.Text;
            BunifuLabel CodigoVerificacionCC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCodVerificacion", false)[0];
            codigo_verificacion = CodigoVerificacionCC.Text;
            lblEmail.Text = Email;
        }

        private void txtCodigoVerificacion_TextChanged(object sender, EventArgs e)
        {
            CodigoVerificacion_Lleno = Validador.ValidarNumeroLimitado(txtCodigoVerificacion, lblErrorCodigo, pbErrorCodigo, 6);
            if (CodigoVerificacion_Lleno)
            {
                lblErrorCodigo.Visible = false;
                pbErrorCodigo.Visible = false;
            }
        }

        private void btnVolverEnviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            codigo_verificacion = EnviarCodigo(Email);
            if (codigo_verificacion == "Error Enviar Código")
                A_Dialogo.DialogoError("Error al enviar el código de verificación");
            else
                A_Dialogo.DialogoInformacion("El código de verificación fue enviado, revise su correo institucional");
        }

        private void btnSiguiente_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtCodigoVerificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Siguiente_Paso();
        }

        public void Siguiente_Paso()
        {
            if (CodigoVerificacion_Lleno)
            {
                if (ValidarCodigo())
                {
                    BunifuLabel UsuarioCN = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblUsuario", false)[0];
                    UsuarioCN.Text = Usuario;
                    new A_Paso().Siguiente(ParentForm, "Paso2", "Paso3", "C_CambioContraseñaNueva");
                }
            }
            else
            {
                Validador.EnfocarCursor(txtCodigoVerificacion);
            }
        }
    }
}
