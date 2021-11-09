using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Docente
    {
        readonly D_Docente ObjDocente = new D_Docente();

        public static DataTable MostrarDocentesDepartamento(string CodDepartamentoA)
        {
            return new D_Docente().MostrarDocentesDepartamento(CodDepartamentoA);
        }

        public static DataTable BuscarDocente(string CodDepartamentoA, string CodDocente)
        {
            return new D_Docente().BuscarDocente(CodDepartamentoA, CodDocente);
        }

        public static DataTable BuscarDocentes(string CodDepartamentoA, string Texto)
        {
            return new D_Docente().BuscarDocente(CodDepartamentoA, Texto);
        }

        public void InsertarDocente(E_Docente Docente)
        {
            ObjDocente.InsertarDocente(Docente);
        }

        public void ActualizarDocente(E_Docente Docente)
        {
            ObjDocente.ActualizarDocente(Docente);
        }

        public void EliminarDocente(E_Docente Docente)
        {
            ObjDocente.EliminarDocente(Docente);
        }
    }
}
