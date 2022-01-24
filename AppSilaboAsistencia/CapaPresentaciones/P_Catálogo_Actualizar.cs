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

namespace CapaPresentaciones
{
    public partial class P_Catálogo_Actualizar : Form
    {
        readonly E_Catalogo ObjEntidadC;
        readonly N_Catalogo ObjNegocioC;
        readonly E_HorarioAsignatura ObjEntidadHA;
        readonly N_HorarioAsignatura ObjNegocioHA;
        readonly E_Catalogo ObjEntidadCE;
        readonly N_Catalogo ObjNegocioCE;
        readonly E_HorarioAsignatura ObjEntidadHAE;
        readonly N_HorarioAsignatura ObjNegocioHAE;
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
        int HoraTeoríaA = 0;
        int HoraPrácticaA = 0;
        int HTD1, HTD2 = 0;
        int HD1 = 0;
        int HD2 = 0;
        string CódigoDocente1, CódigoDocente2, CódigoAsignatura;
        int HoraTeoría, HoraPráctica;
        string CódigoAsignaturaA, CódigoSemestreA, GrupoA, EscuelaPA;
        string CódigoD1A = "";
        string CódigoD2A = "";
        public P_Catálogo_Actualizar()
        {
            ObjEntidadC = new E_Catalogo();
            ObjNegocioC = new N_Catalogo();
            ObjEntidadHA = new E_HorarioAsignatura();
            ObjNegocioHA = new N_HorarioAsignatura();
            ObjEntidadCE = new E_Catalogo();
            ObjNegocioCE = new N_Catalogo();
            ObjEntidadHAE = new E_HorarioAsignatura();
            ObjNegocioHAE = new N_HorarioAsignatura();
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            InitializeComponent();
            Control[] Controles = { panel1, panel2, label1 };
            Docker.SubscribeControlsToDragEvents(Controles);
            Main();
            LlenarDatosEscuelas();
            LlenarDatosAsignatura();
            LlenarDatosDocente();
            Limpiar_Colores();
        }

        private void LlenarDatosEscuelas()
        {
            Seleccionar_EP.DataSource = N_EscuelaProfesional.MostrarEscuelas();

            Seleccionar_EP.ValueMember = "CodEscuelaP";
            Seleccionar_EP.DisplayMember = "Nombre";
        }

        private void LlenarDatosDocente()
        {
            Seleccionar_Docente_Cod_Nom.DataSource = N_Docente.MostrarTodosDocentesDepartamento(CodDepartamentoA);

            Seleccionar_Docente_Cod_Nom.ValueMember = "CodDocente";
            Seleccionar_Docente_Cod_Nom.DisplayMember = "NombreCompleto";

            Seleccionar_Docente_Cod_Nom2.DataSource = N_Docente.MostrarTodosDocentesDepartamento(CodDepartamentoA);

            Seleccionar_Docente_Cod_Nom2.ValueMember = "CodDocente";
            Seleccionar_Docente_Cod_Nom2.DisplayMember = "NombreCompleto";
        }

        private void LlenarDatosAsignatura()
        {
            Seleccionar_Asignatura_Cod_Nom.DataSource = N_Asignatura.MostrarAsignaturas(CodDepartamentoA);

            Seleccionar_Asignatura_Cod_Nom.ValueMember = "CodAsignatura";
            Seleccionar_Asignatura_Cod_Nom.DisplayMember = "NombreAsignatura";
        }

        private void P_Catálogo_Actualizar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bDSistemaGestionDataSet.TAsignatura' Puede moverla o quitarla según sea necesario.
            //this.tAsignaturaTableAdapter.Fill(this.bDSistemaGestionDataSet.TAsignatura);
            // TODO: esta línea de código carga datos en la tabla 'bDSistemaGestionDataSet.TDocente' Puede moverla o quitarla según sea necesario.
            //this.tDocenteTableAdapter.Fill(this.bDSistemaGestionDataSet.TDocente);
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
            DataTable T1 = N_HorarioAsignatura.HorasDocenteHorarioAsignatura(CódigoDocente1, CodSemestre);
            for (int i = 0; i < T1.Rows.Count; i++)
            {
                HT1 = HT1 + Convert.ToInt32(T1.Rows[i]["HorasTeoria"].ToString());
                HT1 = HT1 + Convert.ToInt32(T1.Rows[i]["HorasPractica"].ToString());
            }
            DataTable T2 = N_HorarioAsignatura.HorasDocenteHorarioAsignatura(CódigoDocente2, CodSemestre);
            for (int i = 0; i < T2.Rows.Count; i++)
            {
                HT2 = HT2 + Convert.ToInt32(T2.Rows[i]["HorasTeoria"].ToString());
                HT2 = HT2 + Convert.ToInt32(T2.Rows[i]["HorasPractica"].ToString());
            }

            HTD1 = HT1;
            HTD2 = HT2;
        }

        public bool Verificar_Horario(string CodDocente, string Día, string HoraInicio, string HoraFin)
        {
            string Días;
            int HoraI, HoraF;
            bool Pasa = true;

            DataTable T = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, CodDocente);

            if (T.Rows.Count >= 1)
            {
                for (int i = 0; i < T.Rows.Count; i++)
                {

                    Días = T.Rows[i]["Dia"].ToString();
                    if (Días == Día)
                    {
                        HoraI = Convert.ToInt32(T.Rows[i]["HoraInicio"].ToString());
                        HoraF = Convert.ToInt32(T.Rows[i]["HoraFin"].ToString());
                        if (Convert.ToInt32(HoraInicio) < HoraI && Convert.ToInt32(HoraFin) <= HoraI)
                            Pasa = Pasa && true;
                        else if (Convert.ToInt32(HoraInicio) >= HoraF)
                            Pasa = Pasa && true;
                        else
                            Pasa = Pasa && false;
                    }
                }
                return Pasa;
            }
            else
                return Pasa;
        }

        public void Guardar()
        {
            string CódigoAS, CódigoD1, CódigoD2, CódigoS, Grupo, Día1, Día2, Día3, Día4
                                , Día5, Día6, Tipo1, Tipo2, Tipo3, Tipo4, Tipo5, Tipo6;
            int HoraInicio, HoraFin;
            string Aula;
            string Modalidad;
            bool Pasa1 = true;
            bool Pasa2 = true;
            if (Check_Código_Docente.Checked == true)
            {
                CódigoD1 = Seleccionar_Docente_Cod_Nom.Text;
                CódigoD2 = Seleccionar_Docente_Cod_Nom2.Text;
            }
            else
            {
                CódigoD1 = Seleccionar_Docente_Cod_Nom.SelectedValue.ToString();
                CódigoD2 = Seleccionar_Docente_Cod_Nom2.SelectedValue.ToString();
            }
            if (Check_Código_Asignatura.Checked == true)
                CódigoAS = Seleccionar_Asignatura_Cod_Nom.Text;
            else
                CódigoAS = Seleccionar_Asignatura_Cod_Nom.SelectedValue.ToString();
            if (Check_Grupo_A.Checked == true)
                Grupo = "A";
            else if (Check_Grupo_B.Checked == true)
                Grupo = "B";
            else
                Grupo = "C";

            CódigoS = CodSemestre;
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
                //Eliminar el registro anterior de Horario Asignatura
                ObjEntidadHAE.CodSemestre = CódigoSemestreA;
                ObjEntidadHAE.CodAsignatura = CódigoAsignaturaA;
                ObjEntidadHAE.CodEscuelaP = EscuelaPA;
                ObjEntidadHAE.Grupo = GrupoA;

                ObjNegocioHAE.EliminarHorarioAsignatura(ObjEntidadHAE);

                if (Día1 != "")
                    Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día1, Hora_Inicio_Lunes.Text, Hora_Fin_Lunes.Text);
                if (Día2 != "")
                    Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día2, Hora_Inicio_Martes.Text, Hora_Fin_Martes.Text);
                if (Día3 != "")  
                    Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día3, Hora_Inicio_Miércoles.Text, Hora_Fin_Miércoles.Text);
                if (Día4 != "")
                    Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día4, Hora_Inicio_Jueves.Text, Hora_Fin_Jueves.Text);
                if (Día5 != "")
                    Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día5, Hora_Inicio_Viernes.Text, Hora_Fin_Viernes.Text);
                if (Día6 != "")
                    Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día6, Hora_Inicio_Sábado.Text, Hora_Fin_Sábado.Text);

                if (Pasa1 || CódigoD1 == "00000")
                {
                    try
                    {
                        //Eliminar el anterior registro de THorarioAsignatura

                        ObjEntidadHAE.CodSemestre = CódigoSemestreA;
                        ObjEntidadHAE.CodAsignatura = CódigoAsignaturaA;
                        ObjEntidadHAE.CodEscuelaP = EscuelaPA;
                        ObjEntidadHAE.Grupo = GrupoA;

                        ObjNegocioHAE.EliminarHorarioAsignatura(ObjEntidadHAE);

                        //Eliminar registro del catálogo

                        ObjEntidadCE.CodSemestre = CódigoSemestreA;
                        ObjEntidadCE.CodAsignatura = CódigoAsignaturaA;
                        ObjEntidadCE.CodEscuelaP = EscuelaPA;
                        ObjEntidadCE.Grupo = GrupoA;

                        ObjNegocioCE.EliminarAsignaturaCatalogo(ObjEntidadCE);

                        //Insertar primer elemento a la tabla TCatálogo
                        ObjEntidadC.CodSemestre = CódigoS;
                        ObjEntidadC.CodAsignatura = CódigoAS;
                        ObjEntidadC.CodEscuelaP = Seleccionar_EP.SelectedValue.ToString();
                        ObjEntidadC.Grupo = Grupo;
                        ObjEntidadC.CodDocente = CódigoD1;
                        ObjEntidadC.Silabo = new byte[1];
                        ObjEntidadC.PlanSesiones = new byte[1];

                        ObjNegocioC.InsertarAsignaturaCatalogo(ObjEntidadC);

                        //Insertar elementos a la tabla THorarioAsignatura

                        ObjEntidadHA.CodSemestre = CódigoS;
                        ObjEntidadHA.CodAsignatura = CódigoAS;
                        ObjEntidadHA.CodEscuelaP = Seleccionar_EP.SelectedValue.ToString();
                        ObjEntidadHA.Grupo = Grupo;
                        ObjEntidadHA.CodDocente = CódigoD1;

                        if (Día1 != "")
                        {
                            ObjEntidadHA.Dia = Día1;
                            ObjEntidadHA.Tipo = Tipo1;
                            HoraInicio = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                            HoraFin = Convert.ToInt32(Hora_Fin_Lunes.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                            if (Tipo1 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día2 != "")
                        {
                            ObjEntidadHA.Dia = Día2;
                            ObjEntidadHA.Tipo = Tipo2;
                            HoraInicio = Convert.ToInt32(Hora_Inicio_Martes.Text);
                            HoraFin = Convert.ToInt32(Hora_Fin_Martes.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                            if (Tipo2 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día3 != "")
                        {
                            ObjEntidadHA.Dia = Día3;
                            ObjEntidadHA.Tipo = Tipo3;
                            HoraInicio = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                            HoraFin = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                            if (Tipo3 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día4 != "")
                        {
                            ObjEntidadHA.Dia = Día4;
                            ObjEntidadHA.Tipo = Tipo4;
                            HoraInicio = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                            HoraFin = Convert.ToInt32(Hora_Fin_Jueves.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                            if (Tipo4 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día5 != "")
                        {
                            ObjEntidadHA.Dia = Día5;
                            ObjEntidadHA.Tipo = Tipo5;
                            HoraInicio = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                            HoraFin = Convert.ToInt32(Hora_Fin_Viernes.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                            if (Tipo5 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        if (Día6 != "")
                        {
                            ObjEntidadHA.Dia = Día6;
                            ObjEntidadHA.Tipo = Tipo6;
                            HoraInicio = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                            HoraFin = Convert.ToInt32(Hora_Fin_Sábado.Text);
                            ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                            ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                            if (Tipo6 == "T")
                            {
                                ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                ObjEntidadHA.HorasPractica = 0;
                            }
                            else
                            {
                                ObjEntidadHA.HorasTeoria = 0;
                                ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                            }
                            ObjEntidadHA.Aula = Aula;
                            ObjEntidadHA.Modalidad = Modalidad;

                            ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                        }
                        A_Dialogo.DialogoConfirmacion("Actualizado con éxito");
                        //MessageBox.Show("Actualizado con éxito.");
                        Program.Evento = 0;
                        Program.Cont = 0;
                        this.Close();
                    }
                    catch
                    {
                        A_Dialogo.DialogoError("Ya se ingresó en el catálogo u horario un contenido similar");
                        //MessageBox.Show("Ya se ingresó en el catálogo u horario un contenido similar.");
                        Program.Evento = 0;
                        Program.Cont = 0;
                        this.Close();
                    }
                }
                else
                {
                    A_Dialogo.DialogoError("Hay un cruce de horarios de ese docente");
                    //MessageBox.Show("Hay un cruce de horarios de ese docente.");
                }
            }
            else
            {
                if (HoraTeoría != 0 && HoraPráctica != 0)
                {
                    if (Día1 != "")
                    {
                        if (Tipo1 == "P")
                            Pasa2 = Pasa2 && Verificar_Horario(CódigoD2, Día1, Hora_Inicio_Lunes.Text, Hora_Fin_Lunes.Text);
                        else
                            Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día1, Hora_Inicio_Lunes.Text, Hora_Fin_Lunes.Text);
                    }
                    if (Día2 != "")
                    {
                        if (Tipo2 == "P")                       
                            Pasa2 = Pasa2 && Verificar_Horario(CódigoD2, Día2, Hora_Inicio_Martes.Text, Hora_Fin_Martes.Text);
                        else
                            Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día2, Hora_Inicio_Martes.Text, Hora_Fin_Martes.Text);
                    }
                    if (Día3 != "")
                    {
                        if (Tipo3 == "P")
                            Pasa2 = Pasa2 && Verificar_Horario(CódigoD2, Día3, Hora_Inicio_Miércoles.Text, Hora_Fin_Miércoles.Text);
                        else
                            Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día3, Hora_Inicio_Miércoles.Text, Hora_Fin_Miércoles.Text);
                    }
                    if (Día4 != "")
                    {
                        if (Tipo4 == "P")
                            Pasa2 = Pasa2 && Verificar_Horario(CódigoD2, Día4, Hora_Inicio_Jueves.Text, Hora_Fin_Jueves.Text);
                        else
                            Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día4, Hora_Inicio_Jueves.Text, Hora_Fin_Jueves.Text);
                    }
                    if (Día5 != "")
                    {
                        if (Tipo5 == "P")
                            Pasa2 = Pasa2 && Verificar_Horario(CódigoD2, Día5, Hora_Inicio_Viernes.Text, Hora_Fin_Viernes.Text);
                        else
                            Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día5, Hora_Inicio_Viernes.Text, Hora_Fin_Viernes.Text);
                    }
                    if (Día6 != "")
                    {
                        if (Tipo6 == "P")
                            Pasa2 = Pasa2 && Verificar_Horario(CódigoD2, Día6, Hora_Inicio_Sábado.Text, Hora_Fin_Sábado.Text);
                        else
                            Pasa1 = Pasa1 && Verificar_Horario(CódigoD1, Día6, Hora_Inicio_Sábado.Text, Hora_Fin_Sábado.Text);
                    }

                    if (CódigoD1 != CódigoD2)
                    {
                        if (Pasa1 || CódigoD1 == "00000")
                        {
                            if (Pasa2 || CódigoD2 == "00000")
                            {
                                try
                                {
                                    //Eliminar el anterior registro de THorarioAsignatura

                                    ObjEntidadHAE.CodSemestre = CódigoSemestreA;
                                    ObjEntidadHAE.CodAsignatura = CódigoAsignaturaA;
                                    ObjEntidadHAE.CodEscuelaP = Seleccionar_EP.SelectedValue.ToString();
                                    ObjEntidadHAE.Grupo = GrupoA;

                                    ObjNegocioHAE.EliminarHorarioAsignatura(ObjEntidadHAE);

                                    //Eliminar registro del catálogo

                                    ObjEntidadCE.CodSemestre = CódigoSemestreA;
                                    ObjEntidadCE.CodAsignatura = CódigoAsignaturaA;
                                    ObjEntidadCE.CodEscuelaP = Seleccionar_EP.SelectedValue.ToString();
                                    ObjEntidadCE.Grupo = GrupoA;

                                    ObjNegocioCE.EliminarAsignaturaCatalogo(ObjEntidadCE);

                                    //Insertar primer elemento a la tabla TCatálogo
                                    ObjEntidadC.CodSemestre = CódigoS;
                                    ObjEntidadC.CodAsignatura = CódigoAS;
                                    ObjEntidadC.CodEscuelaP = Seleccionar_EP.SelectedValue.ToString();
                                    ObjEntidadC.Grupo = Grupo;
                                    ObjEntidadC.CodDocente = CódigoD1;
                                    ObjEntidadC.Silabo = new byte[1];
                                    ObjEntidadC.PlanSesiones = new byte[1];

                                    ObjNegocioC.InsertarAsignaturaCatalogo(ObjEntidadC);

                                    //Insertar segundo elemento a la tabla TCatálogo
                                    ObjEntidadC.CodSemestre = CódigoS;
                                    ObjEntidadC.CodAsignatura = CódigoAS;
                                    ObjEntidadC.CodEscuelaP = Seleccionar_EP.SelectedValue.ToString();
                                    ObjEntidadC.Grupo = Grupo;
                                    ObjEntidadC.CodDocente = CódigoD2;
                                    ObjEntidadC.Silabo = new byte[1];
                                    ObjEntidadC.PlanSesiones = new byte[1];

                                    ObjNegocioC.InsertarAsignaturaCatalogo(ObjEntidadC);

                                    //Insertar elementos a la tabla THorarioAsignatura

                                    ObjEntidadHA.CodSemestre = CódigoS;
                                    ObjEntidadHA.CodAsignatura = CódigoAS;
                                    ObjEntidadHA.CodEscuelaP = Seleccionar_EP.SelectedValue.ToString();
                                    ObjEntidadHA.Grupo = Grupo;
                                    ObjEntidadHA.Aula = Aula;
                                    ObjEntidadHA.Modalidad = Modalidad;

                                    if (Día1 != "")
                                    {
                                        ObjEntidadHA.Dia = Día1;
                                        ObjEntidadHA.Tipo = Tipo1;
                                        HoraInicio = Convert.ToInt32(Hora_Inicio_Lunes.Text);
                                        HoraFin = Convert.ToInt32(Hora_Fin_Lunes.Text);
                                        ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                                        ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                                        if (Tipo1 == "P")
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD2;
                                            ObjEntidadHA.HorasTeoria = 0;
                                            ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                                        }
                                        else
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD1;
                                            ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                            ObjEntidadHA.HorasPractica = 0;
                                        }
                                        ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                    }
                                    if (Día2 != "")
                                    {
                                        ObjEntidadHA.Dia = Día2;
                                        ObjEntidadHA.Tipo = Tipo2;
                                        HoraInicio = Convert.ToInt32(Hora_Inicio_Martes.Text);
                                        HoraFin = Convert.ToInt32(Hora_Fin_Martes.Text);
                                        ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                                        ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                                        if (Tipo2 == "P")
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD2;
                                            ObjEntidadHA.HorasTeoria = 0;
                                            ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                                        }
                                        else
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD1;
                                            ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                            ObjEntidadHA.HorasPractica = 0;
                                        }
                                        ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                    }
                                    if (Día3 != "")
                                    {
                                        ObjEntidadHA.Dia = Día3;
                                        ObjEntidadHA.Tipo = Tipo3;
                                        HoraInicio = Convert.ToInt32(Hora_Inicio_Miércoles.Text);
                                        HoraFin = Convert.ToInt32(Hora_Fin_Miércoles.Text);
                                        ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                                        ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                                        if (Tipo3 == "P")
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD2;
                                            ObjEntidadHA.HorasTeoria = 0;
                                            ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                                        }
                                        else
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD1;
                                            ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                            ObjEntidadHA.HorasPractica = 0;
                                        }
                                        ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                    }
                                    if (Día4 != "")
                                    {
                                        ObjEntidadHA.Dia = Día4;
                                        ObjEntidadHA.Tipo = Tipo4;
                                        HoraInicio = Convert.ToInt32(Hora_Inicio_Jueves.Text);
                                        HoraFin = Convert.ToInt32(Hora_Fin_Jueves.Text);
                                        ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                                        ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                                        if (Tipo4 == "P")
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD2;
                                            ObjEntidadHA.HorasTeoria = 0;
                                            ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                                        }
                                        else
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD1;
                                            ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                            ObjEntidadHA.HorasPractica = 0;
                                        }
                                        ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                    }
                                    if (Día5 != "")
                                    {
                                        ObjEntidadHA.Dia = Día5;
                                        ObjEntidadHA.Tipo = Tipo5;
                                        HoraInicio = Convert.ToInt32(Hora_Inicio_Viernes.Text);
                                        HoraFin = Convert.ToInt32(Hora_Fin_Viernes.Text);
                                        ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                                        ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                                        if (Tipo5 == "P")
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD2;
                                            ObjEntidadHA.HorasTeoria = 0;
                                            ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                                        }
                                        else
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD1;
                                            ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                            ObjEntidadHA.HorasPractica = 0;
                                        }
                                        ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                    }
                                    if (Día6 != "")
                                    {
                                        ObjEntidadHA.Dia = Día6;
                                        ObjEntidadHA.Tipo = Tipo6;
                                        HoraInicio = Convert.ToInt32(Hora_Inicio_Sábado.Text);
                                        HoraFin = Convert.ToInt32(Hora_Fin_Sábado.Text);
                                        ObjEntidadHA.HoraInicio = Convert.ToString(HoraInicio);
                                        ObjEntidadHA.HoraFin = Convert.ToString(HoraFin);
                                        if (Tipo6 == "P")
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD2;
                                            ObjEntidadHA.HorasTeoria = 0;
                                            ObjEntidadHA.HorasPractica = HoraFin - HoraInicio;
                                        }
                                        else
                                        {
                                            ObjEntidadHA.CodDocente = CódigoD1;
                                            ObjEntidadHA.HorasTeoria = HoraFin - HoraInicio;
                                            ObjEntidadHA.HorasPractica = 0;
                                        }
                                        ObjNegocioHA.InsertarHorarioAsignatura(ObjEntidadHA);
                                    }

                                    A_Dialogo.DialogoConfirmacion("Actualizado con éxito");
                                    //MessageBox.Show("Actualizado con éxito.");
                                    Program.Evento = 0;
                                    Program.Cont = 0;
                                    this.Close();
                                }
                                catch
                                {
                                    A_Dialogo.DialogoError("Ya se ingresó en el catálogo u horario un contenido similar");
                                    //MessageBox.Show("Ya se ingresó en el catálogo u horario un contenido similar.");
                                    Program.Evento = 0;
                                    Program.Cont = 0;
                                    this.Close();
                                }
                            }
                            else
                            {
                                A_Dialogo.DialogoError("Hay un cruce de horarios del segundo docente");
                                //MessageBox.Show("Hay un cruce de horarios del segundo docente.");
                            }

                        }
                        else
                        {
                            A_Dialogo.DialogoError("Hay un cruce de horarios del primer docente");
                            //MessageBox.Show("Hay un cruce de horarios del primer docente.");
                        }

                    }
                    else
                    {
                        A_Dialogo.DialogoError("Los docentes seleccionados no deben ser iguales");
                        //MessageBox.Show("Los docentes seleccionados no deben ser iguales.");
                    }
                }
                else
                {
                    A_Dialogo.DialogoError("Ese curso no puede llevar 2 docentes");
                    //MessageBox.Show("Ese curso no puede llevar 2 docentes.");
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
                    && (Check_Nombre_Docente.Checked == true || Check_Código_Docente.Checked == true)
                    && (Check_Nombre_Asignatura.Checked == true || Check_Código_Asignatura.Checked == true) && (Seleccionar_Aula.SelectedItem != null)
                    && (Seleccionar_Modalidad.SelectedItem != null))
                {
                    if (Check_1_Docentes.Checked == true && (Seleccionar_Docente_Cod_Nom.Text == "00000" || Seleccionar_Docente_Cod_Nom.Text == "DOCENTE PRUEBA"))
                    {
                        if (HoraTeoría == HoraTeoríaA && HoraPráctica == HoraPrácticaA)
                            Guardar();
                        else
                        {
                            A_Dialogo.DialogoError("Las horas de teoría y práctica no concuerdan");
                            //MessageBox.Show("Las horas de teoría y práctica no concuerdan.");
                        }
                            
                    }
                    else if (Check_2_Docentes.Checked == true && (Seleccionar_Docente_Cod_Nom.Text == "00000" || Seleccionar_Docente_Cod_Nom.Text == "DOCENTE PRUEBA") && (Seleccionar_Docente_Cod_Nom2.Text == "00000" || Seleccionar_Docente_Cod_Nom2.Text == "DOCENTE PRUEBA"))
                    {
                        if (HoraTeoría == HoraTeoríaA && HoraPráctica == HoraPrácticaA)
                            Guardar();
                        else
                        {
                            A_Dialogo.DialogoError("Las horas de teoría y práctica no concuerdan");
                            //MessageBox.Show("Las horas de teoría y práctica no concuerdan.");
                        }
                            
                    }
                    else
                    {
                        if (HoraTeoría == HoraTeoríaA && HoraPráctica == HoraPrácticaA)
                        {
                            Guardar();
                        }
                        else
                        {
                            A_Dialogo.DialogoError("Las horas de teoría y práctica no concuerdan");
                            //MessageBox.Show("Las horas de teoría y práctica no concuerdan.");
                        }
                    }
                        
                }
                else
                {
                    A_Dialogo.DialogoError("No seleccionó todos los items o hay items mal puestos");
                    //MessageBox.Show("No seleccionó todos los items o hay items mal puestos.");
                }
                    
            }
            catch (Exception Ex)
            {
                A_Dialogo.DialogoError(Ex.ToString());
                //MessageBox.Show(Convert.ToString(Ex));
                Program.Evento = 0;
                Program.Cont = 0;
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
                Actualizar_Color();
                Borrar_Color();
            }
        }

        private void Check_2_Docentes_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_2_Docentes.Checked == true)
            {
                Check_1_Docentes.Checked = false;
                Seleccionar_Docente_Cod_Nom.Enabled = true;
                Seleccionar_Docente_Cod_Nom2.Enabled = true;
                Actualizar_Color();
                Borrar_Color();
            }
            else
            {
                Check_2_Docentes.Checked = false;
                Seleccionar_Docente_Cod_Nom.Enabled = true;
                Seleccionar_Docente_Cod_Nom2.Enabled = false;
                Check_1_Docentes.Checked = true;
                Actualizar_Color();
                Borrar_Color();
            }
        }

        private void Check_Nombre_Docente_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Nombre_Docente.Checked == true)
            {
                Check_Código_Docente.Checked = false;
                Seleccionar_Docente_Cod_Nom.DisplayMember = "NombreCompleto";
                Seleccionar_Docente_Cod_Nom2.DisplayMember = "NombreCompleto";
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
                Seleccionar_Docente_Cod_Nom.DisplayMember = "NombreCompleto";
                Seleccionar_Docente_Cod_Nom2.DisplayMember = "NombreCompleto";
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
                Recuperar_Horas_Docentes();
                DescontarHoras();
                Borrar_Color();
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
                Recuperar_Horas_Docentes();
                DescontarHoras();
                Borrar_Color();
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
                Recuperar_Horas_Docentes();
                DescontarHoras();
                Borrar_Color();
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

        public void Arreglar_Hora_Lunes()
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
                A_Dialogo.DialogoError("La hora de inicio no puede ser mayor o igual que la hora de finalización");
                //MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
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

        private void Hora_Inicio_Lunes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Lunes.Text) >= 7)
                Arreglar_Hora_Lunes();
            else
            {
                Hora_Inicio_Lunes.Value = new DateTime(2022, 1, 1, 7, 0, 0);
                Arreglar_Hora_Lunes();
                A_Dialogo.DialogoError("No hay horario que inicie antes de las 7:00");
                //MessageBox.Show("No hay horario que inicie antes de las 7:00");
            }
        }

        private void Hora_Fin_Lunes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Fin_Lunes.Text) <= 21 && Convert.ToInt32(Hora_Fin_Lunes.Text) >= 8)
                Arreglar_Hora_Lunes();
            else if (Convert.ToInt32(Hora_Fin_Lunes.Text) > 21)
            {
                Hora_Fin_Lunes.Value = new DateTime(2022, 1, 1, 21, 0, 0);
                Arreglar_Hora_Lunes();
                A_Dialogo.DialogoError("No hay horario que termine después de las 21:00");
                //MessageBox.Show("No hay horario que termine después de las 21:00");
            }
            else if (Convert.ToInt32(Hora_Fin_Lunes.Text) < 8)
            {
                Hora_Fin_Lunes.Value = new DateTime(2022, 1, 1, 8, 0, 0);
                Arreglar_Hora_Lunes();
            }
        }

        public void Arreglar_Hora_Martes()
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
                A_Dialogo.DialogoError("La hora de inicio no puede ser mayor o igual que la hora de finalización");
                //MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
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

        private void Hora_Inicio_Martes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Martes.Text) >= 7)
                Arreglar_Hora_Martes();
            else
            {
                Hora_Inicio_Martes.Value = new DateTime(2022, 1, 1, 7, 0, 0);
                Arreglar_Hora_Martes();
                A_Dialogo.DialogoError("No hay horario que inicie antes de las 7:00");
                //MessageBox.Show("No hay horario que inicie antes de las 7:00");
            }
        }

        private void Hora_Fin_Martes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Fin_Martes.Text) <= 21 && Convert.ToInt32(Hora_Fin_Martes.Text) >= 8)
                Arreglar_Hora_Martes();
            else if (Convert.ToInt32(Hora_Fin_Martes.Text) > 21)
            {
                Hora_Fin_Martes.Value = new DateTime(2022, 1, 1, 21, 0, 0);
                Arreglar_Hora_Martes();
                A_Dialogo.DialogoError("No hay horario que termine después de las 21:00");
                //MessageBox.Show("No hay horario que termine después de las 21:00");
            }
            else if (Convert.ToInt32(Hora_Fin_Martes.Text) < 8)
            {
                Hora_Fin_Martes.Value = new DateTime(2022, 1, 1, 8, 0, 0);
                Arreglar_Hora_Martes();
            }
        }

        public void Arreglar_Hora_Miércoles()
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
                A_Dialogo.DialogoError("La hora de inicio no puede ser mayor o igual que la hora de finalización");
                //MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
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

        private void Hora_Inicio_Miércoles_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Miércoles.Text) >= 7)
                Arreglar_Hora_Miércoles();
            else
            {
                Hora_Inicio_Miércoles.Value = new DateTime(2022, 1, 1, 7, 0, 0);
                Arreglar_Hora_Miércoles();
                A_Dialogo.DialogoError("No hay horario que inicie antes de las 7:00");
                //MessageBox.Show("No hay horario que inicie antes de las 7:00");
            }
        }

        private void Hora_Fin_Miércoles_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Fin_Miércoles.Text) <= 21 && Convert.ToInt32(Hora_Fin_Miércoles.Text) >= 8)
                Arreglar_Hora_Miércoles();
            else if (Convert.ToInt32(Hora_Fin_Miércoles.Text) > 21)
            {
                Hora_Fin_Miércoles.Value = new DateTime(2022, 1, 1, 21, 0, 0);
                Arreglar_Hora_Miércoles();
                A_Dialogo.DialogoError("No hay horario que termine después de las 21:00");
                //MessageBox.Show("No hay horario que termine después de las 21:00");
            }
            else if (Convert.ToInt32(Hora_Fin_Miércoles.Text) < 8)
            {
                Hora_Fin_Miércoles.Value = new DateTime(2022, 1, 1, 8, 0, 0);
                Arreglar_Hora_Miércoles();
            }
        }

        public void Arreglar_Hora_Jueves()
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
                A_Dialogo.DialogoError("La hora de inicio no puede ser mayor o igual que la hora de finalización");
                //MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
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

        private void Hora_Inicio_Jueves_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Jueves.Text) >= 7)
                Arreglar_Hora_Jueves();
            else
            {
                Hora_Inicio_Jueves.Value = new DateTime(2022, 1, 1, 7, 0, 0);
                Arreglar_Hora_Jueves();
                A_Dialogo.DialogoError("No hay horario que inicie antes de las 7:00");
                //MessageBox.Show("No hay horario que inicie antes de las 7:00");
            }
        }

        private void Hora_Fin_Jueves_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Fin_Jueves.Text) <= 21 && Convert.ToInt32(Hora_Fin_Jueves.Text) >= 8)
                Arreglar_Hora_Jueves();
            else if (Convert.ToInt32(Hora_Fin_Jueves.Text) > 21)
            {
                Hora_Fin_Jueves.Value = new DateTime(2022, 1, 1, 21, 0, 0);
                Arreglar_Hora_Jueves();
                A_Dialogo.DialogoError("No hay horario que termine después de las 21:00");
                //MessageBox.Show("No hay horario que termine después de las 21:00");
            }
            else if (Convert.ToInt32(Hora_Fin_Jueves.Text) < 8)
            {
                Hora_Fin_Jueves.Value = new DateTime(2022, 1, 1, 8, 0, 0);
                Arreglar_Hora_Jueves();
            }
        }

        public void Arreglar_Hora_Viernes()
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
                A_Dialogo.DialogoError("La hora de inicio no puede ser mayor o igual que la hora de finalización");
                //MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
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

        private void Hora_Inicio_Viernes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Viernes.Text) >= 7)
                Arreglar_Hora_Viernes();
            else
            {
                Hora_Inicio_Viernes.Value = new DateTime(2022, 1, 1, 7, 0, 0);
                Arreglar_Hora_Viernes();
                A_Dialogo.DialogoError("No hay horario que inicie antes de las 7:00");
                //MessageBox.Show("No hay horario que inicie antes de las 7:00");
            }
        }

        private void Hora_Fin_Viernes_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Fin_Viernes.Text) <= 21 && Convert.ToInt32(Hora_Fin_Viernes.Text) >= 8)
                Arreglar_Hora_Viernes();
            else if (Convert.ToInt32(Hora_Fin_Viernes.Text) > 21)
            {
                Hora_Fin_Viernes.Value = new DateTime(2022, 1, 1, 21, 0, 0);
                Arreglar_Hora_Viernes();
                A_Dialogo.DialogoError("No hay horario que termine después de las 21:00");
                //MessageBox.Show("No hay horario que termine después de las 21:00");
            }
            else if (Convert.ToInt32(Hora_Fin_Viernes.Text) < 8)
            {
                Hora_Fin_Viernes.Value = new DateTime(2022, 1, 1, 8, 0, 0);
                Arreglar_Hora_Viernes();
            }
        }

        public void Arreglar_Hora_Sábado()
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
                A_Dialogo.DialogoError("La hora de inicio no puede ser mayor o igual que la hora de finalización");
                //MessageBox.Show("La hora de inicio no puede ser mayor o igual que la hora de finalización");
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

        private void Hora_Inicio_Sábado_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Inicio_Sábado.Text) >= 7)
                Arreglar_Hora_Sábado();
            else
            {
                Hora_Inicio_Sábado.Value = new DateTime(2022, 1, 1, 7, 0, 0);
                Arreglar_Hora_Sábado();
                A_Dialogo.DialogoError("No hay horario que inicie antes de las 7:00");
                //MessageBox.Show("No hay horario que inicie antes de las 7:00");
            }
        }

        private void Hora_Fin_Sábado_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Hora_Fin_Sábado.Text) <= 21 && Convert.ToInt32(Hora_Fin_Sábado.Text) >= 8)
                Arreglar_Hora_Sábado();
            else if (Convert.ToInt32(Hora_Fin_Sábado.Text) > 21)
            {
                Hora_Fin_Sábado.Value = new DateTime(2022, 1, 1, 21, 0, 0);
                Arreglar_Hora_Sábado();
                A_Dialogo.DialogoError("No hay horario que termine después de las 21:00");
                //MessageBox.Show("No hay horario que termine después de las 21:00");
            }
            else if (Convert.ToInt32(Hora_Fin_Sábado.Text) < 8)
            {
                Hora_Fin_Sábado.Value = new DateTime(2022, 1, 1, 8, 0, 0);
                Arreglar_Hora_Sábado();
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

        private void Seleccionar_Docente_Cod_Nom_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Check_Código_Docente.Checked == true)
                    CódigoDocente1 = Seleccionar_Docente_Cod_Nom.Text;
                else
                    CódigoDocente1 = Seleccionar_Docente_Cod_Nom.SelectedValue.ToString();
                Recuperar_Horas_Docentes();
                DescontarHoras();
                Actualizar_Color();
                Borrar_Color();
            }
            catch
            {
                //Falta ver cuál es el problema...
            }
        }

        private void Seleccionar_Docente_Cod_Nom2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Check_Código_Docente.Checked == true)
                    CódigoDocente2 = Seleccionar_Docente_Cod_Nom2.Text;
                else
                    CódigoDocente2 = Seleccionar_Docente_Cod_Nom2.SelectedValue.ToString();
                Recuperar_Horas_Docentes();
                DescontarHoras();
                Actualizar_Color();
                Borrar_Color();
            }
            catch
            {
                //Falta ver cuál es el problema...
            }
        }

        private void Seleccionar_Asignatura_Cod_Nom_SelectedIndexChanged_1(object sender, EventArgs e)
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
                Recuperar_Horas_Docentes();
                DescontarHoras();
                Borrar_Color();
            }
            catch
            {
                //Falta ver cuál es el problema...
            }
        }

        private void Seleccionar_Semestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recuperar_Horas_Docentes();
            DescontarHoras();
            Actualizar_Color();
            Borrar_Color();
        }

        public void Buscar(string CS, string CA, string EP, string G)
        {
            string CodDocente, Día, Tipo, HI, HF, Aula, Modalidad;
            CódigoAsignaturaA = CA;
            GrupoA = G;
            EscuelaPA = EP;
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
            Actualizar_Color();
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
                Seleccionar_EP.SelectedValue = EP;
                lblSemestre.Text = CodSemestre;
                for (int i = 0; i < T1.Rows.Count; i++)
                {
                    Tipo = T1.Rows[i]["Tipo"].ToString();
                    TipoT[i] = Tipo;
                    CodDocente = T1.Rows[i]["CodDocente"].ToString();
                    DocenteT[i] = CodDocente;
                    if (CodDocenteP == CodDocente)
                    {
                        CódigoD1A = CodDocenteP;
                        if (Tipo == "T")
                        {
                            Seleccionar_Docente_Cod_Nom.SelectedValue = CodDocenteP;
                            Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        }
                        else
                        {
                            Seleccionar_Docente_Cod_Nom2.SelectedValue = CodDocenteP;
                            Seleccionar_Docente_Cod_Nom2.DisplayMember = "Nombre";
                        }
                    }
                    else
                    {
                        CódigoD1A = CodDocente;
                        Check_2_Docentes.Checked = true;
                        if (Tipo == "T")
                        {
                            Seleccionar_Docente_Cod_Nom.SelectedValue = CodDocente;
                            Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        }
                        else
                        {
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
                        Seleccionar_Docente_Cod_Nom.SelectedValue = DocenteT[0];
                        Seleccionar_Docente_Cod_Nom2.SelectedValue = DocenteT[1];
                        Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        Seleccionar_Docente_Cod_Nom2.DisplayMember = "Nombre";
                        Seleccionar_Docente_Cod_Nom2.Enabled = true;
                    }
                    else
                    {
                        Check_1_Docentes.Checked = true;
                        Seleccionar_Docente_Cod_Nom.SelectedValue = DocenteT[0];
                        Seleccionar_Docente_Cod_Nom.DisplayMember = "Nombre";
                        Seleccionar_Docente_Cod_Nom2.Enabled = false;
                    }
                }
            }
            Check_Código_Docente.Checked = true;
            Check_Nombre_Docente.Checked = true;
        }

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
            Program.Cont = 0;
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
            DescontarHoras();
        }

        public void DescontarHoras()
        {
            if (CódigoD1A == CódigoDocente1 && CódigoSemestreA == CodSemestre)
            {
                HD1 = 0;
                DataTable T1 = N_HorarioAsignatura.HorasDocenteAsignaturaHorarioAsignatura(CódigoDocente1, CodSemestre, CódigoAsignaturaA, GrupoA);
                for (int i = 0; i < T1.Rows.Count; i++)
                {
                    HD1 = HD1 + Convert.ToInt32(T1.Rows[i]["HorasTeoria"].ToString());
                    HD1 = HD1 + Convert.ToInt32(T1.Rows[i]["HorasPractica"].ToString());
                }
                HTD1 = HTD1 - HD1;
            }
            if (CódigoD2A == CódigoDocente2 && CódigoSemestreA == CodSemestre)
            {
                HD2 = 0;
                DataTable T1 = N_HorarioAsignatura.HorasDocenteAsignaturaHorarioAsignatura(CódigoDocente2, CodSemestre, CódigoAsignaturaA, GrupoA);
                for (int i = 0; i < T1.Rows.Count; i++)
                {
                    HD2 = HD2 + Convert.ToInt32(T1.Rows[i]["HorasTeoria"].ToString());
                    HD2 = HD2 + Convert.ToInt32(T1.Rows[i]["HorasPractica"].ToString());
                }
                HTD2 = HTD2 - HD2;
            }
        }

        public void Designar(string Día, string HoraInicio, string HoraFin, int Docente)
        {
            int[] Horas = { 0, 0, 0, 0, 0 };
            Horas[0] = Convert.ToInt32(HoraInicio);
            for (int i = 1; i < 5; i++)
            {
                if (Convert.ToInt32(HoraInicio) + i <= Convert.ToInt32(HoraFin))
                    Horas[i] = Convert.ToInt32(HoraInicio) + i;
            }

            for (int i = 0; i < 4; i++)
            {
                if (Horas[i] != 0 && Horas[i + 1] != 0)
                {
                    if (Docente == 1)
                        Colorear1(Día, Horas[i], Horas[i + 1]);
                    else
                        Colorear2(Día, Horas[i], Horas[i + 1]);
                }
            }
        }

        public void Designar2(string Día, string HoraInicio, string HoraFin)
        {
            int[] Horas = { 0, 0, 0, 0, 0 };
            Horas[0] = Convert.ToInt32(HoraInicio);
            for (int i = 1; i < 5; i++)
            {
                if (Convert.ToInt32(HoraInicio) + i <= Convert.ToInt32(HoraFin))
                    Horas[i] = Convert.ToInt32(HoraInicio) + i;
            }

            for (int i = 0; i < 4; i++)
            {
                if (Horas[i] != 0 && Horas[i + 1] != 0)
                {
                    Borrar(Día, Horas[i], Horas[i + 1]);
                }
            }
        }

        public void Limpiar_Colores()
        {
            //Lunes
            L7_8.BackColor = Color.White;
            L8_9.BackColor = Color.White;
            L9_10.BackColor = Color.White;
            L10_11.BackColor = Color.White;
            L11_12.BackColor = Color.White;
            L12_13.BackColor = Color.White;
            L13_14.BackColor = Color.White;
            L14_15.BackColor = Color.White;
            L15_16.BackColor = Color.White;
            L16_17.BackColor = Color.White;
            L17_18.BackColor = Color.White;
            L18_19.BackColor = Color.White;
            L19_20.BackColor = Color.White;
            L20_21.BackColor = Color.White;
            //Martes
            M7_8.BackColor = Color.White;
            M8_9.BackColor = Color.White;
            M9_10.BackColor = Color.White;
            M10_11.BackColor = Color.White;
            M11_12.BackColor = Color.White;
            M12_13.BackColor = Color.White;
            M13_14.BackColor = Color.White;
            M14_15.BackColor = Color.White;
            M15_16.BackColor = Color.White;
            M16_17.BackColor = Color.White;
            M17_18.BackColor = Color.White;
            M18_19.BackColor = Color.White;
            M19_20.BackColor = Color.White;
            M20_21.BackColor = Color.White;
            //Miércoles
            Mi7_8.BackColor = Color.White;
            Mi8_9.BackColor = Color.White;
            Mi9_10.BackColor = Color.White;
            Mi10_11.BackColor = Color.White;
            Mi11_12.BackColor = Color.White;
            Mi12_13.BackColor = Color.White;
            Mi13_14.BackColor = Color.White;
            Mi14_15.BackColor = Color.White;
            Mi15_16.BackColor = Color.White;
            Mi16_17.BackColor = Color.White;
            Mi17_18.BackColor = Color.White;
            Mi18_19.BackColor = Color.White;
            Mi19_20.BackColor = Color.White;
            Mi20_21.BackColor = Color.White;
            //Jueves
            J7_8.BackColor = Color.White;
            J8_9.BackColor = Color.White;
            J9_10.BackColor = Color.White;
            J10_11.BackColor = Color.White;
            J11_12.BackColor = Color.White;
            J12_13.BackColor = Color.White;
            J13_14.BackColor = Color.White;
            J14_15.BackColor = Color.White;
            J15_16.BackColor = Color.White;
            J16_17.BackColor = Color.White;
            J17_18.BackColor = Color.White;
            J18_19.BackColor = Color.White;
            J19_20.BackColor = Color.White;
            J20_21.BackColor = Color.White;
            //Viernes
            V7_8.BackColor = Color.White;
            V8_9.BackColor = Color.White;
            V9_10.BackColor = Color.White;
            V10_11.BackColor = Color.White;
            V11_12.BackColor = Color.White;
            V12_13.BackColor = Color.White;
            V13_14.BackColor = Color.White;
            V14_15.BackColor = Color.White;
            V15_16.BackColor = Color.White;
            V16_17.BackColor = Color.White;
            V17_18.BackColor = Color.White;
            V18_19.BackColor = Color.White;
            V19_20.BackColor = Color.White;
            V20_21.BackColor = Color.White;
            //Sábado
            S7_8.BackColor = Color.White;
            S8_9.BackColor = Color.White;
            S9_10.BackColor = Color.White;
            S10_11.BackColor = Color.White;
            S11_12.BackColor = Color.White;
            S12_13.BackColor = Color.White;
            S13_14.BackColor = Color.White;
            S14_15.BackColor = Color.White;
            S15_16.BackColor = Color.White;
            S16_17.BackColor = Color.White;
            S17_18.BackColor = Color.White;
            S18_19.BackColor = Color.White;
            S19_20.BackColor = Color.White;
            S20_21.BackColor = Color.White;
        }

        public void Borrar(string Día, int HoraInicio, int HoraFin)
        {
            if (Día == "LU")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    L7_8.BackColor = Color.White;
                else if (HoraInicio == 8 && HoraFin == 9)
                    L8_9.BackColor = Color.White;
                else if (HoraInicio == 9 && HoraFin == 10)
                    L9_10.BackColor = Color.White;
                else if (HoraInicio == 10 && HoraFin == 11)
                    L10_11.BackColor = Color.White;
                else if (HoraInicio == 11 && HoraFin == 12)
                    L11_12.BackColor = Color.White;
                else if (HoraInicio == 12 && HoraFin == 13)
                    L12_13.BackColor = Color.White;
                else if (HoraInicio == 13 && HoraFin == 14)
                    L13_14.BackColor = Color.White;
                else if (HoraInicio == 14 && HoraFin == 15)
                    L14_15.BackColor = Color.White;
                else if (HoraInicio == 15 && HoraFin == 16)
                    L15_16.BackColor = Color.White;
                else if (HoraInicio == 16 && HoraFin == 17)
                    L16_17.BackColor = Color.White;
                else if (HoraInicio == 17 && HoraFin == 18)
                    L17_18.BackColor = Color.White;
                else if (HoraInicio == 18 && HoraFin == 19)
                    L18_19.BackColor = Color.White;
                else if (HoraInicio == 19 && HoraFin == 20)
                    L19_20.BackColor = Color.White;
                else if (HoraInicio == 20 && HoraFin == 21)
                    L20_21.BackColor = Color.White;
            }
            else if (Día == "MA")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    M7_8.BackColor = Color.White;
                else if (HoraInicio == 8 && HoraFin == 9)
                    M8_9.BackColor = Color.White;
                else if (HoraInicio == 9 && HoraFin == 10)
                    M9_10.BackColor = Color.White;
                else if (HoraInicio == 10 && HoraFin == 11)
                    M10_11.BackColor = Color.White;
                else if (HoraInicio == 11 && HoraFin == 12)
                    M11_12.BackColor = Color.White;
                else if (HoraInicio == 12 && HoraFin == 13)
                    M12_13.BackColor = Color.White;
                else if (HoraInicio == 13 && HoraFin == 14)
                    M13_14.BackColor = Color.White;
                else if (HoraInicio == 14 && HoraFin == 15)
                    M14_15.BackColor = Color.White;
                else if (HoraInicio == 15 && HoraFin == 16)
                    M15_16.BackColor = Color.White;
                else if (HoraInicio == 16 && HoraFin == 17)
                    M16_17.BackColor = Color.White;
                else if (HoraInicio == 17 && HoraFin == 18)
                    M17_18.BackColor = Color.White;
                else if (HoraInicio == 18 && HoraFin == 19)
                    M18_19.BackColor = Color.White;
                else if (HoraInicio == 19 && HoraFin == 20)
                    M19_20.BackColor = Color.White;
                else if (HoraInicio == 20 && HoraFin == 21)
                    M20_21.BackColor = Color.White;
            }
            else if (Día == "MI")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    Mi7_8.BackColor = Color.White;
                else if (HoraInicio == 8 && HoraFin == 9)
                    Mi8_9.BackColor = Color.White;
                else if (HoraInicio == 9 && HoraFin == 10)
                    Mi9_10.BackColor = Color.White;
                else if (HoraInicio == 10 && HoraFin == 11)
                    Mi10_11.BackColor = Color.White;
                else if (HoraInicio == 11 && HoraFin == 12)
                    Mi11_12.BackColor = Color.White;
                else if (HoraInicio == 12 && HoraFin == 13)
                    Mi12_13.BackColor = Color.White;
                else if (HoraInicio == 13 && HoraFin == 14)
                    Mi13_14.BackColor = Color.White;
                else if (HoraInicio == 14 && HoraFin == 15)
                    Mi14_15.BackColor = Color.White;
                else if (HoraInicio == 15 && HoraFin == 16)
                    Mi15_16.BackColor = Color.White;
                else if (HoraInicio == 16 && HoraFin == 17)
                    Mi16_17.BackColor = Color.White;
                else if (HoraInicio == 17 && HoraFin == 18)
                    Mi17_18.BackColor = Color.White;
                else if (HoraInicio == 18 && HoraFin == 19)
                    Mi18_19.BackColor = Color.White;
                else if (HoraInicio == 19 && HoraFin == 20)
                    Mi19_20.BackColor = Color.White;
                else if (HoraInicio == 20 && HoraFin == 21)
                    Mi20_21.BackColor = Color.White;
            }
            else if (Día == "JU")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    J7_8.BackColor = Color.White;
                else if (HoraInicio == 8 && HoraFin == 9)
                    J8_9.BackColor = Color.White;
                else if (HoraInicio == 9 && HoraFin == 10)
                    J9_10.BackColor = Color.White;
                else if (HoraInicio == 10 && HoraFin == 11)
                    J10_11.BackColor = Color.White;
                else if (HoraInicio == 11 && HoraFin == 12)
                    J11_12.BackColor = Color.White;
                else if (HoraInicio == 12 && HoraFin == 13)
                    J12_13.BackColor = Color.White;
                else if (HoraInicio == 13 && HoraFin == 14)
                    J13_14.BackColor = Color.White;
                else if (HoraInicio == 14 && HoraFin == 15)
                    J14_15.BackColor = Color.White;
                else if (HoraInicio == 15 && HoraFin == 16)
                    J15_16.BackColor = Color.White;
                else if (HoraInicio == 16 && HoraFin == 17)
                    J16_17.BackColor = Color.White;
                else if (HoraInicio == 17 && HoraFin == 18)
                    J17_18.BackColor = Color.White;
                else if (HoraInicio == 18 && HoraFin == 19)
                    J18_19.BackColor = Color.White;
                else if (HoraInicio == 19 && HoraFin == 20)
                    J19_20.BackColor = Color.White;
                else if (HoraInicio == 20 && HoraFin == 21)
                    J20_21.BackColor = Color.White;
            }
            else if (Día == "VI")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    V7_8.BackColor = Color.White;
                else if (HoraInicio == 8 && HoraFin == 9)
                    V8_9.BackColor = Color.White;
                else if (HoraInicio == 9 && HoraFin == 10)
                    V9_10.BackColor = Color.White;
                else if (HoraInicio == 10 && HoraFin == 11)
                    V10_11.BackColor = Color.White;
                else if (HoraInicio == 11 && HoraFin == 12)
                    V11_12.BackColor = Color.White;
                else if (HoraInicio == 12 && HoraFin == 13)
                    V12_13.BackColor = Color.White;
                else if (HoraInicio == 13 && HoraFin == 14)
                    V13_14.BackColor = Color.White;
                else if (HoraInicio == 14 && HoraFin == 15)
                    V14_15.BackColor = Color.White;
                else if (HoraInicio == 15 && HoraFin == 16)
                    V15_16.BackColor = Color.White;
                else if (HoraInicio == 16 && HoraFin == 17)
                    V16_17.BackColor = Color.White;
                else if (HoraInicio == 17 && HoraFin == 18)
                    V17_18.BackColor = Color.White;
                else if (HoraInicio == 18 && HoraFin == 19)
                    V18_19.BackColor = Color.White;
                else if (HoraInicio == 19 && HoraFin == 20)
                    V19_20.BackColor = Color.White;
                else if (HoraInicio == 20 && HoraFin == 21)
                    V20_21.BackColor = Color.White;
            }
            else if (Día == "SA")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    S7_8.BackColor = Color.White;
                else if (HoraInicio == 8 && HoraFin == 9)
                    S8_9.BackColor = Color.White;
                else if (HoraInicio == 9 && HoraFin == 10)
                    S9_10.BackColor = Color.White;
                else if (HoraInicio == 10 && HoraFin == 11)
                    S10_11.BackColor = Color.White;
                else if (HoraInicio == 11 && HoraFin == 12)
                    S11_12.BackColor = Color.White;
                else if (HoraInicio == 12 && HoraFin == 13)
                    S12_13.BackColor = Color.White;
                else if (HoraInicio == 13 && HoraFin == 14)
                    S13_14.BackColor = Color.White;
                else if (HoraInicio == 14 && HoraFin == 15)
                    S14_15.BackColor = Color.White;
                else if (HoraInicio == 15 && HoraFin == 16)
                    S15_16.BackColor = Color.White;
                else if (HoraInicio == 16 && HoraFin == 17)
                    S16_17.BackColor = Color.White;
                else if (HoraInicio == 17 && HoraFin == 18)
                    S17_18.BackColor = Color.White;
                else if (HoraInicio == 18 && HoraFin == 19)
                    S18_19.BackColor = Color.White;
                else if (HoraInicio == 19 && HoraFin == 20)
                    S19_20.BackColor = Color.White;
                else if (HoraInicio == 20 && HoraFin == 21)
                    S20_21.BackColor = Color.White;
            }
        }

        public void Colorear1(string Día, int HoraInicio, int HoraFin)
        {
            if (Día == "LU")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    L7_8.BackColor = Color.LawnGreen;
                else if (HoraInicio == 8 && HoraFin == 9)
                    L8_9.BackColor = Color.LawnGreen;
                else if (HoraInicio == 9 && HoraFin == 10)
                    L9_10.BackColor = Color.LawnGreen;
                else if (HoraInicio == 10 && HoraFin == 11)
                    L10_11.BackColor = Color.LawnGreen;
                else if (HoraInicio == 11 && HoraFin == 12)
                    L11_12.BackColor = Color.LawnGreen;
                else if (HoraInicio == 12 && HoraFin == 13)
                    L12_13.BackColor = Color.LawnGreen;
                else if (HoraInicio == 13 && HoraFin == 14)
                    L13_14.BackColor = Color.LawnGreen;
                else if (HoraInicio == 14 && HoraFin == 15)
                    L14_15.BackColor = Color.LawnGreen;
                else if (HoraInicio == 15 && HoraFin == 16)
                    L15_16.BackColor = Color.LawnGreen;
                else if (HoraInicio == 16 && HoraFin == 17)
                    L16_17.BackColor = Color.LawnGreen;
                else if (HoraInicio == 17 && HoraFin == 18)
                    L17_18.BackColor = Color.LawnGreen;
                else if (HoraInicio == 18 && HoraFin == 19)
                    L18_19.BackColor = Color.LawnGreen;
                else if (HoraInicio == 19 && HoraFin == 20)
                    L19_20.BackColor = Color.LawnGreen;
                else if (HoraInicio == 20 && HoraFin == 21)
                    L20_21.BackColor = Color.LawnGreen;
            }
            else if (Día == "MA")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    M7_8.BackColor = Color.LawnGreen;
                else if (HoraInicio == 8 && HoraFin == 9)
                    M8_9.BackColor = Color.LawnGreen;
                else if (HoraInicio == 9 && HoraFin == 10)
                    M9_10.BackColor = Color.LawnGreen;
                else if (HoraInicio == 10 && HoraFin == 11)
                    M10_11.BackColor = Color.LawnGreen;
                else if (HoraInicio == 11 && HoraFin == 12)
                    M11_12.BackColor = Color.LawnGreen;
                else if (HoraInicio == 12 && HoraFin == 13)
                    M12_13.BackColor = Color.LawnGreen;
                else if (HoraInicio == 13 && HoraFin == 14)
                    M13_14.BackColor = Color.LawnGreen;
                else if (HoraInicio == 14 && HoraFin == 15)
                    M14_15.BackColor = Color.LawnGreen;
                else if (HoraInicio == 15 && HoraFin == 16)
                    M15_16.BackColor = Color.LawnGreen;
                else if (HoraInicio == 16 && HoraFin == 17)
                    M16_17.BackColor = Color.LawnGreen;
                else if (HoraInicio == 17 && HoraFin == 18)
                    M17_18.BackColor = Color.LawnGreen;
                else if (HoraInicio == 18 && HoraFin == 19)
                    M18_19.BackColor = Color.LawnGreen;
                else if (HoraInicio == 19 && HoraFin == 20)
                    M19_20.BackColor = Color.LawnGreen;
                else if (HoraInicio == 20 && HoraFin == 21)
                    M20_21.BackColor = Color.LawnGreen;
            }
            else if (Día == "MI")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    Mi7_8.BackColor = Color.LawnGreen;
                else if (HoraInicio == 8 && HoraFin == 9)
                    Mi8_9.BackColor = Color.LawnGreen;
                else if (HoraInicio == 9 && HoraFin == 10)
                    Mi9_10.BackColor = Color.LawnGreen;
                else if (HoraInicio == 10 && HoraFin == 11)
                    Mi10_11.BackColor = Color.LawnGreen;
                else if (HoraInicio == 11 && HoraFin == 12)
                    Mi11_12.BackColor = Color.LawnGreen;
                else if (HoraInicio == 12 && HoraFin == 13)
                    Mi12_13.BackColor = Color.LawnGreen;
                else if (HoraInicio == 13 && HoraFin == 14)
                    Mi13_14.BackColor = Color.LawnGreen;
                else if (HoraInicio == 14 && HoraFin == 15)
                    Mi14_15.BackColor = Color.LawnGreen;
                else if (HoraInicio == 15 && HoraFin == 16)
                    Mi15_16.BackColor = Color.LawnGreen;
                else if (HoraInicio == 16 && HoraFin == 17)
                    Mi16_17.BackColor = Color.LawnGreen;
                else if (HoraInicio == 17 && HoraFin == 18)
                    Mi17_18.BackColor = Color.LawnGreen;
                else if (HoraInicio == 18 && HoraFin == 19)
                    Mi18_19.BackColor = Color.LawnGreen;
                else if (HoraInicio == 19 && HoraFin == 20)
                    Mi19_20.BackColor = Color.LawnGreen;
                else if (HoraInicio == 20 && HoraFin == 21)
                    Mi20_21.BackColor = Color.LawnGreen;
            }
            else if (Día == "JU")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    J7_8.BackColor = Color.LawnGreen;
                else if (HoraInicio == 8 && HoraFin == 9)
                    J8_9.BackColor = Color.LawnGreen;
                else if (HoraInicio == 9 && HoraFin == 10)
                    J9_10.BackColor = Color.LawnGreen;
                else if (HoraInicio == 10 && HoraFin == 11)
                    J10_11.BackColor = Color.LawnGreen;
                else if (HoraInicio == 11 && HoraFin == 12)
                    J11_12.BackColor = Color.LawnGreen;
                else if (HoraInicio == 12 && HoraFin == 13)
                    J12_13.BackColor = Color.LawnGreen;
                else if (HoraInicio == 13 && HoraFin == 14)
                    J13_14.BackColor = Color.LawnGreen;
                else if (HoraInicio == 14 && HoraFin == 15)
                    J14_15.BackColor = Color.LawnGreen;
                else if (HoraInicio == 15 && HoraFin == 16)
                    J15_16.BackColor = Color.LawnGreen;
                else if (HoraInicio == 16 && HoraFin == 17)
                    J16_17.BackColor = Color.LawnGreen;
                else if (HoraInicio == 17 && HoraFin == 18)
                    J17_18.BackColor = Color.LawnGreen;
                else if (HoraInicio == 18 && HoraFin == 19)
                    J18_19.BackColor = Color.LawnGreen;
                else if (HoraInicio == 19 && HoraFin == 20)
                    J19_20.BackColor = Color.LawnGreen;
                else if (HoraInicio == 20 && HoraFin == 21)
                    J20_21.BackColor = Color.LawnGreen;
            }
            else if (Día == "VI")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    V7_8.BackColor = Color.LawnGreen;
                else if (HoraInicio == 8 && HoraFin == 9)
                    V8_9.BackColor = Color.LawnGreen;
                else if (HoraInicio == 9 && HoraFin == 10)
                    V9_10.BackColor = Color.LawnGreen;
                else if (HoraInicio == 10 && HoraFin == 11)
                    V10_11.BackColor = Color.LawnGreen;
                else if (HoraInicio == 11 && HoraFin == 12)
                    V11_12.BackColor = Color.LawnGreen;
                else if (HoraInicio == 12 && HoraFin == 13)
                    V12_13.BackColor = Color.LawnGreen;
                else if (HoraInicio == 13 && HoraFin == 14)
                    V13_14.BackColor = Color.LawnGreen;
                else if (HoraInicio == 14 && HoraFin == 15)
                    V14_15.BackColor = Color.LawnGreen;
                else if (HoraInicio == 15 && HoraFin == 16)
                    V15_16.BackColor = Color.LawnGreen;
                else if (HoraInicio == 16 && HoraFin == 17)
                    V16_17.BackColor = Color.LawnGreen;
                else if (HoraInicio == 17 && HoraFin == 18)
                    V17_18.BackColor = Color.LawnGreen;
                else if (HoraInicio == 18 && HoraFin == 19)
                    V18_19.BackColor = Color.LawnGreen;
                else if (HoraInicio == 19 && HoraFin == 20)
                    V19_20.BackColor = Color.LawnGreen;
                else if (HoraInicio == 20 && HoraFin == 21)
                    V20_21.BackColor = Color.LawnGreen;
            }
            else if (Día == "SA")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                    S7_8.BackColor = Color.LawnGreen;
                else if (HoraInicio == 8 && HoraFin == 9)
                    S8_9.BackColor = Color.LawnGreen;
                else if (HoraInicio == 9 && HoraFin == 10)
                    S9_10.BackColor = Color.LawnGreen;
                else if (HoraInicio == 10 && HoraFin == 11)
                    S10_11.BackColor = Color.LawnGreen;
                else if (HoraInicio == 11 && HoraFin == 12)
                    S11_12.BackColor = Color.LawnGreen;
                else if (HoraInicio == 12 && HoraFin == 13)
                    S12_13.BackColor = Color.LawnGreen;
                else if (HoraInicio == 13 && HoraFin == 14)
                    S13_14.BackColor = Color.LawnGreen;
                else if (HoraInicio == 14 && HoraFin == 15)
                    S14_15.BackColor = Color.LawnGreen;
                else if (HoraInicio == 15 && HoraFin == 16)
                    S15_16.BackColor = Color.LawnGreen;
                else if (HoraInicio == 16 && HoraFin == 17)
                    S16_17.BackColor = Color.LawnGreen;
                else if (HoraInicio == 17 && HoraFin == 18)
                    S17_18.BackColor = Color.LawnGreen;
                else if (HoraInicio == 18 && HoraFin == 19)
                    S18_19.BackColor = Color.LawnGreen;
                else if (HoraInicio == 19 && HoraFin == 20)
                    S19_20.BackColor = Color.LawnGreen;
                else if (HoraInicio == 20 && HoraFin == 21)
                    S20_21.BackColor = Color.LawnGreen;
            }
        }

        public void Colorear2(string Día, int HoraInicio, int HoraFin)
        {
            if (Día == "LU")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                {
                    if (L7_8.BackColor == Color.White)
                        L7_8.BackColor = Color.Orange;
                    else
                        L7_8.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 8 && HoraFin == 9)
                {
                    if (L8_9.BackColor == Color.White)
                        L8_9.BackColor = Color.Orange;
                    else
                        L8_9.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 9 && HoraFin == 10)
                {
                    if (L9_10.BackColor == Color.White)
                        L9_10.BackColor = Color.Orange;
                    else
                        L9_10.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 10 && HoraFin == 11)
                {
                    if (L10_11.BackColor == Color.White)
                        L10_11.BackColor = Color.Orange;
                    else
                        L10_11.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 11 && HoraFin == 12)
                {
                    if (L11_12.BackColor == Color.White)
                        L11_12.BackColor = Color.Orange;
                    else
                        L11_12.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 12 && HoraFin == 13)
                {
                    if (L12_13.BackColor == Color.White)
                        L12_13.BackColor = Color.Orange;
                    else
                        L12_13.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 13 && HoraFin == 14)
                {
                    if (L13_14.BackColor == Color.White)
                        L13_14.BackColor = Color.Orange;
                    else
                        L13_14.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 14 && HoraFin == 15)
                {
                    if (L14_15.BackColor == Color.White)
                        L14_15.BackColor = Color.Orange;
                    else
                        L14_15.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 15 && HoraFin == 16)
                {
                    if (L15_16.BackColor == Color.White)
                        L15_16.BackColor = Color.Orange;
                    else
                        L15_16.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 16 && HoraFin == 17)
                {
                    if (L16_17.BackColor == Color.White)
                        L16_17.BackColor = Color.Orange;
                    else
                        L16_17.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 17 && HoraFin == 18)
                {
                    if (L17_18.BackColor == Color.White)
                        L17_18.BackColor = Color.Orange;
                    else
                        L17_18.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 18 && HoraFin == 19)
                {
                    if (L18_19.BackColor == Color.White)
                        L18_19.BackColor = Color.Orange;
                    else
                        L18_19.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 19 && HoraFin == 20)
                {
                    if (L19_20.BackColor == Color.White)
                        L19_20.BackColor = Color.Orange;
                    else
                        L19_20.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 20 && HoraFin == 21)
                {
                    if (L20_21.BackColor == Color.White)
                        L20_21.BackColor = Color.Orange;
                    else
                        L20_21.BackColor = Color.DarkViolet;
                }
            }
            else if (Día == "MA")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                {
                    if (M7_8.BackColor == Color.White)
                        M7_8.BackColor = Color.Orange;
                    else
                        M7_8.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 8 && HoraFin == 9)
                {
                    if (M8_9.BackColor == Color.White)
                        M8_9.BackColor = Color.Orange;
                    else
                        M8_9.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 9 && HoraFin == 10)
                {
                    if (M9_10.BackColor == Color.White)
                        M9_10.BackColor = Color.Orange;
                    else
                        M9_10.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 10 && HoraFin == 11)
                {
                    if (M10_11.BackColor == Color.White)
                        M10_11.BackColor = Color.Orange;
                    else
                        M10_11.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 11 && HoraFin == 12)
                {
                    if (M11_12.BackColor == Color.White)
                        M11_12.BackColor = Color.Orange;
                    else
                        M11_12.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 12 && HoraFin == 13)
                {
                    if (M12_13.BackColor == Color.White)
                        M12_13.BackColor = Color.Orange;
                    else
                        M12_13.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 13 && HoraFin == 14)
                {
                    if (M13_14.BackColor == Color.White)
                        M13_14.BackColor = Color.Orange;
                    else
                        M13_14.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 14 && HoraFin == 15)
                {
                    if (M14_15.BackColor == Color.White)
                        M14_15.BackColor = Color.Orange;
                    else
                        M14_15.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 15 && HoraFin == 16)
                {
                    if (M15_16.BackColor == Color.White)
                        M15_16.BackColor = Color.Orange;
                    else
                        M15_16.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 16 && HoraFin == 17)
                {
                    if (M16_17.BackColor == Color.White)
                        M16_17.BackColor = Color.Orange;
                    else
                        M16_17.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 17 && HoraFin == 18)
                {
                    if (M17_18.BackColor == Color.White)
                        M17_18.BackColor = Color.Orange;
                    else
                        M17_18.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 18 && HoraFin == 19)
                {
                    if (M18_19.BackColor == Color.White)
                        M18_19.BackColor = Color.Orange;
                    else
                        M18_19.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 19 && HoraFin == 20)
                {
                    if (M19_20.BackColor == Color.White)
                        M19_20.BackColor = Color.Orange;
                    else
                        M19_20.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 20 && HoraFin == 21)
                {
                    if (M20_21.BackColor == Color.White)
                        M20_21.BackColor = Color.Orange;
                    else
                        M20_21.BackColor = Color.DarkViolet;
                }
            }
            else if (Día == "MI")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                {
                    if (Mi7_8.BackColor == Color.White)
                        Mi7_8.BackColor = Color.Orange;
                    else
                        Mi7_8.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 8 && HoraFin == 9)
                {
                    if (Mi8_9.BackColor == Color.White)
                        Mi8_9.BackColor = Color.Orange;
                    else
                        Mi8_9.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 9 && HoraFin == 10)
                {
                    if (Mi9_10.BackColor == Color.White)
                        Mi9_10.BackColor = Color.Orange;
                    else
                        Mi9_10.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 10 && HoraFin == 11)
                {
                    if (Mi10_11.BackColor == Color.White)
                        Mi10_11.BackColor = Color.Orange;
                    else
                        Mi10_11.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 11 && HoraFin == 12)
                {
                    if (Mi11_12.BackColor == Color.White)
                        Mi11_12.BackColor = Color.Orange;
                    else
                        Mi11_12.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 12 && HoraFin == 13)
                {
                    if (Mi12_13.BackColor == Color.White)
                        Mi12_13.BackColor = Color.Orange;
                    else
                        Mi12_13.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 13 && HoraFin == 14)
                {
                    if (Mi13_14.BackColor == Color.White)
                        Mi13_14.BackColor = Color.Orange;
                    else
                        Mi13_14.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 14 && HoraFin == 15)
                {
                    if (Mi14_15.BackColor == Color.White)
                        Mi14_15.BackColor = Color.Orange;
                    else
                        Mi14_15.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 15 && HoraFin == 16)
                {
                    if (Mi15_16.BackColor == Color.White)
                        Mi15_16.BackColor = Color.Orange;
                    else
                        Mi15_16.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 16 && HoraFin == 17)
                {
                    if (Mi16_17.BackColor == Color.White)
                        Mi16_17.BackColor = Color.Orange;
                    else
                        Mi16_17.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 17 && HoraFin == 18)
                {
                    if (Mi17_18.BackColor == Color.White)
                        Mi17_18.BackColor = Color.Orange;
                    else
                        Mi17_18.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 18 && HoraFin == 19)
                {
                    if (Mi18_19.BackColor == Color.White)
                        Mi18_19.BackColor = Color.Orange;
                    else
                        Mi18_19.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 19 && HoraFin == 20)
                {
                    if (Mi19_20.BackColor == Color.White)
                        Mi19_20.BackColor = Color.Orange;
                    else
                        Mi19_20.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 20 && HoraFin == 21)
                {
                    if (Mi20_21.BackColor == Color.White)
                        Mi20_21.BackColor = Color.Orange;
                    else
                        Mi20_21.BackColor = Color.DarkViolet;
                }
            }
            else if (Día == "JU")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                {
                    if (J7_8.BackColor == Color.White)
                        J7_8.BackColor = Color.Orange;
                    else
                        J7_8.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 8 && HoraFin == 9)
                {
                    if (J8_9.BackColor == Color.White)
                        J8_9.BackColor = Color.Orange;
                    else
                        J8_9.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 9 && HoraFin == 10)
                {
                    if (J9_10.BackColor == Color.White)
                        J9_10.BackColor = Color.Orange;
                    else
                        J9_10.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 10 && HoraFin == 11)
                {
                    if (J10_11.BackColor == Color.White)
                        J10_11.BackColor = Color.Orange;
                    else
                        J10_11.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 11 && HoraFin == 12)
                {
                    if (J11_12.BackColor == Color.White)
                        J11_12.BackColor = Color.Orange;
                    else
                        J11_12.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 12 && HoraFin == 13)
                {
                    if (J12_13.BackColor == Color.White)
                        J12_13.BackColor = Color.Orange;
                    else
                        J12_13.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 13 && HoraFin == 14)
                {
                    if (J13_14.BackColor == Color.White)
                        J13_14.BackColor = Color.Orange;
                    else
                        J13_14.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 14 && HoraFin == 15)
                {
                    if (J14_15.BackColor == Color.White)
                        J14_15.BackColor = Color.Orange;
                    else
                        J14_15.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 15 && HoraFin == 16)
                {
                    if (J15_16.BackColor == Color.White)
                        J15_16.BackColor = Color.Orange;
                    else
                        J15_16.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 16 && HoraFin == 17)
                {
                    if (J16_17.BackColor == Color.White)
                        J16_17.BackColor = Color.Orange;
                    else
                        J16_17.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 17 && HoraFin == 18)
                {
                    if (J17_18.BackColor == Color.White)
                        J17_18.BackColor = Color.Orange;
                    else
                        J17_18.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 18 && HoraFin == 19)
                {
                    if (J18_19.BackColor == Color.White)
                        J18_19.BackColor = Color.Orange;
                    else
                        J18_19.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 19 && HoraFin == 20)
                {
                    if (J19_20.BackColor == Color.White)
                        J19_20.BackColor = Color.Orange;
                    else
                        J19_20.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 20 && HoraFin == 21)
                {
                    if (J20_21.BackColor == Color.White)
                        J20_21.BackColor = Color.Orange;
                    else
                        J20_21.BackColor = Color.DarkViolet;
                }
            }
            else if (Día == "VI")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                {
                    if (V7_8.BackColor == Color.White)
                        V7_8.BackColor = Color.Orange;
                    else
                        V7_8.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 8 && HoraFin == 9)
                {
                    if (V8_9.BackColor == Color.White)
                        V8_9.BackColor = Color.Orange;
                    else
                        V8_9.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 9 && HoraFin == 10)
                {
                    if (V9_10.BackColor == Color.White)
                        V9_10.BackColor = Color.Orange;
                    else
                        V9_10.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 10 && HoraFin == 11)
                {
                    if (V10_11.BackColor == Color.White)
                        V10_11.BackColor = Color.Orange;
                    else
                        V10_11.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 11 && HoraFin == 12)
                {
                    if (V11_12.BackColor == Color.White)
                        V11_12.BackColor = Color.Orange;
                    else
                        V11_12.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 12 && HoraFin == 13)
                {
                    if (V12_13.BackColor == Color.White)
                        V12_13.BackColor = Color.Orange;
                    else
                        V12_13.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 13 && HoraFin == 14)
                {
                    if (V13_14.BackColor == Color.White)
                        V13_14.BackColor = Color.Orange;
                    else
                        V13_14.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 14 && HoraFin == 15)
                {
                    if (V14_15.BackColor == Color.White)
                        V14_15.BackColor = Color.Orange;
                    else
                        V14_15.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 15 && HoraFin == 16)
                {
                    if (V15_16.BackColor == Color.White)
                        V15_16.BackColor = Color.Orange;
                    else
                        V15_16.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 16 && HoraFin == 17)
                {
                    if (V16_17.BackColor == Color.White)
                        V16_17.BackColor = Color.Orange;
                    else
                        V16_17.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 17 && HoraFin == 18)
                {
                    if (V17_18.BackColor == Color.White)
                        V17_18.BackColor = Color.Orange;
                    else
                        V17_18.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 18 && HoraFin == 19)
                {
                    if (V18_19.BackColor == Color.White)
                        V18_19.BackColor = Color.Orange;
                    else
                        V18_19.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 19 && HoraFin == 20)
                {
                    if (V19_20.BackColor == Color.White)
                        V19_20.BackColor = Color.Orange;
                    else
                        V19_20.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 20 && HoraFin == 21)
                {
                    if (V20_21.BackColor == Color.White)
                        V20_21.BackColor = Color.Orange;
                    else
                        V20_21.BackColor = Color.DarkViolet;
                }
            }
            else if (Día == "SA")
            {
                if (HoraInicio == 7 && HoraFin == 8)
                {
                    if (S7_8.BackColor == Color.White)
                        S7_8.BackColor = Color.Orange;
                    else
                        S7_8.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 8 && HoraFin == 9)
                {
                    if (S8_9.BackColor == Color.White)
                        S8_9.BackColor = Color.Orange;
                    else
                        S8_9.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 9 && HoraFin == 10)
                {
                    if (S9_10.BackColor == Color.White)
                        S9_10.BackColor = Color.Orange;
                    else
                        S9_10.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 10 && HoraFin == 11)
                {
                    if (S10_11.BackColor == Color.White)
                        S10_11.BackColor = Color.Orange;
                    else
                        S10_11.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 11 && HoraFin == 12)
                {
                    if (S11_12.BackColor == Color.White)
                        S11_12.BackColor = Color.Orange;
                    else
                        S11_12.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 12 && HoraFin == 13)
                {
                    if (S12_13.BackColor == Color.White)
                        S12_13.BackColor = Color.Orange;
                    else
                        S12_13.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 13 && HoraFin == 14)
                {
                    if (S13_14.BackColor == Color.White)
                        S13_14.BackColor = Color.Orange;
                    else
                        S13_14.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 14 && HoraFin == 15)
                {
                    if (S14_15.BackColor == Color.White)
                        S14_15.BackColor = Color.Orange;
                    else
                        S14_15.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 15 && HoraFin == 16)
                {
                    if (S15_16.BackColor == Color.White)
                        S15_16.BackColor = Color.Orange;
                    else
                        S15_16.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 16 && HoraFin == 17)
                {
                    if (S16_17.BackColor == Color.White)
                        S16_17.BackColor = Color.Orange;
                    else
                        S16_17.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 17 && HoraFin == 18)
                {
                    if (S17_18.BackColor == Color.White)
                        S17_18.BackColor = Color.Orange;
                    else
                        S17_18.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 18 && HoraFin == 19)
                {
                    if (S18_19.BackColor == Color.White)
                        S18_19.BackColor = Color.Orange;
                    else
                        S18_19.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 19 && HoraFin == 20)
                {
                    if (S19_20.BackColor == Color.White)
                        S19_20.BackColor = Color.Orange;
                    else
                        S19_20.BackColor = Color.DarkViolet;
                }
                else if (HoraInicio == 20 && HoraFin == 21)
                {
                    if (S20_21.BackColor == Color.White)
                        S20_21.BackColor = Color.Orange;
                    else
                        S20_21.BackColor = Color.DarkViolet;
                }
            }
        }

        public void Actualizar_Color()
        {
            Limpiar_Colores();

            DataTable T1 = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, CódigoDocente1);
            DataTable T2 = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, CódigoDocente2);

            if (T1.Rows.Count >= 1 || T2.Rows.Count >= 1)
            {
                string Día;
                string HI;
                string HF;

                if (CódigoDocente1 != "00000")
                {
                    if (T1.Rows.Count >= 1)
                    {
                        for (int i = 0; i < T1.Rows.Count; i++)
                        {
                            Día = T1.Rows[i]["Dia"].ToString();
                            HI = T1.Rows[i]["HoraInicio"].ToString();
                            HF = T1.Rows[i]["HoraFin"].ToString();
                            Designar(Día, HI, HF, 1);
                        }
                    }
                }

                if (CódigoDocente2 != "00000")
                {
                    if (T2.Rows.Count >= 1 && Seleccionar_Docente_Cod_Nom2.Enabled == true)
                    {
                        for (int i = 0; i < T2.Rows.Count; i++)
                        {
                            Día = T2.Rows[i]["Dia"].ToString();
                            HI = T2.Rows[i]["HoraInicio"].ToString();
                            HF = T2.Rows[i]["HoraFin"].ToString();
                            Designar(Día, HI, HF, 2);
                        }
                    }
                }
            }
        }

        public void Borrar_Color()
        {
            string Grupo;
            if (Check_Grupo_A.Checked == true)
                Grupo = "A";
            else if (Check_Grupo_A.Checked == true)
                Grupo = "B";
            else
                Grupo = "C";

            DataTable T1 = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, CódigoDocente1);
            DataTable T2 = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, CódigoDocente2);

            string CodA;
            string grupo;
            string cod_asignatura;
            string Día;
            string HI;
            string HF;

            if (CódigoD1A == CódigoDocente1 && CódigoSemestreA == CodSemestre && CódigoAsignaturaA == CódigoAsignatura && Grupo == GrupoA)
            {
                if (CódigoDocente1 != "00000")
                {
                    for (int i = 0; i < T1.Rows.Count; i++)
                    {
                        CodA = T1.Rows[i]["CodAsignatura"].ToString();
                        cod_asignatura = CodA.Substring(0, 5);
                        grupo = CodA.Substring(5, 1);
                        Día = T1.Rows[i]["Dia"].ToString();
                        HI = T1.Rows[i]["HoraInicio"].ToString();
                        HF = T1.Rows[i]["HoraFin"].ToString();
                        if (cod_asignatura == CódigoAsignaturaA && grupo == GrupoA)
                            Designar2(Día,HI,HF);
                    }
                }
            }
            if (CódigoD2A == CódigoDocente2 && CódigoSemestreA == CodSemestre && CódigoAsignaturaA == CódigoAsignatura && Grupo == GrupoA)
            {
                if (CódigoDocente2 != "00000")
                {
                    if (Seleccionar_Docente_Cod_Nom2.Enabled == true)
                    {
                        for (int i = 0; i < T2.Rows.Count; i++)
                        {
                            CodA = T2.Rows[i]["CodAsignatura"].ToString();
                            cod_asignatura = CodA.Substring(0, 5);
                            grupo = CodA.Substring(5, 1);
                            Día = T2.Rows[i]["Dia"].ToString();
                            HI = T2.Rows[i]["HoraInicio"].ToString();
                            HF = T2.Rows[i]["HoraFin"].ToString();
                            if (cod_asignatura == CódigoAsignaturaA && grupo == GrupoA)
                                Designar2(Día, HI, HF);
                        }
                    }
                }
            }
        }
    }
}
