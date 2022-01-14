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
    public partial class P_DialogoReporte : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        C_Reporte Reportes = new C_Reporte();
        string nombreDocente;

        public P_DialogoReporte()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();
        }

        public P_DialogoReporte(string[] ValoresNecesarios, string Criterio)
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();

            if (Criterio == "Por Fechas")
            {
                string Titulo = "Reporte de Asistencia Estudiantes" + Environment.NewLine + ValoresNecesarios[5];
                string[] Titulos = { "Semestre", "Escuela Profesional", "Cod. Asignatura", "Asignatura", "Cod. Docente", "Docente" };
                string[] Valores = { CodSemestre, ValoresNecesarios[4], ValoresNecesarios[2], ValoresNecesarios[3], ValoresNecesarios[0], ValoresNecesarios[1] };

                DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudiantes(CodSemestre, ValoresNecesarios[2], ValoresNecesarios[5], "09:15:29");

                C_Reporte Reporte = new C_Reporte(Titulo, Titulos, Valores, resultados, "Por Fechas")
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                Reportes = Reporte;
                Responsivo();
                pnReporte.Controls.Add(Reporte);
                ActiveControl = Reporte.btnGrafico1;
            }
            else if (Criterio == "Por Estudiantes")
            {
                string Titulo = "Reporte de Asistencia Estudiantes" + Environment.NewLine + "Desde: " + DateTime.ParseExact(ValoresNecesarios[7], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")) + " - " + "Hasta: " + DateTime.ParseExact(ValoresNecesarios[8], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES"));
                string[] Titulos = { "Semestre", "Escuela Profesional", "Cod. Asignatura", "Asignatura", "Cod. Docente", "Docente", "Cod. Estudiante", "Estudiante" };
                string[] Valores = { CodSemestre, ValoresNecesarios[4], ValoresNecesarios[2], ValoresNecesarios[3], ValoresNecesarios[0], ValoresNecesarios[1], ValoresNecesarios[5], ValoresNecesarios[6] };

                DataTable resultados = N_AsistenciaEstudiante.AsistenciaEstudianteAsignatura(CodSemestre, ValoresNecesarios[5], ValoresNecesarios[2], ValoresNecesarios[7], ValoresNecesarios[8]);

                C_Reporte Reporte = new C_Reporte(Titulo, Titulos, Valores, resultados, "Por Estudiantes")
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                Reportes = Reporte;
                Responsivo();
                pnReporte.Controls.Add(Reporte);
                ActiveControl = Reporte.btnGrafico1;
            }
            else if (Criterio == "Por Asignaturas")
            {
                /*C_Reporte Reporte = new C_Reporte(Titulo, Titulos, Valores, resultados, txtCodigo.Text, "Por Fechas")
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right

                };

                Reportes = Reporte;
                Responsivo();
                pnReporte.Controls.Add(Reporte);
                ActiveControl = Reporte.btnGrafico1;*/
            }
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

        private void P_DialogoReporte_Load(object sender, EventArgs e)
        {
            pnReporte.Parent = pnPadre;
            pnReporte.Location = new Point(0, 0);
            pnReporte.Width = pnPadre.ClientSize.Width + SystemInformation.VerticalScrollBarWidth;
            pnReporte.Height = pnPadre.ClientSize.Height + SystemInformation.HorizontalScrollBarHeight;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
