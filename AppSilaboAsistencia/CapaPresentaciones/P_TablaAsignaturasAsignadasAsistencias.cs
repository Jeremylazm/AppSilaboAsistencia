using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using Ayudas;
namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasAsistencias : Form
    {
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

        public P_TablaAsignaturasAsignadasAsistencias()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            MostrarAsignaturas();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 4;
            dgvDatos.Columns[4].Visible = false;
            dgvDatos.Columns[1].HeaderText = "Código";
            dgvDatos.Columns[2].HeaderText = "Asignatura";
            dgvDatos.Columns[3].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[4].HeaderText = "Grupo";
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, CodDocente);
            //modificar atributos de las columnas
            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            }
            dgvDatos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDatos.Columns[0].MinimumWidth = 100;
            dgvDatos.Columns[0].Width = 100;
            dgvDatos.Columns[1].MinimumWidth = 100;
            dgvDatos.Columns[1].Width = 100;
            dgvDatos.Columns[2].MinimumWidth = 480;
            dgvDatos.Columns[2].Width = 480;
            dgvDatos.Columns[3].MinimumWidth = 400;
            dgvDatos.Columns[3].Width = 400;
            AccionesTabla();
        }

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, CodDocente, txtBuscar.Text);
            //modificar atributos de las columnas
            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            }
            dgvDatos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDatos.Columns[0].MinimumWidth = 100;
            dgvDatos.Columns[0].Width = 100;
            dgvDatos.Columns[1].MinimumWidth = 100;
            dgvDatos.Columns[1].Width = 100;
            dgvDatos.Columns[2].MinimumWidth = 480;
            dgvDatos.Columns[2].Width = 480;
            dgvDatos.Columns[3].MinimumWidth = 400;
            dgvDatos.Columns[3].Width = 400;
            AccionesTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                // Estudiantes
                string CodEscuelaP = N_Catalogo.VerEscuelaAsignatura(CodSemestre, dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString()).Rows[0][0].ToString();
                DataTable Estudiantes = N_Matricula.BuscarEstudiantesMatriculadosAsignatura(CodSemestre, CodEscuelaP, dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), "");

                if (Estudiantes.Rows.Count != 0)
                {
                    P_HistorialSesionesAsignatura HistorialSesiones = new P_HistorialSesionesAsignatura(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString()) //codasignatura y coddocente
                    {
                        TopLevel = false,
                        Dock = DockStyle.Fill
                    };
                    ParentForm.Controls.Find("pnPrincipal", false)[0].Controls.Find("pnContenedor", false)[0].Controls.Add(HistorialSesiones);
                    HistorialSesiones.Show();
                    HistorialSesiones.BringToFront();
                    //HistorialSesiones.Dispose();
                }
                else
                {
                    A_Dialogo.DialogoError("No hay Estudiantes Matriculados" + Environment.NewLine + "Ud. debe actualizar");
                }
            }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }
    }
}
