using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using SpreadsheetLight;
using ClosedXML.Excel;
using Ayudas;
using System.Globalization;
namespace CapaPresentaciones
{
	public partial class P_TablaAsistenciaDiariaDocente : Form
	{
		private readonly string CodSemestre;
		
		//public string CodDocente;
		readonly E_AsistenciaDiariaDocente ObjEntidadDoc;
		readonly N_AsistenciaDiariaDocente ObjNegocioDoc;
		public string hora;
		public DataTable dgvTabla;
        public string CodDepartamentoA;
		public string LmFechaInf;
		public P_TablaAsistenciaDiariaDocente(DataTable pdgv)
		{
			DataTable Semestre = N_Semestre.SemestreActual();
			CodSemestre = Semestre.Rows[0][0].ToString();
            LmFechaInf = DateTime.ParseExact(Semestre.Rows[0][1].ToString(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
            CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
            dgvTabla = pdgv;
			ObjEntidadDoc = new E_AsistenciaDiariaDocente();
			ObjNegocioDoc = new N_AsistenciaDiariaDocente();
			InitializeComponent();
            //MostrarEstudiantesRegistrados();
            
            Control[] Controles = { this, lblTitulo, pbLogo, lblFecha, lblMarcarTodos, txtFecha};
			Docker.SubscribeControlsToDragEvents(Controles);
			Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            txtSemestre.Text = CodSemestre;
			lblFecha.Text += "    ";
			
		}
        private void AccionesTablaEditar()
        {
            dgvDatos.Columns[0].DisplayIndex = 8;
            dgvDatos.Columns[1].DisplayIndex = 8;

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
            dgvDatos.Columns[7].Visible = false;
            dgvDatos.Columns[8].Visible = false;


        }
        public void MostrarDocentesRegistrados()
        {
            
            
            int i = 0;
            foreach (DataRow fila in dgvTabla.Rows)
            {
                //DataGridViewComboBoxCell textBoxcell = (DataGridViewComboBoxCell)(fila["cbxObservaciones"]);
                //textBoxcell.Value = fila[6];
                //fila.Cells[0].Value = (fila.Cells[6].Value.Equals("SI")) ? ListaImagenes.Images[1] : ListaImagenes.Images[0];
                if (fila[5].Equals("SI"))
                {
                    
                    dgvDatos.Rows.Add(ListaImagenes.Images[1], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4],fila[5],fila[6]);
                    dgvDatos.Rows[i].Cells[0].Tag = true;
                }
                else
                {
                    dgvDatos.Rows.Add(ListaImagenes.Images[0], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6]);


                    dgvDatos.Rows[i].Cells[0].Tag = false;
                }

                i += 1;

            }
            //DataTable dtFromGrid = new DataTable();
            //dtFromGrid = dgvDatos.DataSource as DataTable;
            //InicializarValoresEditar();
            //dgvDatos.DataSource = dgv;
            AccionesTablaEditar();
           

        }
        public void BuscarRegistros()
        {
            //dgvDatos.DataSource = N_Docente.BuscarDocentes(CodDepartamentoA, txtBuscar.Text);
            DataTable Docentes = N_Docente.BuscarDocentes(CodDepartamentoA, txtBuscar.Text);
            this.dgvDatos.DataSource = null;
            this.dgvDatos.Rows.Clear();

            if (Docentes.Rows.Count != 0)
            {

                foreach (DataRow f in Docentes.Rows)
                {

                    if (dgvTabla.Rows.Count != 0)
                    {

                        int i = 0;
                        foreach (DataRow fila in dgvTabla.Rows)
                        {
							if (f[2].ToString() == fila[1].ToString())
							{
                                if (fila[5].ToString() == "SI")
                                {

                                    dgvDatos.Rows.Add(ListaImagenes.Images[1], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6]);
                                    dgvDatos.Rows[i].Cells[0].Tag = true;
                                }
                                else
                                {
                                    dgvDatos.Rows.Add(ListaImagenes.Images[0], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6]);


                                    dgvDatos.Rows[i].Cells[0].Tag = false;
                                }

                                i += 1;
                            }
                            
                        }
                        AccionesTablaEditar();
                    }
                }
            }

        }
        //buscar la hora en que sergistró la asistencia de un docente
        public string HoraRegistroAsistenciaDocente(string pCodSemestre,string pDepartamentoA,string pFecha,string pCodDocente)
		{
            DataTable Resultado = N_AsistenciaDiariaDocente.BuscarAsistenciaDocente(pCodSemestre,pDepartamentoA, DateTime.Parse(pFecha).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), pCodDocente);
            if(Resultado.Rows.Count != 0)
			{
                return Resultado.Rows[0][0].ToString();
            }
            return null;
		}
        public void GuardarRegistroDiarioDocenteEditado()
        {

            try
            {
                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea editar el registro?") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow dr in dgvDatos.Rows)
                    {
                        string HoraReg = HoraRegistroAsistenciaDocente(CodSemestre, CodDepartamentoA, DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), dr.Cells[3].Value.ToString());

                        ObjEntidadDoc.CodSemestre = CodSemestre;
                        ObjEntidadDoc.Fecha = DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                        ObjEntidadDoc.Hora = HoraReg;
                        ObjEntidadDoc.CodDocente = dr.Cells[3].Value.ToString();

                        string Asistio = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";
                        string ObsActualizada = (dr.Cells[1].Value == null) ? "" : dr.Cells[1].Value.ToString();
                        

                        ObjNegocioDoc.ActualizarAsistenciaDiariaDocente(ObjEntidadDoc, Asistio, ObsActualizada);

                    }
                    A_Dialogo.DialogoConfirmacion("Se ha Editado correctamente la asistencia" + Environment.NewLine + " del los Docentes");

                    Close();
                }

            }
            catch (Exception)
            {
                A_Dialogo.DialogoError("Error al editar el registro");
            }
            
        }

        private void AjustarTabla()
        {
            // Verificar el numero de filas de los resultados
            if (dgvDatos.Rows.Count <= 20)
            {
                sbDatos.Visible = false;
                dgvDatos.Width = 1124;
                this.Height = dgvDatos.Rows.Count * 26 + 253;
            }
            else
            {
                sbDatos.Visible = true;
                sbDatos.Maximum = dgvDatos.Rows.Count - 20;
                this.Height = 773;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
		{
            Close();
        }

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
            BuscarRegistros();

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
                    Fila.Cells[0].Tag = true;
                }
            }
            else
            {
                foreach (DataGridViewRow Fila in dgvDatos.Rows)
                {
                    Fila.Cells[0].Value = ListaImagenes.Images[0];
                    Fila.Cells[0].Tag = false;
                }
            }
        }

		private void P_TablaAsistenciaDiariaDocente_Load(object sender, EventArgs e)
		{

            
                MostrarDocentesRegistrados();
                //InicializarValoresEditar();
                AjustarTabla();

        }

		private void btnGuardar_Click(object sender, EventArgs e)
		{
            GuardarRegistroDiarioDocenteEditado();
            Close();
        }

		private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
            //InicializarValoresEditar();
        }
    }
}
