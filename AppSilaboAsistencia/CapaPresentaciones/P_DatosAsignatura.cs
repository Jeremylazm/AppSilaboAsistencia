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
		readonly E_Asignatura ObjEntidad;// = new E_Docente();
		readonly N_Asignatura ObjNegocio;// = new N_Docente();
		public P_DatosAsignatura()
		{
			InitializeComponent();
		}
		private void MensajeConfirmacion(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MensajeError(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
            if ((txtCod.Text.Trim() != "") &&
                    (txtNombre.Text.Trim() != "") &&
                    (txtCredito.Text.Trim() != "") &&
                    (txtCategoria.Text.Trim() != "") &&
                    (txthteoria.Text.Trim() != "") &&
                    (txthpractica.Text.Trim() != ""))
            {
                if (Program.Evento == 0)//add
                {
                    try
                    {
                        DataTable Resultado = N_Asignatura.BuscarAsignatura("IF",txtCod.Text);

                        if (Resultado.Rows.Count == 0)
                        {
                            
                            ObjEntidad.CodAsignatura = txtCod.Text.ToUpper();
                            ObjEntidad.NombreAsignatura = txtNombre.Text.ToUpper();
                            ObjEntidad.Creditos = Convert.ToInt32(txtCredito.Text);
                            ObjEntidad.Categoria = txtCategoria.Text.ToUpper();
                            ObjEntidad.HorasTeoria = Convert.ToInt32(txthteoria.Text);
                            ObjEntidad.HorasPractica = Convert.ToInt32(txthpractica.Text);
                            ObjEntidad.Prerrequisito = txtPrerreq.Text.ToUpper();
                          
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
                            DataTable Resultado = N_Asignatura.BuscarAsignatura("IF",txtCod.Text);

                            if (Resultado.Rows.Count != 0)
                            {

                                ObjEntidad.CodAsignatura = txtCod.Text.ToUpper();
                                ObjEntidad.NombreAsignatura = txtNombre.Text.ToUpper();
                                ObjEntidad.Creditos = Convert.ToInt32(txtCredito.Text);
                                ObjEntidad.Categoria = txtCategoria.Text.ToUpper();
                                ObjEntidad.HorasTeoria = Convert.ToInt32(txthteoria.Text);
                                ObjEntidad.HorasPractica = Convert.ToInt32(txthpractica.Text);
                                ObjEntidad.Prerrequisito = txtPrerreq.Text.ToUpper();

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
