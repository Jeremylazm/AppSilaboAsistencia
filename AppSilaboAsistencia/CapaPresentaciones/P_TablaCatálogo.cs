using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using Ayudas;
using System.Drawing;

namespace CapaPresentaciones
{
    public partial class P_TablaCatálogo : Form
    {
        readonly E_Catalogo ObjEntidad;
        readonly N_Catalogo ObjNegocio;
        readonly E_HorarioAsignatura ObjEntidadHA;
        readonly N_HorarioAsignatura ObjNegocioHA;

        public P_TablaCatálogo()
        {
            ObjEntidad = new E_Catalogo();
            ObjNegocio = new N_Catalogo();
            ObjEntidadHA = new E_HorarioAsignatura();
            ObjNegocioHA = new N_HorarioAsignatura();
            InitializeComponent();
            MostrarRegistros();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
        }

        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 9;
            dgvDatos.Columns[1].DisplayIndex = 9;

            dgvDatos.Columns[2].HeaderText = "Código";
            dgvDatos.Columns[3].HeaderText = "Asignatura";
            dgvDatos.Columns[4].HeaderText = "Escuela";
            dgvDatos.Columns[5].HeaderText = "Grupo";
            dgvDatos.Columns[6].HeaderText = "Cod Docente";
            dgvDatos.Columns[7].HeaderText = "Docente";
            dgvDatos.Columns[8].HeaderText = "Cod Asignatura";
            dgvDatos.Columns[9].HeaderText = "Cod Escuela";
            dgvDatos.Columns[8].Visible = false;
            dgvDatos.Columns[9].Visible = false;
        }//Listo

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }//Listo

        public void BuscarRegistros()
        {
            string Semestre = "";
            var AñoActual = DateTime.Now.ToString("yyyy");
            var MesActual = DateTime.Now.ToString("MM");
            if (Convert.ToInt32(MesActual) >= 1 && Convert.ToInt32(MesActual) <= 6)
                Semestre = AñoActual + "-I";
            if (Convert.ToInt32(MesActual) >= 7 && Convert.ToInt32(MesActual) <= 12)
                Semestre = AñoActual + "-II";
            dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(Semestre, txtBuscar.Text, "IF");
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
            string Semestre = "";
            var AñoActual = DateTime.Now.ToString("yyyy");
            var MesActual = DateTime.Now.ToString("MM");
            if (Convert.ToInt32(MesActual) >= 1 && Convert.ToInt32(MesActual) <= 6)
                Semestre = AñoActual + "-I";
            if (Convert.ToInt32(MesActual) >= 7 && Convert.ToInt32(MesActual) <= 12)
                Semestre = AñoActual + "-II";
            dgvDatos.DataSource = N_Catalogo.MostrarCatalogo(Semestre, "IF");
            AccionesTabla();
        }//Listo

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistros();
        }//Listo

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Semestre = "";
            var AñoActual = DateTime.Now.ToString("yyyy");
            var MesActual = DateTime.Now.ToString("MM");
            if (Convert.ToInt32(MesActual) >= 1 && Convert.ToInt32(MesActual) <= 6)
                Semestre = AñoActual + "-I";
            if (Convert.ToInt32(MesActual) >= 7 && Convert.ToInt32(MesActual) <= 12)
                Semestre = AñoActual + "-II";

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                string CodSemestre, CodAsignatura, CodEscuelaP, Grupo;
                P_Catálogo_Actualizar ActualizarC = new P_Catálogo_Actualizar();
                ActualizarC.FormClosed += new FormClosedEventHandler(ActualizarDatos);

                Program.Evento = 1;

                CodSemestre = Semestre;
                CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[8].Value.ToString();
                CodEscuelaP = dgvDatos.Rows[e.RowIndex].Cells[9].Value.ToString();
                Grupo = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();

                ActualizarC.Show();
                ActualizarC.Buscar(CodSemestre, CodAsignatura, CodEscuelaP, Grupo);
            }//Actualizar Falta

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
                {
                    ObjEntidad.CodSemestre = Semestre;
                    ObjEntidad.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[8].Value.ToString();
                    ObjEntidad.CodEscuelaP = dgvDatos.Rows[e.RowIndex].Cells[9].Value.ToString();
                    ObjEntidad.Grupo = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();

                    ObjEntidadHA.CodSemestre = Semestre;
                    ObjEntidadHA.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[8].Value.ToString();
                    ObjEntidadHA.CodEscuelaP = dgvDatos.Rows[e.RowIndex].Cells[9].Value.ToString();
                    ObjEntidadHA.Grupo = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();

                    ObjNegocioHA.EliminarHorarioAsignatura(ObjEntidadHA);
                    ObjNegocio.EliminarAsignaturaCatalogo(ObjEntidad);
                    A_Dialogo.DialogoConfirmacion("Registro eliminado exitosamente");
                    //MensajeConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }//Eliminar Listo
        }
    }
}
