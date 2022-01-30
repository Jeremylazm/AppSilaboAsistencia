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

        private readonly string AccesoReporte = "";
        public P_SeleccionadoAsignatura(string AccesoReporte)
        {
            this.AccesoReporte = AccesoReporte;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);

            if (AccesoReporte == "Docente") MostrarTodasAsignaturasDocente();
            else MostrarTodasAsignaturasJefe_Director();
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

        private void MostrarTodasAsignaturasDocente()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, CodDocente);

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

        private void MostrarTodasAsignaturasJefe_Director()
        {
            dgvDatos.DataSource = N_Catalogo.MostrarCatalogo(CodSemestre, CodDepartamentoA);

            dgvDatos.Columns[0].HeaderText = "Código";
            dgvDatos.Columns[0].MinimumWidth = 95;
            dgvDatos.Columns[0].Width = 95;
            dgvDatos.Columns[1].HeaderText = "Asignatura";
            dgvDatos.Columns[2].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[4].Visible = false;
            dgvDatos.Columns[5].Visible = false;
            dgvDatos.Columns[6].Visible = false;
            dgvDatos.Columns[7].Visible = false;

            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void BuscarAsignaturasDocente()
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

        public void BuscarAsignaturasJefe_Director()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(CodSemestre, CodDepartamentoA, txtBuscar.Text);

            dgvDatos.Columns[0].HeaderText = "Código";
            dgvDatos.Columns[0].MinimumWidth = 95;
            dgvDatos.Columns[0].Width = 95;
            dgvDatos.Columns[1].HeaderText = "Asignatura";
            dgvDatos.Columns[2].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[4].Visible = false;
            dgvDatos.Columns[5].Visible = false;
            dgvDatos.Columns[6].Visible = false;
            dgvDatos.Columns[7].Visible = false;

            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (AccesoReporte == "Docente") BuscarAsignaturasDocente();
            else BuscarAsignaturasJefe_Director();
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

                if (codTemp != DatosAsignatura.txtCodigo.Text)
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (AccesoReporte == "Director de Escuela")
            {
                P_ReporteDirector DatosAsignatura = Owner as P_ReporteDirector;

                string codTemp = DatosAsignatura.txtCodigo.Text;

                DatosAsignatura.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                DatosAsignatura.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                DatosAsignatura.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                DatosAsignatura.CodDocenteReporte = dgvDatos.CurrentRow.Cells[4].Value.ToString();
                DatosAsignatura.NombreDocente = dgvDatos.CurrentRow.Cells[5].Value.ToString();

                if (codTemp != DatosAsignatura.txtCodigo.Text)
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else
            {
                P_ReporteJefe DatosAsignatura = Owner as P_ReporteJefe;

                string codTemp = DatosAsignatura.txtCodigo.Text;

                DatosAsignatura.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                DatosAsignatura.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                DatosAsignatura.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                DatosAsignatura.CodDocenteReporte = dgvDatos.CurrentRow.Cells[4].Value.ToString();
                DatosAsignatura.NombreDocente = dgvDatos.CurrentRow.Cells[5].Value.ToString();

                if (codTemp != DatosAsignatura.txtCodigo.Text)
                {
                    this.DialogResult = DialogResult.Yes;
                }
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
