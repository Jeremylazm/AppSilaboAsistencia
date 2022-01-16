using ControlesPerzonalizados;
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

namespace CapaPresentaciones
{
    public partial class P_PrincipalDocente : Form
    {
        readonly string CodSemestre;

        public P_PrincipalDocente()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            InitializeComponent();
        }

        private void P_PrincipalDocente_Load(object sender, EventArgs e)
        {
            string[] Dias = { "LU", "MA", "MI", "JU", "VI", "SA", "DO" };

            for (int J = 0; J < 7; J++)
            {
                C_Encabezado EncabezadoDia = new C_Encabezado();
                EncabezadoDia.txtTexto.Name = "Dia0" + (J + 1);
                EncabezadoDia.txtTexto.Text = Dias[J];
                pnDias.Controls.Add(EncabezadoDia);
            }

            for (int J = 0; J < 16; J++)
            {
                C_Encabezado EncabezadoHora = new C_Encabezado();
                EncabezadoHora.txtTexto.Name = "Hora" + (J + 1).ToString("D2");
                EncabezadoHora.txtTexto.Text = (J + 7).ToString("D2") + " - " + (J + 8).ToString("D2") + "";
                pnHoras.Controls.Add(EncabezadoHora);
            }

            for (int I = 1; I <= 16; I++)
            {
                for (int J = 1; J <= 7; J++)
                {
                    C_Evento EventoPersonalizado = new C_Evento();
                    EventoPersonalizado.btnEvento.Name = "Evento" + I.ToString("D2") + "_" + J.ToString("D2");
                    EventoPersonalizado.btnEvento.Text = "";
                    pnHorario.Controls.Add(EventoPersonalizado);
                }
            }

            DataTable HorarioDocente = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, E_InicioSesion.Usuario);

            foreach (DataRow FilaHorario in HorarioDocente.Rows)
            {
                string Asignatura = FilaHorario["CodAsignatura"].ToString();
                string Nombre = FilaHorario["NombreAsignatura"].ToString();
                string Tipo = FilaHorario["Tipo"].ToString();
                string Aula = FilaHorario["Aula"].ToString();
                string Modalidad = FilaHorario["Modalidad"].ToString();
                string Dia = FilaHorario["Dia"].ToString(); 
                int Inicio = Convert.ToInt32(FilaHorario["HoraInicio"].ToString());
                int Fin = Convert.ToInt32(FilaHorario["HoraFin"].ToString());
                string DiaAsignatura = "0" + (1 + Array.IndexOf(Dias, Dia));
                List<string> HorasAsignatura = new List<string>();

                for (int I = Inicio; I < Fin; I++)
                {
                    HorasAsignatura.Add((I - 6).ToString("D2"));
                }

                foreach (C_Evento EventoPersonalizado in pnHorario.Controls)
                {
                    if (EventoPersonalizado.btnEvento.Name.Substring(9, 2) == DiaAsignatura)
                    {
                        if (HorasAsignatura.Count != 0)
                        {
                            if (EventoPersonalizado.btnEvento.Name.Substring(6, 2) == HorasAsignatura[0])
                            {
                                EventoPersonalizado.btnEvento.OnIdleState.BorderColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.OnIdleState.FillColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.onHoverState.BorderColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.onHoverState.FillColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.OnPressedState.BorderColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.OnPressedState.FillColor = Color.FromArgb(232, 158, 31);

                                EventoPersonalizado.btnEvento.Text = Asignatura;
                                if (Tipo.Equals("T"))
                                    Tipo = "TEORÍA";
                                else
                                    Tipo = "PRÁCTICA";
                                EventoPersonalizado.ttEvento.SetToolTip(EventoPersonalizado.btnEvento, "<b>ASIGNATURA:</b> " + Nombre + "<br/><b>TIPO:</b> " + Tipo + "<br/><b>AULA:</b> " + Aula + "<br/><b>MODALIDAD:</b> " + Modalidad);
                                HorasAsignatura.RemoveAt(0);
                            }
                        }
                    }
                }
            }
        }
    }
}
