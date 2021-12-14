using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class N_EscuelaProfesional
    {
        public static DataTable MostrarEscuelas()
        {
            return new D_EscuelaProfesional().MostrarEscuelas();
        }

        public static string BuscarNombraEscuela(string CodEscuelaP)
        {
            return new D_EscuelaProfesional().BuscarNombreEscuela(CodEscuelaP);
        }
    }
}
