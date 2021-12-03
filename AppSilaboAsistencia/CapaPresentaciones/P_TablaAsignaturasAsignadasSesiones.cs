using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using ClosedXML.Excel;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasSesiones : Form
    {
        private string CodDocente = "49920";
        //private string CodDocente = "34024";

        public P_TablaAsignaturasAsignadasSesiones()
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
            dgvDatos.Columns[6].Visible = false;
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[4].HeaderText = "Nombre";
            dgvDatos.Columns[5].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[6].HeaderText = "Grupo";
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente("2021-II", "IF", CodDocente);
            AccionesTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Plantilla
            if ((e.RowIndex == 0) && (e.ColumnIndex == 0))
            {
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.FilterIndex = 1;

                DataTable PlantillaPlanSesiones = N_Recursos.DescargarPlantillaSilabo();

                // Se crea un archivo temporal, para después abrirlo con ClosedXML
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

                byte[] archivo = PlantillaPlanSesiones.Rows[0]["PlantillaSilabo"] as byte[];

                File.WriteAllBytes(fullFilePath, archivo);

            }
        }
    }
}
