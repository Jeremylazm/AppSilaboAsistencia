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
        private readonly string CodDocente = E_InicioSesion.Usuario;
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
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente("2021-II", "IF", CodDocente);
            AccionesTabla();
        }

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente("2021-II", "IF", CodDocente, txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Estudiantes
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                P_HistorialSesionesAsignatura HistorialSesiones = new P_HistorialSesionesAsignatura(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), CodDocente)//codasignatura y coddocente
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                ParentForm.Controls.Find("pnPrincipal", false)[0].Controls.Find("pnContenedor", false)[0].Controls.Add(HistorialSesiones);
                HistorialSesiones.Show();
                HistorialSesiones.BringToFront();
                HistorialSesiones.Dispose();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }
    }
}
