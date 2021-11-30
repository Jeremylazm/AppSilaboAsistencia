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
    public partial class P_Catálogo_Actualizar : Form
    {
        readonly E_Catalogo ObjEntidadC;
        readonly N_Catalogo ObjNegocioC;
        readonly E_HorarioAsignatura ObjEntidadHA;
        readonly N_HorarioAsignatura ObjNegocioHA;
        int HoraTeoríaA = 0;
        int HoraPrácticaA = 0;
        int HTD1, HTD2 = 0;
        string CódigoDocente1, CódigoDocente2, CódigoAsignatura;
        int HoraTeoría, HoraPráctica;
        string CódigoAsignaturaA, CódigoSemestreA, GrupoA;
        public string CodDocenteG = "";
        public P_Catálogo_Actualizar()
        {
            ObjEntidadC = new E_Catalogo();
            ObjNegocioC = new N_Catalogo();
            ObjEntidadHA = new E_HorarioAsignatura();
            ObjNegocioHA = new N_HorarioAsignatura();
            InitializeComponent();
            Main();
        }

        private void P_Catálogo_Actualizar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bDSistemaGestionDataSet.TAsignatura' Puede moverla o quitarla según sea necesario.
            this.tAsignaturaTableAdapter.Fill(this.bDSistemaGestionDataSet.TAsignatura);
            // TODO: esta línea de código carga datos en la tabla 'bDSistemaGestionDataSet.TDocente' Puede moverla o quitarla según sea necesario.
            this.tDocenteTableAdapter.Fill(this.bDSistemaGestionDataSet.TDocente);

        }

        public void Recuperar_Horas_Asignaturas()
        {
            DataTable T = N_Asignatura.ObtenerHorasAsignatura(CódigoAsignatura);
            DataRow R = T.Rows[0];

            LabelP1.Text = R["HorasTeoria"].ToString();
            LabelP2.Text = R["HorasPractica"].ToString();

            HoraTeoría = Convert.ToInt32(R["HorasTeoria"].ToString());
            HoraPráctica = Convert.ToInt32(R["HorasPractica"].ToString());
        }

        public void Recuperar_Horas_Docentes()
        {
            int HT1 = 0;
            int HT2 = 0;
            DataTable T1 = N_HorarioAsignatura.HorasDocenteHorarioAsignatura(CódigoDocente1, Seleccionar_Semestre.Text);
            for (int i = 0; i < T1.Rows.Count; i++)
            {
                HT1 = HT1 + Convert.ToInt32(T1.Rows[i]["HorasTeoria"].ToString());
                HT1 = HT1 + Convert.ToInt32(T1.Rows[i]["HorasPractica"].ToString());
            }
            DataTable T2 = N_HorarioAsignatura.HorasDocenteHorarioAsignatura(CódigoDocente2, Seleccionar_Semestre.Text);
            for (int i = 0; i < T2.Rows.Count; i++)
            {
                HT2 = HT2 + Convert.ToInt32(T2.Rows[i]["HorasTeoria"].ToString());
                HT2 = HT2 + Convert.ToInt32(T2.Rows[i]["HorasPractica"].ToString());
            }

            Label_Horas_Asignadas_Docente1.Text = Convert.ToString(HT1);
            Label_Horas_Asignadas_Docente2.Text = Convert.ToString(HT2);

            HTD1 = HT1;
            HTD2 = HT2;
        }

        public void Guardar()
        {
            string CódigoAS, CódigoD1, CódigoD2, CódigoS, Grupo, Día1, Día2, Día3, Día4
                                , Día5, Día6, Tipo1, Tipo2, Tipo3, Tipo4, Tipo5, Tipo6;
            int HoraInicio1, HoraFin1, HoraInicio2, HoraFin2, HoraInicio3, HoraFin3, HoraInicio4
                , HoraFin4, HoraInicio5, HoraFin5, HoraInicio6, HoraFin6;
            string Aula;
            string Modalidad;
            if (Check_Código_Docente.Checked == true)
            {
                CódigoD1 = Seleccionar_Docente_Cod_Nom.Text;
                CódigoD2 = Seleccionar_Docente_Cod_Nom2.Text;
            }
            else
            {
                Check_Código_Docente.Checked = true;
                CódigoD1 = Seleccionar_Docente_Cod_Nom.Text;
                CódigoD2 = Seleccionar_Docente_Cod_Nom2.Text;
                Check_Código_Docente.Checked = false;
            }
            if (Check_Código_Asignatura.Checked == true)
                CódigoAS = Seleccionar_Asignatura_Cod_Nom.Text;
            else
            {
                Check_Código_Asignatura.Checked = true;
                CódigoAS = Seleccionar_Asignatura_Cod_Nom.Text;
                Check_Código_Asignatura.Checked = false;
            }
            if (Check_Grupo_A.Checked == true)
                Grupo = "A";
            else if (Check_Grupo_B.Checked == true)
                Grupo = "B";
            else
                Grupo = "C";

            CódigoS = Seleccionar_Semestre.Text;
            Aula = Seleccionar_Aula.Text;
            Modalidad = Seleccionar_Modalidad.Text;

            if (Check_Día_Lunes.Checked == true)
                Día1 = "LU";
            else
                Día1 = "";
            if (Check_Día_Martes.Checked == true)
                Día2 = "MA";
            else
                Día2 = "";
            if (Check_Día_Miércoles.Checked == true)
                Día3 = "MI";
            else
                Día3 = "";
            if (Check_Día_Jueves.Checked == true)
                Día4 = "JU";
            else
                Día4 = "";
            if (Check_Día_Viernes.Checked == true)
                Día5 = "VI";
            else
                Día5 = "";
            if (Check_Día_Sábado.Checked == true)
                Día6 = "SA";
            else
                Día6 = "";

            if (Check_T_Lunes.Checked == true)
                Tipo1 = "T";
            else if (Check_P_Lunes.Checked == true)
                Tipo1 = "P";
            else
                Tipo1 = "";
            if (Check_T_Martes.Checked == true)
                Tipo2 = "T";
            else if (Check_P_Martes.Checked == true)
                Tipo2 = "P";
            else
                Tipo2 = "";
            if (Check_T_Miércoles.Checked == true)
                Tipo3 = "T";
            else if (Check_P_Miércoles.Checked == true)
                Tipo3 = "P";
            else
                Tipo3 = "";
            if (Check_T_Jueves.Checked == true)
                Tipo4 = "T";
            else if (Check_P_Jueves.Checked == true)
                Tipo4 = "P";
            else
                Tipo4 = "";
            if (Check_T_Viernes.Checked == true)
                Tipo5 = "T";
            else if (Check_P_Viernes.Checked == true)
                Tipo5 = "P";
            else
                Tipo5 = "";
            if (Check_T_Sábado.Checked == true)
                Tipo6 = "T";
            else if (Check_P_Sábado.Checked == true)
                Tipo6 = "P";
            else
                Tipo6 = "";

            if (Check_1_Docentes.Checked == true)
            {
                if (Día1 != "")
                    HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                if (Día2 != "")
                    HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                if (Día3 != "")
                    HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                if (Día4 != "")
                    HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                if (Día5 != "")
                    HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                if (Día6 != "")
                    HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);

                if (HTD1 <= 10 || CódigoD1 == "00000")
                {
                    try
                    {
                        //Eliminar el anterior registro de THorarioAsignatura

                        N_HorarioAsignatura.EliminarHorarioAsignatura(CódigoSemestreA, CódigoAsignaturaA, "IN", GrupoA);

                        //Eliminar registro del catálogo

                        N_Catalogo.EliminarAsignaturaCatalogo(CódigoSemestreA, CódigoAsignaturaA, "IN", GrupoA);

                        //Insertar primer elemento a la tabla TCatálogo
                        ObjEntidadC.CodSemestre = CódigoS;
                        ObjEntidadC.CodAsignatura = CódigoAS;
                        ObjEntidadC.CodEscuelaP = "IN";
                        ObjEntidadC.Grupo = Grupo;
                        ObjEntidadC.CodDocente = CódigoD1;
                        ObjEntidadC.Silabo = new byte[1];
                        ObjEntidadC.PlanSesiones = new byte[1];

                        ObjNegocioC.InsertarAsignaturaCatalogo(ObjEntidadC);

                        //Insertar elementos a la tabla THorarioAsignatura

                        ObjEntidadHA.CodSemestre = CódigoS;
                        ObjEntidadHA.CodAsignatura = CódigoAS;
                        ObjEntidadHA.CodEscuelaP = "IN";
                        ObjEntidadHA.Grupo = Grupo;
                        ObjEntidadHA.CodDocente = CódigoD1;

                        if (Día1 != "")
                        {
                            ObjEntidadHA.Dia = Día1;
                            ObjEntidadHA.Tipo = Tipo1;
                            HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                            HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                            if (Tipo1 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día2 != "")
                        {
                            ObjEntidadHA.Dia = Día2;
                            ObjEntidadHA.Tipo = Tipo2;
                            HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                            HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                            if (Tipo2 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día3 != "")
                        {
                            ObjEntidadHA.Dia = Día3;
                            ObjEntidadHA.Tipo = Tipo3;
                            HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                            HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                            if (Tipo3 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día4 != "")
                        {
                            ObjEntidadHA.Dia = Día4;
                            ObjEntidadHA.Tipo = Tipo4;
                            HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                            HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                            if (Tipo4 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día5 != "")
                        {
                            ObjEntidadHA.Dia = Día5;
                            ObjEntidadHA.Tipo = Tipo5;
                            HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                            HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                            if (Tipo5 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día6 != "")
                        {
                            ObjEntidadHA.Dia = Día6;
                            ObjEntidadHA.Tipo = Tipo6;
                            HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                            HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                            if (Tipo6 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        MessageBox.Show("Actualizado con éxito.");
                        Program.Evento = 0;
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ya se ingresó en el catálogo u horario un contenido similar.");
                    }   
                }
                else
                {
                    MessageBox.Show("Las horas totales del docente serían: " + HTD1 + "\nLas cuales supera su límite\nNo se puede actualizar.");
                    CódigoDocente1 = CódigoD1;
                    CódigoDocente2 = CódigoD2;
                    Recuperar_Horas_Docentes();
                }
            }
            else
            {
                if (Día1 != "" && Día2 != "" && Día3 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                    if (Tipo2 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                    if (Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                }
                else if (Día1 != "" && Día2 != "" && Día4 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    if (Tipo2 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                }
                else if (Día1 != "" && Día2 != "" && Día5 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo2 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día1 != "" && Día2 != "" && Día6 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo2 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día1 != "" && Día3 != "" && Día4 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    if (Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                }
                else if (Día1 != "" && Día3 != "" && Día5 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día1 != "" && Día3 != "" && Día6 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día1 != "" && Día4 != "" && Día5 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día1 != "" && Día4 != "" && Día6 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día1 != "" && Día5 != "" && Día6 != "")
                {
                    if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día2 != "" && Día3 != "" && Día4 != "")
                {
                    if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    if (Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                }
                else if (Día2 != "" && Día3 != "" && Día5 != "")
                {
                    if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día2 != "" && Día3 != "" && Día6 != "")
                {
                    if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día2 != "" && Día4 != "" && Día5 != "")
                {
                    if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día2 != "" && Día4 != "" && Día6 != "")
                {
                    if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día3 != "" && Día4 != "" && Día5 != "")
                {
                    if (Tipo3 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día3 != "" && Día4 != "" && Día6 != "")
                {
                    if (Tipo3 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día3 != "" && Día5 != "" && Día6 != "")
                {
                    if (Tipo3 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día4 != "" && Día5 != "" && Día6 != "")
                {
                    if (Tipo4 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    if (Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }

                if (Día1 != "" && Día2 != "")
                {
                    if (Tipo1 == "P" && Tipo2 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                    }
                    else if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                    }
                }
                else if (Día1 != "" && Día3 != "")
                {
                    if (Tipo1 == "P" && Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                    else if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                }
                else if (Día1 != "" && Día4 != "")
                {
                    if (Tipo1 == "P" && Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    else if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                }
                else if (Día1 != "" && Día5 != "")
                {
                    if (Tipo1 == "P" && Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día1 != "" && Día6 != "")
                {
                    if (Tipo1 == "P" && Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else if (Tipo1 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día2 != "" && Día3 != "")
                {
                    if (Tipo2 == "P" && Tipo3 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                    else if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    }
                }
                else if (Día2 != "" && Día4 != "")
                {
                    if (Tipo2 == "P" && Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    else if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                }
                else if (Día2 != "" && Día5 != "")
                {
                    if (Tipo2 == "P" && Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día2 != "" && Día6 != "")
                {
                    if (Tipo2 == "P" && Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else if (Tipo2 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día3 != "" && Día4 != "")
                {
                    if (Tipo3 == "P" && Tipo4 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    else if (Tipo3 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    }
                }
                else if (Día3 != "" && Día5 != "")
                {
                    if (Tipo3 == "P" && Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else if (Tipo3 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día3 != "" && Día6 != "")
                {
                    if (Tipo3 == "P" && Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else if (Tipo3 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día4 != "" && Día5 != "")
                {
                    if (Tipo4 == "P" && Tipo5 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else if (Tipo4 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    }
                }
                else if (Día4 != "" && Día6 != "")
                {
                    if (Tipo4 == "P" && Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else if (Tipo4 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }
                else if (Día5 != "" && Día6 != "")
                {
                    if (Tipo5 == "P" && Tipo6 == "P")
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else if (Tipo5 == "P")
                    {
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                    else
                    {
                        HTD1 = HTD1 + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                        HTD2 = HTD2 + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    }
                }

                if ((HTD1 <= 10 && HTD2 <= 10) || (CódigoD1 == "00000" && CódigoD2 == "00000"))
                {
                    if (CódigoD1 != CódigoD2 || (CódigoD1 == "00000" && CódigoD2 == "00000"))
                    {
                        try
                        {
                            //Eliminar el anterior registro de THorarioAsignatura

                            N_HorarioAsignatura.EliminarHorarioAsignatura(CódigoSemestreA, CódigoAsignaturaA, "IN", GrupoA);

                            //Eliminar registro del catálogo

                            N_Catalogo.EliminarAsignaturaCatalogo(CódigoSemestreA, CódigoAsignaturaA, "IN", GrupoA);

                            //Insertar primer elemento a la tabla TCatálogo

                            ObjEntidadC.CodSemestre = CódigoS;
                            ObjEntidadC.CodAsignatura = CódigoAS;
                            ObjEntidadC.CodEscuelaP = "IN";
                            ObjEntidadC.Grupo = Grupo;
                            ObjEntidadC.CodDocente = CódigoD1;
                            ObjEntidadC.Silabo = new byte[1];
                            ObjEntidadC.PlanSesiones = new byte[1];

                            ObjNegocioC.InsertarAsignaturaCatalogo(ObjEntidadC);

                            //Insertar segundo elemento a la tabla TCatálogo

                            ObjEntidadC.CodSemestre = CódigoS;
                            ObjEntidadC.CodAsignatura = CódigoAS;
                            ObjEntidadC.CodEscuelaP = "IN";
                            ObjEntidadC.Grupo = Grupo;
                            ObjEntidadC.CodDocente = CódigoD2;
                            ObjEntidadC.Silabo = new byte[1];
                            ObjEntidadC.PlanSesiones = new byte[1];

                            ObjNegocioC.InsertarAsignaturaCatalogo(ObjEntidadC);

                            //Insertar elementos a la tabla THorarioAsignatura

                            ObjEntidadHA.CodSemestre = CódigoS;
                            ObjEntidadHA.CodAsignatura = CódigoAS;
                            ObjEntidadHA.CodEscuelaP = "IN";
                            ObjEntidadHA.Grupo = Grupo;
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            if (Día1 != "" && Día2 != "" && Día3 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día2 != "" && Día4 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día2 != "" && Día5 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día2 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día3 != "" && Día4 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día3 != "" && Día5 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día3 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día4 != "" && Día5 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día4 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día1 != "" && Día5 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día1;
                                ObjEntidadHA.Tipo = Tipo1;
                                HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                if (Tipo1 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día2 != "" && Día3 != "" && Día4 != "")
                            {
                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día2 != "" && Día3 != "" && Día5 != "")
                            {
                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día2 != "" && Día3 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día2 != "" && Día4 != "" && Día5 != "")
                            {
                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día2 != "" && Día4 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día2 != "" && Día5 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día2;
                                ObjEntidadHA.Tipo = Tipo2;
                                HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                if (Tipo2 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día3 != "" && Día4 != "" && Día5 != "")
                            {
                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día3 != "" && Día4 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día3 != "" && Día5 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día3;
                                ObjEntidadHA.Tipo = Tipo3;
                                HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                if (Tipo3 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }
                            else if (Día4 != "" && Día5 != "" && Día6 != "")
                            {
                                ObjEntidadHA.Dia = Día4;
                                ObjEntidadHA.Tipo = Tipo4;
                                HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                if (Tipo4 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día5;
                                ObjEntidadHA.Tipo = Tipo5;
                                HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                if (Tipo5 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                ObjEntidadHA.Dia = Día6;
                                ObjEntidadHA.Tipo = Tipo6;
                                HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                if (Tipo6 == "P")
                                {
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                }
                                else
                                {
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;
                                }

                                ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                            }

                            if (Día1 != "" && Día2 != "")
                            {
                                if (Tipo1 == "P" && Tipo2 == "P")
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    if (Tipo1 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    if (Tipo2 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día1 != "" && Día3 != "")
                            {
                                if (Tipo1 == "P" && Tipo3 == "P")
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    if (Tipo1 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    if (Tipo3 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día1 != "" && Día4 != "")
                            {
                                if (Tipo1 == "P" && Tipo4 == "P")
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    if (Tipo1 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    if (Tipo4 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día1 != "" && Día5 != "")
                            {
                                if (Tipo1 == "P" && Tipo5 == "P")
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    if (Tipo1 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    if (Tipo5 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día1 != "" && Día6 != "")
                            {
                                if (Tipo1 == "P" && Tipo6 == "P")
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día1;
                                    ObjEntidadHA.Tipo = Tipo1;
                                    HoraInicio1 = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                    HoraFin1 = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio1);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin1);
                                    if (Tipo1 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin1 - HoraInicio1;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin1 - HoraInicio1;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    if (Tipo6 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día2 != "" && Día3 != "")
                            {
                                if (Tipo2 == "P" && Tipo3 == "P")
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    if (Tipo2 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    if (Tipo3 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día2 != "" && Día4 != "")
                            {
                                if (Tipo2 == "P" && Tipo4 == "P")
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    if (Tipo2 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    if (Tipo4 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día2 != "" && Día5 != "")
                            {
                                if (Tipo2 == "P" && Tipo5 == "P")
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    if (Tipo2 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    if (Tipo5 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día2 != "" && Día6 != "")
                            {
                                if (Tipo2 == "P" && Tipo6 == "P")
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día2;
                                    ObjEntidadHA.Tipo = Tipo2;
                                    HoraInicio2 = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                    HoraFin2 = Convert.ToInt32(Hora_Fin_Martes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio2);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin2);
                                    if (Tipo2 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin2 - HoraInicio2;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin2 - HoraInicio2;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    if (Tipo6 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día3 != "" && Día4 != "")
                            {
                                if (Tipo3 == "P" && Tipo4 == "P")
                                {
                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    if (Tipo3 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    if (Tipo4 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día3 != "" && Día5 != "")
                            {
                                if (Tipo3 == "P" && Tipo5 == "P")
                                {
                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    if (Tipo3 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    if (Tipo5 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día3 != "" && Día6 != "")
                            {
                                if (Tipo3 == "P" && Tipo6 == "P")
                                {
                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día3;
                                    ObjEntidadHA.Tipo = Tipo3;
                                    HoraInicio3 = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                    HoraFin3 = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio3);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin3);
                                    if (Tipo3 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin3 - HoraInicio3;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin3 - HoraInicio3;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    if (Tipo6 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día4 != "" && Día5 != "")
                            {
                                if (Tipo4 == "P" && Tipo5 == "P")
                                {
                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    if (Tipo4 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    if (Tipo5 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día4 != "" && Día6 != "")
                            {
                                if (Tipo4 == "P" && Tipo6 == "P")
                                {
                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = 0;
                                    ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día4;
                                    ObjEntidadHA.Tipo = Tipo4;
                                    HoraInicio4 = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                    HoraFin4 = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio4);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin4);
                                    if (Tipo4 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin4 - HoraInicio4;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin4 - HoraInicio4;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    if (Tipo6 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }
                            else if (Día5 != "" && Día6 != "")
                            {
                                if (Tipo5 == "T" && Tipo6 == "T")
                                {
                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    ObjEntidadHA.CodDocente = CódigoD1;
                                    ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                    ObjEntidadHA.HorasPractica = 0;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    ObjEntidadHA.CodDocente = CódigoD2;
                                    ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                    ObjEntidadHA.HorasPractica = 0;

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                                else
                                {
                                    ObjEntidadHA.Dia = Día5;
                                    ObjEntidadHA.Tipo = Tipo5;
                                    HoraInicio5 = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                    HoraFin5 = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio5);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin5);
                                    if (Tipo5 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin5 - HoraInicio5;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin5 - HoraInicio5;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);

                                    ObjEntidadHA.Dia = Día6;
                                    ObjEntidadHA.Tipo = Tipo6;
                                    HoraInicio6 = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                    HoraFin6 = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                    ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio6);
                                    ObjEntidadHA.HoraFin = Convert.ToString(HoraFin6);
                                    if (Tipo6 == "T")
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD1;
                                        ObjEntidadHA.HorasTeoria = HoraFin6 - HoraInicio6;
                                        ObjEntidadHA.HorasPractica = 0;
                                    }
                                    else
                                    {
                                        ObjEntidadHA.CodDocente = CódigoD2;
                                        ObjEntidadHA.HorasTeoria = 0;
                                        ObjEntidadHA.HorasPractica = HoraFin6 - HoraInicio6;
                                    }

                                    ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                }
                            }

                            MessageBox.Show("Actualizado con éxito.");
                            Program.Evento = 0;
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ya se ingresó en el catálogo u horario un contenido similar.");
                        }
                    }
                    else
                        MessageBox.Show("Los docentes seleccionados no deben ser iguales.");
                }
                else
                {
                    MessageBox.Show("Las horas del primer docente serían: " + HTD1 + "\nLas horas del segundo docente serían: " + HTD2 + "\nNo deben de superar las 10 horas semanales.");
                    CódigoDocente1 = CódigoD1;
                    CódigoDocente2 = CódigoD2;
                    Recuperar_Horas_Docentes();
                }
            }
        }

        private void Botón_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                /*Validar*/
                if ((Check_Grupo_A.Checked == true || Check_Grupo_B.Checked == true || Check_Grupo_C.Checked == true)
                    && (Check_Día_Lunes.Checked == true || Check_Día_Martes.Checked == true || Check_Día_Miércoles.Checked == true
                    || Check_Día_Jueves.Checked == true || Check_Día_Viernes.Checked == true || Check_Día_Sábado.Checked == true)
                    && (Seleccionar_Semestre.SelectedItem != null) && (Check_Nombre_Docente.Checked == true || Check_Código_Docente.Checked == true)
                    && (Check_Nombre_Asignatura.Checked == true || Check_Código_Asignatura.Checked == true) && (Seleccionar_Aula.SelectedItem != null)
                    && (Seleccionar_Modalidad.SelectedItem != null))
                {
                    if ((Convert.ToInt32(Label_Horas_Asignadas_Docente1.Text) <= 10 && Convert.ToInt32(Label_Horas_Asignadas_Docente2.Text) <= 10
                        && Check_2_Docentes.Checked == true) || (Convert.ToInt32(Label_Horas_Asignadas_Docente1.Text) <= 10 && Check_1_Docentes.Checked == true))
                    {
                        if (HoraTeoría == HoraTeoríaA && HoraPráctica == HoraPrácticaA)
                        {
                            Guardar();
                        }
                        else
                            MessageBox.Show("Las horas de teoría y práctica no concuerdan.");
                    }
                    else if (Check_1_Docentes.Checked == true && (Seleccionar_Docente_Cod_Nom.Text == "00000" || Seleccionar_Docente_Cod_Nom.Text == "DOCENTE PRUEBA"))
                    {
                        if (HoraTeoría == HoraTeoríaA && HoraPráctica == HoraPrácticaA)
                            Guardar();
                        else
                            MessageBox.Show("Las horas de teoría y práctica no concuerdan.");
                    }
                    else if (Check_2_Docentes.Checked == true && (Seleccionar_Docente_Cod_Nom.Text == "00000" || Seleccionar_Docente_Cod_Nom.Text == "DOCENTE PRUEBA") && (Seleccionar_Docente_Cod_Nom2.Text == "00000" || Seleccionar_Docente_Cod_Nom2.Text == "DOCENTE PRUEBA"))
                    {
                        if (HoraTeoría == HoraTeoríaA && HoraPráctica == HoraPrácticaA)
                            Guardar();
                        else
                            MessageBox.Show("Las horas de teoría y práctica no concuerdan.");
                    }
                    else
                        MessageBox.Show("Las horas de los docentes no debe superar sus límites.");
                }
                else
                    MessageBox.Show("No seleccionó todos los items o hay items mal puestos.");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Convert.ToString(Ex));
                this.Close();
            }
        }

        private void Check_1_Docentes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_1_Docentes.Checked == true)
            {
                Check_2_Docentes.Checked = false;
                Seleccionar_Docente_Cod_Nom.Enabled = true;
                Seleccionar_Docente_Cod_Nom2.Enabled = false;
            }
            else
            {
                Check_1_Docentes.Checked = false;
                Seleccionar_Docente_Cod_Nom.Enabled = true;
                Seleccionar_Docente_Cod_Nom2.Enabled = true;
                Check_2_Docentes.Checked = true;
            }
        }

        private void Check_2_Docentes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_2_Docentes.Checked == true)
            {
                Check_1_Docentes.Checked = false;
                Seleccionar_Docente_Cod_Nom.Enabled = true;
                Seleccionar_Docente_Cod_Nom2.Enabled = true;
                label24.Visible = true;
                label25.Visible = true;
                Label_Horas_Asignadas_Docente2.Visible = true;           
            }
            else
            {
                Check_2_Docentes.Checked = false;
                Seleccionar_Docente_Cod_Nom.Enabled = true;
                Seleccionar_Docente_Cod_Nom2.Enabled = false;
                Check_1_Docentes.Checked = true;
                label24.Visible = false;
                label25.Visible = false;
                Label_Horas_Asignadas_Docente2.Visible = false;
            }
        }

        private void Seleccionar_Docente_Cod_Nom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Check_Código_Docente.Checked == true)
                    CódigoDocente1 = Seleccionar_Docente_Cod_Nom.Text;
                else
                {
                    DataTable T = N_Docente.ObtenerCodigoDocente(Seleccionar_Docente_Cod_Nom.Text);
                    DataRow R = T.Rows[0];
                    CódigoDocente1 = R["CodDocente"].ToString();
                }
                Recuperar_Horas_Docentes();
            }
            catch
            {
                //Falta ver cuál es el problema...
            }
        }

        private void Seleccionar_Docente_Cod_Nom2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Check_Código_Docente.Checked == true)
                    CódigoDocente2 = Seleccionar_Docente_Cod_Nom2.Text;
                else
                {
                    DataTable T = N_Docente.ObtenerCodigoDocente(Seleccionar_Docente_Cod_Nom2.Text);
                    DataRow R = T.Rows[0];
                    CódigoDocente2 = R["CodDocente"].ToString();
                }
                Recuperar_Horas_Docentes();
            }
            catch
            {
                //Falta ver cuál es el problema...
            }
        }

        private void Check_Nombre_Docente_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Nombre_Docente.Checked == true)
            {
                Check_Código_Docente.Checked = false;
                Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                Seleccionar_Docente_Cod_Nom2.DisplayMember = "Nombre";
            }
            else
            {
                Check_Nombre_Docente.Checked = false;
                Seleccionar_Docente_Cod_Nom.DisplayMember = "CodDocente";
                Seleccionar_Docente_Cod_Nom2.DisplayMember = "CodDocente";
                Check_Código_Docente.Checked = true;
            }
        }

        private void Check_Código_Docente_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Código_Docente.Checked == true)
            {
                Check_Nombre_Docente.Checked = false;
                Seleccionar_Docente_Cod_Nom.DisplayMember = "CodDocente";
                Seleccionar_Docente_Cod_Nom2.DisplayMember = "CodDocente";
            }
            else
            {
                Check_Código_Docente.Checked = false;
                Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                Seleccionar_Docente_Cod_Nom2.DisplayMember = "Nombre";
                Check_Nombre_Docente.Checked = true;
            }
        }

        private void Seleccionar_Asignatura_Cod_Nom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Check_Código_Asignatura.Checked == true)
                    CódigoAsignatura = Seleccionar_Asignatura_Cod_Nom.Text;
                else
                {
                    DataTable T = N_Asignatura.ObtenerCódigoAsignatura(Seleccionar_Asignatura_Cod_Nom.Text);
                    DataRow R = T.Rows[0];
                    CódigoAsignatura = R["CodAsignatura"].ToString();
                }
                Recuperar_Horas_Asignaturas();
            }
            catch
            {
                //Falta ver cuál es el problema...
            }
        }

        private void Check_Nombre_Asignatura_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Nombre_Asignatura.Checked == true)
            {
                Check_Código_Asignatura.Checked = false;
                Seleccionar_Asignatura_Cod_Nom.DisplayMember = "NombreAsignatura";
            }
            else
            {
                Check_Nombre_Asignatura.Checked = false;
                Seleccionar_Asignatura_Cod_Nom.DisplayMember = "CodAsignatura";
                Check_Código_Asignatura.Checked = true;
            }
        }

        private void Check_Código_Asignatura_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Código_Asignatura.Checked == true)
            {
                Check_Nombre_Asignatura.Checked = false;
                Seleccionar_Asignatura_Cod_Nom.DisplayMember = "CodAsignatura";
            }
            else
            {
                Check_Código_Asignatura.Checked = false;
                Seleccionar_Asignatura_Cod_Nom.DisplayMember = "NombreAsignatura";
                Check_Nombre_Asignatura.Checked = true;
            }
        }

        private void Check_Grupo_A_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Grupo_A.Checked == true)
            {
                Check_Grupo_B.Checked = false;
                Check_Grupo_C.Checked = false;
            }
            else
            {
                if (Check_Grupo_B.Checked == true)
                    Check_Grupo_C.Checked = false;
                else
                    Check_Grupo_C.Checked = true;
            }
        }

        private void Check_Grupo_B_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Grupo_B.Checked == true)
            {
                Check_Grupo_A.Checked = false;
                Check_Grupo_C.Checked = false;
            }
            else
            {
                if (Check_Grupo_A.Checked == true)
                    Check_Grupo_C.Checked = false;
                else
                    Check_Grupo_C.Checked = true;
            }
        }

        private void Check_Grupo_C_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Grupo_C.Checked == true)
            {
                Check_Grupo_A.Checked = false;
                Check_Grupo_B.Checked = false;
            }
            else
            {
                if (Check_Grupo_A.Checked == true)
                    Check_Grupo_B.Checked = false;
                else
                    Check_Grupo_B.Checked = true;
            }
        }

        private void Seleccionar_Aula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Seleccionar_Aula.Text == "VIRT 1 IN" || Seleccionar_Aula.Text == "VIRT 2 IN" || Seleccionar_Aula.Text == "VIRT 3 IN"
                || Seleccionar_Aula.Text == "VIRT 4 IN" || Seleccionar_Aula.Text == "VIRT 5 IN" || Seleccionar_Aula.Text == "VIRT 6 IN"
                || Seleccionar_Aula.Text == "VIRT 7 IN" || Seleccionar_Aula.Text == "VIRT 8 IN" || Seleccionar_Aula.Text == "VIRT 9 IN"
                || Seleccionar_Aula.Text == "VIRT 10 IN" || Seleccionar_Aula.Text == "VIRT 11 IN")
            {
                if (Seleccionar_Modalidad.Text == "PRESENCIAL")
                {
                    Seleccionar_Modalidad.Text = "VIRTUAL";
                }
            }
            else
            {
                if (Seleccionar_Modalidad.Text == "VIRTUAL")
                {
                    Seleccionar_Modalidad.Text = "PRESENCIAL";
                }
            }
        }

        private void Check_Día_Lunes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Lunes.Checked == true)
            {
                Check_P_Lunes.Enabled = true;
                Check_T_Lunes.Enabled = true;
                Hora_Inicio_Lunes.Enabled = true;
                Hora_Fin_Lunes.Enabled = true;
                Check_T_Lunes.Checked = true;
            }
            else
            {
                if (Check_P_Lunes.Checked == true)
                {
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                if (Check_T_Lunes.Checked == true)
                {
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                Check_P_Lunes.Enabled = false;
                Check_T_Lunes.Enabled = false;
                Hora_Inicio_Lunes.Enabled = false;
                Hora_Fin_Lunes.Enabled = false;
                Check_T_Lunes.Checked = false;
                Check_P_Lunes.Checked = false;
            }
        }

        private void Check_Día_Martes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Martes.Checked == true)
            {
                Check_P_Martes.Enabled = true;
                Check_T_Martes.Enabled = true;
                Hora_Inicio_Martes.Enabled = true;
                Hora_Fin_Martes.Enabled = true;
                Check_T_Martes.Checked = true;
            }
            else
            {
                if (Check_P_Martes.Checked == true)
                {
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                if (Check_T_Martes.Checked == true)
                {
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                Check_P_Martes.Enabled = false;
                Check_T_Martes.Enabled = false;
                Hora_Inicio_Martes.Enabled = false;
                Hora_Fin_Martes.Enabled = false;
                Check_T_Martes.Checked = false;
                Check_P_Martes.Checked = false;
            }
        }

        private void Check_Día_Miércoles_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Miércoles.Checked == true)
            {
                Check_P_Miércoles.Enabled = true;
                Check_T_Miércoles.Enabled = true;
                Hora_Inicio_Miércoles.Enabled = true;
                Hora_Fin_Miércoles.Enabled = true;
                Check_T_Miércoles.Checked = true;
            }
            else
            {
                if (Check_P_Miércoles.Checked == true)
                {
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                if (Check_T_Miércoles.Checked == true)
                {
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                Check_P_Miércoles.Enabled = false;
                Check_T_Miércoles.Enabled = false;
                Hora_Inicio_Miércoles.Enabled = false;
                Hora_Fin_Miércoles.Enabled = false;
                Check_T_Miércoles.Checked = false;
                Check_P_Miércoles.Checked = false;
            }
        }

        private void Check_Día_Jueves_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Jueves.Checked == true)
            {
                Check_P_Jueves.Enabled = true;
                Check_T_Jueves.Enabled = true;
                Hora_Inicio_Jueves.Enabled = true;
                Hora_Fin_Jueves.Enabled = true;
                Check_T_Jueves.Checked = true;
            }
            else
            {
                if (Check_P_Jueves.Checked == true)
                {
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                if (Check_T_Jueves.Checked == true)
                {
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                Check_P_Jueves.Enabled = false;
                Check_T_Jueves.Enabled = false;
                Hora_Inicio_Jueves.Enabled = false;
                Hora_Fin_Jueves.Enabled = false;
                Check_T_Jueves.Checked = false;
                Check_P_Jueves.Checked = false;
            }
        }

        private void Check_Día_Viernes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Viernes.Checked == true)
            {
                Check_P_Viernes.Enabled = true;
                Check_T_Viernes.Enabled = true;
                Hora_Inicio_Viernes.Enabled = true;
                Hora_Fin_Viernes.Enabled = true;
                Check_T_Viernes.Checked = true;
            }
            else
            {
                if (Check_P_Viernes.Checked == true)
                {
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                if (Check_T_Viernes.Checked == true)
                {
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                Check_P_Viernes.Enabled = false;
                Check_T_Viernes.Enabled = false;
                Hora_Inicio_Viernes.Enabled = false;
                Hora_Fin_Viernes.Enabled = false;
                Check_T_Viernes.Checked = false;
                Check_P_Viernes.Checked = false;
            }
        }

        private void Check_Día_Sábado_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Sábado.Checked == true)
            {
                Check_P_Sábado.Enabled = true;
                Check_T_Sábado.Enabled = true;
                Hora_Inicio_Sábado.Enabled = true;
                Hora_Fin_Sábado.Enabled = true;
                Check_T_Sábado.Checked = true;
            }
            else
            {
                if (Check_P_Sábado.Checked == true)
                {
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                if (Check_T_Sábado.Checked == true)
                {
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                Check_P_Sábado.Enabled = false;
                Check_T_Sábado.Enabled = false;
                Hora_Inicio_Sábado.Enabled = false;
                Hora_Fin_Sábado.Enabled = false;
                Check_T_Sábado.Checked = false;
                Check_P_Sábado.Checked = false;
            }
        }

        private void Check_T_Lunes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Lunes.Checked == true)
            {
                if (Check_T_Lunes.Checked == true)
                {
                    Check_P_Lunes.Checked = false;
                    HoraTeoríaA = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + HoraTeoríaA;
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                else
                {
                    Check_T_Lunes.Checked = false;
                    Check_P_Lunes.Checked = true;
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
            }
            else
            {
                Check_T_Lunes.Checked = false;
                Check_P_Lunes.Checked = false;
            }
        }

        private void Check_P_Lunes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Lunes.Checked == true)
            {
                if (Check_P_Lunes.Checked == true)
                {
                    Check_T_Lunes.Checked = false;
                    HoraPrácticaA = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + HoraPrácticaA;
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                else
                {
                    Check_P_Lunes.Checked = false;
                    Check_T_Lunes.Checked = true;
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
            else
            {
                Check_T_Lunes.Checked = false;
                Check_P_Lunes.Checked = false;
            }
        }

        private void Check_T_Martes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Martes.Checked == true)
            {
                if (Check_T_Martes.Checked == true)
                {
                    Check_P_Martes.Checked = false;
                    HoraTeoríaA = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + HoraTeoríaA;
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                else
                {
                    Check_T_Martes.Checked = false;
                    Check_P_Martes.Checked = true;
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
            }
            else
            {
                Check_T_Martes.Checked = false;
                Check_P_Martes.Checked = false;
            }
        }

        private void Check_P_Martes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Martes.Checked == true)
            {
                if (Check_P_Martes.Checked == true)
                {
                    Check_T_Martes.Checked = false;
                    HoraPrácticaA = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + HoraPrácticaA;
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                else
                {
                    Check_P_Martes.Checked = false;
                    Check_T_Martes.Checked = true;
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
            else
            {
                Check_T_Martes.Checked = false;
                Check_P_Martes.Checked = false;
            }
        }

        private void Check_T_Miércoles_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Miércoles.Checked == true)
            {
                if (Check_T_Miércoles.Checked == true)
                {
                    Check_P_Miércoles.Checked = false;
                    HoraTeoríaA = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + HoraTeoríaA;
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                else
                {
                    Check_T_Miércoles.Checked = false;
                    Check_P_Miércoles.Checked = true;
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
            }
            else
            {
                Check_T_Miércoles.Checked = false;
                Check_P_Miércoles.Checked = false;
            }
        }

        private void Check_P_Miércoles_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Miércoles.Checked == true)
            {
                if (Check_P_Miércoles.Checked == true)
                {
                    Check_T_Miércoles.Checked = false;
                    HoraPrácticaA = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + HoraPrácticaA;
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                else
                {
                    Check_P_Miércoles.Checked = false;
                    Check_T_Miércoles.Checked = true;
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
            else
            {
                Check_T_Miércoles.Checked = false;
                Check_P_Miércoles.Checked = false;
            }
        }

        private void Check_T_Jueves_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Jueves.Checked == true)
            {
                if (Check_T_Jueves.Checked == true)
                {
                    Check_P_Jueves.Checked = false;
                    HoraTeoríaA = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + HoraTeoríaA;
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                else
                {
                    Check_T_Jueves.Checked = false;
                    Check_P_Jueves.Checked = true;
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
            }
            else
            {
                Check_T_Jueves.Checked = false;
                Check_P_Jueves.Checked = false;
            }
        }

        private void Check_P_Jueves_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Jueves.Checked == true)
            {
                if (Check_P_Jueves.Checked == true)
                {
                    Check_T_Jueves.Checked = false;
                    HoraPrácticaA = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + HoraPrácticaA;
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                else
                {
                    Check_P_Jueves.Checked = false;
                    Check_T_Jueves.Checked = true;
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
            else
            {
                Check_T_Jueves.Checked = false;
                Check_P_Jueves.Checked = false;
            }
        }

        private void Check_T_Viernes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Viernes.Checked == true)
            {
                if (Check_T_Viernes.Checked == true)
                {
                    Check_P_Viernes.Checked = false;
                    HoraTeoríaA = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + HoraTeoríaA;
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                else
                {
                    Check_T_Viernes.Checked = false;
                    Check_P_Viernes.Checked = true;
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
            }
            else
            {
                Check_T_Viernes.Checked = false;
                Check_P_Viernes.Checked = false;
            }
        }

        private void Check_P_Viernes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Viernes.Checked == true)
            {
                if (Check_P_Viernes.Checked == true)
                {
                    Check_T_Viernes.Checked = false;
                    HoraPrácticaA = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + HoraPrácticaA;
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                else
                {
                    Check_P_Viernes.Checked = false;
                    Check_T_Viernes.Checked = true;
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
            else
            {
                Check_T_Viernes.Checked = false;
                Check_P_Viernes.Checked = false;
            }
        }

        private void Check_T_Sábado_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Sábado.Checked == true)
            {
                if (Check_T_Sábado.Checked == true)
                {
                    Check_P_Sábado.Checked = false;
                    HoraTeoríaA = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + HoraTeoríaA;
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                else
                {
                    Check_T_Sábado.Checked = false;
                    Check_P_Sábado.Checked = true;
                    HoraTeoríaA = HoraTeoríaA - (Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text));
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
            }
            else
            {
                Check_T_Sábado.Checked = false;
                Check_P_Sábado.Checked = false;
            }
        }

        private void Check_P_Sábado_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Día_Sábado.Checked == true)
            {
                if (Check_P_Sábado.Checked == true)
                {
                    Check_T_Sábado.Checked = false;
                    HoraPrácticaA = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + HoraPrácticaA;
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
                else
                {
                    Check_P_Sábado.Checked = false;
                    Check_T_Sábado.Checked = true;
                    HoraPrácticaA = HoraPrácticaA - (Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
            else
            {
                Check_T_Sábado.Checked = false;
                Check_P_Sábado.Checked = false;
            }
        }

        private void Hora_Inicio_Lunes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Lunes.Text) >= Convert.ToInt32(Hora_Fin_Lunes.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Lunes.Text) >= 1)
                {
                    Hora_Inicio_Lunes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Lunes.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Lunes.Text) == 0)
                {
                    Hora_Fin_Lunes.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Lunes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Lunes.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Lunes.Checked == true)
                {
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Lunes.Checked == true)
                {
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Fin_Lunes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Lunes.Text) >= Convert.ToInt32(Hora_Fin_Lunes.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Lunes.Text) >= 1)
                {
                    Hora_Inicio_Lunes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Lunes.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Lunes.Text) == 0)
                {
                    Hora_Fin_Lunes.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Lunes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Lunes.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Lunes.Checked == true)
                {
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Lunes.Checked == true)
                {
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Inicio_Martes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Martes.Text) >= Convert.ToInt32(Hora_Fin_Martes.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Martes.Text) >= 1)
                {
                    Hora_Inicio_Martes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Martes.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Martes.Text) == 0)
                {
                    Hora_Fin_Martes.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Martes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Martes.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Martes.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Martes.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Fin_Martes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Martes.Text) >= Convert.ToInt32(Hora_Fin_Martes.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Martes.Text) >= 1)
                {
                    Hora_Inicio_Martes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Martes.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Martes.Text) == 0)
                {
                    Hora_Fin_Martes.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Martes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Martes.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Martes.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Martes.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Inicio_Miércoles_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Miércoles.Text) >= Convert.ToInt32(Hora_Fin_Miércoles.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Miércoles.Text) >= 1)
                {
                    Hora_Inicio_Miércoles.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Miércoles.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Miércoles.Text) == 0)
                {
                    Hora_Fin_Miércoles.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Miércoles.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Miércoles.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Miércoles.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Miércoles.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Fin_Miércoles_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Miércoles.Text) >= Convert.ToInt32(Hora_Fin_Miércoles.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Miércoles.Text) >= 1)
                {
                    Hora_Inicio_Miércoles.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Miércoles.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Miércoles.Text) == 0)
                {
                    Hora_Fin_Miércoles.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Miércoles.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Miércoles.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Miércoles.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Miércoles.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Inicio_Jueves_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Jueves.Text) >= Convert.ToInt32(Hora_Fin_Jueves.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Jueves.Text) >= 1)
                {
                    Hora_Inicio_Jueves.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Jueves.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Jueves.Text) == 0)
                {
                    Hora_Fin_Jueves.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Jueves.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Jueves.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Jueves.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Jueves.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Fin_Jueves_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Jueves.Text) >= Convert.ToInt32(Hora_Fin_Jueves.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Jueves.Text) >= 1)
                {
                    Hora_Inicio_Jueves.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Jueves.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Jueves.Text) == 0)
                {
                    Hora_Fin_Jueves.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Jueves.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Jueves.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Jueves.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Jueves.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Inicio_Viernes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Viernes.Text) >= Convert.ToInt32(Hora_Fin_Viernes.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Viernes.Text) >= 1)
                {
                    Hora_Inicio_Viernes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Viernes.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Viernes.Text) == 0)
                {
                    Hora_Fin_Viernes.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Viernes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Viernes.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Viernes.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Viernes.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Fin_Viernes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Viernes.Text) >= Convert.ToInt32(Hora_Fin_Viernes.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Viernes.Text) >= 1)
                {
                    Hora_Inicio_Viernes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Viernes.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Viernes.Text) == 0)
                {
                    Hora_Fin_Viernes.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Viernes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Viernes.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Viernes.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Viernes.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Sábado.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Hora_Inicio_Sábado_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Sábado.Text) >= Convert.ToInt32(Hora_Fin_Sábado.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Sábado.Text) >= 1)
                {
                    Hora_Inicio_Sábado.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Sábado.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Sábado.Text) == 0)
                {
                    Hora_Fin_Sábado.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Sábado.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Sábado.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Sábado.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Sábado.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        private void Información_Click(object sender, EventArgs e)
        {
            if (Panel_Info.Width == 0)
            {
                Panel_Info.Enabled = true;
                Panel_Info.Width = 138;
                Panel_Info.Height = 214;
            }
            else
            {
                Panel_Info.Enabled = false;
                Panel_Info.Width = 0;
                Panel_Info.Height = 0;
            }
        }

        private void Hora_Fin_Sábado_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Sábado.Text) >= Convert.ToInt32(Hora_Fin_Sábado.Text))
            {
                if (Convert.ToInt32(Hora_Fin_Sábado.Text) >= 1)
                {
                    Hora_Inicio_Sábado.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Sábado.Text) - 1, 0, 0);
                }
                else if (Convert.ToInt32(Hora_Fin_Sábado.Text) == 0)
                {
                    Hora_Fin_Sábado.Value = new DateTime(2022, 1, 1, 1, 0, 0);
                    Hora_Inicio_Sábado.Value = new DateTime(2022, 1, 1, Convert.ToInt32(Hora_Fin_Sábado.Text) - 1, 0, 0);
                }
                MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
            }
            else
            {
                int Aux = 0;
                if (Check_T_Sábado.Checked == true)
                {
                    if (Check_T_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_T_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_T_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_T_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_T_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    HoraTeoríaA = Aux + Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text);
                    LabelPR1.Text = Convert.ToString(HoraTeoríaA);
                }
                if (Check_P_Sábado.Checked == true)
                {
                    if (Check_P_Lunes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Lunes.Text) - Convert.ToInt32(Hora_Inicio_Lunes.Text) + Aux;
                    if (Check_P_Martes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Martes.Text) - Convert.ToInt32(Hora_Inicio_Martes.Text) + Aux;
                    if (Check_P_Miércoles.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Miércoles.Text) - Convert.ToInt32(Hora_Inicio_Miércoles.Text) + Aux;
                    if (Check_P_Jueves.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Jueves.Text) - Convert.ToInt32(Hora_Inicio_Jueves.Text) + Aux;
                    if (Check_P_Viernes.Checked == true)
                        Aux = Convert.ToInt32(Hora_Fin_Viernes.Text) - Convert.ToInt32(Hora_Inicio_Viernes.Text) + Aux;
                    HoraPrácticaA = Aux + (Convert.ToInt32(Hora_Fin_Sábado.Text) - Convert.ToInt32(Hora_Inicio_Sábado.Text));
                    LabelPR2.Text = Convert.ToString(HoraPrácticaA);
                }
            }
        }

        public bool Buscar(string CS, string CA, string EP, string G)
        {
            string CodDocente, Día, Tipo, HI, HF, Aula, Modalidad;
            CódigoAsignaturaA = CA;
            GrupoA = G;
            CódigoSemestreA = CS;
            if (G == "A")
                Check_Grupo_A.Checked = true;
            else if (G == "B")
                Check_Grupo_B.Checked = true;
            else
                Check_Grupo_C.Checked = true;

            Seleccionar_Asignatura_Cod_Nom.DisplayMember = "CodAsignatura";
            Seleccionar_Asignatura_Cod_Nom.SelectedValue = CA;
            Seleccionar_Asignatura_Cod_Nom.DisplayMember = "NombreAsignatura";

            CódigoAsignatura = CA;
            Recuperar_Horas_Asignaturas();

            DataTable T1 = N_HorarioAsignatura.BuscarHorarioAsignatura(CS, CA, EP, G);
            string[] TipoT = new string[T1.Rows.Count];
            string[] DocenteT = new string[T1.Rows.Count];
            if (T1.Rows.Count >= 1)
            {
                string CodDocenteP = T1.Rows[0]["CodDocente"].ToString();
                Aula = T1.Rows[0]["Aula"].ToString();
                Modalidad = T1.Rows[0]["Modalidad"].ToString();
                Seleccionar_Aula.Text = Aula;
                Seleccionar_Modalidad.Text = Modalidad;
                Seleccionar_Semestre.Text = CS;
                for (int i = 0; i < T1.Rows.Count; i++)
                {
                    Tipo = T1.Rows[i]["Tipo"].ToString();
                    TipoT[i] = Tipo;
                    CodDocente = T1.Rows[i]["CodDocente"].ToString();
                    DocenteT[i] = CodDocente;
                    if (CodDocenteP == CodDocente)
                    {
                        if (Tipo == "T")
                        {
                            Seleccionar_Docente_Cod_Nom.DisplayMember = "CodDocente";
                            Seleccionar_Docente_Cod_Nom.SelectedValue = CodDocenteP;
                            Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        }
                        else
                        {
                            Seleccionar_Docente_Cod_Nom2.DisplayMember = "CodDocente";
                            Seleccionar_Docente_Cod_Nom2.SelectedValue = CodDocenteP;
                            Seleccionar_Docente_Cod_Nom2.DisplayMember = "Nombre";
                        }
                    }
                    else
                    {
                        Check_2_Docentes.Checked = true;
                        if (Tipo == "T")
                        {
                            Seleccionar_Docente_Cod_Nom.DisplayMember = "CodDocente";
                            Seleccionar_Docente_Cod_Nom.SelectedValue = CodDocente;
                            Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        }
                        else
                        {
                            Seleccionar_Docente_Cod_Nom2.DisplayMember = "CodDocente";
                            Seleccionar_Docente_Cod_Nom2.SelectedValue = CodDocente;
                            Seleccionar_Docente_Cod_Nom2.DisplayMember = "Nombre";
                        }
                    }

                    Día = T1.Rows[i]["Dia"].ToString();
                    HI = T1.Rows[i]["HoraInicio"].ToString();
                    HF = T1.Rows[i]["HoraFin"].ToString();

                    if (Día == "LU")
                    {
                        Check_Día_Lunes.Checked = true;
                        Hora_Fin_Lunes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HF), 0, 0);
                        Hora_Inicio_Lunes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HI), 0, 0);
                        if (Tipo == "T")
                            Check_T_Lunes.Checked = true;
                        else
                            Check_P_Lunes.Checked = true;
                    }
                    if (Día == "MA")
                    {
                        Check_Día_Martes.Checked = true;
                        Hora_Fin_Martes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HF), 0, 0);
                        Hora_Inicio_Martes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HI), 0, 0);
                        if (Tipo == "T")
                            Check_T_Martes.Checked = true;
                        else
                            Check_P_Martes.Checked = true;
                    }
                    if (Día == "MI")
                    {
                        Check_Día_Miércoles.Checked = true;
                        Hora_Fin_Miércoles.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HF), 0, 0);
                        Hora_Inicio_Miércoles.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HI), 0, 0);
                        if (Tipo == "T")
                            Check_T_Miércoles.Checked = true;
                        else
                            Check_P_Miércoles.Checked = true;
                    }
                    if (Día == "JU")
                    {
                        Check_Día_Jueves.Checked = true;
                        Hora_Fin_Jueves.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HF), 0, 0);
                        Hora_Inicio_Jueves.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HI), 0, 0);
                        if (Tipo == "T")
                            Check_T_Jueves.Checked = true;
                        else
                            Check_P_Jueves.Checked = true;
                    }
                    if (Día == "VI")
                    {
                        Check_Día_Viernes.Checked = true;
                        Hora_Fin_Viernes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HF), 0, 0);
                        Hora_Inicio_Viernes.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HI), 0, 0);
                        if (Tipo == "T")
                            Check_T_Viernes.Checked = true;
                        else
                            Check_P_Viernes.Checked = true;
                    }
                    if (Día == "SA")
                    {
                        Check_Día_Sábado.Checked = true;
                        Hora_Fin_Sábado.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HF), 0, 0);
                        Hora_Inicio_Sábado.Value = new DateTime(2022, 1, 1, Convert.ToInt32(HI), 0, 0);
                        if (Tipo == "T")
                            Check_T_Sábado.Checked = true;
                        else
                            Check_P_Sábado.Checked = true;
                    }
                }
                Seleccionar_Aula.Text = Aula;
                Seleccionar_Modalidad.Text = Modalidad;
                if (T1.Rows.Count == 2 && TipoT[0] == "P" && TipoT[1] == "P")
                {
                    if (DocenteT[0] != DocenteT[1])
                    {
                        Check_2_Docentes.Checked = true;
                        Check_1_Docentes.Checked = false;
                        Seleccionar_Docente_Cod_Nom.DisplayMember = "CodDocente";
                        Seleccionar_Docente_Cod_Nom2.DisplayMember = "CodDocente";
                        Seleccionar_Docente_Cod_Nom.SelectedValue = DocenteT[0];
                        Seleccionar_Docente_Cod_Nom2.SelectedValue = DocenteT[1];
                        Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        Seleccionar_Docente_Cod_Nom2.DisplayMember = "Nombre";
                        Seleccionar_Docente_Cod_Nom2.Enabled = true;
                    }
                    else
                    {
                        Check_1_Docentes.Checked = true;
                        Seleccionar_Docente_Cod_Nom.DisplayMember = "CodDocente";
                        Seleccionar_Docente_Cod_Nom.SelectedValue = DocenteT[0];
                        Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        Seleccionar_Docente_Cod_Nom2.Enabled = false;
                    }
                }
                return true;
            }
            else
                return false;
        } //Falta arreglar

        private void Seleccionar_Modalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Seleccionar_Modalidad.Text == "VIRTUAL")
            {
                if (Seleccionar_Aula.Text != "VIRT 1 IN" || Seleccionar_Aula.Text != "VIRT 2 IN" || Seleccionar_Aula.Text != "VIRT 3 IN"
                    || Seleccionar_Aula.Text != "VIRT 4 IN" || Seleccionar_Aula.Text != "VIRT 5 IN" || Seleccionar_Aula.Text != "VIRT 6 IN"
                    || Seleccionar_Aula.Text != "VIRT 7 IN" || Seleccionar_Aula.Text != "VIRT 8 IN" || Seleccionar_Aula.Text != "VIRT 9 IN"
                    || Seleccionar_Aula.Text != "VIRT 10 IN" || Seleccionar_Aula.Text != "VIRT 11 IN")
                {
                    Seleccionar_Aula.Text = "VIRT 1 IN";
                }
            }
            else
            {
                if (Seleccionar_Aula.Text != "IN101" || Seleccionar_Aula.Text != "IN102" || Seleccionar_Aula.Text != "IN103"
                    || Seleccionar_Aula.Text != "IN104" || Seleccionar_Aula.Text != "IN105" || Seleccionar_Aula.Text != "IN201"
                    || Seleccionar_Aula.Text != "IN202" || Seleccionar_Aula.Text != "IN203" || Seleccionar_Aula.Text != "IN204"
                    || Seleccionar_Aula.Text != "IN205" || Seleccionar_Aula.Text != "IN206" || Seleccionar_Aula.Text != "IN207"
                    || Seleccionar_Aula.Text != "IN301" || Seleccionar_Aula.Text != "IN302" || Seleccionar_Aula.Text != "IN303"
                    || Seleccionar_Aula.Text != "IN304" || Seleccionar_Aula.Text != "IN305" || Seleccionar_Aula.Text != "IN306"
                    || Seleccionar_Aula.Text != "IN307")
                {
                    Seleccionar_Aula.Text = "IN101";
                }
            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            this.Close();
        }

        public void Main()
        {
            Check_Nombre_Asignatura.Checked = true;
            Check_1_Docentes.Checked = true;
            Check_Nombre_Docente.Checked = true;
            Seleccionar_Docente_Cod_Nom2.Enabled = false;
            Check_P_Lunes.Enabled = false;
            Check_T_Lunes.Enabled = false;
            Hora_Inicio_Lunes.Enabled = false;
            Hora_Fin_Lunes.Enabled = false;
            Check_P_Martes.Enabled = false;
            Check_T_Martes.Enabled = false;
            Hora_Inicio_Martes.Enabled = false;
            Hora_Fin_Martes.Enabled = false;
            Check_P_Miércoles.Enabled = false;
            Check_T_Miércoles.Enabled = false;
            Hora_Inicio_Miércoles.Enabled = false;
            Hora_Fin_Miércoles.Enabled = false;
            Check_P_Jueves.Enabled = false;
            Check_T_Jueves.Enabled = false;
            Hora_Inicio_Jueves.Enabled = false;
            Hora_Fin_Jueves.Enabled = false;
            Check_P_Viernes.Enabled = false;
            Check_T_Viernes.Enabled = false;
            Hora_Inicio_Viernes.Enabled = false;
            Hora_Fin_Viernes.Enabled = false;
            Check_P_Sábado.Enabled = false;
            Check_T_Sábado.Enabled = false;
            Hora_Inicio_Sábado.Enabled = false;
            Hora_Fin_Sábado.Enabled = false;
            Panel_Info.Enabled = false;
            Panel_Info.Height = 0;
            Panel_Info.Width = 0;
            label24.Visible = false;
            label25.Visible = false;
            Label_Horas_Asignadas_Docente2.Visible = false;
        }
    }
}
