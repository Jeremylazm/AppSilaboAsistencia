USE MASTER
GO

/* ********************************************************************
					    CREACION DE LA BASE DE DATOS
   ******************************************************************** */
IF EXISTS (SELECT * 
				FROM SYSDATABASES
				WHERE NAME = 'BDSistemaGestion')
	DROP DATABASE BDSistemaGestion
GO
CREATE DATABASE BDSistemaGestion
GO

USE BDSistemaGestion

-- Crear tipos de datos para las claves primarias
USE BDSistemaGestion
	EXEC SP_ADDTYPE tyCodEscuelaP,				'VARCHAR(4)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodDocente,				'VARCHAR(5)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodEstudiante,			'VARCHAR(6)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodAsignatura,			'VARCHAR(8)', 'NOT NULL'
	EXEC sp_addtype tyCodSemestre,				'VARCHAR(7)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodSilabo,				'VARCHAR(4)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodControlAsistencia,		'VARCHAR(5)', 'NOT NULL'
GO 

/* ********************************************************************
					        CREACION DE TABLAS
   ******************************************************************** */
USE BDSistemaGestion
GO

/* *************************** TABLA ESCUELA PROFESIONAL *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TEscuela_Profesional')
	DROP TABLE TEscuela_Profesional
GO
CREATE TABLE TEscuela_Profesional
(
	-- Lista de atributos
	CodEscuelaP tyCodEscuelaP,
	Nombre VARCHAR(40) NOT NULL,

	-- Determinar las claves 
	PRIMARY KEY (CodEscuelaP)
);
GO

/* *************************** TABLA ESTUDIANTE *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TEstudiante')
	DROP TABLE TEstudiante
GO
CREATE TABLE TEstudiante
(
	-- Lista de atributos
	Perfil VARBINARY(MAX),
	CodEstudiante tyCodEstudiante,
	APaterno VARCHAR(15) NOT NULL,
	AMaterno VARCHAR(15) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Telefono VARCHAR(15) NOT NULL,
	CodEscuelaP tyCodEscuelaP,

	-- Determinar las claves 
	PRIMARY KEY (CodEstudiante),
	CONSTRAINT FK_CodEscuelaPE FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuela_Profesional
		ON UPDATE CASCADE
);
GO

/* *************************** TABLA DOCENTE *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TDocente')
	DROP TABLE TDocente
GO
CREATE TABLE TDocente
(
	-- Lista de atributos
	Perfil VARBINARY(MAX),
	CodDocente tyCodDocente,
	APaterno VARCHAR(15) NOT NULL,
	AMaterno VARCHAR(15) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Telefono VARCHAR(15) NOT NULL,
	Categoria VARCHAR(10) NOT NULL CHECK (Categoria IN ('NOMBRADO', 
														'CONTRATADO')),
	Subcategoria VARCHAR(9) NOT NULL CHECK (Subcategoria IN ('PRINCIPAL', 
															 'ASOCIADO', 
															 'AUXILIAR', 
															 'A1',
															 'A2',
															 'A3',
															 'B1',
															 'B2',
															 'B3')),
	Regimen VARCHAR(20) NOT NULL CHECK (Regimen IN ('TIEMPO COMPLETO', 
													'DEDICACIÓN EXCLUSIVA',
													'TIEMPO PARCIAL')),
	CodEscuelaP tyCodEscuelaP,

	-- Determinar las claves 
	PRIMARY KEY (CodDocente),
	CONSTRAINT FK_CodEscuelaPD FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuela_Profesional
		ON UPDATE CASCADE
);
GO

/* *************************** TABLA ASIGNATURA *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TAsignatura')
	DROP TABLE TAsignatura
GO
CREATE TABLE TAsignatura
(
	-- Lista de atributos
	CodEscuelaP tyCodEscuelaP,
	CodAsignatura tyCodAsignatura,
	NombreAsignatura VARCHAR(50) NOT NULL,
	Creditos INT NOT NULL,
	Categoria VARCHAR(5) NOT NULL,
	HorasTeoria INT NOT NULL,
	HorasPractica INT NOT NULL,

	-- Determinar las claves
	PRIMARY KEY (CodEscuelaP, CodAsignatura),
	CONSTRAINT FK_CodEscuelaPA FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuela_Profesional
		ON UPDATE CASCADE
);
GO

/* *************************** TABLA CATALOGO *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TCatalogo')
	DROP TABLE TCatalogo
GO
CREATE TABLE TCatalogo
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodEscuelaP tyCodEscuelaP,
	CodAsignatura tyCodAsignatura,
	CodDocente tyCodDocente, -- Puede ser uno o más
	Silabo VARBINARY(MAX)

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodEscuelaP, CodAsignatura, CodDocente),
	CONSTRAINT FKC_CodAsignatura FOREIGN KEY (CodEscuelaP, CodAsignatura)
		REFERENCES TAsignatura
		ON UPDATE CASCADE,
	CONSTRAINT FKC_CodDocente FOREIGN KEY (CodDocente)
		REFERENCES TDocente
		ON UPDATE NO ACTION
);
GO

/* *************************** TABLA HORARIO-ASIGNATURA *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'THorarioAsignatura')
	DROP TABLE THorarioAsignatura
GO
CREATE TABLE THorarioAsignatura
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodEscuelaP tyCodEscuelaP,
	CodAsignatura tyCodAsignatura,
	CodDocente tyCodDocente,
	Dia VARCHAR(2), -- LU, MA, MI, JU, VI
	Horario VARCHAR(6) NOT NULL,-- Formato: 07-09
	Tipo CHAR(1) NOT NULL, -- T: Teoria, P: Práctica
	Aula VARCHAR(10) NOT NULL,
	Horas INT NOT NULL,
	Modalidad VARCHAR(10) NOT NULL, -- VIRTUAL, PRESENCIAL

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodEscuelaP, CodAsignatura, CodDocente, Dia),
	CONSTRAINT FKHA_CodCatalogo FOREIGN KEY (CodSemestre, CodEscuelaP, CodAsignatura, CodDocente)
		REFERENCES TCatalogo
		ON UPDATE CASCADE,
);
GO

/* *************************** TABLA MATRICULA *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TMatricula')
	DROP TABLE TMatricula
GO
CREATE TABLE TMatricula
(
	-- Lista de atributos
	IdMatricula INT IDENTITY(1,1),
	CodSemestre tyCodSemestre,
	CodEscuelaP tyCodEscuelaP,
	CodAsignatura tyCodAsignatura,
	CodEstudiante tyCodEstudiante,

	-- Determinar las claves
	PRIMARY KEY (IdMatricula),
	CONSTRAINT FKM_CodAsignatura FOREIGN KEY (CodEscuelaP, CodAsignatura)
		REFERENCES TAsignatura
		ON UPDATE CASCADE,
	CONSTRAINT FK_CodEstudiante FOREIGN KEY (CodEstudiante)
		REFERENCES TEstudiante
		ON UPDATE NO ACTION
);
GO

/* *************************** TABLA ASISTENCIA-DOCENTE *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TAsistenciaDocente')
	DROP TABLE TAsistenciaDocente
GO
CREATE TABLE TAsistenciaDocente
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodEscuelaP tyCodEscuelaP,
	CodAsignatura tyCodAsignatura,
	Fecha DATE NOT NULL,
	CodDocente tyCodDocente,
	NombreTema VARCHAR(100),

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodEscuelaP, CodAsignatura, Fecha),
	CONSTRAINT FKR_CodCatalogo FOREIGN KEY (CodSemestre, CodEscuelaP, CodAsignatura, CodDocente)
		REFERENCES TCatalogo
		ON UPDATE CASCADE
);
GO

/* *************************** TABLA ASISTENCIA-ESTUDIANTE*************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TAsistenciaEstudiante')
	DROP TABLE TAsistenciaEstudiante
GO
CREATE TABLE TAsistenciaEstudiante
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodEscuelaP tyCodEscuelaP,
	CodAsignatura tyCodAsignatura,
	Fecha DATE NOT NULL,
	CodEstudiante tyCodEstudiante,
	Estado VARCHAR(2) NOT NULL,  --SI/NO (Presente/No presente)
	Observación VARCHAR(25) -- tardanza, permisos

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodEscuelaP, CodAsignatura, Fecha, CodEstudiante),
	CONSTRAINT FK_CodAsistenciaDocente FOREIGN KEY (CodSemestre, CodEscuelaP, CodAsignatura, Fecha)
		REFERENCES TAsistenciaDocente
		ON UPDATE CASCADE,
);
GO

/* *************************** TABLA USUARIO *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TUsuario')
	DROP TABLE TUsuario
GO
CREATE TABLE TUsuario
(
	-- Lista de atributos
	Perfil VARBINARY(MAX),
	Usuario VARCHAR(6) NOT NULL,
	Contraseña VARBINARY(MAX) NOT NULL,
	Acceso VARCHAR(20) NOT NULL,
	Datos VARCHAR(53) NOT NULL,

	-- Definir la clave primaria
	PRIMARY KEY(Usuario)
)
GO

/* *************************** TABLA HISTORIAL *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'Historial')
	DROP TABLE Historial
GO
CREATE TABLE Historial
(
	-- Lista de atributos
	IdHistorial INT IDENTITY(1,1),
	Fecha DATETIME,
	Tabla VARCHAR(30),
	Operacion VARCHAR(15),
	IdRegistroAfectado VARCHAR(20),
	ValorAnterior VARCHAR(400),
	ValorPosterior VARCHAR(400),

	-- Definir la clave primaria
	PRIMARY KEY(IdHistorial)	
)
GO