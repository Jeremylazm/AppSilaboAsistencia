using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ControlesPerzonalizados.Ayudas;
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

        private DialogResult MensajeConfirmacionD(string Mensaje)
        {
            return MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Sílabo Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } //Listo

        private void btnAtras_Click(object sender, EventArgs e)
        {
            new A_Paso().Atras(ParentForm, "Paso3", "Paso2", "C_CambioContraseñaCodigo");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Cambiar_Contraseña() && Validar())
            {
                BunifuPictureBox PictureActual = (BunifuPictureBox)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("pbPaso3", false)[0];
                PictureActual.Image = Properties.Resources.Circulo_Checked;
            }
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
                        MensajeError("La confirmación de la contraseña no es igual a la escrita previamente");
                        return false;
                    }
                }
                else
                {
                    MensajeError("La contraseña nueva no puede estar vacío o debe tener por lo menos un número y una mayúscula");
                    return false;
                }
            }
            else
            {
                MensajeError("La contraseña anterior no puede estar vacío");
                return false;
            }
        }

        public bool Cambiar_Contraseña()
        {
            string ans = validarpanelCambiarContraseña(Usuario, txtContraseñaAnterior.Text, txtContraseñaNueva.Text, txtConfirmarContraseña.Text, false);

            if (ans == "Tamaño no Válido") // longitud de nueva contraseña mayor que 5
            {
                MensajeError("Error, la longitud de la nueva contraseña debe ser mayor a 5");
                txtContraseñaNueva.Clear();
                txtConfirmarContraseña.Clear();
                return false;
            }
            else if (ans == "Contrasela Anterior Incorrecta")
            {
                MensajeError("Contraseña anterior incorrecta, intente de nuevo");
                txtContraseñaAnterior.Clear();
                txtContraseñaNueva.Clear();
                txtConfirmarContraseña.Clear();
                return false;
            }
            else if (ans == "No se pudo Cambiar Contraseña")
            {
                MensajeError("Error al cambiar la contraseña");
                return false;
            }
            else if (ans == "Cancelar Cambio")
            {
                return false;
            }
            else
            {
                MessageBox.Show("La contraseña se cambio éxitosamente");
                return true;
            }
        }

        public string validarpanelCambiarContraseña(string usuario, string contraseña, string contraseñaNueva, string confirmarContraseña, bool test)
        {
            if (contraseñaNueva.Length < 6)
                return "Tamaño no Válido";
            else
            {
                if (!usuarioValido(usuario, contraseña))
                    return "Contrasela Anterior Incorrecta";

                DialogResult Opcion = DialogResult.OK; // OK para test unitario

                if (!test)
                    Opcion = MensajeConfirmacionD("¿Realmente desea cambiar la contraseña ? ");

                if (Opcion == DialogResult.OK)
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
        }

        public bool usuarioValido(string usuario, string contraseña)
        {
            N_InicioSesion InicioSesion = new N_InicioSesion();
            return InicioSesion.IniciarSesion(usuario, contraseña);
        }

        private void txtContraseñaAnterior_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtContraseñaNueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtConfirmarContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void txtContraseñaAnterior_TextChange(object sender, EventArgs e)
        {
            ContraseñaAnterior = Validador.ValidarUsuario(txtContraseñaAnterior, lblErrorContraseñaAnterior, pbErrorContraseñaAnterior);
            if (ContraseñaAnterior)
            {
                lblErrorContraseñaAnterior.Visible = false;
                pbErrorContraseñaAnterior.Visible = false;
            }
        }

        private void txtContraseñaNueva_TextChange(object sender, EventArgs e)
        {
            ContraseñaNueva = Validador.ValidarContraseña(txtContraseñaNueva, lblErrorContraseñaNueva, pbErrorContraseñaNueva);
            if (ContraseñaNueva)
            {
                lblErrorContraseñaNueva.Visible = false;
                pbErrorContraseñaNueva.Visible = false;
            }
        }

        private void txtConfirmarContraseña_TextChange(object sender, EventArgs e)
        {
            ConfirmarContraseña = Validador.ValidarComparar(txtConfirmarContraseña, lblErrorConfirmarContraseña, txtContraseñaNueva.Text, pbErrorConfirmarContraseña, "La contraseña ingresada");
            if (ConfirmarContraseña)
            {
                lblErrorConfirmarContraseña.Visible = false;
                pbErrorConfirmarContraseña.Visible = false;
            }
        }

        private void C_CambioContraseñaNueva_Enter(object sender, EventArgs e)
        {
            BunifuLabel UsuarioCN = (BunifuLabel)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("lblUsuario", false)[0];
            Usuario = UsuarioCN.Text;
            lblPrueba.Text = Usuario;
        }
    }
}
