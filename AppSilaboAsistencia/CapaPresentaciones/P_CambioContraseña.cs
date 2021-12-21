using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlesPerzonalizados;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_CambioContraseña : Form
    {
        public P_CambioContraseña()
        {
            InitializeComponent();
            lblCorreo.Text = E_InicioSesion.Usuario;
            pnPasos.Controls.Add(new C_CambioContraseñaCorreo());
            pnPasos.Controls.Add(new C_CambioContraseñaCodigo());
            pnPasos.Controls.Add(new C_CambioContraseñaNueva());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
