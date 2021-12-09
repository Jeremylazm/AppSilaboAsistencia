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
	EXEC SP_ADDTYPE tyCodEscuelaP,				'VARCHAR(3)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodDepartamentoA,		    'VARCHAR(3)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodDocente,				'VARCHAR(5)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodEstudiante,			'VARCHAR(6)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodAsignatura,			'VARCHAR(6)', 'NOT NULL'
	EXEC sp_addtype tyCodSemestre,				'VARCHAR(7)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodSilabo,				'VARCHAR(4)', 'NOT NULL'
GO 

/* ********************************************************************
					        CREACION DE TABLAS
   ******************************************************************** */
USE BDSistemaGestion
GO

/* ********************* TABLA ESCUELA-PROFESIONAL ********************* */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TEscuelaProfesional')
	DROP TABLE TEscuelaProfesional
GO
CREATE TABLE TEscuelaProfesional
(
	-- Lista de atributos
	CodEscuelaP tyCodEscuelaP,
	Nombre VARCHAR(80) NOT NULL,

	-- Determinar las claves 
	PRIMARY KEY (CodEscuelaP)
);
GO

/* ********************* TABLA DEPARTAMENTO-ACADEMICO ********************* */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TDepartamentoAcademico')
	DROP TABLE TDepartamentoAcademico
GO
CREATE TABLE TDepartamentoAcademico
(
	-- Lista de atributos
	CodDepartamentoA tyCodDepartamentoA,

	Nombre VARCHAR(80) NOT NULL,

	-- Determinar las claves 
	PRIMARY KEY (CodDepartamentoA)
);
GO

/* ************************* TABLA ESTUDIANTE ************************** */
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
	APaterno VARCHAR(35) NOT NULL,
	AMaterno VARCHAR(35) NOT NULL,
	Nombre VARCHAR(35) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Telefono VARCHAR(15) NOT NULL,
	CodEscuelaP tyCodEscuelaP

	-- Determinar las claves 
	PRIMARY KEY (CodEstudiante),
	CONSTRAINT FKE_CodEscuelaP FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuelaProfesional
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
	APaterno VARCHAR(35) NOT NULL,
	AMaterno VARCHAR(35) NOT NULL,
	Nombre VARCHAR(35) NOT NULL,
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
	CodDepartamentoA tyCodDepartamentoA,
	CodEscuelaP tyCodEscuelaP

	-- Determinar las claves 
	PRIMARY KEY (CodDocente),
	CONSTRAINT FK_CodDepartamentoA FOREIGN KEY (CodDepartamentoA)
		REFERENCES TDepartamentoAcademico
		ON UPDATE CASCADE,
	CONSTRAINT FKD_CodEscuelaP FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuelaProfesional
		ON UPDATE CASCADE
);
GO

/* ************************** TABLA ASIGNATURA ************************* */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TAsignatura')
	DROP TABLE TAsignatura
GO
CREATE TABLE TAsignatura
(
	-- Lista de atributos
	CodAsignatura tyCodAsignatura, -- ej. IF085
	NombreAsignatura VARCHAR(100) NOT NULL,
	Creditos INT NOT NULL,
	Categoria VARCHAR(5) NOT NULL,
	HorasTeoria INT NOT NULL,
	HorasPractica INT NOT NULL,
	Prerrequisito VARCHAR(25),
	Sumilla VARCHAR(2000) NOT NULL

	-- Determinar las claves
	PRIMARY KEY (CodAsignatura)
);
GO

/* ************************** TABLA CATALOGO *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TCatalogo')
	DROP TABLE TCatalogo
GO
CREATE TABLE TCatalogo
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodAsignatura tyCodAsignatura, -- ej. IF085
	CodEscuelaP tyCodEscuelaP, -- EP donde se enseña la asignatura
	Grupo VARCHAR(1) NOT NULL,
	CodDocente tyCodDocente, -- Puede ser uno o más
	Silabo VARBINARY(MAX),
	PlanSesiones VARBINARY(MAX)

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodAsignatura, CodEscuelaP, Grupo, CodDocente),
	CONSTRAINT FK_CodAsignatura FOREIGN KEY (CodAsignatura)
		REFERENCES TAsignatura
		ON UPDATE CASCADE,
	CONSTRAINT FKC_CodDocente FOREIGN KEY (CodDocente)
		REFERENCES TDocente
		ON UPDATE NO ACTION
);
GO

/* ********************** TABLA HORARIO-ASIGNATURA ********************* */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'THorarioAsignatura')
	DROP TABLE THorarioAsignatura
GO
CREATE TABLE THorarioAsignatura
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodAsignatura tyCodAsignatura, -- ej. IF085
	CodEscuelaP tyCodEscuelaP, -- EP donde se enseña la asignatura
	Grupo VARCHAR(1) NOT NULL,
	CodDocente tyCodDocente, -- Puede ser uno o más
	Dia VARCHAR(2), -- LU, MA, MI, JU, VI
	Tipo VARCHAR(1) NOT NULL, -- T: Teoria, P: Práctica
	HorasTeoria INT NOT NULL,
	HorasPractica INT NOT NULL,
	HoraInicio VARCHAR(2) NOT NULL, -- Formato: 00-23
	HoraFin VARCHAR(2) NOT NULL, -- Formato: 00-23
	Aula VARCHAR(10) NOT NULL,
	Modalidad VARCHAR(10) NOT NULL -- VIRTUAL, PRESENCIAL

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodAsignatura, CodEscuelaP, Grupo, CodDocente, Dia),
	CONSTRAINT FKHA_CodCatalogo FOREIGN KEY (CodSemestre, CodAsignatura, CodEscuelaP, Grupo, CodDocente)
		REFERENCES TCatalogo
		ON UPDATE CASCADE,
);
GO

/* ************************** TABLA MATRICULA ************************** */
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
	CodAsignatura VARCHAR(9), -- ej. IF085AIN
	CodEstudiante tyCodEstudiante

	-- Determinar las claves
	PRIMARY KEY (IdMatricula),
	CONSTRAINT FKM_CodEscuelaP FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuelaProfesional
		ON UPDATE CASCADE,
	CONSTRAINT FK_CodEstudiante FOREIGN KEY (CodEstudiante)
		REFERENCES TEstudiante
		ON UPDATE NO ACTION
);
GO

/* ********************* TABLA ASISTENCIA-DOCENTE ********************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TAsistenciaDocente')
	DROP TABLE TAsistenciaDocente
GO
CREATE TABLE TAsistenciaDocente
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodAsignatura VARCHAR(9) NOT NULL, -- ej. IF085AIN
	HoraInicio VARCHAR(2) NOT NULL, -- Formato: 00-23 (Hora de inicio de la asignatura en el catálogo)
	Fecha DATE NOT NULL,   -- Formato: yyyy-mm-dd
	Hora TIME(0) NOT NULL, -- Formato: hh:mm:ss (Hora del control de asistencia)
	CodDocente tyCodDocente NOT NULL,
	NombreTema VARCHAR(100)

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodAsignatura, HoraInicio, Fecha),
	CONSTRAINT FKAD_CodDocente FOREIGN KEY (CodDocente)
		REFERENCES TDocente
		ON UPDATE NO ACTION
);
GO

/* ********************* TABLA ASISTENCIA-ESTUDIANTE ******************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TAsistenciaEstudiante')
	DROP TABLE TAsistenciaEstudiante
GO
CREATE TABLE TAsistenciaEstudiante
(
	-- Lista de atributos
	CodSemestre tyCodSemestre,
	CodAsignatura VARCHAR(9) NOT NULL, -- ej. IF085AIN
	HoraInicio VARCHAR(2) NOT NULL, -- Formato: 00-23 (Hora de inicio de la asignatura en el catálogo)
	Fecha DATE NOT NULL,   -- Formato: yyyy-mm-dd
	Hora TIME(0) NOT NULL, -- Formato: hh:mm:ss (Hora del control de asistencia)
	CodEstudiante tyCodEstudiante NOT NULL,
	Estado VARCHAR(2) NOT NULL,  -- SI/NO (Presente/No presente)
	Observación VARCHAR(25) -- tardanza, permisos

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodAsignatura, HoraInicio, Fecha, CodEstudiante),
	CONSTRAINT FK_CodAsistenciaDocente FOREIGN KEY (CodSemestre, CodAsignatura, HoraInicio, Fecha)
		REFERENCES TAsistenciaDocente
		ON UPDATE CASCADE,
);

/* *************************** TABLA RECURSOS *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TRecursos')
	DROP TABLE TRecursos
GO
CREATE TABLE TRecursos
(
	-- Lista de atributos
	IdRecurso INT IDENTITY(1, 1),
	PlantillaSilabo VARBINARY(MAX),
	PlantillaPlanSesiones2y3 VARBINARY(MAX),
	PlantillaPlanSesiones4 VARBINARY(MAX)

	-- Definir la clave primaria
	PRIMARY KEY(IdRecurso)
)
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
	Datos VARCHAR(53) NOT NULL

	-- Definir la clave primaria
	PRIMARY KEY(Usuario)
)
GO

/* ************************** TABLA HISTORIAL ************************** */
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

/* **************************************************************************************************
   ******************* FUNCIONES Y PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS********************
   ************************************************************************************************** */

/* ****************** FUNCIONES PARA LA ENCRIPTACION DE LA CONTRASEÑA ****************** */
USE BDSistemaGestion
GO
-- Crear una llave asimetrica
CREATE ASYMMETRIC KEY AppSistemaGestionAsymKey01
    WITH ALGORITHM = RSA_2048
    ENCRYPTION BY PASSWORD = 'IngenieriaSoftwareI';   
GO

-- Funcion encriptar --
CREATE FUNCTION fnEncriptarContraseña(@Contraseña Varchar(8))
RETURNS VARBINARY(max)
AS
BEGIN
	-- Declarar las variables
    DECLARE @EncryptedText VARBINARY(max)

	-- Generar contraseña encriptada
	SET @EncryptedText=ENCRYPTBYASYMKEY(ASYMKEY_ID(N'AppSistemaGestionAsymKey01'), @Contraseña)

	-- Retornar una contrasenia varbinary
    RETURN (@EncryptedText);
END;
GO
-- Funcion desencriptar --
CREATE FUNCTION fnDesencriptarContraseña(@EncryptedText VARBINARY(max))
RETURNS VARCHAR(8)
AS
BEGIN
	-- Declarar las variables
    DECLARE @DecryptedText VARCHAR(MAX)

	-- Generar contraseña desencriptada
	SET @DecryptedText=DECRYPTBYASYMKEY (ASYMKEY_ID(N'AppSistemaGestionAsymKey01'),@EncryptedText, N'IngenieriaSoftwareI')

	-- Retornar una contrasenia desencriptada
    RETURN (@DecryptedText);
END;
GO

/* ************************** FUNCION PARA GENERAR UNA CONTRASEÑA ************************** */

CREATE VIEW viAleatorio
AS
	-- Generar un numero aleatorio
	SELECT RAND() AS ValorAleatorio
GO 

CREATE FUNCTION fnGenerarContraseña ()
RETURNS VARCHAR(8)
AS
BEGIN
	-- Declarar las variables necesarias
	DECLARE @Indice INT;
    DECLARE @Contador INT;
    DECLARE @Caracteres VARCHAR(37);      
    DECLARE @Contraseña VARCHAR(8);

	-- Establecer los valores iniciales
	SET @Contador = 0
	SET @Caracteres = 'ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789'
	SET @Contraseña = ''
    
	-- Tomar un indice aleatorio de los caracteres para generar una contraseña
    WHILE (@Contador < 8)
    BEGIN
        SET @Indice = CEILING((SELECT ValorAleatorio FROM viAleatorio) * (LEN(@Caracteres)))
        SET @Contraseña = @Contraseña + SUBSTRING(@Caracteres, @Indice, 1)
        SET @Contador = @Contador + 1
    END;

	-- Retornar una contraseña de 8 caracteres
    RETURN (@Contraseña);
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA USUARIO ****************** */
USE BDSistemaGestion
GO
-- Procedimiento insertar nuevo usuario, encripta la contraseña
CREATE PROCEDURE spuInsertarUsuario	@Perfil VARBINARY(MAX),
									@Usuario VARCHAR(6),
									@Contraseña VARCHAR(8),
									@Acceso VARCHAR(20),
									@Datos VARCHAR(53)
AS
BEGIN
	-- Actualizar un estudiante de la tabla de TEstudiante
	Insert INTO TUsuario values(@Perfil,@Usuario, DBO.fnEncriptarContraseña(@Contraseña),@Acceso,@Datos)
END;
GO

-- Cambiar contraseña de usuario --
CREATE PROCEDURE spuCambiarContraseña @Usuario VARCHAR(6),
									  @NuevaContrasenia VARCHAR(8)
AS
BEGIN
	-- Actualizar contraseña de Usuario
	UPDATE TUsuario
		SET Contraseña = DBO.fnEncriptarContraseña(@NuevaContrasenia)
		WHERE Usuario = @Usuario
END;
GO
-- Retornar contraseña desencriptada
CREATE PROCEDURE spuRetornarContraseña @Usuario VARCHAR(6)			
AS
BEGIN
	-- Actualizar un estudiante de la tabla de TEstudiante
	SELECT DBO.fnDesencriptarContraseña(Contraseña) as 'Contraseña'
		FROM TUsuario
		WHERE Usuario = @Usuario
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ESCUELA PROFESIONAL ****************** */

-- Procedimiento para mostrar la lista de escuelas profesionales.
CREATE PROCEDURE spuMostrarEscuelas 
AS
BEGIN
	-- Mostrar la tabla TEscuelaProfesional
	SELECT * FROM TEscuelaProfesional
END;
GO

-- Procedimiento para buscar el nombre de una escuela profesional.
CREATE PROCEDURE spuBuscarNombreEscuela @CodEscuelaP VARCHAR(3) 
AS
BEGIN
	-- Mostrar el nombre de la escuela profesional
	SELECT Nombre
		FROM TEscuelaProfesional
		WHERE CodEscuelaP = @CodEscuelaP
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA DEPARTAMENTO ACADEMICO ****************** */

-- Procedimiento para mostrar la lista de departamentos académicos.
CREATE PROCEDURE spuMostrarDepartamentos 
AS
BEGIN
	-- Mostrar la tabla TDepartamentoAcademico
	SELECT * FROM TDepartamentoAcademico
END;
GO

-- Procedimiento para buscar el nombre de un departamento académico.
CREATE PROCEDURE spuBuscarNombreDepartamento @CodDepartamentoA VARCHAR(3) 
AS
BEGIN
	-- Mostrar el nombre del departamento académico.
	SELECT Nombre
		FROM TDepartamentoAcademico
		WHERE CodDepartamentoA = @CodDepartamentoA
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ESTUDIANTE ****************** */

-- Procedimiento para mostrar los estudiantes de una escuela profesional. 
CREATE PROCEDURE spuMostrarEstudiantes @CodEscuelaP VARCHAR(3)
AS
BEGIN
	-- Mostrar la tabla TEstudiante
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodEstudiante, APaterno, AMaterno, Nombre, Email, Direccion, Telefono
		FROM TEstudiante 
	    WHERE CodEscuelaP = @CodEscuelaP
END;
GO

-- Procedimiento para buscar un estudiante (por su código) de una escuela profesional.
CREATE PROCEDURE spuBuscarEstudiante @CodEscuelaP VARCHAR(3),
									 @CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Mostrar la información del estudiante
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodEstudiante, APaterno, AMaterno, Nombre, Email, Direccion, Telefono
		FROM TEstudiante
		WHERE CodEscuelaP = @CodEscuelaP AND CodEstudiante = @CodEstudiante
END;
GO

-- Procedimiento para buscar por cualquier atributo los estudiantes de una escuela profesional.
CREATE PROCEDURE spuBuscarEstudiantes @CodEscuelaP VARCHAR(3),
									  @Texto VARCHAR(35)
AS
BEGIN
	-- Mostrar la tabla TEstudiante por el texto que se desea buscar
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodEstudiante, APaterno, AMaterno, Nombre, Email, Direccion, Telefono
		FROM TEstudiante
		WHERE CodEscuelaP = @CodEscuelaP AND
		     (CodEstudiante LIKE (@Texto + '%') OR
			  APaterno LIKE (@Texto + '%') OR
			  AMaterno LIKE (@Texto + '%') OR
			  Nombre LIKE (@Texto + '%') OR
			  Email LIKE (@Texto + '%') OR
			  Direccion LIKE (@Texto + '%') OR
			  Telefono LIKE (@Texto + '%'))
END;
GO

-- Procedimiento para insertar un estudiante.
CREATE PROCEDURE spuInsertarEstudiante @Perfil VARBINARY(MAX),
									   @CodEstudiante VARCHAR(6),
									   @APaterno VARCHAR(35),
									   @AMaterno VARCHAR(35),
									   @Nombre VARCHAR(35),
									   @Email VARCHAR(50),
									   @Direccion VARCHAR(50),
									   @Telefono VARCHAR(15),
									   @CodEscuelaP VARCHAR(3)
AS
BEGIN
	-- Insertar un estudiante en la tabla TEstudiante
	INSERT INTO TEstudiante
		VALUES (@Perfil, @CodEstudiante, @APaterno, @AMaterno, @Nombre, @Email, @Direccion, @Telefono, @CodEscuelaP)
END;
GO

-- Procedimiento para actualizar un estudiante.
CREATE PROCEDURE spuActualizarEstudiante @Perfil VARBINARY(MAX),
										 @CodEstudiante VARCHAR(6),
										 @APaterno VARCHAR(35),
										 @AMaterno VARCHAR(35),
										 @Nombre VARCHAR(35),
										 @Email VARCHAR(50),
										 @Direccion VARCHAR(50),
										 @Telefono VARCHAR(15),
										 @CodEscuelaP VARCHAR(3)					
AS
BEGIN
	-- Actualizar un estudiante de la tabla TEstudiante
	UPDATE TEstudiante
		SET Perfil = @Perfil,
		    CodEstudiante = @CodEstudiante,
			APaterno = @APaterno,
			AMaterno = @AMaterno,
			Nombre = @Nombre, 
		    Email = @Email,
			Direccion = @Direccion,
			Telefono = @Telefono,
			CodEscuelaP = @CodEscuelaP

		WHERE CodEstudiante = @CodEstudiante
END;
GO

-- Procedimiento para eliminar un estudiante.
CREATE PROCEDURE spuEliminarEstudiante @CodEstudiante VARCHAR(6)					
AS
BEGIN
	-- Eliminar un estudiante de la tabla TEstudiante
	DELETE FROM TEstudiante
		WHERE CodEstudiante = @CodEstudiante
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA DOCENTE ****************** */

-- Procedimiento para mostrar los docentes de una escuela profesional.
CREATE PROCEDURE spuMostrarDocentesEscuela @CodEscuelaP VARCHAR(3)
AS
BEGIN
	-- Mostrar la tabla TDocente
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
	    WHERE CodEscuelaP = @CodEscuelaP AND CodDocente != '00000'
		ORDER BY APaterno
END;
GO

-- Procedimiento para mostrar todos los docentes de una escuela profesional.
CREATE PROCEDURE spuMostrarTodosDocentesDepartamento @CodDepartamentoA VARCHAR(3)
AS
BEGIN
	-- Mostrar la tabla TDocente
	SELECT CodDocente, Nombre
		FROM TDocente
	    WHERE CodDepartamentoA = @CodDepartamentoA
		ORDER BY APaterno
END;
GO

-- Procedimiento para mostrar los docentes de un departamento académico.
CREATE PROCEDURE spuMostrarDocentesDepartamento @CodDepartamentoA VARCHAR(3)
AS
BEGIN
	-- Mostrar la tabla TDocente
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
	    WHERE CodDepartamentoA = @CodDepartamentoA AND CodDocente != '00000'
		ORDER BY APaterno
END;
GO

-- Procedimiento para buscar un docente (por su código) de un departamento académico.
CREATE PROCEDURE spuBuscarDocente @CodDepartamentoA VARCHAR(3),
								  @CodDocente VARCHAR(5)
AS
BEGIN
	-- Mostrar la información del docente
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
		WHERE CodDepartamentoA = @CodDepartamentoA AND CodDocente = @CodDocente AND CodDocente != '00000'
END;
GO

-- Procedimiento para buscar por cualquier atributo los docentes de un departamento académico.
CREATE PROCEDURE spuBuscarDocentes @CodDepartamentoA VARCHAR(3),
								   @Texto VARCHAR(35)
AS
BEGIN
	-- Mostrar la tabla TDocente por el texto que se desea buscar
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
		WHERE CodDepartamentoA = @CodDepartamentoA AND @Texto != '00000' AND
		     (CodDocente LIKE (@Texto + '%') OR
			  APaterno LIKE (@Texto + '%') OR
			  AMaterno LIKE (@Texto + '%') OR
			  Nombre LIKE (@Texto + '%') OR
			  Email LIKE (@Texto + '%') OR
			  Direccion LIKE (@Texto + '%') OR
			  Telefono LIKE (@Texto + '%') OR
			  Categoria LIKE (@Texto + '%') OR
			  Subcategoria LIKE (@Texto + '%') OR
			  Regimen LIKE (@Texto + '%') OR
			  CodEscuelaP LIKE (@Texto + '%') )
END;
GO

--Procedimiento para obtener el código de un docente por su nombre.
CREATE PROCEDURE spuObtenerCodigoDocente @Nombre VARCHAR(50)
AS
BEGIN
	--Obtener el código de la asignatura
	SELECT CodDocente
		FROM TDocente
		WHERE Nombre = @Nombre
END;
GO

-- Procedimiento para insertar un docente.
CREATE PROCEDURE spuInsertarDocente @Perfil VARBINARY(MAX),
									@CodDocente VARCHAR(5),
									@APaterno VARCHAR(35),
									@AMaterno VARCHAR(35),
									@Nombre VARCHAR(35),
									@Email VARCHAR(50),
									@Direccion VARCHAR(50),
									@Telefono VARCHAR(15),
									@Categoria VARCHAR(10),
									@Subcategoria VARCHAR(9),
									@Regimen VARCHAR(20),
									@CodDepartamentoA VARCHAR(3),
									@CodEscuelaP VARCHAR(3)
AS
BEGIN
	-- Insertar un docente en la tabla TDocente
	INSERT INTO TDocente
		VALUES (@Perfil, @CodDocente, @APaterno, @AMaterno, @Nombre, @Email, @Direccion, @Telefono, @Categoria, @Subcategoria,
         		@Regimen, @CodDepartamentoA, @CodEscuelaP)

	-- Insertar un usuario con el codigo del docente en la tabla TUsuario
	DECLARE @Datos VARCHAR(53);
	DECLARE @Contraseña VARCHAR(8);
	SET @Datos = CONCAT(@APaterno, ' ', @AMaterno, ', ', @Nombre);
	SET @Contraseña = @CodDocente;
	EXEC DBO.spuInsertarUsuario @Perfil, @CodDocente, @Contraseña, 'Docente', @Datos
END;
GO

-- Procedimiento para actualizar un docente.
CREATE PROCEDURE spuActualizarDocente @Perfil VARBINARY(MAX),
									  @CodDocente VARCHAR(5),
									  @APaterno VARCHAR(35),
									  @AMaterno VARCHAR(35),
									  @Nombre VARCHAR(35),
									  @Email VARCHAR(50),
									  @Direccion VARCHAR(50),
									  @Telefono VARCHAR(15),
									  @Categoria VARCHAR(10),
									  @Subcategoria VARCHAR(9),
									  @Regimen VARCHAR(20),
									  @CodDepartamentoA VARCHAR(3),
									  @CodEscuelaP VARCHAR(3)				
AS
BEGIN
	-- Actualizar un docente de la tabla TDocente
	UPDATE TDocente
		SET Perfil = @Perfil,
		    CodDocente = @CodDocente,
			APaterno = @APaterno,
			AMaterno = @AMaterno,
			Nombre = @Nombre, 
		    Email = @Email,
			Direccion = @Direccion,
			Telefono = @Telefono,
			Categoria = @Categoria,
			Subcategoria = @Subcategoria, 
			Regimen = @Regimen,
			CodDepartamentoA = @CodDepartamentoA,
			CodEscuelaP = @CodEscuelaP

		WHERE CodDocente = @CodDocente

	-- Actualizar un docente de la tabla TUsuario
	UPDATE TUsuario
		SET Perfil = @Perfil, Usuario = @CodDocente, 
			Datos = @APaterno + ' ' + @AMaterno + ', ' + @Nombre
		WHERE Usuario = @CodDocente
END;
GO

-- Procedimiento para eliminar un docente.
CREATE PROCEDURE spuEliminarDocente @CodDocente VARCHAR(5)					
AS
BEGIN
	-- Eliminar un docente de la tabla TDocente
	DELETE FROM TDocente
		WHERE CodDocente = @CodDocente

	-- Eliminar el usuario docente de la tabla TUsuario
	DELETE FROM TUsuario
		WHERE Usuario = @CodDocente
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ASIGNATURA ****************** */

-- Procedimiento para mostrar las asignaturas de un departamento académico.
CREATE PROCEDURE spuMostrarAsignaturas @CodDepartamento VARCHAR(3)
AS
BEGIN	
	-- Mostrar la tabla TAsignatura
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica, Prerrequisito, Sumilla
		FROM TAsignatura
	    WHERE SUBSTRING(CodAsignatura,1,2) = @CodDepartamento
		ORDER BY NombreAsignatura
END;
GO

-- Procedimiento para buscar una asignatura.
CREATE PROCEDURE spuBuscarAsignatura @CodDepartamento VARCHAR(3),
									 @CodAsignatura VARCHAR(6)
AS
BEGIN
	-- Mostrar la tabla TAsignatura por el texto que se desea buscar
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica, Prerrequisito, Sumilla
		FROM TAsignatura
		WHERE SUBSTRING(CodAsignatura,1,2) = @CodDepartamento AND CodAsignatura = @CodAsignatura
END;
GO

-- Procedimiento para buscar por cualquier atributo las asignaturas de un departamento académico.
CREATE PROCEDURE spuBuscarAsignaturas @CodDepartamento VARCHAR(3),
									  @Texto VARCHAR(100)
AS
BEGIN
	-- Mostrar la tabla TAsignatura por el texto que se desea buscar
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica, Prerrequisito, Sumilla
		FROM TAsignatura
		WHERE SUBSTRING(CodAsignatura,1,2) = @CodDepartamento AND 
			 (CodAsignatura LIKE (@Texto + '%') OR
			  NombreAsignatura LIKE (@Texto + '%') OR
			  Creditos LIKE (@Texto + '%') OR
			  Categoria LIKE (@Texto + '%') OR
			  HorasTeoria LIKE (@Texto + '%') OR
			  HorasPractica LIKE (@Texto + '%'))
			 
END;
GO

--Procedimiento para obtener las horas de teoría y práctica de una asignatura.
CREATE PROCEDURE spuObtenerHorasAsignatura @CodAsignatura VARCHAR(6)
AS                                                         
BEGIN                                 
	--Obtener las horas de teoría y práctica
	SELECT HorasTeoria,HorasPractica
		FROM TAsignatura
		WHERE CodAsignatura = @CodAsignatura
END;
GO

--Procedimiento para obtener el código de una asignatura por su nombre.
CREATE PROCEDURE spuObtenerCodigoAsignatura @NombreAsignatura VARCHAR(50)
AS
BEGIN
	--Obtener el código de la asignatura
	SELECT CodAsignatura
		FROM TAsignatura
		WHERE NombreAsignatura = @NombreAsignatura
END;
GO

--Procedimiento para obtener el primer nombre de una asignatura
CREATE PROCEDURE spuObtenerPrimeraAsignatura
AS
BEGIN
	--Obtener el primer nombre
	SELECT TOP 1 NombreAsignatura
		FROM TAsignatura
END;
GO

-- Procedimiento para insertar una asignatura.
CREATE PROCEDURE spuInsertarAsignatura @CodAsignatura VARCHAR(6),
									   @NombreAsignatura VARCHAR(100),
									   @Creditos INT,
									   @Categoria VARCHAR(5),
									   @HorasTeoria INT,
									   @HorasPractica INT,
									   @Prerrequisito VARCHAR(25),
									   @Sumilla VARCHAR(2000)
AS
BEGIN
	-- Insertar una asignatura en la tabla TAsignatura
	INSERT INTO TAsignatura
		VALUES (@CodAsignatura, @NombreAsignatura, @Creditos, @Categoria, @HorasTeoria, @HorasPractica, @Prerrequisito, @Sumilla)
END;
GO

-- Procedimiento para actualizar una asignatura.
CREATE PROCEDURE spuActualizarAsignatura @CodAsignatura VARCHAR(6),
									     @NombreAsignatura VARCHAR(100),
									     @Creditos INT,
									     @Categoria VARCHAR(5),
									     @HorasTeoria INT,
									     @HorasPractica INT,
									     @Prerrequisito VARCHAR(25),
										 @Sumilla VARCHAR(2000)
AS
BEGIN
	-- Actualizar una asignatura de la tabla TAsignatura
	UPDATE TAsignatura
		SET CodAsignatura = @CodAsignatura,
			NombreAsignatura = @NombreAsignatura,
		    Creditos = @Creditos,
			Categoria = @Categoria,
			HorasTeoria = @HorasTeoria, 
			HorasPractica = @HorasPractica,
			Prerrequisito = @Prerrequisito,
			Sumilla = @Sumilla

		WHERE CodAsignatura = @CodAsignatura
END;
GO

-- Procedimiento para eliminar una asignatura.
CREATE PROCEDURE spuEliminarAsignatura @CodAsignatura VARCHAR(6)					
AS
BEGIN
	-- Eliminar una asignatura de la tabla TAsignatura
	DELETE FROM TAsignatura
		WHERE CodAsignatura = @CodAsignatura
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA CATALOGO ****************** */

-- Procedimiento para mostrar el catálogo de asignaturas asignadas de un departamento académico.
CREATE PROCEDURE spuMostrarCatalogo @CodSemestre VARCHAR(7),
                                    @CodDepartamentoA VARCHAR(3) -- Atrib. Docente (Jefe de Dep.) 
AS
BEGIN
	-- Mostrar la tabla de TCatalogo
	SELECT CodAsignatura = (C.CodAsignatura + C.Grupo + C.CodEscuelaP), A.NombreAsignatura, 
	       EscuelaProfesional = EP.Nombre, C.Grupo, C.CodDocente,  
		   Docente = (D.APaterno + ' ' + D.AMaterno + ', ' + D.Nombre), A.CodAsignatura, EP.CodEscuelaP
		FROM ((TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
	    WHERE C.CodSemestre = @CodSemestre AND SUBSTRING(C.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA
		ORDER BY A.NombreAsignatura
END;
GO

-- Procedimiento para buscar por cualquier atributo en un catálogo.
CREATE PROCEDURE spuBuscarCatalogo @CodSemestre VARCHAR(7),
                                   @CodDepartamentoA VARCHAR(3), -- Atrib. Docente (Jefe de Dep.) 
								   @Texto VARCHAR(50) -- Filtro
AS
BEGIN
	-- Mostrar la tabla de TCatalogo por el texto que se desea buscar
	SELECT CodAsignatura = (C.CodAsignatura + C.Grupo + C.CodEscuelaP), A.NombreAsignatura, 
	       EscuelaProfesional = EP.Nombre, C.Grupo, C.CodDocente,  
		   Docente = (D.APaterno + ' ' + D.AMaterno + ', ' + D.Nombre), A.CodAsignatura, EP.CodEscuelaP
		FROM ((TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
		WHERE C.CodSemestre = @CodSemestre AND
		      SUBSTRING(C.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA AND
			  (C.CodAsignatura LIKE (@Texto + '%') OR
			   A.NombreAsignatura LIKE (@Texto + '%') OR
			   C.CodEscuelaP = @Texto OR
			   EP.Nombre LIKE (@Texto + '%') OR
			   C.Grupo LIKE (@Texto + '%') OR
			   C.CodDocente LIKE (@Texto + '%') OR
			   D.Nombre LIKE (@Texto + '%') OR
			   D.APaterno LIKE (@Texto + '%') OR
			   D.AMaterno LIKE (@Texto + '%'))
END;
GO

-- Procedimiento para buscar los docentes que enseñan una asignatura. 
CREATE PROCEDURE spuBuscarDocentesAsignatura @CodSemestre VARCHAR(7),
										     @Texto1 VARCHAR(100), -- código (ej. IF065) o nombre de la asignatura
											 @Texto2 VARCHAR(3), -- EP donde se enseña la asignatura
											 @Grupo VARCHAR(1)
AS
BEGIN
	-- Mostrar la tabla TCatalogo por el texto que se desea buscar
	SELECT DISTINCT C.CodDocente, Docente = (D.APaterno + ' ' + D.AMaterno + ', ' + D.Nombre)
		FROM ((TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
		WHERE C.CodSemestre = @CodSemestre AND
		     (C.CodAsignatura LIKE (@Texto1 + '%') OR A.NombreAsignatura LIKE (@Texto1 + '%')) AND
			 (C.CodEscuelaP LIKE (@Texto2 + '%') OR EP.Nombre LIKE (@Texto2 + '%')) AND
			  C.Grupo = @Grupo
END;
GO

-- Procedimiento para buscar las asignaturas asignadas a un docente.
CREATE PROCEDURE spuBuscarAsignaturasDocente @CodSemestre VARCHAR(7),
                                             @CodDepartamentoA VARCHAR(3), -- Atrib. Docente
										     @Texto VARCHAR(35) -- código o nombre del docente
AS
BEGIN
	-- Mostrar la tabla de TCatalogo por el texto que se desea buscar
	SELECT DISTINCT CodAsignatura = (C.CodAsignatura + C.Grupo + C.CodEscuelaP), A.NombreAsignatura, EscuelaProfesional = EP.Nombre, C.Grupo
		FROM ((TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
		WHERE C.CodSemestre = @CodSemestre AND
			  SUBSTRING(C.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA AND
		      (C.CodDocente LIKE (@Texto + '%') OR
			   D.Nombre LIKE (@Texto + '%') OR
			   D.APaterno LIKE (@Texto + '%') OR
			   D.AMaterno LIKE (@Texto + '%'))
END;
GO

-- Procedimiento para buscar por un filtro las asignaturas asignadas a un docente.
CREATE PROCEDURE spuBuscarAsignaturasAsignadasDocente @CodSemestre VARCHAR(7),
													  @CodDepartamentoA VARCHAR(3), -- Atrib. Docente
													  @CodDocente VARCHAR(5),
													  @Texto VARCHAR(100) -- filtro (código o nombre de la asignatura, EP, grupo)
AS
BEGIN
	-- Mostrar la tabla de TCatalogo por el texto que se desea buscar
	SELECT DISTINCT CodAsignatura = (C.CodAsignatura + C.Grupo + C.CodEscuelaP), A.NombreAsignatura, EscuelaProfesional = EP.Nombre, C.Grupo
		FROM ((TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
		WHERE C.CodSemestre = @CodSemestre AND 
			  SUBSTRING(C.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA AND
		      C.CodDocente = @CodDocente AND
			  ((C.CodAsignatura + C.Grupo + C.CodEscuelaP) LIKE (@Texto + '%') OR
			   A.NombreAsignatura LIKE (@Texto + '%') OR
			   C.CodEscuelaP LIKE (@Texto + '%') OR 
			   EP.Nombre LIKE (@Texto + '%') OR
			   C.Grupo LIKE (@Texto + '%'))
END;
GO

-- Procedimiento para buscar los silabos de una asignatura.
CREATE PROCEDURE spuBuscarSilabosAsignatura @CodSemestre VARCHAR(7),
											@CodAsignatura VARCHAR(6)
AS
BEGIN
	-- Mostrar los silabos
	SELECT DISTINCT C.CodSemestre, C.Grupo, C.CodDocente, D.Nombre, 
	                CodAsignatura = C.CodAsignatura + C.Grupo + C.CodEscuelaP, C.Silabo
		FROM TCatalogo C INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
		WHERE C.CodSemestre = @CodSemestre AND C.CodAsignatura = @CodAsignatura AND 
				C.Silabo IS NOT NULL
END;
GO

-- Procedimiento para buscar los planes de sesión anteriores de un docente que dicto una asignatura.
CREATE PROCEDURE spuBuscarPlanSesionesAsignatura @CodSemestre VARCHAR(7),
											     @CodAsignatura VARCHAR(6),
										         @CodEscuelaP VARCHAR(3),
											     @CodDocente VARCHAR(5)
AS
BEGIN
	-- Mostrar los catalogos
	SELECT DISTINCT C.CodSemestre, C.Grupo, C.CodDocente, D.Nombre,
	                CodAsignatura = C.CodAsignatura + C.Grupo + C.CodEscuelaP, C.PlanSesiones
		FROM TCatalogo C INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
		WHERE C.CodSemestre = @CodSemestre AND C.CodAsignatura = @CodAsignatura AND C.CodEscuelaP = @CodEscuelaP AND 
		      C.CodDocente = @CodDocente AND C.PlanSesiones IS NOT NULL
END;
GO

-- Procedimiento para insertar una asignatura en un catálogo.
CREATE PROCEDURE spuInsertarAsignaturaCatalogo @CodSemestre VARCHAR(7),
											   @CodAsignatura VARCHAR(6),
											   @CodEscuelaP VARCHAR(3),
											   @Grupo VARCHAR(1),
											   @CodDocente VARCHAR(5),
											   @Silabo VARBINARY(MAX),
											   @PlanSesiones VARBINARY(MAX)
AS
BEGIN
	-- Insertar una asignatura en la tabla TCatalogo
	INSERT INTO TCatalogo
		VALUES (@CodSemestre, @CodAsignatura, @CodEscuelaP, @Grupo, @CodDocente, @Silabo, @PlanSesiones)
END;
GO

-- Procedimiento para actualizar la información de una asignatura de un catálogo.
CREATE PROCEDURE spuActualizarAsignaturaCatalogo @CodSemestre VARCHAR(7),
											     @CodAsignatura VARCHAR(6),
											     @CodEscuelaP VARCHAR(3),
											     @Grupo VARCHAR(1),
											     @CodDocente VARCHAR(5),
												 @NCodSemestre VARCHAR(7), -- Nuevo CodSemestre
												 @NCodAsignatura VARCHAR(6), -- Nuevo CodAsignatura
												 @NCodEscuelaP VARCHAR(3), -- Nuevo CodEscuelaP
												 @NGrupo VARCHAR(1), -- Nuevo Grupo
												 @NCodDocente VARCHAR(5) -- Nuevo CodDocente
AS
BEGIN
	-- Actualizar una asignatura de la tabla TCatalogo
	UPDATE TCatalogo
		SET CodSemestre = @NCodSemestre,   
		    CodAsignatura = @NCodAsignatura,
			CodEscuelaP = @NCodEscuelaP,
			Grupo = @NGrupo,
			CodDocente = @NCodDocente
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND 
		      Grupo = @Grupo AND CodDocente = @CodDocente
END;
GO

-- Procedimiento para actualizar el silabo de una asignatura.
CREATE PROCEDURE spuActualizarSilaboAsignatura @CodSemestre VARCHAR(7),
											   @CodAsignatura VARCHAR(9), -- código (ej. IF065AIN), obtener de spuBuscarAsignaturasDocente
											   @CodDocente VARCHAR(5),
											   @Silabo VARBINARY(MAX)
AS
BEGIN
	-- Actualizar una asignatura de la tabla TCatalogo
	UPDATE TCatalogo
		SET Silabo = @Silabo
		WHERE CodSemestre = @CodSemestre AND CodAsignatura + Grupo + CodEscuelaP = @CodAsignatura AND CodDocente = @CodDocente
END;
GO

-- Procedimiento para actualizar el plan de sesiones de una asignatura.
CREATE PROCEDURE spuActualizarPlanSesionesAsignatura @CodSemestre VARCHAR(7),
											         @CodAsignatura VARCHAR(9), -- código (ej. IF065AIN), obtener de spuBuscarAsignaturasDocente
											         @CodDocente VARCHAR(5),
											         @PlanSesiones VARBINARY(MAX)
AS
BEGIN
	-- Actualizar una asignatura de la tabla TCatalogo
	UPDATE TCatalogo
		SET PlanSesiones = @PlanSesiones
		WHERE CodSemestre = @CodSemestre AND CodAsignatura + Grupo + CodEscuelaP = @CodAsignatura AND CodDocente = @CodDocente
END;
GO

-- Procedimiento para eliminar una asignatura de un catálogo
CREATE PROCEDURE spuEliminarAsignaturaCatalogo @CodSemestre VARCHAR(7),
											   @CodAsignatura VARCHAR(6),
											   @CodEscuelaP VARCHAR(3),
											   @Grupo VARCHAR(1)
AS
BEGIN
	-- Eliminar una asignatura de la tabla TCatalogo
	DELETE FROM TCatalogo
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND 
		      Grupo = @Grupo
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA HORARIO-ASIGNATURA ****************** */

-- Procedimiento para buscar el horario de una asignatura en un catálogo. 
CREATE PROCEDURE spuBuscarHorarioAsignatura @CodSemestre VARCHAR(7),
										    @Texto1 VARCHAR(100), -- código (ej. IF065) o nombre de la asignatura
											@Texto2 VARCHAR(3), -- EP donde se enseña la asignatura
											@Grupo VARCHAR(1)
AS
BEGIN
	-- Mostrar la tabla de TCatalogo por el texto que se desea buscar
	SELECT HA.CodDocente, Docente = (D.APaterno + ' ' + D.AMaterno + ', ' + D.Nombre), HA.Dia, HA.Tipo, HA.HorasTeoria, HA.HorasPractica,
	       HA.HoraInicio, HA.HoraFin, HA.Aula, HA.Modalidad
		FROM ((THorarioAsignatura HA INNER JOIN TAsignatura A ON
			 HA.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 HA.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 HA.CodDocente = D.CodDocente
		WHERE HA.CodSemestre = @CodSemestre AND
		     (HA.CodAsignatura LIKE (@Texto1 + '%') OR A.NombreAsignatura LIKE (@Texto1 + '%')) AND
			 (HA.CodEscuelaP LIKE (@Texto2 + '%') OR EP.Nombre LIKE (@Texto2 + '%')) AND
			  HA.Grupo = @Grupo
END;
GO

-- Procedimiento para obtener el horario semanal (por registros) de las asignaturas asignadas a un docente.
CREATE PROCEDURE spuHorarioSemanalDocente @CodSemestre VARCHAR(7),
										  @Texto VARCHAR(35) -- código o nombre del docente
AS
BEGIN
	-- Mostrar las asignaturas y los horarios:
	SELECT CodAsignatura = (HA.CodAsignatura + HA.Grupo + HA.CodEscuelaP), HA.Dia, HA.Tipo, HA.HorasTeoria, HA.HorasPractica,
	       HA.HoraInicio, HA.HoraFin, HA.Aula, HA.Modalidad
		FROM (THorarioAsignatura HA INNER JOIN TAsignatura A ON
			 HA.CodAsignatura = A.CodAsignatura) INNER JOIN TDocente D ON
			 HA.CodDocente = D.CodDocente
		WHERE HA.CodSemestre = @CodSemestre AND 
		      (HA.CodDocente LIKE (@Texto + '%') OR
			   D.Nombre LIKE (@Texto + '%') OR
			   D.APaterno LIKE (@Texto + '%') OR
			   D.AMaterno LIKE (@Texto + '%'))
END;
GO

-- Procedimiento para obtener el horario (concatenado) de una asignatura asignada a un docente.
-- Formato salida: IF614AIN T:MA 7 -9 VIRT 7 IN; T:VI 8 -9 VIRT 7 IN; P:JU 7 -9 VIRT 7 IN
CREATE PROCEDURE spuHorarioAsignaturaDocente @CodSemestre VARCHAR(7),
											 @CodAsignatura VARCHAR(9), -- código (ej. IF065AIN), obtener de spuBuscarAsignaturasDocente
											 @CodDocente VARCHAR(5)
AS
BEGIN
	-- Crear tabla de resultados
	DECLARE @taHorarioAsignatura TABLE(CodAsignatura VARCHAR(9),
									   HorarioGeneral VARCHAR(100));
	-- Declarar cursor
	DECLARE cu_RegHorario CURSOR
	FOR 
		SELECT Dia, Tipo, HoraInicio, HoraFin, Aula
		FROM THorarioAsignatura
		WHERE CodSemestre = @CodSemestre AND CodAsignatura + Grupo + CodEscuelaP = @CodAsignatura AND CodDocente = @CodDocente

	-- Declarar variables que utilizará el cursor
	DECLARE @Dia VARCHAR(2),  
			@Tipo CHAR(1),
		    @HoraInicio VARCHAR(2),
			@HoraFin VARCHAR(2),
			@Aula VARCHAR(10),
			@HorarioGeneral VARCHAR(100)
			
	-- Abrir el cursor
	OPEN cu_RegHorario
	-- Recuperar valores del primer registro
	FETCH NEXT FROM cu_RegHorario
		INTO @Dia, @Tipo, @HoraInicio, @HoraFin, @Aula
	
	-- Inicializar variables @HorarioGeneral
	SET @HorarioGeneral = ''

	-- Procesar tupla
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Concatenar:
		SET @HorarioGeneral = @HorarioGeneral + @Tipo + ':' + @Dia + ' ' + @HoraInicio + '-' + @HoraFin + ' ' + @Aula + '; '
		-- Siguiente tupla
		FETCH NEXT FROM cu_RegHorario
			INTO @Dia, @Tipo, @HoraInicio, @HoraFin, @Aula
	END

	SET @HorarioGeneral = SUBSTRING(@HorarioGeneral, 1, LEN(@HorarioGeneral)-1)
	INSERT INTO @taHorarioAsignatura  VALUES (@CodAsignatura, @HorarioGeneral)

	-- Cerrar cursor
	CLOSE cu_RegHorario
	DEALLOCATE cu_RegHorario

	-- Mostrar la tabla se asignaturas
	SELECT * FROM @taHorarioAsignatura
END;
GO

--Procedimiento para obtener las horas que se le asignó a un docente en un semestre.
CREATE PROCEDURE spuHorasDocenteHorarioAsignatura @CodDocente VARCHAR(5),
												  @CodSemestre VARCHAR(7)
AS
BEGIN
	--Extraer solo las horas de un docente
	SELECT HorasTeoria, HorasPractica
		FROM THorarioAsignatura
		WHERE CodDocente = @CodDocente AND CodSemestre = @CodSemestre
END;
GO

-- Procedimiento para insertar el horario de una asignatura.
CREATE PROCEDURE spuInsertarHorarioAsignatura @CodSemestre VARCHAR(7),
											  @CodAsignatura VARCHAR(6),
											  @CodEscuelaP VARCHAR(3),
											  @Grupo VARCHAR(1),
											  @CodDocente VARCHAR(5),
											  @Dia VARCHAR(2),
											  @Tipo VARCHAR(1),
											  @HorasTeoria INT,
											  @HorasPractica INT,
											  @HoraInicio VARCHAR(2),
											  @HoraFin VARCHAR(2),
									          @Aula VARCHAR(10),
											  @Modalidad VARCHAR(10)
AS
BEGIN
	-- Insertar el horario de una asignatura en la tabla THorarioAsignatura
	INSERT INTO THorarioAsignatura
		VALUES (@CodSemestre, @CodAsignatura, @CodEscuelaP, @Grupo, @CodDocente, @Dia, @Tipo, @HorasTeoria, @HorasPractica,
		        @HoraInicio, @HoraFin, @Aula, @Modalidad)
END;
GO

-- Procedimiento para actualizar el horario de una asignatura.
CREATE PROCEDURE spuActualizarHorarioAsignatura @CodSemestre VARCHAR(7),
												@CodAsignatura VARCHAR(6),
											    @CodEscuelaP VARCHAR(3),
												@Grupo VARCHAR(1),
											    @CodDocente VARCHAR(5),
											    @Dia VARCHAR(2),
												@NCodSemestre VARCHAR(7), -- Nuevo CodSemestre
												@NCodAsignatura VARCHAR(6), -- Nuevo CodAsignatura
											    @NCodEscuelaP VARCHAR(3), -- Nuevo CodEscuelaP
												@NGrupo VARCHAR(1), -- Nuevo Grupo
											    @NCodDocente VARCHAR(5), -- Nuevo CodDocente
											    @NDia VARCHAR(2), -- Nuevo Dia
												@NTipo VARCHAR(1), -- Nuevo Tipo
											    @NHorasTeoria INT, -- Nuevo HorasTeoria
											    @NHorasPractica INT, -- Nuevo HorasPractica
											    @NHoraInicio VARCHAR(2), -- Nuevo HoraInicio
											    @NHoraFin VARCHAR(2), -- Nuevo HoraFin
									            @NAula VARCHAR(10), -- Nuevo Aula
											    @NModalidad VARCHAR(10) -- Nuevo Modalidad
AS
BEGIN
	-- Actualizar una asignatura de la tabla THorarioAsignatura
	UPDATE THorarioAsignatura
		SET CodSemestre = @NCodSemestre,
		    CodAsignatura = @NCodAsignatura,
		    CodEscuelaP = @NCodEscuelaP,
			Grupo = @NGrupo,
			CodDocente = @NCodDocente,
		    Dia = @NDia,
			Tipo = @NTipo,
			HorasTeoria = @NHorasTeoria,
			HorasPractica = @NHorasPractica,
			HoraInicio = @NHoraInicio,
			HoraFin = @NHoraFin,
			Aula = @NAula,
			Modalidad = @NModalidad

		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND
      		  Grupo = @Grupo AND CodDocente = @CodDocente AND Dia = @Dia
END;
GO

-- Procedimiento para eliminar el horario de una asignatura.
CREATE PROCEDURE spuEliminarHorarioAsignatura @CodSemestre VARCHAR(7),
                                              @CodAsignatura VARCHAR(6),
											  @CodEscuelaP VARCHAR(3),
										      @Grupo VARCHAR(1)
AS
BEGIN
	-- Eliminar una asignatura de la tabla THorarioAsignatura
	DELETE FROM THorarioAsignatura
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND
      		  Grupo = @Grupo
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA MATRICULA ****************** */

-- Procedimiento para mostrar los estudiantes matriculados en un determinado semestre de una escuela profesional.
CREATE PROCEDURE spuMostrarEstudiantesMatriculados @CodSemestre VARCHAR(7),
												   @CodEscuelaP VARCHAR(3)
AS
BEGIN
	-- Mostrar la tabla de TMatricula
	SELECT M.IdMatricula, M.CodAsignatura, A.NombreAsignatura, M.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre
		FROM (TMatricula M INNER JOIN TAsignatura A ON
			 M.CodAsignatura = A.CodAsignatura) INNER JOIN TEstudiante ET ON
			 M.CodEstudiante = ET.CodEstudiante
	    WHERE M.CodSemestre = @CodSemestre AND M.CodEscuelaP = @CodEscuelaP
END;
GO

-- Procedimiento para buscar las asignaturas a los que esta matriculado un estudiante de una escuela profesional.
CREATE PROCEDURE spuBuscarAsignaturasEstudiante @CodSemestre VARCHAR(7),
										        @CodEscuelaP VARCHAR(3),
											    @CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Mostrar la tabla de TMatricula
	SELECT M.CodAsignatura, A.NombreAsignatura, A.Categoria, A.Creditos
		FROM TMatricula M INNER JOIN TAsignatura A ON
			 M.CodAsignatura = A.CodAsignatura
	    WHERE M.CodSemestre = @CodSemestre AND M.CodEscuelaP = @CodEscuelaP AND M.CodEstudiante = @CodEstudiante
END;
GO

-- Procedimiento para buscar los estudiantes matriculados en una asignatura de un determinado semestre.
CREATE PROCEDURE spuBuscarEstudiantesAsignatura @CodSemestre VARCHAR(7),
										        @CodEscuelaP VARCHAR(3),
											    @Texto VARCHAR(100) -- código (ej. IF085AIN) o nombre de la asignatura
AS
BEGIN
	-- Mostrar la tabla de TMatricula
	SELECT ROW_NUMBER() OVER (ORDER BY ET.APaterno ASC) AS Id, M.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre
		FROM (TMatricula M INNER JOIN TAsignatura A ON
			 SUBSTRING(M.CodAsignatura,1,5) = A.CodAsignatura) INNER JOIN TEstudiante ET ON
			 M.CodEstudiante = ET.CodEstudiante
	    WHERE M.CodSemestre = @CodSemestre AND M.CodEscuelaP = @CodEscuelaP AND
		      (M.CodAsignatura LIKE (@Texto + '%') OR A.NombreAsignatura LIKE (@Texto + '%'))
END;
GO

-- Procedimiento para buscar por sus datos de los estudiantes matriculados a una asignatura
CREATE PROCEDURE spuBuscarEstudiantesMatriculadosAsignatura @CodSemestre VARCHAR(7),
															@CodEscuelaP VARCHAR(3),
															@Texto1 VARCHAR(100), -- código (ej. IF085AIN) o nombre de la asignatura
															@Texto2 VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla de TMatricula
	SELECT ROW_NUMBER() OVER (ORDER BY ET.APaterno ASC) AS Id, M.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre
		FROM (TMatricula M INNER JOIN TAsignatura A ON
			 SUBSTRING(M.CodAsignatura,1,5) = A.CodAsignatura) INNER JOIN TEstudiante ET ON
			 M.CodEstudiante = ET.CodEstudiante
	    WHERE M.CodSemestre = @CodSemestre AND M.CodEscuelaP = @CodEscuelaP AND
		      (M.CodAsignatura LIKE (@Texto1 + '%') OR A.NombreAsignatura LIKE (@Texto1 + '%')) AND
			  (M.CodEstudiante LIKE (@Texto2 + '%') OR
			   ET.APaterno LIKE (@Texto2 + '%') OR
			   ET.AMaterno LIKE (@Texto2 + '%') OR
			   ET.Nombre LIKE (@Texto2 + '%'))
END;
GO

-- Procedimiento para insertar la matricula de un estudiante en una asignatura.
CREATE PROCEDURE spuInsertarMatricula @CodSemestre VARCHAR(7),
									  @CodEscuelaP VARCHAR(3),
								      @CodAsignatura VARCHAR(9),
									  @CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Insertar una matricula en la tabla de TMatricula
	INSERT INTO TMatricula
		VALUES (@CodSemestre, @CodEscuelaP, @CodAsignatura, @CodEstudiante)
END;
GO

-- Procedimiento para actualizar la matricula de un estudiante.
CREATE PROCEDURE spuActualizarMatricula @CodSemestre VARCHAR(7),
									    @CodEscuelaP VARCHAR(3),
								        @CodAsignatura VARCHAR(9),
									    @CodEstudiante VARCHAR(6),
										@NCodSemestre VARCHAR(7),
									    @NCodEscuelaP VARCHAR(3),
								        @NCodAsignatura VARCHAR(9),
									    @NCodEstudiante VARCHAR(6)
AS
BEGIN
	-- Actualizar una matricula de la tabla de TMatricula
	UPDATE TMatricula
		SET CodSemestre = @NCodSemestre,
		    CodEscuelaP = @NCodEscuelaP,
			CodAsignatura = @NCodAsignatura,
			CodEstudiante = @NCodEstudiante
		WHERE CodSemestre = @NCodSemestre AND CodEscuelaP = @CodEscuelaP AND 
		      CodAsignatura = @CodAsignatura AND CodEstudiante = @CodEstudiante
END;
GO

-- Procedimiento para eliminar la matricula de un estudiante en una asignatura.
CREATE PROCEDURE spuEliminarMatricula @CodSemestre VARCHAR(7),
									  @CodEscuelaP VARCHAR(3),
								      @CodAsignatura VARCHAR(9),
									  @CodEstudiante VARCHAR(6)					
AS
BEGIN
	-- Eliminar una asignatura de la tabla de TMatricula
	DELETE FROM TMatricula
		WHERE CodSemestre = @CodSemestre AND CodEscuelaP = @CodEscuelaP AND 
		      CodAsignatura = @CodAsignatura AND CodEstudiante = @CodEstudiante
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ASISTENCIA-DOCENTE ****************** */

-- Procedimiento para mostrar el registro de asistencia de los docentes en una fecha especifica.
CREATE PROCEDURE spuAsistenciaDocentes @CodSemestre VARCHAR(7),
									   @CodDepartamentoA VARCHAR(3), -- Atrib. Docente (Jefe de Dep.)
									   @Fecha DATE
AS
BEGIN
	-- Mostrar el registro de asistencia
	SELECT ROW_NUMBER() OVER (ORDER BY D.APaterno ASC) AS Id, AD.CodDocente, D.APaterno, D.AMaterno, D.Nombre, 
	       AD.CodAsignatura, A.NombreAsignatura, AD.HoraInicio, AD.Hora, AD.NombreTema
		FROM (TAsistenciaDocente AD INNER JOIN TDocente D ON
			 AD.CodDocente = D.CodDocente) INNER JOIN TAsignatura A ON
			 SUBSTRING(AD.CodAsignatura,1,5) = A.CodAsignatura
	    WHERE AD.CodSemestre = @CodSemestre AND AD.Fecha = @Fecha AND
              SUBSTRING(AD.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA
END;
GO

-- Procedimiento para mostrar el registro de asistencias de un docente que dicta una asignatura en un rango de fechas.
CREATE PROCEDURE spuAsistenciaDocenteAsignatura @CodSemestre VARCHAR(7),
                                                @CodDepartamentoA VARCHAR(3), -- Atrib. Docente (Jefe de Dep.)
												@Texto1 VARCHAR(35), -- código o nombre del docente
												@Texto2 VARCHAR(100), -- código (ej. IF085AIN) o nombre de la asignatura
												@HoraInicio VARCHAR(2), -- Hora inicio de la asignatura
												@LimFechaInf DATE,
												@LimFechaSup DATE
AS
BEGIN
	-- Mostrar el registro de asistencia en el rango de fechas
	SELECT AD.Fecha, AD.Hora, AD.NombreTema
		FROM (TAsistenciaDocente AD INNER JOIN TDocente D ON
			 AD.CodDocente = D.CodDocente) INNER JOIN TAsignatura A ON
			 SUBSTRING(AD.CodAsignatura,1,5) = A.CodAsignatura
	    WHERE AD.CodSemestre = @CodSemestre AND AD.HoraInicio = @HoraInicio AND
              SUBSTRING(AD.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA AND
		      (AD.Fecha BETWEEN @LimFechaInf AND @LimFechaSup) AND
			  (AD.CodDocente LIKE (@Texto1 + '%') OR
			   D.Nombre LIKE (@Texto1 + '%') OR
			   D.APaterno LIKE (@Texto1 + '%') OR
			   D.AMaterno LIKE (@Texto1 + '%')) AND
			  (AD.CodAsignatura LIKE (@Texto2 + '%') OR A.NombreAsignatura LIKE (@Texto2 + '%'))
END;
GO

-- Procedimiento para registrar la asistencia de un docente.
CREATE PROCEDURE spuRegistrarAsistenciaDocente @CodSemestre VARCHAR(7),
								               @CodAsignatura VARCHAR(9),
											   @HoraInicio VARCHAR(2),
										       @Fecha DATE,
											   @Hora TIME(0),
									           @CodDocente VARCHAR(5),
										       @NombreTema VARCHAR(100)
AS
BEGIN
	-- Registrar la asistencia en la tabla TAsistenciaDocente
	INSERT INTO TAsistenciaDocente
		VALUES (@CodSemestre, @CodAsignatura, @HoraInicio, @Fecha, @Hora, @CodDocente, @NombreTema)
END;
GO

-- Procedimiento para actualizar la asistencia de un docente:
CREATE PROCEDURE spuActualizarAsistenciaDocente @CodSemestre VARCHAR(7),
								                @CodAsignatura VARCHAR(9),
												@HoraInicio VARCHAR(2),
										        @Fecha DATE,
												@NCodSemestre VARCHAR(7), -- Nuevo CodSemestre
								                @NCodAsignatura VARCHAR(9), -- Nuevo CodAsignatura
												@NHoraInicio VARCHAR(2),
										        @NFecha DATE, -- Nueva Fecha
									            @NCodDocente VARCHAR(5), -- Nuevo CodDocente
										        @NNombreTema VARCHAR(100) -- Nuevo Nombre Tema

AS
BEGIN
	-- Actualizar la asistencia en la tabla TAsistenciaDocente
	UPDATE TAsistenciaDocente
		SET CodSemestre = @NCodSemestre, 
			CodAsignatura = @NCodAsignatura,
			HoraInicio = @NHoraInicio,
			Fecha = @NFecha,
			CodDocente = @NCodDocente,
			NombreTema = @NNombreTema

		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND HoraInicio = @HoraInicio AND Fecha = @Fecha
END;
GO

-- Procedimiento para eliminar la asistencia de un docente.
CREATE PROCEDURE spuEliminarAsistenciaDocente @CodSemestre VARCHAR(7),
								              @CodAsignatura VARCHAR(9),
											  @HoraInicio VARCHAR(2),
										      @Fecha DATE				
AS
BEGIN
	-- Eliminar una asistencia en la tabla de TAsistenciaDocente
	DELETE FROM TAsistenciaDocente
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND HoraInicio = @HoraInicio AND Fecha = @Fecha
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ASISTENCIA-ESTUDIANTE ****************** */

-- Procedimiento para mostrar el registro de asistencia de los estudiantes de una asignatura en una fecha especifica.
CREATE PROCEDURE spuAsistenciaEstudiantes @CodSemestre VARCHAR(7),
									      @CodDepartamentoA VARCHAR(3), -- Atrib. Docente (Jefe de Dep.)
									      @Texto VARCHAR(100), -- código (ej. IF085AIN) o nombre de la asignatura
										  @HoraInicio VARCHAR(2), -- Hora inicio de la asignatura
									      @Fecha DATE
AS
BEGIN
	-- Mostrar el registro de asistencia de los estudiantes
	SELECT ROW_NUMBER() OVER (ORDER BY ET.APaterno ASC) AS Id, AE.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre,
	       AE.Hora, AE.Estado, AE.Observación
		FROM (TAsistenciaEstudiante AE INNER JOIN TEstudiante ET ON
			 AE.CodEstudiante = ET.CodEstudiante) INNER JOIN TAsignatura A ON
			 SUBSTRING(AE.CodAsignatura,1,5) = A.CodAsignatura
	    WHERE AE.CodSemestre = @CodSemestre AND AE.HoraInicio = @HoraInicio AND
              SUBSTRING(AE.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA AND
		     (AE.CodAsignatura LIKE (@Texto + '%') OR A.NombreAsignatura LIKE (@Texto + '%')) AND
			  AE.Fecha = @Fecha
END;
GO

-- Procedimiento para mostrar el registro de asistencias de un estudiante en una asignatura en un rango de fechas.
CREATE PROCEDURE spuAsistenciaEstudianteAsignatura @CodSemestre VARCHAR(7),
												   @CodDepartamentoA VARCHAR(3), -- Atrib. Docente (Jefe de Dep.)
												   @Texto1 VARCHAR(35), -- código o nombre del estudiante
												   @Texto2 VARCHAR(100), -- código (ej. IF085AIN) o nombre de la asignatura
												   @HoraInicio VARCHAR(2), -- Hora inicio de la asignatura
												   @LimFechaInf DATE,
												   @LimFechaSup DATE
AS
BEGIN
	-- Mostrar el registro de asistencia en el rango de fechas
	SELECT AE.Fecha, AE.Hora, AE.Estado, AE.Observación
		FROM (TAsistenciaEstudiante AE INNER JOIN TEstudiante ET ON
			 AE.CodEstudiante = ET.CodEstudiante) INNER JOIN TAsignatura A ON
			 SUBSTRING(AE.CodAsignatura,1,5) = A.CodAsignatura
	    WHERE AE.CodSemestre = @CodSemestre AND AE.HoraInicio = @HoraInicio AND
              SUBSTRING(AE.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA AND
		      (AE.Fecha BETWEEN @LimFechaInf AND @LimFechaSup) AND
			  (AE.CodEstudiante LIKE (@Texto1 + '%') OR
			   ET.Nombre LIKE (@Texto1 + '%') OR
			   ET.APaterno LIKE (@Texto1 + '%') OR
			   ET.AMaterno LIKE (@Texto1 + '%')) AND
			  (AE.CodAsignatura LIKE (@Texto2 + '%') OR A.NombreAsignatura LIKE (@Texto2 + '%'))
END;
GO

-- Procedimiento para registrar la asistencia de un estudiante.
CREATE PROCEDURE spuRegistrarAsistenciaEstudiante @CodSemestre VARCHAR(7),
								                  @CodAsignatura VARCHAR(9),
												  @HoraInicio VARCHAR(2),
										          @Fecha DATE,
												  @Hora TIME(0),
									              @CodEstudiante VARCHAR(6),
										          @Estado VARCHAR(2),
											      @Observación VARCHAR(25)
AS
BEGIN
	-- Registrar la asistencia en la tabla TAsistenciaEstudiante
	INSERT INTO TAsistenciaEstudiante
		VALUES (@CodSemestre, @CodAsignatura, @HoraInicio, @Fecha, @Hora, @CodEstudiante, @Estado, @Observación)
END;
GO

-- Procedimiento para actualizar la asistencia de un estudiante.
CREATE PROCEDURE spuActualizarAsistenciaEstudiante @CodSemestre VARCHAR(7),
								                   @CodAsignatura VARCHAR(9),
												   @HoraInicio VARCHAR(2),
										           @Fecha DATE,
									               @CodEstudiante VARCHAR(6),
												   @NCodSemestre VARCHAR(7),
								                   @NCodAsignatura VARCHAR(9),
												   @NHoraInicio VARCHAR(2),
										           @NFecha DATE,
									               @NCodEstudiante VARCHAR(6),
										           @NEstado VARCHAR(2),
											       @NObservación VARCHAR(25)
AS
BEGIN
	-- Actualizar la asistencia en la tabla TAsistenciaEstudiante
	UPDATE TAsistenciaEstudiante
		SET CodSemestre = @NCodSemestre, 
			CodAsignatura = @NCodAsignatura,
			HoraInicio = @HoraInicio,
			Fecha = @NFecha,
			CodEstudiante = @NCodEstudiante,
			Estado = @NEstado,
			Observación = @NObservación

		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND HoraInicio = @HoraInicio AND 
		      Fecha = @Fecha AND CodEstudiante = @CodEstudiante
END;
GO

-- Procedimiento para eliminar la asistencia de un estudiante.
CREATE PROCEDURE spuEliminarAsistenciaEstudiante @CodSemestre VARCHAR(7),
								                 @CodAsignatura VARCHAR(9),
												 @HoraInicio VARCHAR(2),
										         @Fecha DATE,
											     @CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Eliminar una asistencia en la tabla de TAsistenciaEstudiante
	DELETE FROM TAsistenciaEstudiante
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND HoraInicio = @HoraInicio AND 
		      Fecha = @Fecha AND CodEstudiante = @CodEstudiante
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA RECURSOS ****************** */

-- Procedimiento para el descargar la plantilla del silabo
CREATE PROCEDURE spuDescargarPlantillaSilabo
AS
BEGIN
	-- Mostrar la plantilla en la tabla TRecursos
	SELECT PlantillaSilabo FROM TRecursos WHERE IdRecurso = 1
END;
GO

-- Procedimiento para el descargar la plantilla del plan de sesiones de 2 y 3 créditos
CREATE PROCEDURE spuDescargarPlantillaPlanSesiones2y3
AS
BEGIN
	-- Mostrar la plantilla en la tabla TRecursos
	SELECT PlantillaPlanSesiones2y3 FROM TRecursos WHERE IdRecurso = 1
END;
GO

-- Procedimiento para el descargar la plantilla del plan de sesiones de 4 créditos
CREATE PROCEDURE spuDescargarPlantillaPlanSesiones4
AS
BEGIN
	-- Mostrar la plantilla en la tabla TRecursos
	SELECT PlantillaPlanSesiones4 FROM TRecursos WHERE IdRecurso = 1
END;
GO

-- Procedimiento para el actualizar la plantilla del silabo (solo el Director de Escuela)
CREATE PROCEDURE spuActualizarPlantillaSilabo @PlantillaSilabo VARBINARY(MAX)
AS
BEGIN
	-- Actualizar la plantilla en la tabla TRecursos
	UPDATE TRecursos
		SET PlantillaSilabo = @PlantillaSilabo
		WHERE IdRecurso = 1
END;
GO

-- Procedimiento para el actualizar la plantilla del plan de sesiones de 2 y 3 créditos (solo el Director de Escuela)
CREATE PROCEDURE spuActualizarPlantillaPlanSesiones2y3 @PlantillaPlanSesiones2y3 VARBINARY(MAX)
AS
BEGIN
	-- Actualizar la plantilla en la tabla TRecursos
	UPDATE TRecursos
		SET PlantillaPlanSesiones2y3 = @PlantillaPlanSesiones2y3
		WHERE IdRecurso = 1
END;
GO

-- Procedimiento para el actualizar la plantilla del plan de sesiones de 4 créditos (solo el Director de Escuela)
CREATE PROCEDURE spuActualizarPlantillaPlanSesiones4 @PlantillaPlanSesiones4 VARBINARY(MAX)
AS
BEGIN
	-- Actualizar la plantilla en la tabla TRecursos
	UPDATE TRecursos
		SET PlantillaPlanSesiones4 = @PlantillaPlanSesiones4
		WHERE IdRecurso = 1
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA USUARIO ****************** */

-- Procedimiento para el inicio de sesión.
CREATE PROCEDURE spuIniciarSesion @Usuario VARCHAR(6),
                                  @Contraseña VARCHAR(20)
AS
BEGIN
	-- Seleccionar los datos del usuario valido
	SELECT Perfil, Usuario, DBO.fnDesencriptarContraseña(Contraseña), Acceso, Datos
		FROM TUsuario
		WHERE Usuario = @Usuario AND DBO.fnDesencriptarContraseña(Contraseña) = @Contraseña
END;
GO