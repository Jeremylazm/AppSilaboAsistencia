using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using CapaNegocios;
using Ayudas;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaPresentaciones
{
    public partial class P_SubirArchivo : Form
    {
        readonly N_Catalogo ObjNegocio;

        private readonly string CodSemestre;
        public string CodAsignatura;
        public string CodDocente;
        public string NombreAsignatura;
        public string EscuelaProfesional;
        public string Grupo;
        //readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        private readonly string Tipo;

        public P_SubirArchivo(string Tipo)
        {
            ObjNegocio = new N_Catalogo();
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();

            InitializeComponent();
            Control[] Controles = { this, lblTitulo };
            Docker.SubscribeControlsToDragEvents(Controles);

            this.Tipo = Tipo;

            if (Tipo == "Silabo")
            {
                lblTitulo.Text += " Sílabo";
            }
            else if (Tipo == "Plan de Sesiones")
            {
                lblTitulo.Text += " Plan de Sesiones";
            }
            //Plantillas 
            else if (Tipo == "Plantilla Silabo")
            {
                lblTitulo.Text += " Plantilla Silabo";
            }
            else if (Tipo == "Plantilla Sesiones 2 y 3 créditos")
            {
                lblTitulo.Text += " Plantilla Sesiones 2 y 3 créditos";
            }
            else if (Tipo == "Plantilla Sesiones 4 créditos")
            {
                lblTitulo.Text += " Plantilla Sesiones 4 créditos";
            }
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            openFileDialog.Title = "Subir archivo";
            openFileDialog.Filter = "Archivos de Excel | *.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog.FileName;
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            if (txtRuta.Text.Trim().Equals(""))
            {
                A_Dialogo.DialogoError("Seleccione un archivo");
                //MessageBox.Show("Selecciona un archivo");
                return;
            }

            byte[] archivo = null;

            try
            {
                Stream myStream = openFileDialog.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    archivo = ms.ToArray();
                }

                if (Tipo == "Silabo")
                {
                    ObjNegocio.ActualizarSilaboAsignatura(CodSemestre, CodAsignatura, CodDocente, archivo);
                    //MensajeConfirmacion("Archivo subido exitosamente");
                }
                else if (Tipo == "Plan de Sesiones")
                {
                    ObjNegocio.ActualizarPlanSesionesAsignatura(CodSemestre, CodAsignatura, CodDocente, archivo);
                    //MensajeConfirmacion("Archivo subido exitosamente");
                }
                else if (Tipo == "Plantilla Silabo")
                {
                    ObjNegocio.ActualizarPlantillaSilabo(archivo);
                    //MensajeConfirmacion("Archivo subido exitosamente");
                }
                else if (Tipo == "Plantilla Sesiones 2 y 3 créditos")
                {
                    ObjNegocio.ActualizarPlantillaSesiones2y3(archivo);
                    //MensajeConfirmacion("Archivo subido exitosamente");
                }
                else if (Tipo == "Plantilla Sesiones 4 créditos")
                {
                    ObjNegocio.ActualizarPlantillaSesiones4(archivo);
                    //MensajeConfirmacion("Archivo subido exitosamente");
                }
                A_Dialogo.DialogoConfirmacion("Archivo subido exitosamente");
            }
            catch (IOException)
            {
                A_Dialogo.DialogoError("Guarde y cierre el archivo antes de subirlo");
                //MessageBox.Show("Guarda y cierra el archivo antes de subirlo", "Sistema de Gestión de Sílabos y Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            // Abrir el archivo subido
            /*string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "/temp/";
            string fullFilePath = folder + realNametemp;

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }

            MessageBox.Show(archivo.Length.ToString());
            File.WriteAllBytes(fullFilePath, archivo);

            Process.Start(fullFilePath);
            */
            Program.Evento = 0;
            Close();
        }
    }
}
