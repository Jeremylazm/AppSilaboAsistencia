using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_AsistenciaEstudiante
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar el registro de asistencia de los estudiantes de una asignatura en una fecha y hora especifica.
        public DataTable AsistenciaEstudiantes(string CodSemestre, string CodAsignatura, string Fecha, string Hora)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@Fecha", Fecha); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@Hora", Hora); // Formato: hh:mm:ss (Hora del control de asistencia)
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el registro de asistencia de un estudiante de una asignatura en un rango de fechas.
        public DataTable AsistenciaEstudianteAsignatura(string CodSemestre, string CodEstudiante, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaEstudianteAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEstudiante", CodEstudiante);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: dd/mm/yyyy o dd-mm-yyyy
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar la asistencia de los estudiantes de una asignatura por fechas en un rango.
        public DataTable AsistenciaEstudiantesPorFechas(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaEstudiantesPorFechas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: dd/mm/yyyy o dd-mm-yyyy
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar las asistencia de los estudiantes de una asignatura en un rango de fechas
        public DataTable AsistenciaEstudiantesPorEstudiante(string CodSemestre, string CodAsignatura, string CodDocente, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaEstudiantesPorEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: dd/mm/yyyy o dd-mm-yyyy
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el porcentaje de asistencia de los estudiantes de todas las asignaturas de una dpto academico.
        public DataTable AsistenciaEstudiantesPorAsignaturas(string CodSemestre, string CodDepartamentoA, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaEstudiantesPorAsignaturas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.CommandTimeout = 60;

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); // Atrib. Docente (Director Escuela)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: dd/mm/yyyy o dd-mm-yyyy
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el porcentaje de asistencia de un estudiante para cada una de sus asignaturas.
        public DataTable AsistenciaAsignaturasEstudiante(string CodSemestre, string CodEstudiante, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaAsignaturasEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodEstudiante",CodEstudiante);
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: dd/mm/yyyy o dd-mm-yyyy
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para registrar la asistencia de un estudiante.
        public void RegistrarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            SqlCommand Comando = new SqlCommand("spuRegistrarAsistenciaEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaEstudiante.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", AsistenciaEstudiante.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaEstudiante.CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaEstudiante.Fecha); // Formato: dd/mm/yyyy o dd-mm-yyyy
            Comando.Parameters.AddWithValue("@Hora", AsistenciaEstudiante.Hora); // Formato: hh: mm: ss (Hora del control de asistencia)
            Comando.Parameters.AddWithValue("@CodEstudiante", AsistenciaEstudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@Asistió", AsistenciaEstudiante.Asistio); // SI/NO (Presente/No presente)
            Comando.Parameters.AddWithValue("@Observación", AsistenciaEstudiante.Observacion); // tardanza, permiso
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la asistencia de un estudiante.
        public void ActualizarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante, string NAsistio, string NObservacion)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsistenciaEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaEstudiante.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", AsistenciaEstudiante.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaEstudiante.CodAsignatura);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaEstudiante.Fecha); 
            Comando.Parameters.AddWithValue("@Hora", AsistenciaEstudiante.Hora); 
            Comando.Parameters.AddWithValue("@CodEstudiante", AsistenciaEstudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@NAsistió", NAsistio); 
            Comando.Parameters.AddWithValue("@NObservación", NObservacion); 
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar la asistencia de un estudiante.
        public void EliminarAsistenciaEstudiante(E_AsistenciaEstudiante AsistenciaEstudiante)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsistenciaEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaEstudiante.CodSemestre);
            Comando.Parameters.AddWithValue("@CodEscuelaP", AsistenciaEstudiante.CodEscuelaP);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaEstudiante.CodAsignatura);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaEstudiante.Fecha);
            Comando.Parameters.AddWithValue("@Hora", AsistenciaEstudiante.Hora); 
            Comando.Parameters.AddWithValue("@CodEstudiante", AsistenciaEstudiante.CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
