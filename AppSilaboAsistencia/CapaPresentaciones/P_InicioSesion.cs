using System.Windows.Forms;
using System.Text.RegularExpressions;
using CapaEntidades;
using CapaNegocios;
using System;

namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        public P_InicioSesion()
        {
            InitializeComponent();
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        public void IniciarSesion(string Usuario, string Contraseña)
        {

            if (Usuario == "" && Contraseña == "")
            {
                /*Mensaje = "Llenar ambos campos";
                if (Test == false)
                    MensajeError(Mensaje);
                return Mensaje;*/
            }
            else if (ValidarUsuario())
            {
                if (ValidarContraseña())
                {
                    // Patrones de usuario de docente
                    Regex PatronCodigo1 = new Regex(@"\A[0-9]{5}\Z");
                    Regex PatronCodigo2 = new Regex(@"\A[0-9]{6}\Z");

                    // Patron de usuario de administrador
                    Regex PatronCodigo3 = new Regex(@"\A(AD)[A-Z]{2}\Z");

                    // Patrón de usuario de director de escuela
                    Regex PatronCodigo4 = new Regex(@"\A(DE)[A-Z]{2}\Z");

                    if (PatronCodigo1.IsMatch(Usuario) || PatronCodigo2.IsMatch(Usuario) || PatronCodigo3.IsMatch(Usuario) || PatronCodigo4.IsMatch(Usuario))
                    {

                        N_InicioSesion InicioSesion = new N_InicioSesion();
                        var ValidarDatos = InicioSesion.IniciarSesion(Usuario, Contraseña);

                        // Si los datos son correctos
                        if (ValidarDatos == true)
                        {

                            Hide();

                            //Mostrar mensaje de bienvenida
                            //P_Bienvenida Bienvenida = new P_Bienvenida();

                            //Bienvenida.ShowDialog();

                            // Si el usuario es administrador
                            if (E_InicioSesion.Acceso == E_Acceso.Administrador)
                            {
                                P_Menu Menu = new P_Menu
                                {
                                    Acceso = "Administrador"
                                };
                                Menu.Show();
                            }

                            // Si el usuarios es Jefe de Departamento Académico
                            if (E_InicioSesion.Acceso == E_Acceso.JefeDepartamentoAcademico)
                            {
                                P_Menu Menu = new P_Menu
                                {
                                    Acceso = "Jefe de Departamento Academico"
                                };
                                Menu.Show();
                            }

                            // Si el usuario es Director de Escuela
                            if (E_InicioSesion.Acceso == E_Acceso.DirectorEscuelaProfesional)
                            {
                                P_Menu Menu = new P_Menu
                                {
                                    Acceso = "Director de Escuela Profesional"
                                };
                                Menu.Show();
                            }

                            // Si el usuario es Docente
                            if (E_InicioSesion.Acceso == E_Acceso.Docente)
                            {
                                P_Menu Menu = new P_Menu
                                {
                                    Acceso = "Docente"
                                };
                                Menu.Show();
                            }
                        }
                        // Si los datos son incorrectos
                        else
                        {
                            txtUsuario.Clear();
                            txtContraseña.Clear();
                            ActiveControl = txtUsuario;
                            errorProvider1.SetError(txtUsuario, "");
                            errorProvider1.SetError(txtContraseña, "");
                            P_DialogoError.Mostrar("Usuario o Contraseña incorrectos");
                            //MessageBox.Show("Usuario o Contraseña incorrectos");
                            /*Mensaje = "Datos incorrectos";
                            return Mensaje;*/
                        }
                    }
                    // Si la longitud del usuario no es de 5 o 6 dígitos
                    /*else
                    {
                        Mensaje = "El usuario debe de tener 5 o 6 dígitos";
                        if (Test == false)
                        {
                            MensajeError(Mensaje);
                            txtContraseña.Clear();
                            txtUsuario.Focus();
                        }
                        return Mensaje;
                    }*/
                }
                // Si el campo de la contraseña está vacío
                else
                {
                    ValidarContraseña();
                    txtContraseña.Focus();

                    /*Mensaje = "Llenar el campo contraseña";
                    return Mensaje;*/
                }
            }
            // Si el campo del usuario está vacío
            else
            {
                ValidarUsuario();
                //MensajeError("Ingrese su usuario, por favor");
                txtUsuario.Focus();
                //Mensaje = "Llenar el campo usuario";
                //return Mensaje;
            }
            //return Mensaje;
        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            ActualizarColor();
            IniciarSesion(txtUsuario.Text, txtContraseña.Text);
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void P_InicioSesion_Load(object sender, System.EventArgs e)
        {
            ActiveControl = txtUsuario;
        }

        private void txtContraseña_TextChange(object sender, System.EventArgs e)
        {
            if (txtContraseña.Text != "")
            {
                txtContraseña.PasswordChar = '*';
            }
            else
            {
                txtContraseña.PasswordChar = '\0';
            }
            errorProvider1.SetError(txtContraseña, "");
        }

        private bool ValidarUsuario()
        {
            bool val = true;
            if (txtUsuario.Text == "")
            {
                errorProvider1.SetError(txtUsuario, "Por favor ingresa tu usuario");
                val = false;
            }
            else
            {
                errorProvider1.SetError(txtUsuario, "");
                if (txtUsuario.Text.Length != 5)
                {
                    errorProvider1.SetError(txtUsuario, "La longitud debe ser de 5 dígitos");
                    val = false;
                }
                else
                {
                    errorProvider1.SetError(txtUsuario, "");
                }
            }
            return val;
        }

        private bool ValidarContraseña()
        {
            bool val = true;
            if (txtContraseña.Text == "")
            {
                errorProvider1.SetError(txtContraseña, "Por favor ingresa tu contraseña");
                val = false;
            }
            else
            {
                errorProvider1.SetError(txtContraseña, "");
            }
            return val;
        }

        private void txtUsuario_TextChange(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUsuario, "");
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                IniciarSesion(txtUsuario.Text, txtContraseña.Text);
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                IniciarSesion(txtUsuario.Text, txtContraseña.Text);
        }
    }
}
