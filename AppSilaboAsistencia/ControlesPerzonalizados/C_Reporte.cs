﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.Statistics;
using Ayudas;
using System.IO;
using ClosedXML.Excel;
using CapaNegocios;

namespace ControlesPerzonalizados
{
    public partial class C_Reporte : UserControl
    {
        private string CriterioAsistenciasEstudiantes;
        readonly N_Catalogo ObjCatalogo;
        private int IndiceGrafico1 = 0;
        private int IndiceGrafico2 = 1;

        public C_Reporte()
        {
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvResultados, sbResultados);
        }

        void dataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            int currentIndex = this.dgvResultados.FirstDisplayedScrollingRowIndex;
            int scrollLines = SystemInformation.MouseWheelScrollLines;

            if (e.Delta > 0)
            {
                this.dgvResultados.FirstDisplayedScrollingRowIndex
                    = Math.Max(0, currentIndex - scrollLines);
                this.sbResultados.Value = Math.Max(0, currentIndex - scrollLines);
            }
            else if (e.Delta < 0)
            {
                this.dgvResultados.FirstDisplayedScrollingRowIndex
                    = currentIndex + scrollLines;
                this.sbResultados.Value = currentIndex + scrollLines;
            }
        }

        public void LimpiarCampos()
        {
            pnSubcampos.Controls.Clear();
        }

        public C_Reporte(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistenciasEstudiantes, string CodAsignatura, string AccesoReporte)
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvResultados, sbResultados);

            fnReporte1(Titulo, Titulos, Valores, Datos, CriterioAsistenciasEstudiantes, CodAsignatura);
        }

        private void C_ReporteA_Resize(object sender, EventArgs e)
        {
            int AnchoTotal = 0;
            int Filas = 1;

            foreach (C_Campo cpControl in this.pnSubcampos.Controls)
            {
                if ((AnchoTotal + cpControl.Width + 6) > this.pnSubcampos.Width)
                {
                    Filas++;
                    AnchoTotal = cpControl.Width + 6;
                }
                else
                {
                    AnchoTotal += cpControl.Width + 6;
                }
            }

            this.Cuadricula.RowStyles[0].Height = Filas * 92 + 51;
            this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;
        }

        public void fnReporte1(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistenciasEstudiantes, string CodAsignatura)
        {
            this.CriterioAsistenciasEstudiantes = CriterioAsistenciasEstudiantes;

            LimpiarCampos();

            lblTitulo.Text = Titulo;

            if (Titulos.Length.Equals(Valores.Length))
            {
                if (Titulos.Length != 0)
                {
                    for (int K = 0; K < Titulos.Length; K++)
                    {
                        C_Campo Nuevo = new C_Campo(Titulos[K], Valores[K]);
                        pnSubcampos.Controls.Add(Nuevo);
                    }
                }
                else
                {
                    MessageBox.Show("No existen parametros");
                }
            }
            else
            {
                MessageBox.Show("Error de parametros");
            }

            if (Datos.Rows.Count == 0)
            {
                A_Dialogo.DialogoInformacion("No hay registros entre estas fechas, por favor selecciona otro rango de fechas");

                lblTitulo.Text = "";
                pnSubcampos.Controls.Clear();
                dgvResumen.Columns.Clear();
                dgvResultados.Columns.Clear();
                dgvResultados.Refresh();

                //tcGraficos.Controls.Clear();
            }
            else
            {
                // Crear columna
                DataGridViewImageColumn btnVerReporte = new DataGridViewImageColumn
                {
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Frozen = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,
                    DividerWidth = 0,
                    FillWeight = 100,
                    MinimumWidth = 5,
                    Width = 1032
                };

                dgvResultados.Columns.Clear();
                dgvResultados.Columns.Add(btnVerReporte);
                dgvResultados.Columns[0].HeaderText = "Ver Reporte";

                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[0].DisplayIndex = 5;

                if (dgvResultados.Rows.Count <= 10)
                {
                    sbResultados.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = dgvResultados.Rows.Count * 26 + 81;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                else
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = 341;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    sbResultados.Visible = true;
                }

                // Mostrar cuadro de resumen
                //pnInferior.Controls[2].Show();
                if (!pnContenedorCuadro.Visible)
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    this.Cuadricula.RowStyles[1].Height += pnContenedorGraficos.Location.Y - pnContenedorCuadro.Location.Y;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorCuadro.Visible = true;
                }

                DataTable dtEstadisticos = (dgvResultados.DataSource as DataTable).Copy();
                dtEstadisticos.Rows.Clear();

                //DataTable dtEstadisticos = (dgvResultados.DataSource as DataTable).Copy();
                //dtEstadisticos.Rows.Clear();

                // Asistencias
                // Solo donde SesiónDictada es SI para los estadísticos
                foreach (DataRow row in Datos.Rows)
                {
                    if (row["SesiónDictada"].ToString() == "SI")
                    {
                        dtEstadisticos.ImportRow(row);
                    }
                }

                // Listas de valores
                List<double> Asistieron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<int>("TotalAsistieron"))).ToList();
                List<double> Faltaron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<int>("TotalFaltaron"))).ToList();

                foreach (int i in Asistieron)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("-------------");

                foreach (int i in Faltaron)
                {
                    Console.WriteLine(i);
                }

                // Cuadro de resumen
                DataTable cuadroResumen = new DataTable();
                cuadroResumen.Columns.Add(" ");
                cuadroResumen.Columns.Add("Asistieron");
                cuadroResumen.Columns.Add("Faltaron");

                // Máximos
                cuadroResumen.Rows.Add("Máximo", Statistics.Maximum(Asistieron), Statistics.Maximum(Faltaron));

                // Mínimos
                cuadroResumen.Rows.Add("Mínimo", Statistics.Minimum(Asistieron), Statistics.Minimum(Faltaron));

                // Media
                cuadroResumen.Rows.Add("Media", String.Format("{0:0.00}", Statistics.Mean(Asistieron)) + " (" + String.Format("{0:0.00}", Statistics.Mean(Asistieron) / (Statistics.Mean(Asistieron) + Statistics.Mean(Faltaron)) * 100) + "%)", String.Format("{0:0.00}", Statistics.Mean(Faltaron)) + " (" + String.Format("{0:0.00}", Statistics.Mean(Faltaron) / (Statistics.Mean(Asistieron) + Statistics.Mean(Faltaron)) * 100) + "%)");

                // Mediana
                cuadroResumen.Rows.Add("Mediana", String.Format("{0:0.00}", Statistics.Median(Asistieron)), String.Format("{0:0.00}", Statistics.Median(Faltaron)));

                // Moda
                var modeAsistieron = Asistieron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                var modeFaltaron = Faltaron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                cuadroResumen.Rows.Add("Moda", modeAsistieron, modeFaltaron);

                // Varianza
                cuadroResumen.Rows.Add("Varianza", String.Format("{0:0.00}", Statistics.Variance(Asistieron)), String.Format("{0:0.00}", Statistics.Variance(Faltaron)));

                // Desviación Estándar
                var dvA = Statistics.StandardDeviation(Asistieron);
                var dvF = Statistics.StandardDeviation(Faltaron);
                cuadroResumen.Rows.Add("Desv. Estándar", String.Format("{0:0.00}", dvA), String.Format("{0:0.00}", dvF));

                dgvResumen.DataSource = cuadroResumen;

                pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                pnContenedorCuadro.Height = dgvResumen.Rows.Count * 26 + 81;
                this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                // Gráficos
                btnGrafico2.Visible = true;
                IndiceGrafico1 = 0;
                IndiceGrafico2 = 1;

                // Grafico 1
                gxGrafico1.XAxesLabel = "Fecha";
                gxGrafico1.YAxesLabel = "Cantidad";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                foreach (DataRow Fila in dtEstadisticos.Rows)
                {
                    EtiquetasA.Add(Fila["Fecha"].ToString());
                    Datos1A.Add(double.Parse(Fila["TotalAsistieron"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));
                    Datos2A.Add(double.Parse(Fila["TotalFaltaron"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico1.Labels = EtiquetasA.ToArray();
                gxGrafico1.Clear();

                GraficoBarrasHorizontales1.Label = "Total Asistieron";
                GraficoBarrasHorizontales1.Data = Datos1A;
                GraficoBarrasHorizontales1.BackgroundColor = Colores1A;

                GraficoBarrasHorizontales2.Label = "Total Faltaron";
                GraficoBarrasHorizontales2.Data = Datos2A;
                GraficoBarrasHorizontales2.BackgroundColor = Colores2A;

                GraficoBarrasHorizontales1.TargetCanvas = gxGrafico1;
                GraficoBarrasHorizontales2.TargetCanvas = gxGrafico1;

                gxGrafico1.Update();

                // Grafico 2
                gxGrafico2.XAxesLabel = "Fecha";
                gxGrafico2.YAxesLabel = "Porcentaje de Asistencia";

                List<string> EtiquetasB = new List<string>();
                List<double> Datos1B = new List<double>();
                double Valor1 = 0;
                double Valor2 = 0;

                foreach (DataRow Fila in dtEstadisticos.Rows)
                {
                    EtiquetasB.Add(Fila["Fecha"].ToString());
                    Valor1 = double.Parse(Fila["TotalAsistieron"].ToString());
                    Valor2 = double.Parse(Fila["TotalFaltaron"].ToString());

                    if ((Valor1 == 0) && (Valor2 == 0))
                    {
                        Datos1B.Add(0.00);
                    }
                    else
                    {
                        Datos1B.Add(Math.Round((Valor1 * 100) / (Valor1 + Valor2), 2));
                    }
                }

                gxGrafico2.Labels = EtiquetasB.ToArray();
                gxGrafico2.Clear();

                GraficoLineas.Label = "Total Asistieron";
                GraficoLineas.Data = Datos1B;

                GraficoLineas.TargetCanvas = gxGrafico2;

                gxGrafico2.Update();
            }
        }

        public void fnReporte3(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistenciasEstudiantes, string CodAsignatura)
        {
            this.CriterioAsistenciasEstudiantes = CriterioAsistenciasEstudiantes;

            LimpiarCampos();

            lblTitulo.Text = Titulo;

            if (Titulos.Length.Equals(Valores.Length))
            {
                if (Titulos.Length != 0)
                {
                    for (int K = 0; K < Titulos.Length; K++)
                    {
                        C_Campo Nuevo = new C_Campo(Titulos[K], Valores[K]);
                        pnSubcampos.Controls.Add(Nuevo);
                    }
                }
                else
                {
                    MessageBox.Show("No existen parametros");
                }
            }
            else
            {
                MessageBox.Show("Error de parametros");
            }

            if (Datos.Rows.Count == 0)
            {
                A_Dialogo.DialogoInformacion("No hay registros entre estas fechas, por favor selecciona otro rango de fechas");

                lblTitulo.Text = "";
                pnSubcampos.Controls.Clear();
                dgvResumen.Columns.Clear();
                dgvResultados.Columns.Clear();
                dgvResultados.Refresh();

                //tcGraficos.Controls.Clear();
            }
            else
            {
                // Crear columna
                DataGridViewImageColumn btnVerReporte = new DataGridViewImageColumn
                {
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Frozen = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,
                    DividerWidth = 0,
                    FillWeight = 100,
                    MinimumWidth = 5,
                    Width = 1032
                };

                dgvResultados.Columns.Clear();
                dgvResultados.Columns.Add(btnVerReporte);
                dgvResultados.Columns[0].HeaderText = "Ver Reporte";

                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[1].Visible = false;
                dgvResultados.Columns[0].DisplayIndex = 7;

                if (dgvResultados.Rows.Count <= 10)
                {
                    sbResultados.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = dgvResultados.Rows.Count * 26 + 81;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                else
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = 341;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    sbResultados.Visible = true;
                }

                //pnInferior.Controls[2].Hide();
                if (pnContenedorCuadro.Visible)
                {
                    pnContenedorCuadro.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    this.Cuadricula.RowStyles[1].Height -= pnContenedorGraficos.Location.Y - pnContenedorCuadro.Location.Y;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }

                

                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 0;

                // Grafico 1
                gxGrafico1.XAxesLabel = "Código Estudiante";
                gxGrafico1.YAxesLabel = "Cantidad";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                foreach (DataRow Fila in Datos.Rows)
                {
                    EtiquetasA.Add(Fila["CodEstudiante"].ToString());
                    Datos1A.Add(double.Parse(Fila["TotalAsistencias"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));
                    Datos2A.Add(double.Parse(Fila["TotalFaltas"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico1.Labels = EtiquetasA.ToArray();
                gxGrafico1.Clear();

                GraficoBarrasHorizontales1.Label = "Total Asistencias";
                GraficoBarrasHorizontales1.Data = Datos1A;
                GraficoBarrasHorizontales1.BackgroundColor = Colores1A;

                GraficoBarrasHorizontales2.Label = "Total Faltas";
                GraficoBarrasHorizontales2.Data = Datos2A;
                GraficoBarrasHorizontales2.BackgroundColor = Colores2A;

                GraficoBarrasHorizontales1.TargetCanvas = gxGrafico1;
                GraficoBarrasHorizontales2.TargetCanvas = gxGrafico1;

                gxGrafico1.Update();
            }
        }

        public void fnReporte5(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CodAsignatura, int Completados, int Faltantes)
        {
            this.CriterioAsistenciasEstudiantes = "";

            // Limpiar los Antiguos Reportes
            LimpiarCampos();

            #region ===================== TÍTULO =====================
            // Cambiar el Título
            lblTitulo.Text = Titulo;
            #endregion ===================== TÍTULO =====================

            #region ===================== DESCRIPCIÓN =====================
            // Verificar que los Títulos y los Valores dados Coincidan
            if (Titulos.Length.Equals(Valores.Length))
            {
                if (Titulos.Length != 0)
                {
                    for (int K = 0; K < Titulos.Length; K++)
                    {
                        C_Campo Nuevo = new C_Campo(Titulos[K], Valores[K]);
                        pnSubcampos.Controls.Add(Nuevo);
                    }
                }
                else
                {
                    Ayudas.A_Dialogo.DialogoError("No existen parametros");
                }
            }
            else
            {
                Ayudas.A_Dialogo.DialogoError("Error de parametros");
            }
            #endregion ===================== DESCRIPCIÓN =====================

            // Validar las Fechas dadas
            if (Datos.Rows.Count == 0)
            {
                A_Dialogo.DialogoInformacion("No hay registros entre estas fechas, por favor selecciona otro rango de fechas");

                lblTitulo.Text = "";
                pnSubcampos.Controls.Clear();
                dgvResumen.Columns.Clear();
                dgvResultados.Columns.Clear();
                dgvResultados.Refresh();

                //tcGraficos.Controls.Clear();
            }
            else
            {
                #region ===================== CUADRO DE RESULTADOS =====================
                dgvResultados.Columns.Clear();
                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[0].HeaderText = "Sesión";
                dgvResultados.Columns[1].HeaderText = "Tema";
                dgvResultados.Columns[2].HeaderText = "Fecha";
                dgvResultados.Columns[3].HeaderText = "Estado";

                if (dgvResultados.Rows.Count <= 10)
                {
                    sbResultados.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = dgvResultados.Rows.Count * 26 + 81;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                else
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = 341;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    sbResultados.Visible = true;
                }

                #endregion ===================== CUADRO DE RESULTADOS =====================

                #region ===================== CUADRO DE RESUMEN =====================
                //pnInferior.Controls[2].Show();
                if (!pnContenedorCuadro.Visible)
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    this.Cuadricula.RowStyles[1].Height += pnContenedorGraficos.Location.Y - pnContenedorCuadro.Location.Y;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorCuadro.Visible = true;
                }

                DataTable dtEstadisticos = (dgvResultados.DataSource as DataTable).Copy();
                dtEstadisticos.Rows.Clear();

                DataTable cuadroResumen = new DataTable();
                cuadroResumen.Columns.Add(" ");
                cuadroResumen.Columns.Add("Porcentajes");

                int Total = Completados + Math.Abs(Faltantes);
                float Completado = 100 * Completados / Total;
                float Faltante = 100 - Completado;
                float Totales = Completado + Faltante;

                cuadroResumen.Rows.Add("Porcentaje de Avance Completado", Completado + "%");

                cuadroResumen.Rows.Add("Porcentaje de Avance Faltante", Faltante + "%");

                cuadroResumen.Rows.Add("TOTAL", Totales + "%");

                dgvResumen.DataSource = cuadroResumen;

                pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                pnContenedorCuadro.Height = dgvResumen.Rows.Count * 26 + 81;
                this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                #endregion ===================== CUADRO DE RESUMEN =====================

                #region ===================== GRÁFICO =====================
                //tcGraficos.TabPages.Clear();
                /*
                Chart Grafico1 = new Chart
                {
                    Dock = DockStyle.Fill,
                    Palette = ChartColorPalette.Excel
                };
                TabPage tpGrafico1 = new TabPage("Gráfico 1");
                tpGrafico1.Controls.Add(Grafico1);


                Grafico1.Titles.Clear();
                Grafico1.Series.Clear();
                Grafico1.ChartAreas.Clear();

                Grafico1.Titles.Add("Asignatura" + " - " + CodAsignatura);

                ChartArea areaGrafico1 = new ChartArea();


                Grafico1.ChartAreas.Add(areaGrafico1);

                Series serie1 = new Series("TotalAsistencias")
                {
                    ChartType = SeriesChartType.Pie,
                    XValueMember = "Porcentaje de Avance Completado",
                    YValueMembers = "Porcentaje de Avance Faltante"
                };

                Grafico1.Series.Add(serie1);

                Grafico1.DataSource = cuadroResumen;

                tcGraficos.TabPages.Add(tpGrafico1);
                */
                #endregion ===================== GRÁFICO =====================
            }
        }

        public void fnReporte6(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CodAsignatura)
        {
            this.CriterioAsistenciasEstudiantes = "";

            // Limpiar los Antiguos Reportes
            LimpiarCampos();

            #region ===================== TÍTULO =====================
            // Cambiar el Título
            lblTitulo.Text = Titulo;
            #endregion ===================== TÍTULO =====================

            #region ===================== DESCRIPCIÓN =====================
            // Verificar que los Títulos y los Valores dados Coincidan
            if (Titulos.Length.Equals(Valores.Length))
            {
                if (Titulos.Length != 0)
                {
                    for (int K = 0; K < Titulos.Length; K++)
                    {
                        C_Campo Nuevo = new C_Campo(Titulos[K], Valores[K]);
                        pnSubcampos.Controls.Add(Nuevo);
                    }
                }
                else
                {
                    Ayudas.A_Dialogo.DialogoError("No existen parametros");
                }
            }
            else
            {
                Ayudas.A_Dialogo.DialogoError("Error de parametros");
            }
            #endregion ===================== DESCRIPCIÓN =====================

            // Validar las Fechas dadas
            if (Datos.Rows.Count == 0)
            {
                A_Dialogo.DialogoInformacion("No hay registros entre estas fechas, por favor selecciona otro rango de fechas");

                lblTitulo.Text = "";
                pnSubcampos.Controls.Clear();
                dgvResumen.Columns.Clear();
                dgvResultados.Columns.Clear();
                dgvResultados.Refresh();

                //tcGraficos.Controls.Clear();
            }
            else
            {
                #region ===================== CUADRO DE RESULTADOS =====================
                dgvResultados.Columns.Clear();
                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[0].HeaderText = "Código Asignatura";
                dgvResultados.Columns[1].HeaderText = "Nombre Asignatura";
                dgvResultados.Columns[2].HeaderText = "Porcentaje Temas Avanzados";
                dgvResultados.Columns[3].HeaderText = "Porcentaje Temas Faltantes";

                if (dgvResultados.Rows.Count <= 10)
                {
                    sbResultados.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = dgvResultados.Rows.Count * 26 + 81;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                else
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = 341;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    sbResultados.Visible = true;
                }

                #endregion ===================== CUADRO DE RESULTADOS =====================

                #region ===================== CUADRO DE RESUMEN =====================
                // Ocultar cuadro de resumen
                //pnInferior.Controls[2].Hide();
                if (pnContenedorCuadro.Visible)
                {
                    pnContenedorCuadro.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    this.Cuadricula.RowStyles[1].Height -= pnContenedorGraficos.Location.Y - pnContenedorCuadro.Location.Y;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                
                #endregion ===================== CUADRO DE RESUMEN =====================

                #region ===================== GRÁFICO =====================
                //tcGraficos.TabPages.Clear();
                /*
                Chart Grafico1 = new Chart
                {
                    Dock = DockStyle.Fill,
                    Palette = ChartColorPalette.Excel
                };

                TabPage tpGrafico1 = new TabPage("Gráfico 1");
                tpGrafico1.Controls.Add(Grafico1);

                Grafico1.Titles.Clear();
                Grafico1.Series.Clear();
                Grafico1.ChartAreas.Clear();

                Grafico1.Titles.Add("Avance de Asignatura");

                ChartArea areaGrafico1 = new ChartArea();

                // Propiedades de los ejes
                areaGrafico1.AxisX.Interval = 1;
                areaGrafico1.AxisX.Title = "Cód. Estudiante";
                areaGrafico1.AxisX.TitleFont = new Font("Montserrat Alternates", 12f, FontStyle.Bold);
                areaGrafico1.AxisX.LabelStyle.Font = new Font("Montserrat Alternates", 14f);
                areaGrafico1.AxisY.Title = "Cantidad";
                areaGrafico1.AxisY.TitleFont = new Font("Montserrat Alternates", 12f, FontStyle.Bold);
                areaGrafico1.AxisY.LabelStyle.Font = new Font("Montserrat Alternates", 11f);
                areaGrafico1.AxisX.MajorGrid.LineColor = Color.Red;
                areaGrafico1.AxisX.MajorGrid.Enabled = false;
                //areaGrafico2.AxisY.MajorGrid.Enabled = false;

                Grafico1.ChartAreas.Add(areaGrafico1);

                Series serie1 = new Series("TotalAsistencias")
                {
                    ChartType = SeriesChartType.StackedBar,
                    XValueMember = "CodEstudiante",
                    YValueMembers = "TotalAsistencias",
                    IsValueShownAsLabel = true,
                    MarkerSize = 14,
                    Font = new Font("Montserrat Alternates", 10f)
                };

                Series serie2 = new Series("TotalFaltas")
                {
                    ChartType = SeriesChartType.StackedBar,
                    XValueMember = "CodEstudiante",
                    YValueMembers = "TotalFaltas",
                    MarkerSize = 14,
                    Font = new Font("Montserrat Alternates", 11f)
                };

                Grafico1.Series.Add(serie1);
                Grafico1.Series.Add(serie2);

                Grafico1.DataSource = dgvResultados.DataSource;

                tcGraficos.TabPages.Add(tpGrafico1);
                */
                #endregion ===================== GRÁFICO =====================
            }
        }

        public void fnReporte7(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
        {
            LimpiarCampos();

            lblTitulo.Text = Titulo;

            if (Titulos.Length.Equals(Valores.Length))
            {
                if (Titulos.Length != 0)
                {
                    for (int K = 0; K < Titulos.Length; K++)
                    {
                        C_Campo Nuevo = new C_Campo(Titulos[K], Valores[K]);
                        pnSubcampos.Controls.Add(Nuevo);
                    }
                }
                else
                {
                    MessageBox.Show("No existen parametros");
                }
            }
            else
            {
                MessageBox.Show("Error de parametros");
            }

            if (Datos.Rows.Count == 0)
            {
                A_Dialogo.DialogoInformacion("No hay registros entre estas fechas, por favor selecciona otro rango de fechas");
            }
            else
            {
                dgvResultados.Columns.Clear();
                dgvResultados.DataSource = Datos;

                if (dgvResultados.Rows.Count <= 10)
                {
                    sbResultados.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = dgvResultados.Rows.Count * 26 + 81;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                else
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = 341;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    sbResultados.Visible = true;
                }
                
                if (!pnContenedorCuadro.Visible)
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    this.Cuadricula.RowStyles[1].Height += pnContenedorGraficos.Location.Y - pnContenedorCuadro.Location.Y;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorCuadro.Visible = true;
                }

                // Cuadro de resumen
                DataTable dtEstadisticos = (dgvResultados.DataSource as DataTable).Copy();

                Console.WriteLine(dtEstadisticos.Rows[0][3].ToString());
                Console.WriteLine(dtEstadisticos.Rows[0][3].GetType());
                Console.WriteLine(dtEstadisticos.Rows[0][4].ToString());
                Console.WriteLine(dtEstadisticos.Rows[0][4].GetType());
                var aaaa = dtEstadisticos.Rows[0][3].ToString();

                // Listas de valores
                List<double> Asistieron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(Convert.ToDecimal(x.Field<decimal>("PorcentajeAsistencias")))).ToList();
                List<double> Faltaron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(Convert.ToDecimal(x.Field<decimal>("PorcentajeFaltas")))).ToList();

                foreach (int i in Asistieron)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("-------------");

                foreach (int i in Faltaron)
                {
                    Console.WriteLine(i);
                }

                // Cuadro de resumen
                DataTable cuadroResumen = new DataTable();
                cuadroResumen.Columns.Add(" ");
                cuadroResumen.Columns.Add("Porcentaje de Asistencia");
                cuadroResumen.Columns.Add("Porcentaje de Falta");

                // Máximo
                cuadroResumen.Rows.Add("Máximo", Statistics.Maximum(Asistieron), Statistics.Maximum(Faltaron));

                // Mínimos
                cuadroResumen.Rows.Add("Mínimo", Statistics.Minimum(Asistieron), Statistics.Minimum(Faltaron));

                // Media
                cuadroResumen.Rows.Add("Media", String.Format("{0:0.00}", Statistics.Mean(Asistieron)) + " (" + String.Format("{0:0.00}", Statistics.Mean(Asistieron) / (Statistics.Mean(Asistieron) + Statistics.Mean(Faltaron)) * 100) + "%)", String.Format("{0:0.00}", Statistics.Mean(Faltaron)) + " (" + String.Format("{0:0.00}", Statistics.Mean(Faltaron) / (Statistics.Mean(Asistieron) + Statistics.Mean(Faltaron)) * 100) + "%)");

                // Mediana
                cuadroResumen.Rows.Add("Mediana", String.Format("{0:0.00}", Statistics.Median(Asistieron)), String.Format("{0:0.00}", Statistics.Median(Faltaron)));

                // Moda
                var modeAsistieron = Asistieron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                var modeFaltaron = Faltaron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                cuadroResumen.Rows.Add("Moda", modeAsistieron, modeFaltaron);

                // Varianza
                cuadroResumen.Rows.Add("Varianza", String.Format("{0:0.00}", Statistics.Variance(Asistieron)), String.Format("{0:0.00}", Statistics.Variance(Faltaron)));

                // Desviación Estándar
                var dvA = Statistics.StandardDeviation(Asistieron);
                var dvF = Statistics.StandardDeviation(Faltaron);
                cuadroResumen.Rows.Add("Desv. Estándar", String.Format("{0:0.00}", dvA), String.Format("{0:0.00}", dvF));

                dgvResumen.DataSource = cuadroResumen;

                // Gráficos
            }
        }

        public void fnReporte8(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistenciasEstudiantes, string CodEstudiante)
        {
            this.CriterioAsistenciasEstudiantes = CriterioAsistenciasEstudiantes;

            LimpiarCampos();

            lblTitulo.Text = Titulo;

            if (Titulos.Length.Equals(Valores.Length))
            {
                if (Titulos.Length != 0)
                {
                    for (int K = 0; K < Titulos.Length; K++)
                    {
                        C_Campo Nuevo = new C_Campo(Titulos[K], Valores[K]);
                        pnSubcampos.Controls.Add(Nuevo);
                    }
                }
                else
                {
                    MessageBox.Show("No existen parametros");
                }
            }
            else
            {
                MessageBox.Show("Error de parametros");
            }

            if (Datos.Rows.Count == 0)
            {
                A_Dialogo.DialogoInformacion("No hay registros entre estas fechas, por favor selecciona otro rango de fechas");
            }
            else
            {
                // Crear columna
                DataGridViewImageColumn btnVerReporte = new DataGridViewImageColumn
                {
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Frozen = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,
                    DividerWidth = 0,
                    FillWeight = 100,
                    MinimumWidth = 5,
                    Width = 1032
                };

                dgvResultados.Columns.Clear();
                dgvResultados.Columns.Add(btnVerReporte);
                dgvResultados.Columns[0].HeaderText = "Reporte Por Fechas";

                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[0].DisplayIndex = 4;


                if (dgvResultados.Rows.Count <= 10)
                {
                    sbResultados.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = dgvResultados.Rows.Count * 26 + 81;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                else
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = 341;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    sbResultados.Visible = true;
                }

                //if (pnContenedorCuadro.Visible)
                //{
                    pnContenedorCuadro.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    this.Cuadricula.RowStyles[1].Height -= pnContenedorGraficos.Location.Y - pnContenedorCuadro.Location.Y;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                //}

                // Gráficos
            }
        }

        public void fnReporte9(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, DataTable Resumen)
        {
            this.CriterioAsistenciasEstudiantes = "";

            // Limpiar los Antiguos Reportes
            LimpiarCampos();

            #region ===================== TÍTULO =====================
            // Cambiar el Título
            lblTitulo.Text = Titulo;
            #endregion ===================== TÍTULO =====================

            #region ===================== DESCRIPCIÓN =====================
            // Verificar que los Títulos y los Valores dados Coincidan
            if (Titulos.Length.Equals(Valores.Length))
            {
                if (Titulos.Length != 0)
                {
                    for (int K = 0; K < Titulos.Length; K++)
                    {
                        C_Campo Nuevo = new C_Campo(Titulos[K], Valores[K]);
                        pnSubcampos.Controls.Add(Nuevo);
                    }
                }
                else
                {
                    Ayudas.A_Dialogo.DialogoError("No existen parametros");
                }
            }
            else
            {
                Ayudas.A_Dialogo.DialogoError("Error de parametros");
            }
            #endregion ===================== DESCRIPCIÓN =====================

            // Validar las Fechas dadas
            if (Datos.Rows.Count == 0)
            {
                A_Dialogo.DialogoInformacion("No hay registros disponibles");

                lblTitulo.Text = "";
                pnSubcampos.Controls.Clear();
                dgvResumen.Columns.Clear();
                dgvResultados.Columns.Clear();
                dgvResultados.Refresh();

                //tcGraficos.Controls.Clear();
            }
            else
            {
                #region ===================== CUADRO DE RESULTADOS =====================
                dgvResultados.Columns.Clear();
                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[0].HeaderText = "Código Asignatura";
                dgvResultados.Columns[1].HeaderText = "Nombre Asignatura";
                dgvResultados.Columns[2].HeaderText = "Docente";
                dgvResultados.Columns[3].HeaderText = "Avance Completado";
                dgvResultados.Columns[4].HeaderText = "Avance que Falta";

                if (dgvResultados.Rows.Count <= 10)
                {
                    sbResultados.Visible = false;
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = dgvResultados.Rows.Count * 26 + 81;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                }
                else
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    pnContenedorResultados.Height = 341;
                    this.Cuadricula.RowStyles[1].Height = pnContenedorResultados.Height + pnContenedorCuadro.Height + pnContenedorGraficos.Height;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    sbResultados.Visible = true;
                }

                #endregion ===================== CUADRO DE RESULTADOS =====================

                #region ===================== CUADRO DE RESUMEN =====================
                if (!pnContenedorCuadro.Visible)
                {
                    pnContenedorCuadro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorGraficos.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    this.Cuadricula.RowStyles[1].Height += pnContenedorGraficos.Location.Y - pnContenedorCuadro.Location.Y;
                    this.Height = (int)this.Cuadricula.RowStyles[0].Height + (int)this.Cuadricula.RowStyles[1].Height + 73;

                    pnContenedorCuadro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    pnContenedorGraficos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pnContenedorCuadro.Visible = true;
                }

                // Listas de valores
                List<double> Avanzó = Resumen.AsEnumerable().Select(x => Convert.ToDouble(x.Field<int>("TemasAvanzados"))).ToList();
                List<double> Falta = Resumen.AsEnumerable().Select(x => Convert.ToDouble(x.Field<int>("TemasFaltantes"))).ToList();

                // Cuadro de resumen
                DataTable cuadroResumen = new DataTable();
                cuadroResumen.Columns.Add(" ");
                cuadroResumen.Columns.Add("Avance Completado");
                cuadroResumen.Columns.Add("Avance Faltante");

                // Máximos
                cuadroResumen.Rows.Add("Máximo", Statistics.Maximum(Avanzó), Statistics.Maximum(Falta));

                // Mínimos
                cuadroResumen.Rows.Add("Mínimo", Statistics.Minimum(Avanzó), Statistics.Minimum(Falta));

                // Media
                cuadroResumen.Rows.Add("Media", String.Format("{0:0.00}", Statistics.Mean(Avanzó)) + " (" + String.Format("{0:0.00}", Statistics.Mean(Avanzó) / (Statistics.Mean(Avanzó) + Statistics.Mean(Falta)) * 100) + "%)", String.Format("{0:0.00}", Statistics.Mean(Falta)) + " (" + String.Format("{0:0.00}", Statistics.Mean(Falta) / (Statistics.Mean(Avanzó) + Statistics.Mean(Falta)) * 100) + "%)");

                // Mediana
                cuadroResumen.Rows.Add("Mediana", String.Format("{0:0.00}", Statistics.Median(Avanzó)), String.Format("{0:0.00}", Statistics.Median(Falta)));

                // Moda
                var modeAsistieron = Avanzó.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                var modeFaltaron = Falta.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                cuadroResumen.Rows.Add("Moda", modeAsistieron, modeFaltaron);

                // Varianza
                cuadroResumen.Rows.Add("Varianza", String.Format("{0:0.00}", Statistics.Variance(Avanzó)), String.Format("{0:0.00}", Statistics.Variance(Falta)));

                // Desviación Estándar
                var dvA = Statistics.StandardDeviation(Avanzó);
                var dvF = Statistics.StandardDeviation(Falta);
                cuadroResumen.Rows.Add("Desv. Estándar", String.Format("{0:0.00}", dvA), String.Format("{0:0.00}", dvF));

                dgvResumen.DataSource = cuadroResumen;
                #endregion ===================== CUADRO DE RESUMEN =====================

                #region ===================== GRÁFICO =====================
                //tcGraficos.TabPages.Clear();
                /*
                Chart Grafico1 = new Chart
                {
                    Dock = DockStyle.Fill,
                    Palette = ChartColorPalette.Excel
                };

                TabPage tpGrafico1 = new TabPage("Gráfico 1");
                tpGrafico1.Controls.Add(Grafico1);

                Grafico1.Titles.Clear();
                Grafico1.Series.Clear();
                Grafico1.ChartAreas.Clear();

                Grafico1.Titles.Add("Avance de Asignatura");

                ChartArea areaGrafico1 = new ChartArea();

                // Propiedades de los ejes
                areaGrafico1.AxisX.Interval = 1;
                areaGrafico1.AxisX.Title = "Cód. Estudiante";
                areaGrafico1.AxisX.TitleFont = new Font("Montserrat Alternates", 12f, FontStyle.Bold);
                areaGrafico1.AxisX.LabelStyle.Font = new Font("Montserrat Alternates", 14f);
                areaGrafico1.AxisY.Title = "Cantidad";
                areaGrafico1.AxisY.TitleFont = new Font("Montserrat Alternates", 12f, FontStyle.Bold);
                areaGrafico1.AxisY.LabelStyle.Font = new Font("Montserrat Alternates", 11f);
                areaGrafico1.AxisX.MajorGrid.LineColor = Color.Red;
                areaGrafico1.AxisX.MajorGrid.Enabled = false;
                //areaGrafico2.AxisY.MajorGrid.Enabled = false;

                Grafico1.ChartAreas.Add(areaGrafico1);

                Series serie1 = new Series("TotalAsistencias")
                {
                    ChartType = SeriesChartType.StackedBar,
                    XValueMember = "CodEstudiante",
                    YValueMembers = "TotalAsistencias",
                    IsValueShownAsLabel = true,
                    MarkerSize = 14,
                    Font = new Font("Montserrat Alternates", 10f)
                };

                Series serie2 = new Series("TotalFaltas")
                {
                    ChartType = SeriesChartType.StackedBar,
                    XValueMember = "CodEstudiante",
                    YValueMembers = "TotalFaltas",
                    MarkerSize = 14,
                    Font = new Font("Montserrat Alternates", 11f)
                };

                Grafico1.Series.Add(serie1);
                Grafico1.Series.Add(serie2);

                Grafico1.DataSource = dgvResultados.DataSource;

                tcGraficos.TabPages.Add(tpGrafico1);
                */
                #endregion ===================== GRÁFICO =====================
            }
        }

        private void dgvResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0) && this.CriterioAsistenciasEstudiantes != "")
            {
                if (CriterioAsistenciasEstudiantes == "Por Fechas")
                {
                    MessageBox.Show("Por Fechas");
                }
                if (CriterioAsistenciasEstudiantes == "Por Estudiantes")
                {
                    MessageBox.Show("Por Estudiantes");
                }
                else if (CriterioAsistenciasEstudiantes == "Por Asignaturas")
                {
                    MessageBox.Show("Por Asignaturas");
                }
            }
        }

        private void btnGrafico1_Click(object sender, EventArgs e)
        {
            tcGraficos.SetPage(IndiceGrafico1);
        }

        private void btnGrafico2_Click(object sender, EventArgs e)
        {
            tcGraficos.SetPage(IndiceGrafico2);
        }
    }
}