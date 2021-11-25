using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.Data;

namespace CapaPresentaciones
{
	public partial class P_TablaAsignaturas : Form
	{
		readonly E_Asignatura ObjEntidad;
		readonly N_Asignatura ObjNegocio;
		
		public P_TablaAsignaturas()
		{
			ObjEntidad = new E_Asignatura();
			ObjNegocio = new N_Asignatura();
			InitializeComponent();
			MostrarRegistros();
			Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
		}
		
		private void MensajeConfirmacion(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Gestión de Sílabo y Control de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MensajeError(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Gestión de Sílabo y Control de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void AccionesTabla()
		{
			dgvDatos.Columns[0].DisplayIndex = 9;
			dgvDatos.Columns[1].DisplayIndex = 9;

			dgvDatos.Columns[2].HeaderText = "Código";
			dgvDatos.Columns[3].HeaderText = "Nombre";
			dgvDatos.Columns[4].HeaderText = "Nro. Créditos";
			dgvDatos.Columns[5].HeaderText = "Categoría";
			dgvDatos.Columns[6].HeaderText = "Hrs. Teoria";
			dgvDatos.Columns[7].HeaderText = "Hrs. Práctica";
			dgvDatos.Columns[8].HeaderText = "Prerrequisitos";
            dgvDatos.Columns[9].Visible = false;

        }

		public void MostrarRegistros()
		{
			dgvDatos.DataSource = N_Asignatura.MostrarAsignaturas("IF");
			AccionesTabla();
		}

		private void ActualizarDatos(object sender, FormClosedEventArgs e)
		{
			MostrarRegistros();
		}

		public void BuscarRegistros()
		{
			dgvDatos.DataSource = N_Asignatura.BuscarAsignaturas("IF", txtBuscar.Text);
		}

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistros();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            P_DatosAsignatura NuevoRegistro = new P_DatosAsignatura();
            NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistro.ShowDialog();
            NuevoRegistro.Dispose();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                P_DatosAsignatura EditarRegistro = new P_DatosAsignatura();
                
                EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                
                Program.Evento = 1;

                EditarRegistro.txtCodigo.Text = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                EditarRegistro.txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                EditarRegistro.txtCreditos.Text = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                //EditarRegistro.txtCategoria.Text = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                EditarRegistro.cxtCategoriaAsg.SelectedItem = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                EditarRegistro.txtHorasTeoria.Text = dgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString();
                EditarRegistro.txtHorasPractica.Text = dgvDatos.Rows[e.RowIndex].Cells[7].Value.ToString();
                EditarRegistro.txtPrerrequisito.Text = dgvDatos.Rows[e.RowIndex].Cells[8].Value.ToString();
               
                EditarRegistro.txtSumilla.Text = dgvDatos.Rows[e.RowIndex].Cells[9].Value.ToString();

                EditarRegistro.ShowDialog();
                EditarRegistro.Dispose();
            }

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    ObjEntidad.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    ObjNegocio.EliminarAsignatura(ObjEntidad);
                    MensajeConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }
        }
    }
}
