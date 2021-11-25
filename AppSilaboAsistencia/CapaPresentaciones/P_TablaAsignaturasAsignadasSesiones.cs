using System;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasSesiones : Form
    {
        public P_TablaAsignaturasAsignadasSesiones()
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
