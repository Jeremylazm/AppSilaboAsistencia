using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using Ayudas;
using System.Drawing;

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

            //Form Fondo = new Form();
            using (P_DatosAsignatura NuevoRegistro = new P_DatosAsignatura())
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

                NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                //NuevoRegistro.Owner = Fondo;
                NuevoRegistro.ShowDialog();
                NuevoRegistro.Dispose();

                //Fondo.Dispose();
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                //Form Fondo = new Form();
                using (P_DatosAsignatura EditarRegistro = new P_DatosAsignatura())
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

                    //EditarRegistro.Owner = Fondo;
                    EditarRegistro.ShowDialog();
                    EditarRegistro.Dispose();

                    //Fondo.Dispose();
                }
            }

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
                {
                    ObjEntidad.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    ObjNegocio.EliminarAsignatura(ObjEntidad);
                    A_Dialogo.DialogoConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }
        }
    }
}
