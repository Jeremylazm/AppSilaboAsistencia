using System;
using CapaNegocios;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace CapaPresentaciones
{
    public partial class P_RecuperacionContraseña : Form
    {
        public P_RecuperacionContraseña()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Recupera la contraseña asociada a un usuario
        void Recuperar(string Email, string Dominio)
        {
            // Verificar si hay un usuario asociado al correo puesto en el textbox
            N_InicioSesion InicioSesion = new N_InicioSesion();
            string Contraseña = InicioSesion.RetornarContraseña(Email);

            // Enviar un correo con la contraseña del usuario si el usuario existe
            if (Contraseña != null)
            {
                try
                {
                    SmtpClient clientDetails = new SmtpClient();
                    clientDetails.Port = 587;
                    clientDetails.Host = "smtp.gmail.com";
                    clientDetails.EnableSsl = true;
                    clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                    clientDetails.UseDefaultCredentials = false;
                    clientDetails.Credentials = new NetworkCredential("elvis.ff.jorge@gmail.com", "ingdesoftware");

                    MailMessage mailDetails = new MailMessage();
                    mailDetails.From = new MailAddress("elvis.ff.jorge@gmail.com");
                    mailDetails.To.Add(Email + Dominio);
                    mailDetails.Subject = "Recuperación de contraseña de Sistema de Silabos y Asistencia UNSAAC";
                    mailDetails.IsBodyHtml = true;

                    // Llenamos el contenido de la solicitud
                    string TextoSolicitud = "<!DOCTYPE html>";
                    TextoSolicitud += "<html lang='es'>";
                    TextoSolicitud += "<body style='background - color: black '>";
                    TextoSolicitud += "<tr>";
                    TextoSolicitud += "<h2 style='color: #000000; text-align: center; margin: 0 0 7px'>" + "Solicitud de recuperación de contraseña de Silabo-Asistencia UNSAAC" + "</h2>";
                    TextoSolicitud += "<p style='color: #000000; margin: 2px; font - size: 15px'>";
                    TextoSolicitud += "<br/>";
                    TextoSolicitud += "<b>" + "CONTRASEÑA: " + "<span style='font-size: 45px'>" + Contraseña + "</span>" + "</b>" + "<br/>";
                    TextoSolicitud += "</p>";
                    TextoSolicitud += "<p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>Atte. Dream Team UNSAAC</p>";

                    TextoSolicitud += "</tr>";
                    TextoSolicitud += "</body>";
                    TextoSolicitud += "</html>";

                    mailDetails.Body = TextoSolicitud;
                    clientDetails.Send(mailDetails);
                    lblMensaje.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay ningún usuario asociado a esta cuenta");
            }
        }


        // Atajo tecla ENTER para enviar el formulario
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Recuperar(txtCorreo.Text, lblDominio.Text);
        }

        private void btnRecuperar_Click_1(object sender, EventArgs e)
        {
            Recuperar(txtCorreo.Text, lblDominio.Text);
        }
    }
}
