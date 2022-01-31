class M_AsistenciaEstudiante:

    def __init__(self):
        self.CodSemestre = None
        self.CodEscuelaP = None
        self.CodAsignatura =None
        self.Fecha = None
        self.Hora = None
        self.CodEstudiante = None
        self.Asistio = None
        self.Observacion = None
    
class M_AsistenciaDocentePorAsignatura:

    def __init__(self):
        self.CodSemestre = None
        self.CodDepartamentoA = None
        self.CodAsignatura =None
        self.Fecha = None
        self.Hora = None
        self.CodDocente = None
        self.Asistio = None
        self.TipoSesion = None
        self.NombreTema = None
        self.Observacion = None

class M_AsistenciaDiariaDocente:

    def __init__(self):
        self.CodSemestre = None
        self.CodDepartamentoA = None
        self.Fecha = None
        self.Hora = None
        self.CodDocente = None
        self.Asistio = None
        self.Observacion = None