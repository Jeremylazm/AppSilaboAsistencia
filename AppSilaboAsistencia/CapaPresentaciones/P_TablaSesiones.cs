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
using SpreadsheetLight;
using ClosedXML.Excel;

namespace CapaPresentaciones
{
    public partial class P_TablaSesiones : Form
    {
        private DataTable PlanSesion;
        private readonly string CodSemestre;
        public string CodAsignatura;
        public string CodDocente;

        public P_TablaSesiones(string pCodAsignatura, string pCodDocente)
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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
        }

        private void pnPeriodosParciales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
