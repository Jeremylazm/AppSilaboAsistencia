using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_SeleccionadoAsignatura : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        private readonly string CodAsignatura;

        private readonly string AccesoReporte = "";
        private readonly string CriterioSeleccion = "";
        public P_SeleccionadoAsignatura(string pCodAsignatura, string AccesoReporte, string CriterioSeleccion)
        {
            this.CriterioSeleccion = CriterioSeleccion;
            this.AccesoReporte = AccesoReporte;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            CodAsignatura = pCodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            MostrarTodasAsignaturas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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

        public void BuscarAsignaturas()
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            P_ReporteJefe DatosAsignatura = Owner as P_ReporteJefe;

            string codTemp = DatosAsignatura.txtCodigo.Text;

            DatosAsignatura.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
            DatosAsignatura.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
            DatosAsignatura.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();

            Console.WriteLine(codTemp);
            Console.WriteLine(DatosAsignatura.txtCodigo.Text);

            if (codTemp != DatosAsignatura.txtCodigo.Text)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void P_SeleccionadoAsignatura_Load(object sender, EventArgs e)
        {
            dgvDatos.CellMouseEnter += new DataGridViewCellEventHandler(dgvDatos_CellMouseEnter);
            dgvDatos.ClearSelection();
        }

        private void dgvDatos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) dgvDatos.Cursor = Cursors.Hand;
            else dgvDatos.Cursor = Cursors.Default;
        }
    }
}
