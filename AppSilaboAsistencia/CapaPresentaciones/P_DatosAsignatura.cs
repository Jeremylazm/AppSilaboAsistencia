using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using CapaPresentaciones.Ayudas;

namespace CapaPresentaciones
{
	public partial class P_DatosAsignatura : Form
	{
        readonly A_Validador Validador;
        readonly E_Asignatura ObjEntidad;
        readonly N_Asignatura ObjNegocio;

        public P_DatosAsignatura()
		{
            Validador = new A_Validador();
            ObjEntidad = new E_Asignatura();
            ObjNegocio = new N_Asignatura();
            InitializeComponent();
            Control[] Controles = { lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            InicializarComboBoxCatergoria();
        }

        private void LimpiarCajas()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCreditos.Clear();
            //txtCategoria.Clear();
            txtHorasTeoria.Clear();
            txtHorasPractica.Clear();
            txtPrerrequisito.Clear();
            txtSumilla.Clear();
            txtCodigo.Focus();
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }
        private void InicializarComboBoxCatergoria()
		{
            cxtCategoriaAsg.SelectedIndex = 0;
        }

        private void RegistrarAsignatura()
        {
            bool CodigoCorrecto = Validador.ValidarCodigoAsignatura(txtCodigo, lblErrorCodigo, pbErrorCodigo, "IF");
            bool NombreCorrecto = Validador.ValidarCampoLleno(txtNombre, lblErrorNombre, pbErrorNombre);
            bool NroCreditosCorrecto = Validador.ValidarDigitoIntervalo(txtCreditos, lblErrorNroCreditos, pbErrorNroCreditos, 2, 4);
            bool HorasTeoriaCorrectas = Validador.ValidarDigitoIntervalo(txtHorasTeoria, lblErrorHorasTeoria, pbErrorHorasTeoria, 0, 5);
            bool HorasPracticaCorrectas = Validador.ValidarDigitoIntervalo(txtHorasPractica, lblErrorHorasPractica, pbErrorHorasPractica, 0, 4);
            bool SumillaCorrecta = Validador.ValidarCampoLleno(txtSumilla, lblErrorSumilla, pbErrorSumilla);

            if (CodigoCorrecto)
            {
                if (NombreCorrecto)
                {
                    if (NroCreditosCorrecto)
                    {
                        if (HorasTeoriaCorrectas)
                        {
                            if (HorasPracticaCorrectas)
                            {
                                if (SumillaCorrecta)
                                {
                                    // Agregar
                                    if (Program.Evento == 0)
                                    {
                                        try
                                        {
                                            DataTable Resultado = N_Asignatura.BuscarAsignatura("IF", txtCodigo.Text);

                                            if (Resultado.Rows.Count == 0)
                                            {
                                                ObjEntidad.CodAsignatura = txtCodigo.Text.ToUpper();
                                                ObjEntidad.NombreAsignatura = txtNombre.Text.ToUpper();
                                                ObjEntidad.Creditos = Convert.ToInt32(txtCreditos.Text);
                                                ObjEntidad.Categoria = cxtCategoriaAsg.SelectedItem.ToString();
                                                ObjEntidad.HorasTeoria = Convert.ToInt32(txtHorasTeoria.Text);
                                                ObjEntidad.HorasPractica = Convert.ToInt32(txtHorasPractica.Text);
                                                ObjEntidad.Prerrequisito = txtPrerrequisito.Text.ToUpper();
                                                ObjEntidad.Sumilla = txtSumilla.Text.ToUpper();

                                                ObjNegocio.InsertarAsignatura(ObjEntidad);
                                                A_Dialogo.DialogoConfirmacion("Registro insertado exitosamente");
                                                Program.Evento = 0;

                                                Close();
                                            }
                                            else
                                            {
                                                A_Dialogo.DialogoError("El registro de asignatura ya existe");
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            A_Dialogo.DialogoError("Error al insertar el registro");
                                        }
                                    }

                                    // Editar
                                    else
                                    {
                                        try
                                        {
                                            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea editar el registro?") == DialogResult.Yes)
                                            {
                                                DataTable Resultado = N_Asignatura.BuscarAsignatura("IF", txtCodigo.Text);

                                                if (Resultado.Rows.Count != 0)
                                                {
                                                    ObjEntidad.CodAsignatura = txtCodigo.Text.ToUpper();
                                                    ObjEntidad.NombreAsignatura = txtNombre.Text.ToUpper();
                                                    ObjEntidad.Creditos = Convert.ToInt32(txtCreditos.Text);
                                                    ObjEntidad.Categoria = cxtCategoriaAsg.SelectedItem.ToString();
                                                    ObjEntidad.HorasTeoria = Convert.ToInt32(txtHorasTeoria.Text);
                                                    ObjEntidad.HorasPractica = Convert.ToInt32(txtHorasPractica.Text);
                                                    ObjEntidad.Prerrequisito = txtPrerrequisito.Text.ToUpper();
                                                    ObjEntidad.Sumilla = txtSumilla.Text.ToUpper();

                                                    ObjNegocio.ActualizarAsignatura(ObjEntidad);
                                                    A_Dialogo.DialogoConfirmacion("Registro editado exitosamente");
                                                    Program.Evento = 0;

                                                    Close();
                                                }
                                                else
                                                {
                                                    A_Dialogo.DialogoError("El registro de asignatura no existe");
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            A_Dialogo.DialogoError("Error al editar el registro");
                                        }
                                    }
                                }
                                else
                                {
                                    Validador.EnfocarCursor(txtSumilla);
                                }
                            }
                            else
                            {
                                Validador.EnfocarCursor(txtHorasPractica);
                            }
                        }
                        else
                        {
                            Validador.EnfocarCursor(txtHorasTeoria);
                        }
                    }
                    else
                    {
                        Validador.EnfocarCursor(txtCreditos);
                    }
                }
                else
                {
                    Validador.EnfocarCursor(txtNombre);
                }
            }
            else
            {
                Validador.EnfocarCursor(txtCodigo);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            RegistrarAsignatura();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            LimpiarCajas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarCodigoAsignatura(txtCodigo, lblErrorCodigo, pbErrorCodigo, "IF"))
            {
                pbErrorCodigo.Visible = false;
                lblErrorCodigo.Visible = false;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarCampoLleno(txtNombre, lblErrorNombre, pbErrorNombre))
            {
                pbErrorNombre.Visible = false;
                lblErrorNombre.Visible = false;
            }
        }

        private void txtCreditos_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarDigitoIntervalo(txtCreditos, lblErrorNroCreditos, pbErrorNroCreditos, 2, 4))
            {
                pbErrorNroCreditos.Visible = false;
                lblErrorNroCreditos.Visible = false;
            }
        }

        private void txtHorasTeoria_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarDigitoIntervalo(txtHorasTeoria, lblErrorHorasTeoria, pbErrorHorasTeoria, 0, 5))
            {
                pbErrorHorasTeoria.Visible = false;
                lblErrorHorasTeoria.Visible = false;
            }
        }

        private void txtHorasPractica_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarDigitoIntervalo(txtHorasPractica, lblErrorHorasPractica, pbErrorHorasPractica, 0, 4))
            {
                lblErrorHorasPractica.Visible = false;
                pbErrorHorasPractica.Visible = false;
            }
        }

        private void txtSumilla_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarCampoLleno(txtSumilla, lblErrorSumilla, pbErrorSumilla))
            {
                pbErrorSumilla.Visible = false;
                lblErrorSumilla.Visible = false;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarAsignatura();
        }

        private void txtCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarAsignatura();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarAsignatura();
        }

        private void txtHorasTeoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarAsignatura();
        }

        private void txtPrerrequisito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarAsignatura();
        }

        private void txtHorasPractica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarAsignatura();
        }

        private void txtSumilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarAsignatura();
        }
    }
}
