using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class N_DepartamentoAcademico
    {
        public static DataTable MostrarDepartamentos()
        {
            return new D_DepartamentoAcademico().MostrarDepartamentos();
        }
    }
}
