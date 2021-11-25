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
    public partial class P_Editar_Catálogo : Form
    {
        public P_Editar_Catálogo()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void Menú_Click(object sender, EventArgs e)
        {
            if(Panel_DashBoard.Width==201)
            {
                Panel_DashBoard.Visible = false;
                Panel_DashBoard.Width = 80;
                GradientPanel.Width = 48;
                Animación_Panel.Show(Panel_DashBoard);
            }
            else
            {
                Panel_DashBoard.Visible = false;
                Panel_DashBoard.Width = 201;
                GradientPanel.Width = 171;
                Animación_Panel_Back.Show(Panel_DashBoard);
            }
        }
    }
}
