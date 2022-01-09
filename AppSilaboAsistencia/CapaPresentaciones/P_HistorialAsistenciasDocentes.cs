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

namespace CapaPresentaciones
{
    public partial class P_HistorialAsistenciasDocentes : Form
    {
        private readonly string CodSemestre;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();
        public P_HistorialAsistenciasDocentes()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LimtFechaInf = Semestre.Rows[0][1].ToString();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Por discutir
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
