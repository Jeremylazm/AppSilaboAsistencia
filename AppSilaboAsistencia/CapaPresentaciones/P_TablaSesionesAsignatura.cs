using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_TablaSesionesAsignatura : Form
    {
        readonly private string CodAsignatura;

        private readonly DataTable Asignaturas;

        public P_TablaSesionesAsignatura(string CodAsignatura)
        {
            this.CodAsignatura = CodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            Asignaturas = N_Catalogo.BuscarPlanSesionesAsignatura(CodAsignatura.Substring(0, 5), "65475");
            MostrarAsignaturas();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].HeaderText = "Semestre";
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[5].Visible = false;
            dgvDatos.Columns[6].Visible = false;
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = Asignaturas;
            AccionesTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                // Descargar el plan de sesiones
                if (Asignaturas.Rows.Count != 0)
                {
                    saveFileDialog.InitialDirectory = @"C:\";
                    saveFileDialog.FileName = "Plan de Sesiones " + " - " + CodAsignatura.Substring(0, 5);
                    saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.FilterIndex = 1;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, dgvDatos.Rows[e.RowIndex].Cells["PlanSesiones"].Value as byte[]);
                            P_DialogoInformacion.Mostrar("Archivo guardado correctamente");
                            //MessageBox.Show("Archivo guardado correctamente");
                            Close();
                        }
                        catch(IOException)
                        {
                            P_DialogoRespuesta1.Mostrar("Cierre el archivo antes de que sea reemplazado o elija otro nombre");
                            //MessageBox.Show("Cierra el archivo antes de reemplazarlo o elige otro nombre");
                        }
                    }
                }
                else
                {
                    P_DialogoRespuesta1.Mostrar("No hay plan de sesiones");
                    //MessageBox.Show("No hay plan de sesiones");
                }
            }
        }
    }
}
