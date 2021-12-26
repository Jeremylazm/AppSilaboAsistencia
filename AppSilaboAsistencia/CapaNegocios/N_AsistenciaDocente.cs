using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_AsistenciaDocente
    {
        readonly D_AsistenciaDocente ObjAsistenciaDocente = new D_AsistenciaDocente();

        public static DataTable AsistenciaDocentes(string CodSemestre, string CodDepartamentoA, string Fecha)
        {
            return new D_AsistenciaDocente().AsistenciaDocentes(CodSemestre, CodDepartamentoA, Fecha);
        }

        public static DataTable MostrarSesionesAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaDocente().MostrarSesionesAsignatura(CodSemestre, CodDocente, CodAsignatura, LimFechaInf, LimFechaSup);
        }

        public static DataTable BuscarSesionAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup, string Texto)
        {
            return new D_AsistenciaDocente().BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, LimFechaInf, LimFechaSup, Texto);
        }

        public void RegistrarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente)
        {
            ObjAsistenciaDocente.RegistrarAsistenciaDocente(AsistenciaDocente);
        }

        public void ActualizarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente, string NNombreTema) 
        {
            ObjAsistenciaDocente.ActualizarAsistenciaDocente(AsistenciaDocente, NNombreTema);
        }

        public void EliminarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente)
        {
            ObjAsistenciaDocente.EliminarAsistenciaDocente(AsistenciaDocente);
        }
    }
}
