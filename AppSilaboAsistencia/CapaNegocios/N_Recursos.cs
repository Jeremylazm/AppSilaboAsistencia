using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Recursos
    {
        readonly D_Recursos ObjRecursos = new D_Recursos();

        public static DataTable DescargarPlantillaSilabo()
        {
            return new D_Recursos().DescargarPlantillaSilabo();
        }
        public static DataTable DescargarPlantillaPlanSesiones()
        {
            return new D_Recursos().DescargarPlantillaPlanSesiones();
        }
        public void ActualizarPlantillaSilabo(E_Recursos Recursos)
        {
            ObjRecursos.ActualizarPlantillaSilabo(Recursos);
        }
        public void ActualizarPlantillaPlanSesiones(E_Recursos Recursos)
        {
            ObjRecursos.ActualizarPlantillaPlanSesiones(Recursos);
        }
    }
}
