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

        public void RegistrarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.RegistrarAsistenciaEstudiante(AsistenciaEstudiante);
        }

        public void ActualizarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante, string NEstado, string NObservacion)   
        {
            ObjAsistenciaEstudiante.ActualizarAsistenciaEstudiante(AsistenciaEstudiante, NEstado, NObservacion);
        }

        public void EliminarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.EliminarAsistenciaEstudiante(AsistenciaEstudiante);
        }
    }
}
