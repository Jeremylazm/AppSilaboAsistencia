using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_AsistenciaEstudiante
    {
        readonly D_AsistenciaEstudiante ObjAsistenciaEstudiante = new D_AsistenciaEstudiante();

        public static DataTable AsistenciaEstudiantes(string CodSemestre, string CodDepartamentoA, string Texto, string HoraInicio, string Fecha)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudiantes(CodSemestre, CodDepartamentoA, Texto, HoraInicio, Fecha);
        }

        public static DataTable AsistenciaEstudianteAsignatura(string CodSemestre, string CodDepartamentoA, string Texto1, string Texto2,
                                                               string HoraInicio, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudianteAsignatura(CodSemestre, CodDepartamentoA, Texto1, Texto2, HoraInicio, LimFechaInf, LimFechaSup);
        }

        public void RegistrarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.RegistrarAsistenciaEstudiante(AsistenciaEstudiante);
        }

        public void ActualizarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante,
                                                   string NCodSemestre,   
                                                   string NCodAsignatura,
                                                   string NHoraInicio,
                                                   string NFecha,    
                                                   string NCodEstudiante, 
                                                   string NEstado,        
                                                   string NObservacion)   
        {
            ObjAsistenciaEstudiante.ActualizarAsistenciaEstudiante(AsistenciaEstudiante, NCodSemestre, NCodAsignatura, NHoraInicio, NFecha, NCodEstudiante, NEstado, NObservacion);
        }

        public void EliminarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.EliminarAsistenciaEstudiante(AsistenciaEstudiante);
        }
    }
}
