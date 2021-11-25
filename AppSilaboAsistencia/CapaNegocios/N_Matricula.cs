using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Matricula
    {
        readonly D_Matricula ObjMatricula = new D_Matricula();

        public static DataTable MostrarEstudiantesMatriculados(string CodSemestre, string CodEscuelaP)
        {
            return new D_Matricula().MostrarEstudiantesMatriculados(CodSemestre, CodEscuelaP);
        }

        public static DataTable BuscarAsignaturasEstudiante(string CodSemestre, string CodEscuelaP, string CodEstudiante)
        {
            return new D_Matricula().BuscarAsignaturasEstudiante(CodSemestre, CodEscuelaP, CodEstudiante);
        }

        public static DataTable BuscarEstudiantesAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            return new D_Matricula().BuscarEstudiantesAsignatura(CodSemestre, CodEscuelaP, Texto);
        }

        public void InsertarMatricula(E_Matricula Matricula)
        {
            ObjMatricula.InsertarMatricula(Matricula);
        }

        public void ActualizarMatricula(E_Matricula Matricula)
        {
            ObjMatricula.ActualizarMatricula(Matricula);
        }

        public void EliminarMatricula(E_Matricula Matricula)
        {
            ObjMatricula.EliminarMatricula(Matricula);
        }
    }
}
