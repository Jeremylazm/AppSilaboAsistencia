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

CREATE FUNCTION fnObtenerEscuelaEstudiante (@CodEstudiante VARCHAR(6))
RETURNS VARCHAR(4)
AS
BEGIN
	-- Declarar una variable para el codigo de la escuela profesional
	DECLARE @CodEscuelaP VARCHAR(4);

	-- Obtener la escuela profesional del estudiante
	SELECT @CodEscuelaP = CodEscuelaP
		FROM TEstudiante
		WHERE CodEstudiante = @CodEstudiante

	-- Retornar la escuela profesional del estudiante
    RETURN @CodEscuelaP;
END;
GO

CREATE FUNCTION fnObtenerEscuelaDocente (@CodDocente VARCHAR(5))
RETURNS VARCHAR(4)
AS
BEGIN
	-- Declarar una variable para el codigo de la escuela profesional
	DECLARE @CodEscuelaP VARCHAR(4);

	-- Obtener la escuela profesional del docente
	SELECT @CodEscuelaP = CodEscuelaP
		FROM TDocente
		WHERE CodDocente = @CodDocente

	-- Retornar la escuela profesional del docente
    RETURN @CodEscuelaP;
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ESTUDIANTE ****************** */

-- Procedimiento para mostrar los estudiantes de una escuela profesional. 
CREATE PROCEDURE spuMostrarEstudiantes @CodEscuelaP VARCHAR(4)
AS
BEGIN
	-- Mostrar la tabla TEstudiante
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodEstudiante, APaterno, AMaterno, Nombre, Email, Direccion, Telefono
		FROM TEstudiante 
	    WHERE CodEscuelaP = @CodEscuelaP
END;
GO

-- Procedimiento para buscar un estudiante (por su código) de una escuela profesional.
CREATE PROCEDURE spuBuscarEstudiante @CodEscuelaP VARCHAR(4),
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
CREATE PROCEDURE spuBuscarEstudiantes @CodEscuelaP VARCHAR(4),
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
									   @CodEscuelaP VARCHAR(4)
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
										 @CodEscuelaP VARCHAR(4)					
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
CREATE PROCEDURE spuMostrarDocentes @CodEscuelaP VARCHAR(4)
AS
BEGIN
	-- Mostrar la tabla TDocente
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
	    WHERE CodEscuelaP = @CodEscuelaP
END;
GO

-- Procedimiento para buscar un docente (por su código) de una escuela profesional.
CREATE PROCEDURE spuBuscarDocente @CodEscuelaP VARCHAR(4),
								  @CodDocente VARCHAR(5)
AS
BEGIN
	-- Mostrar la información del docente
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
		WHERE CodEscuelaP = @CodEscuelaP AND CodDocente = @CodDocente
END;
GO

-- Procedimiento para buscar por cualquier atributo los docentes de una escuela profesional.
CREATE PROCEDURE spuBuscarDocentes @CodEscuelaP VARCHAR(4),
								   @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla TDocente por el texto que se desea buscar
	SELECT Perfil1 = Perfil, Perfil2 = Perfil, CodDocente, APaterno, AMaterno, Nombre, Email, Direccion, Telefono, Categoria, 
	       Subcategoria, Regimen
		FROM TDocente
		WHERE CodEscuelaP = @CodEscuelaP AND
		     (CodDocente LIKE (@Texto + '%') OR
			  APaterno LIKE (@Texto + '%') OR
			  AMaterno LIKE (@Texto + '%') OR
			  Nombre LIKE (@Texto + '%') OR
			  Email LIKE (@Texto + '%') OR
			  Direccion LIKE (@Texto + '%') OR
			  Telefono LIKE (@Texto + '%') OR
			  Categoria LIKE (@Texto + '%') OR
			  Subcategoria LIKE (@Texto + '%') OR
			  Regimen LIKE (@Texto + '%'))
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
									@CodEscuelaP VARCHAR(4)
AS
BEGIN
	-- Insertar un docente en la tabla TDocente
	INSERT INTO TDocente
		VALUES (@Perfil, @CodDocente, @APaterno, @AMaterno, @Nombre, @Email, @Direccion, @Telefono, @Categoria, @Subcategoria,
         		@Regimen, @CodEscuelaP)

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
									  @CodEscuelaP VARCHAR(4)				
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

-- Procedimiento para mostrar las asignaturas de una escuela profesional.
CREATE PROCEDURE spuMostrarAsignaturas @CodEscuelaP VARCHAR(4)
AS
BEGIN
	-- Mostrar la tabla TAsignatura
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica
		FROM TAsignatura
	    WHERE CodEscuelaP = @CodEscuelaP
END;
GO

-- Procedimiento para buscar una asignatura de una escuela profesional.
CREATE PROCEDURE spuBuscarAsignatura @CodEscuelaP VARCHAR(4),
									 @CodAsignatura VARCHAR(8)
AS
BEGIN
	-- Mostrar la tabla TAsignatura por el texto que se desea buscar
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica
		FROM TAsignatura
		WHERE CodEscuelaP = @CodEscuelaP AND CodAsignatura = @CodAsignatura
END;
GO

-- Procedimiento para buscar por cualquier atributo las asignaturas de una escuela profesional.
CREATE PROCEDURE spuBuscarAsignaturas @CodEscuelaP VARCHAR(4),
									  @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla TAsignatura por el texto que se desea buscar
	SELECT CodAsignatura, NombreAsignatura, Creditos, Categoria, HorasTeoria, HorasPractica
		FROM TAsignatura
		WHERE CodEscuelaP = @CodEscuelaP AND 
			 (CodAsignatura LIKE (@Texto + '%') OR
			  NombreAsignatura LIKE (@Texto + '%') OR
			  Creditos LIKE (@Texto + '%') OR
			  Categoria LIKE (@Texto + '%') OR
			  HorasTeoria LIKE (@Texto + '%') OR
			  HorasPractica LIKE (@Texto + '%'))
END;
GO

-- Procedimiento para insertar una asignatura.
CREATE PROCEDURE spuInsertarAsignatura @CodEscuelaP VARCHAR(4),
									   @CodAsignatura VARCHAR(8),
									   @NombreAsignatura VARCHAR(50),
									   @Creditos INT,
									   @Categoria VARCHAR(5),
									   @HorasTeoria INT,
									   @HorasPractica INT
AS
BEGIN
	-- Insertar una asignatura en la tabla TAsignatura
	INSERT INTO TAsignatura
		VALUES (@CodEscuelaP, @CodAsignatura, @NombreAsignatura, @Creditos, @Categoria, @HorasTeoria, @HorasPractica)
END;
GO

-- Procedimiento para actualizar una asignatura.
CREATE PROCEDURE spuActualizarAsignatura @CodEscuelaP VARCHAR(4),
									     @CodAsignatura VARCHAR(8),
									     @NombreAsignatura VARCHAR(50),
									     @Creditos INT,
									     @Categoria VARCHAR(5),
									     @HorasTeoria INT,
									     @HorasPractica INT	
AS
BEGIN
	-- Actualizar una asignatura de la tabla TAsignatura
	UPDATE TAsignatura
		SET CodEscuelaP = @CodEscuelaP,
		    CodAsignatura = @CodAsignatura,
			NombreAsignatura = @NombreAsignatura,
		    Creditos = @Creditos,
			Categoria = @Categoria,
			HorasTeoria = @HorasTeoria, 
			HorasPractica = @HorasPractica 

		WHERE CodEscuelaP = @CodEscuelaP AND CodAsignatura = @CodAsignatura
END;
GO

-- Procedimiento para eliminar una asignatura.
CREATE PROCEDURE spuEliminarAsignatura @CodEscuelaP VARCHAR(4),
									   @CodAsignatura VARCHAR(8)					
AS
BEGIN
	-- Eliminar una asignatura de la tabla TAsignatura
	DELETE FROM TAsignatura
		WHERE CodEscuelaP = @CodEscuelaP AND CodAsignatura = @CodAsignatura
END;
GO

