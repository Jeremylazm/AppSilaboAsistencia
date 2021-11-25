using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Asignatura
    {
        readonly D_Asignatura ObjAsignatura = new D_Asignatura();

        public static DataTable MostrarAsignaturas(string CodEscuelaP)
        {
            return new D_Asignatura().MostrarAsignaturas(CodEscuelaP);
        }

        public static DataTable BuscarAsignatura(string CodEscuelaP, string CodAsignatura)
        {
            return new D_Asignatura().BuscarAsignatura(CodEscuelaP, CodAsignatura);
        }

        public static DataTable BuscarAsignaturas(string CodEscuelaP, string Texto)
        {
            return new D_Asignatura().BuscarAsignaturas(CodEscuelaP, Texto);
        }

        public static DataTable ObtenerHorasAsignatura(string CodAsignatura)
        {
            return new D_Asignatura().ObtenerHorasAsignatura(CodAsignatura);
        }

        public static DataTable ObtenerCódigoAsignatura(string NombreAsignatura)
        {
            return new D_Asignatura().ObtenerCódigoAsignatura(NombreAsignatura);
        }

        public static DataTable ObtenerPrimeraAsignatura()
        {
            return new D_Asignatura().ObtenerPrimeraAsignatura();
        }

        public void InsertarAsignatura(E_Asignatura Asignatura)
        {
            ObjAsignatura.InsertarAsignatura(Asignatura);
        }

        public void ActualizarAsignatura(E_Asignatura Asignatura)
        {
            ObjAsignatura.ActualizarAsignatura(Asignatura);
        }

        public void EliminarAsignatura(E_Asignatura Asignatura)
        {
            ObjAsignatura.EliminarAsignatura(Asignatura);
        }
    }
}
