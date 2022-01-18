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

        public static DataTable BuscarEstudiantesMatriculados(string CodSemestre, string CodEscuelaP, string Texto)
        {
            return new D_Matricula().BuscarEstudiantesMatriculados(CodSemestre, CodEscuelaP, Texto);
        }

        public static DataTable BuscarAsignaturasEstudiante(string CodSemestre, string CodEscuelaP, string CodEstudiante)
        {
            return new D_Matricula().BuscarAsignaturasEstudiante(CodSemestre, CodEscuelaP, CodEstudiante);
        }

        public static DataTable BuscarEstudiantesAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            return new D_Matricula().BuscarEstudiantesAsignatura(CodSemestre, CodEscuelaP, Texto);
        }

        public static DataTable BuscarEstudiantesMatriculadosAsignatura(string CodSemestre, string CodEscuelaP, string CodAsignatura, string Texto)
        {
            return new D_Matricula().BuscarEstudiantesMatriculadosAsignatura(CodSemestre, CodEscuelaP, CodAsignatura, Texto);
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
