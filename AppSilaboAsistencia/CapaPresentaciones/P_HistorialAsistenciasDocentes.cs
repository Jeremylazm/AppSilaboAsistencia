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
            return "N";
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


        }

		private void btnAgregarD_Click(object sender, EventArgs e)
		{
            // Por discutir

            DataTable Resultados = N_AsistenciaDiariaDocente.AsistenciaDiariaDocentes(CodSemestre, CodDepartamentoA, LimtFechaSup);
            if (Resultados.Rows.Count == 0)
            {
                DataTable DocentesDepartamentoA = N_Docente.MostrarTodosDocentesDepartamento(CodDepartamentoA);
                Form Fondo = new Form();
                P_TablaAsistenciaDiariaDocente NuevoRegistroAsistenciaDocente = new P_TablaAsistenciaDiariaDocente(DocentesDepartamentoA);
                NuevoRegistroAsistenciaDocente.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                NuevoRegistroAsistenciaDocente.txtFecha.Text = LimtFechaSup;
                NuevoRegistroAsistenciaDocente.hora = DateTime.Now.ToString("HH:mm:ss");
                NuevoRegistroAsistenciaDocente.txtJD.Text = NombreCompletoJD();
                NuevoRegistroAsistenciaDocente.Owner = Fondo;
                NuevoRegistroAsistenciaDocente.ShowDialog();
                NuevoRegistroAsistenciaDocente.Dispose();
            }
            else
            {
                A_Dialogo.DialogoInformacion("El registro de Hoy, ¡Ya existe!");
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {

        }
    }
}
