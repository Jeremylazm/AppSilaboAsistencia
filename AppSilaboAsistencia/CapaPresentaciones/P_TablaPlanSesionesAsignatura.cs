﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CapaNegocios;
using Ayudas;
using CapaEntidades;


namespace CapaPresentaciones
{
    public partial class P_TablaPlanSesionesAsignatura : Form
    {
        readonly private string CodAsignatura;
        private readonly DataTable PlanSesiones;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

        public P_TablaPlanSesionesAsignatura(string CodAsignatura)
        {
            this.CodAsignatura = CodAsignatura;

            InitializeComponent();
            Control[] Controles = { this, lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);

            PlanSesiones = N_Catalogo.MostrarPlanSesionesAsignatura(CodAsignatura.Substring(0, CodDepartamentoA.Length + 3), E_InicioSesion.Usuario);
            MostrarPlasSesiones();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].HeaderText = "Semestre";
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[5].Visible = false;
            dgvDatos.Columns[6].Visible = false;
        }

        private void MostrarPlasSesiones()
        {
            dgvDatos.DataSource = PlanSesiones;
            AccionesTabla();
        }

        public void BuscarPlanSesiones()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarPlanSesionesAsignatura(CodAsignatura.Substring(0, CodDepartamentoA.Length + 3), E_InicioSesion.Usuario, txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                // Descargar el plan de sesiones
                if (PlanSesiones.Rows.Count != 0)
                {
                    saveFileDialog.Title = "Descargar Plan de Sesiones";
                    saveFileDialog.FileName = "Plan de Sesiones " + " - " + CodAsignatura;
                    saveFileDialog.Filter = "Archivo de Excel | *.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.FilterIndex = 1;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, dgvDatos.Rows[e.RowIndex].Cells["PlanSesiones"].Value as byte[]);
                            A_Dialogo.DialogoConfirmacion("Archivo guardado correctamente");
                            //MessageBox.Show("Archivo guardado correctamente");
                            Close();
                        }
                        catch(IOException)
                        {
                            A_Dialogo.DialogoError("Cierre el archivo antes de que sea reemplazado o elija otro nombre");
                            //MessageBox.Show("Cierra el archivo antes de reemplazarlo o elige otro nombre");
                        }
                    }
                }
                else
                {
                    A_Dialogo.DialogoInformacion("No hay plan de sesiones");
                    //MessageBox.Show("No hay plan de sesiones");
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarPlanSesiones();
        }
    }
}
