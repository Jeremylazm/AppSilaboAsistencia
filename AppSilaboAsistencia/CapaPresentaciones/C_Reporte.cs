﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;
using Ayudas;
using System.IO;
using ClosedXML.Excel;
using CapaNegocios;
using ControlesPerzonalizados;
using System.Globalization;

namespace CapaPresentaciones
{
    public partial class C_Reporte : UserControl
    {
        private string CriterioAsistenciasEstudiantes;
        private string CriterioAsistenciasDocentes;
        readonly N_Catalogo ObjCatalogo;
        private int IndiceGrafico1 = 0;
        private int IndiceGrafico2 = 1;

        public C_Reporte()
        {
            ObjCatalogo = new N_Catalogo();
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvResultados, sbResultados);

            dgvResultados.CellMouseEnter += new DataGridViewCellEventHandler(dgvResultados_CellMouseEnter);
        }

        void dataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            int currentIndex = this.dgvResultados.FirstDisplayedScrollingRowIndex;
            int scrollLines = SystemInformation.MouseWheelScrollLines;

            if (e.Delta > 0)
            {
                this.dgvResultados.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
                this.sbResultados.Value = Math.Max(0, currentIndex - scrollLines);
            }
            else if (e.Delta < 0)
            {
                this.dgvResultados.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
                this.sbResultados.Value = currentIndex + scrollLines;
            }
        }

        public void LimpiarCampos()
        {
            pnSubcampos.Controls.Clear();
        }
        private string AccesoReportes = "";
        public C_Reporte(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistencia, string CodAsignatura, string AccesoReporte)
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvResultados, sbResultados);
            AccesoReportes = AccesoReporte;
            dgvResultados.CellMouseEnter += new DataGridViewCellEventHandler(dgvResultados_CellMouseEnter);
            if (AccesoReporte == "Jefe de Departamento")
            {
                fnReporte10(Titulo, Titulos, Valores, Datos, CriterioAsistencia, CodAsignatura);
            }
            else
            {
                fnReporte1(Titulo, Titulos, Valores, Datos, CriterioAsistencia, CodAsignatura);
            }

            
        }

        public C_Reporte(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string Criterio)
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvResultados, sbResultados);

            dgvResultados.CellMouseEnter += new DataGridViewCellEventHandler(dgvResultados_CellMouseEnter);

            if (Criterio == "Por Fechas")
            {
                fnReporte2(Titulo, Titulos, Valores, Datos);
                tcGraficos.SetPage(IndiceGrafico1);
            }
            else if (Criterio == "Por Estudiantes")
            {
                fnReporte4(Titulo, Titulos, Valores, Datos);
                tcGraficos.SetPage(IndiceGrafico1);
            }
            else if (Criterio == "Por Asignaturas")
            {
                fnReporte4(Titulo, Titulos, Valores, Datos);
                tcGraficos.SetPage(IndiceGrafico1);
            }
            else if (Criterio == "Por Asignaturas D")
            {
                fnReporte11(Titulo, Titulos, Valores, Datos);
                tcGraficos.SetPage(IndiceGrafico1);
            }
            else if (Criterio == "Por Fechas D")
            {
                fnReporte15(Titulo, Titulos, Valores, Datos);
                tcGraficos.SetPage(IndiceGrafico1);
            }
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
                    Width = 1032,
                    Image = Properties.Resources.Mostrar
                };

                dgvResultados.Columns.Clear();
                dgvResultados.Columns.Add(btnVerReporte);
                dgvResultados.Columns[0].HeaderText = "Ver Reporte";

                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[6].Visible = false;
                dgvResultados.Columns[0].DisplayIndex = 6;

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
                gxGrafico1.XAxesLabel = "Cantidad";
                gxGrafico1.YAxesLabel = "Fecha";

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

                DataTable dtEstadisticos2 = dtEstadisticos.AsEnumerable().Reverse().CopyToDataTable();

                foreach (DataRow Fila in dtEstadisticos2.Rows)
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

                GraficoLineas.Label = "Total Asistieron (%)";
                GraficoLineas.Data = Datos1B;

                GraficoLineas.TargetCanvas = gxGrafico2;

                gxGrafico2.Update();

                tcGraficos.SetPage(IndiceGrafico1);
            }
        }

        public void fnReporte2(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
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

            dgvResultados.Columns.Clear();

            dgvResultados.DataSource = Datos;
            dgvResultados.Columns[0].Visible = false;           

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

            DataTable dtResumen = (dgvResultados.DataSource as DataTable).Copy();

            // Cuadro de resumen
            DataTable cuadroResumen = new DataTable();
            cuadroResumen.Columns.Add(" ");
            cuadroResumen.Columns.Add("Cantidad");

            double Total = dtResumen.Rows.Count;
            double AsistieronPuntual = 0;
            double AsistieronTarde = 0;
            double FaltaronJustificado = 0;
            double FaltaronSinJustificar = 0;

            foreach (DataRow row in dtResumen.Rows)
            {
                if (row["Asistió"].ToString() == "SI" && row["Observación"].ToString() == "")
                {
                    AsistieronPuntual += 1;
                }
                else if (row["Asistió"].ToString() == "SI" && row["Observación"].ToString() != "")
                {
                    AsistieronTarde += 1;
                }
                else if (row["Asistió"].ToString() == "NO" && row["Observación"].ToString() != "FALTO SIN JUSTIFICAR" && row["Observación"].ToString() != "FERIADO" && row["Observación"].ToString() != "SUSPENSION" && row["Observación"].ToString() != "FALTO EL DOCENTE")
                {
                    FaltaronJustificado += 1;
                }
                else if (row["Asistió"].ToString() == "NO" && row["Observación"].ToString() == "FALTO SIN JUSTIFICAR")
                {
                    FaltaronSinJustificar += 1;
                }
            }

            // Asistieron puntual
            cuadroResumen.Rows.Add("Asistieron Puntual", AsistieronPuntual.ToString() + " (" + String.Format("{0:0.00}", AsistieronPuntual / Total * 100) + "%)");

            // Asistieron tarde
            cuadroResumen.Rows.Add("Asistieron Tarde", AsistieronTarde.ToString() + " (" + String.Format("{0:0.00}", AsistieronTarde / Total * 100) + "%)");

            // Faltaron (Justificado)
            cuadroResumen.Rows.Add("Faltaron (Justificado)", FaltaronJustificado.ToString() + " (" + String.Format("{0:0.00}", FaltaronJustificado / Total * 100) + "%)");

            // Faltaron (Sin justificar)
            cuadroResumen.Rows.Add("Faltaron (Sin Justificar)", FaltaronSinJustificar.ToString() + " (" + String.Format("{0:0.00}", FaltaronSinJustificar / Total * 100) + "%)");

            cuadroResumen.Rows.Add("", "");

            // Asistencias
            cuadroResumen.Rows.Add("Asistencias", (AsistieronPuntual + AsistieronTarde).ToString() + " (" + String.Format("{0:0.00}", (AsistieronPuntual + AsistieronTarde) / Total * 100) + "%)");

            // Faltas
            cuadroResumen.Rows.Add("Faltas", (FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + String.Format("{0:0.00}", (FaltaronJustificado + FaltaronSinJustificar) / Total * 100) + "%)");

            // Total
            cuadroResumen.Rows.Add("Total", (AsistieronPuntual + AsistieronTarde + FaltaronJustificado + FaltaronSinJustificar) + " (" + "100" + "%)");

            dgvResumen.DataSource = cuadroResumen;

            // Gráficos
            btnGrafico2.Visible = true;
            IndiceGrafico1 = 2;

            // Gráfico 1
            gxGrafico3.XAxesLabel = "";
            gxGrafico3.LegendDisplay = false;
            gxGrafico3.YAxesLabel = "Cantidad";

            List<string> EtiquetasA = new List<string>();
            List<double> Datos1A = new List<double>();
            List<Color> Colores1A = new List<Color>();

            Datos1A.Add(AsistieronPuntual + AsistieronTarde);
            Datos1A.Add(FaltaronJustificado + FaltaronSinJustificar);
            Colores1A.Add(Color.FromArgb(104, 13, 15));
            Colores1A.Add(Color.FromArgb(232, 158, 31));

            EtiquetasA.Add("Total Asistieron");
            EtiquetasA.Add("Total Faltaron");

            gxGrafico3.Labels = EtiquetasA.ToArray();
            gxGrafico3.Clear();
            
            GraficoBarrasVerticales.Label = "";
            GraficoBarrasVerticales.Data = Datos1A;
            GraficoBarrasVerticales.BackgroundColor = Colores1A;

            GraficoBarrasVerticales.TargetCanvas = gxGrafico3;

            gxGrafico3.Update();

            // Gráfico 2
            IndiceGrafico2 = 3;

            gxGrafico4.XAxesLabel = "";
            gxGrafico4.YAxesLabel = "";

            List<string> EtiquetasB = new List<string>();
            List<double> Datos1B = new List<double>();
            List<Color> Color1B = new List<Color>();

            EtiquetasB.Add("Asistieron Puntual");
            EtiquetasB.Add("Asistieron Tarde");
            EtiquetasB.Add("Faltaron (Justificado)");
            EtiquetasB.Add("Faltaron (Sin Justificar)");

            Datos1B.Add(AsistieronPuntual);
            Datos1B.Add(AsistieronTarde);
            Datos1B.Add(FaltaronJustificado);
            Datos1B.Add(FaltaronSinJustificar);

            Color1B.Add(Color.FromArgb(23, 153, 75));
            Color1B.Add(Color.FromArgb(117, 163, 229));
            Color1B.Add(Color.FromArgb(232, 128, 31));
            Color1B.Add(Color.FromArgb(104, 13, 15));

            gxGrafico4.Labels = EtiquetasB.ToArray();
            gxGrafico4.Clear();

            GraficoCircular.Label = "";
            GraficoCircular.Data = Datos1B;
            GraficoCircular.BackgroundColor = Color1B;

            GraficoCircular.TargetCanvas = gxGrafico4;

            gxGrafico4.Update();
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
                    MessageBox.Show("No existen parámetros");
                }
            }
            else
            {
                MessageBox.Show("Error de parámetros");
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
                    Width = 1032,
                    Image = Properties.Resources.Mostrar
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
                gxGrafico1.XAxesLabel = "Cantidad";
                gxGrafico1.YAxesLabel = "Código Estudiante";

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

                tcGraficos.SetPage(IndiceGrafico1);
            }
        }

        public void fnReporte4(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
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

            dgvResultados.Columns.Clear();

            dgvResultados.DataSource = Datos;
            //dgvResultados.Columns[0].DisplayIndex = 7;

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

            DataTable dtResumen = (dgvResultados.DataSource as DataTable).Copy();

            // Cuadro de resumen
            DataTable cuadroResumen = new DataTable();
            cuadroResumen.Columns.Add(" ");
            cuadroResumen.Columns.Add("Cantidad");

            double AsistieronPuntual = 0;
            double AsistieronTarde = 0;
            double FaltaronJustificado = 0;
            double FaltaronSinJustificar = 0;

            foreach (DataRow Fila in dtResumen.Rows)
            {
                if (Fila["Asistió"].ToString() == "SI" && Fila["Observación"].ToString() == "")
                {
                    AsistieronPuntual += 1;
                }
                else if (Fila["Asistió"].ToString() == "SI" && Fila["Observación"].ToString() != "")
                {
                    AsistieronTarde += 1;
                }
                else if (Fila["Asistió"].ToString() == "NO" && Fila["Observación"].ToString() != "FALTO SIN JUSTIFICAR" && Fila["Observación"].ToString() != "FERIADO" && Fila["Observación"].ToString() != "SUSPENSION" && Fila["Observación"].ToString() != "FALTO EL DOCENTE")
                {
                    FaltaronJustificado += 1;
                }
                else if (Fila["Asistió"].ToString() == "NO" && Fila["Observación"].ToString() == "FALTO SIN JUSTIFICAR")
                {
                    FaltaronSinJustificar += 1;
                }
            }

            double Total = AsistieronPuntual + AsistieronTarde + FaltaronJustificado + FaltaronSinJustificar;

            // Asistieron puntual
            cuadroResumen.Rows.Add("Asistencia Puntual", AsistieronPuntual.ToString() + " (" + String.Format("{0:0.00}", AsistieronPuntual / Total * 100) + "%)");

            // Asistieron tarde
            cuadroResumen.Rows.Add("Asistencia Tarde", AsistieronTarde.ToString() + " (" + String.Format("{0:0.00}", AsistieronTarde / Total * 100) + "%)");

            // Faltaron (Justificado)
            cuadroResumen.Rows.Add("Falta (Justificada)", FaltaronJustificado.ToString() + " (" + String.Format("{0:0.00}", FaltaronJustificado / Total * 100) + "%)");

            // Faltaron (Sin justificar)
            cuadroResumen.Rows.Add("Falta (Sin Justificar)", FaltaronSinJustificar.ToString() + " (" + String.Format("{0:0.00}", FaltaronSinJustificar / Total * 100) + "%)");

            cuadroResumen.Rows.Add("", "");

            // Asistencias
            cuadroResumen.Rows.Add("Asistencias", (AsistieronPuntual + AsistieronTarde).ToString() + " (" + String.Format("{0:0.00}", (AsistieronPuntual + AsistieronTarde) / Total * 100) + "%)");

            // Faltas
            cuadroResumen.Rows.Add("Faltas", (FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + String.Format("{0:0.00}", (FaltaronJustificado + FaltaronSinJustificar) / Total * 100) + "%)");

            // Total
            cuadroResumen.Rows.Add("Total", (AsistieronPuntual + AsistieronTarde + FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + "100" + "%)");

            dgvResumen.DataSource = cuadroResumen;

            // Gráficos // Barras verticales y Pie
            btnGrafico2.Visible = true;
            IndiceGrafico1 = 2;

            // Gráfico 1
            gxGrafico3.XAxesLabel = "";
            gxGrafico3.LegendDisplay = false;
            gxGrafico3.YAxesLabel = "Cantidad";

            List<string> EtiquetasA = new List<string>();
            List<double> Datos1A = new List<double>();
            List<Color> Colores1A = new List<Color>();

            Datos1A.Add(AsistieronPuntual + AsistieronTarde);
            Datos1A.Add(FaltaronJustificado + FaltaronSinJustificar);
            Colores1A.Add(Color.FromArgb(104, 13, 15));
            Colores1A.Add(Color.FromArgb(232, 158, 31));

            EtiquetasA.Add("Total Asistencias");
            EtiquetasA.Add("Total Faltas");

            gxGrafico3.Labels = EtiquetasA.ToArray();
            gxGrafico3.Clear();

            GraficoBarrasVerticales.Label = "";
            GraficoBarrasVerticales.Data = Datos1A;
            GraficoBarrasVerticales.BackgroundColor = Colores1A;

            GraficoBarrasVerticales.TargetCanvas = gxGrafico3;

            gxGrafico3.Update();

            // Gráfico 2
            IndiceGrafico2 = 3;

            gxGrafico4.XAxesLabel = "";
            gxGrafico4.YAxesLabel = "";

            List<string> EtiquetasB = new List<string>();
            List<double> Datos1B = new List<double>();
            List<Color> Color1B = new List<Color>();

            EtiquetasB.Add("Asistencia Puntual");
            EtiquetasB.Add("Asistencia Tarde");
            EtiquetasB.Add("Falta (Justificada)");
            EtiquetasB.Add("Falta (Sin Justificar)");

            Datos1B.Add(AsistieronPuntual);
            Datos1B.Add(AsistieronTarde);
            Datos1B.Add(FaltaronJustificado);
            Datos1B.Add(FaltaronSinJustificar);

            Color1B.Add(Color.FromArgb(23, 153, 75));
            Color1B.Add(Color.FromArgb(117, 163, 229));
            Color1B.Add(Color.FromArgb(232, 128, 31));
            Color1B.Add(Color.FromArgb(104, 13, 15));
            
            gxGrafico4.Labels = EtiquetasB.ToArray();
            gxGrafico4.Clear();

            GraficoCircular.Label = "";
            GraficoCircular.Data = Datos1B;
            GraficoCircular.BackgroundColor = Color1B;

            GraficoCircular.TargetCanvas = gxGrafico4;

            gxGrafico4.Update();
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
                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 3;

                // Grafico 1
                gxGrafico4.XAxesLabel = "";
                gxGrafico4.YAxesLabel = "";

                List<string> EtiquetasB = new List<string>();
                List<double> Datos1B = new List<double>();
                List<Color> Color1B = new List<Color>();

                EtiquetasB.Add("Avance Completado (%)");
                EtiquetasB.Add("Avance Faltante (%)");

                Datos1B.Add(Completado);
                Datos1B.Add(Faltante);

                Color1B.Add(Color.FromArgb(104, 13, 15));
                Color1B.Add(Color.FromArgb(232, 158, 31));

                gxGrafico4.Labels = EtiquetasB.ToArray();
                gxGrafico4.Clear();

                GraficoCircular.Label = "";
                GraficoCircular.Data = Datos1B;
                GraficoCircular.BackgroundColor = Color1B;

                GraficoCircular.TargetCanvas = gxGrafico4;

                gxGrafico4.Update();
                tcGraficos.SetPage(IndiceGrafico1);
                #endregion ===================== GRÁFICO =====================
            }
        }

        public void fnReporte6(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, DataTable DatosGrafico, string CodAsignatura)
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
                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 4;

                // Grafico 1
                gxGrafico5.XAxesLabel = "";
                gxGrafico5.YAxesLabel = "Cantidad";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                for (int i = 0; i < DatosGrafico.Rows.Count; i++)
                {
                    EtiquetasA.Add(DatosGrafico.Rows[i]["CodAsignatura"].ToString());
                    Datos1A.Add(Convert.ToInt32(DatosGrafico.Rows[i]["TemasAvanzados"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));                    

                    Datos2A.Add(Convert.ToInt32(DatosGrafico.Rows[i]["TemasFaltantes"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico5.Labels = EtiquetasA.ToArray();
                gxGrafico5.Clear();

                GraficoBarrasCompletas1.Label = "Temas Avanzados";
                GraficoBarrasCompletas1.Data = Datos1A;
                GraficoBarrasCompletas1.BackgroundColor = Colores1A;

                GraficoBarrasCompletas2.Label = "Temas Faltantes";
                GraficoBarrasCompletas2.Data = Datos2A;
                GraficoBarrasCompletas2.BackgroundColor = Colores2A;

                GraficoBarrasCompletas1.TargetCanvas = gxGrafico5;
                GraficoBarrasCompletas2.TargetCanvas = gxGrafico5;

                gxGrafico5.Update();
                tcGraficos.SetPage(IndiceGrafico1);
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

                // Listas de valores
                List<double> Asistieron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<double>("PorcentajeAsistencias"))).ToList();
                List<double> Faltaron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<double>("PorcentajeFaltas"))).ToList();

                // Cuadro de resumen
                DataTable cuadroResumen = new DataTable();
                cuadroResumen.Columns.Add(" ");
                cuadroResumen.Columns.Add("Asistencia");
                cuadroResumen.Columns.Add("Falta");

                // Máximo
                cuadroResumen.Rows.Add("Máximo", Statistics.Maximum(Asistieron).ToString() + " %", Statistics.Maximum(Faltaron).ToString() + " %");

                // Mínimos
                cuadroResumen.Rows.Add("Mínimo", String.Format("{0:0.00}", Statistics.Minimum(Asistieron)) + " %", String.Format("{0:0.00}", Statistics.Minimum(Faltaron)) + " %");

                // Media
                cuadroResumen.Rows.Add("Media", String.Format("{0:0.00}", Statistics.Mean(Asistieron)) + " %", String.Format("{0:0.00}", Statistics.Mean(Faltaron)) + " %");

                // Mediana
                cuadroResumen.Rows.Add("Mediana", String.Format("{0:0.00}", Statistics.Median(Asistieron)) + " %", String.Format("{0:0.00}", Statistics.Median(Faltaron)) + " %");

                // Moda
                var modeAsistieron = Asistieron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                var modeFaltaron = Faltaron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                cuadroResumen.Rows.Add("Moda", String.Format("{0:0.00}", modeAsistieron) + " %", String.Format("{0:0.00}", modeFaltaron) + " %");

                // Varianza
                cuadroResumen.Rows.Add("Varianza", String.Format("{0:0.00}", Statistics.Variance(Asistieron)), String.Format("{0:0.00}", Statistics.Variance(Faltaron)));

                // Desviación Estándar
                var dvA = Statistics.StandardDeviation(Asistieron);
                var dvF = Statistics.StandardDeviation(Faltaron);
                cuadroResumen.Rows.Add("Desv. Estándar", String.Format("{0:0.00}", dvA), String.Format("{0:0.00}", dvF));

                dgvResumen.DataSource = cuadroResumen;

                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 0;

                // Gráfico 1
                gxGrafico1.XAxesLabel = "Porcentaje";
                gxGrafico1.YAxesLabel = "Código Asignatura";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                foreach (DataRow Fila in dtEstadisticos.Rows)
                {
                    EtiquetasA.Add(Fila["CodAsignatura"].ToString());
                    Datos1A.Add(double.Parse(Fila["PorcentajeAsistencias"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));
                    Datos2A.Add(double.Parse(Fila["PorcentajeFaltas"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico1.Labels = EtiquetasA.ToArray();
                gxGrafico1.Clear();

                GraficoBarrasHorizontales1.Label = "Asistencias (%)";
                GraficoBarrasHorizontales1.Data = Datos1A;
                GraficoBarrasHorizontales1.BackgroundColor = Colores1A;

                GraficoBarrasHorizontales2.Label = "Faltas (%)";
                GraficoBarrasHorizontales2.Data = Datos2A;
                GraficoBarrasHorizontales2.BackgroundColor = Colores2A;

                GraficoBarrasHorizontales1.TargetCanvas = gxGrafico1;
                GraficoBarrasHorizontales2.TargetCanvas = gxGrafico1;

                gxGrafico1.Update();

                tcGraficos.SetPage(IndiceGrafico1);
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
                    Width = 1032,
                    Image = Properties.Resources.Mostrar
                };

                dgvResultados.Columns.Clear();
                dgvResultados.Columns.Add(btnVerReporte);
                dgvResultados.Columns[0].HeaderText = "Reporte Por Fechas";

                dgvResultados.DataSource = Datos;
                dgvResultados.Columns[3].Visible = false;
                dgvResultados.Columns[4].Visible = false;
                dgvResultados.Columns[0].DisplayIndex = 6;


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

                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 4;

                // Gráfico 1
                gxGrafico5.XAxesLabel = "";
                gxGrafico5.YAxesLabel = "Porcentaje";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                foreach (DataRow Fila in Datos.Rows)
                {
                    EtiquetasA.Add(Fila["CodAsignatura"].ToString());
                    Datos1A.Add(double.Parse(Fila["PorcentajeAsistencias"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));
                    Datos2A.Add(double.Parse(Fila["PorcentajeFaltas"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico5.Labels = EtiquetasA.ToArray();
                gxGrafico5.Clear();

                GraficoBarrasCompletas1.Label = "Asistencias (%)";
                GraficoBarrasCompletas1.Data = Datos1A;
                GraficoBarrasCompletas1.BackgroundColor = Colores1A;

                GraficoBarrasCompletas2.Label = "Faltas (%)";
                GraficoBarrasCompletas2.Data = Datos2A;
                GraficoBarrasCompletas2.BackgroundColor = Colores2A;

                GraficoBarrasCompletas1.TargetCanvas = gxGrafico5;
                GraficoBarrasCompletas2.TargetCanvas = gxGrafico5;

                gxGrafico5.Update();
                tcGraficos.SetPage(IndiceGrafico1);
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
                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 0;

                // Grafico 1
                gxGrafico1.XAxesLabel = "Cantidad";
                gxGrafico1.YAxesLabel = "Fecha";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                foreach (DataRow Fila in Resumen.Rows)
                {
                    EtiquetasA.Add(Fila["CodAsignatura"].ToString());
                    Datos1A.Add(double.Parse(Fila["TemasAvanzados"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));
                    Datos2A.Add(double.Parse(Fila["TemasFaltantes"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico1.Labels = EtiquetasA.ToArray();
                gxGrafico1.Clear();

                GraficoBarrasHorizontales1.Label = "Avance Completado";
                GraficoBarrasHorizontales1.Data = Datos1A;
                GraficoBarrasHorizontales1.BackgroundColor = Colores1A;

                GraficoBarrasHorizontales2.Label = "Avance Faltante";
                GraficoBarrasHorizontales2.Data = Datos2A;
                GraficoBarrasHorizontales2.BackgroundColor = Colores2A;

                GraficoBarrasHorizontales1.TargetCanvas = gxGrafico1;
                GraficoBarrasHorizontales2.TargetCanvas = gxGrafico1;

                gxGrafico1.Update();
                tcGraficos.SetPage(IndiceGrafico1);
                #endregion ===================== GRÁFICO =====================
            }
        }

        public void fnReporte10(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistenciasDocentes, string CodAsignatura)
        {
            this.CriterioAsistenciasDocentes = CriterioAsistenciasDocentes;

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
                    Width = 1032,
                    Image = Properties.Resources.Mostrar
                };

                dgvResultados.Columns.Clear();
                dgvResultados.Columns.Add(btnVerReporte);
                dgvResultados.Columns[0].HeaderText = "Ver Reporte";

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

                // Ocultar cuadro de resumen
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

                #region ===================== GRÁFICO =====================
                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 4;

                // Gráfico 1
                gxGrafico5.XAxesLabel = "";
                gxGrafico5.YAxesLabel = "Porcentaje";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                foreach (DataRow Fila in Datos.Rows)
                {
                    EtiquetasA.Add(Fila["CodAsignatura"].ToString());
                    Datos1A.Add(double.Parse(Fila["PorcentajeAsistencias"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));
                    Datos2A.Add(double.Parse(Fila["PorcentajeFaltas"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico5.Labels = EtiquetasA.ToArray();
                gxGrafico5.Clear();

                GraficoBarrasCompletas1.Label = "Asistencias (%)";
                GraficoBarrasCompletas1.Data = Datos1A;
                GraficoBarrasCompletas1.BackgroundColor = Colores1A;

                GraficoBarrasCompletas2.Label = "Faltas (%)";
                GraficoBarrasCompletas2.Data = Datos2A;
                GraficoBarrasCompletas2.BackgroundColor = Colores2A;

                GraficoBarrasCompletas1.TargetCanvas = gxGrafico5;
                GraficoBarrasCompletas2.TargetCanvas = gxGrafico5;

                gxGrafico5.Update();
                tcGraficos.SetPage(IndiceGrafico1);
                #endregion ===================== GRÁFICO =====================

            }
        }

        public void fnReporte11(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
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

            dgvResultados.Columns.Clear();

            dgvResultados.DataSource = Datos;
            //dgvResultados.Columns[0].DisplayIndex = 7;

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

            DataTable dtResumen = (dgvResultados.DataSource as DataTable).Copy();

            // Cuadro de resumen
            DataTable cuadroResumen = new DataTable();
            cuadroResumen.Columns.Add(" ");
            cuadroResumen.Columns.Add("Cantidad");

            double AsistieronPuntual = 0;
            double AsistieronTarde = 0;
            double FaltaronJustificado = 0;
            double FaltaronSinJustificar = 0;

            foreach (DataRow Fila in dtResumen.Rows)
            {
                if (Fila["Asistió"].ToString() == "SI" && Fila["Observación"].ToString() == "")
                {
                    AsistieronPuntual += 1;
                }
                else if (Fila["Asistió"].ToString() == "SI" && Fila["Observación"].ToString() != "")
                {
                    
                }
                else if (Fila["Asistió"].ToString() == "NO" && Fila["Observación"].ToString() == "FALTO SIN JUSTIFICAR")
                {
                    FaltaronSinJustificar += 1;
                }
                else if (Fila["Asistió"].ToString() == "NO" && Fila["Observación"].ToString() != "FALTO SIN JUSTIFICAR")
                {
                    FaltaronJustificado += 1;
                }
                
            }

            double Total = AsistieronPuntual + AsistieronTarde + FaltaronJustificado + FaltaronSinJustificar;

            // Asistieron puntual
            cuadroResumen.Rows.Add("Asistencia Puntual", AsistieronPuntual.ToString() + " (" + String.Format("{0:0.00}", AsistieronPuntual / Total * 100) + "%)");

            // Asistieron tarde
            //cuadroResumen.Rows.Add("Asistencia Tarde", AsistieronTarde.ToString() + " (" + String.Format("{0:0.00}", AsistieronTarde / Total * 100) + "%)");

            // Faltaron (Justificado)
            cuadroResumen.Rows.Add("Falta (Justificada)", FaltaronJustificado.ToString() + " (" + String.Format("{0:0.00}", FaltaronJustificado / Total * 100) + "%)");

            // Faltaron (Sin justificar)
            cuadroResumen.Rows.Add("Falta (Sin Justificar)", FaltaronSinJustificar.ToString() + " (" + String.Format("{0:0.00}", FaltaronSinJustificar / Total * 100) + "%)");

            cuadroResumen.Rows.Add("", "");

            // Asistencias
            cuadroResumen.Rows.Add("Asistencias", (AsistieronPuntual + AsistieronTarde).ToString() + " (" + String.Format("{0:0.00}", (AsistieronPuntual + AsistieronTarde) / Total * 100) + "%)");

            // Faltas
            cuadroResumen.Rows.Add("Faltas", (FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + String.Format("{0:0.00}", (FaltaronJustificado + FaltaronSinJustificar) / Total * 100) + "%)");

            // Total
            cuadroResumen.Rows.Add("Total", (AsistieronPuntual + AsistieronTarde + FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + "100" + "%)");

            dgvResumen.DataSource = cuadroResumen;

            // Gráficos // Barras verticales y Pie
            btnGrafico2.Visible = true;
            IndiceGrafico1 = 2;

            // Gráfico 1
            gxGrafico3.XAxesLabel = "";
            gxGrafico3.LegendDisplay = false;
            gxGrafico3.YAxesLabel = "Cantidad";

            List<string> EtiquetasA = new List<string>();
            List<double> Datos1A = new List<double>();
            List<Color> Colores1A = new List<Color>();

            Datos1A.Add(AsistieronPuntual + AsistieronTarde);
            Datos1A.Add(FaltaronJustificado + FaltaronSinJustificar);
            Colores1A.Add(Color.FromArgb(104, 13, 15));
            Colores1A.Add(Color.FromArgb(232, 158, 31));

            EtiquetasA.Add("Total Asistencias");
            EtiquetasA.Add("Total Faltas");

            gxGrafico3.Labels = EtiquetasA.ToArray();
            gxGrafico3.Clear();

            GraficoBarrasVerticales.Label = "";
            GraficoBarrasVerticales.Data = Datos1A;
            GraficoBarrasVerticales.BackgroundColor = Colores1A;

            GraficoBarrasVerticales.TargetCanvas = gxGrafico3;

            gxGrafico3.Update();

            // Gráfico 2
            IndiceGrafico2 = 3;

            gxGrafico4.XAxesLabel = "";
            gxGrafico4.YAxesLabel = "";

            List<string> EtiquetasB = new List<string>();
            List<double> Datos1B = new List<double>();
            List<Color> Color1B = new List<Color>();

            EtiquetasB.Add("Asistencia Puntual");
            //EtiquetasB.Add("Asistencia Tarde");
            EtiquetasB.Add("Falta (Justificada)");
            EtiquetasB.Add("Falta (Sin Justificar)");

            Datos1B.Add(AsistieronPuntual);
            //Datos1B.Add(AsistieronTarde);
            Datos1B.Add(FaltaronJustificado);
            Datos1B.Add(FaltaronSinJustificar);

            Color1B.Add(Color.FromArgb(23, 153, 75));
            Color1B.Add(Color.FromArgb(117, 163, 229));
            Color1B.Add(Color.FromArgb(232, 128, 31));
            Color1B.Add(Color.FromArgb(104, 13, 15));

            gxGrafico4.Labels = EtiquetasB.ToArray();
            gxGrafico4.Clear();

            GraficoCircular.Label = "";
            GraficoCircular.Data = Datos1B;
            GraficoCircular.BackgroundColor = Color1B;

            GraficoCircular.TargetCanvas = gxGrafico4;

            gxGrafico4.Update();
        }
        public void fnReporte12(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
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

                // Listas de valores
                List<double> Asistieron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<double>("PorcentajeAsistencias"))).ToList();
                List<double> Faltaron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<double>("PorcentajeFaltas"))).ToList();

                // Cuadro de resumen
                DataTable cuadroResumen = new DataTable();
                cuadroResumen.Columns.Add(" ");
                cuadroResumen.Columns.Add("Asistencia");
                cuadroResumen.Columns.Add("Falta");

                // Máximo
                cuadroResumen.Rows.Add("Máximo", Statistics.Maximum(Asistieron).ToString() + " %", Statistics.Maximum(Faltaron).ToString() + " %");

                // Mínimos
                cuadroResumen.Rows.Add("Mínimo", String.Format("{0:0.00}", Statistics.Minimum(Asistieron)) + " %", String.Format("{0:0.00}", Statistics.Minimum(Faltaron)) + " %");

                // Media
                cuadroResumen.Rows.Add("Media", String.Format("{0:0.00}", Statistics.Mean(Asistieron)) + " %", String.Format("{0:0.00}", Statistics.Mean(Faltaron)) + " %");

                // Mediana
                cuadroResumen.Rows.Add("Mediana", String.Format("{0:0.00}", Statistics.Median(Asistieron)) + " %", String.Format("{0:0.00}", Statistics.Median(Faltaron)) + " %");

                // Moda
                var modeAsistieron = Asistieron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                var modeFaltaron = Faltaron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
                cuadroResumen.Rows.Add("Moda", String.Format("{0:0.00}", modeAsistieron) + " %", String.Format("{0:0.00}", modeFaltaron) + " %");

                // Varianza
                cuadroResumen.Rows.Add("Varianza", String.Format("{0:0.00}", Statistics.Variance(Asistieron)), String.Format("{0:0.00}", Statistics.Variance(Faltaron)));

                // Desviación Estándar
                var dvA = Statistics.StandardDeviation(Asistieron);
                var dvF = Statistics.StandardDeviation(Faltaron);
                cuadroResumen.Rows.Add("Desv. Estándar", String.Format("{0:0.00}", dvA), String.Format("{0:0.00}", dvF));

                dgvResumen.DataSource = cuadroResumen;

                // Gráficos
                btnGrafico2.Visible = false;
                IndiceGrafico1 = 0;

                // Gráfico 1
                gxGrafico1.XAxesLabel = "Porcentaje";
                gxGrafico1.YAxesLabel = "Código Asignatura";

                List<string> EtiquetasA = new List<string>();

                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                List<double> Datos2A = new List<double>();
                List<Color> Colores2A = new List<Color>();

                foreach (DataRow Fila in dtEstadisticos.Rows)
                {
                    EtiquetasA.Add(Fila["CodAsignatura"].ToString());
                    Datos1A.Add(double.Parse(Fila["PorcentajeAsistencias"].ToString()));
                    Colores1A.Add(Color.FromArgb(104, 13, 15));
                    Datos2A.Add(double.Parse(Fila["PorcentajeFaltas"].ToString()));
                    Colores2A.Add(Color.FromArgb(232, 158, 31));
                }

                gxGrafico1.Labels = EtiquetasA.ToArray();
                gxGrafico1.Clear();

                GraficoBarrasHorizontales1.Label = "Asistencias (%)";
                GraficoBarrasHorizontales1.Data = Datos1A;
                GraficoBarrasHorizontales1.BackgroundColor = Colores1A;

                GraficoBarrasHorizontales2.Label = "Faltas (%)";
                GraficoBarrasHorizontales2.Data = Datos2A;
                GraficoBarrasHorizontales2.BackgroundColor = Colores2A;

                GraficoBarrasHorizontales1.TargetCanvas = gxGrafico1;
                GraficoBarrasHorizontales2.TargetCanvas = gxGrafico1;

                gxGrafico1.Update();

                tcGraficos.SetPage(IndiceGrafico1);
            }
        }
        public void fnReporte13(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistenciasDocentes, string CodAsignatura)
        {
            this.CriterioAsistenciasDocentes = CriterioAsistenciasDocentes;

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
                    Width = 1032,
                    Image = Properties.Resources.Mostrar
                };

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

                DataTable dtResumen = (dgvResultados.DataSource as DataTable).Copy();

                // Cuadro de resumen
                DataTable cuadroResumen = new DataTable();
                cuadroResumen.Columns.Add(" ");
                cuadroResumen.Columns.Add("Cantidad");

                double Asistio = 0;
                
                double FaltaronJustificado = 0;
                double FaltaronSinJustificar = 0;

                foreach (DataRow Fila in dtResumen.Rows)
                {
                    if (Fila["Asistió"].ToString() == "SI" && Fila["Observación"].ToString() == "")
                    {
                        Asistio += 1;
                    }
                    
                    else if (Fila["Asistió"].ToString() == "NO" && (Fila["Observación"].ToString() == "FERIADO" || Fila["Observación"].ToString() == "SUSPENSION" || Fila["Observación"].ToString() == "PERMISO"))
                    {
                        FaltaronJustificado += 1;
                    }

                    else if (Fila["Asistió"].ToString() == "NO" && Fila["Observación"].ToString() == "FALTO SIN JUSTIFICAR")
                    {
                        FaltaronSinJustificar += 1;
                    }
                }

                double Total = Asistio + FaltaronJustificado + FaltaronSinJustificar;

                // Asistieron 
                cuadroResumen.Rows.Add("Asistencias", Asistio.ToString() + " (" + String.Format("{0:0.00}", Asistio / Total * 100) + "%)");

                // Faltaron (Justificado)
                cuadroResumen.Rows.Add("Falta(s) (Justificada(s))", FaltaronJustificado.ToString() + " (" + String.Format("{0:0.00}", FaltaronJustificado / Total * 100) + "%)");

                // Faltaron (Sin justificar)
                cuadroResumen.Rows.Add("Falta(s) (Sin Justificar)", FaltaronSinJustificar.ToString() + " (" + String.Format("{0:0.00}", FaltaronSinJustificar / Total * 100) + "%)");

                // Faltas
                cuadroResumen.Rows.Add("Total de Faltas", (FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + String.Format("{0:0.00}", (FaltaronJustificado + FaltaronSinJustificar) / Total * 100) + "%)");

                // Total
                cuadroResumen.Rows.Add("Total", (Asistio + FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + "100" + "%)");

                dgvResumen.DataSource = cuadroResumen;

                // Gráficos // Barras verticales y Pie
                btnGrafico2.Visible = true;
                IndiceGrafico1 = 2;

                // Gráfico 1
                gxGrafico3.XAxesLabel = "";
                gxGrafico3.LegendDisplay = false;
                gxGrafico3.YAxesLabel = "Cantidad";

                List<string> EtiquetasA = new List<string>();
                List<double> Datos1A = new List<double>();
                List<Color> Colores1A = new List<Color>();

                Datos1A.Add(Asistio);
                Datos1A.Add(FaltaronJustificado + FaltaronSinJustificar);
                Colores1A.Add(Color.FromArgb(104, 13, 15));
                Colores1A.Add(Color.FromArgb(232, 158, 31));

                EtiquetasA.Add("Total Asistencias");
                EtiquetasA.Add("Total Faltas");

                gxGrafico3.Labels = EtiquetasA.ToArray();
                gxGrafico3.Clear();

                GraficoBarrasVerticales.Label = "";
                GraficoBarrasVerticales.Data = Datos1A;
                GraficoBarrasVerticales.BackgroundColor = Colores1A;

                GraficoBarrasVerticales.TargetCanvas = gxGrafico3;

                gxGrafico3.Update();

                // Gráfico 2
                IndiceGrafico2 = 3;

                gxGrafico4.XAxesLabel = "";
                gxGrafico4.YAxesLabel = "";

                List<string> EtiquetasB = new List<string>();
                List<double> Datos1B = new List<double>();
                List<Color> Color1B = new List<Color>();

                EtiquetasB.Add("Asistencia Normal");
              
                EtiquetasB.Add("Falta (Justificada)");
                EtiquetasB.Add("Falta (Sin Justificar)");

                Datos1B.Add(Asistio);
                
                Datos1B.Add(FaltaronJustificado);
                Datos1B.Add(FaltaronSinJustificar);

                Color1B.Add(Color.FromArgb(23, 153, 75));
                Color1B.Add(Color.FromArgb(117, 163, 229));
                Color1B.Add(Color.FromArgb(232, 128, 31));
                Color1B.Add(Color.FromArgb(104, 13, 15));

                gxGrafico4.Labels = EtiquetasB.ToArray();
                gxGrafico4.Clear();

                GraficoCircular.Label = "";
                GraficoCircular.Data = Datos1B;
                GraficoCircular.BackgroundColor = Color1B;

                GraficoCircular.TargetCanvas = gxGrafico4;

                gxGrafico4.Update();
            }
        }

        public void fnReporte14(string Titulo, string[] Titulos, string[] Valores, DataTable Datos, string CriterioAsistenciasDocentes, string CodAsignatura)
        {
            this.CriterioAsistenciasDocentes = CriterioAsistenciasDocentes;

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
                    Width = 1032,
                    Image = Properties.Resources.Mostrar
                };

                dgvResultados.Columns.Clear();
                dgvResultados.Columns.Add(btnVerReporte);
                dgvResultados.Columns[0].HeaderText = "Ver Reporte";

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

                // Mostrar cuadro de resumen
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
                

                

                // Listas de valores
                List<double> Asistieron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<int>("TotalAsistieron"))).ToList();
                List<double> Faltaron = dtEstadisticos.AsEnumerable().Select(x => Convert.ToDouble(x.Field<int>("TotalFaltaron"))).ToList();

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
                gxGrafico1.XAxesLabel = "Cantidad";
                gxGrafico1.YAxesLabel = "Fecha";

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

                GraficoLineas.Label = "Total Asistieron (%)";
                GraficoLineas.Data = Datos1B;

                GraficoLineas.TargetCanvas = gxGrafico2;

                gxGrafico2.Update();

                tcGraficos.SetPage(IndiceGrafico1);
            }
        }

        public void fnReporte15(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
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

            dgvResultados.Columns.Clear();

            dgvResultados.DataSource = Datos;
            dgvResultados.Columns[0].Visible = false;

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

            DataTable dtResumen = (dgvResultados.DataSource as DataTable).Copy();

            // Cuadro de resumen
            DataTable cuadroResumen = new DataTable();
            cuadroResumen.Columns.Add(" ");
            cuadroResumen.Columns.Add("Cantidad");

            double Total = dtResumen.Rows.Count;
            double AsistieronPuntual = 0;
            double AsistieronTarde = 0;
            double FaltaronJustificado = 0;
            double FaltaronSinJustificar = 0;

            foreach (DataRow row in dtResumen.Rows)
            {
                if (row["Asistió"].ToString() == "SI" && row["Observación"].ToString() == "")
                {
                    AsistieronPuntual += 1;
                }
                else if (row["Asistió"].ToString() == "SI" && row["Observación"].ToString() != "")
                {
                    //AsistieronTarde += 1;
                }
                else if (row["Asistió"].ToString() == "NO" && row["Observación"].ToString() == "FALTO SIN JUSTIFICAR")
                {
                    FaltaronSinJustificar += 1;
                }
                else if (row["Asistió"].ToString() == "NO" && row["Observación"].ToString() != "FALTO SIN JUSTIFICAR")
                {
                    FaltaronJustificado += 1;
                }
                
            }

            // Asistieron puntual
            cuadroResumen.Rows.Add("Asistieron Puntual", AsistieronPuntual.ToString() + " (" + String.Format("{0:0.00}", AsistieronPuntual / Total * 100) + "%)");

            // Asistieron tarde
            //cuadroResumen.Rows.Add("Asistieron Tarde", AsistieronTarde.ToString() + " (" + String.Format("{0:0.00}", AsistieronTarde / Total * 100) + "%)");

            // Faltaron (Justificado)
            cuadroResumen.Rows.Add("Faltaron (Justificado)", FaltaronJustificado.ToString() + " (" + String.Format("{0:0.00}", FaltaronJustificado / Total * 100) + "%)");

            // Faltaron (Sin justificar)
            cuadroResumen.Rows.Add("Faltaron (Sin Justificar)", FaltaronSinJustificar.ToString() + " (" + String.Format("{0:0.00}", FaltaronSinJustificar / Total * 100) + "%)");

            cuadroResumen.Rows.Add("", "");

            // Asistencias
            cuadroResumen.Rows.Add("Asistencias", (AsistieronPuntual + AsistieronTarde).ToString() + " (" + String.Format("{0:0.00}", (AsistieronPuntual + AsistieronTarde) / Total * 100) + "%)");

            // Faltas
            cuadroResumen.Rows.Add("Faltas", (FaltaronJustificado + FaltaronSinJustificar).ToString() + " (" + String.Format("{0:0.00}", (FaltaronJustificado + FaltaronSinJustificar) / Total * 100) + "%)");

            // Total
            cuadroResumen.Rows.Add("Total", (AsistieronPuntual + AsistieronTarde + FaltaronJustificado + FaltaronSinJustificar) + " (" + "100" + "%)");

            dgvResumen.DataSource = cuadroResumen;

            // Gráficos
            btnGrafico2.Visible = true;
            IndiceGrafico1 = 2;

            // Gráfico 1
            gxGrafico3.XAxesLabel = "";
            gxGrafico3.LegendDisplay = false;
            gxGrafico3.YAxesLabel = "Cantidad";

            List<string> EtiquetasA = new List<string>();
            List<double> Datos1A = new List<double>();
            List<Color> Colores1A = new List<Color>();

            Datos1A.Add(AsistieronPuntual + AsistieronTarde);
            Datos1A.Add(FaltaronJustificado + FaltaronSinJustificar);
            Colores1A.Add(Color.FromArgb(104, 13, 15));
            Colores1A.Add(Color.FromArgb(232, 158, 31));

            EtiquetasA.Add("Total Asistieron");
            EtiquetasA.Add("Total Faltaron");

            gxGrafico3.Labels = EtiquetasA.ToArray();
            gxGrafico3.Clear();

            GraficoBarrasVerticales.Label = "";
            GraficoBarrasVerticales.Data = Datos1A;
            GraficoBarrasVerticales.BackgroundColor = Colores1A;

            GraficoBarrasVerticales.TargetCanvas = gxGrafico3;

            gxGrafico3.Update();

            // Gráfico 2
            IndiceGrafico2 = 3;

            gxGrafico4.XAxesLabel = "";
            gxGrafico4.YAxesLabel = "";

            List<string> EtiquetasB = new List<string>();
            List<double> Datos1B = new List<double>();
            List<Color> Color1B = new List<Color>();

            EtiquetasB.Add("Asistieron Puntual");
            //EtiquetasB.Add("Asistieron Tarde");
            EtiquetasB.Add("Faltaron (Justificado)");
            EtiquetasB.Add("Faltaron (Sin Justificar)");

            Datos1B.Add(AsistieronPuntual);
            //Datos1B.Add(AsistieronTarde);
            Datos1B.Add(FaltaronJustificado);
            Datos1B.Add(FaltaronSinJustificar);

            Color1B.Add(Color.FromArgb(23, 153, 75));
            Color1B.Add(Color.FromArgb(117, 163, 229));
            Color1B.Add(Color.FromArgb(232, 128, 31));
            Color1B.Add(Color.FromArgb(104, 13, 15));

            gxGrafico4.Labels = EtiquetasB.ToArray();
            gxGrafico4.Clear();

            GraficoCircular.Label = "";
            GraficoCircular.Data = Datos1B;
            GraficoCircular.BackgroundColor = Color1B;

            GraficoCircular.TargetCanvas = gxGrafico4;

            gxGrafico4.Update();
        }
        private void dgvResultados_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Equals("System.Windows.Forms.DataGridViewImageColumn", dgvResultados.Columns[e.ColumnIndex].GetType().ToString()))
            {
                dgvResultados.Cursor = Cursors.Hand;
            }
            else
            {
                dgvResultados.Cursor = Cursors.Default;
            }
        }

        private void dgvResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0) && AccesoReportes=="Jefe de Departamento")// denis cpp
            {
                if (CriterioAsistenciasDocentes == "Por Fechas")
                {
                    string[] ValoresNecesarios = { (pnSubcampos.Controls[0] as C_Campo).Valor, dgvResultados.CurrentRow.Cells["Fecha"].Value.ToString() };
                    DateTime[] FechasNecesarias = { Convert.ToDateTime(dgvResultados.CurrentRow.Cells["Fecha"].Value.ToString(), CultureInfo.GetCultureInfo("es-ES")) };

                    P_DialogoReporte DR = new P_DialogoReporte(ValoresNecesarios, FechasNecesarias, "Por Fechas D");
                    DR.ShowDialog();
                    DR.Dispose();
                }
                else if (CriterioAsistenciasDocentes == "Por Asignaturas")
                {
                    string[] Titulo_1 = ((pnTitulo.Controls[0] as Bunifu.UI.WinForms.BunifuLabel).Text.Split('\n'));
                    string[] Fechas = Titulo_1[1].Split(' ');

                    string FechaInicial = DateTime.ParseExact(Fechas[1], "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                    string FechaFinal = DateTime.ParseExact(Fechas[4], "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));

                    string[] ValoresNecesarios = { (pnSubcampos.Controls[0] as C_Campo).Valor, (pnSubcampos.Controls[2] as C_Campo).Valor, (pnSubcampos.Controls[3] as C_Campo).Valor, dgvResultados.CurrentRow.Cells["CodAsignatura"].Value.ToString(), dgvResultados.CurrentRow.Cells["NombreAsignatura"].Value.ToString(),FechaInicial,FechaFinal};

                    DateTime[] FechasNecesarias = { Convert.ToDateTime(Fechas[1], CultureInfo.GetCultureInfo("es-ES")), Convert.ToDateTime(Fechas[4], CultureInfo.GetCultureInfo("es-ES")), Convert.ToDateTime(Fechas[4]) };

                    P_DialogoReporte DR = new P_DialogoReporte(ValoresNecesarios, FechasNecesarias, "Por Asignaturas D");
                    DR.ShowDialog();
                    DR.Dispose();
                }
            }
            else if ((e.RowIndex >= 0) && (e.ColumnIndex == 0) && this.CriterioAsistenciasEstudiantes != "")
            {
                if (CriterioAsistenciasEstudiantes == "Por Fechas")
                {
                    string[] ValoresNecesarios = { (pnSubcampos.Controls[1] as C_Campo).Valor, (pnSubcampos.Controls[2] as C_Campo).Valor, (pnSubcampos.Controls[3] as C_Campo).Valor, (pnSubcampos.Controls[4] as C_Campo).Valor, (pnSubcampos.Controls[5] as C_Campo).Valor, dgvResultados.CurrentRow.Cells["Fecha"].Value.ToString(), dgvResultados.CurrentRow.Cells["Hora"].Value.ToString() };
                    DateTime[] FechasNecesarias = { Convert.ToDateTime(dgvResultados.CurrentRow.Cells["Fecha"].Value.ToString(), CultureInfo.GetCultureInfo("es-ES")) };

                    P_DialogoReporte DR = new P_DialogoReporte(ValoresNecesarios, FechasNecesarias, "Por Fechas");
                    DR.ShowDialog();
                    DR.Dispose();
                }
                else if (CriterioAsistenciasEstudiantes == "Por Estudiantes")
                {
                    string[] Titulo_1 = ((pnTitulo.Controls[0] as Bunifu.UI.WinForms.BunifuLabel).Text.Split('\n'));
                    string[] Fechas = Titulo_1[1].Split(' ');

                    string FechaInicial = DateTime.ParseExact(Fechas[1], "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                    string FechaFinal = DateTime.ParseExact(Fechas[4], "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));

                    string[] ValoresNecesarios = { (pnSubcampos.Controls[1] as C_Campo).Valor, (pnSubcampos.Controls[2] as C_Campo).Valor, (pnSubcampos.Controls[3] as C_Campo).Valor, (pnSubcampos.Controls[4] as C_Campo).Valor, (pnSubcampos.Controls[5] as C_Campo).Valor, dgvResultados.CurrentRow.Cells["CodEstudiante"].Value.ToString(), dgvResultados.CurrentRow.Cells["Nombre"].Value.ToString() + " " + dgvResultados.CurrentRow.Cells["APaterno"].Value.ToString() + " " + dgvResultados.CurrentRow.Cells["AMaterno"].Value.ToString(), FechaInicial, FechaFinal };

                    DateTime[] FechasNecesarias = { Convert.ToDateTime(Fechas[1], CultureInfo.GetCultureInfo("es-ES")), Convert.ToDateTime(Fechas[4], CultureInfo.GetCultureInfo("es-ES")) };

                    P_DialogoReporte DR = new P_DialogoReporte(ValoresNecesarios, FechasNecesarias, "Por Estudiantes");
                    DR.ShowDialog();
                    DR.Dispose();
                }
                else if (CriterioAsistenciasEstudiantes == "Por Asignaturas")
                {
                    string[] Titulo_1 = ((pnTitulo.Controls[0] as Bunifu.UI.WinForms.BunifuLabel).Text.Split('\n'));
                    string[] Fechas = Titulo_1[1].Split(' ');

                    string FechaInicial = DateTime.ParseExact(Fechas[1], "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                    string FechaFinal = DateTime.ParseExact(Fechas[4], "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));

                    string[] ValoresNecesarios = { (pnSubcampos.Controls[1] as C_Campo).Valor, (pnSubcampos.Controls[2] as C_Campo).Valor, (pnSubcampos.Controls[3] as C_Campo).Valor, dgvResultados.CurrentRow.Cells["CodAsignatura"].Value.ToString(), dgvResultados.CurrentRow.Cells["NombreAsignatura"].Value.ToString(), dgvResultados.CurrentRow.Cells["CodDocente"].Value.ToString(), dgvResultados.CurrentRow.Cells["Docente"].Value.ToString(), FechaInicial, FechaFinal };

                    DateTime[] FechasNecesarias = { Convert.ToDateTime(Fechas[1], CultureInfo.GetCultureInfo("es-ES")), Convert.ToDateTime(Fechas[4], CultureInfo.GetCultureInfo("es-ES")), Convert.ToDateTime(Fechas[4]) };

                    P_DialogoReporte DR = new P_DialogoReporte(ValoresNecesarios, FechasNecesarias, "Por Asignaturas");
                    DR.ShowDialog();
                    DR.Dispose();
                }
            }
            
        }

        public void btnGrafico1_Click(object sender, EventArgs e)
        {
            tcGraficos.SetPage(IndiceGrafico1);
        }

        private void btnGrafico2_Click(object sender, EventArgs e)
        {
            tcGraficos.SetPage(IndiceGrafico2);
        }
    }
}