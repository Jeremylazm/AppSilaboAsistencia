using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using ClosedXML.Excel;
using ControlesPerzonalizados;

namespace CapaPresentaciones
{
    public partial class P_ReporteJefe : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        C_Reporte Reportes = new C_Reporte();
        string nombreDocente;
        public P_ReporteJefe()
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

            DataTable Estudiantes = N_Matricula.MostrarEstudiantesMatriculados(CodSemestre, "IN");
            // Campos Docente
            DataTable Campos = N_Catalogo.MostrarCatalogo(CodSemestre, CodDepartamentoA);

            txtCodigo.Text = Campos.Rows[0].ItemArray[0].ToString();
            txtNombre.Text = Campos.Rows[0].ItemArray[1].ToString();
            txtEscuelaP.Text = Campos.Rows[0].ItemArray[2].ToString();
            this.CodDocenteReporte = Campos.Rows[0].ItemArray[4].ToString();
            this.nombreDocente = Campos.Rows[0].ItemArray[5].ToString();
        }
        public string CodDocenteReporte = "";
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void P_ReporteJefe_Load(object sender, EventArgs e)
        {
            /*dpFechaInicial.MaxDate = DateTime.Now;
            dpFechaFinal.MaxDate = DateTime.Now;*/
            dpFechaFinal.MaxDate = new DateTime(2022, 03, 01);
            dpFechaFinal.MinDate = new DateTime(2021, 09, 01);
            dpFechaInicial.MaxDate = new DateTime(2022, 03, 01);
            dpFechaInicial.MinDate = new DateTime(2021, 09, 01);

            //
            dpFechaInicial.Value = new DateTime(2021, 10, 18);
            dpFechaFinal.Value = new DateTime(2021, 11, 05);

            pnReporte.Parent = pnPadre;
            pnReporte.Location = new Point(0, 0);
            pnReporte.Width = pnPadre.ClientSize.Width + SystemInformation.VerticalScrollBarWidth;
            pnReporte.Height = pnPadre.ClientSize.Height + SystemInformation.HorizontalScrollBarHeight;

            DataTable resultadoss = N_Docente.MostrarDocentesDepartamento(CodDepartamentoA);
            txtCodDocente.Text = resultadoss.Rows[0]["CodDocente"].ToString();
            txtDocente.Text = resultadoss.Rows[0]["Nombre"].ToString() +" "+ resultadoss.Rows[0]["APaterno"]+" "+ resultadoss.Rows[0]["AMaterno"];
            DataTable NombreDepar = N_DepartamentoAcademico.BuscarNombreDepartamento(CodDepartamentoA);
            string NomDepartamento= NombreDepar.Rows[0]["Nombre"].ToString();
            //DataTable datosDocente = N_Docente.BuscarDocente(CodDepartamentoA, CodDocente);
            //nombreDocente = datosDocente.Rows[0]["Nombre"].ToString() + " " + datosDocente.Rows[0]["APaterno"].ToString() + " " + datosDocente.Rows[0]["AMaterno"].ToString();

            string Titulo = "REPORTE DE ASISTENCIA DOCENTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Departamento Académico", "Cod. Docente", "Docente" };
            string[] Valores = { CodSemestre,NomDepartamento, txtCodDocente.Text, txtDocente.Text };

            DataTable resultados = N_AsistenciaDocentePorAsignatura.AsistenciaAsignaturasDocente(CodSemestre, txtCodDocente.Text,dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
            
            C_Reporte Reporte = new C_Reporte(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString(), txtCodDocente.Text, "Jefe de Departamento")
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right

            };

            Reportes = Reporte;
            Responsivo();
            pnReporte.Controls.Add(Reporte);
            ActiveControl = Reporte.btnGrafico1;
        }

        private void Responsivo()
        {
            int AnchoTotal = 0;
            int Filas = 1;

            foreach (C_Campo cpControl in Reportes.pnSubcampos.Controls)
            {
                if ((AnchoTotal + cpControl.Width + 6) > Reportes.pnSubcampos.Width)
                {
                    Filas++;
                    AnchoTotal = cpControl.Width + 6;
                }
                else
                {
                    AnchoTotal += cpControl.Width + 6;
                }
            }

            Reportes.Cuadricula.RowStyles[0].Height = Filas * 92 + 51;
            Reportes.Height = (int)Reportes.Cuadricula.RowStyles[0].Height + (int)Reportes.Cuadricula.RowStyles[1].Height + 73;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            P_SeleccionadoDocente docente = new P_SeleccionadoDocente(txtCodDocente.Text,"Jefe de Departamento", cxtCriterioSeleccion.SelectedItem.ToString());
            AddOwnedForm(docente);
            docente.ShowDialog();
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Docentes"))
            {
                if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fechas"))
                    fnReporte13();
                else
                    fnReporte10();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignatura"))
            {
                fnReporte5();
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Docentes"))
            {
                //if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fechas"))
                    //fnReporte14();
                //else
                    //fnReporte12();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignatura"))
            {
                fnReporte9();
            }
        }

        private void cxtTipoReporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Docentes"))
            {
                lblCriterioSeleccion.Visible = true;
                cxtCriterioSeleccion.Visible = true;

                lblFechaInicial.Visible = true;
                dpFechaInicial.Visible = true;

                lblFechaFinal.Visible = true;
                dpFechaFinal.Visible = true;

                btnGeneral.Visible = true;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);

                CriterioSeleccionAsistenciaDocentes();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                lblCriterioSeleccion.Visible = false;
                cxtCriterioSeleccion.Visible = false;

                lblFechaInicial.Visible = false;
                dpFechaInicial.Visible = false;

                lblFechaFinal.Visible = false;
                dpFechaFinal.Visible = false;

                btnGeneral.Visible = true;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);

                fnReporte5();
            }
        }

        private void cxtCriterioSeleccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CriterioSeleccionAsistenciaDocentes();
        }
        public void CriterioSeleccionAsistenciaDocentes()
        {
            if (cxtCriterioSeleccion.SelectedItem.Equals("Por Asignaturas"))
            {
                fnReporte10();
            }
            else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fechas"))
            {
                fnReporte13();
            }
        }
        private void fnReporte10()
        {
            // Tipo de reporte: Asistencia estudiantes
            // Criterio de selección: Por Fechas
            DataTable NombreDepar = N_DepartamentoAcademico.BuscarNombreDepartamento(CodDepartamentoA);
            string NomDepartamento = NombreDepar.Rows[0]["Nombre"].ToString();
            //DataTable datosDocente = N_Docente.BuscarDocente(CodDepartamentoA, CodDocente);
            //nombreDocente = datosDocente.Rows[0]["Nombre"].ToString() + " " + datosDocente.Rows[0]["APaterno"].ToString() + " " + datosDocente.Rows[0]["AMaterno"].ToString();

            string Titulo = "REPORTE DE ASISTENCIA DOCENTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Departamento Académico", "Cod. Docente", "Docente" };
            string[] Valores = { CodSemestre, NomDepartamento, txtCodDocente.Text, txtDocente.Text };

            DataTable resultados = N_AsistenciaDocentePorAsignatura.AsistenciaAsignaturasDocente(CodSemestre, txtCodDocente.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
            Reportes.fnReporte10(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString(), txtCodigo.Text);
        }
        private void fnReporte13()
        {
            // Tipo de reporte: Asistencia estudiantes
            // Criterio de selección: Por Estudiantes
            DataTable NombreDepar = N_DepartamentoAcademico.BuscarNombreDepartamento(CodDepartamentoA);
            string NomDepartamento = NombreDepar.Rows[0]["Nombre"].ToString();

            string Titulo = "REPORTE DE ASISTENCIA DOCENTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Departamento Académico", "Cod. Docente", "Docente" };
            string[] Valores = { CodSemestre, NomDepartamento, txtCodDocente.Text, txtDocente.Text };
            DataTable resultados = N_AsistenciaDiariaDocente.AsistenciasDocente(CodSemestre, txtCodDocente.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
            Reportes.fnReporte13(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString(), txtCodigo.Text);
        }
        private void dpFechaInicial_CloseUp(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Docentes"))
            {
                CriterioSeleccionAsistenciaDocentes();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                fnReporte5();
            }
        }

        private void dpFechaFinal_CloseUp(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Docentes"))
            {
                CriterioSeleccionAsistenciaDocentes();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                fnReporte5();
            }
        }

        //public string CodDocenteReporte = "";

        private void fnReporte5()
        {
            pnReporte.AutoScrollPosition = new Point(0, 0);
            // Tipo de reporte: Avance Asignatura
            // Criterio de selección: Por Docente
            string Titulo = "REPORTE DE AVANCE - " + txtCodigo.Text + Environment.NewLine + "SEMESTRE " + CodSemestre;
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Cod. Asignatura", "Asignatura", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocenteReporte, nombreDocente, txtCodigo.Text, txtNombre.Text, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaDocentePorAsignatura.AvanceAsignatura(CodSemestre, CodDocenteReporte, txtCodigo.Text);
            DataTable plansesion = N_Catalogo.RecuperarPlanDeSesionAsignatura(CodSemestre, txtCodigo.Text, CodDocenteReporte);

            int Total = 0;

            if (plansesion.Rows.Count >= 1)
            {
                DataRow Fila = plansesion.Rows[0];

                byte[] archivo = Fila["PlanSesiones"] as byte[];

                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "/temp/";
                string fullFilePath = folder + "temp.xlsx";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (File.Exists(fullFilePath))
                {
                    File.Delete(fullFilePath);
                }

                File.WriteAllBytes(fullFilePath, archivo);
                XLWorkbook wb = new XLWorkbook(fullFilePath);

                DataTable ResultadosFinales = new DataTable();
                ResultadosFinales.Columns.Add("Sesión", typeof(int));
                ResultadosFinales.Columns.Add("NombreTema", typeof(string));
                ResultadosFinales.Columns.Add("Fecha", typeof(string));
                ResultadosFinales.Columns.Add("Estado", typeof(string));

                int[] TemasAvanzados = new int[resultados.Rows.Count];

                for (int i = 0; i < resultados.Rows.Count; i++)
                {
                    TemasAvanzados[i] = Convert.ToInt32(resultados.Rows[i]["Sesión"].ToString());
                    ResultadosFinales.Rows.Add(Convert.ToInt32(resultados.Rows[i]["Sesión"].ToString()), resultados.Rows[i]["NombreTema"].ToString(), resultados.Rows[i]["Fecha"].ToString(), "HECHO");
                }

                int Contador = 9;
                for (int i = 9; i <= 61; i++)
                {
                    if (wb.Worksheet(1).Cell("E" + Convert.ToString(i)).Value.ToString() != "")
                    {
                        if (Array.Exists(TemasAvanzados, x => x == Convert.ToInt32(wb.Worksheet(1).Cell("B" + Convert.ToString(i)).Value.ToString())))
                        {

                        }
                        else
                            ResultadosFinales.Rows.Add(Contador - 8, "Tema" + Convert.ToString(Contador - 8), "", "FALTA");
                        Total = Total + 1;
                        Contador = Contador + 1;
                    }
                }

                int Hechos = resultados.Rows.Count;
                int Faltan = Total - Hechos;
                Reportes.fnReporte5(Titulo, Titulos, Valores, ResultadosFinales, txtCodigo.Text, Hechos, Faltan);
            }
            else
                Ayudas.A_Dialogo.DialogoError("No hay Plan de Sesiones");
        }

        private void fnReporte9()
        {
            pnReporte.AutoScrollPosition = new Point(0, 0);

            string Titulo = "REPORTE DE AVANCE GENERAL" + Environment.NewLine + "SEMESTRE " + CodSemestre;
            string[] Titulos = { "Semestre" };
            string[] Valores = { CodSemestre };

            DataTable resultados = N_AsistenciaDocentePorAsignatura.AvanceAsignaturasDpto(CodSemestre, CodDepartamentoA);

            DataTable ResultadosFinales = new DataTable();
            ResultadosFinales.Columns.Add("CodAsignatura", typeof(string));
            ResultadosFinales.Columns.Add("NombreAsignatura", typeof(string));
            ResultadosFinales.Columns.Add("Docente", typeof(string));
            ResultadosFinales.Columns.Add("TemasAvanzados", typeof(string));
            ResultadosFinales.Columns.Add("TemasFaltantes", typeof(string));

            DataTable ResultadosResumen = new DataTable();
            ResultadosResumen.Columns.Add("CodAsignatura", typeof(string));
            ResultadosResumen.Columns.Add("NombreAsignatura", typeof(string));
            ResultadosResumen.Columns.Add("Docente", typeof(string));
            ResultadosResumen.Columns.Add("TemasAvanzados", typeof(int));
            ResultadosResumen.Columns.Add("TemasFaltantes", typeof(int));

            int Créditos = 0;
            int TemasTotales = 0;
            float PorcentajeAvanzados = 0;

            for (int i = 0; i < resultados.Rows.Count; i++)
            {
                DataTable TablaCreditos = N_Asignatura.BuscarAsignatura(CodDepartamentoA, resultados.Rows[i]["CodAsignatura"].ToString().Substring(0, 5));
                if (TablaCreditos.Rows.Count != 0)
                {
                    Créditos = Convert.ToInt32(TablaCreditos.Rows[0]["Creditos"].ToString());
                }
                if (Créditos == 4)
                {
                    TemasTotales = 51;
                    PorcentajeAvanzados = 100 * Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()) / TemasTotales;
                    ResultadosFinales.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), Convert.ToString(PorcentajeAvanzados) + "%", Convert.ToString(100 - PorcentajeAvanzados) + "%");
                    ResultadosResumen.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()), TemasTotales - Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()));
                }
                else
                {
                    TemasTotales = 34;
                    PorcentajeAvanzados = 100 * Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()) / TemasTotales;
                    ResultadosFinales.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), Convert.ToString(PorcentajeAvanzados) + "%", Convert.ToString(100 - PorcentajeAvanzados) + "%");
                    ResultadosResumen.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()), TemasTotales - Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()));
                }
            }

            Reportes.fnReporte9(Titulo, Titulos, Valores, ResultadosFinales, ResultadosResumen);
        }
    }
}
