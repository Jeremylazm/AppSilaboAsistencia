﻿using System;
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
    public partial class P_SubirArchivo : Form
    {
        readonly N_Catalogo ObjNegocio;

        public string CodAsignatura;
        public string CodDocente;
        public string NombreAsignatura;
        public string EscuelaProfesional;
        public string Grupo;

        private static string realNametemp;

        private string Tipo;

        public P_SubirArchivo(string Tipo)
        {
            ObjNegocio = new N_Catalogo();

            InitializeComponent();

            this.Tipo = Tipo;

            if (Tipo == "Silabo")
            {
                lblTitulo.Text += " Sílabo";
            }
            else if (Tipo == "Plan de Sesiones")
            {
                lblTitulo.Text += " Plan de Sesiones";
            }

        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Gestión de Sílabo y Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Archivos de Excel | *.xlsx";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog.FileName;
            }

            realNametemp = openFileDialog.SafeFileName;
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            if (txtRuta.Text.Trim().Equals(""))
            {
                MessageBox.Show("Selecciona un archivo");
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
                    ObjNegocio.ActualizarSilaboAsignatura("2021-II", CodAsignatura, CodDocente, archivo);
                    MensajeConfirmacion("Archivo subido exitosamente");
                }
                else if (Tipo == "Plan de Sesiones")
                {
                    ObjNegocio.ActualizarPlanSesionesAsignatura("2021-II", CodAsignatura, CodDocente, archivo);
                    MensajeConfirmacion("Archivo subido exitosamente");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Guarda y cierra el archivo antes de subirlo");
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