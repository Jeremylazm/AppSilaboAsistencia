using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Asignatura
    {
        readonly D_Asignatura ObjAsignatura = new D_Asignatura();

        public static DataTable MostrarAsignaturas(string CodDepartamentoA)
        {
            return new D_Asignatura().MostrarAsignaturas(CodDepartamentoA);
        }

        public static DataTable BuscarAsignatura(string CodDepartamentoA, string CodAsignatura)
        {
            return new D_Asignatura().BuscarAsignatura(CodDepartamentoA, CodAsignatura);
        }

        public static DataTable BuscarAsignaturas(string CodDepartamentoA, string Texto)
        {
            return new D_Asignatura().BuscarAsignaturas(CodDepartamentoA, Texto);
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
