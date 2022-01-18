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
using CapaEntidades;
using Ayudas;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasPlanSesiones : Form
    {
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;

        public P_TablaAsignaturasAsignadasPlanSesiones()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);

            dgvDatos.CellMouseEnter += new DataGridViewCellEventHandler(dgvDatos_CellMouseEnter);

            MostrarAsignaturas();
        }

        private void dgvDatos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Equals("System.Windows.Forms.DataGridViewImageColumn", dgvDatos.Columns[e.ColumnIndex].GetType().ToString()) && e.RowIndex >= 0) dgvDatos.Cursor = Cursors.Hand;
            else dgvDatos.Cursor = Cursors.Default;
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].DisplayIndex = 6;
            dgvDatos.Columns[2].DisplayIndex = 6;
            dgvDatos.Columns[6].Visible = false;
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[4].HeaderText = "Asignatura";
            dgvDatos.Columns[5].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[6].HeaderText = "Grupo";

            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvDatos.Columns[0].Width = 70;
            dgvDatos.Columns[1].Width = 70;
            dgvDatos.Columns[2].Width = 70;
            dgvDatos.Columns[3].Width = 70;
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, "IF", CodDocente);
            AccionesTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Plantilla
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                saveFileDialog.Title = "Descargar plantilla de plan de sesiones";
                saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.FilterIndex = 1;

                string CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();

                DataTable dtDatosAsignatura = N_Asignatura.BuscarAsignatura(CodAsignatura.Substring(0, 2), CodAsignatura.Substring(0, 5));

                int NumCreditos = Convert.ToInt32(dtDatosAsignatura.Rows[0][2]);

                DataTable PlantillaPlanSesiones;
                byte[] archivo = null;
                if (NumCreditos == 2 || NumCreditos == 3)
                {
                    PlantillaPlanSesiones = N_Recursos.DescargarPlantillaPlanSesiones2y3();
                    archivo = PlantillaPlanSesiones.Rows[0]["PlantillaPlanSesiones2y3"] as byte[];
                }
                else if (NumCreditos == 4)
                {
                    PlantillaPlanSesiones = N_Recursos.DescargarPlantillaPlanSesiones4();
                    archivo = PlantillaPlanSesiones.Rows[0]["PlantillaPlanSesiones4"] as byte[];
                }

                // Se crea un archivo temporal, para después abrirlo con ClosedXML
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "/temp/";
                string fullFilePath = folder + "temp.xlsx";

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                if (File.Exists(fullFilePath)) File.Delete(fullFilePath);

                File.WriteAllBytes(fullFilePath, archivo);

                XLWorkbook wb = new XLWorkbook(fullFilePath);

                // Completar información

                // Nombre y código del curso
                wb.Worksheet(1).Cell("A4").Value = dtDatosAsignatura.Rows[0]["NombreAsignatura"].ToString() + " (" + CodAsignatura + ")";

                // Semestre
                wb.Worksheet(1).Cell("A5").Value = wb.Worksheet(1).Cell("A5").Value + CodSemestre;

                // Completar información del docente
                DataTable dtDatosDocente = N_Docente.BuscarDocente(CodAsignatura.Substring(0, 2), CodDocente);
                string Nombre = dtDatosDocente.Rows[0]["Nombre"].ToString();
                string APaterno = dtDatosDocente.Rows[0]["APaterno"].ToString();
                string AMaterno = dtDatosDocente.Rows[0]["AMaterno"].ToString();

                // Nombre del docente
                wb.Worksheet(1).Cell("A6").Value = wb.Worksheet(1).Cell("A6").Value + " " + APaterno + "-" + AMaterno + "-" + Nombre; 

                // Guardar el archivo
                saveFileDialog.FileName = "Plantilla Plan de Sesiones - " + CodAsignatura;

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

                if (Directory.Exists(folder)) Directory.Delete(folder, true);
            }

            // Descargar
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                //Form Fondo = new Form();
                using (P_TablaPlanSesionesAsignatura sesionesAsignatura = new P_TablaPlanSesionesAsignatura(dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString()))
                {
                    //Fondo.StartPosition = FormStartPosition.Manual;
                    //Fondo.FormBorderStyle = FormBorderStyle.None;
                    //Fondo.Opacity = .70d;
                    //Fondo.BackColor = Color.Black;
                    //Fondo.WindowState = FormWindowState.Maximized;
                    //Fondo.TopMost = true;
                    //Fondo.Location = this.Location;
                    //Fondo.ShowInTaskbar = false;
                    //Fondo.Show();

                    //sesionesAsignatura.Owner = Fondo;
                    sesionesAsignatura.ShowDialog();
                    sesionesAsignatura.Dispose();

                    //Fondo.Dispose();
                }                
            }

            // Subir
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 2))
            {
                //Form Fondo = new Form();
                using (P_SubirArchivo SubirPlanSesiones = new P_SubirArchivo("Plan de Sesiones"))
                {
                    //Fondo.StartPosition = FormStartPosition.Manual;
                    //Fondo.FormBorderStyle = FormBorderStyle.None;
                    //Fondo.Opacity = .70d;
                    //Fondo.BackColor = Color.Black;
                    //Fondo.WindowState = FormWindowState.Maximized;
                    //Fondo.TopMost = true;
                    //Fondo.Location = this.Location;
                    //Fondo.ShowInTaskbar = false;
                    //Fondo.Show();

                    Program.Evento = 1;

                    SubirPlanSesiones.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    SubirPlanSesiones.NombreAsignatura = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    SubirPlanSesiones.EscuelaProfesional = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    SubirPlanSesiones.Grupo = dgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString();
                    SubirPlanSesiones.CodDocente = CodDocente;

                    //SubirPlanSesiones.Owner = Fondo;
                    SubirPlanSesiones.ShowDialog();
                    SubirPlanSesiones.Dispose();

                    //Fondo.Dispose();
                }
            }
        }
    }
}
