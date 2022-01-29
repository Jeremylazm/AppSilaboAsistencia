using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using System;
using Ayudas;
using System.Threading;

namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        readonly A_Validador Validador;
        P_Bienvenida Bienvenida;

        public P_InicioSesion()
        {
            Validador = new A_Validador();
            Bienvenida = new P_Bienvenida();
            InitializeComponent();
            Control[] Controles = { this, lblTitulo, pnLogo, pbLogo, lblUniversidad };
            Docker.SubscribeControlsToDragEvents(Controles);
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        private void EstablecerCarga(bool Flag)
        {
            if (Flag)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Bienvenida.Abrir();
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Bienvenida.Cerrar();
                });
            }
        }

        private void MostrarMenu(string pAcceso, int Tiempo)
        {
            try
            {
                Thread Tarea = new Thread(() =>
                {
                    P_Menu Menu = new P_Menu
                    {
                        Acceso = pAcceso
                    };
                    Application.Run(Menu);
                });
                Tarea.Start();
                Thread.Sleep(Tiempo * 1000);
            }
            catch (Exception)
            {
                A_Dialogo.DialogoError("Error al mostrar el menú principal");
            }
        }

        private void CargarBienvenida()
        {
            //EstablecerCarga(true);

            // Si el usuario es Administrador
            if (E_InicioSesion.Acceso == E_Acceso.Administrador)
            {
                MostrarMenu(E_InicioSesion.Acceso, 4);
            }

            // Si el usuarios es Jefe de Departamento Académico
            if (E_InicioSesion.Acceso == E_Acceso.JefeDepartamentoAcademico)
            {
                MostrarMenu(E_InicioSesion.Acceso, 30);
            }

            // Si el usuario es Director de Escuela
            if (E_InicioSesion.Acceso == E_Acceso.DirectorEscuelaProfesional)
            {
                MostrarMenu(E_InicioSesion.Acceso, 30);
            }

            // Si el usuario es Docente
            if (E_InicioSesion.Acceso == E_Acceso.Docente)
            {
                MostrarMenu(E_InicioSesion.Acceso, 30);
            }
                        
            //EstablecerCarga(false);
        }

        public void IniciarSesion()
        {
            bool UsuarioCorrecto = Validador.ValidarUsuario(txtUsuario, lblErrorUsuario, pbErrorUsuario);
            bool ContraseñaCorrecta = Validador.ValidarCampoLleno(txtContraseña, lblErrorContraseña, pbErrorContraseña);

            if (UsuarioCorrecto)
            {
                if (ContraseñaCorrecta)
                {
                    N_InicioSesion InicioSesion = new N_InicioSesion();
                    var ValidarDatos = InicioSesion.IniciarSesion(txtUsuario.Text, txtContraseña.Text);

                    // Si los datos son correctos
                    if (ValidarDatos == true)
                    {
                        this.Hide();

                        try
                        {
                            Thread Tarea = new Thread(CargarBienvenida);
                            Tarea.Start();
                        }
                        catch (Exception)
                        {
                            A_Dialogo.DialogoError("Error al ejecutar la tarea");
                        }
                    }
                    // Si los datos son incorrectos
                    else
                    {
                        A_Dialogo.DialogoError("Usuario o contraseña incorrecta");
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
            IniciarSesion();
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void txtUsuario_TextChange(object sender, EventArgs e)
        {
            if (Validador.ValidarUsuario(txtUsuario, lblErrorUsuario, pbErrorUsuario))
            {
                pbErrorUsuario.Visible = false;
                lblErrorUsuario.Visible = false;
            }
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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                IniciarSesion();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                IniciarSesion();
        }


        private void btnOlvidarContraseña_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            P_RecuperacionContraseña RC = new P_RecuperacionContraseña();
            RC.ShowDialog();
        }

        private void btnMostrarOcultarContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarContraseña.Image = Properties.Resources.Mostrar;
            txtContraseña.UseSystemPasswordChar = false;
        }

        private void btnMostrarOcultarContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarContraseña.Image = Properties.Resources.Ocultar;
            if (txtContraseña.Text != "")
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }
    }
}
