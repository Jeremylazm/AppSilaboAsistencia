using CapaPresentaciones.Ayudas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPerzonalizados
{
    public partial class C_CambioContraseñaNueva : UserControl
    {
        public C_CambioContraseñaNueva()
        {
            InitializeComponent();
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Gestion de Plan de seciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MensajeConfirmacion("La contraseña se cambio éxitosamente");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            new A_Paso().Atras(ParentForm, "pbPaso3", "pbPaso2", "C_CambioContraseñaCodigo");
        }
    }
}
