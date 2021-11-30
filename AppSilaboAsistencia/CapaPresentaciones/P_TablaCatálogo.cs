using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_TablaCatálogo : Form
    {
        readonly E_Catalogo ObjEntidad;
        readonly N_Catalogo ObjNegocio;

        public P_TablaCatálogo()
        {
            ObjEntidad = new E_Catalogo();
            ObjNegocio = new N_Catalogo();
            InitializeComponent();
            MostrarRegistros();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
        }

        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 10;
            dgvDatos.Columns[1].DisplayIndex = 10;
            dgvDatos.Columns[5].Visible = false;
            dgvDatos.Columns[6].Visible = false;
            dgvDatos.Columns[10].Visible = false;
            dgvDatos.Columns[3].Visible = false;
            dgvDatos.Columns[7].Visible = false;
            dgvDatos.Columns[2].HeaderText = "Código";
            dgvDatos.Columns[3].HeaderText = "Cod Asignatura";
            dgvDatos.Columns[4].HeaderText = "Asignatura";
            dgvDatos.Columns[5].HeaderText = "Cod Escuela";
            dgvDatos.Columns[6].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[7].HeaderText = "Grupo";
            dgvDatos.Columns[8].HeaderText = "Cod Docente";
            dgvDatos.Columns[9].HeaderText = "Docente";
            dgvDatos.Columns[10].HeaderText = "Semestre";
        }//Listo

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }//Listo

        public void BuscarRegistros()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(txtBuscar.Text, "IN");
        }//Listo

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Gestión de Sílabo y Control de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//Listo

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }//Listo

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }//Listo

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            P_Catálogo_Agregar C = new P_Catálogo_Agregar();
            C.Show();
        }//Listo

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_Catalogo.MostrarCatalogo("IF");
            AccionesTabla();
        }//Listo

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistros();
        }//Listo

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                string CodSemestre, CodAsignatura, CodEscuelaP, Grupo;
                P_Catálogo_Actualizar ActualizarC = new P_Catálogo_Actualizar();
                ActualizarC.FormClosed += new FormClosedEventHandler(ActualizarDatos);

                Program.Evento = 1;

                CodSemestre = dgvDatos.Rows[e.RowIndex].Cells[10].Value.ToString();
                CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                CodEscuelaP = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                Grupo = dgvDatos.Rows[e.RowIndex].Cells[7].Value.ToString();

                ActualizarC.Seleccionar_Asignatura_Cod_Nom.DisplayMember = "CodAsignatura";
                ActualizarC.Seleccionar_Asignatura_Cod_Nom.SelectedValue = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                ActualizarC.Seleccionar_Asignatura_Cod_Nom.DisplayMember = "NombreAsignatura";
                ActualizarC.Show();
                ActualizarC.Buscar(CodSemestre, CodAsignatura, CodEscuelaP, Grupo);
            }//Actualizar Falta

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                string CodSemestre, CodAsignatura, CodEscuelaP, Grupo;
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    CodSemestre = dgvDatos.Rows[e.RowIndex].Cells[10].Value.ToString();
                    CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    CodEscuelaP = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    Grupo = dgvDatos.Rows[e.RowIndex].Cells[7].Value.ToString();
                    N_HorarioAsignatura.EliminarHorarioAsignatura(CodSemestre, CodAsignatura, CodEscuelaP, Grupo);
                    N_Catalogo.EliminarAsignaturaCatalogo(CodSemestre, CodAsignatura, CodEscuelaP, Grupo);
                    MensajeConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }//Eliminar Listo
        }
    }
}
