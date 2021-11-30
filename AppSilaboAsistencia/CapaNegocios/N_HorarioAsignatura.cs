using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_HorarioAsignatura
    {
        readonly D_HorarioAsignatura ObjHorarioAsignatura = new D_HorarioAsignatura();

        public static DataTable BuscarHorarioAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            return new D_HorarioAsignatura().BuscarHorarioAsignatura(CodSemestre, Texto1, Texto2, Grupo);
        }

        public static DataTable HorarioAsignaturaDocente(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            return new D_HorarioAsignatura().HorarioAsignaturaDocente(CodSemestre, CodAsignatura, CodDocente);
        }

        public static DataTable HorarioSemanalDocente(string CodSemestre, string Texto)
        {
            return new D_HorarioAsignatura().HorarioSemanalDocente(CodSemestre, Texto);
        }

        public static DataTable HorasDocenteHorarioAsignatura(string CodDocente, string CodSemestre)
        {
            return new D_HorarioAsignatura().HorasDocenteHorarioAsignatura(CodDocente, CodSemestre);
        }

        public void InsertarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura)
        {
            ObjHorarioAsignatura.InsertarHorarioAsignatura(HorarioAsignatura);
        }

        public static void ActualizarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura, string CodSemestreB, string CodAsignaturaB, string CodEscuelaPB, string GrupoB, string CodDocenteB, string DiaB)
        {
            new D_HorarioAsignatura().ActualizarHorarioAsignatura(HorarioAsignatura, CodSemestreB, CodAsignaturaB, CodEscuelaPB, GrupoB, CodDocenteB, DiaB);
        }

        public static void EliminarHorarioAsignatura(string CodSemestre, string CodAsignatura, string CodEscuelaP, string Grupo)
        {
            new D_HorarioAsignatura().EliminarHorarioAsignatura(CodSemestre, CodAsignatura, CodEscuelaP, Grupo);
        }
    }
}
