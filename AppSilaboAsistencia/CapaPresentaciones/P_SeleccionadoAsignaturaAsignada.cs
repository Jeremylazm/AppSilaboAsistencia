﻿using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_SeleccionadoAsignaturaAsignada : Form
    {
        readonly N_Catalogo ObjCatalogo;
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodEscuelaP = "IF";
        private readonly string CodAsignatura;

        private readonly string AccesoReporte = "";

        public P_SeleccionadoAsignaturaAsignada(string pCodAsignatura, string AccesoReporte)
        {
            this.AccesoReporte = AccesoReporte;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            CodAsignatura = pCodAsignatura;
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);

            if (AccesoReporte == "Docente") MostrarAsignaturas();
            else if (AccesoReporte == "Director de Escuela") MostrarEstudiantes();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[3].Visible = false;

            dgvDatos.Columns[0].HeaderText = "Código";
            dgvDatos.Columns[0].MinimumWidth = 95;
            dgvDatos.Columns[0].Width = 95;
            dgvDatos.Columns[1].HeaderText = "Nombre";
            dgvDatos.Columns[2].HeaderText = "Escuela Profesional";
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodEscuelaP, CodDocente);
            AccionesTabla();
        }

        private void MostrarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.MostrarEstudiantesMatriculados(CodSemestre, "IN");
        }

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodSemestre, CodEscuelaP, CodDocente, txtBuscar.Text);
            dgvDatos.ClearSelection();
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (AccesoReporte == "Docente")
            {
                P_ReporteDocente DatosAsingatura = Owner as P_ReporteDocente;
                string codTemp = DatosAsingatura.txtCodigo.Text;

                DatosAsingatura.txtCodigo.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                DatosAsingatura.txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                DatosAsingatura.txtEscuelaP.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();

                if (codTemp != DatosAsingatura.txtCodigo.Text && DatosAsingatura.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
                {
                    DatosAsingatura.CriterioSeleccionAsistenciaEstudiantes();
                }
            }
            else if (AccesoReporte == "Director de Escuela")
            {
                P_ReporteDirector DatosEstudiante = Owner as P_ReporteDirector;
                string codTemp = DatosEstudiante.txtCodEstudiante.Text;

                DatosEstudiante.txtCodEstudiante.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                DatosEstudiante.txtEstudiante.Text = dgvDatos.CurrentRow.Cells[3].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[2].Value.ToString() + " " + dgvDatos.CurrentRow.Cells[1].Value.ToString();

                if (codTemp != DatosEstudiante.txtCodEstudiante.Text && DatosEstudiante.cxtTipoReporte.SelectedItem.Equals("Asistencia Estudiantes"))
                {
                    DatosEstudiante.CriterioSeleccionAsistenciaEstudiantes();
                }
            }

            Close();
        }

        private void P_SeleccionadoAsignaturaAsignada_Load(object sender, EventArgs e)
        {
            dgvDatos.ClearSelection();
        }
    }
}
