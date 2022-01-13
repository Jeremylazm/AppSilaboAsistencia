using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_SeleccionadoAsignatura : Form
    {
        public P_SeleccionadoAsignatura()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Revisar P_SeleccionadoAsignaturaAsignada
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Revisar P_SeleccionadoAsignaturaAsignada
        }

        private void P_SeleccionadoAsignatura_Load(object sender, EventArgs e)
        {
            dgvDatos.ClearSelection();
        }
    }
}
