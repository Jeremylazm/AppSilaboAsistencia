using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_EditarPerfilDocente : Form
    {
        public P_EditarPerfilDocente()
        {
            InitializeComponent();
        }

        private void CargarDatosUsuario()
        {
            /*
            // Buscar sus datos del docente con su usuario
            DataTable Datos = N_Docente.BuscarRegistro(Usuario);

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
            txtCodigo.Text = Fila[2].ToString();
            APaterno = Fila[3].ToString();
            AMaterno = Fila[4].ToString();
            Nombre = Fila[5].ToString();
            txtDocente.Text = Fila[6].ToString();
            txtEmail.Text = Fila[7].ToString();
            txtDireccion.Text = Fila[8].ToString();
            txtTelefono.Text = Fila[9].ToString();
            txtCategoria.Text = Fila[10].ToString();
            txtSubcategoria.Text = Fila[11].ToString();
            txtRegimen.Text = Fila[12].ToString();
            CodEscuelaP = Fila[13].ToString();
            txtEscuelaP.Text = Fila[14].ToString();
            txtHorario.Text = Fila[15].ToString();*/
        }

        private void P_EditarPerfilDocente_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }
    }
}
