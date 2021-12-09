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
    public partial class P_TablaSilabosAsignatura : Form
    {
        readonly private string CodAsignatura;

        private DataTable Asignaturas;

        public P_TablaSilabosAsignatura(string CodAsignatura)
        {
            this.CodAsignatura = CodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            Asignaturas = N_Catalogo.BuscarSilabosAsignatura("2021-II", CodAsignatura.Substring(0, 5)); //////////
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
                if (Asignaturas.Rows.Count != 0)
                {
                    saveFileDialog.InitialDirectory = @"C:\";
                    saveFileDialog.FileName = "Sílabo " + CodAsignatura.Substring(0, 5);
                    saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.FilterIndex = 1;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, dgvDatos.Rows[e.RowIndex].Cells["Silabo"].Value as byte[]);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("No hay sílabo");
                }
            }
        }
    }
}
