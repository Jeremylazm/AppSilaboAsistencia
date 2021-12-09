using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Catalogo
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar el catálogo de asignaturas de una departamento académico.
        public DataTable MostrarCatalogo(string CodSemestre, string CodDepartamentoA)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); // Atrib.Docente(Jefe de Dep.)
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar un catálogo. 
        public DataTable BuscarCatálogo(string CodSemestre, string CodDepartamentoA, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); // Atrib.Docente(Jefe de Dep.)
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar los docentes que enseñan una asignatura. 
        public DataTable BuscarDocentesAsignatura(string CodSemestre, string Texto1, string Texto2, string Grupo)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarDocentesAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@Texto1", Texto1); // EP donde se enseña la asignatura
            Comando.Parameters.AddWithValue("@Texto2", Texto2); // código (ej. IF065) o nombre de la asignatura
            Comando.Parameters.AddWithValue("@Grupo", Grupo);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar las asignaturas asignadas a un docente.
        public DataTable BuscarAsignaturasDocente(string CodSemestre, string CodDepartamentoA, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignaturasDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); // Atrib. Docente (Jefe de Dep.)
            Comando.Parameters.AddWithValue("@Texto", Texto); // código o nombre del docente
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar por un filtro las asignaturas asignadas a un docente.
        public DataTable BuscarAsignaturasAsignadasDocente(string CodSemestre, string CodDepartamentoA, string CodDocente, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignaturasAsignadasDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); // Atrib. Docente (Jefe de Dep.)
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente); 
            Comando.Parameters.AddWithValue("@Texto", Texto); // campo de asignatura
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar los silabos de una asignatura.
        public DataTable BuscarSilabosAsignatura(string CodSemestre, string CodAsignatura)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarSilabosAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
            SqlDataAdapter Data = new SqlDataAdapter(Comando); 
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar el silabo de una asignatura.
        public DataTable MostrarSilaboAsignatura(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarSilaboAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // código (ej. IF065AIN), obtener de BuscarAsignaturasDocente
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar los planes de sesión de una asignatura.
        public DataTable BuscarPlanSesionesAsignatura(string CodSemestre, string CodAsignatura, string CodEscuelaP, string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarPlanSesionesAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar el plan de sesiones de un docente para una asignatura.
        public DataTable MostrarPlanSesionesAsignatura(string CodSemestre, string CodAsignatura, string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarPlanSesionesAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // código (ej. IF065AIN), obtener de BuscarAsignaturasDocente
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para insertar una asignatura en un catálogo.
        public void InsertarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarAsignaturaCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Catalogo.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", Catalogo.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Catalogo.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Grupo", Catalogo.Grupo);
            Comando.Parameters.AddWithValue("@CodDocente", Catalogo.CodDocente);
            Comando.Parameters.AddWithValue("@Silabo", Catalogo.Silabo);
            Comando.Parameters.AddWithValue("@PlanSesiones", Catalogo.PlanSesiones);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la información de una asignatura de un catálogo.
        public void ActualizarAsignaturaCatalogo(E_Catalogo Catalogo,
                                                 string NCodSemestre,   // Atributo nuevo
                                                 string NCodAsignatura, // Atributo nuevo
                                                 string NCodEscuelaP,   // Atributo nuevo
                                                 string NGrupo,         // Atributo nuevo
                                                 string NCodDocente)    // Atributo nuevo
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsignaturaCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Catalogo.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", Catalogo.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Catalogo.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Grupo", Catalogo.Grupo);
            Comando.Parameters.AddWithValue("@CodDocente", Catalogo.CodDocente);
            Comando.Parameters.AddWithValue("@NCodSemestre", NCodSemestre); 
            Comando.Parameters.AddWithValue("@NCodAsignatura", NCodAsignatura); 
            Comando.Parameters.AddWithValue("@NCodEscuelaP", NCodEscuelaP);
            Comando.Parameters.AddWithValue("@NGrupo", NGrupo);
            Comando.Parameters.AddWithValue("@NCodDocente", NCodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el silabo de una asignatura.
        public void ActualizarSilaboAsignatura(string CodSemestre, string CodAsignatura, string CodDocente, byte[] Silabo)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarSilaboAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // código (ej. IF065AIN), obtener de BuscarAsignaturasDocente
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Silabo", Silabo);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el plan de sesiones de una asignatura.
        public void ActualizarPlanSesionesAsignatura(string CodSemestre, string CodAsignatura, string CodDocente, byte[] PlanSesiones)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarPlanSesionesAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // código (ej. IF065AIN), obtener de BuscarAsignaturasDocente
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@PlanSesiones", PlanSesiones);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar una asignatura de un catálogo
        public void EliminarAsignaturaCatalogo(E_Catalogo Catalogo)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsignaturaCatalogo", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Catalogo.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", Catalogo.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Catalogo.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Grupo", Catalogo.Grupo);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
