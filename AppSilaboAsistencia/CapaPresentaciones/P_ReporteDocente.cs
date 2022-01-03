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
using ControlesPerzonalizados;

namespace CapaPresentaciones
{
    public partial class P_ReporteDocente : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodEscuelaP = "IF";

        public P_ReporteDocente()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();
            LLenarCampos();
        }

        private void LLenarCampos()
        {
            cxtTipoReporte.SelectedIndex = 0;
            cxtCriterioSeleccion.SelectedIndex = 0;

            DataTable Asignaturas = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodEscuelaP, CodDocente);
            txtCodigo.Text = Asignaturas.Rows[0].ItemArray[0].ToString();
            txtNombre.Text = Asignaturas.Rows[0].ItemArray[1].ToString();
            txtEscuelaP.Text = Asignaturas.Rows[0].ItemArray[2].ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void P_ReporteDocente_Load(object sender, EventArgs e)
        {
            pnReporte.Parent = pnPadre;
            pnReporte.Location = new Point(0, 0);
            pnReporte.Width = pnPadre.ClientSize.Width + SystemInformation.VerticalScrollBarWidth;
            pnReporte.Height = pnPadre.ClientSize.Height + SystemInformation.HorizontalScrollBarHeight;

            C_ReporteA Reporte = new C_ReporteA
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            pnReporte.Controls.Add(Reporte);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            P_SeleccionadoAsignaturaAsignada Asignaturas = new P_SeleccionadoAsignaturaAsignada(txtCodigo.Text);
            AddOwnedForm(Asignaturas);
            Asignaturas.ShowDialog();
        }

        private void cxtTipoReporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                lblCriterioSeleccion.Visible = true;
                cxtCriterioSeleccion.Visible = true;

                lblFechaInicial.Visible = true;
                dpFechaInicial.Visible = true;

                if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
                {
                    lblFechaInicial.Text = "Fecha Inicial";

                    lblFechaFinal.Visible = true;
                    dpFechaFinal.Visible = true;
                }
                else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fecha"))
                {
                    lblFechaInicial.Text = "Fecha";

                    lblFechaFinal.Visible = false;
                    dpFechaFinal.Visible = false;
                }
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                lblCriterioSeleccion.Visible = false;
                cxtCriterioSeleccion.Visible = false;

                lblFechaInicial.Visible = false;
                dpFechaInicial.Visible = false;

                lblFechaFinal.Visible = false;
                dpFechaFinal.Visible = false;
            }
        }

        private void cxtCriterioSeleccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
            {
                lblFechaInicial.Text = "Fecha Inicial";

                lblFechaFinal.Visible = true;
                dpFechaFinal.Visible = true;
            }
            else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fecha"))
            {
                lblFechaInicial.Text = "Fecha";

                lblFechaFinal.Visible = false;
                dpFechaFinal.Visible = false;
            }
        }
    }
}
