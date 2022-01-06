using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly string CodDepartamentoA = "IF";

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

            DataTable Asignaturas = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, CodDocente);
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

            //
            dpFechaInicial.Value = new DateTime(2021, 10, 18);
            dpFechaFinal.Value = new DateTime(2022, 01, 10);
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

                // Tipo de reporte: Asistencia estudiantes
                // Criterio de selección: Por Estudiantes
                //MessageBox.Show(pnReporte.Controls.Count.ToString());
                //MessageBox.Show(pnReporte.Controls[0].Controls.Count.ToString());
                Control.ControlCollection main = pnReporte.Controls[0].Controls;
                //MessageBox.Show(a[0].Name);

                /*Console.WriteLine(main[7].Name);
                Console.WriteLine(main[7].Controls.Count.ToString());*/
                //a[7].Text = "HOLA";
                // 7: pnCampos para la Descripción
                /*for (int i = 0; i < main[7].Controls.Count; i++)
                {
                    Console.WriteLine(main[7].Controls[i].Name + " -> " + i);
                }*/
                Console.WriteLine("--------");

                DataTable datosDocente = N_Docente.BuscarDocente(CodDepartamentoA, CodDocente);
                string nombreDocente = datosDocente.Rows[0]["Nombre"].ToString() + " " + datosDocente.Rows[0]["APaterno"].ToString() + " " + datosDocente.Rows[0]["AMaterno"].ToString();

                // Descripción
                Control.ControlCollection descripcion = main["pnCampos"].Controls;

                descripcion["lblCampo1"].Text = "Semestre";
                descripcion["txtCampo1"].Text = CodSemestre;

                descripcion["lblCampo2"].Text = "Escuela Profesional";
                descripcion["txtCampo2"].Text = txtEscuelaP.Text;

                descripcion["lblCampo3"].Text = "Asignatura";
                descripcion["txtCampo3"].Text = txtNombre.Text;

                descripcion["lblCampo4"].Text = "Cód. Asignatura";
                descripcion["txtCampo4"].Text = txtCodigo.Text;

                descripcion["lblCampo5"].Text = "Docente";
                descripcion["txtCampo5"].Text = nombreDocente;

                descripcion["lblCampo6"].Text = "Cod. Docente";
                descripcion["txtCampo6"].Text = CodDocente;

                // Resultados
                Control.ControlCollection resultados = main["pnResultados"].Controls;

                Bunifu.UI.WinForms.BunifuDataGridView dgvResultados = (resultados["dgvResultados"] as Bunifu.UI.WinForms.BunifuDataGridView);

                dgvResultados.DataSource = N_AsistenciaEstudiante.AsistenciaEstudiantesPorEstudiante(CodSemestre, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("eS-ES")));
                dgvResultados.Columns[1].Visible = false;
                dgvResultados.Columns[0].DisplayIndex = 7;

                // Cuadro resumen
                /*(main["gbxCuadroResumen"] as Bunifu.UI.WinForms.BunifuLabel).Visible = false;
                Bunifu.UI.WinForms.BunifuPanel cuadroResumen = main["pnResumen"] as Bunifu.UI.WinForms.BunifuPanel;*/
                /*main.Remove(main["gbxCuadroResumen"]);
               
                main.Remove(main["pnResumen"]);*/


                /*for (int i = 0; i < resumen.Count; i++)
                {
                    Console.WriteLine(resumen[i].Name + " -> " + i);
                }

                Bunifu.UI.WinForms.BunifuDataGridView dgvResumen = (resultados["dgvResumen"] as Bunifu.UI.WinForms.BunifuDataGridView);*/
            }
            else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fecha"))
            {
                lblFechaInicial.Text = "Fecha";

                lblFechaFinal.Visible = false;
                dpFechaFinal.Visible = false;

                // Tipo de reporte: Asistencia estudiantes
                // Criterio de selección: Por Fecha
            }
        }
    }
}
