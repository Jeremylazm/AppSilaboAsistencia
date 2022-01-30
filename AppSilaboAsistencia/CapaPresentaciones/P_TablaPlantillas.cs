using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.IO;
using ClosedXML.Excel;
using Ayudas;



namespace CapaPresentaciones
{
    public partial class P_TablaPlantillas : Form
    {
        //readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        public P_TablaPlantillas()
        {
            InitializeComponent();
        }

        //private void btnPlantillaSilabo_Click(object sender, EventArgs e)
        //{
        //    P_SubirArchivo sa = new P_SubirArchivo("Plantilla Silabo");
        //    sa.ShowDialog();
        //    sa.Dispose();
        //}

        //private void btnPlanDeSesiones2y3_Click(object sender, EventArgs e)
        //{
        //    P_SubirArchivo sa = new P_SubirArchivo("Plantilla Sesiones 2 y 3 créditos");
        //    sa.ShowDialog();
        //    sa.Dispose();
        //}

        //private void bunifuButton22_Click(object sender, EventArgs e)
        //{
        //    P_SubirArchivo sa = new P_SubirArchivo("Plantilla Sesiones 4 créditos");
        //    sa.ShowDialog();
        //    sa.Dispose();
        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void btnDescargarPlantilla1_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Descargar plantilla de sílabo";
            saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.FilterIndex = 1;
            // El registro de la plantilla
            DataTable PlantillaSilabo = N_Recursos.DescargarPlantillaSilabo();
            // Se crea un archivo temporal, para después abrirlo con ClosedXML
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "/temp/";
            string fullFilePath = folder + "temp.xlsx";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            if (File.Exists(fullFilePath)) File.Delete(fullFilePath);

            if (PlantillaSilabo.Rows[0]["PlantillaSilabo"].ToString() != "")
            {
                byte[] archivo = PlantillaSilabo.Rows[0]["PlantillaSilabo"] as byte[];

                File.WriteAllBytes(fullFilePath, archivo);
                XLWorkbook wb = new XLWorkbook(fullFilePath);
                saveFileDialog.FileName = "Plantilla Sílabo";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        wb.SaveAs(saveFileDialog.FileName);
                        A_Dialogo.DialogoConfirmacion("Archivo guardado exitosamente");
                    }
                    catch (IOException)
                    {
                        A_Dialogo.DialogoError("Cierre el archivo antes de que sea reemplazado");
                    }
                }
            }
            else
            {
                A_Dialogo.DialogoError("Aun no subio una plantilla para descargar");
            }

            
        }

        private void btnSubirPlantilla1_Click_1(object sender, EventArgs e)
        {
            P_SubirArchivo sa = new P_SubirArchivo("Plantilla Silabo");
            sa.ShowDialog();
            sa.Dispose();
        }

        private void btnSubirPlantilla2_Click_1(object sender, EventArgs e)
        {
            P_SubirArchivo sa = new P_SubirArchivo("Plantilla Sesiones 2 y 3 créditos");
            sa.ShowDialog();
            sa.Dispose();
        }

        private void btnSubirPlantilla3_Click_1(object sender, EventArgs e)
        {
            P_SubirArchivo sa = new P_SubirArchivo("Plantilla Sesiones 4 créditos");
            sa.ShowDialog();
            sa.Dispose();
        }

        private void btnDescargarPlantilla2_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Descargar plantilla de sílabo";
            saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.FilterIndex = 1;
            // El registro de la plantilla
            DataTable PlantillaSilabo = N_Recursos.DescargarPlantillaPlanSesiones2y3();
            // Se crea un archivo temporal, para después abrirlo con ClosedXML
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "/temp/";
            string fullFilePath = folder + "temp.xlsx";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            if (File.Exists(fullFilePath)) File.Delete(fullFilePath);
            
            if (PlantillaSilabo.Rows[0]["PlantillaPlanSesiones2y3"].ToString()!="")
            {
                byte[] archivo = PlantillaSilabo.Rows[0]["PlantillaPlanSesiones2y3"] as byte[];

                File.WriteAllBytes(fullFilePath, archivo);
                XLWorkbook wb = new XLWorkbook(fullFilePath);
                saveFileDialog.FileName = "Plantilla Plan de Sesiones de 2 y 3 créditos";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        wb.SaveAs(saveFileDialog.FileName);
                        A_Dialogo.DialogoConfirmacion("Archivo guardado exitosamente");
                    }
                    catch (IOException)
                    {
                        A_Dialogo.DialogoError("Cierre el archivo antes de que sea reemplazado");
                    }
                }
            }
            else
            {
                A_Dialogo.DialogoError("Aun no subio una plantilla para descargar");
            }
            
        }

        private void btnDescargarPlantilla3_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Descargar plantilla de sílabo";
            saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.FilterIndex = 1;
            // El registro de la plantilla
            DataTable PlantillaSilabo = N_Recursos.DescargarPlantillaPlanSesiones4();
            // Se crea un archivo temporal, para después abrirlo con ClosedXML
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "/temp/";
            string fullFilePath = folder + "temp.xlsx";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            if (File.Exists(fullFilePath)) File.Delete(fullFilePath);

            if (PlantillaSilabo.Rows[0]["PlantillaPlanSesiones4"].ToString() != "")
            {
                byte[] archivo = PlantillaSilabo.Rows[0]["PlantillaPlanSesiones4"] as byte[];

                File.WriteAllBytes(fullFilePath, archivo);
                XLWorkbook wb = new XLWorkbook(fullFilePath);
                saveFileDialog.FileName = "Plantilla Plan de Sesiones de 4 créditos";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        wb.SaveAs(saveFileDialog.FileName);
                        A_Dialogo.DialogoConfirmacion("Archivo guardado exitosamente");
                    }
                    catch (IOException)
                    {
                        A_Dialogo.DialogoError("Cierre el archivo antes de que sea reemplazado");
                    }
                }
            }
            else
            {
                A_Dialogo.DialogoError("Aun no subio una plantilla para descargar");
            }

            
        }
    }
}
