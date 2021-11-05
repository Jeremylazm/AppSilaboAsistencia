using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Estudiante
    {
        readonly D_Estudiante ObjEstudiante = new D_Estudiante();

        public static DataTable MostrarEstudiantes(string CodEscuelaP)
        {
            return new D_Estudiante().MostrarEstudiantes(CodEscuelaP);
        }

        public static DataTable BuscarEstudiante(string CodEscuelaP, string CodEstudiante)
        {
            return new D_Estudiante().BuscarEstudiante(CodEscuelaP, CodEstudiante);
        }

        public static DataTable BuscarEstudiantes(string CodEscuelaP, string Texto)
        {
            return new D_Estudiante().BuscarEstudiante(CodEscuelaP, Texto);
        }

        public void InsertarEstudiante(E_Estudiante Estudiante)
        {
            ObjEstudiante.InsertarEstudiante(Estudiante);
        }

        public void ActualizarEstudiante(E_Estudiante Estudiante)
        {
            ObjEstudiante.ActualizarEstudiante(Estudiante);
        }

        public void EliminarEstudiante(E_Estudiante Estudiante)
        {
            ObjEstudiante.EliminarEstudiante(Estudiante);
        }
    }
}
