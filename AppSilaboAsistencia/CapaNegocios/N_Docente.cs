using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Docente
    {
        readonly D_Docente ObjDocente = new D_Docente();

        public static DataTable MostrarDocentes(string CodEscuelaP)
        {
            return new D_Docente().MostrarDocentes(CodEscuelaP);
        }

        public static DataTable BuscarDocente(string CodEscuelaP, string CodDocente)
        {
            return new D_Docente().BuscarDocente(CodEscuelaP, CodDocente);
        }

        public static DataTable BuscarDocentes(string CodEscuelaP, string Texto)
        {
            return new D_Docente().BuscarDocente(CodEscuelaP, Texto);
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
