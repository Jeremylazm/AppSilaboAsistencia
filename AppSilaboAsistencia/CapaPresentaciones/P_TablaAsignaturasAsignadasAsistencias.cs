using System;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasAsistencias : Form
    {
        public P_TablaAsignaturasAsignadasAsistencias()
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
