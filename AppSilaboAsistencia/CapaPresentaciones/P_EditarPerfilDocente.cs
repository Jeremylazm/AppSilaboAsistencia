using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Bunifu.UI.WinForms;
using Ayudas;
using System.Linq;

namespace CapaPresentaciones
{
    public partial class P_EditarPerfilDocente : Form
    {

        readonly A_Validador Validador;

        // Instanciar la capa entidad y negocio de docente
        readonly E_Docente ObjEntidad = new E_Docente();
        readonly N_Docente ObjNegocio = new N_Docente();

        // Inicializar atributos constantes (no modificables por el docente)
        public string UsuarioE = "";
        private string APaterno = "";
        private string AMaterno = "";
        private string Nombre = "";
        private string CodDepartamentoA = "";
        private string CodEscuelaP = "";

        public P_EditarPerfilDocente()
        {
            Validador = new A_Validador();

            InitializeComponent();
        }

        private void CargarDatosUsuario()
        {
            // Buscar sus datos del docente con su usuario
            DataTable Datos = N_Docente.BuscarDocente("IF", UsuarioE);

            // Obtener la primera fila con los datos
            object[] Fila = Datos.Rows[0].ItemArray;

            // Verificar si el campo de perfil es nulo
            if (E_InicioSesion.Perfil == null)
            {
                // Asignar una imagen por defecto para docente
                imgPerfil.Image = Properties.Resources.Perfil_Docente as Image;
            }
            else
            {
                // Cargar el perfil del docente de la base de datos
                byte[] Perfil = new byte[0];
                Perfil = E_InicioSesion.Perfil;
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                imgPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
            }

            // Cargar los otros datos del docente
            lblCodigo2.Text = Fila[2].ToString();
            APaterno = Fila[3].ToString();
            AMaterno = Fila[4].ToString();
            Nombre = Fila[5].ToString();
            lblNombres2.Text = APaterno + " " + AMaterno + ", " + Nombre;
            txtEmail.Text = Fila[6].ToString();
            txtDireccion.Text = Fila[7].ToString();
            txtTelefono.Text = Fila[8].ToString();
            lblCategoria2.Text = Fila[9].ToString();
            lblSubcategoria2.Text = Fila[10].ToString();
            lblRegimen2.Text = Fila[11].ToString();
            CodDepartamentoA = Fila[12].ToString();
            CodEscuelaP = Fila[13].ToString();
            lblEscuelaP2.Text = N_EscuelaProfesional.BuscarNombraEscuela(CodEscuelaP);

            //CodEscuelaP = Fila[13].ToString();
            //txtEscuelaP.Text = Fila[14].ToString();
        }

        // Metodo para hacer una imagen circular
        public Image HacerImagenCircular(Image img)
        {
            // Determinar el centro de la imagen
            int x = img.Width / 2;
            int y = img.Height / 2;

            // Determinar el radio de la imagen
            int r = Math.Min(x, y);

            // Generar el espacio donde estara la imagen (cuadrado)
            Bitmap tmp = null;
            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                // Mover la imagen al centro
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);

                // Generar un circulo con los atributos determinados
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);

                // Cortar el espacio en forma circular
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);

                // Dibujar la imagen circular
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }

            // Retornar la imagen circular
            return tmp;
        }

        private void P_EditarPerfilDocente_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRestablecerPerfil_Click(object sender, EventArgs e)
        {
            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea restablecer su perfil?") == DialogResult.Yes)
            {
                // Cargar imagen por defecto en el formulario
                imgPerfil.Image = Properties.Resources.Perfil_Docente as Image;
            }
        }

        private void btnSubirPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir una ventana para seleccionar una imagen
                OpenFileDialog Archivo = new OpenFileDialog
                {
                    Filter = "Archivos de Imagen | *.jpg; *.jpeg; *.png; *.gif; *.tif",
                    Title = "Subir Perfil"
                };

                // Verificar si ya se eligio una imagen
                if (Archivo.ShowDialog() == DialogResult.OK)
                {
                    // Cargar imagen en el formulario
                    imgPerfil.Image = HacerImagenCircular(Image.FromFile(Archivo.FileName));
                }
            }
            catch (Exception)
            {
                // Mostrar mensaje de error
                A_Dialogo.DialogoError("Error al subir perfil");
                //MessageBox.Show("Error al subir perfil");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool EmailCorrecto = Validador.ValidarEmail(txtEmail, lblErrorEmail, pbErrorEmail);
            bool TelefonoCorrecto = Validador.ValidarNumeroLimitado(txtTelefono, lblErrorTelefono, pbErrorTelefono, 9);

            if (EmailCorrecto)
            {
                if (TelefonoCorrecto)
                {
                    // Mostrar mensaje para saber si realmente se desea editar los datos
                    if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea actualizar su perfil?") == DialogResult.Yes)
                    {
                        // Asignar campo por campo, los datos editados en el objeto entidad del docente
                        byte[] Perfil = new byte[0];
                        using (MemoryStream MemoriaPerfil = new MemoryStream())
                        {
                            imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                            Perfil = MemoriaPerfil.ToArray();
                        }
                        E_InicioSesion.Perfil = Perfil;
                        ObjEntidad.Perfil = Perfil;
                        ObjEntidad.CodDocente = lblCodigo2.Text;
                        ObjEntidad.APaterno = APaterno;
                        ObjEntidad.AMaterno = AMaterno;
                        ObjEntidad.Nombre = Nombre;
                        ObjEntidad.Email = txtEmail.Text;
                        ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                        ObjEntidad.Telefono = txtTelefono.Text;
                        ObjEntidad.Categoria = lblCategoria2.Text;
                        ObjEntidad.Subcategoria = lblSubcategoria2.Text;
                        ObjEntidad.Regimen = lblRegimen2.Text;
                        ObjEntidad.CodDepartamentoA = CodDepartamentoA;
                        ObjEntidad.CodEscuelaP = CodEscuelaP;

                        // Editar el registro en la base de datos con sus datos
                        ObjNegocio.ActualizarDocente(ObjEntidad);

                        // Mostrar mensaje de confirmacion dando entender que se edito sus datos del docente
                        A_Dialogo.DialogoConfirmacion("Perfil guardado exitosamente");
                    }
                }
                else
                {
                    Validador.EnfocarCursor(txtTelefono);
                }
            }
            else
            {
                Validador.EnfocarCursor(txtEmail);
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            Form CambioContraseña = ParentForm.Controls.Find("pnPrincipal", false)[0].Controls.Find("pnContenedor", false)[0].Controls.OfType<P_CambioContraseña>().FirstOrDefault();
            CambioContraseña = new P_CambioContraseña(txtEmail.Text)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            ParentForm.Controls.Find("pnPrincipal", false)[0].Controls.Find("pnContenedor", false)[0].Controls.Add(CambioContraseña);

            CambioContraseña.Show();
            CambioContraseña.BringToFront();
        }
      
        private void txtEmail_TextChange(object sender, EventArgs e)
        {
            if (Validador.ValidarEmail(txtEmail, lblErrorEmail, pbErrorEmail) || txtEmail.Text == "")
            {
                pbErrorEmail.Visible = false;
                lblErrorEmail.Visible = false;
            }
        }

        private void txtTelefono_TextChange(object sender, EventArgs e)
        {
            if (Validador.ValidarNumeroLimitado(txtTelefono, lblErrorTelefono, pbErrorTelefono, 9) || txtTelefono.Text == "")
            {
                pbErrorTelefono.Visible = false;
                lblErrorTelefono.Visible = false;
            }
        }
    }
}
