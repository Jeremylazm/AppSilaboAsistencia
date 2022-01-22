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
    public partial class P_SeleccionadoDocente : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        private readonly string CodAsignatura;

        private readonly string AccesoReporte = "";
        private readonly string CriterioSeleccion = "";
        public P_SeleccionadoDocente(string pCodAsignatura, string AccesoReporte, string CriterioSeleccion)
        {
            this.CriterioSeleccion = CriterioSeleccion;
            this.AccesoReporte = AccesoReporte;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            CodAsignatura = pCodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            if (AccesoReporte == "Jefe de Departamento")
            {
                if (CriterioSeleccion == "Por Fechas") MostrarTodosLosDocentes();
                if (CriterioSeleccion == "Por Asignaturas") MostrarTodosLosDocentes();
            }
        }
        private void AccionesTabla()
        {
            dgvDatos.Columns[0].Visible = false;
            dgvDatos.Columns[1].Visible = false;

            dgvDatos.Columns[2].HeaderText = "Código";
            dgvDatos.Columns[2].MinimumWidth = 95;
            dgvDatos.Columns[2].Width = 95;
            dgvDatos.Columns[5].HeaderText = "Nombre";
            dgvDatos.Columns[7].Visible = false;
            dgvDatos.Columns[8].Visible = false;
            dgvDatos.Columns[9].Visible = false;
            dgvDatos.Columns[10].Visible = false;
            dgvDatos.Columns[11].Visible = false;

        }
        public void MostrarTodosLosDocentes()
        {
            dgvDatos.DataSource = N_Docente.MostrarDocentesDepartamento(CodDepartamentoA);
            AccionesTabla();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void BuscarDocente()
        {
            dgvDatos.DataSource = N_Docente.BuscarDocente(CodDepartamentoA, txtBuscar.Text);

            if (AccesoReporte == "Jefe de Departamento")
            {
                dgvDatos.DataSource = N_Docente.BuscarDocentes(CodDepartamentoA, txtBuscar.Text);
            }
            dgvDatos.ClearSelection();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarDocente();
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AccesoReporte == "Jefe de Departamento")
            {
                P_ReporteJefe DatosDocente = Owner as P_ReporteJefe;

                DatosDocente.txtCodDocente.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                DatosDocente.txtDocente.Text = dgvDatos.CurrentRow.Cells[5].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[3].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[4].Value.ToString();
                DatosDocente.CriterioSeleccionAsistenciaDocentes();
            }
            Close();
        }

        private void P_SeleccionadoDocente_Load(object sender, EventArgs e)
        {
            dgvDatos.ClearSelection();
        }
    }
}
