using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_TablaSesiones : Form
    {
        public P_TablaSesiones()
        {
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvSesiones, sbDatos);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        string Direccion = @"D:\Yo\Plantilla Sesion Pruebas.xlsx";
        private void P_TablaSesiones_Load(object sender, EventArgs e)
        {
            SLDocument sl = new SLDocument(Direccion);
            int IRow = 9;
            List<sesionesViewModel> lst = new List<sesionesViewModel>();

            //while (!string.IsNullOrEmpty(sl.GetCellValueAsString(IRow, 3)) && !string.IsNullOrEmpty(sl.GetCellValueAsString(IRow+1, 3)))
            while (string.IsNullOrEmpty(sl.GetCellValueAsString(IRow, 8)))
            {
                
                sesionesViewModel oSesion = new sesionesViewModel();
                oSesion.Sesion = sl.GetCellValueAsString(IRow, 3);
                oSesion.Fecha = sl.GetCellValueAsDateTime(IRow, 5);
                IRow++;
                lst.Add(oSesion);
            }
            dgvSesiones.DataSource = lst;
        }

        private void pnPeriodosParciales_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
