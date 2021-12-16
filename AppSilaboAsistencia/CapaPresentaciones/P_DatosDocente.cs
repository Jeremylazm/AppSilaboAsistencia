using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_DatosDocente : Form
    {
        readonly E_Docente ObjEntidad;
        readonly N_Docente ObjNegocio;

        public P_DatosDocente()
        {
            ObjEntidad = new E_Docente();
            ObjNegocio = new N_Docente();
            InitializeComponent();
            Control[] Controles = { lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            LlenarComboBox();
            ValidarPerfil();
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
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCodigo.Focus();
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        private void ValidarPerfil()
        {
            if (pbPerfil.Image == (Properties.Resources.Perfil_Docente as Image))
            {
                btnRestablecerPerfil.Visible = false;
            }
        }

        private void LlenarComboBox()
        {
            cxtCategoria.SelectedIndex = 0;
            cxtSubcategoria.SelectedIndex = 0;
            cxtRegimen.SelectedIndex = 0;

            if (E_InicioSesion.Acceso == "Administrador")
            {
                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarEscuelas();
            }
            else
            {
                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarEscuelas();
                //cxtEscuela.DataSource = N_EscuelaProfesional.MostrarEscuelas(E_InicioSesion.Usuario);

                cxtEscuela.SelectedIndex = 2;
                //cxtEscuela.Enabled = false;
            }

            cxtEscuela.ValueMember = "CodEscuelaP";
            cxtEscuela.DisplayMember = "Nombre";

            if (E_InicioSesion.Acceso == "Administrador")
            {
                cxtDepartamento.DataSource = N_DepartamentoAcademico.MostrarDepartamentos();
            }
            else
            {
                cxtDepartamento.DataSource = N_DepartamentoAcademico.MostrarDepartamentos();
                cxtDepartamento.SelectedIndex = 4;
                cxtDepartamento.Enabled = false;
            }

            cxtDepartamento.ValueMember = "CodDepartamentoA";
            cxtDepartamento.DisplayMember = "Nombre";
        }

        public string VerificarDatosDocente(out bool EsValido, string Codigo, string APaterno, string AMaterno,
              string Nombre, string Email, string Direccion, string Telefono, string Categoria, string Subcategoria,
              string Regimen, string EProfesional)
        {
            //Inicializando variables de salida
            EsValido = false; //Inicializando como si es falso

            //Definiendo expresiones regulares
            Regex PatronCodigo = new Regex(@"\A[0-9]{5}\Z");
            Regex PatronTelefono = new Regex(@"\A[0-9]{9}\Z");

            //Verificando textbox vacios
            if (Codigo.Trim() == "") return "Debe llenar el código";
            if (APaterno.Trim() == "") return "Debe llenar el apellido paterno";
            if (AMaterno.Trim() == "") return "Debe llenar el apellido materno";
            if (Nombre.Trim() == "") return "Debe llenar el nombre";
            if (Email.Trim() == "") return "Debe llenar el email";
            if (Direccion.Trim() == "") return "Debe llenar la dirección";
            if (Telefono.Trim() == "") return "Debe llenar el telefono";
            if (Categoria.Trim() == "") return "Debe elegir la categoría";
            if (Subcategoria.Trim() == "") return "Debe elegir la subcategoría";
            if (Regimen.Trim() == "") return "Debe elegir el régimen";

            //Verificado si los datos son validos
            if (!PatronCodigo.IsMatch(Codigo)) return "El formato del código es incorrecto";
            if (!PatronTelefono.IsMatch(Telefono)) return "El formato del teléfono es incorrecto";

            //Si paso todo sin problema
            EsValido = true; //Los datos son válidos
            return "Registro insertado correctamente";
        }

        public Image HacerImagenCircular(Image img)
        {
            int x = img.Width / 2;
            int y = img.Height / 2;
            int r = Math.Min(x, y);

            Bitmap tmp = null;
            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }

            return tmp;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            LimpiarCajas();
        }

        private void btnSubirPerfil_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            try
            {
                OpenFileDialog Archivo = new OpenFileDialog();
                Archivo.Filter = "Archivos de Imagen | *.jpg; *.jpeg; *.png; *.gif; *.tif";
                Archivo.Title = "Subir Perfil";

                if (Archivo.ShowDialog() == DialogResult.OK)
                {
                    pbPerfil.Image = HacerImagenCircular(Image.FromFile(Archivo.FileName));
                }
            }
            catch (Exception)
            {
                P_DialogoError.Mostrar("Error al subir perfil");
                //MensajeError("Error al subir perfil");
            }
        }

        private void btnRestablecerPerfil_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            pbPerfil.Image = Properties.Resources.Perfil_Docente as Image;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            //Validar datos ingresados
            bool EsValido;
            string msg = VerificarDatosDocente(out EsValido, txtCodigo.Text, txtAPaterno.Text.ToUpper(), txtAMaterno.Text.ToUpper(), txtNombre.Text.ToUpper()
                , txtEmail.Text + "unsaac.edu.pe", txtDireccion.Text.ToUpper(), txtTelefono.Text, cxtCategoria.SelectedItem.ToString(),
                cxtSubcategoria.SelectedItem.ToString(), cxtRegimen.SelectedItem.ToString(), cxtEscuela.SelectedValue.ToString());

            if (EsValido) //Si los datos ingresados son validos, insertar
            {
                if ((txtCodigo.Text.Trim() != "") &&
                    (txtAPaterno.Text.Trim() != "") &&
                    (txtAMaterno.Text.Trim() != "") &&
                    (txtNombre.Text.Trim() != "") &&
                    (txtEmail.Text.Trim() != "") &&
                    (txtDireccion.Text.Trim() != "") &&
                    (txtTelefono.Text.Trim() != ""))
                {
                    if (Program.Evento == 0)
                    {
                        try
                        {
                            DataTable Resultado = N_Docente.BuscarDocente("IF", txtCodigo.Text);

                            if (Resultado.Rows.Count == 0)
                            {
                                byte[] Perfil = new byte[0];
                                using (MemoryStream MemoriaPerfil = new MemoryStream())
                                {
                                    pbPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                                    Perfil = MemoriaPerfil.ToArray();
                                }
                                ObjEntidad.Perfil = Perfil;
                                ObjEntidad.CodDocente = txtCodigo.Text;
                                ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
                                ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
                                ObjEntidad.Nombre = txtNombre.Text.ToUpper();
                                ObjEntidad.Email = txtEmail.Text + lblDominioEmail.Text;
                                ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                                ObjEntidad.Telefono = txtTelefono.Text;
                                ObjEntidad.Categoria = cxtCategoria.SelectedItem.ToString();
                                ObjEntidad.Subcategoria = cxtSubcategoria.SelectedItem.ToString();
                                ObjEntidad.Regimen = cxtRegimen.SelectedItem.ToString();
                                ObjEntidad.CodDepartamentoA = cxtDepartamento.SelectedValue.ToString();
                                ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();

                                ObjNegocio.InsertarDocente(ObjEntidad);
                                P_DialogoInformacion.Mostrar("Registro insertado exitosamente");
                                //MensajeConfirmacion("Registro insertado exitosamente");
                                Program.Evento = 0;

                                N_InicioSesion InicioSesion = new N_InicioSesion();
                                string Contrasena = InicioSesion.RetornarContraseña(txtCodigo.Text);
                                /*
                                // Enviar un correo con la contraseña para un nuevo usuario
                                try
                                {
                                    SmtpClient clientDetails = new SmtpClient();
                                    clientDetails.Port = 587;
                                    clientDetails.Host = "smtp.gmail.com";
                                    clientDetails.EnableSsl = true;
                                    clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    clientDetails.UseDefaultCredentials = false;
                                    clientDetails.Credentials = new NetworkCredential("denisomarcuyottito@gmail.com", "Tutoriasunsaac5");

                                    MailMessage mailDetails = new MailMessage();
                                    mailDetails.From = new MailAddress("denisomarcuyottito@gmail.com");
                                    mailDetails.To.Add(ObjEntidad.Email);
                                    mailDetails.Subject = "Contraseña del Sistema de Tutoría UNSAAC";
                                    mailDetails.IsBodyHtml = true;
                                    mailDetails.Body = "Tu contraseña es " + Contrasena;
                                    clientDetails.Send(mailDetails);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }*/

                                LimpiarCajas();
                                Close();
                            }
                            else
                            {
                                P_DialogoError.Mostrar("El registro de docente ya existe");
                                //MensajeError("Este registro de docente ya existe");
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
                            P_DialogoPregunta Dialogo = new P_DialogoPregunta("¿Realmente desea editar el registro?");
                            Dialogo.ShowDialog();
                            DialogResult Opcion = Dialogo.DialogResult;
                            //Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.OK)
                            {
                                DataTable Resultado = N_Docente.BuscarDocente("IF", txtCodigo.Text);

                                if (Resultado.Rows.Count != 0)
                                {
                                    byte[] Perfil = new byte[0];
                                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                                    {
                                        pbPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                                        Perfil = MemoriaPerfil.ToArray();
                                    }
                                    ObjEntidad.Perfil = Perfil;
                                    ObjEntidad.CodDocente = txtCodigo.Text;
                                    ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
                                    ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
                                    ObjEntidad.Nombre = txtNombre.Text.ToUpper();
                                    ObjEntidad.Email = txtEmail.Text + lblDominioEmail.Text;
                                    ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                                    ObjEntidad.Telefono = txtTelefono.Text;
                                    ObjEntidad.Categoria = cxtCategoria.SelectedItem.ToString();
                                    ObjEntidad.Subcategoria = cxtSubcategoria.SelectedItem.ToString();
                                    ObjEntidad.Regimen = cxtRegimen.SelectedItem.ToString();
                                    ObjEntidad.CodDepartamentoA = cxtDepartamento.SelectedValue.ToString();
                                    ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();

                                    ObjNegocio.ActualizarDocente(ObjEntidad);
                                    P_DialogoInformacion.Mostrar("Registro editado exitosamente");
                                    //MensajeConfirmacion("Registro editado exitosamente");
                                    Program.Evento = 0;
                                    LimpiarCajas();
                                    Close();
                                }
                                else
                                {
                                    P_DialogoError.Mostrar("El registro de docente no existe");
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }
    }
}
