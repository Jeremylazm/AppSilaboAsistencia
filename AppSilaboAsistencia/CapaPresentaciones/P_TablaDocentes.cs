using CapaEntidades;
using CapaNegocios;
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
    public partial class P_TablaDocentes : Form
    {
        readonly E_Docente ObjEntidad = new E_Docente();
        readonly N_Docente ObjNegocio = new N_Docente();

        public P_TablaDocentes()
        {
            InitializeComponent();
        }

        private void P_TablaDocentes_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        public void AccionesTabla()
        {
            dgvTabla.Columns[0].Visible = false;
            dgvTabla.Columns[3].Visible = false;
            dgvTabla.Columns[4].Visible = false;
            dgvTabla.Columns[5].Visible = false;
            dgvTabla.Columns[13].Visible = false;

            dgvTabla.Columns[1].HeaderText = "";
            dgvTabla.Columns[2].HeaderText = "Cod. Docente";
            dgvTabla.Columns[6].HeaderText = "Docente";
            dgvTabla.Columns[7].HeaderText = "Email";
            dgvTabla.Columns[8].HeaderText = "Dirección";
            dgvTabla.Columns[9].HeaderText = "Teléfono";
            dgvTabla.Columns[10].HeaderText = "Categoría";
            dgvTabla.Columns[11].HeaderText = "Subcategoría";
            dgvTabla.Columns[12].HeaderText = "Régimen";
            dgvTabla.Columns[14].HeaderText = "Escuela Profesional";
        }

        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_Docente.MostrarDocentes("IN");
            AccionesTabla();
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            P_DatosDocente NuevoRegistro = new P_DatosDocente();
            NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistro.ShowDialog();
            NuevoRegistro.Dispose();
        }
    }
}
