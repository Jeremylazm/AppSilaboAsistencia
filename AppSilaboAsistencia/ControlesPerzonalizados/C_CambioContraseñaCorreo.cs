using System;
using System.Windows.Forms;
using ControlesPerzonalizados.Ayudas;

namespace ControlesPerzonalizados
{
    public partial class C_CambioContraseñaCorreo : UserControl
    {
        public string Usuario = "";
        public string Correo = "";
        public C_CambioContraseñaCorreo()
        {
            InitializeComponent();
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Sílabo Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } //Listo

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                Usuario = txtUsuario.Text;
                Correo = txtUsuario.Text + "@unsaac.edu.pe";
                C_CambioContraseñaCodigo.Inicializar(Correo, Usuario);
                new A_Paso().Siguiente(ParentForm, "Paso1", "Paso2", "C_CambioContraseñaCodigo");
            }
            else
                MensajeError("No se ingresó el usuario");
        }


    }
}
