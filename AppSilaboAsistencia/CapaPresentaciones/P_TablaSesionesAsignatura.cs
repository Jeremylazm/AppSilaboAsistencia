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

        public P_TablaSesionesAsignatura(string CodAsignatura)
        {
            this.CodAsignatura = CodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
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
            dgvDatos.DataSource = N_Catalogo.BuscarSilabosAsignatura("2021-II", CodAsignatura.Substring(0, 5), CodAsignatura.Substring(6));
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
                DataTable silaboAsignatura = N_Catalogo.MostrarSilaboAsignatura(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString(), dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString());

                if (silaboAsignatura.Rows.Count != 0)
                {
                    saveFileDialog.InitialDirectory = @"C:\";
                    saveFileDialog.FileName = "Sílabo " + CodAsignatura.Substring(0, 5);
                    saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.FilterIndex = 1;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, silaboAsignatura.Rows[0]["Silabo"] as byte[]);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("No hay plan de sesiones");
                }
            }
        }
    }
}
