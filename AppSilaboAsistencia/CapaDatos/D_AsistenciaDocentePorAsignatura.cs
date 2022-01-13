using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_AsistenciaDocentePorAsignatura
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //readonly SqlConnection Conectar = new SqlConnection("Data Source=.;Initial Catalog=BDSistemaGestion;Integrated Security=True");

        // Método para mostrar el registro de asistencia de los docentes en una fecha especifica.
        public DataTable AsistenciaDocentesPorAsignatura(string CodSemestre, string CodDepartamentoA, string Fecha)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaDocentesPorAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA);
            Comando.Parameters.AddWithValue("@Fecha", Fecha); // Formato: dd/mm/yyyy o dd-mm-yyyy
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar los registros de las sesiones para una asignatura en un rango de fechas.
        public DataTable MostrarSesionesAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarSesionesAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para buscar un registro de una sesión para una asignatura dado el tema y en un rango de fechas.
        public DataTable BuscarSesionAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarSesionAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@Texto", Texto); // Tema de avance
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el registro de asistencia de un docente de una asignatura en un rango de fechas.
        public DataTable AsistenciaDocenteAsignatura(string CodSemestre, string CodDocente, string CodAsignatura, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaDocenteAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente); // código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el porcentaje de asistencia de los docentes de todas las asignaturas de un departamento académico
        public DataTable AsistenciaDocentesPorAsignaturas(string CodSemestre, string CodDepartamentoA, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaDocentesPorAsignaturas", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); // Atrib. Docente (Jefe Dpto.)
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el avance de los temas en una asignatura.
        public DataTable AvanceAsignatura(string CodSemestre, string CodDocente, string CodAsignatura)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAvanceAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura); // código (ej. IF085AIN)
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el avance de los temas en todas las asignaturas de un docente.
        public DataTable AvanceAsignaturasDocente(string CodSemestre, string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAvanceAsignaturasDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el avance de los temas en todas las asignaturas de un departamento académico.
        public DataTable AvanceAsignaturasDpto(string CodSemestre, string CodDepartamentoA)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAvanceAsignaturasDpto", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", CodDepartamentoA); // Atrib. Docente (Jefe de Dep.)
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para mostrar el porcentaje de asistencia de un docente para cada una de sus asignaturas.
        public DataTable AsistenciaAsignaturasDocente(string CodSemestre, string CodDocente, string LimFechaInf, string LimFechaSup)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuAsistenciaAsignaturasDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodSemestre", CodSemestre);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@LimFechaInf", LimFechaInf); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@LimFechaSup", LimFechaSup); // Formato: yyyy-mm-dd
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        // Método para registrar la asistencia de un docente.
        public void RegistrarAsistenciaDocentePorAsignatura(E_AsistenciaDocentePorAsignatura AsistenciaDocente)
        {
            SqlCommand Comando = new SqlCommand("spuRegistrarAsistenciaDocentePorAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodDepartamentoA", AsistenciaDocente.CodDepartamentoA);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura); // Código (ej. IF085AIN)
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha); // Formato: yyyy-mm-dd
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDocente.Hora); // Hora: hh:mm:ss
            Comando.Parameters.AddWithValue("@CodDocente", AsistenciaDocente.CodDocente);
            Comando.Parameters.AddWithValue("@Asistió", AsistenciaDocente.Asistio); // SI/NO
            Comando.Parameters.AddWithValue("@TipoSesión", AsistenciaDocente.TipoSesion); // NORMAL/RECUPERACIÓN
            Comando.Parameters.AddWithValue("@NombreTema", AsistenciaDocente.NombreTema);
            Comando.Parameters.AddWithValue("@Observación", AsistenciaDocente.Observacion);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para actualizar la asistencia de un docente:
        public void ActualizarAsistenciaDocentePorAsignatura(E_AsistenciaDocentePorAsignatura AsistenciaDocente, 
                                                string NTipoSesion,
                                                string NNombreTema,
                                                string NObservacion)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarAsistenciaDocentePorAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha);
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDocente.Hora);
            Comando.Parameters.AddWithValue("@NTipoSesión", NTipoSesion); // NORMAL/RECUPERACIÓN
            Comando.Parameters.AddWithValue("@NNombreTema", NNombreTema); // Nuevo Nombre Tema
            Comando.Parameters.AddWithValue("@NObservacion", NObservacion);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Método para eliminar la asistencia de un docente.
        public void EliminarAsistenciaDocentePorAsignatura(E_AsistenciaDocentePorAsignatura AsistenciaDocente)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarAsistenciaDocentePorAsignatura", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodSemestre", AsistenciaDocente.CodSemestre);
            Comando.Parameters.AddWithValue("@CodAsignatura", AsistenciaDocente.CodAsignatura);
            Comando.Parameters.AddWithValue("@Fecha", AsistenciaDocente.Fecha);
            Comando.Parameters.AddWithValue("@Hora", AsistenciaDocente.Hora);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
