﻿using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_TablaAsistenciaEstudiantes : Form
    {
        public string CodAsignatura;

        public P_TablaAsistenciaEstudiantes(string pCodAsignatura)
        {
            CodAsignatura = pCodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
            txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            MostrarEstudiantes();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].DisplayIndex = 6;
            dgvDatos.Columns[2].HeaderText = "Id.";
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[4].HeaderText = "Apellido Paterno";
            dgvDatos.Columns[5].HeaderText = "Apellido Materno";
            dgvDatos.Columns[6].HeaderText = "Nombre";
        }

        private void MostrarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.BuscarEstudiantesAsignatura("2021-II", CodAsignatura.Substring(6), CodAsignatura);
            AccionesTabla();
        }

        public void BuscarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.BuscarEstudiantesMatriculadosAsignatura("2021-II", CodAsignatura.Substring(6), CodAsignatura, txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEstudiantes();
        }

        private void btnSesiones_Click(object sender, EventArgs e)
        {

        }
    }
}