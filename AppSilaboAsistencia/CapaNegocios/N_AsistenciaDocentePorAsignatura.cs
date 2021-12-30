using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_AsistenciaDocentePorAsignatura
    {
        readonly D_AsistenciaDocentePorAsignatura ObjAsistenciaDocentePorAsignatura = new D_AsistenciaDocentePorAsignatura();

        public static DataTable AsistenciaDocentesPorAsignatura(string CodSemestre, string CodDepartamentoA, string Fecha)
        {
            return new D_AsistenciaDocentePorAsignatura().AsistenciaDocentesPorAsignatura(CodSemestre, CodDepartamentoA, Fecha);
        }

        public static DataTable MostrarSesionesAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaDocentePorAsignatura().MostrarSesionesAsignatura(CodSemestre, CodDocente, CodAsignatura, LimFechaInf, LimFechaSup);
        }

        public static DataTable BuscarSesionAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup, string Texto)
        {
            return new D_AsistenciaDocentePorAsignatura().BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, LimFechaInf, LimFechaSup, Texto);
        }

        public void RegistrarAsistenciaDocentePorAsignatura(E_AsistenciaDocentePorAsignatura AsistenciaDocente)
        {
            ObjAsistenciaDocentePorAsignatura.RegistrarAsistenciaDocentePorAsignatura(AsistenciaDocente);
        }

        public void ActualizarAsistenciaDocentePorAsignatura(E_AsistenciaDocentePorAsignatura AsistenciaDocente, string NTipoSesion, string NNombreTema, string NObservacion) 
        {
            ObjAsistenciaDocentePorAsignatura.ActualizarAsistenciaDocentePorAsignatura(AsistenciaDocente, NTipoSesion, NNombreTema, NObservacion);
        }

        public void EliminarAsistenciaDocentePorAsignatura(E_AsistenciaDocentePorAsignatura AsistenciaDocente)
        {
            ObjAsistenciaDocentePorAsignatura.EliminarAsistenciaDocentePorAsignatura(AsistenciaDocente);
        }
    }
}
