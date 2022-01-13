using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_AsistenciaDiariaDocente
    {
        readonly D_AsistenciaDiariaDocente ObjAsistenciaDiariaDocente = new D_AsistenciaDiariaDocente();

        public static DataTable BuscarAsistenciaDocente(string CodSemestre, string CodDepartamentoA, string Fecha, string CodDocente)
        {
            return new D_AsistenciaDiariaDocente().BuscarAsistenciaDocente(CodSemestre, CodDepartamentoA, Fecha, CodDocente);
        }

        public static DataTable AsistenciaDiariaDocentes(string CodSemestre, string CodDepartamentoA, string Fecha)
        {
            return new D_AsistenciaDiariaDocente().AsistenciaDiariaDocentes(CodSemestre, CodDepartamentoA, Fecha);
        }

        public static DataTable AsistenciasDocente(string CodSemestre, string CodDocente, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaDiariaDocente().AsistenciasDocente(CodSemestre, CodDocente, LimFechaInf, LimFechaSup);
        }

        public static DataTable AsistenciaDocentesPorFechas(string CodSemestre, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaDiariaDocente().AsistenciaDocentesPorFechas(CodSemestre, LimFechaInf, LimFechaSup);
        }

        public void RegistrarAsistenciaDiariaDocente(E_AsistenciaDiariaDocente AsistenciaDiariaDocente)
        {
            ObjAsistenciaDiariaDocente.RegistrarAsistenciaDiariaDocente(AsistenciaDiariaDocente);
        }

        public void ActualizarAsistenciaDiariaDocente(E_AsistenciaDiariaDocente AsistenciaDiariaDocente, string NObservacion)
        {
            ObjAsistenciaDiariaDocente.ActualizarAsistenciaDiariaDocente(AsistenciaDiariaDocente, NObservacion);
        }

        public void EliminarAsistenciaDiariaDocente(E_AsistenciaDiariaDocente AsistenciaDiariaDocente)
        {
            ObjAsistenciaDiariaDocente.EliminarAsistenciaDiariaDocente(AsistenciaDiariaDocente);
        }
    }
}
