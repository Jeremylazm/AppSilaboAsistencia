using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Catalogo
    {
        readonly D_Catalogo ObjCatalogo = new D_Catalogo();

        public static DataTable MostrarCatalogo(string CodSemestre, string CodDepartamentoA)
        {
            return new D_Catalogo().MostrarCatalogo(CodSemestre, CodDepartamentoA);
        }

        public static DataTable BuscarDocentesAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            return new D_Catalogo().BuscarDocentesAsignatura(CodSemestre, Texto1, Texto2, Grupo);
        }

        public static DataTable BuscarAsignaturasDocente(string CodSemestre, string CodDepartamentoA, string Texto)
        {
            return new D_Catalogo().BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, Texto);
        }

        public static DataTable BuscarSilabosAsignatura(string Texto1, string Texto2)
        {
            return new D_Catalogo().BuscarSilabosAsignatura(Texto1, Texto2);
        }

        public static DataTable MostrarSilaboAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            return new D_Catalogo().MostrarSilaboAsignatura(CodSemestre, Texto1, Texto2, Grupo);
        }

        public static DataTable BuscarPlanSesionesAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            return new D_Catalogo().BuscarPlanSesionesAsignatura(CodSemestre, Texto1, Texto2, Grupo);
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
