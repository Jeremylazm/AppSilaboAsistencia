using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasAsistencias : Form
    {
        public P_TablaAsignaturasAsignadasAsistencias()
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            MostrarAsignaturas();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 4;
            dgvDatos.Columns[4].Visible = false;
            dgvDatos.Columns[1].HeaderText = "Código";
            dgvDatos.Columns[2].HeaderText = "Nombre";
            dgvDatos.Columns[3].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[4].HeaderText = "Grupo";
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente("2021-II", "IF", "65475");
            AccionesTabla();
        }

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente("2021-II", "IF", "65475", txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Estudiantes
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                P_HistorialSesionesAsignatura Estudiantes = new P_HistorialSesionesAsignatura(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), "65475");//codasignatura y coddocente

                Estudiantes.ShowDialog();
                Estudiantes.Dispose();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }
    }
}
