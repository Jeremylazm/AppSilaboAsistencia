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
        public P_CambioContraseña(string CorreoVálido)
        {
            InitializeComponent();
            lblCorreoVerdadero.Text = CorreoVálido;
            lblCorreo.Text = E_InicioSesion.Usuario;
            lblUsuario.Text = E_InicioSesion.Usuario;
            C_CambioContraseñaCorreo Correo = new C_CambioContraseñaCorreo(lblUsuario.Text, lblCorreoVerdadero.Text)
            {
                Dock = DockStyle.Fill
            };
            pnPasos.Controls.Add(Correo);
            C_CambioContraseñaCodigo Codigo = new C_CambioContraseñaCodigo()
            {
                Dock = DockStyle.Fill
            };
            pnPasos.Controls.Add(Codigo);
            C_CambioContraseñaNueva Nueva = new C_CambioContraseñaNueva()
            {
                Dock = DockStyle.Fill
            };
            pnPasos.Controls.Add(Nueva);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
