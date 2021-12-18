using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ControlesPerzonalizados.Ayudas;

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
            BunifuPictureBox PictureActual = (BunifuPictureBox)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("pbPaso3", false)[0];
            PictureActual.Image = Properties.Resources.Circulo_Checked;

            MensajeConfirmacion("La contraseña se cambio éxitosamente");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            new A_Paso().Atras(ParentForm, "Paso3", "Paso2", "C_CambioContraseñaCodigo");
        }
    }
}
