using System;
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

namespace ControlesPerzonalizados
{
    public partial class C_ReporteA : UserControl
    {
        public C_ReporteA()
        {
            InitializeComponent();

            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvResultados, sbResultados);
            dgvResultados.MouseWheel += new MouseEventHandler(dataGridView1_MouseWheel);
            sbResultados.MouseWheel += new MouseEventHandler(dataGridView1_MouseWheel);
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

        public C_ReporteA(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
        {
            InitializeComponent();

            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvResultados, sbResultados);
            dgvResultados.MouseWheel += new MouseEventHandler(dataGridView1_MouseWheel);
            sbResultados.MouseWheel += new MouseEventHandler(dataGridView1_MouseWheel);

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

            dgvResultados.DataSource = Datos;
            dgvResultados.Columns[0].DisplayIndex = 5;

            //
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

            // Máximo
            cuadroResumen.Rows.Add("Máximo", Statistics.Maximum(Asistieron), Statistics.Maximum(Faltaron));

            // Mínimos
            cuadroResumen.Rows.Add("Mínimo", Statistics.Minimum(Asistieron), Statistics.Minimum(Faltaron));

            // Media
            cuadroResumen.Rows.Add("Media", Statistics.Mean(Asistieron), Statistics.Mean(Faltaron));

            // Mediana
            cuadroResumen.Rows.Add("Mediana", Statistics.Median(Asistieron), Statistics.Median(Faltaron));

            // Moda
            var modeAsistieron = Asistieron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
            var modeFaltaron = Faltaron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
            cuadroResumen.Rows.Add("Moda", modeAsistieron, modeFaltaron);

            // Varianza
            cuadroResumen.Rows.Add("Varianza", Statistics.Variance(Asistieron), Statistics.Variance(Faltaron));

            // Desviación Estándar
            var dvA = Statistics.StandardDeviation(Asistieron);
            var dvF = Statistics.StandardDeviation(Faltaron);
            cuadroResumen.Rows.Add("Desv. Estándar", String.Format("{0:0.00}", dvA), String.Format("{0:0.00}", dvF));

            dgvResumen.DataSource = cuadroResumen;

            // Gráfico

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

        public void fnReporte1(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
        {
            LimpiarCampos();
            MessageBox.Show("report1");
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

            dgvResultados.DataSource = Datos;
            dgvResultados.Columns[0].DisplayIndex = 5;

            //
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

            // Máximo
            cuadroResumen.Rows.Add("Máximo", Statistics.Maximum(Asistieron), Statistics.Maximum(Faltaron));

            // Mínimos
            cuadroResumen.Rows.Add("Mínimo", Statistics.Minimum(Asistieron), Statistics.Minimum(Faltaron));

            // Media
            cuadroResumen.Rows.Add("Media", Statistics.Mean(Asistieron), Statistics.Mean(Faltaron));

            // Mediana
            cuadroResumen.Rows.Add("Mediana", Statistics.Median(Asistieron), Statistics.Median(Faltaron));

            // Moda
            var modeAsistieron = Asistieron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
            var modeFaltaron = Faltaron.GroupBy(a => a).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();
            cuadroResumen.Rows.Add("Moda", modeAsistieron, modeFaltaron);

            // Varianza
            cuadroResumen.Rows.Add("Varianza", Statistics.Variance(Asistieron), Statistics.Variance(Faltaron));

            // Desviación Estándar
            var dvA = Statistics.StandardDeviation(Asistieron);
            var dvF = Statistics.StandardDeviation(Faltaron);
            cuadroResumen.Rows.Add("Desv. Estándar", String.Format("{0:0.00}", dvA), String.Format("{0:0.00}", dvF));

            dgvResumen.DataSource = cuadroResumen;

            // Gráfico
        }

        public void fnReporte3(string Titulo, string[] Titulos, string[] Valores, DataTable Datos)
        {
            LimpiarCampos();
            MessageBox.Show("report3");
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

            dgvResultados.DataSource = Datos;
            dgvResultados.Columns[1].Visible = false;
            dgvResultados.Columns[0].DisplayIndex = 7;

            // Gráficos
            Grafico1.Titles.Clear();
            Grafico1.Series.Clear();
            Grafico1.ChartAreas.Clear();

            Grafico1.Palette = ChartColorPalette.Excel;
            Grafico1.Titles.Add("Asignatura");

            ChartArea Area = new ChartArea();
            Area.AxisX.Interval = 1;
            Grafico1.ChartAreas.Add(Area);

            Series serie1 = new Series("TotalAsistencias")
            {
                ChartType = SeriesChartType.StackedBar,

                XValueMember = "CodEstudiante",
                YValueMembers = "TotalAsistencias",
                MarkerColor = Color.Blue,
                IsValueShownAsLabel = true
            };

            Series serie2 = new Series("TotalFaltas")
            {
                ChartType = SeriesChartType.StackedBar,

                XValueMember = "CodEstudiante",
                YValueMembers = "TotalFaltas"
            };

            Grafico1.Series.Add(serie1);
            Grafico1.Series.Add(serie2);

            Grafico1.DataSource = dgvResultados.DataSource;
        }
    }
}