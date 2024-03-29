﻿using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Ayudas;
using CapaNegocios;

namespace ControlesPerzonalizados
{
    public partial class C_CambioContraseñaNueva : UserControl
    {
        string Usuario;
        bool ContraseñaAnterior = false;
        bool ContraseñaNueva = false;
        bool ConfirmarContraseña = false;
        readonly A_Validador Validador;

        public C_CambioContraseñaNueva()
        {
            Validador = new A_Validador();
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Finalizar_Pasos();
        }

        public bool Validar()
        {
            if (ContraseñaAnterior)
            {
                if (ContraseñaNueva) 
                {
                    if (ConfirmarContraseña)
                        return true;
                    else
                    {
                        txtConfirmarContraseña.Clear();
                        Validador.EnfocarCursor(txtConfirmarContraseña);
                        return false;
                    }
                }
                else
                {
                    Validador.EnfocarCursor(txtContraseñaNueva);
                    return false;
                }
            }
            else
            {
                Validador.EnfocarCursor(txtContraseñaAnterior);
                return false;
            }
        }

        public bool Cambiar_Contraseña()
        {
            string ans = validarpanelCambiarContraseña(Usuario, txtContraseñaAnterior.Text, txtContraseñaNueva.Text, false);

            if (ans == "Contraseña Anterior Incorrecta")
            {
                A_Dialogo.DialogoError("La contraseña anterior es incorrecta, intente de nuevo");
                txtContraseñaAnterior.Clear();
                txtContraseñaNueva.Clear();
                txtConfirmarContraseña.Clear();
                return false;
            }
            else if (ans == "No se pudo Cambiar Contraseña")
            {
                A_Dialogo.DialogoError("Error al cambiar la contraseña");
                return false;
            }
            else if (ans == "Cancelar Cambio")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string validarpanelCambiarContraseña(string usuario, string contraseña, string contraseñaNueva, bool test)
        {
            if (!usuarioValido(usuario, contraseña))
                return "Contraseña Anterior Incorrecta";

            DialogResult Opcion = DialogResult.Yes; // OK para test unitario

            if (!test)
                Opcion = A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea cambiar la contraseña? ");

            if (Opcion == DialogResult.Yes)
            {
                N_InicioSesion InicioSesion = new N_InicioSesion();
                bool CambioContraseñaValido = InicioSesion.CambiarContraseña(usuario, contraseñaNueva);
                if (CambioContraseñaValido)
                    return "Cambio Exitoso";
                else
                    return "No se pudo Cambiar Contraseña";
            }
            return "Cancelar Cambio";
        }

        public bool usuarioValido(string usuario, string contraseña)
        {
            N_InicioSesion InicioSesion = new N_InicioSesion();
            return InicioSesion.IniciarSesion(usuario, contraseña);
        }

        private void C_CambioContraseñaNueva_Enter(object sender, EventArgs e)
        {
            BunifuLabel UsuarioCN = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblUsuario", false)[0];
            Usuario = UsuarioCN.Text;
        }

        private void txtContraseñaAnterior_TextChanged(object sender, EventArgs e)
        {
            ContraseñaAnterior = Validador.ValidarCampoLleno(txtContraseñaAnterior, lblErrorContraseñaAnterior, pbErrorContraseñaAnterior);
            if (ContraseñaAnterior)
            {
                lblErrorContraseñaAnterior.Visible = false;
                pbErrorContraseñaAnterior.Visible = false;
            }
            if (txtContraseñaAnterior.Text != "")
            {
                txtContraseñaAnterior.UseSystemPasswordChar = true;
            }
            else
            {
                txtContraseñaAnterior.UseSystemPasswordChar = false;
            }
        }

        private void txtContraseñaNueva_TextChanged(object sender, EventArgs e)
        {
            ContraseñaNueva = Validador.ValidarContraseña(txtContraseñaNueva, lblErrorContraseñaNueva, pbErrorContraseñaNueva);
            if (ContraseñaNueva)
            {
                lblErrorContraseñaNueva.Visible = false;
                pbErrorContraseñaNueva.Visible = false;
            }
            if (txtContraseñaNueva.Text != "")
            {
                txtContraseñaNueva.UseSystemPasswordChar = true;
            }
            else
            {
                txtContraseñaNueva.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {
            ConfirmarContraseña = Validador.ValidarComparar(txtConfirmarContraseña, lblErrorConfirmarContraseña, txtContraseñaNueva.Text, pbErrorConfirmarContraseña, "La contraseña ingresada");
            if (ConfirmarContraseña)
            {
                lblErrorConfirmarContraseña.Visible = false;
                pbErrorConfirmarContraseña.Visible = false;
            }
            if (txtConfirmarContraseña.Text != "")
            {
                txtConfirmarContraseña.UseSystemPasswordChar = true;
            }
            else
            {
                txtConfirmarContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnAceptar_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtContraseñaAnterior_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Finalizar_Pasos();
        }

        private void txtContraseñaNueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Finalizar_Pasos();
        }

        private void txtConfirmarContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Finalizar_Pasos();
        }

        public void Finalizar_Pasos()
        {
            if (Validar())
            {
                if (Cambiar_Contraseña())
                {
                    PictureBox PictureActual = (PictureBox)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("pbPaso3", false)[0];
                    PictureActual.Image = Properties.Resources.Circulo_Checked;
                    A_Dialogo.DialogoConfirmacion("La contraseña se cambio exitosamente");
                    //MessageBox.Show("La contraseña se cambio exitosamente");
                    ParentForm.Close();
                }
            }
        }

        private void btnMostrarOcultarAnteriorContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarAnteriorContraseña.Image = Properties.Resources.Mostrar;
            txtContraseñaAnterior.UseSystemPasswordChar = false;
        }

        private void btnMostrarOcultarAnteriorContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarAnteriorContraseña.Image = Properties.Resources.Ocultar;
            if (txtContraseñaAnterior.Text != "")
            {
                txtContraseñaAnterior.UseSystemPasswordChar = true;
            }
        }

        private void btnMostrarOcultarNuevaContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarNuevaContraseña.Image = Properties.Resources.Mostrar;
            txtContraseñaNueva.UseSystemPasswordChar = false;
        }

        private void btnMostrarOcultarNuevaContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarNuevaContraseña.Image = Properties.Resources.Ocultar;
            if (txtContraseñaNueva.Text != "")
            {
                txtContraseñaNueva.UseSystemPasswordChar = true;
            }
        }

        private void btnMostrarOcultarConfirmarContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarConfirmarContraseña.Image = Properties.Resources.Mostrar;
            txtConfirmarContraseña.UseSystemPasswordChar = false;
        }

        private void btnMostrarOcultarConfirmarContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            btnMostrarOcultarConfirmarContraseña.Image = Properties.Resources.Ocultar;
            if (txtConfirmarContraseña.Text != "")
            {
                txtConfirmarContraseña.UseSystemPasswordChar = true;
            }
        }
    }
}
