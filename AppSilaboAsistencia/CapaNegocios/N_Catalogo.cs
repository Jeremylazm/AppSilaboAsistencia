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

        public static DataTable BuscarCatálogo(string CodSemestre, string CodDepartamentoA, string Texto)
        {
            return new D_Catalogo().BuscarCatálogo(CodSemestre, CodDepartamentoA, Texto);
        }

        public static DataTable BuscarDocentesAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            return new D_Catalogo().BuscarDocentesAsignatura(CodSemestre, Texto1, Texto2, Grupo);
        }

        public static DataTable BuscarAsignaturasDocente(string CodSemestre, string CodDepartamentoA, string Texto)
        {
            return new D_Catalogo().BuscarAsignaturasDocente(CodSemestre, CodDepartamentoA, Texto);
        }

        public static DataTable BuscarAsignaturasAsignadasDocente(string CodSemestre, string CodDepartamentoA, string CodDocente, string Texto)
        {
            return new D_Catalogo().BuscarAsignaturasAsignadasDocente(CodSemestre, CodDepartamentoA, CodDocente, Texto);
        }

        public static DataTable BuscarSilabosAsignatura(string CodAsignatura)
        {
            return new D_Catalogo().BuscarSilabosAsignatura(CodAsignatura);
        }

        public static DataTable BuscarPlanSesionesAsignatura(string CodAsignatura, string CodDocente)
        {
            return new D_Catalogo().BuscarPlanSesionesAsignatura(CodAsignatura, CodDocente);
        }
        public static DataTable RecuperarPlanDeSesionAsignatura(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            return new D_Catalogo().RecuperarPlanDeSesionAsignatura(CodSemestre, CodAsignatura, CodDocente);
        }

        public static DataTable ListaEstudiantesMatriculados(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            return new D_Catalogo().ListaEstudiantesMatriculados(CodSemestre, CodAsignatura, CodDocente);
        }

        public void InsertarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            ObjCatalogo.InsertarAsignaturaCatalogo(Catalogo);
        }

        public void ActualizarMatriculadosAsignatura(string CodSemestre, string CodAsignatura, string CodDocente, string Matriculados)
        {
            ObjCatalogo.ActualizarMatriculadosAsignatura(CodSemestre, CodAsignatura, CodDocente, Matriculados);
        }

        public void ActualizarAsignaturaCatalogo(E_Catalogo Catalogo, string NCodSemestre, string NCodAsignatura, string NCodEscuelaP, string NGrupo, string NCodDocente) 
        {
            ObjCatalogo.ActualizarAsignaturaCatalogo(Catalogo, NCodSemestre, NCodAsignatura, NCodEscuelaP, NGrupo, NCodDocente);
        }

        public void ActualizarSilaboAsignatura(string CodSemestre, string CodAsignatura, string CodDocente, byte[] Silabo)
        {
            ObjCatalogo.ActualizarSilaboAsignatura(CodSemestre, CodAsignatura, CodDocente, Silabo);
        }

        public void ActualizarPlanSesionesAsignatura(string CodSemestre, string CodAsignatura, string CodDocente, byte[] PlanSesiones)
        {
            ObjCatalogo.ActualizarPlanSesionesAsignatura(CodSemestre, CodAsignatura, CodDocente, PlanSesiones);
        }
        public void ActualizarPlantillaSilabo(byte[] PlantillaSilabo)
        {
            ObjCatalogo.ActualizarPlantillaSilabo(PlantillaSilabo);
        }
        public void ActualizarPlantillaSesiones2y3(byte[] PlantillaSesiones)
        {
            ObjCatalogo.ActualizarPlantillaSesiones2y3(PlantillaSesiones);
        }
        public void ActualizarPlantillaSesiones4(byte[] PlantillaSesiones)
        {
            ObjCatalogo.ActualizarPlantillaSesiones4(PlantillaSesiones);
        }

        public void EliminarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            ObjCatalogo.EliminarAsignaturaCatalogo(Catalogo);
        }
    }
}
