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

namespace CapaPresentaciones
{
	public partial class P_TablaAsigaturas : Form
	{
		readonly E_Asignatura ObjEntidad = new E_Asignatura();
		readonly N_Asignatura ObjNegocio = new N_Asignatura();
		public void OcultarMoverAncharColumnas()
		{
			dgvMostrarAsignatura.Columns[0].DisplayIndex = 7;//0
			dgvMostrarAsignatura.Columns[1].DisplayIndex = 7;//1

		}
		public void AccionesTabla()
		{


			//dgvMostrarAsignatura.Columns[0].HeaderText = "CodAsignatura";
			//dgvMostrarAsignatura.Columns[1].HeaderText = "NombreAsignatura";
			//dgvMostrarAsignatura.Columns[2].HeaderText = "Credito";
			//dgvMostrarAsignatura.Columns[3].HeaderText = "Categoria";
			//dgvMostrarAsignatura.Columns[4].HeaderText = "HorasTeoria";
			//dgvMostrarAsignatura.Columns[5].HeaderText = "HorasPractica";
			//dgvMostrarAsignatura.Columns[6].HeaderText = "Prerrequisitos";
		}
		public P_TablaAsigaturas()
		{
			InitializeComponent();
			MostrarRegistros();
			OcultarMoverAncharColumnas();
		}
		private void MensajeConfirmacion(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MensajeError(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		public void MostrarRegistros()
		{
			dgvMostrarAsignatura.DataSource = N_Asignatura.MostrarAsignaturas("IF");
			AccionesTabla();
		}
		private void ActualizarDatos(object sender, FormClosedEventArgs e)
		{
			MostrarRegistros();
		}
		public void BuscarRegistros()
		{
			dgvMostrarAsignatura.DataSource = N_Asignatura.BuscarAsignaturas("IF", tbxBuscar.Text);
		}
		private void tbxBuscar_TextChanged(object sender, EventArgs e)
		{
			BuscarRegistros();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			P_DatosAsignatura NuevoRegistro = new P_DatosAsignatura();
			NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
			NuevoRegistro.ShowDialog();
			NuevoRegistro.Dispose();
		}

		private void dgvMostrarAsignatura_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			

			////
			
		}

		private void P_TablaAsigaturas_Load(object sender, EventArgs e)
		{
			
		}

		private void dgvMostrarAsignatura_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvMostrarAsignatura.Rows[e.RowIndex].Cells["editar"].Selected)
			{
				//editar

				P_DatosAsignatura EditarRegistro = new P_DatosAsignatura();
				EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);

				Program.Evento = 1;


				EditarRegistro.txtCod.Text = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[2].Value.ToString();
				EditarRegistro.txtNombre.Text = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[3].Value.ToString();
				EditarRegistro.txtCredito.Text = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[4].Value.ToString();
				EditarRegistro.txtCategoria.Text = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[5].Value.ToString();
				EditarRegistro.txthteoria.Text = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[6].Value.ToString();
				EditarRegistro.txthpractica.Text = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[7].Value.ToString();
				EditarRegistro.txtPrerreq.Text = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[8].Value.ToString();


				EditarRegistro.ShowDialog();
			
				EditarRegistro.Dispose();

			}
			///

			if (dgvMostrarAsignatura.Rows[e.RowIndex].Cells["eliminar"].Selected)
			{
				DialogResult Opcion;
				Opcion = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (Opcion == DialogResult.OK)
				{
					ObjEntidad.CodAsignatura = dgvMostrarAsignatura.Rows[e.RowIndex].Cells[2].Value.ToString();
					ObjNegocio.EliminarAsignatura(ObjEntidad);
					MensajeConfirmacion("Registro eliminado exitosamente");
					MostrarRegistros();
				}

			}

		}
	}
}
