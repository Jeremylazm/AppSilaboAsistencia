using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ayudas
{
    public partial class A_DialogoRespuesta1 : Form
    {
        public A_DialogoRespuesta1(string Mensaje, Image Imagen)
        {
            InitializeComponent();
            Control[] Controles = { pbImagen, lblTitulo, lblMensaje };
            Docker.SubscribeControlsToDragEvents(Controles);

            pbImagen.Image = Imagen;
            lblMensaje.Text = Mensaje;
        }

        public static void Mostrar(string Mensaje, Image Imagen)
        {
            Form Fondo = new Form();
            using (A_DialogoRespuesta1 Dialogo = new A_DialogoRespuesta1(Mensaje, Imagen))
            {
                Fondo.StartPosition = FormStartPosition.Manual;
                Fondo.FormBorderStyle = FormBorderStyle.None;
                Fondo.Opacity = .70d;
                Fondo.BackColor = Color.Black;
                Fondo.WindowState = FormWindowState.Maximized;
                Fondo.TopMost = true;
                //Fondo.Location = Formulario.Location;
                Fondo.ShowInTaskbar = false;
                Fondo.Show();

                Dialogo.Owner = Fondo;
                Dialogo.ShowDialog();
                Dialogo.Dispose();

                Fondo.Dispose();
            }
        }

        private void P_DialogoRespuesta1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            AparicionFormulario.Start();
        }

        private void FormAparicion_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.2;
            if (this.Opacity == 1)
            {
                AparicionFormulario.Stop();
                AparicionImagen.ShowSync(pbImagen);
                lblTitulo.Visible = true;
                lblMensaje.Visible = true;
                btnAceptar.Visible = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
