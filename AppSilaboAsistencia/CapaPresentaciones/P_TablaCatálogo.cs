using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using ControlesPerzonalizados;
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
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

        public P_TablaCatálogo()
        {
            ObjEntidad = new E_Catalogo();
            ObjNegocio = new N_Catalogo();
            ObjEntidadHA = new E_HorarioAsignatura();
            ObjNegocioHA = new N_HorarioAsignatura();
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
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
            dgvDatos.Columns[0].Width = 50;
            dgvDatos.Columns[1].Width = 50;
            dgvDatos.Columns[5].Width = 60;
            dgvDatos.Columns[6].Width = 90;
            dgvDatos.Columns[8].Width = 70;
            dgvDatos.Columns[9].Width = 50;
        }//Listo

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }//Listo

        public void BuscarRegistros()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarCatálogo(CodSemestre, CodDepartamentoA, txtBuscar.Text);
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
            Program.Cont = Program.Cont + 1;
            if (Program.Cont < 2)
            {
                P_Catálogo_Agregar C = new P_Catálogo_Agregar();
                C.Show();
            }
        }//Listo

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_Catalogo.MostrarCatalogo(CodSemestre, CodDepartamentoA);
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
                string CodAsignatura, CodEscuelaP, Grupo;

                Program.Evento = 1;

                CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[8].Value.ToString();
                CodEscuelaP = dgvDatos.Rows[e.RowIndex].Cells[9].Value.ToString();
                Grupo = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();

                Program.Cont = Program.Cont + 1;
                if (Program.Cont < 2)
                {
                    P_Catálogo_Actualizar ActualizarC = new P_Catálogo_Actualizar();
                    ActualizarC.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                    ActualizarC.Show();
                    ActualizarC.Buscar(CodSemestre, CodAsignatura, CodEscuelaP, Grupo);
                }
            }//Actualizar Falta

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
                {
                    ObjEntidad.CodSemestre = CodSemestre;
                    ObjEntidad.CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[8].Value.ToString();
                    ObjEntidad.CodEscuelaP = dgvDatos.Rows[e.RowIndex].Cells[9].Value.ToString();
                    ObjEntidad.Grupo = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();

                    ObjEntidadHA.CodSemestre = CodSemestre;
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
        }//Listo
    }
}
