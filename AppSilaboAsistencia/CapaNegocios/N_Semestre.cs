using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_Semestre
    {
        readonly D_Semestre ObjSemestre = new D_Semestre();

        public static DataTable SemestreActual()
        {
            return new D_Semestre().SemestreActual();
        }

        public static DataTable MostrarSemestres()
        {
            return new D_Semestre().MostrarSemestres();
        }

        public void InsertarSemestre(E_Semestre Semestre)
        {
            ObjSemestre.InsertarSemestre(Semestre);
        }

        public void ActualizarSemestre(E_Semestre Semestre, string NDenominacion, string NFechaInicio)
        {
            ObjSemestre.ActualizarSemestre(Semestre, NDenominacion, NFechaInicio);
        }

        public void EliminarSemestre(E_Semestre Semestre)
        {
            ObjSemestre.EliminarSemestre(Semestre);
        }
    }
}
