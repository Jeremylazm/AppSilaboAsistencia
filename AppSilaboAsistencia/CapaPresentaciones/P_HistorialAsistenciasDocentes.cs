using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using Ayudas;
namespace CapaPresentaciones
{
    public partial class P_HistorialAsistenciasDocentes : Form
    {
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();
        public P_HistorialAsistenciasDocentes()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LimtFechaInf = Semestre.Rows[0][1].ToString();
            CodDepartamentoA = "IF";
            InitializeComponent();
            MostrarRegistros();
        }
        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 4;
            dgvDatos.Columns[1].HeaderText = "Fecha";
            dgvDatos.Columns[2].HeaderText = "Total Asistieron";
            dgvDatos.Columns[3].HeaderText = "Total Faltaron";
            dgvDatos.Columns[4].HeaderText = "Observacion";

        }
        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDiariaDocente.AsistenciaDocentesPorFechas(CodSemestre,LimtFechaInf,LimtFechaSup);
            AccionesTabla();
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }
        //NombreCompleto del jefe de departamento
        public string NombreCompletoJD()
		{
            DataTable DocentesDepartamentoA = N_Docente.MostrarTodosDocentesDepartamento(CodDepartamentoA);
            foreach (DataRow fila in DocentesDepartamentoA.Rows)
            {
                
                if (fila[0].Equals(CodDocente))
                {

                    return fila[1].ToString();
                }
            }
            return "--";
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Editar
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
			{
                DataTable RegistroAsistenciaDocentesDA = N_AsistenciaDiariaDocente.AsistenciaDiariaDocentes(CodSemestre, CodDepartamentoA, dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString());
                if (RegistroAsistenciaDocentesDA.Rows.Count != 0)
                {
                    Form Fondo = new Form();
                    P_TablaAsistenciaDiariaDocente EddRegistroAsistenciaDocente = new P_TablaAsistenciaDiariaDocente(RegistroAsistenciaDocentesDA);

                    EddRegistroAsistenciaDocente.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                    EddRegistroAsistenciaDocente.txtFecha.Text = dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    EddRegistroAsistenciaDocente.txtSemestreA.Text = CodSemestre;
                    //EddRegistroAsistenciaDocente.hora = DateTime.Now.ToString("HH:mm:ss");
                    EddRegistroAsistenciaDocente.txtJD.Text = NombreCompletoJD();
                    EddRegistroAsistenciaDocente.Owner = Fondo;
                    EddRegistroAsistenciaDocente.ShowDialog();
                    EddRegistroAsistenciaDocente.Dispose();
                }
                else
                {
                    A_Dialogo.DialogoInformacion("El registro ¡No Existe!");
                }
            }
        }

		private void btnAgregarD_Click(object sender, EventArgs e)
		{
            // Por discutir
            Form Fondo = new Form();
            P_DialogoAgregarAsistenciaDocente AddFechaNoLavorable = new P_DialogoAgregarAsistenciaDocente();
            AddFechaNoLavorable.Owner = Fondo;
            AddFechaNoLavorable.ShowDialog();
            AddFechaNoLavorable.Dispose();
        }

		private void btnCambiar_Click(object sender, EventArgs e)
        {

        }
    }
}
