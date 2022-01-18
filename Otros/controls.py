class C_Semestre:

    # Método para mostrar el semestre actual. 
    def SemestreActual(self, conexion):
        cursor = conexion.cursor()
        query = """EXEC spuSemestreActual"""
        rows = None
        try:
            cursor.execute(query)
            row = cursor.fetchall()
        except Exception as e:
            print(e)

        return row

class C_DepartamentoA:

    # Método para mostrar la lista de departamentos académicos.
    def MostrarDepartamentos(self, conexion):
        cursor = conexion.cursor()
        query = """EXEC spuMostrarDepartamentos"""
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows

class C_Docente:
    
    # Método para mostrar todos los docentes de un departamento académico.
    def MostrarTodosDocentesDepartamento(self, conexion, CodDepartamentoA):
        cursor = conexion.cursor()
        params = (CodDepartamentoA)
        query = """EXEC spuMostrarTodosDocentesDepartamento @CodDepartamentoA = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows

class C_Catalogo:
    
    # Método para mostrar la escuela profesional donde se dicta una asignatura.
    def VerEscuelaAsignatura(self, conexion, CodSemestre, CodAsignatura):
        cursor = conexion.cursor()
        params = (CodSemestre, CodAsignatura)
        query = """EXEC spuVerEscuelaAsignatura @CodSemestre = '%s', @CodAsignatura = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows
    
    # Método para buscar las asignaturas que se dictan en un dia y un intervalo de tiempo.
    def BuscarAsignaturasDiaHora(self, conexion, CodSemestre, CodDepartamentoA, Dia, HoraInicio, HoraFin):
        cursor = conexion.cursor()
        params = (CodSemestre, CodDepartamentoA, Dia, HoraInicio, HoraFin)
        query = """EXEC spuBuscarAsignaturasDiaHora @CodSemestre = '%s', 
                                                    @CodDepartamentoA = '%s',
                                                    @Dia = '%s',
                                                    @HoraInicio = '%s',
                                                    @HoraFin = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows

class C_Matricula:
    
    # Método para buscar los estudiantes matriculados en una asignatura de un determinado semestre.
    def BuscarEstudiantesAsignatura(self, conexion, CodSemestre, CodEscuelaP, Texto):
        cursor = conexion.cursor()
        params = (CodSemestre, CodEscuelaP, Texto)
        query = """EXEC spuBuscarEstudiantesAsignatura @CodSemestre = '%s',
                                                       @CodEscuelaP = '%s',
                                                       @Texto = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows

class C_HorarioRegistroAsistencia:

    def BuscarHorarioRegistroAsistencia(self, conexion, CodSemestre, CodDepartamentoA):
        cursor = conexion.cursor()
        params = (CodSemestre, CodDepartamentoA)
        query = """EXEC spuBuscarHorarioRegistroAsistencia @CodSemestre = '%s',
                                                           @CodDepartamentoA = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows

class C_AsistenciaDocentePorAsignatura:
    
    # Método para mostrar el registro de asistencia de un docente para una asignatura en una fecha.
    def MostrarAsistenciaDocenteAsignatura(self, conexion, CodSemestre, CodDocente, CodAsignatura, Fecha):
        cursor = conexion.cursor()
        params = (CodSemestre, CodDocente, CodAsignatura, Fecha)
        query = """EXEC spuMostrarAsistenciaDocenteAsignatura @CodSemestre = '%s',
                                                              @CodDocente = '%s',
                                                              @CodAsignatura = '%s',
                                                              @Fecha = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows
    
    # Método para registrar la asistencia de un docente por asignatura.
    def RegistrarAsistenciaDocentePorAsignatura(self, conexion, obj):
        cursor = conexion.cursor()
        params = (obj.CodSemestre,  
                  obj.CodDepartamentoA,
                  obj.CodAsignatura,
                  obj.Fecha,
                  obj.Hora,
                  obj.CodDocente,
                  obj.Asistio,
                  obj.TipoSesion,
                  obj.NombreTema,
                  obj.Observacion)

        query = """EXEC spuRegistrarAsistenciaDocentePorAsignatura @CodSemestre = '%s', 
                                                                   @CodDepartamentoA = '%s',
                                                                   @CodAsignatura = '%s',
                                                                   @Fecha = '%s',
                                                                   @Hora = '%s',
                                                                   @CodDocente = '%s',
                                                                   @Asistió = '%s',
                                                                   @TipoSesión = '%s',
                                                                   @NombreTema = '%s',
                                                                   @Observación = '%s'""" % params
        try:
            cursor.execute(query)
            cursor.commit()
        except Exception as e:
            print(e)

class C_AsistenciaDiariaDocente:

    # Método para mostrar el registro de asistencia diaria de los docentes en una fecha especifica.
    def AsistenciaDiariaDocentes(self, conexion, CodSemestre, CodDepartamentoA, Fecha):
        cursor = conexion.cursor()
        params = (CodSemestre, CodDepartamentoA, Fecha)
        query = """EXEC spuBuscarAsistenciaDocente @CodSemestre = '%s',
                                                   @CodDepartamentoA = '%s',
                                                   @Fecha = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows 
    
    # Método para buscar el registro de asistencia de un docente en un dia.
    def BuscarAsistenciaDocente(self, conexion, CodSemestre, CodDepartamentoA, Fecha, CodDocente):
        cursor = conexion.cursor()
        params = (CodSemestre, CodDepartamentoA, Fecha, CodDocente)
        query = """EXEC spuBuscarAsistenciaDocente @CodSemestre = '%s',
                                                   @CodDepartamentoA = '%s',
                                                   @Fecha = '%s',
                                                   @CodDocente = '%s'""" % params
        rows = None
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
        except Exception as e:
            print(e)

        return rows
    
    # Método para registrar la asistencia diaria de un docente.
    def RegistrarAsistenciaDiariaDocente(self, conexion, obj):
        cursor = conexion.cursor()
        params = (obj.CodSemestre,  
                  obj.CodDepartamentoA,
                  obj.Fecha,
                  obj.Hora,
                  obj.CodDocente,
                  obj.Asistio,
                  obj.Observacion)

        query = """EXEC spuRegistrarAsistenciaDiariaDocente @CodSemestre = '%s', 
                                                            @CodDepartamentoA = '%s',
                                                            @Fecha = '%s',
                                                            @Hora = '%s',
                                                            @CodDocente = '%s',
                                                            @Asistió = '%s',
                                                            @Observación = '%s'""" % params
        try:
            cursor.execute(query)
            cursor.commit()
        except Exception as e:
            print(e)

class C_AsistenciaEstudiante:

    # Método para registrar la asistencia diaria de un estudiante.
    def RegistrarAsistenciaEstudiante(self, conexion, obj):
        cursor = conexion.cursor()
        params = (obj.CodSemestre,  
                  obj.CodEscuelaP,
                  obj.CodAsignatura,
                  obj.Fecha,
                  obj.Hora,
                  obj.CodEstudiante,
                  obj.Asistio,
                  obj.Observacion)
        query = """EXEC spuRegistrarAsistenciaEstudiante @CodSemestre = '%s', 
                                                         @CodEscuelaP = '%s',
                                                         @CodAsignatura = '%s',
                                                         @Fecha = '%s',
                                                         @Hora = '%s',
                                                         @CodEstudiante = '%s',
                                                         @Asistió = '%s',
                                                         @Observación = '%s'""" % params
        try:
            cursor.execute(query)
            cursor.commit()
        except Exception as e:
            print(e)