using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasSilabos : Form
    {
        public P_TablaAsignaturasAsignadasSilabos()
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            MostrarAsignaturas();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].DisplayIndex = 6;
            dgvDatos.Columns[2].DisplayIndex = 6;
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente("2021-II", "IF", "10134");
            AccionesTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Plantilla
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.FileName = "Plantilla 2021-II";
                saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.FilterIndex = 1;


                byte[] archivo = null;

                // ruta de la plantilla
                Stream myStream = File.OpenRead(@"C:\Users\deniswin\Desktop\plantilla.xlsx");
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    archivo = ms.ToArray();
                } 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, archivo);
                }
            }

            // Descargar
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                /*DataTable A = N_Catalogo.BuscarSilaboAsignatura("2021-II", dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString().Substring(0, 5), dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString().Substring(6, 2), dgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString());

                if (A.Rows.Count != 0)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + "temp.xlsx";
                    MessageBox.Show(fullFilePath);

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    if (File.Exists(fullFilePath))
                    {
                        File.Delete(fullFilePath);
                    }

                    MessageBox.Show(A.Rows[0][0].GetType().ToString());

                    byte[] archivo = A.Rows[0]["Silabo"] as byte[];
                    MessageBox.Show(archivo.Length.ToString());

                    File.WriteAllBytes(fullFilePath, archivo);

                    Process.Start(fullFilePath);

                    if (Directory.Exists(folder))
                    {
                        MessageBox.Show("Se eliminará un folder");
                        Directory.Delete(folder);
                    }

                }
                else
                {
                    MessageBox.Show("No hay registro del sílabo");
                }*/
            }

            // Subir sílabo
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 2))
            {
                P_SubirSilabo SubirArchivo = new P_SubirSilabo();

                Program.Evento = 1;

                SubirArchivo.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                SubirArchivo.NombreAsignatura = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                SubirArchivo.EscuelaProfesional = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                SubirArchivo.Grupo = dgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString();
                SubirArchivo.CodDocente = "10134";

                SubirArchivo.ShowDialog();
                SubirArchivo.Dispose();
            }

            /*
            // Ver archivo
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                DataTable A = N_Catalogo.BuscarSilaboAsignatura("2021-II", dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString().Substring(0, 5), dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString().Substring(6, 2), dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString());

                if (A.Rows.Count != 0)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + "temp.txt";
                    MessageBox.Show(fullFilePath);

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    if (File.Exists(fullFilePath))
                    {
                        File.Delete(fullFilePath);
                    }

                    MessageBox.Show(A.Rows[0][0].GetType().ToString());

                    byte[] archivo = A.Rows[0]["Silabo"] as byte[];
                    MessageBox.Show(archivo.Length.ToString());

                    File.WriteAllBytes(fullFilePath, archivo);

                    Process.Start(fullFilePath);

                    if (Directory.Exists(folder))
                    {
                        MessageBox.Show("Se eliminará un folder");
                        Directory.Delete(folder);
                    }
                }
                else
                {
                    MessageBox.Show("No hay registro del sílabo");
                }
            }*/
        }
    }
}
