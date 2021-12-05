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

        public static DataTable AsistenciaDocenteAsignatura(string CodSemestre, string CodDepartamentoA, string Texto1, string Texto2, string LimFechaInf, string LimFechaSup)
        {
            return new D_AsistenciaDocente().AsistenciaDocenteAsignatura(CodSemestre, CodDepartamentoA, Texto1, Texto2, LimFechaInf, LimFechaSup);
        }

        public void RegistrarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente)
        {
            ObjAsistenciaDocente.RegistrarAsistenciaDocente(AsistenciaDocente);
        }

        public void ActualizarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente,
                                                string NCodSemestre,  
                                                string NCodAsignatura, 
                                                string NFecha,     
                                                string NCodDocente, 
                                                string NNombreTema) 
        {
            ObjAsistenciaDocente.ActualizarAsistenciaDocente(AsistenciaDocente, NCodSemestre, NCodAsignatura, NFecha, NCodDocente, NNombreTema);
        }

        public void EliminarAsistenciaDocente(E_AsistenciaDocente AsistenciaDocente)
        {
            ObjAsistenciaDocente.EliminarAsistenciaDocente(AsistenciaDocente);
        }
    }
}
