using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_AsistenciaDiariaDocente
    {
        readonly D_AsistenciaDiariaDocente ObjAsistenciaDiariaDocente = new D_AsistenciaDiariaDocente();

        public static DataTable AsistenciaDiariaDocentes(string CodSemestre, string CodDepartamentoA, string Fecha)
        {
            return new D_AsistenciaDiariaDocente().AsistenciaDiariaDocentes(CodSemestre, CodDepartamentoA, Fecha);
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
