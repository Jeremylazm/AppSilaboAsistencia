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

        public static DataTable HorasDocenteAsignaturaHorarioAsignatura(string CodDocente, string CodSemestre, string CodAsignatura, string Grupo)
        {
            return new D_HorarioAsignatura().HorasDocenteAsignaturaHorarioAsignatura(CodDocente, CodSemestre, CodAsignatura, Grupo);
        }

        public static DataTable BuscarAsignaturasDiaHora(string CodSemestre, string CodDepartamentoA, string Dia, string HoraInicio, string HoraFin)
        {
            return new D_HorarioAsignatura().BuscarAsignaturasDiaHora(CodSemestre, CodDepartamentoA, Dia, HoraInicio, HoraFin);
        }

        public void InsertarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura)
        {
            ObjHorarioAsignatura.InsertarHorarioAsignatura(HorarioAsignatura);
        }

        public void ActualizarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura,
                                                string NCodSemestre, 
                                                string NCodAsignatura,
                                                string NCodEscuelaP,
                                                string NGrupo, 
                                                string NCodDocente,
                                                string NDia,
                                                string NTipo,
                                                string NHorasTeoria,
                                                string NHorasPractica,
                                                string NHoraInicio,
                                                string NHoraFin,
                                                string NAula,
                                                string NModalidad)
        {
            ObjHorarioAsignatura.ActualizarHorarioAsignatura(HorarioAsignatura, NCodSemestre, NCodAsignatura, NCodEscuelaP, NGrupo, NCodDocente, NDia, 
                                                             NTipo,NHorasTeoria, NHorasPractica, NHoraInicio, NHoraFin, NAula, NModalidad);
        }

        public void EliminarHorarioAsignatura(E_HorarioAsignatura HorarioAsignatura)
        {
            ObjHorarioAsignatura.EliminarHorarioAsignatura(HorarioAsignatura);
        }
    }
}
