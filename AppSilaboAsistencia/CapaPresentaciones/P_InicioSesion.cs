using System.Windows.Forms;
using System.Drawing;
using CapaEntidades;
using CapaNegocios;
using System;
using Ayudas;
using System.Threading;

namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        private readonly A_Validador Validador;

        public P_InicioSesion()
        {
            // Crear un objeto validador
            Validador = new A_Validador();

            InitializeComponent();

            // Mover el formulario permitiendo pulsar sobre algunos controles
            Control[] Controles = { this, lblTitulo, pnLogo, pbLogo, lblUniversidad };
            Docker.SubscribeControlsToDragEvents(Controles);
        }

        #region ===================== MÉTODOS =====================
        // Metodo para actualizar algun boton
        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        // Metodo para abrir el control de bienvenida
        public void Abrir()
        {
            // Ocultar el formulario de inicio sesion
            this.Hide();

            // Preparar el control de bienvenida para mostrarlo
            this.Size = new Size(1330, 768);
            this.CenterToScreen();
            this.TopMost = true;
            pnBienvenida.Size = this.Size;
            Bienvenida.lblDatos.Text = E_InicioSesion.Datos;
            pnBienvenida.Visible = true;

            // Mostrar el formulario de inicio sesion
            this.Show();
        }

        // Metodo para cerrar el control de bienvenida
        public void Cerrar()
        {
            this.TopMost = false;

            // Desaparecer el formulario animadamente
            TiempoDesaparicion.Start();
        }

        // Metodo para abrir o cerrar el control de bienvenida
        private void EstablecerCarga(bool Flag)
        {
            if (Flag)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    // Abrir el control de bienvenida
                    Abrir();
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    // Cerrar el control de bienvenida
                    Cerrar();
                });
            }
        }

        // Metodo para cargar y mostrar el menu principal
        private void MostrarMenu(string pAcceso)
        {
            if (E_InicioSesion.Acceso != E_Acceso.Administrador)
            {
                Thread.Sleep(4000);
                Bienvenida.pbProgreso.Value = 28;
                Bienvenida.lblCarga.Text = "CARGANDO TABLAS, REPORTES...";
            }

            Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate
            {
                P_Menu Menu = new P_Menu
                {
                    Acceso = pAcceso
                };

                // Mostrar el menu principal
                Menu.Show();
                Bienvenida.pbProgreso.Value = 65;
            });

            Thread.Sleep(1000);

            Bienvenida.lblCarga.Text = "FINALIZANDO CARGA...";

            Thread.Sleep(1000);

            Bienvenida.pbProgreso.Value = 97;
            Bienvenida.lblCarga.Text = "ABRIENDO MENÚ PRINCIPAL...";

            Thread.Sleep(1000);

            Bienvenida.pbProgreso.Value = 100;

            Thread.Sleep(1000);
        }

        // Metodo para cargar el control de bienvenida mediante hilos
        private void CargarBienvenida()
        {
            // Abrir el control de bienvenida
            EstablecerCarga(true);

            // Cargar y mostrar el menu principal
            if ((E_InicioSesion.Acceso == E_Acceso.Administrador) ||
                (E_InicioSesion.Acceso == E_Acceso.JefeDepartamentoAcademico) ||
                (E_InicioSesion.Acceso == E_Acceso.DirectorEscuelaProfesional) ||
                (E_InicioSesion.Acceso == E_Acceso.Docente))
            {
                MostrarMenu(E_InicioSesion.Acceso);
            }

            // Cerrar el control de bienvenida
            EstablecerCarga(false);
        }

        // Metodo para iniciar sesion con un usuario
        public void IniciarSesion()
        {
            // Validar los campos
            bool UsuarioCorrecto = Validador.ValidarUsuario(txtUsuario, lblErrorUsuario, pbErrorUsuario);
            bool ContraseñaCorrecta = Validador.ValidarCampoLleno(txtContraseña, lblErrorContraseña, pbErrorContraseña);

            // Validar el usuario
            if (UsuarioCorrecto)
            {
                // Validar la contrasenha
                if (ContraseñaCorrecta)
                {
                    // Verificar el usuario en la base de datos y obtener su acceso
                    N_InicioSesion InicioSesion = new N_InicioSesion();
                    var ValidarDatos = InicioSesion.IniciarSesion(txtUsuario.Text, txtContraseña.Text);

                    // Verificar si los datos son correctos
                    if (ValidarDatos == true)
                    {
                        // Cargar el menu principal mientras se muestra el control de bienvenida mediante hilos
                        try
                        {
                            Thread Tarea = new Thread(CargarBienvenida);
                            Tarea.Start();
                        }
                        catch (Exception)
                        {
                            A_Dialogo.DialogoError("Error al mostrar el menú principal");
                        }
                    }
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
        #endregion ===================== MÉTODOS =====================

        #region ===================== EVENTOS =====================
        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            ActualizarColor();

            // Iniciar sesion con un usuario
            IniciarSesion();
        }

        private void txtUsuario_TextChange(object sender, EventArgs e)
        {
            // Validar el usuario
            if (Validador.ValidarUsuario(txtUsuario, lblErrorUsuario, pbErrorUsuario))
            {
                pbErrorUsuario.Visible = false;
                lblErrorUsuario.Visible = false;
            }
        }

        private void txtContraseña_TextChange(object sender, System.EventArgs e)
        {
            // Validar la contrasenha
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

        private void btnMostrarOcultarContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            // Mostrar contrasenha
            btnMostrarOcultarContraseña.Image = Properties.Resources.Mostrar;
            txtContraseña.UseSystemPasswordChar = false;
        }

        private void btnMostrarOcultarContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            // Ocultar contrasenha
            btnMostrarOcultarContraseña.Image = Properties.Resources.Ocultar;
            if (txtContraseña.Text != "")
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void btnOlvidarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abrir el formulario para recuperar la contrasenha de un usuario
            P_RecuperacionContraseña RC = new P_RecuperacionContraseña();
            RC.ShowDialog();
        }

        private void TiempoDesaparicion_Tick(object sender, EventArgs e)
        {
            // Desaparecer este formulario animadamente
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                TiempoDesaparicion.Stop();
                this.Hide();
            }
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            // Cerrar la aplicacion
            Application.Exit();
        }
        #endregion ===================== EVENTOS =====================
    }
}
