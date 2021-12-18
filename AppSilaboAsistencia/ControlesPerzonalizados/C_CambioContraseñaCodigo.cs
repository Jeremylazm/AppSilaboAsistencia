using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using ControlesPerzonalizados.Ayudas;

namespace ControlesPerzonalizados
{
    public partial class C_CambioContraseñaCodigo : UserControl
    {
        private string codigo_verificacion = "";
        public static string Email;
        public static string Usuario;
        public C_CambioContraseñaCodigo()
        {
            InitializeComponent();
        }

        public static void Inicializar(string pEmail, string pUsuario)
        {
            Email = pEmail;
            Usuario = pUsuario;
        } //Listo

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Sílabo Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } //Listo

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if(ValidarCodigo())
                new A_Paso().Siguiente(ParentForm, "Paso2", "Paso3", "C_CambioContraseñaNueva");
        } //Listo

        private void btnAtras_Click(object sender, EventArgs e)
        {
            new A_Paso().Atras(ParentForm, "Paso2", "Paso1", "C_CambioContraseñaCorreo");
        } //Listo

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
                clientDetails.Credentials = new NetworkCredential("denisomarcuyottito@gmail.com", "Tutoriasunsaac5");

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress("denisomarcuyottito@gmail.com");
                mailDetails.To.Add(Correo);
                mailDetails.Subject = "Código de verificación";
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = "Ingresa el siguiente código: " + s;

                clientDetails.Send(mailDetails);
                return s;
            }
            catch (Exception ex)
            {
                // Mostrar error
                MessageBox.Show(ex.Message);
                return "-1";
            }
        }

        private bool ValidarCodigo()
        {
            string ans = validarpanelVerificarCodigo(codigo_verificacion, txtCodigoVerificacion.Text);
            if (ans == "00") // codigo ingresado incorrecto
            {
                MensajeError("Los codigos no coinciden, intente de nuevo");
                txtCodigoVerificacion.Text = "";
                txtCodigoVerificacion.Focus();
                return false;
            }
            else if (ans == "01") // codigo ingresado vacío
            {
                txtCodigoVerificacion.Focus();
                MensajeError("Campo codigo de verificación vacio, intente de nuevo");
                return false;
            }
            else // validacion correcta
            {
                return true;
            }
        }

        public string validarpanelVerificarCodigo(string codigoValido, string codigoIngresado)
        {
            // Verificar que se ingresó codigo
            if (codigoIngresado != "")
                // Verifcar código valido
                if (codigoIngresado == codigoValido)
                    return "1";
                // Codigo no coincide
                else
                    return "00";
            // Codigo no fue ingresado
            else
                return "01";
        }

        public string validarpanelEnviarCodigo(string correoValido, string correoIngresado)
        {
            // Verificar correo ingresado
            if (correoIngresado != "")
                // verificar correo valido
                if (correoIngresado == correoValido)
                    // enviar codigo de verificacion
                    return EnviarCodigo(correoValido);
                // Correo invalido
                else
                    return "00"; // 0: correo invalido
            // Correo no ingresado
            else
                return "01"; // correo vacio
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string correoIngresado = Email;

            string ans = validarpanelEnviarCodigo(Email, correoIngresado);

            if (ans == "-1")
            {
                txtEmail.Focus();
                MessageBox.Show("El código no se pudo enviar");
            }
            else if (ans == "00") // Correo invalido
            {
                txtEmail.Text = "";
                txtEmail.Focus();
                MensajeError("Correo electrónico no coincide, intente de nuevo");
            }
            // Correo no ingresado
            else if (ans == "01")
            {
                txtEmail.Focus();
                MensajeError("Correo no ingresado, intente de nuevo");
            }
            else
            {
                MessageBox.Show("Código enviado");
                codigo_verificacion = ans;

                // mostrar panel de verificacion de codigo
                panelCorreo.Visible = false;
                panelVerificacion.Visible = true;
                panelVerificacion.BringToFront();
                lblEmail.Text = correoIngresado;
            }
        }

        private void btnVolverEnviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string correo = lblEmail.Text;
            codigo_verificacion = EnviarCodigo(correo);
        }
    }
}
