using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ControlesPerzonalizados.Ayudas;
using CapaNegocios;

namespace ControlesPerzonalizados
{
    public partial class C_CambioContraseñaNueva : UserControl
    {
        public string Usuario;
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
            bool Validar = true;
            if (Cambiar_Contraseña() == "1" && Validar)
            {
                BunifuPictureBox PictureActual = (BunifuPictureBox)ParentForm.Controls.Find("pnContenedor", false)[0].Controls.Find("pbPaso3", false)[0];
                PictureActual.Image = Properties.Resources.Circulo_Checked;
            }
        }

        public string Cambiar_Contraseña()
        {
            string ans = validarpanelCambiarContraseña(Usuario, txtContraseñaAnterior.Text, txtContraseñaNueva.Text, txtConfirmarContraseña.Text, false);

            if (ans == "000" || ans == "001" || ans == "010") // campos vacios
            {
                MensajeError("Campos vacíos, intente de nuevo");
                if (ans == "00") txtContraseñaAnterior.Focus(); // contraseña vacia
                else if (ans == "01") txtContraseñaNueva.Focus(); //Contraseña nueva vacia
                else if (ans == "10") txtConfirmarContraseña.Focus(); // Repeticion contraseña nueva vacia
            }

            else if (ans == "011") // longitud de nueva contraseña no está en el intervalo [6, 8]
            {
                MensajeError("Error, la longitud de la nueva contraseña debe estar contenida entre 6 y 8");
                txtContraseñaNueva.Clear();
                txtConfirmarContraseña.Clear();
                txtContraseñaNueva.Focus();
            }
            else if (ans == "100") // contraseña nueva y repeticion son diferentes
            {
                MensajeError("Nuevas contraseñas no coinciden, intente de nuevo");
                txtConfirmarContraseña.Clear();
                txtContraseñaNueva.Clear();
                txtContraseñaNueva.Focus();
            }
            else if (ans == "-1")
            {
                MensajeError("Contraseña anterior incorrecta, intente de nuevo");
                txtContraseñaAnterior.Clear();
                txtContraseñaNueva.Clear();
                txtConfirmarContraseña.Clear();
                txtContraseñaAnterior.Focus();
            }
            else if (ans == "-2")
                MensajeError("Error al cambiar la contraseña");

            else if (ans == "1")
                MessageBox.Show("La contraseña se cambio éxitosamente");

            return ans;
        }

        public string validarpanelCambiarContraseña(string usuario, string contraseña, string contraseñaNueva, string confirmarContraseña, bool test)
        {
            if (contraseña == "")
                return "000"; // contraseña vacia
            else if (contraseñaNueva == "")
                return "001"; // nueva contraseña vacia
            else if (confirmarContraseña == "")
                return "010"; // longitud de confirmar contraeña vacia
            else if (contraseñaNueva.Length < 6 || contraseñaNueva.Length > 8)
                return "011"; // nueva contraseña no esta en intervalo [6, 8]
            else if (contraseñaNueva != confirmarContraseña)
                return "100"; // contraseña nueva y repeticion son diferentes
            else
            {
                if (!usuarioValido(usuario, contraseña))
                    return "-1"; // contraseña incorrecta

                DialogResult Opcion = DialogResult.OK; // Ok para test unitario

                if (!test)
                    Opcion = MensajeConfirmacionD("¿Realmente desea cambiar la contraseña ? ");

                if (Opcion == DialogResult.OK)
                {
                    N_InicioSesion InicioSesion = new N_InicioSesion();
                    bool CambioContraseñaValido = InicioSesion.CambiarContraseña(usuario, contraseñaNueva);
                    if (CambioContraseñaValido)
                        return "1"; // contraseña cambiada
                    else
                        return "-2"; // contraseña no se pudo cambiar
                }
                return "2"; // Cancelar
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
            bool ContraseñaAnterior = Validador.ValidarUsuario(txtContraseñaAnterior, lblErrorContraseñaAnterior, pbErrorContraseñaAnterior);
            if (ContraseñaAnterior)
            {
                lblErrorContraseñaAnterior.Visible = false;
                pbErrorContraseñaAnterior.Visible = false;
            }
        }

        private void txtContraseñaNueva_TextChange(object sender, EventArgs e)
        {
            bool ContraseñaNueva = Validador.ValidarContraseña(txtContraseñaNueva, lblErrorContraseñaNueva, pbErrorContraseñaNueva);
            if (ContraseñaNueva)
            {
                lblErrorContraseñaNueva.Visible = false;
                pbErrorContraseñaNueva.Visible = false;
            }
        }

        private void txtConfirmarContraseña_TextChange(object sender, EventArgs e)
        {
            bool ConfirmarContraseña = Validador.ValidarComparar(txtConfirmarContraseña, lblErrorConfirmarContraseña, txtContraseñaNueva.Text, pbErrorConfirmarContraseña, "La contraseña ingresada");
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
