using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_HorarioRegistroAsistencia
    {
        readonly D_HorarioRegistroAsistencia ObjHorarioRegistroAsistencia = new D_HorarioRegistroAsistencia();

        public static DataTable BuscarHorarioRegistroAsistencia(string CodSemestre, string CodDepartamentoA, string CodJefeDepartamentoA)
        {
            return new D_HorarioRegistroAsistencia().BuscarHorarioRegistroAsistencia(CodSemestre, CodDepartamentoA, CodJefeDepartamentoA);
        }

        public void InsertarHorarioRegistroAsistencia(E_HorarioRegistroAsistencia HorarioRegistroAsistencia)
        {
            ObjHorarioRegistroAsistencia.InsertarHorarioRegistroAsistencia(HorarioRegistroAsistencia);
        }

        public void ActualizarHorarioRegistroAsistencia(E_HorarioRegistroAsistencia HorarioRegistroAsistencia, string NHoraInicio, string NHoraFin)
        {
            ObjHorarioRegistroAsistencia.ActualizarHorarioRegistroAsistencia(HorarioRegistroAsistencia, NHoraInicio, NHoraFin);
        }

        public void EliminarHorarioRegistroAsistencia(E_HorarioRegistroAsistencia HorarioRegistroAsistencia)
        {
            ObjHorarioRegistroAsistencia.EliminarHorarioRegistroAsistencia(HorarioRegistroAsistencia);
        }
    }
}
