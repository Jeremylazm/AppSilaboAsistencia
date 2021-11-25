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
	Nombre VARCHAR(40) NOT NULL,

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
	Nombre VARCHAR(40) NOT NULL,

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
	APaterno VARCHAR(15) NOT NULL,
	AMaterno VARCHAR(15) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
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
	NombreAsignatura VARCHAR(50) NOT NULL,
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
	CodAsignatura VARCHAR(9), -- ej. IF085AIN
	Fecha DATE NOT NULL,
	CodDocente tyCodDocente,
	NombreTema VARCHAR(100)

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodAsignatura, Fecha),
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
	CodAsignatura VARCHAR(9), -- ej. IF085AIN
	Fecha DATE NOT NULL,
	CodEstudiante tyCodEstudiante,
	Estado VARCHAR(2) NOT NULL,  --SI/NO (Presente/No presente)
	Observación VARCHAR(25) -- tardanza, permisos

	-- Determinar las claves
	PRIMARY KEY (CodSemestre, CodAsignatura, Fecha, CodEstudiante),
	CONSTRAINT FK_CodAsistenciaDocente FOREIGN KEY (CodSemestre, CodAsignatura, Fecha)
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
									  @Texto VARCHAR(20)
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
									   @APaterno VARCHAR(15),
									   @AMaterno VARCHAR(15),
									   @Nombre VARCHAR(20),
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
										 @APaterno VARCHAR(15),
										 @AMaterno VARCHAR(15),
										 @Nombre VARCHAR(20),
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
	    WHERE CodEscuelaP = @CodEscuelaP
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
	    WHERE CodDepartamentoA = @CodDepartamentoA
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
		WHERE CodDepartamentoA = @CodDepartamentoA AND CodDocente = @CodDocente
END;
GO

-- Procedimiento para buscar por cualquier atributo los docentes de un departamento académico.
CREATE PROCEDURE spuBuscarDocentes @CodDepartamentoA VARCHAR(3),
								   @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla TDocente por el texto que se desea buscar
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
		WHERE CodDepartamentoA = @CodDepartamentoA AND
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
									@APaterno VARCHAR(15),
									@AMaterno VARCHAR(15),
									@Nombre VARCHAR(20),
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
									  @APaterno VARCHAR(15),
									  @AMaterno VARCHAR(15),
									  @Nombre VARCHAR(20),
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
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica, Prerrequisito
		FROM TAsignatura
	    WHERE SUBSTRING(CodAsignatura,1,2) = @CodDepartamento
		ORDER BY NombreAsignatura
END;
GO

-- Procedimiento para mostrar la sumilla de una asignatura
CREATE PROCEDURE spuMostrarSumilla @CodDepartamento VARCHAR(3),
								   @CodAsignatura VARCHAR(6)
AS
BEGIN	
	-- Mostrar la tabla TAsignatura
	SELECT Sumilla
		FROM TAsignatura
	    WHERE SUBSTRING(CodAsignatura,1,2) = @CodDepartamento AND CodAsignatura = @CodAsignatura
END;
GO

-- Procedimiento para buscar una asignatura.
CREATE PROCEDURE spuBuscarAsignatura @CodDepartamento VARCHAR(3),
									 @CodAsignatura VARCHAR(6)
AS
BEGIN
	-- Mostrar la tabla TAsignatura por el texto que se desea buscar
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica, Prerrequisito
		FROM TAsignatura
		WHERE SUBSTRING(CodAsignatura,1,2) = @CodDepartamento AND CodAsignatura = @CodAsignatura
END;
GO

-- Procedimiento para buscar por cualquier atributo las asignaturas de un departamento académico.
CREATE PROCEDURE spuBuscarAsignaturas @CodDepartamento VARCHAR(3),
									  @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla TAsignatura por el texto que se desea buscar
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica, Prerrequisito
		FROM TAsignatura
		WHERE SUBSTRING(CodAsignatura,1,2) = @CodDepartamento AND 
			 (CodAsignatura LIKE (@Texto + '%') OR
			  NombreAsignatura LIKE (@Texto + '%') OR
			  Creditos LIKE (@Texto + '%') OR
			  Categoria LIKE (@Texto + '%') OR
			  HorasTeoria LIKE (@Texto + '%') OR
			  HorasPractica LIKE (@Texto + '%') OR
			  Prerrequisito LIKE (@Texto + '%'))
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
									   @NombreAsignatura VARCHAR(50),
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
									     @NombreAsignatura VARCHAR(50),
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
	SELECT CodAsignatura = (C.CodAsignatura + C.Grupo + C.CodEscuelaP), A.NombreAsignatura, EscuelaProfesional = EP.Nombre, 
	       C.Grupo, C.CodDocente, Docente = (D.APaterno + ' ' + D.AMaterno + ', ' + D.Nombre)
		FROM ((TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
	    WHERE C.CodSemestre = @CodSemestre AND SUBSTRING(C.CodAsignatura,1,LEN(@CodDepartamentoA)) = @CodDepartamentoA
		ORDER BY A.NombreAsignatura
END;
GO

-- Procedimiento para buscar los docentes que enseñan una asignatura. 
CREATE PROCEDURE spuBuscarDocentesAsignatura @CodSemestre VARCHAR(7),
										     @Texto1 VARCHAR(20), -- código (ej. IF065) o nombre de la asignatura
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
										     @Texto VARCHAR(20) -- código o nombre del docente
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

-- Procedimiento para buscar los silabos de una asignatura.
CREATE PROCEDURE spuBuscarSilabosAsignatura @CodSemestre VARCHAR(7),
											@Texto1 VARCHAR(20), -- código (ej. IF065) o nombre de la asignatura
										    @Texto2 VARCHAR(3), -- EP donde se enseña la asignatura
											@Grupo VARCHAR(1)
AS
BEGIN
	-- Mostrar el silabo
	SELECT DISTINCT C.CodSemestre, C.Grupo, C.CodDocente, D.Nombre
		FROM ((TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP) INNER JOIN TDocente D ON
			 C.CodDocente = D.CodDocente
		WHERE (C.CodAsignatura LIKE (@Texto1 + '%') OR A.NombreAsignatura LIKE (@Texto1 + '%')) AND 
			  (C.CodEscuelaP LIKE (@Texto2 + '%') OR EP.Nombre LIKE (@Texto2 + '%'))
END;
GO

-- Procedimiento para buscar el silabo de una asignatura.
CREATE PROCEDURE spuMostrarSilaboAsignatura @CodSemestre VARCHAR(7),
										    @Texto1 VARCHAR(20), -- código (ej. IF065) o nombre de la asignatura
										    @Texto2 VARCHAR(3), -- EP donde se enseña la asignatura
										    @Grupo VARCHAR(1)
AS
BEGIN
	-- Mostrar el silabo
	SELECT DISTINCT C.Silabo
		FROM (TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP
		WHERE C.CodSemestre = @CodSemestre AND
			 (C.CodAsignatura LIKE (@Texto1 + '%') OR A.NombreAsignatura LIKE (@Texto1 + '%')) AND 
			 (C.CodEscuelaP LIKE (@Texto2 + '%') OR EP.Nombre LIKE (@Texto2 + '%')) AND
			  C.Grupo = @Grupo AND C.Silabo IS NOT NULL
END;
GO

-- Procedimiento para buscar el plan de sesiones de un docente para una asignatura.
CREATE PROCEDURE spuBuscarPlanSesionesAsignatura @CodSemestre VARCHAR(7),
												 @Texto1 VARCHAR(20), -- código (ej. IF065) o nombre de la asignatura
										         @Texto2 VARCHAR(3), -- EP donde se enseña la asignatura     
										         @Grupo VARCHAR(1)
AS
BEGIN
	-- Mostrar el silabo
	SELECT DISTINCT C.PlanSesiones
		FROM (TCatalogo C INNER JOIN TAsignatura A ON
			 C.CodAsignatura = A.CodAsignatura) INNER JOIN TEscuelaProfesional EP ON
			 C.CodEscuelaP = EP.CodEscuelaP
		WHERE C.CodSemestre = @CodSemestre AND
		     (C.CodAsignatura LIKE (@Texto1 + '%') OR A.NombreAsignatura LIKE (@Texto1 + '%')) AND
			 (C.CodEscuelaP LIKE (@Texto2 + '%') OR EP.Nombre LIKE (@Texto2 + '%')) AND
			  C.Grupo = @Grupo AND C.PlanSesiones IS NOT NULL
END;
GO

-- Procedimiento para insertar una asignatura en un catálogo.
CREATE PROCEDURE spuInsertarAsignaturaCatalogo @CodSemestre VARCHAR(7),
											   @CodAsignatura VARCHAR(6),
											   @CodEscuelaP VARCHAR(3),
											   @Grupo VARCHAR(1),
											   @CodDocente VARCHAR(5),
											   @Silabo VARBINARY,
											   @PlanSesiones VARBINARY
AS
BEGIN
	-- Insertar una asignatura en la tabla TCatalogo
	INSERT INTO TCatalogo
		VALUES (@CodSemestre, @CodAsignatura, @CodEscuelaP, @Grupo, @CodDocente, @Silabo, @PlanSesiones)
END;
GO

-- Procedimiento para actualizar una asignatura de un catálogo.
CREATE PROCEDURE spuActualizarAsignaturaCatalogo @CodSemestre VARCHAR(7),
											     @CodAsignatura VARCHAR(6),
											     @CodEscuelaP VARCHAR(3),
											     @Grupo VARCHAR(1),
											     @CodDocente VARCHAR(5),
											     @Silabo VARBINARY,
											     @PlanSesiones VARBINARY
AS
BEGIN
	-- Actualizar una asignatura de la tabla TCatalogo
	UPDATE TCatalogo
		SET CodSemestre = @CodSemestre,  
			CodAsignatura = @CodAsignatura, 
			CodEscuelaP = @CodEscuelaP,
			Grupo = @Grupo,
			CodDocente = @CodDocente,
		    Silabo = @Silabo,
			PlanSesiones = @PlanSesiones
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND 
		      Grupo = @Grupo AND CodDocente = @CodDocente
END;
GO

-- Procedimiento para eliminar una asignatura de un catálogo
CREATE PROCEDURE spuEliminarAsignaturaCatalogo @CodSemestre VARCHAR(7),
											   @CodAsignatura VARCHAR(6),
											   @CodEscuelaP VARCHAR(3),
											   @Grupo VARCHAR(1),
											   @CodDocente VARCHAR(5)
AS
BEGIN
	-- Eliminar una asignatura de la tabla TCatalogo
	DELETE FROM TCatalogo
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND 
		      Grupo = @Grupo AND CodDocente = @CodDocente
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA HORARIO-ASIGNATURA ****************** */

-- Procedimiento para buscar el horario de una asignatura en un catálogo. 
CREATE PROCEDURE spuBuscarHorarioAsignatura @CodSemestre VARCHAR(7),
										    @Texto1 VARCHAR(20), -- código (ej. IF065) o nombre de la asignatura
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

-- Procedimiento para obtener el horario semanal de las asignaturas asignadas a un docente.
CREATE PROCEDURE spuHorarioSemanalDocente @CodSemestre VARCHAR(7),
										  @Texto VARCHAR(20) -- código o nombre del docente
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













--Procedimiento para obtener las horas que se le asignó a un docente
CREATE PROCEDURE spuHorasDocenteHorarioAsignatura @CodDocente VARCHAR(5)
AS
BEGIN
	--Extraer solo las horas de un docente
	SELECT HorasTeoria,HorasPractica
		FROM THorarioAsignatura
		WHERE CodDocente = @CodDocente
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
												@Tipo VARCHAR(1),
											    @HorasTeoria INT,
											    @HorasPractica INT,
											    @HoraInicio VARCHAR(2),
											    @HoraFin VARCHAR(2),
									            @Aula VARCHAR(10),
											    @Modalidad VARCHAR(10)	
AS
BEGIN
	-- Actualizar una asignatura de la tabla THorarioAsignatura
	UPDATE THorarioAsignatura
		SET CodSemestre = @CodSemestre,
			CodAsignatura = @CodAsignatura,
		    CodEscuelaP = @CodEscuelaP,
			Grupo = @Grupo,
			CodDocente = @CodDocente,
		    Dia = @Dia,
			Tipo = @Tipo,
			HorasTeoria = @HorasTeoria,
			HorasPractica = @HorasPractica,
			HoraInicio = @HoraInicio,
			HoraFin = @HoraFin,
			Aula = @Aula,
			Modalidad = @Modalidad

		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND
      		  Grupo = @Grupo AND CodDocente = @CodDocente AND Dia = @Dia
END;
GO

-- Procedimiento para eliminar el horario de una asignatura.
CREATE PROCEDURE spuEliminarHorarioAsignatura @CodSemestre VARCHAR(7),
											  @CodAsignatura VARCHAR(6),
											  @CodEscuelaP VARCHAR(3),
											  @Grupo VARCHAR(1),
											  @CodDocente VARCHAR(5),
											  @Dia VARCHAR(2)
AS
BEGIN
	-- Eliminar una asignatura de la tabla THorarioAsignatura
	DELETE FROM THorarioAsignatura
		WHERE CodSemestre = @CodSemestre AND CodAsignatura = @CodAsignatura AND CodEscuelaP = @CodEscuelaP AND
      		  Grupo = @Grupo AND CodDocente = @CodDocente AND Dia = @Dia
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
											    @Texto VARCHAR(20) -- código (ej. IF085AIN) o nombre de la asignatura
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
									    @CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Actualizar una matricula de la tabla de TMatricula
	UPDATE TMatricula
		SET CodSemestre = @CodSemestre, CodEscuelaP = @CodEscuelaP, CodAsignatura = @CodAsignatura, CodEstudiante = @CodEstudiante
		WHERE CodSemestre = @CodSemestre AND CodEscuelaP = @CodEscuelaP AND 
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