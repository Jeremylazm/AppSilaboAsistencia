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
using CapaEntidades;
using CapaNegocios;
using Ayudas;

namespace CapaPresentaciones
{
    public partial class P_TablaSilabosAsignatura : Form
    {
        readonly private string CodAsignatura;
        private readonly DataTable Silabos;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

        public P_TablaSilabosAsignatura(string CodAsignatura)
        {
            this.CodAsignatura = CodAsignatura;

            InitializeComponent();
            Control[] Controles = { this, lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);

            Silabos = N_Catalogo.MostrarSilabosAsignatura(CodAsignatura.Substring(0, CodDepartamentoA.Length + 3));
            MostrarSilabos();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].HeaderText = "Semestre";
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[5].Visible = false;
            dgvDatos.Columns[6].Visible = false;
        }

        private void MostrarSilabos()
        {
            dgvDatos.DataSource = Silabos;
            AccionesTabla();
        }

        public void BuscarSilabos()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarSilabosAsignatura(CodAsignatura.Substring(0, CodDepartamentoA.Length + 3), txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                if (Silabos.Rows.Count != 0)
                {
                    saveFileDialog.Title = "Descargar Sílabo";
                    saveFileDialog.FileName = "Sílabo " + CodAsignatura;
                    saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.FilterIndex = 1;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, dgvDatos.Rows[e.RowIndex].Cells["Silabo"].Value as byte[]);
                            A_Dialogo.DialogoConfirmacion("Archivo guardado correctamente");
                            //MessageBox.Show("Archivo guardado correctamente");
                            Close();
                        }
                        catch (IOException)
                        {
                            A_Dialogo.DialogoError("Cierre el archivo antes de que sea reemplazado o elija otro nombre");
                            //MessageBox.Show("Cierra el archivo antes de reemplazarlo o elige otro nombre");
                        }
                    }
                }
                else
                {
                    A_Dialogo.DialogoInformacion("No hay sílabo");
                    //MessageBox.Show("No hay sílabo");
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarSilabos();
        }
    }
}
