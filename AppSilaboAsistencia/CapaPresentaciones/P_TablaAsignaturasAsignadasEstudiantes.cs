using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasEstudiantes : Form
    {
        public P_TablaAsignaturasAsignadasEstudiantes()
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
