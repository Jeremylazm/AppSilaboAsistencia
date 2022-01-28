using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_Bienvenida : Form
    {
        public P_Bienvenida()
        {
            InitializeComponent();
        }

        public void Abrir()
        {
            lblDatos.Text = E_InicioSesion.Datos;
            this.TopMost = true;
            this.Show();
            this.Opacity = 0.0;
            TiempoAparicion.Start();
        }

        public void Cerrar()
        {
            this.TopMost = false;
            TiempoDesaparicion.Start();
        }

        private void TiempoAparicion_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.5;
            if (this.Opacity == 1)
            {
                TiempoAparicion.Stop();
                lblBienvenida.Visible = true;
                lblDatos.Visible = true;
                pbProgreso.Visible = true;
            }
        }

        private void TiempoDesaparicion_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                TiempoDesaparicion.Stop();
                this.Close();
            }
        }
    }
}
