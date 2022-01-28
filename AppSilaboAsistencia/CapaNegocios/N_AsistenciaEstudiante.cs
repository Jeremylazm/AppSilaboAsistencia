using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_AsistenciaEstudiante
    {
        readonly D_AsistenciaEstudiante ObjAsistenciaEstudiante = new D_AsistenciaEstudiante();

        public static DataTable AsistenciaEstudiantes(string CodSemestre, string CodAsignatura, string Fecha, string Hora)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudiantes(CodSemestre, CodAsignatura, Fecha, Hora);
        }

        public static DataTable AsistenciaEstudianteAsignatura(string CodSemestre, string CodEstudiante, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudianteAsignatura(CodSemestre, CodEstudiante, CodAsignatura, LimFechaInf, LimFechaSup);
        }

        public static DataTable AsistenciaEstudiantesPorFechas(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudiantesPorFechas(CodSemestre, CodDocente, CodAsignatura, LimFechaInf, LimFechaSup);
        }

        public static DataTable AsistenciaEstudiantesPorEstudiante(string CodSemestre, string CodAsignatura, string CodDocente, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudiantesPorEstudiante(CodSemestre, CodAsignatura, CodDocente, LimFechaInf, LimFechaSup);
        }

        public static DataTable AsistenciaEstudiantesPorAsignaturas(string CodSemestre, string CodDepartamentoA, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudiantesPorAsignaturas(CodSemestre, CodDepartamentoA, LimFechaInf, LimFechaSup);
        }

        public static DataTable AsistenciaAsignaturasEstudiante(string CodSemestre, string CodEstudiante, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaEstudiante().AsistenciaAsignaturasEstudiante(CodSemestre, CodEstudiante, LimFechaInf, LimFechaSup);
        }

        public void RegistrarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.RegistrarAsistenciaEstudiante(AsistenciaEstudiante);
        }

        public void ActualizarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante, string NAsistio, string NObservacion)   
        {
            ObjAsistenciaEstudiante.ActualizarAsistenciaEstudiante(AsistenciaEstudiante, NAsistio, NObservacion);
        }

        public void EliminarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.EliminarAsistenciaEstudiante(AsistenciaEstudiante);
        }
    }
}
