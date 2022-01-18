using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using Ayudas;
using System.Drawing;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasSilabos : Form
    {
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

        public P_TablaAsignaturasAsignadasSilabos()
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
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, CodDocente);
            AccionesTabla();
        }

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, CodDocente, txtBuscar.Text);
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

                byte[] archivo = PlantillaSilabo.Rows[0]["PlantillaSilabo"] as byte[];

                File.WriteAllBytes(fullFilePath, archivo);

                string CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();

                DataTable dtDatosAsignatura = N_Asignatura.BuscarAsignatura(CodAsignatura.Substring(0, 2), CodAsignatura.Substring(0, 5));

                XLWorkbook wb = new XLWorkbook(fullFilePath);

                // Completar información de la asignatura
                wb.Worksheet(1).Cell("C6").Value = dtDatosAsignatura.Rows[0]["NombreAsignatura"].ToString();
                wb.Worksheet(1).Cell("C7").Value = CodAsignatura;
                wb.Worksheet(1).Cell("C8").Value = dtDatosAsignatura.Rows[0]["Categoria"].ToString();
                wb.Worksheet(1).Cell("C9").Value = dtDatosAsignatura.Rows[0]["Creditos"].ToString();

                wb.Worksheet(1).Cell("A21").Value = dtDatosAsignatura.Rows[0]["Sumilla"].ToString();

                // Horario de la asignatura
                DataTable dtHorarioAsignatura = N_HorarioAsignatura.BuscarHorarioAsignatura(CodSemestre, CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6, 2), dgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString());

                wb.Worksheet(1).Cell("C14").Value = dtHorarioAsignatura.Rows[0]["Modalidad"].ToString();

                // Número de horas 3T 2P
                string NumeroHoras;
                int T = 0;
                int P = 0;
                foreach (DataRow dr in dtHorarioAsignatura.Rows)
                {
                    if (dr["Tipo"].ToString() == "T") T += Convert.ToInt32(dr["HorasTeoria"].ToString());
                    else P += Convert.ToInt32(dr["HorasPractica"].ToString());
                }

                if (T == 0) NumeroHoras = P.ToString() + "P";
                else if (P == 0) NumeroHoras = T.ToString() + "T";
                else NumeroHoras = T.ToString() + "T" + " " + P.ToString() + "P";

                wb.Worksheet(1).Cell("C12").Value = NumeroHoras;

                // Aula y horario
                DataTable dtAulaHorario = N_HorarioAsignatura.HorarioAsignaturaDocente(CodSemestre, CodAsignatura, CodDocente);

                wb.Worksheet(1).Cell("C13").Value = dtAulaHorario.Rows[0]["HorarioGeneral"].ToString();
                
                // Completar información del docente
                DataTable dtDatosDocente = N_Docente.BuscarDocente(CodAsignatura.Substring(0, 2), CodDocente);
                string Nombre = dtDatosDocente.Rows[0]["Nombre"].ToString();
                string APaterno = dtDatosDocente.Rows[0]["APaterno"].ToString();
                string AMaterno = dtDatosDocente.Rows[0]["AMaterno"].ToString();

                wb.Worksheet(1).Cell("C15").Value = CodSemestre;

                wb.Worksheet(1).Cell("C16").Value = APaterno + "-" + AMaterno + "-" + Nombre;
                wb.Worksheet(1).Cell("C17").Value = dtDatosDocente.Rows[0]["Email"].ToString();

                // Escuela profesional
                wb.Worksheet(1).Cell("C18").Value = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();

                saveFileDialog.FileName = "Plantilla Sílabo - " + CodAsignatura;

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
                using (P_TablaSilabosAsignatura silabosAsignatura = new P_TablaSilabosAsignatura(dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString()))
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

                    //silabosAsignatura.Owner = Fondo;
                    silabosAsignatura.ShowDialog();
                    silabosAsignatura.Dispose();

                    //Fondo.Dispose();
                }
            }

            // Subir sílabo
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 2))
            {
                //Form Fondo = new Form();
                using (P_SubirArchivo SubirSilabo = new P_SubirArchivo("Silabo"))
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

                    SubirSilabo.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    SubirSilabo.NombreAsignatura = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    SubirSilabo.EscuelaProfesional = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    SubirSilabo.Grupo = dgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString();
                    SubirSilabo.CodDocente = CodDocente;

                    //SubirSilabo.Owner = Fondo;
                    SubirSilabo.ShowDialog();
                    SubirSilabo.Dispose();

                    //Fondo.Dispose();
                }
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }
    }
}
