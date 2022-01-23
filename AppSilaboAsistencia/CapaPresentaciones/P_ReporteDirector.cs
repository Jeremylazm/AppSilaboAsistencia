using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using ClosedXML.Excel;
using ControlesPerzonalizados;

namespace CapaPresentaciones
{
    public partial class P_ReporteDirector : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        C_Reporte Reportes = new C_Reporte();

        public string nombreDocente;

        public P_ReporteDirector()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();
            LLenarCampos();

            lblCodEstudiante.Visible = false;
            txtCodEstudiante.Visible = false;
            lnCodEstudiante.Visible = false;
            lblEstudiante.Visible = false;
            txtEstudiante.Visible = false;
            lnEstudiante.Visible = false;

            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            lnCodigo.Visible = true;
            pnCajas.Visible = true;

            btnGeneral.Visible = false;
            btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);
        }

        private void LLenarCampos()
        {
            cxtTipoReporte.SelectedIndex = 0;
            cxtCriterioSeleccion.SelectedIndex = 0;

            DataTable Estudiantes = N_Matricula.MostrarEstudiantesMatriculados(CodSemestre, "IN");
            txtCodEstudiante.Text = Estudiantes.Rows[0].ItemArray[0].ToString();
            txtEstudiante.Text = Estudiantes.Rows[0].ItemArray[3].ToString() + " " + Estudiantes.Rows[0].ItemArray[1].ToString() + " " + Estudiantes.Rows[0].ItemArray[2].ToString();

            // Campos Docente
            DataTable Campos = N_Catalogo.MostrarCatalogo(CodSemestre, CodDepartamentoA);

            txtCodigo.Text = Campos.Rows[0].ItemArray[0].ToString();
            txtNombre.Text = Campos.Rows[0].ItemArray[1].ToString();
            txtEscuelaP.Text = Campos.Rows[0].ItemArray[2].ToString();
            this.CodDocenteReporte = Campos.Rows[0].ItemArray[4].ToString();
            this.nombreDocente = Campos.Rows[0].ItemArray[5].ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void P_ReporteDirector_Load(object sender, EventArgs e)
        {
            /*dpFechaInicial.MaxDate = DateTime.Now;
            dpFechaFinal.MaxDate = DateTime.Now;*/
            dpFechaFinal.MaxDate = new DateTime(2022, 03, 01);
            dpFechaFinal.MinDate = new DateTime(2021, 09, 01);
            dpFechaInicial.MaxDate = new DateTime(2022, 03, 01);
            dpFechaInicial.MinDate = new DateTime(2021, 09, 01);

            //
            dpFechaInicial.Value = new DateTime(2021, 10, 18);
            dpFechaFinal.Value = new DateTime(2021, 12, 01);

            pnReporte.Parent = pnPadre;
            pnReporte.Location = new Point(0, 0);
            pnReporte.Width = pnPadre.ClientSize.Width + SystemInformation.VerticalScrollBarWidth;
            pnReporte.Height = pnPadre.ClientSize.Height + SystemInformation.HorizontalScrollBarHeight;

            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Cod. Asignatura", "Asignatura", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocenteReporte, nombreDocente, txtCodigo.Text, txtNombre.Text, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorFechas(CodSemestre, CodDocenteReporte, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            C_Reporte Reporte = new C_Reporte(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString(), txtCodigo.Text, "Director de Escuela")
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
                else AnchoTotal += cpControl.Width + 6;
            }

            Reportes.Cuadricula.RowStyles[0].Height = Filas * 92 + 51;
            Reportes.Height = (int)Reportes.Cuadricula.RowStyles[0].Height + (int)Reportes.Cuadricula.RowStyles[1].Height + 73;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            P_SeleccionadoAsignaturaAsignada Asignaturas = new P_SeleccionadoAsignaturaAsignada(txtCodigo.Text, "Director de Escuela", cxtCriterioSeleccion.SelectedItem.ToString());
            AddOwnedForm(Asignaturas);
            Asignaturas.ShowDialog();

            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                //if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
                    //fnReporte3(); // es fnReporte(8)
                //else
                    //fnReporte1();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                fnReporte5();
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))  fnReporte9();
            else if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes")) fnReporte7();
        }

        private void cxtTipoReporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                lblCriterioSeleccion.Visible = true;
                cxtCriterioSeleccion.Visible = true;

                lblFechaInicial.Visible = true;
                dpFechaInicial.Visible = true;

                lblFechaFinal.Visible = true;
                dpFechaFinal.Visible = true;

                if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fechas"))
                {
                    lblCodEstudiante.Visible = false;
                    txtCodEstudiante.Visible = false;
                    lnCodEstudiante.Visible = false;
                    lblEstudiante.Visible = false;
                    txtEstudiante.Visible = false;
                    lnEstudiante.Visible = false;

                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;
                    lnCodigo.Visible = true;
                    pnCajas.Visible = true;

                    btnGeneral.Visible = true;
                    btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);
                }
                else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
                {
                    lblCodEstudiante.Visible = true;
                    txtCodEstudiante.Visible = true;
                    lnCodEstudiante.Visible = true;
                    lblEstudiante.Visible = true;
                    txtEstudiante.Visible = true;
                    lnEstudiante.Visible = true;

                    lblCodigo.Visible = false;
                    txtCodigo.Visible = false;
                    lnCodigo.Visible = false;
                    pnCajas.Visible = false;

                    btnGeneral.Visible = false;
                    btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);
                }
                else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Asignaturas"))
                {
                    lblCodEstudiante.Visible = false;
                    txtCodEstudiante.Visible = false;
                    lnCodEstudiante.Visible = false;
                    lblEstudiante.Visible = false;
                    txtEstudiante.Visible = false;
                    lnEstudiante.Visible = false;

                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;
                    lnCodigo.Visible = true;
                    pnCajas.Visible = true;

                    btnGeneral.Visible = true;
                    btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);
                }

                CriterioSeleccionAsistenciaEstudiantes();
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
            CriterioSeleccionAsistenciaEstudiantes();
        }

        public void CriterioSeleccionAsistenciaEstudiantes()
        {
            if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fechas"))
            {
                lblCodEstudiante.Visible = false;
                txtCodEstudiante.Visible = false;
                lnCodEstudiante.Visible = false;
                lblEstudiante.Visible = false;
                txtEstudiante.Visible = false;
                lnEstudiante.Visible = false;

                lblCodigo.Visible = true;
                txtCodigo.Visible = true;
                lnCodigo.Visible = true;
                pnCajas.Visible = true;

                btnGeneral.Visible = false;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);

                fnReporte1(this.CodDocenteReporte);
            }
            else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
            {
                lblCodEstudiante.Visible = false;
                txtCodEstudiante.Visible = false;
                lnCodEstudiante.Visible = false;
                lblEstudiante.Visible = false;
                txtEstudiante.Visible = false;
                lnEstudiante.Visible = false;

                lblCodigo.Visible = true;
                txtCodigo.Visible = true;
                lnCodigo.Visible = true;
                pnCajas.Visible = true;

                btnGeneral.Visible = false;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);

                fnReporte3(this.CodDocenteReporte);
            }
            else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Asignaturas"))
            {
                lblCodEstudiante.Visible = true;
                txtCodEstudiante.Visible = true;
                lnCodEstudiante.Visible = true;
                lblEstudiante.Visible = true;
                txtEstudiante.Visible = true;
                lnEstudiante.Visible = true;

                lblCodigo.Visible = false;
                txtCodigo.Visible = false;
                lnCodigo.Visible = false;
                pnCajas.Visible = false;

                btnGeneral.Visible = true;

                fnReporte8();
            }
        }

        public string CodDocenteReporte = "";

        private void fnReporte5()
        {
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
                        {
                            if (Total == resultados.Rows.Count)
                                ResultadosFinales.Rows.Add(Contador - 8, "Tema" + Convert.ToString(Contador - 8), "", "PROGRESO");
                            else
                                ResultadosFinales.Rows.Add(Contador - 8, "Tema" + Convert.ToString(Contador - 8), "", "FALTA");
                        }
                        Total = Total + 1;
                        Contador = Contador + 1;
                    }
                }

                int Hechos = resultados.Rows.Count;
                int Faltan = Total - Hechos;
                Reportes.fnReporte5(Titulo, Titulos, Valores, ResultadosFinales, txtCodigo.Text, Hechos, Faltan);
            }
            else
            {
                Ayudas.A_Dialogo.DialogoError("El Docente no subió su Plan de Sesiones");

                lblCriterioSeleccion.Visible = true;
                cxtCriterioSeleccion.Visible = true;

                lblFechaInicial.Visible = true;
                dpFechaInicial.Visible = true;

                lblFechaFinal.Visible = true;
                dpFechaFinal.Visible = true;

                btnGeneral.Visible = false;

                cxtTipoReporte.SelectedIndex = 0;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);
            }
        }

        public void fnReporte7()
        {
            // Reporte 7
            string Titulo = "REPORTE DE GENERAL ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Escuela Profesional" };
            string[] Valores = { CodSemestre, "INGENIERÍA INFORMÁTICA Y DE SISTEMAS" };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorAsignaturas(CodSemestre, CodDepartamentoA, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            Reportes.fnReporte7(Titulo, Titulos, Valores, resultados);
        }

        private void fnReporte1(string CodDocenteReporte)
        {
            // Tipo de reporte: Asistencia estudiantes
            // Criterio de selección: Por Fechas

            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Cod. Asignatura", "Asignatura", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocenteReporte, nombreDocente, txtCodigo.Text, txtNombre.Text, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorFechas(CodSemestre, CodDocenteReporte, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            string ans = Reportes.fnReporte1(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString(), txtCodigo.Text);

            if (ans == "Si")
            {
                cxtCriterioSeleccion.SelectedIndex = AntCriterioSeleccion;
                dpFechaInicial.Value = AntFechaInicial;
                dpFechaFinal.Value = AntFechaFinal;
                txtCodigo.Text = AntCodAsignatura;
                txtNombre.Text = AntNombreAsignatura;
                txtEscuelaP.Text = AntEscuelaProfesional;

                pnReporte.Controls[0].Controls[1].Controls[0].Text = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            }
            else pnReporte.AutoScrollPosition = new Point(0, 0);
        }

        private void fnReporte3(string CodDocenteReporte)
        {
            // Tipo de reporte: Asistencia estudiantes
            // Criterio de selección: Por Estudiantes

            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Cod. Asignatura", "Asignatura", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocenteReporte, nombreDocente, txtCodigo.Text, txtNombre.Text, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorEstudiante(CodSemestre, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            string ans = Reportes.fnReporte3(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString(), txtCodigo.Text);

            if (ans == "Si")
            {
                cxtCriterioSeleccion.SelectedIndex = AntCriterioSeleccion;
                dpFechaInicial.Value = AntFechaInicial;
                dpFechaFinal.Value = AntFechaFinal;
                txtCodigo.Text = AntCodAsignatura;
                txtNombre.Text = AntNombreAsignatura;
                txtEscuelaP.Text = AntEscuelaProfesional;

                pnReporte.Controls[0].Controls[1].Controls[0].Text = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            }
            else pnReporte.AutoScrollPosition = new Point(0, 0);
        }

        private void fnReporte8()
        {
            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Escuela Profesional", "Código", "Estudiante" };
            string[] Valores = { CodSemestre, "INGENIERÍA INFORMÁTICA Y DE SISTEMAS", txtCodEstudiante.Text, txtEstudiante.Text };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaAsignaturasEstudiante(CodSemestre, txtCodEstudiante.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            Reportes.fnReporte8(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString(), txtCodEstudiante.Text);
        }

        private void fnReporte9()
        {
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

            DataTable ResultadosGráfico = new DataTable();
            ResultadosGráfico.Columns.Add("CodAsignatura", typeof(string));
            ResultadosGráfico.Columns.Add("NombreAsignatura", typeof(string));
            ResultadosGráfico.Columns.Add("Docente", typeof(string));
            ResultadosGráfico.Columns.Add("TemasAvanzados", typeof(double));
            ResultadosGráfico.Columns.Add("TemasFaltantes", typeof(double));

            int Créditos = 0;
            int TemasTotales = 0;
            double PorcentajeAvanzados = 0;

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
                    ResultadosGráfico.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), PorcentajeAvanzados, Convert.ToDouble(100 - PorcentajeAvanzados));
                }
                else
                {
                    TemasTotales = 34;
                    PorcentajeAvanzados = 100 * Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()) / TemasTotales;
                    ResultadosFinales.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), Convert.ToString(PorcentajeAvanzados) + "%", Convert.ToString(100 - PorcentajeAvanzados) + "%");
                    ResultadosResumen.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()), TemasTotales - Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()));
                    ResultadosGráfico.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), resultados.Rows[i]["Docente"].ToString(), PorcentajeAvanzados, Convert.ToDouble(100 - PorcentajeAvanzados));
                }
            }

            Reportes.fnReporte9(Titulo, Titulos, Valores, ResultadosFinales, ResultadosResumen, ResultadosGráfico);
        }

        private int AntCriterioSeleccion;
        private DateTime AntFechaInicial;
        private DateTime AntFechaFinal;
        private string AntCodAsignatura;
        private string AntNombreAsignatura;
        private string AntEscuelaProfesional;

        private void dpFechaInicial_MouseDown(object sender, MouseEventArgs e)
        {
            AntCriterioSeleccion = cxtCriterioSeleccion.SelectedIndex;
            AntFechaInicial = dpFechaInicial.Value;
            AntFechaFinal = dpFechaFinal.Value;
            AntCodAsignatura = txtCodigo.Text;
            AntNombreAsignatura = txtNombre.Text;
            AntEscuelaProfesional = txtEscuelaP.Text;
        }

        private void dpFechaInicial_CloseUp(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                CriterioSeleccionAsistenciaEstudiantes();
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                fnReporte5();
            }
        }
    }
}
