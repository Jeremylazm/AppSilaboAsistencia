# Script para el control de asistencia. 

import config, models, controls
from datetime import datetime

fecha_long = datetime.today()
fecha = fecha_long.date().strftime('%d/%m/%Y') # fecha hoy
hora = fecha_long.time().strftime('%H:%M:%S') # hora de ejecución del script
dia_index = datetime.today().isoweekday()
dia = {1:'LU', 2:'MA', 3:'MI', 4:'JU', 5:'VI', 6:'SA', 7:'D0'}

feriados = ['01/01/2022','14/04/2022','15/4/2022','01/05/2022','29/06/2022','28/07/2022','29/07/2022','30/08/2022','08/10/2022','01/11/2022','08/12/2022','09/12/2022','25/12/2022']

conn = config.conexion # establecer conexión con la DB
CodSemestre = controls.C_Semestre().SemestreActual(conn)[0][0]
DptosA = controls.C_DepartamentoA().MostrarDepartamentos(conn)

# Iterar para cada Departamento Académico:
for dpto in DptosA:   
    CodDptoA = dpto[0]
    objCatalogo = controls.C_Catalogo()
    HorarioAsistencia = controls.C_HorarioRegistroAsistencia().BuscarHorarioRegistroAsistencia(conn, CodSemestre, CodDptoA)
    if HorarioAsistencia != []:
        HoraRegistro = str(HorarioAsistencia[0][0])
        # Verificar la asistencia diaria de los docentes
        Docentes = controls.C_Docente().MostrarTodosDocentesDepartamento(conn, CodDptoA)
        for docente in Docentes:
            CodDocente = docente[0]
            # Buscar el registro de asistencia diaria de los docentes de la fecha actual
            AsistenciaDocente = controls.C_AsistenciaDiariaDocente().BuscarAsistenciaDocente(conn, CodSemestre, CodDptoA, fecha, CodDocente)
            if AsistenciaDocente == []: # Docente no marco asistencia
                objAsistenciaDocente = models.M_AsistenciaDiariaDocente()
                objAsistenciaDocente.CodSemestre = CodSemestre
                objAsistenciaDocente.CodDepartamentoA = CodDptoA
                objAsistenciaDocente.Fecha = fecha
                objAsistenciaDocente.Hora = HoraRegistro
                objAsistenciaDocente.CodDocente = CodDocente
                objAsistenciaDocente.Asistio = 'NO'
                if fecha in feriados:
                    objAsistenciaDocente.Observacion = 'FERIADO'
                else:            
                    objAsistenciaDocente.Observacion = 'FALTO SIN JUSTIFICAR'
                controls.C_AsistenciaDiariaDocente().RegistrarAsistenciaDiariaDocente(conn, objAsistenciaDocente)

        # Buscar las asignaturas que se dictan la fecha actual:
        AsignaturasHoy = objCatalogo.BuscarAsignaturasDiaHora(conn, CodSemestre, CodDptoA, dia[dia_index], '00:00:00', '23:59:59')   
        for row in AsignaturasHoy:       
            CodAsignatura = row[0] 
            CodDocente = row[1]
            HoraRegistro = row[2] + ':00:00'
            # Buscar el registro de asistencia diaria del docente:
            objAsistenciaDiaria = controls.C_AsistenciaDiariaDocente()
            AsistenciaDiariaDocente = objAsistenciaDiaria.BuscarAsistenciaDocente(conn, CodSemestre, CodDptoA, fecha, CodDocente)     
            # Buscar el registro de la sesión de la asignatura del dia (puede ser uno o más):
            Sesiones = controls.C_AsistenciaDocentePorAsignatura().MostrarAsistenciaDocenteAsignatura(conn, CodSemestre, CodDocente, CodAsignatura, fecha)      
            if Sesiones == []: # No existen registros
                # Marcar asistencia de los docentes por asignatura
                objAsistenciaDocente = models.M_AsistenciaDocentePorAsignatura()
                objAsistenciaDocente.CodSemestre = CodSemestre
                objAsistenciaDocente.CodDepartamentoA = CodDptoA
                objAsistenciaDocente.CodAsignatura = CodAsignatura
                objAsistenciaDocente.Fecha = fecha
                objAsistenciaDocente.Hora = HoraRegistro
                objAsistenciaDocente.CodDocente = CodDocente
                objAsistenciaDocente.Asistio = 'NO'
                objAsistenciaDocente.TipoSesion = ''
                objAsistenciaDocente.NombreTema = ''
                Observacion = AsistenciaDiariaDocente[0][6]
                if fecha in feriados:
                    objAsistenciaDocente.Observacion = 'FERIADO'
                else:
                    if Observacion == 'PERMISO': # Si Observación = PERMISO:
                        # Marcar asistencia docente por asignatura con PERMISO 
                        objAsistenciaDocente.Observacion = 'PERMISO'
                    if Observacion == '' or Observacion == 'FALTO SIN JUSTIFICAR': # Si Observación = '' o 'FALTO SIN JUSTIFICAR':
                        # Marcar asistencia docente por asignatura con FALTO SIN JUSTIFICAR
                        objAsistenciaDocente.Observacion = 'FALTO SIN JUSTIFICAR'           
    
                controls.C_AsistenciaDocentePorAsignatura().RegistrarAsistenciaDocentePorAsignatura(conn, objAsistenciaDocente)

                # Obtener la escuela profesional donde se dicta la asignatura:
                CodEscuelaP = controls.C_Catalogo().VerEscuelaAsignatura(conn, CodSemestre, CodAsignatura)[0][0]        
                # Marcar asistencia de los estudiantes con FALTO EL DOCENTE
                EstudiantesAsignatura = controls.C_Matricula().BuscarEstudiantesAsignatura(conn, CodSemestre, CodEscuelaP, CodAsignatura)
                for estudiante in EstudiantesAsignatura: 
                    CodEstudiante = estudiante[1] 
                    objAsistenciaEstudiante = models.M_AsistenciaEstudiante()         
                    objAsistenciaEstudiante.CodSemestre = CodSemestre
                    objAsistenciaEstudiante.CodEscuelaP = CodEscuelaP
                    objAsistenciaEstudiante.CodAsignatura = CodAsignatura
                    objAsistenciaEstudiante.Fecha = fecha
                    objAsistenciaEstudiante.Hora = HoraRegistro
                    objAsistenciaEstudiante.CodEstudiante = CodEstudiante
                    objAsistenciaEstudiante.Asistio = 'NO'
                    if fecha in feriados:
                        objAsistenciaEstudiante.Observacion = 'FERIADO'
                    else:
                        objAsistenciaEstudiante.Observacion = 'FALTO EL DOCENTE'
                    controls.C_AsistenciaEstudiante().RegistrarAsistenciaEstudiante(conn, objAsistenciaEstudiante)

conn.close() # cerrar conexión
