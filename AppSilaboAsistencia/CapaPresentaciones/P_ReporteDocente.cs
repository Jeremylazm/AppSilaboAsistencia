﻿using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using CapaEntidades;
using CapaNegocios;
using ControlesPerzonalizados;

namespace CapaPresentaciones
{
    public partial class P_ReporteDocente : Form
    {
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        readonly string CodDocente = E_InicioSesion.Usuario;
        string NombreDocente;
        private int AntCriterioSeleccion;
        private DateTime AntFechaInicial;
        private DateTime AntFechaFinal;
        private string AntCodAsignatura;
        private string AntNombreAsignatura;
        private string AntEscuelaProfesional;
        C_Reporte Reportes;

        public P_ReporteDocente()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            InitializeComponent();
            LLenarCampos();

            // Definir minimas y maximas fechas para los filtros
            dpFechaInicial.MaxDate = new DateTime(2022, 03, 01);
            dpFechaInicial.MinDate = new DateTime(2021, 09, 01);
            dpFechaFinal.MaxDate = new DateTime(2022, 03, 01);
            dpFechaFinal.MinDate = new DateTime(2021, 09, 01);

            // Inicializar las fechas de los reportes         
            //dpFechaInicial.Value = new DateTime(2021, 10, 18);
            //dpFechaFinal.Value = new DateTime(2021, 11, 05);
            
            dpFechaInicial.Value = Convert.ToDateTime(Semestre.Rows[0][1], CultureInfo.GetCultureInfo("es-ES"));
            dpFechaFinal.Value = DateTime.Today;

            AntCriterioSeleccion = cxtCriterioSeleccion.SelectedIndex;
            AntFechaInicial = dpFechaInicial.Value;
            AntFechaFinal = dpFechaFinal.Value;
            AntCodAsignatura = txtCodigo.Text;
            AntNombreAsignatura = txtNombre.Text;
            AntEscuelaProfesional = txtEscuelaP.Text;
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
            // Ocultar el scroll del panel del reporte
            pnReporte.Parent = pnPadre;
            pnReporte.Location = new Point(0, 0);
            pnReporte.Width = pnPadre.ClientSize.Width + SystemInformation.VerticalScrollBarWidth;
            pnReporte.Height = pnPadre.ClientSize.Height + SystemInformation.HorizontalScrollBarHeight;

            // Determinar el nombre del docente
            DataTable DatosDocente = N_Docente.BuscarDocente(CodDepartamentoA, CodDocente);
            NombreDocente = DatosDocente.Rows[0]["Nombre"].ToString() + " " + DatosDocente.Rows[0]["APaterno"].ToString() + " " + DatosDocente.Rows[0]["AMaterno"].ToString();

            // Crear un objeto reporte
            Reportes = new C_Reporte()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right                
            };

            // Mostrar el reporte 1
            fnReporte1();

            // Anhadir el reporte al formulario y mostrarlo responsivamente
            pnReporte.Controls.Add(Reportes);
            Responsivo();

            // Mostrar el reporte desde el inicio
            ActiveControl = pnReporte;
            pnReporte.AutoScrollPosition = new Point(0, 0);
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
            lblCodigo.Visible = true;
            lblNombre.Visible = true;
            lblEscuelaP.Visible = true;
            txtCodigo.Visible = true;
            txtNombre.Visible = true;
            txtEscuelaP.Visible = true;
            lnCodigo.Visible = true;
            lnNombre.Visible = true;
            lnEscuelaP.Visible = true;

            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                P_SeleccionadoAsignaturaAsignada Asignaturas = new P_SeleccionadoAsignaturaAsignada(txtCodigo.Text, "Docente", cxtCriterioSeleccion.SelectedItem.ToString());
                AddOwnedForm(Asignaturas);
                Asignaturas.ShowDialog();
                Asignaturas.Dispose();

                if (Asignaturas.DialogResult == DialogResult.Yes)
                {
                    if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
                        fnReporte3();
                    else
                        fnReporte1();
                }
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                P_SeleccionadoAsignatura Asignaturas = new P_SeleccionadoAsignatura("Docente");
                AddOwnedForm(Asignaturas);
                Asignaturas.ShowDialog();
                Asignaturas.Dispose();

                if (Asignaturas.DialogResult == DialogResult.Yes)
                {
                    fnReporte5();
                }
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            lblCodigo.Visible = false;
            lblNombre.Visible = false;
            lblEscuelaP.Visible = false;
            txtCodigo.Visible = false;
            txtNombre.Visible = false;
            txtEscuelaP.Visible = false;
            lnCodigo.Visible = false;
            lnNombre.Visible = false;
            lnEscuelaP.Visible = false;

            fnReporte6();
        }

        private void cxtTipoReporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblCodigo.Visible = true;
            lblNombre.Visible = true;
            lblEscuelaP.Visible = true;
            txtCodigo.Visible = true;
            txtNombre.Visible = true;
            txtEscuelaP.Visible = true;
            lnCodigo.Visible = true;
            lnNombre.Visible = true;
            lnEscuelaP.Visible = true;

            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                lblCriterioSeleccion.Visible = true;
                cxtCriterioSeleccion.Visible = true;

                lblFechaInicial.Visible = true;
                dpFechaInicial.Visible = true;

                lblFechaFinal.Visible = true;
                dpFechaFinal.Visible = true;

                btnGeneral.Visible = false;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);

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
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 172);

                fnReporte5();
            }
        }

        private void cxtCriterioSeleccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CriterioSeleccionAsistenciaEstudiantes();
        }

        public void CriterioSeleccionAsistenciaEstudiantes()
        {
            if (cxtCriterioSeleccion.SelectedItem.Equals("Por Estudiantes"))
            {
                fnReporte3();
            }
            else if (cxtCriterioSeleccion.SelectedItem.Equals("Por Fechas"))
            {
                fnReporte1();
            }
        }

        private void fnReporte1()
        {
            // Tipo de reporte: Asistencia estudiantes
            // Criterio de selección: Por Fechas

            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Cod. Asignatura", "Asignatura", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocente, NombreDocente, txtCodigo.Text, txtNombre.Text, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorFechas(CodSemestre, CodDocente, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

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

        private void fnReporte3()
        {
            // Tipo de reporte: Asistencia estudiantes
            // Criterio de selección: Por Estudiantes

            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Cod. Asignatura", "Asignatura", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocente, NombreDocente, txtCodigo.Text, txtNombre.Text, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorEstudiante(CodSemestre, txtCodigo.Text, CodDocente, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

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

        private void fnReporte5()
        {
            // Tipo de reporte: Avance Asignatura
            // Criterio de selección: Por Docente
            string Titulo = "REPORTE DE AVANCE - " + txtCodigo.Text + Environment.NewLine + "SEMESTRE " + CodSemestre;
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Cod. Asignatura", "Asignatura", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocente, NombreDocente, txtCodigo.Text, txtNombre.Text, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaDocentePorAsignatura.AvanceAsignatura(CodSemestre, CodDocente, txtCodigo.Text);
            DataTable plansesion = N_Catalogo.RecuperarPlanDeSesionAsignatura(CodSemestre, txtCodigo.Text, CodDocente);

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
                ResultadosFinales.Columns.Add("Tema", typeof(string));
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
                                ResultadosFinales.Rows.Add(Contador - 8, wb.Worksheet(1).Cell("C" + Convert.ToString(i)).Value.ToString(), "", "PROGRESO");
                            else
                                ResultadosFinales.Rows.Add(Contador - 8, wb.Worksheet(1).Cell("C" + Convert.ToString(i)).Value.ToString(), "", "FALTA");
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
                Ayudas.A_Dialogo.DialogoError("No hay Plan de Sesiones de la asignatura " + txtCodigo.Text);
            }
            pnReporte.AutoScrollPosition = new Point(0, 0);
        }

        private void fnReporte6()
        {
            // Tipo de reporte: Avance Asignatura
            // Criterio de selección: Por Docente
            string Titulo = "REPORTE DE AVANCE GENERAL" + Environment.NewLine + "SEMESTRE - " + CodSemestre;
            string[] Titulos = { "Semestre", "Cod. Docente", "Docente", "Escuela Profesional" };
            string[] Valores = { CodSemestre, CodDocente, NombreDocente, txtEscuelaP.Text };

            DataTable resultados = N_AsistenciaDocentePorAsignatura.AvanceAsignaturasDocente(CodSemestre, CodDocente);

            DataTable ResultadosFinales = new DataTable();
            ResultadosFinales.Columns.Add("CodAsignatura", typeof(string));
            ResultadosFinales.Columns.Add("NombreAsignatura", typeof(string));
            ResultadosFinales.Columns.Add("TemasAvanzados", typeof(string));
            ResultadosFinales.Columns.Add("TemasFaltantes", typeof(string));

            DataTable ResultadosGrafico = new DataTable();
            ResultadosGrafico.Columns.Add("CodAsignatura", typeof(string));
            ResultadosGrafico.Columns.Add("NombreAsignatura", typeof(string));
            ResultadosGrafico.Columns.Add("TemasAvanzados", typeof(int));
            ResultadosGrafico.Columns.Add("TemasFaltantes", typeof(int));

            int Créditos = 0;
            int TemasTotales = 0;
            float PorcentajeAvanzados = 0;

            for (int i = 0; i < resultados.Rows.Count; i++)
            {
                DataTable TablaCreditos = N_Asignatura.BuscarAsignatura(CodDepartamentoA, resultados.Rows[i]["CodAsignatura"].ToString().Substring(0,5));
                if (TablaCreditos.Rows.Count != 0)
                {
                    Créditos = Convert.ToInt32(TablaCreditos.Rows[0]["Creditos"].ToString());
                }
                if (Créditos == 4)
                {
                    TemasTotales = 51;
                    PorcentajeAvanzados = 100 * Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()) / TemasTotales;
                    ResultadosFinales.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), Convert.ToString(PorcentajeAvanzados) + "%", Convert.ToString(100 - PorcentajeAvanzados) + "%");
                    ResultadosGrafico.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()), TemasTotales - Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()));
                }
                else
                {
                    TemasTotales = 34;
                    PorcentajeAvanzados = 100 * Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()) / TemasTotales;
                    ResultadosFinales.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), Convert.ToString(PorcentajeAvanzados) + "%", Convert.ToString(100 - PorcentajeAvanzados) + "%");
                    ResultadosGrafico.Rows.Add(resultados.Rows[i]["CodAsignatura"].ToString(), resultados.Rows[i]["NombreAsignatura"].ToString(), Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()), TemasTotales - Convert.ToInt32(resultados.Rows[i]["TemasAvanzados"].ToString()));
                }
            }

            Reportes.fnReporte6(Titulo, Titulos, Valores, ResultadosFinales, ResultadosGrafico, txtCodigo.Text);
            pnReporte.AutoScrollPosition = new Point(0, 0);
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

        private void dpFechaInicial_MouseDown(object sender, MouseEventArgs e)
        {
            AntCriterioSeleccion = cxtCriterioSeleccion.SelectedIndex;
            AntFechaInicial = dpFechaInicial.Value;
            AntFechaFinal = dpFechaFinal.Value;
            AntCodAsignatura = txtCodigo.Text;
            AntNombreAsignatura = txtNombre.Text;
            AntEscuelaProfesional = txtEscuelaP.Text;
        }
    }
}