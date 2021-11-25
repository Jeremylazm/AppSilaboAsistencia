using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        public P_InicioSesion()
        {
            InitializeComponent();
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            ActualizarColor();
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
