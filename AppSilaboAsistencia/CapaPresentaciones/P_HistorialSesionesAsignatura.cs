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
    public partial class P_HistorialSesionesAsignatura : Form
    {
        public string CodAsignatura;
        public string CodDocente;

        public P_HistorialSesionesAsignatura(string pCodAsignatura, string pCodDocente)
        {
            CodAsignatura = pCodAsignatura;
            CodDocente = pCodDocente;
            InitializeComponent();

            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
