using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using Ayudas;
using Guna.UI2.WinForms;

namespace CapaPresentaciones
{
    public partial class P_HistorialAsistenciasDocentes : Form
    {
        
        readonly E_HorarioRegistroAsistencia ObjEntidadHorarioRegistroAsistencia;
        readonly N_HorarioRegistroAsistencia ObjNegocioHorarioRegistroAsistencia;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA;
        public string LimtFechaInf;
        public string LimtFechaSup = DateTime.Now.ToString("dd/MM/yyyy").ToString();

        public P_HistorialAsistenciasDocentes()
        {
            
            ObjEntidadHorarioRegistroAsistencia=new E_HorarioRegistroAsistencia();
            ObjNegocioHorarioRegistroAsistencia=new N_HorarioRegistroAsistencia();

            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LimtFechaInf = Semestre.Rows[0][1].ToString();
            CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
            InitializeComponent();
            MostrarRegistros();
            MostrarHorarioRegistroAsistencia();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
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
        public void MostrarHorarioRegistroAsistencia()
		{
            DataTable BusacarHoraioRegistroAsistencia = N_HorarioRegistroAsistencia.BuscarHorarioRegistroAsistencia(CodSemestre, CodDepartamentoA);
            if (BusacarHoraioRegistroAsistencia.Rows.Count!=0)
			{
                DateTime HoraIni =Convert.ToDateTime(BusacarHoraioRegistroAsistencia.Rows[0][0].ToString());
                txtInicioHoras.Value =Convert.ToDecimal(HoraIni.ToString("HH"));
                txtInicioMinutos.Value= Convert.ToDecimal(HoraIni.ToString("mm"));
                DateTime HoraFin = Convert.ToDateTime(BusacarHoraioRegistroAsistencia.Rows[0][1].ToString());
                txtFinHoras.Value = Convert.ToDecimal(HoraFin.ToString("HH"));
                txtFinMinutos.Value = Convert.ToDecimal(HoraFin.ToString("mm"));

            }
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
				if (dgvDatos.Rows[e.RowIndex].Cells[4].Value.Equals("FERIADO")|| dgvDatos.Rows[e.RowIndex].Cells[4].Value.Equals("SUSPENSION"))
				{
                    A_Dialogo.DialogoInformacion("No se pude Editar este tipo de registros");
				}
                else
				{
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
        public void EstablecerHorarioRegistroAsistenciaDiariaDocente()
		{
            DataTable BusacarHorarioRegistroAsistenciaDiariaDocente = N_HorarioRegistroAsistencia.BuscarHorarioRegistroAsistencia(CodSemestre, CodDepartamentoA);
            if(BusacarHorarioRegistroAsistenciaDiariaDocente.Rows.Count == 0)
			{
                //Agregar
                ObjEntidadHorarioRegistroAsistencia.CodSemestre = CodSemestre;
                ObjEntidadHorarioRegistroAsistencia.CodDepartamentoA = CodDepartamentoA;
                ObjEntidadHorarioRegistroAsistencia.HoraInicio =txtInicioHoras.Value.ToString()+":"+txtInicioMinutos.Value.ToString()+":00";
                ObjEntidadHorarioRegistroAsistencia.HoraFin = txtFinHoras.Value.ToString() + ":" + txtFinMinutos.Value.ToString() + ":59";

                ObjNegocioHorarioRegistroAsistencia.InsertarHorarioRegistroAsistencia(ObjEntidadHorarioRegistroAsistencia);
                A_Dialogo.DialogoConfirmacion("Se Guardó Exitosamente");
            }
            else
			{
                //Editar
                ObjEntidadHorarioRegistroAsistencia.CodSemestre = CodSemestre;
                ObjEntidadHorarioRegistroAsistencia.CodDepartamentoA = CodDepartamentoA;
                string NHoraInicio = txtInicioHoras.Value.ToString() + ":" + txtInicioMinutos.Value.ToString() + ":00"; ;
                string NHoraFinal = txtFinHoras.Value.ToString() + ":" + txtFinMinutos.Value.ToString() + ":59";

                ObjNegocioHorarioRegistroAsistencia.ActualizarHorarioRegistroAsistencia(ObjEntidadHorarioRegistroAsistencia,NHoraInicio,NHoraFinal);
                A_Dialogo.DialogoConfirmacion("Se Cambió Exitosamente");
            }
		}
		private void btnCambiar_Click(object sender, EventArgs e)
        {
            if(txtInicioHoras.Value<=txtFinHoras.Value)
			{
                if(txtInicioHoras.Value == txtFinHoras.Value)
				{
                    if(txtInicioMinutos.Value<txtFinMinutos.Value)
					{
                        EstablecerHorarioRegistroAsistenciaDiariaDocente();

                    }
                    else
					{
                        A_Dialogo.DialogoError("La Hora de Inicio debe ser menor a la Hora Final");
					}
				}
				else
				{
                    EstablecerHorarioRegistroAsistenciaDiariaDocente();

                }
			}
            else
			{
                A_Dialogo.DialogoError("La Hora de Inicio debe ser menor a la Hora final");
            }
            
        }

        private void ValidarTiempo(Guna2NumericUpDown Numero, int Minimo, int Maximo)
        {
            if (Numero.Value < 10)
                Numero.TextOffset = new Point(5, -1);
            else
                Numero.TextOffset = new Point(2, -1);

            if (Numero.Value == (Maximo + 1))
                Numero.Value = Minimo;

            if (Numero.Value == (Minimo - 1))
                Numero.Value = Maximo;
        }

        private void txtInicioHoras_ValueChanged(object sender, EventArgs e)
        {
            ValidarTiempo(txtInicioHoras, 0, 23);
        }

        private void txtInicioMinutos_ValueChanged(object sender, EventArgs e)
        {
            ValidarTiempo(txtInicioMinutos, 0, 59);
        }

        private void txtFinHoras_ValueChanged(object sender, EventArgs e)
        {
            ValidarTiempo(txtFinHoras, 0, 23);
        }

        private void txtFinMinutos_ValueChanged(object sender, EventArgs e)
        {
            ValidarTiempo(txtFinMinutos, 0, 59);
        }
    }
}
