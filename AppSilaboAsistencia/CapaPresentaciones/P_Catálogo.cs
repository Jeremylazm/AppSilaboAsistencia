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
    public partial class P_Catálogo : Form
    {
        public P_Catálogo()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Maximizar.Visible = true;
            Restaurar.Visible = false;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Menú_Click(object sender, EventArgs e)
        {
            if (Panel_DashBoard.Width == 201)
            {
                Panel_DashBoard.Visible = false;
                Panel_DashBoard.Width = 72;
                GradientPanel.Width = 44;
            }
            else
            {
                Panel_DashBoard.Visible = false;
                Panel_DashBoard.Width = 201;
                GradientPanel.Width = 171;
            }
        }

        private void Botón_Agregar_Click(object sender, EventArgs e)
        {
            P_Catálogo_Agregar CA = new P_Catálogo_Agregar();
            CA.Show();
        }
    }
}
