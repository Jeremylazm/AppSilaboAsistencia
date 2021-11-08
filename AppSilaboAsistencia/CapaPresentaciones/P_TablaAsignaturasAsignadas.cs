using System.Data;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadas : Form
    {
        public P_TablaAsignaturasAsignadas()
        {
            InitializeComponent();
            Docker.SubscribeControlToDragEvents(lblTitulo);
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
