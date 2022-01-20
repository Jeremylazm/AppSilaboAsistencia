using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using SpreadsheetLight;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_TablaSesionesPendientes : Form
    {
        private DataTable PlanSesion;
        private readonly string CodSemestre;
        public string CodAsignatura;
        public string CodDocente;

        public P_TablaSesionesPendientes(string pCodAsignatura, string pCodDocente)
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            CodAsignatura = pCodAsignatura;
            CodDocente = pCodDocente;
            InitializeComponent();
            Control[] Controles = { this, lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            lblTitulo.Text += CodAsignatura;
            PlanSesion = N_Catalogo.RecuperarPlanDeSesionAsignatura(CodSemestre, CodAsignatura, CodDocente);
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvSesiones, sbDatos);
        }

        private void AjustarTabla()
        {
            // Verificar el numero de filas de los resultados
            int AnteriorAlturaResultados = dgvSesiones.Height;
            if (dgvSesiones.Rows.Count <= 15)
            {
                sbDatos.Visible = false;
                this.Height = dgvSesiones.Rows.Count * 26 + 102;

            }
            else
            {
                sbDatos.Visible = true;
                this.Height = 492;
            }
        }
        
        private void P_TablaSesiones_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "/temp/";
            string fullFilePath = folder + "temp.xlsx";


            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }

            byte[] archivo = PlanSesion.Rows[0]["PlanSesiones"] as byte[];

            File.WriteAllBytes(fullFilePath, archivo);
            //string Direccion = @"D:\Yo\Plantilla Sesion Pruebas.xlsx";
            SLDocument sl = new SLDocument(fullFilePath);
            int IRow = 9;
            List<sesionesViewModel> lst = new List<sesionesViewModel>();
            DateTime A = DateTime.Now;
            //

            while (sl.GetCellValueAsDateTime(IRow, 5) < A)
            {
                if (sl.GetCellValueAsString(IRow, 8) != "Hecho" && sl.GetCellValueAsString(IRow,3)!="")
                {
                    sesionesViewModel oSesion = new sesionesViewModel();
                    oSesion.Sesion = sl.GetCellValueAsString(IRow, 3);
                    oSesion.Fecha = sl.GetCellValueAsDateTime(IRow, 5);
                    lst.Add(oSesion);
                }
                IRow++;
                
            }
            dgvSesiones.DataSource = lst;

            dgvSesiones.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvSesiones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSesiones.Columns[1].MinimumWidth = 130;
            dgvSesiones.Columns[1].Width = 130;

            AjustarTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
