using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Matricula
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar los estudiantes matriculados en un semestre de una escuela profesional.
        public DataTable MostrarEstudiantesMatriculados(string CodSemestre, string CodEscuelaP)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarEstudiantesMatriculados", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar estudiantes matriculados de una escuela profesional utilizando un filtro
        public DataTable BuscarEstudiantesMatriculados(string CodSemestre, string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantesMatriculados", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar las asignaturas a los que esta matriculado un estudiante.
        public DataTable BuscarAsignaturasEstudiante(string CodSemestre, string CodEscuelaP, string CodEstudiante)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarAsignaturasEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodEstudiante", CodEstudiante);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar buscar los estudiantes matriculados en una asignatura.
        public DataTable BuscarEstudiantesAsignatura(string CodSemestre, string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantesAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto); // código o nombre de la asignatura
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar buscar los estudiantes matriculados en una asignatura.
        public DataTable BuscarEstudiantesMatriculadosAsignatura(string CodSemestre, string CodEscuelaP, string CodAsignatura, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantesMatriculadosAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // código o nombre de la asignatura
            Comando.Parameters.AddWithValue("@Texto", Texto); // dato del estudiante
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para insertar un nuevo registro de una matricula en la dase de datos.
        public void InsertarMatricula(E_Matricula Matricula)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarMatricula", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Matricula.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Matricula.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Matricula.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEstudiante", Matricula.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Matricula.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Matricula.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Matricula.Nombre);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar el registro de una matricula de la base de datos.
        public void ActualizarMatricula(E_Matricula Matricula)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarMatricula", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Matricula.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Matricula.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Matricula.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEstudiante", Matricula.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Matricula.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Matricula.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Matricula.Nombre);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar el registro de una matricula de la base de datos.
        public void EliminarMatricula(E_Matricula Matricula)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarMatricula", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", Matricula.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Matricula.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", Matricula.CodAsignatura);
            Comando.Parameters.AddWithValue("@CodEstudiante", Matricula.CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
