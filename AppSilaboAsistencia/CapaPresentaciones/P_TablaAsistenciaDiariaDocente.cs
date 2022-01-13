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

		public string LmFechaInf;
		public P_TablaAsistenciaDiariaDocente(DataTable pdgv)
		{
			DataTable Semestre = N_Semestre.SemestreActual();
			CodSemestre = Semestre.Rows[0][0].ToString();
            LmFechaInf = Semestre.Rows[0][1].ToString();

			dgvTabla = pdgv;
			ObjEntidadDoc = new E_AsistenciaDiariaDocente();
			ObjNegocioDoc = new N_AsistenciaDiariaDocente();
			InitializeComponent();
			Control[] Controles = { this, lblTitulo, pbLogo, lblFecha, lblMarcarTodos, txtFecha };
			Docker.SubscribeControlsToDragEvents(Controles);
			Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            txtSemestreA.Text = CodSemestre;
			lblFecha.Text += "    ";
			
		}
		private void AccionesTabla()
		{
			dgvDatos.Columns[0].DisplayIndex = 3;
			dgvDatos.Columns[1].DisplayIndex = 3;

			dgvDatos.Columns[2].HeaderText = "Código";
			dgvDatos.Columns[2].ReadOnly = true;
			dgvDatos.Columns[3].HeaderText = "Nombre Completo";
			dgvDatos.Columns[3].ReadOnly = true;
		}
		public void InicializarValores()
		{
			foreach (DataGridViewRow fila in dgvDatos.Rows)
			{
				DataGridViewComboBoxCell textBoxcell = (DataGridViewComboBoxCell)(fila.Cells["cbxObservaciones"]);
				textBoxcell.Value = "";
				fila.Cells[0].Value = ListaImagenes.Images[0];
				fila.Cells[0].Tag = false;
			}
		}
		private void MostrarDocentesNuevoRegistro()
		{
			dgvDatos.DataSource = dgvTabla;
			AccionesTabla();
		}
        public void GuardarRegistroDiarioDocente()
        {
            if (Program.Evento == 0)//add
            {


                // buscar el registro de asistencia de Docente de la fecha actual
                //DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, txtFecha.Text.ToString(), txtFecha.Text.ToString(),"");

                try
                {
                    foreach (DataGridViewRow dr in dgvDatos.Rows)
                    {
                        if (dr.Cells[2].Value.ToString() != "00000")
                        {
                            ObjEntidadDoc.CodSemestre = CodSemestre;
                            ObjEntidadDoc.CodDepartamentoA = "IF";
                            ObjEntidadDoc.Fecha = txtFecha.Text.ToString();
                            ObjEntidadDoc.Hora = hora;
                            ObjEntidadDoc.CodDocente = dr.Cells[2].Value.ToString();
                            ObjEntidadDoc.Asistio = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";
                            ObjEntidadDoc.Observacion = (dr.Cells[1].Value == null) ? "" : dr.Cells[1].Value.ToString();

                            ObjNegocioDoc.RegistrarAsistenciaDiariaDocente(ObjEntidadDoc);
                        }

                    }
                    A_Dialogo.DialogoConfirmacion("Se ha registrado correctamente la asistencia" + Environment.NewLine + " del los Docentes");
                    Program.Evento = 0;
                    Close();


                }    
                catch (Exception)
                {
                    A_Dialogo.DialogoError("Error al insertar el registro...");
                }
            }
            // Editar
            else
            {

                /*try
                {
                    if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea editar el registro?") == DialogResult.Yes)
                    {
                        DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, txtFecha.Text.ToString(), txtFecha.Text.ToString(), "");

                        if (Resultado.Rows.Count != 0)
                        {

                            ObjEntidadDoc.CodSemestre = CodSemestre;
                            ObjEntidadDoc.CodAsignatura = CodAsignatura;
                            ObjEntidadDoc.Fecha = txtFecha.Text.ToString();
                            ObjEntidadDoc.Hora = hora;

                            string TipoSesionActualizado = txtNombreAP.Text.ToString().ToUpper();
                            string NombreTemaActualizado = txtTema.Text.ToString();
                            string fechaActualizado = txtFecha.Text.ToString();
                            string ObsActulizado = "";


                            ObjNegocioDoc.ActualizarAsistenciaDocentePorAsignatura(ObjEntidadDoc, TipoSesionActualizado, NombreTemaActualizado, ObsActulizado);
                            A_Dialogo.DialogoConfirmacion("Se ha Editado  la Asistencia" + Environment.NewLine + " del Docente y los Estudiantes");
                            EditarRegistroEstudiantes();
                            Program.Evento = 0;

                            Close();
                        }
                        else
                        {
                            A_Dialogo.DialogoError("El registro de Docente no existe");
                        }
                    }

                }
                catch (Exception)
                {
                    A_Dialogo.DialogoError("Error al editar el registro");
                }*/
            }
        }

		private void btnCerrar_Click(object sender, EventArgs e)
		{
            Program.Evento = 0;
            Close();
        }

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{

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
            if (Program.Evento == 0)
            {

                MostrarDocentesNuevoRegistro();
                InicializarValores();
                //Program.Evento = 0;
            }
            else
            {
                //MostrarEstudiantesRegistrados();
                //InicializarValoresEditar();
                //Program.Evento = 1;
            }
        }

		private void btnGuardar_Click(object sender, EventArgs e)
		{
            GuardarRegistroDiarioDocente();
            Close();
        }
	}
}
