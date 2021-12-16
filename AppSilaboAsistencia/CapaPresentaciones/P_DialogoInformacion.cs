using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_DialogoInformacion : Form
    {
        public P_DialogoInformacion(string Mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = Mensaje;
        }

        public static void Mostrar(string Mensaje)
        {
            P_DialogoInformacion Dialogo = new P_DialogoInformacion(Mensaje);
            Dialogo.ShowDialog();
        }

        private void P_DialogoInformacion_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            FormAparicion.Start();
        }

        private void FormAparicion_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.2;
            if (this.Opacity == 1)
            {
                FormAparicion.Stop();
                ImagenAparicion.ShowSync(pbImagen);
                btnAceptar.Visible = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
