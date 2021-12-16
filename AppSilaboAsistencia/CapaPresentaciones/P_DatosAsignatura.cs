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
using System.Text.RegularExpressions;

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
            InicializarComboBoxCatergoria();
        }

		private void MensajeConfirmacion(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Gestion de Plan de seciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MensajeError(string Mensaje)
		{
			MessageBox.Show(Mensaje, "Sistema de Gestion de Plan de seciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public string VerificarDatosAsignatura(out bool EsValido, string Codigo, string Nombre,string creditos,
              string categoria, string horasTeoria, string horasPractica, string Prerrequisito, string sumilla)
        {
            //Inicializando variables de salida
            EsValido = false; //Inicializando como si es falso

            //Definiendo expresiones regulares
            Regex PatronCodigo = new Regex(@"\A^[I]{1}[F]{1}[0-9]{3}\Z");
            Regex PatronCreditos = new Regex(@"\A[2-4]{1}\Z");
            Regex PatronHorasTeo = new Regex(@"\A[0-5]{1}\Z");//en caso de 0, el cursopude ser netamente practico
            Regex PatronHorasPra = new Regex(@"\A[0-4]{1}\Z");//en caso de 0, el cursopude ser netamente teorico

            //Verificando textbox vacios
            if (Codigo.Trim() == "") return "Debe llenar el código";
            if (Nombre.Trim() == "") return "Debe llenar Nombre de la asignatura";
            if (creditos.Trim() == "") return "Debe llenar la cantidad de creditos";
            if (categoria.Trim() == "SELECCIONE") return "Debe seleccionar la categoria";
            if (horasTeoria.Trim() == "") return "Debe llenar las horas de teoria(0-4)";
            if (horasPractica.Trim() == "") return "Debe llenar las horas de  practica(0-4)";
            if (sumilla.Trim() == "") return "Debe llenar sumilla";

            //Verificado si los datos son validos
            if (!PatronCodigo.IsMatch(Codigo)) return "El formato del código es incorrecto  ejemplo 'IF[Nro 3 digitos]' ";
            if (!PatronCreditos.IsMatch(creditos)) return "El formato de creditos es incorrecto(2 a 4)";
            if (!PatronHorasTeo.IsMatch(horasTeoria)) return "El formato de horas de Teoria es incorrecto(0 a 5)";
            if (!PatronHorasPra.IsMatch(horasPractica)) return "El formato de horas de Practica es incorrecto(0 a 4)";
            //Si paso todo sin problema
            EsValido = true; //Los datos son válidos
            return "Registro insertado correctamente";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            bool EsValido;
            string msg = VerificarDatosAsignatura(out EsValido, txtCodigo.Text, txtNombre.Text.ToUpper(), txtCreditos.Text.ToString(),
                cxtCategoriaAsg.SelectedItem.ToString(),txtHorasTeoria.Text.ToUpper(),txtHorasPractica.Text.ToUpper(), txtPrerrequisito.Text.ToUpper(), txtSumilla.Text.ToUpper());
          
            if(EsValido)
			{
                if ((txtCodigo.Text.Trim() != "") &&
                (txtNombre.Text.Trim() != "") &&
                (txtCreditos.Text.Trim() != "") &&
                //(txtCategoria.Text.Trim() != "") &&
                (txtHorasTeoria.Text.Trim() != "") &&
                (txtHorasPractica.Text.Trim() != "") &&
                (txtSumilla.Text.Trim() != ""))
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
                                ObjEntidad.Categoria = cxtCategoriaAsg.SelectedItem.ToString();
                                ObjEntidad.HorasTeoria = Convert.ToInt32(txtHorasTeoria.Text);
                                ObjEntidad.HorasPractica = Convert.ToInt32(txtHorasPractica.Text);
                                ObjEntidad.Prerrequisito = txtPrerrequisito.Text.ToUpper();
                                ObjEntidad.Sumilla = txtSumilla.Text.ToUpper();

                                ObjNegocio.InsertarAsignatura(ObjEntidad);
                                P_DialogoInformacion.Mostrar("Registro insertado exitosamente");
                                //MensajeConfirmacion("Registro insertado exitosamente");
                                Program.Evento = 0;

                                Close();
                            }
                            else
                            {
                                P_DialogoError.Mostrar("El registro de asignatura ya existe");
                                //MensajeError("Este registro de Asignatura ya existe");
                            }
                        }
                        catch (Exception ex)
                        {
                            P_DialogoError.Mostrar("Error al insertar el registro");
                            //MensajeError("Error al insertar el registro " + ex);
                        }
                    }
                    else
                    {
                        try
                        {
                            P_DialogoPregunta Dialogo = new P_DialogoPregunta("¿Realmente desea editar el registro ?");
                            Dialogo.ShowDialog();
                            DialogResult Opcion = Dialogo.DialogResult;
                            //Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Gestion de Plan de seciones", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.OK)
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
                                    P_DialogoInformacion.Mostrar("Registro editado exitosamente");
                                    //MensajeConfirmacion("Registro editado exitosamente");
                                    Program.Evento = 0;

                                    Close();
                                }
                                else
                                {
                                    P_DialogoError.Mostrar("El registro de asignatura no existe");
                                    //MensajeError("Este registro de Asignatura no existe");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            P_DialogoError.Mostrar("Error al editar el registro");
                            //MensajeError("Error al editar el registro " + ex);
                        }
                    }
                }
                else
                {
                    P_DialogoError.Mostrar("Debe llenar los campos");
                    //MensajeError("Debe llenar los campos");
                }
            }
            else
            {
                P_DialogoError.Mostrar(msg);
                //MessageBox.Show(msg);
            }

        }
    }
}
