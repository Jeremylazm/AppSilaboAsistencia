using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ControlesPerzonalizados.Ayudas;
using CapaNegocios;

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

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Sílabo Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } //Listo

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Correo = txtUsuario.Text + lblDominio.Text;
            Verificar();
        }

        public void Verificar()
        {
            string correoIngresado = Correo;

            string ans = validarpanelEnviarCodigo(correoIngresado);

            if (ans == "Error Enviar Código")
            {
                MessageBox.Show("El código no se pudo enviar");
            }
            // Correo no ingresado
            else if (ans == "Correo Vacío")
            {
                MensajeError("Correo no ingresado, intente de nuevo");
            }
            else if (ans == "Correo no Válido")
            {
                MensajeError("El correo ingresado no es igual al correo que aparece en el perfil");
            }
            else
            {
                MessageBox.Show("Código enviado");

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
                return "Correo Vacío";
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

        private void C_CambioContraseñaCorreo_Enter(object sender, EventArgs e)
        {
            /*
            BunifuLabel UsuarioMC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblUsuario", false)[0];
            Usuario = UsuarioMC.Text;
            BunifuLabel CorreoVerdaderoMC = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblCorreoVerdadero", false)[0];
            CorreoValido = CorreoVerdaderoMC.Text;
            */
        }
    }
}
