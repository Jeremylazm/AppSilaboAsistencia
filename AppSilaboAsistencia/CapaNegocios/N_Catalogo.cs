using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Catalogo
    {
        readonly D_Catalogo ObjCatalogo = new D_Catalogo();

        public static DataTable MostrarCatalogo(string CodSemestre, string CodEscuelaP)
        {
            return new D_Catalogo().MostrarCatalogo(CodSemestre, CodEscuelaP);
        }

        public static DataTable BuscarDocentesAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            return new D_Catalogo().BuscarDocentesAsignatura(CodSemestre, CodEscuelaP, Texto);
        }

        public static DataTable BuscarAsignaturasDocente(string CodSemestre, string CodEscuelaP, string Texto)
        {
            return new D_Catalogo().BuscarAsignaturasDocente(CodSemestre, CodEscuelaP, Texto);
        }

        public static DataTable BuscarSilaboAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            return new D_Catalogo().BuscarSilaboAsignatura(CodSemestre, CodEscuelaP, Texto);
        }

        public void InsertarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            ObjCatalogo.InsertarAsignaturaCatalogo(Catalogo);
        }

        public void ActualizarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            ObjCatalogo.ActualizarAsignaturaCatalogo(Catalogo);
        }

        public void EliminarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            ObjCatalogo.EliminarAsignaturaCatalogo(Catalogo);
        }
    }
}
