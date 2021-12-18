using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using ControlesPerzonalizados.Ayudas;

namespace CapaPresentaciones
{
    public partial class P_DatosDocente : Form
    {
        readonly A_Validador Validador;
        readonly E_Docente ObjEntidad;
        readonly N_Docente ObjNegocio;

        public P_DatosDocente()
        {
            Validador = new A_Validador();
            ObjEntidad = new E_Docente();
            ObjNegocio = new N_Docente();
            InitializeComponent();
            Control[] Controles = { lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            LlenarComboBox();
            ValidarPerfil();
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
                cxtDepartamento.DataSource = N_DepartamentoAcademico.MostrarDepartamentos();

                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarEscuelas();
            }
            else
            {
                cxtDepartamento.DataSource = N_DepartamentoAcademico.MostrarDepartamentos();
                cxtDepartamento.SelectedIndex = 4;
                cxtDepartamento.Enabled = false;

                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarEscuelas();
                //cxtEscuela.DataSource = N_EscuelaProfesional.MostrarEscuelas(E_InicioSesion.Usuario);
                cxtEscuela.SelectedIndex = 4;
                cxtEscuela.Enabled = false;
            }

            cxtDepartamento.ValueMember = "CodDepartamentoA";
            cxtDepartamento.DisplayMember = "Nombre";

            cxtEscuela.ValueMember = "CodEscuelaP";
            cxtEscuela.DisplayMember = "Nombre";
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

        private void RegistrarDocente()
        {
            bool CodigoCorrecto = Validador.ValidarNumeroLimitado(txtCodigo, lblErrorCodigo, pbErrorCodigo, 5);
            bool CorreoCorrecto = Validador.ValidarCampoLleno(txtEmail, lblErrorCorreo, pbErrorCorreo);
            bool APaternoCorrecto = Validador.ValidarCampoLleno(txtAPaterno, lblErrorAPaterno, pbErrorAPaterno);
            bool AMaternoCorrecto = Validador.ValidarCampoLleno(txtAMaterno, lblErrorAMaterno, pbErrorAMaterno);
            bool NombreCorrecto = Validador.ValidarCampoLleno(txtNombre, lblErrorNombre, pbErrorNombre);
            bool TelefonoCorrecto = Validador.ValidarNumeroLimitado(txtTelefono, lblErrorTelefono, pbErrorTelefono, 9);
            bool DireccionCorrecta = Validador.ValidarCampoLleno(txtDireccion, lblErrorDireccion, pbErrorDireccion);

            if (CodigoCorrecto)
            {
                if (CorreoCorrecto)
                {
                    if (APaternoCorrecto)
                    {
                        if (AMaternoCorrecto)
                        {
                            if (NombreCorrecto)
                            {
                                if (TelefonoCorrecto)
                                {
                                    if (DireccionCorrecta)
                                    {
                                        // Agregar
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
                                                    P_DialogoRespuesta1.Mostrar("El registro de docente ya existe");
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                P_DialogoRespuesta1.Mostrar("Error al insertar el registro");
                                            }
                                        }

                                        // Editar
                                        else
                                        {
                                            try
                                            {
                                                P_DialogoRespuesta2 Dialogo = new P_DialogoRespuesta2("¿Realmente desea editar el registro?");
                                                Dialogo.ShowDialog();
                                                DialogResult Opcion = Dialogo.DialogResult;
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
                                                        Program.Evento = 0;
                                                        LimpiarCajas();
                                                        Close();
                                                    }
                                                    else
                                                    {
                                                        P_DialogoRespuesta1.Mostrar("El registro de docente no existe");
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                P_DialogoRespuesta1.Mostrar("Error al editar el registro");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Validador.EnfocarCursor(txtDireccion);
                                    }
                                }
                                else
                                {
                                    Validador.EnfocarCursor(txtTelefono);
                                }
                            }
                            else
                            {
                                Validador.EnfocarCursor(txtNombre);
                            }
                        }
                        else
                        {
                            Validador.EnfocarCursor(txtAMaterno);
                        }
                    }
                    else
                    {
                        Validador.EnfocarCursor(txtAPaterno);
                    }
                }
                else
                {
                    Validador.EnfocarCursor(txtEmail);
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
            RegistrarDocente();
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
                P_DialogoRespuesta1.Mostrar("Error al subir perfil");
            }
        }

        private void btnRestablecerPerfil_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            pbPerfil.Image = Properties.Resources.Perfil_Docente as Image;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarNumeroLimitado(txtCodigo, lblErrorCodigo, pbErrorCodigo, 5))
            {
                pbErrorCodigo.Visible = false;
                lblErrorCodigo.Visible = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarCampoLleno(txtEmail, lblErrorCorreo, pbErrorCorreo))
            {
                pbErrorCorreo.Visible = false;
                lblErrorCorreo.Visible = false;
            }
        }

        private void txtAPaterno_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarCampoLleno(txtAPaterno, lblErrorAPaterno, pbErrorAPaterno))
            {
                pbErrorAPaterno.Visible = false;
                lblErrorAPaterno.Visible = false;
            }
        }

        private void txtAMaterno_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarCampoLleno(txtAMaterno, lblErrorAMaterno, pbErrorAMaterno))
            {
                pbErrorAMaterno.Visible = false;
                lblErrorAMaterno.Visible = false;
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarNumeroLimitado(txtTelefono, lblErrorTelefono, pbErrorTelefono, 9))
            {
                pbErrorTelefono.Visible = false;
                lblErrorTelefono.Visible = false;
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (Validador.ValidarCampoLleno(txtDireccion, lblErrorDireccion, pbErrorDireccion))
            {
                pbErrorDireccion.Visible = false;
                lblErrorDireccion.Visible = false;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarDocente();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarDocente();
        }

        private void txtAPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarDocente();
        }

        private void txtAMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarDocente();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarDocente();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarDocente();
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                RegistrarDocente();
        }
    }
}
