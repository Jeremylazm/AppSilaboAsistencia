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
    }
}
