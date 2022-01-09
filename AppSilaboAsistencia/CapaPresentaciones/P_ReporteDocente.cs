﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        C_ReporteA Reportes = new C_ReporteA();
        string nombreDocente;

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
            cxtCargoSeleccion.SelectedIndex = 0;

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
            //dpFechaInicial.MaxDate = DateTime.Now;
            //dpFechaFinal.MaxDate = DateTime.Now;
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

            DataTable datosDocente = N_Docente.BuscarDocente(CodDepartamentoA, CodDocente);
            nombreDocente = datosDocente.Rows[0]["Nombre"].ToString() + " " + datosDocente.Rows[0]["APaterno"].ToString() + " " + datosDocente.Rows[0]["AMaterno"].ToString();
            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy" + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy"));
            string[] Titulos = { "Semestre", "Escuela Profesional", "Asignatura", "Cód. Asignatura", "Docente", "Cod. Docente" };
            string[] Valores = { CodSemestre, txtEscuelaP.Text, txtNombre.Text, txtCodigo.Text,  nombreDocente, CodDocente};
            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorFechas(CodSemestre, CodDocente, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            C_ReporteA Reporte = new C_ReporteA();
            Responsivo();
            pnReporte.Controls.Add(Reporte);

            /*C_ReporteA Reporte = new C_ReporteA(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString())
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            Reportes = Reporte;

            Responsivo();
            pnReporte.Controls.Add(Reporte); */
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
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes")) 
            {
                P_SeleccionadoAsignaturaAsignada Asignaturas = new P_SeleccionadoAsignaturaAsignada(txtCodigo.Text, 1);
                AddOwnedForm(Asignaturas);
                Asignaturas.ShowDialog();
            }
            else
            {
                P_SeleccionadoAsignaturaAsignada Asignaturas = new P_SeleccionadoAsignaturaAsignada(txtCodigo.Text, 2);
                AddOwnedForm(Asignaturas);
                Asignaturas.ShowDialog();
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {

            }
            else
            {
                if (cxtCargoSeleccion.SelectedItem.Equals("Docente"))
                {

                }
                else
                {

                }
            }
        }

        private void cxtTipoReporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
            {
                lblCriterioSeleccion.Text = "Criterio de Selección";
                lblCriterioSeleccion.Visible = true;
                cxtCriterioSeleccion.Visible = true;
                cxtCargoSeleccion.Visible = false;

                lblFechaInicial.Visible = true;
                dpFechaInicial.Visible = true;

                lblFechaFinal.Visible = true;
                dpFechaFinal.Visible = true;

                btnGeneral.Visible = false;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 152);

                CriterioSeleccionAsistenciaEstudiantes(); //OJO
            }
            else if (cxtTipoReporte.SelectedItem.Equals("Avance Asignaturas"))
            {
                if (E_InicioSesion.Acceso == "Docente")
                {
                    lblCriterioSeleccion.Visible = false;
                    cxtCriterioSeleccion.Visible = false;
                }
                else
                {
                    lblCriterioSeleccion.Text = "Cargo de Selección";
                    cxtCargoSeleccion.Visible = true;
                    cxtCriterioSeleccion.Visible = false;
                }

                btnGeneral.Visible = true;
                btnSeleccionar.Location = new Point(btnGeneral.Location.X, 131);
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

            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy" + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy"));
            string[] Titulos = { "Semestre", "Escuela Profesional", "Asignatura", "Cód. Asignatura", "Docente", "Cod. Docente" };
            string[] Valores = { CodSemestre, txtEscuelaP.Text, txtNombre.Text, txtCodigo.Text, nombreDocente, CodDocente };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorFechas(CodSemestre, CodDocente, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            Reportes.fnReporte1(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString());
        }

        private void fnReporte3()
        {
            // Tipo de reporte: Asistencia estudiantes
            // Criterio de selección: Por Estudiantes

            string Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Escuela Profesional", "Asignatura", "Cód. Asignatura", "Docente", "Cod. Docente" };
            string[] Valores = { CodSemestre, txtEscuelaP.Text, txtNombre.Text, txtCodigo.Text, CodDocente, nombreDocente };


            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorEstudiante(CodSemestre, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            Reportes.fnReporte3(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString());
        }

        /*
        private void fnReporte5()
        {
            // Tipo de reporte: Avance Asignatura
            // Criterio de selección: Por Docente
            string Titulo = "REPORTE DE AVANCE" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Escuela Profesional", "Asignatura", "Cód. Asignatura", "Docente", "Cod. Docente" };
            string[] Valores = { CodSemestre, txtEscuelaP.Text, txtNombre.Text, txtCodigo.Text, CodDocente, nombreDocente };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorEstudiante(CodSemestre, txtCodigo.Text, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
        
            Reportes.fnReporte5(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString());
        }

        private void fnReporte6()
        {
            // Tipo de reporte: Avance Asignatura
            // Criterio de selección: Por Docente
            string Titulo = "REPORTE DE AVANCE" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre", "Escuela Profesional", "Docente", "Cod. Docente" };
            string[] Valores = { CodSemestre, txtEscuelaP.Text, CodDocente, nombreDocente };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorEstudiante(CodSemestre, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            Reportes.fnReporte6(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString());
        }

        private void fnReporte9()
        {
            // Tipo de reporte: Avance Asignatura
            // Criterio de selección: Por Fechas
            string Titulo = "REPORTE DE AVANCE" + Environment.NewLine + "Desde: " + dpFechaInicial.Value.ToString("dd/MM/yyyy") + " - " + "Hasta: " + dpFechaFinal.Value.ToString("dd/MM/yyyy");
            string[] Titulos = { "Semestre" };
            string[] Valores = { CodSemestre };

            DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantesPorEstudiante(CodSemestre, dpFechaInicial.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dpFechaFinal.Value.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            Reportes.fnReporte9(Titulo, Titulos, Valores, resultados, cxtCriterioSeleccion.SelectedItem.ToString());
        }
        */
    }
}