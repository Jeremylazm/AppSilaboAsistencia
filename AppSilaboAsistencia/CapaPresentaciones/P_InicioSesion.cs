using System.Windows.Forms;
using System.Text.RegularExpressions;
using CapaEntidades;
using CapaNegocios;
using System;
using ControlesPerzonalizados.Ayudas;

namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        readonly A_Validador Validador = new A_Validador();
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
            bool UsuarioCorrecto = Validador.ValidarUsuario(txtUsuario, lblErrorUsuario, pbErrorUsuario);
            bool ContraseñaCorrecta = Validador.ValidarCampoLleno(txtContraseña, lblErrorContraseña, pbErrorContraseña);

            if (UsuarioCorrecto)
            {
                if (ContraseñaCorrecta)
                {
                    N_InicioSesion InicioSesion = new N_InicioSesion();
                    var ValidarDatos = InicioSesion.IniciarSesion(Usuario, Contraseña);

                    // Si los datos son correctos
                    if (ValidarDatos == true)
                    {
                        this.Hide();

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
                        P_DialogoError.Mostrar("Usuario o contraseña incorrecta");
                        txtUsuario.Clear();
                        txtContraseña.Clear();
                        Validador.EnfocarCursor(txtUsuario);
                    }
                }
                else
                {
                    Validador.EnfocarCursor(txtContraseña);
                }
            }
            else
            {
                Validador.EnfocarCursor(txtUsuario);
            }
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

        private void txtContraseña_TextChange(object sender, System.EventArgs e)
        {
            if (Validador.ValidarCampoLleno(txtContraseña, lblErrorContraseña, pbErrorContraseña))
            {
                pbErrorContraseña.Visible = false;
                lblErrorContraseña.Visible = false;
            }
            if (txtContraseña.Text != "")
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void txtUsuario_TextChange(object sender, EventArgs e)
        {
            if (Validador.ValidarUsuario(txtUsuario, lblErrorUsuario, pbErrorUsuario))
            {
                pbErrorUsuario.Visible = false;
                lblErrorUsuario.Visible = false;
            }
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
