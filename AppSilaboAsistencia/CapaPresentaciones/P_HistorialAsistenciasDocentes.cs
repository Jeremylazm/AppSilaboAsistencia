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
using System.Globalization;
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
        public string LimtFechaSup = DateTime.Now.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")).ToString();

        public P_HistorialAsistenciasDocentes()
        {
            
            ObjEntidadHorarioRegistroAsistencia=new E_HorarioRegistroAsistencia();
            ObjNegocioHorarioRegistroAsistencia=new N_HorarioRegistroAsistencia();

            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LimtFechaInf = DateTime.ParseExact(Semestre.Rows[0][1].ToString(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
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
            dgvDatos.Columns[2].HeaderText = "Asistieron";
            dgvDatos.Columns[3].HeaderText = "Faltaron";
            dgvDatos.Columns[4].HeaderText = "Observación";
        }

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_AsistenciaDiariaDocente.AsistenciaDocentesPorFechas(CodSemestre, DateTime.Parse(LimtFechaInf).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), DateTime.Parse(LimtFechaSup).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
            //atributos del las columnas del datagridview
            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columna.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            dgvDatos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvDatos.Columns[0].MinimumWidth = 150;
            dgvDatos.Columns[0].Width = 150;
            dgvDatos.Columns[1].MinimumWidth = 200;
            dgvDatos.Columns[1].Width = 200;
            dgvDatos.Columns[2].MinimumWidth = 200;
            dgvDatos.Columns[2].Width = 200;
            dgvDatos.Columns[3].MinimumWidth = 200;
            dgvDatos.Columns[3].Width = 200;
            dgvDatos.Columns[4].MinimumWidth = 350;
            dgvDatos.Columns[4].Width = 350;
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
            MostrarHorarioRegistroAsistencia();
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
                DataTable RegistroAsistenciaDocentesDA = N_AsistenciaDiariaDocente.AsistenciaDiariaDocentes(CodSemestre, CodDepartamentoA, DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")));
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
                        EddRegistroAsistenciaDocente.txtFecha.Text = DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString(), CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                        //EddRegistroAsistenciaDocente.txtSemestre.Text = CodSemestre;
                        //EddRegistroAsistenciaDocente.hora = DateTime.Now.ToString("HH:mm:ss");
                        //EddRegistroAsistenciaDocente.txtJD.Text = E_InicioSesion.Datos;
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
            AddFechaNoLavorable.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            AddFechaNoLavorable.Owner = Fondo;
            AddFechaNoLavorable.ShowDialog();
            AddFechaNoLavorable.Dispose();
        }
        public void EstablecerHorarioRegistroAsistenciaDiariaDocente()
		{
            DataTable BusacarHorarioRegistroAsistenciaDiariaDocente = N_HorarioRegistroAsistencia.BuscarHorarioRegistroAsistencia(CodSemestre, CodDepartamentoA);
            if(BusacarHorarioRegistroAsistenciaDiariaDocente.Rows.Count == 0)
			{
                if(A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea registrar el horario  de Asistencia Docentes?") == DialogResult.Yes)
				{
                    //Agregar
                    ObjEntidadHorarioRegistroAsistencia.CodSemestre = CodSemestre;
                    ObjEntidadHorarioRegistroAsistencia.CodDepartamentoA = CodDepartamentoA;
                    ObjEntidadHorarioRegistroAsistencia.HoraInicio = txtInicioHoras.Value.ToString() + ":" + txtInicioMinutos.Value.ToString() + ":00";
                    ObjEntidadHorarioRegistroAsistencia.HoraFin = txtFinHoras.Value.ToString() + ":" + txtFinMinutos.Value.ToString() + ":59";

                    ObjNegocioHorarioRegistroAsistencia.InsertarHorarioRegistroAsistencia(ObjEntidadHorarioRegistroAsistencia);
                    A_Dialogo.DialogoConfirmacion("Se Guardó Exitosamente");
                }
               
            }
            else
			{
                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea Editar el horario  de Asistencia Docentes?") == DialogResult.Yes)
                {
                    //Editar
                    ObjEntidadHorarioRegistroAsistencia.CodSemestre = CodSemestre;
                    ObjEntidadHorarioRegistroAsistencia.CodDepartamentoA = CodDepartamentoA;
                    string NHoraInicio = txtInicioHoras.Value.ToString() + ":" + txtInicioMinutos.Value.ToString() + ":00"; ;
                    string NHoraFinal = txtFinHoras.Value.ToString() + ":" + txtFinMinutos.Value.ToString() + ":59";

                    ObjNegocioHorarioRegistroAsistencia.ActualizarHorarioRegistroAsistencia(ObjEntidadHorarioRegistroAsistencia, NHoraInicio, NHoraFinal);
                    A_Dialogo.DialogoConfirmacion("Se Cambió Exitosamente");
                }
                
            }
		}
		private void btnCambiar_Click(object sender, EventArgs e)
        {
			if (txtFinHoras.Value == 0)
			{
                
                if (txtInicioHoras.Value <= txtFinHoras.Value+24)
                {
                    if (txtInicioHoras.Value == txtFinHoras.Value)
                    {
                        if (txtInicioMinutos.Value < txtFinMinutos.Value)
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
			else
			{
                if (txtInicioHoras.Value <= txtFinHoras.Value)
                {
                    if (txtInicioHoras.Value == txtFinHoras.Value)
                    {
                        if (txtInicioMinutos.Value < txtFinMinutos.Value)
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

            MostrarHorarioRegistroAsistencia();
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
