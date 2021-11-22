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
using CapaEntidades;
using System.IO;
using System.Diagnostics;

namespace CapaPresentaciones
{
    public partial class P_SubirSilabo : Form
    {
        readonly N_Catalogo ObjNegocio;
        readonly E_Catalogo ObjEntidad;

        public string CodAsignatura;
        public string CodDocente;
        public string NombreAsignatura;
        public string EscuelaProfesional;
        public string Grupo;

        private static string realNametemp;

        public P_SubirSilabo()
        {
            ObjEntidad = new E_Catalogo();
            ObjNegocio = new N_Catalogo();
            InitializeComponent();
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Gestión de Sílabo y Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Archivos de Excel | *.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog.FileName;
            }

            realNametemp = openFileDialog.SafeFileName;
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (txtRuta.Text.Trim().Equals(""))
            {
                MessageBox.Show("Selecciona un archivo");
                return;
            }

            byte[] archivo = null;
            Stream myStream = openFileDialog.OpenFile();
            using (MemoryStream ms = new MemoryStream())
            {
                myStream.CopyTo(ms);
                archivo = ms.ToArray();
            }

            ObjEntidad.CodSemestre = "2021-II";
            ObjEntidad.CodAsignatura = CodAsignatura.Substring(0, 5);
            ObjEntidad.CodEscuelaP = CodAsignatura.Substring(6, 2);
            ObjEntidad.Grupo = Grupo;
            ObjEntidad.CodDocente = CodDocente;
            ObjEntidad.Silabo = archivo;
            ObjEntidad.PlanSesiones = new byte[1];

            ObjNegocio.ActualizarAsignaturaCatalogo(ObjEntidad);
            MensajeConfirmacion("Archivo subido exitosamente");

            
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
