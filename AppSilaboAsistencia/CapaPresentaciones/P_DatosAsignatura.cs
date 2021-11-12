using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
	public partial class P_DatosAsignatura : Form
	{
		readonly E_Asignatura ObjEntidad;
        readonly N_Asignatura ObjNegocio;

        public P_DatosAsignatura()
		{
            ObjEntidad = new E_Asignatura();
            ObjNegocio = new N_Asignatura();
            InitializeComponent();
            Control[] Controles = { lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
        }

		private void MensajeConfirmacion(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MensajeError(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

        private void LimpiarCajas()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCreditos.Clear();
            txtCategoria.Clear();
            txtHorasTeoria.Clear();
            txtHorasPractica.Clear();
            txtPrerrequisito.Clear();
            txtCodigo.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((txtCodigo.Text.Trim() != "") &&
                (txtNombre.Text.Trim() != "") &&
                (txtCreditos.Text.Trim() != "") &&
                (txtCategoria.Text.Trim() != "") &&
                (txtHorasTeoria.Text.Trim() != "") &&
                (txtHorasPractica.Text.Trim() != ""))
            {
                if (Program.Evento == 0)//add
                {
                    try
                    {
                        DataTable Resultado = N_Asignatura.BuscarAsignatura("IF", txtCodigo.Text);

                        if (Resultado.Rows.Count == 0)
                        {

                            ObjEntidad.CodAsignatura = txtCodigo.Text.ToUpper();
                            ObjEntidad.NombreAsignatura = txtNombre.Text.ToUpper();
                            ObjEntidad.Creditos = Convert.ToInt32(txtCreditos.Text);
                            ObjEntidad.Categoria = txtCategoria.Text.ToUpper();
                            ObjEntidad.HorasTeoria = Convert.ToInt32(txtHorasTeoria.Text);
                            ObjEntidad.HorasPractica = Convert.ToInt32(txtHorasPractica.Text);
                            ObjEntidad.Prerrequisito = txtPrerrequisito.Text.ToUpper();

                            ObjNegocio.InsertarAsignatura(ObjEntidad);
                            MensajeConfirmacion("Registro insertado exitosamente");
                            Program.Evento = 0;

                            Close();
                        }
                        else
                        {
                            MensajeError("Este registro de docente ya existe");
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al insertar el registro " + ex);
                    }
                }
                else
                {
                    try
                    {
                        DialogResult Opcion;
                        Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (Opcion == DialogResult.OK)
                        {
                            DataTable Resultado = N_Asignatura.BuscarAsignatura("IF", txtCodigo.Text);

                            if (Resultado.Rows.Count != 0)
                            {

                                ObjEntidad.CodAsignatura = txtCodigo.Text.ToUpper();
                                ObjEntidad.NombreAsignatura = txtNombre.Text.ToUpper();
                                ObjEntidad.Creditos = Convert.ToInt32(txtCreditos.Text);
                                ObjEntidad.Categoria = txtCategoria.Text.ToUpper();
                                ObjEntidad.HorasTeoria = Convert.ToInt32(txtHorasTeoria.Text);
                                ObjEntidad.HorasPractica = Convert.ToInt32(txtHorasPractica.Text);
                                ObjEntidad.Prerrequisito = txtPrerrequisito.Text.ToUpper();

                                ObjNegocio.ActualizarAsignatura(ObjEntidad);
                                MensajeConfirmacion("Registro editado exitosamente");
                                Program.Evento = 0;

                                Close();
                            }
                            else
                            {
                                MensajeError("Este registro de docente no existe");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al editar el registro " + ex);
                    }
                }
            }
            else
            {
                MensajeError("Debe llenar los campos");
            }
        }
    }
}
