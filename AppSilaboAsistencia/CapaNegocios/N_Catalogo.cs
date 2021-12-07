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

        public static DataTable BuscarCatálogo(string CodSemestre, string Texto, string CodDepartamentoA)
        {
            return new D_Catalogo().BuscarCatálogo(CodSemestre, Texto, CodDepartamentoA);
        }

        public static DataTable BuscarDocentesAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            return new D_Catalogo().BuscarDocentesAsignatura(CodSemestre, Texto1, Texto2, Grupo);
        }

        public static DataTable BuscarAsignaturasDocente(string CodSemestre, string CodDepartamentoA, string Texto)
        {
            return new D_Catalogo().BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, Texto);
        }

        public static DataTable BuscarAsignaturasAsignadasDocente(string CodSemestre, string CodDepartamentoA, string Texto1, string Texto2)
        {
            return new D_Catalogo().BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, Texto1, Texto2);
        }

        public static DataTable BuscarSilabosAsignatura(string CodSemestre, string Texto1, string Texto2)
        {
            return new D_Catalogo().BuscarSilabosAsignatura(CodSemestre, Texto1, Texto2);
        }

        public static DataTable MostrarSilaboAsignatura(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            return new D_Catalogo().MostrarSilaboAsignatura(CodSemestre, CodAsignatura, CodDocente);
        }

        public static DataTable MostrarPlanSesionesAsignatura(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            return new D_Catalogo().MostrarPlanSesionesAsignatura(CodSemestre, CodAsignatura, CodDocente);
        }

        public void InsertarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            ObjCatalogo.InsertarAsignaturaCatalogo(Catalogo);
        }

        public static void ActualizarAsignaturaCatalogo(string CodSemestreA, string CodAsignaturaA, string CodEscuelaPA, string GrupoA, string CodDocenteA, string CodSemestre, string CodEscuelaP, string Grupo, string CodDocente)
        {
            new D_Catalogo().ActualizarAsignaturaCatalogo(CodSemestreA, CodAsignaturaA, CodEscuelaPA, GrupoA, CodDocenteA, CodSemestre, CodEscuelaP, Grupo, CodDocente);
        }

        public void ActualizarSilaboAsignatura(string CodSemestre, string CodAsignatura, string CodDocente, byte[] Silabo)
        {
            ObjCatalogo.ActualizarSilaboAsignatura(CodSemestre, CodAsignatura, CodDocente, Silabo);
        }

        public void ActualizarPlanSesionesAsignatura(string CodSemestre, string CodAsignatura, string CodDocente, byte[] PlanSesiones)
        {
            ObjCatalogo.ActualizarPlanSesionesAsignatura(CodSemestre, CodAsignatura, CodDocente, PlanSesiones);
        }

        public static void EliminarAsignaturaCatalogo(string CodSemestre, string CodAsignatura, string CodEscuelaP, string Grupo)
        {
            new D_Catalogo().EliminarAsignaturaCatalogo(CodSemestre, CodAsignatura, CodEscuelaP, Grupo);
        }
    }
}
