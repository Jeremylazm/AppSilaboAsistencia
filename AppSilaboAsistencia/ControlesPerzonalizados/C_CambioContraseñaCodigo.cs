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
    public partial class C_CambioContraseñaCodigo : UserControl
    {
        public C_CambioContraseñaCodigo()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            new A_Paso().Siguiente(ParentForm, "pbPaso2", "pbPaso3", "C_CambioContraseñaNueva");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            new A_Paso().Atras(ParentForm, "pbPaso2", "pbPaso1", "C_CambioContraseñaCorreo");
        }
    }
}
