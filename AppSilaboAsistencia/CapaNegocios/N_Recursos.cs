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
        public static DataTable DescargarPlantillaPlanSesiones2y3()
        {
            return new D_Recursos().DescargarPlantillaPlanSesiones2y3();
        }
        public static DataTable DescargarPlantillaPlanSesiones4()
        {
            return new D_Recursos().DescargarPlantillaPlanSesiones4();
        }
        public void ActualizarPlantillaSilabo(E_Recursos Recursos)
        {
            ObjRecursos.ActualizarPlantillaSilabo(Recursos);
        }
        public void ActualizarPlantillaPlanSesiones2y3(E_Recursos Recursos)
        {
            ObjRecursos.ActualizarPlantillaPlanSesiones2y3(Recursos);
        }
        public void ActualizarPlantillaPlanSesiones4(E_Recursos Recursos)
        {
            ObjRecursos.ActualizarPlantillaPlanSesiones4(Recursos);
        }
    }
}
