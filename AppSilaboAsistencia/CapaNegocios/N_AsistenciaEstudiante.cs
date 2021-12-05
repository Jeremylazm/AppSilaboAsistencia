using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_AsistenciaEstudiante
    {
        readonly D_AsistenciaEstudiante ObjAsistenciaEstudiante = new D_AsistenciaEstudiante();

        public static DataTable AsistenciaEstudiantes(string CodSemestre, string CodDepartamentoA, string Texto, string Fecha)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudiantes(CodSemestre, CodDepartamentoA, Texto, Fecha);
        }

        public static DataTable AsistenciaEstudianteAsignatura(string CodSemestre, string CodDepartamentoA, string Texto1, string Texto2, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaEstudiante().AsistenciaEstudianteAsignatura(CodSemestre, CodDepartamentoA, Texto1, Texto2, LimFechaInf, LimFechaSup);
        }

        public void RegistrarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.RegistrarAsistenciaEstudiante(AsistenciaEstudiante);
        }

        public void ActualizarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante,
                                                   string NCodSemestre,   
                                                   string NCodAsignatura,
                                                   string NFecha,    
                                                   string NCodEstudiante, 
                                                   string NEstado,        
                                                   string NObservacion)   
        {
            ObjAsistenciaEstudiante.ActualizarAsistenciaEstudiante(AsistenciaEstudiante, NCodSemestre, NCodAsignatura, NFecha, NCodEstudiante, NEstado, NObservacion);
        }

        public void EliminarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            ObjAsistenciaEstudiante.EliminarAsistenciaEstudiante(AsistenciaEstudiante);
        }
    }
}
