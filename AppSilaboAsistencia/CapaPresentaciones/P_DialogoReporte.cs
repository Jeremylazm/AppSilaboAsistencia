using System;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        C_Reporte Reportes;
        readonly string[] ValoresNecesarios;
        readonly DateTime[] FechasNecesarias;
        readonly string Criterio;

        public P_DialogoReporte()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();
        }

        public P_DialogoReporte(string[] pValoresNecesarios, DateTime[] pFechasNecesarias, string pCriterio)
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            ValoresNecesarios = pValoresNecesarios;
            FechasNecesarias = pFechasNecesarias;
            Criterio = pCriterio;
            InitializeComponent();
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
            string Titulo;
            string[] Titulos;
            string[] Valores;
            DataTable Resultados;

            if (Criterio == "Por Fechas") // Reporte 2
            {
                Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + ValoresNecesarios[5];
                Titulos = new string[] { "Semestre", "Escuela Profesional", "Cod. Asignatura", "Asignatura", "Cod. Docente", "Docente" };
                Valores = new string[] { CodSemestre, ValoresNecesarios[4], ValoresNecesarios[2], ValoresNecesarios[3], ValoresNecesarios[0], ValoresNecesarios[1] };

                Console.WriteLine(FechasNecesarias[0].ToString("yyyy/MM/dd"));

                Resultados = N_AsistenciaEstudiante.AsistenciaEstudiantes(CodSemestre, ValoresNecesarios[2], FechasNecesarias[0].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), ValoresNecesarios[6]);
            }
            else if (Criterio == "Por Estudiantes") // Reporte 4
            {
                Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + DateTime.ParseExact(ValoresNecesarios[7], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")) + " - " + "Hasta: " + DateTime.ParseExact(ValoresNecesarios[8], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES"));
                Titulos = new string[] { "Semestre", "Escuela Profesional", "Cod. Asignatura", "Asignatura", "Cod. Docente", "Docente", "Cod. Estudiante", "Estudiante" };
                Valores = new string[] { CodSemestre, ValoresNecesarios[4], ValoresNecesarios[2], ValoresNecesarios[3], ValoresNecesarios[0], ValoresNecesarios[1], ValoresNecesarios[5], ValoresNecesarios[6] };

                Resultados = N_AsistenciaEstudiante.AsistenciaEstudianteAsignatura(CodSemestre, ValoresNecesarios[5], ValoresNecesarios[2], FechasNecesarias[0].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), FechasNecesarias[1].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
            }
            else if (Criterio == "Por Asignaturas")
            {
                Titulo = "REPORTE DE ASISTENCIA ESTUDIANTES" + Environment.NewLine + "Desde: " + DateTime.ParseExact(ValoresNecesarios[7], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")) + " - " + "Hasta: " + DateTime.ParseExact(ValoresNecesarios[8], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES"));
                Titulos = new string[] { "Semestre", "Escuela Profesional", "Cod. Asignatura", "Asignatura", "Cod. Docente", "Docente", "Cod. Estudiante", "Estudiante" };
                Valores = new string[] { CodSemestre, ValoresNecesarios[0], ValoresNecesarios[3], ValoresNecesarios[4], ValoresNecesarios[5], ValoresNecesarios[6], ValoresNecesarios[1], ValoresNecesarios[2] };

                Resultados = N_AsistenciaEstudiante.AsistenciaEstudianteAsignatura(CodSemestre, ValoresNecesarios[1], ValoresNecesarios[3], FechasNecesarias[0].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), FechasNecesarias[1].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
            }
            else if (Criterio == "Por Fechas D") // Reporte 15
            {
                pnReporte.AutoScrollPosition = new Point(0, 0);
                DataTable NombreDepar = N_DepartamentoAcademico.BuscarNombreDepartamento(CodDepartamentoA);
                string NomDepartamento = NombreDepar.Rows[0]["Nombre"].ToString();
                Titulo = "REPORTE DE ASISTENCIA DOCENTES" + Environment.NewLine + ValoresNecesarios[1];
                Titulos = new string [] { "Semestre", "Dpto Academico " };
                Valores = new string[] { CodSemestre, NomDepartamento };

                Console.WriteLine(FechasNecesarias[0].ToString("yyyy/MM/dd"));

                Resultados = N_AsistenciaDiariaDocente.AsistenciaDiariaDocentes(CodSemestre, CodDepartamentoA, FechasNecesarias[0].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            }
            else// if (Criterio == "Por Asignaturas D") //Reporte 11
            {
                pnReporte.AutoScrollPosition = new Point(0, 0);
                DataTable NombreDepar = N_DepartamentoAcademico.BuscarNombreDepartamento(CodDepartamentoA);
                string NomDepartamento = NombreDepar.Rows[0]["Nombre"].ToString();
                Titulo = "REPORTE DE ASISTENCIA DOCENTES" + Environment.NewLine + "Desde: " + DateTime.ParseExact(ValoresNecesarios[5], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")) + " - " + "Hasta: " + DateTime.ParseExact(ValoresNecesarios[6], "yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES"));
                Titulos = new string[] { "Semestre", "Departamento Academico", "Cod. Asignatura", "Asignatura", "Cod. Docente", "Docente" };
                Valores = new string[] { CodSemestre, NomDepartamento, ValoresNecesarios[3], ValoresNecesarios[4], ValoresNecesarios[1], ValoresNecesarios[2] };

                Resultados = N_AsistenciaDocentePorAsignatura.AsistenciaDocenteAsignatura(CodSemestre, ValoresNecesarios[1], ValoresNecesarios[3], FechasNecesarias[0].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), FechasNecesarias[1].ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));

            }

            Reportes = new C_Reporte(Titulo, Titulos, Valores, Resultados, Criterio)
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Width = pnReporte.Width
            };

            pnReporte.Controls.Add(Reportes);
            Responsivo();

            ActiveControl = pnReporte;
            pnReporte.AutoScrollPosition = new Point(0, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
