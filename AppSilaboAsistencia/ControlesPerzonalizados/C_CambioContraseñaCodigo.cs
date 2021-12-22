using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Ayudas;
using ControlesPerzonalizados;
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

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Sílabo Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } //Listo

        private void btnAtras_Click(object sender, EventArgs e)
        {
            new A_Paso().Atras(ParentForm, "Paso2", "Paso1", "C_CambioContraseñaCorreo");
        } //Listo

        private void btnSiguiente_Click(object sender, EventArgs e)
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
                MensajeError("Campo código de verificación vacío, intente de nuevo");
        } //Listo

        private bool ValidarCodigo()
        {
            string ans = validarpanelVerificarCodigo(codigo_verificacion, txtCodigoVerificacion.Text);
            if (ans == "Código no Coincide") // codigo ingresado incorrecto
            {
                MensajeError("Los códigos no coinciden, intente de nuevo");
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

        private void btnVolverEnviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            codigo_verificacion = EnviarCodigo(Email);
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

        private void C_CambioContraseñaCodigo_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show(ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCorreo", false).Length.ToString());
            //BunifuLabel CorreoE = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCorreo", false)[0];
            //lblEmail.Text = CorreoE.Text;
        }

        private void btnSiguiente_MouseEnter(object sender, EventArgs e)
        {
            //BunifuLabel CorreoE = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCorreo", false)[0];
            //lblEmail.Text = CorreoE.Text;
        }

        private void txtCodigoVerificacion_TextChange(object sender, EventArgs e)
        {
            CodigoVerificacion_Lleno = Validador.ValidarCampoLleno(txtCodigoVerificacion, lblErrorCodigo, pbErrorCodigo);
            if (CodigoVerificacion_Lleno)
            {
                lblErrorCodigo.Visible = false;
                pbErrorCodigo.Visible = false;
            }
        }
    }
}
