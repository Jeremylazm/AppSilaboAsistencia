using CapaEntidades;
using CapaNegocios;
using System;
using System.Data;
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
            else MostrarTodasAsignaturas();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[3].Visible = false;

            dgvDatos.Columns[0].HeaderText = "Código";
            dgvDatos.Columns[0].MinimumWidth = 95;
            dgvDatos.Columns[0].Width = 95;
            dgvDatos.Columns[1].HeaderText = "Asignatura";
            dgvDatos.Columns[2].HeaderText = "Escuela Profesional";

            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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

            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvDatos.Columns["CodAsignatura"].HeaderText = "Cod. Asignatura";
            dgvDatos.Columns["NombreAsignatura"].HeaderText = "Asignatura";
            dgvDatos.Columns["EscuelaProfesional"].HeaderText = "Escuela Profesional";
            dgvDatos.Columns["EscuelaProfesional"].DisplayIndex = 7;
            dgvDatos.Columns["CodDocente"].HeaderText = "Cod. Docente";
        }

        private void MostrarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.MostrarEstudiantesMatriculados(CodSemestre, "IN");

            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvDatos.Columns["CodEstudiante"].HeaderText = "Código";
            dgvDatos.Columns["APaterno"].HeaderText = "A. Paterno";
            dgvDatos.Columns["AMaterno"].HeaderText = "A. Materno";
            dgvDatos.Columns["Nombre"].HeaderText = "Nombre (s)";

            dgvDatos.Columns["CodEstudiante"].Width = 90;
        }

        public void BuscarAsignaturas()
        {
            if (AccesoReporte == "Docente")
            {
                dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, CodDocente, txtBuscar.Text);

                dgvDatos.Columns[0].HeaderText = "Código";
                dgvDatos.Columns[0].MinimumWidth = 95;
                dgvDatos.Columns[0].Width = 95;
                dgvDatos.Columns[1].HeaderText = "Asignatura";
                dgvDatos.Columns[2].HeaderText = "Escuela Profesional";

                dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                foreach (DataGridViewColumn Columna in dgvDatos.Columns)
                {
                    Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else if (AccesoReporte == "Director de Escuela")
            {
                if (CriterioSeleccion == "Por Fechas")
                {
                    dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(CodSemestre, CodDepartamentoA, txtBuscar.Text);

                    dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewColumn Columna in dgvDatos.Columns)
                    {
                        Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    dgvDatos.Columns["CodAsignatura"].HeaderText = "Cod. Asignatura";
                    dgvDatos.Columns["NombreAsignatura"].HeaderText = "Asignatura";
                    dgvDatos.Columns["EscuelaProfesional"].HeaderText = "Escuela Profesional";
                    dgvDatos.Columns["EscuelaProfesional"].DisplayIndex = 7;
                    dgvDatos.Columns["CodDocente"].HeaderText = "Cod. Docente";
                }
                else if (CriterioSeleccion == "Por Estudiantes")
                {
                    dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(CodSemestre, CodDepartamentoA, txtBuscar.Text);

                    dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewColumn Columna in dgvDatos.Columns)
                    {
                        Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    dgvDatos.Columns["CodAsignatura"].HeaderText = "Cod. Asignatura";
                    dgvDatos.Columns["NombreAsignatura"].HeaderText = "Asignatura";
                    dgvDatos.Columns["EscuelaProfesional"].HeaderText = "Escuela Profesional";
                    dgvDatos.Columns["EscuelaProfesional"].DisplayIndex = 7;
                    dgvDatos.Columns["CodDocente"].HeaderText = "Cod. Docente";
                }

                else if (CriterioSeleccion == "Por Asignaturas")
                {
                    dgvDatos.DataSource = N_Matricula.BuscarEstudiantesMatriculados(CodSemestre, CodDepartamentoA, txtBuscar.Text);

                    dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewColumn Columna in dgvDatos.Columns)
                    {
                        Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    dgvDatos.Columns["CodEstudiante"].HeaderText = "Código";
                    dgvDatos.Columns["CodEstudiante"].Width = 100;
                    dgvDatos.Columns["APaterno"].HeaderText = "A. Paterno";
                    dgvDatos.Columns["AMaterno"].HeaderText = "A. Materno";
                    dgvDatos.Columns["Nombre"].HeaderText = "Nombre (s)";
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
                P_ReporteDocente DatosAsignatura = Owner as P_ReporteDocente;

                string codTemp = DatosAsignatura.txtCodigo.Text;

                DatosAsignatura.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                DatosAsignatura.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                DatosAsignatura.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();

                Console.WriteLine(codTemp);
                Console.WriteLine(DatosAsignatura.txtCodigo.Text);

                if (codTemp != DatosAsignatura.txtCodigo.Text && DatosAsignatura.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
                {
                    DatosAsignatura.CriterioSeleccionAsistenciaEstudiantes();
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (AccesoReporte == "Director de Escuela")
            {
                P_ReporteDirector Datos = Owner as P_ReporteDirector;

                if (CriterioSeleccion == "Por Fechas")
                {
                    string codTemp = Datos.txtCodigo.Text;

                    Datos.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    Datos.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    Datos.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                    Datos.CodDocenteReporte = dgvDatos.CurrentRow.Cells[4].Value.ToString();
                    Datos.NombreDocente = dgvDatos.CurrentRow.Cells[5].Value.ToString();

                    if (codTemp != Datos.txtCodigo.Text && Datos.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes")) Datos.CriterioSeleccionAsistenciaEstudiantes();
                }

                if (CriterioSeleccion == "Por Estudiantes")
                {
                    string codTemp = Datos.txtCodigo.Text;

                    Datos.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    Datos.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    Datos.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                    Datos.CodDocenteReporte = dgvDatos.CurrentRow.Cells[4].Value.ToString();
                    Datos.NombreDocente = dgvDatos.CurrentRow.Cells[5].Value.ToString();

                    if (codTemp != Datos.txtCodigo.Text && Datos.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes")) Datos.CriterioSeleccionAsistenciaEstudiantes();
                }
                else if (CriterioSeleccion == "Por Asignaturas")
                {
                    string codTemp = Datos.txtCodEstudiante.Text;

                    Datos.txtCodEstudiante.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    Datos.txtEstudiante.Text = dgvDatos.CurrentRow.Cells[3].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[1].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[2].Value.ToString();

                    if (codTemp != Datos.txtCodEstudiante.Text && Datos.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes")) Datos.CriterioSeleccionAsistenciaEstudiantes();
                }    
            }

            Close();
        }

        private void dgvDatos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) dgvDatos.Cursor = Cursors.Hand;
            else dgvDatos.Cursor = Cursors.Default;
        }

        private void P_SeleccionadoAsignaturaAsignada_Load(object sender, EventArgs e)
        {
            dgvDatos.CellMouseEnter += new DataGridViewCellEventHandler(dgvDatos_CellMouseEnter);

            dgvDatos.ClearSelection();
        }
    }
}
