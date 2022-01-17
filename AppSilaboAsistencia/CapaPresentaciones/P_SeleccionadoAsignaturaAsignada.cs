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
    public partial class P_SeleccionadoAsignaturaAsignada : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        private readonly string CodAsignatura;

        private readonly string AccesoReporte = "";
        private readonly string CriterioSeleccion = "";

        public P_SeleccionadoAsignaturaAsignada(string pCodAsignatura, string AccesoReporte, string CriterioSeleccion)
        {
            this.CriterioSeleccion = CriterioSeleccion;
            this.AccesoReporte = AccesoReporte;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            CodAsignatura = pCodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);

            if (AccesoReporte == "Docente") MostrarAsignaturas();
            else if (AccesoReporte == "Director de Escuela")
            {
                if (CriterioSeleccion == "Por Fechas") MostrarTodasAsignaturas();
                if (CriterioSeleccion == "Por Estudiantes") MostrarTodasAsignaturas();
                if (CriterioSeleccion == "Por Asignaturas") MostrarEstudiantes();
            }
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[3].Visible = false;

            dgvDatos.Columns[0].HeaderText = "Código";
            dgvDatos.Columns[0].MinimumWidth = 95;
            dgvDatos.Columns[0].Width = 95;
            dgvDatos.Columns[1].HeaderText = "Nombre";
            dgvDatos.Columns[2].HeaderText = "Escuela Profesional";
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, CodDocente);
            AccionesTabla();
        }

        private void MostrarTodasAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.MostrarCatalogo(CodSemestre, CodDepartamentoA);

            dgvDatos.Columns[3].Visible = false;
            dgvDatos.Columns[6].Visible = false;
            dgvDatos.Columns[7].Visible = false;
        }

        private void MostrarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.MostrarEstudiantesMatriculados(CodSemestre, "IN");
        }

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, CodDocente, txtBuscar.Text);

            if (AccesoReporte == "Docente")
            {
                dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, CodDocente, txtBuscar.Text);
            }
            else if (AccesoReporte == "Director de Escuela")
            {
                if (CriterioSeleccion == "Por Fechas")
                {
                    // MostrarTodasAsignaturas();
                    dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(CodSemestre, CodDepartamentoA, txtBuscar.Text);
                }
                else if (CriterioSeleccion == "Por Estudiantes")
                {
                    // MostrarTodasAsignaturas();
                    dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(CodSemestre, CodDepartamentoA, txtBuscar.Text);
                }

                else if (CriterioSeleccion == "Por Asignaturas")
                {
                    //MostrarEstudiantes();
                    //dgvDatos.DataSource = N_Matricula.Bus
                }
            }
            dgvDatos.ClearSelection();
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (AccesoReporte == "Docente")
            {
                P_ReporteDocente DatosAsingatura = Owner as P_ReporteDocente;
                string codTemp = DatosAsingatura.txtCodigo.Text;

                DatosAsingatura.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                DatosAsingatura.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                DatosAsingatura.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();

                if (codTemp != DatosAsingatura.txtCodigo.Text && DatosAsingatura.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
                {
                    DatosAsingatura.CriterioSeleccionAsistenciaEstudiantes();
                }
            }
            else if (AccesoReporte == "Director de Escuela")
            {
                P_ReporteDirector Datos = Owner as P_ReporteDirector;

                // Por Fechas -> Todas las asignaturas
                // Por Estudiantes -> Todos las asignaturas
                // Por Asignaturas -> Todos los estudiantes

                if (CriterioSeleccion == "Por Fechas")
                {
                    string codTemp = Datos.txtCodigo.Text;

                    Datos.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    Datos.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    Datos.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                    Datos.CodDocenteReporte = dgvDatos.CurrentRow.Cells[4].Value.ToString();
                    Datos.nombreDocente = dgvDatos.CurrentRow.Cells[5].Value.ToString();

                    if (codTemp != Datos.txtCodigo.Text && Datos.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
                    {
                        Datos.CriterioSeleccionAsistenciaEstudiantes();
                    }
                }

                if (CriterioSeleccion == "Por Estudiantes")
                {
                    string codTemp = Datos.txtCodigo.Text;

                    Datos.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    Datos.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    Datos.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                    Datos.CodDocenteReporte = dgvDatos.CurrentRow.Cells[4].Value.ToString();
                    Datos.nombreDocente = dgvDatos.CurrentRow.Cells[5].Value.ToString();

                    if (codTemp != Datos.txtCodigo.Text && Datos.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
                    {
                        Datos.CriterioSeleccionAsistenciaEstudiantes();
                    }
                }
                else if (CriterioSeleccion == "Por Asignaturas")
                {
                    string codTemp = Datos.txtCodEstudiante.Text;

                    Datos.txtCodEstudiante.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    Datos.txtEstudiante.Text = dgvDatos.CurrentRow.Cells[3].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[1].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[2].Value.ToString();

                    if (codTemp != Datos.txtCodEstudiante.Text && Datos.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
                    {
                        Datos.CriterioSeleccionAsistenciaEstudiantes();
                    }
                }    
            }

            Close();
        }

        private void P_SeleccionadoAsignaturaAsignada_Load(object sender, EventArgs e)
        {
            dgvDatos.ClearSelection();
        }
    }
}
