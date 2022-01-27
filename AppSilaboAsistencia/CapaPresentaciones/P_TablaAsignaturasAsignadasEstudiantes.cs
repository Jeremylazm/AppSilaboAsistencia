using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CapaNegocios;
using System.Data;
using CapaEntidades;
using Ayudas;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasEstudiantes : Form
    {
        readonly N_Catalogo ObjCatalogo;
        readonly E_Matricula ObjEntidadMatricula;
        readonly N_Matricula ObjNegocioMatricula;
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

        public P_TablaAsignaturasAsignadasEstudiantes()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            ObjEntidadMatricula = new E_Matricula();
            ObjNegocioMatricula = new N_Matricula();
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            MostrarAsignaturas();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 5;
            dgvDatos.Columns[1].DisplayIndex = 5;

            dgvDatos.Columns[5].Visible = false;

            dgvDatos.Columns[2].HeaderText = "Código";
            dgvDatos.Columns[3].HeaderText = "Asignatura";
            dgvDatos.Columns[4].HeaderText = "Escuela Profesional";
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, CodDocente);
            AccionesTabla();
        }   

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, CodDocente, txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ActualizarEstudiantes()
        {
            string CodAsignatura = "";
            this.Invoke((MethodInvoker)delegate
            {
                CodAsignatura = dgvDatos.Rows[dgvDatos.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            });

            A_Dialogo.EstablecerCarga(this, true);
            Tuple<int, int> Info = A_Scrapper.ActualizarEstudiantesAsignatura(CodAsignatura, CodDocente, true);
            int matriculados = Info.Item1;
            int desmatriculados = Info.Item2;
            A_Dialogo.EstablecerCarga(this, false);
            A_Dialogo.DialogoInformacion("La actualización ha terminado..." + Environment.NewLine +
                                         "Nuevos estudiantes matriculados: " + matriculados + Environment.NewLine +
                                         "Estudiantes desmatriculados: " + desmatriculados + Environment.NewLine);
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Estudiantes
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                string CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();

                using (P_TablaEstudiantesAsignatura Estudiantes = new P_TablaEstudiantesAsignatura(CodAsignatura))
                {
                    Estudiantes.ShowDialog();
                    Estudiantes.Dispose();
                }
            }

            // Actualizar
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                A_Dialogo.DialogoCargando(ActualizarEstudiantes, "Espere a que se actualice los estudiantes de la asignatura seleccionada");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }
    }
}
