using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data.OleDb;
using SpreadsheetLight;
using System.Data;

namespace CapaPresentaciones
{
    public partial class P_TablaAsistenciaEstudiantes : Form
    {
        public string CodAsignatura;
        public string CodDocente;
        readonly E_AsistenciaEstudiante ObjEntidadEstd;
        readonly N_AsistenciaEstudiante ObjNegocioEstd;
        readonly E_AsistenciaDocente ObjEntidadDoc;
        readonly N_AsistenciaDocente ObjNegocioDoc;
        public string hora = DateTime.Now.ToString("hh:mm:ss");
        private DataTable PlanSesion;
        public P_TablaAsistenciaEstudiantes(string pCodAsignatura, string pCodDocente)
        {
            CodAsignatura = pCodAsignatura;
            CodDocente = pCodDocente;
            ObjEntidadEstd = new E_AsistenciaEstudiante();
            ObjNegocioEstd = new N_AsistenciaEstudiante();
            ObjEntidadDoc = new E_AsistenciaDocente();
            ObjNegocioDoc = new N_AsistenciaDocente();
            InitializeComponent();

            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
            lblFecha.Text += "    " + DateTime.Now.ToString("dd/MM/yyyy").ToString();
            PlanSesion = N_Catalogo.RecuperarPlanDeSesionAsignatura("2021-II", CodAsignatura, CodDocente);
            MostrarEstudiantes();
        }
        
        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].DisplayIndex = 6;
            dgvDatos.Columns[2].HeaderText = "Id.";
            dgvDatos.Columns[2].ReadOnly = true;
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[3].ReadOnly = true;
            dgvDatos.Columns[4].HeaderText = "Apellido Paterno";
            dgvDatos.Columns[4].ReadOnly = true;
            dgvDatos.Columns[5].HeaderText = "Apellido Materno";
            dgvDatos.Columns[5].ReadOnly = true;
            dgvDatos.Columns[6].HeaderText = "Nombre";
            dgvDatos.Columns[6].ReadOnly = true;

            dgvDatos.Rows[6].Cells[0].Value = ListaImagenes.Images[0];
        }

        private void MostrarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.BuscarEstudiantesAsignatura("2021-II", CodAsignatura.Substring(6), CodAsignatura);
            AccionesTabla();
        }

        public void BuscarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.BuscarEstudiantesMatriculadosAsignatura("2021-II", CodAsignatura.Substring(6), CodAsignatura, txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEstudiantes();
        }

        private void btnSesiones_Click(object sender, EventArgs e)
        {
            P_TablaSesiones Sesiones = new P_TablaSesiones();

            Sesiones.ShowDialog();
            Sesiones.Dispose();
            valor++;
            string Direccion = @"D:\Yo\Plantilla Sesion Pruebas.xlsx";
            SLDocument sl = new SLDocument(Direccion);
            if (sl.GetCellValueAsString(valor, 3) == "")
            {
                valor++;
            }
            txtTema.Text = sl.GetCellValueAsString(valor, 3);
        }

        private void dgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
            {
                return;
            }

            var DataGrid = (sender as DataGridView);

            if (e.ColumnIndex == 0)
                DataGrid.Cursor = Cursors.Hand;
            else
                DataGrid.Cursor = Cursors.Default;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
            {
                return;
            }

            var DataGrid = (sender as DataGridView);

            if (e.ColumnIndex == 0)
            {
                var Celda = DataGrid.Rows[e.RowIndex].Cells[0];

                if ((Celda.Tag == null) || !((bool)Celda.Tag))
                {
                    // Falso
                    DataGrid.Rows[e.RowIndex].Cells[0].Value = ListaImagenes.Images[1];
                    DataGrid.Rows[e.RowIndex].Cells[0].Tag = true;
                }
                else
                {
                    DataGrid.Rows[e.RowIndex].Cells[0].Value = ListaImagenes.Images[0];
                    DataGrid.Rows[e.RowIndex].Cells[0].Tag = false;
                }
            }
        }

        private void ckbMarcarTodos_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (ckbMarcarTodos.Checked)
            {
                foreach (DataGridViewRow Fila in dgvDatos.Rows)
                {
                    Fila.Cells[0].Value = ListaImagenes.Images[1];
                }
            }
            else
            {
                foreach (DataGridViewRow Fila in dgvDatos.Rows)
                {
                    Fila.Cells[0].Value = ListaImagenes.Images[0];
                }
            }
        }
        
        int valor = 9;
        private void P_TablaAsistenciaEstudiantes_Load(object sender, EventArgs e)
        {
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

            byte[] archivo = PlanSesion.Rows[0]["PlanSesiones"] as byte[];

            File.WriteAllBytes(fullFilePath, archivo);

            SLDocument sl = new SLDocument(fullFilePath);
            txtTema.Text = sl.GetCellValueAsString(valor, 3);
        }
    }
}
