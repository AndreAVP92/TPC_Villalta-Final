CREATE DATABASE VILLALTA_DB
GO

USE VILLALTA_DB	
GO

CREATE TABLE FOTO(
	IdFoto  INT		IDENTITY(1,1)	NOT NULL,
	Imagen	IMAGE					NOT NULL,
	Estado	BIT						NOT NULL,

	CONSTRAINT PK_IdFoto PRIMARY KEY (IdFoto)
);

CREATE TABLE USUARIO(
	IdUsuario		INT			IDENTITY(1,1)	NOT NULL,
	IdFoto_U		INT								NULL,
	Nombre			varchar(30)						NULL,
	Telfono			INT								NULL,
	Email			VARCHAR(30)					NOT NULL,
	Contrasenia		VARCHAR(30)					NOT NULL,
	EstadoConexion	VARCHAR(15)					NOT NULL,
	FechaRegistro	DATE DEFAULT				getDate(),
	Rol				CHAR						NOT NULL,
	Estado			BIT							NOT NULL,
	
	CONSTRAINT PK_IdUsuario PRIMARY KEY (IdUsuario),
	CONSTRAINT FK_IdFoto_U FOREIGN KEY (IdFoto_U) REFERENCES FOTO (IdFoto)
);

CREATE TABLE CLIENTE(
	IdCliente	INT		IDENTITY(1,1)	NOT NULL,
	IdUsuario_C INT							NULL,
	Valoracion	FLOAT					NOT NULL,
	Estado		BIT						NOT NULL,

	CONSTRAINT PK_IdCliente PRIMARY KEY (IdCliente),
	CONSTRAINT FK_IdUsuario_C FOREIGN KEY (IdUsuario_C) REFERENCES USUARIO (IdUsuario)
);
ALTER TABLE CLIENTE
ALTER COLUMN Valoracion NUMERIC(5,2) NOT NULL

CREATE TABLE PROFESIONAL(
	IdProfesional		INT		IDENTITY(1,1)	NOT NULL,
	IdUsuario_P			INT							NULL,
	Cuit				BIGINT						NOT NULL,
	Valoracion			FLOAT					NOT NULL,
	Estado				BIT						NOT NULL,

	CONSTRAINT PK_IdProfesional PRIMARY KEY (IdProfesional),
	CONSTRAINT FK_IdUsuario_P FOREIGN KEY (IdUsuario_P) REFERENCES USUARIO (IdUsuario),
);
ALTER TABLE PROFESIONAL
ALTER COLUMN Valoracion NUMERIC(5,2) NOT NULL

CREATE TABLE ADMINISTRADOR(
	IdAdmin			INTEGER		IDENTITY(1,1)	NOT NULL,
	IdUsuario_A		INT								NULL,
	Estado			BIT							NOT NULL,

	CONSTRAINT PK_IdAdmin PRIMARY KEY (IdAdmin),
	CONSTRAINT FK_IdUsuario_A FOREIGN KEY (IdUsuario_A) REFERENCES USUARIO (IdUsuario)
);

CREATE TABLE SUB_RUBRO(
	IdSubRubro			INT			IDENTITY(1,1)	NOT NULL,
	Descripcion_SR		VARCHAR(15)					NOT NULL,
	Estado				BIT							NOT NULL,
	
	CONSTRAINT PK_IdSubRubro PRIMARY KEY (IdSubRubro),
);

CREATE TABLE RUBRO(
	IdRubro			INT			IDENTITY(1,1)	NOT NULL,
	Descripcion_R	VARCHAR(15)					NOT NULL,
	Estado			BIT							NOT NULL,

	CONSTRAINT PK_IdRubro PRIMARY KEY (IdRubro),
);

CREATE TABLE SUBRUBROxRUBRO(
	IdRubro_SRR		INT		NOT NULL,
	IdSubRubro_SRR	INT		NOT NULL,

	CONSTRAINT PK_SRR PRIMARY KEY(IdRubro_SRR, IdSubRubro_SRR),
	CONSTRAINT FK_IdRubro_SRR FOREIGN KEY (IdRubro_SRR) REFERENCES RUBRO (IdRubro),
	CONSTRAINT FK_IdSubRubro_SRR FOREIGN KEY (IdSubRubro_SRR) REFERENCES SUB_RUBRO (IdSubRubro)
);

CREATE TABLE RUBROxPROFESIONAL(
	IdProfesional_RP	INT		NOT NULL,
	IdRubro_RP			INT		NOT NULL,

	CONSTRAINT PK_RUBROxPROFESIONAL	PRIMARY KEY (IdProfesional_RP, IdRubro_RP),
	CONSTRAINT FK_IdProfesional_RP FOREIGN KEY (IdProfesional_RP) REFERENCES PROFESIONAL (IdProfesional),
	CONSTRAINT FK_IdRubro_RP FOREIGN KEY (IdRubro_RP) REFERENCES RUBRO (IdRubro),
);
GO

CREATE TABLE ESTADO_CONTRATO(
	IdEstadoContrato	INTEGER		IDENTITY(1,1)	NOT NULL,
	Descripcion_EC		VARCHAR(15)					NOT NULL,
	Estado				BIT							NOT NULL,

	CONSTRAINT PK_ESTADO_CONTRATO PRIMARY KEY (IdEstadoContrato)
);

CREATE TABLE PAGO(
	IdPago			INTEGER IDENTITY(1,1)	NOT NULL,
	Descripcion_P	VARCHAR(15)				NOT NULL,
	Estado			BIT						NOT NULL,

	CONSTRAINT PK_IdPago PRIMARY KEY (IdPago)
);

CREATE TABLE CONTRATO(
	IdContrato			INT		IDENTITY(1,1)	NOT NULL,
	IdCliente_C			INT						NOT NULL,
	IdProfesional_C		INT						NOT NULL,
	IdRubro_C			INT						NOT NULL,
	IdPago_C			INT						NOT NULL,
	Descripcion_C		VARCHAR(125)			NOT NULL,
	Direccion_C			VARCHAR(30)				NOT NULL,
	Importe				FLOAT						NOT NULL,
	Fecha_Contrato		DATE DEFAULT			getDate(),
	IdEstadoContrato_C	INT						NOT NULL,
	Estado				BIT						NOT NULL,
	
	CONSTRAINT PK_IdContrato PRIMARY KEY (IdContrato),
	CONSTRAINT FK_IdCliente_C		 FOREIGN KEY (IdCliente_C)		  REFERENCES CLIENTE			(IdCliente),
	CONSTRAINT FK_RubroxProfesional	 FOREIGN KEY (IdProfesional_C, IdRubro_C) REFERENCES RUBROxPROFESIONAL	(IdProfesional_RP, IdRubro_RP),
	CONSTRAINT FK_IdPago_C			 FOREIGN KEY (IdPago_C)			  REFERENCES PAGO				(IdPago),
	CONSTRAINT FK_IdEstadoContrato_C FOREIGN KEY (IdEstadoContrato_C) REFERENCES ESTADO_CONTRATO	(IdEstadoContrato)
);
ALTER TABLE CONTRATO
ALTER COLUMN Importe NUMERIC(8,2)
--No olvidar: Agregar el tel�fono del cliente a la tabla CONTRATOs

CREATE TABLE IMAGEN_PORTFOLIO(
	IdImagenPort	INTEGER		IDENTITY(1,1) NOT NULL,
	URLImagenPort	IMAGE						  NULL,
	Descripcion_IP	VARCHAR(20)				      NULL,
	Estado			BIT						  NOT NULL, 

	CONSTRAINT PK_IdImagenPort PRIMARY KEY (IdImagenPort)
);

CREATE TABLE PORTFOLIO(
	IdPort				INTEGER			IDENTITY(1,1)	NOT NULL,
	IdImagenPort_P		INTEGER							    NULL,
	IdProfesional_P		INT								NOT NULL,
	Estado				BIT								NOT NULL,
	
	CONSTRAINT PK_IdPost PRIMARY KEY (IdPort),
	CONSTRAINT FK_IdProfesional_P FOREIGN KEY (IdProfesional_P)	REFERENCES PROFESIONAL (IdProfesional),
	CONSTRAINT FK_IdImagenPort_P  FOREIGN KEY (IdImagenPort_P)	REFERENCES IMAGEN_PORTFOLIO (IdImagenPort)
);

CREATE TABLE RECLAMO(
	IdReclamo		INTEGER		IDENTITY(1,1)	NOT NULL,
	IdContrato_R	INT							NOT NULL,
	Motivo			VARCHAR(125)				NOT NULL,
	FechaReclamo	DATE DEFAULT				getDate(),
	Estado			BIT							NOT NULL,

	CONSTRAINT PK_IdReclamo	 PRIMARY KEY (IdReclamo),
	CONSTRAINT FK_IdContrato_R FOREIGN KEY (IdContrato_R) REFERENCES CONTRATO (IdContrato)
);

/*	---	PROCEDIMIENTOS ALMACENADOS	---	*/
--CREATE PROCEDURE INSERTAR_USUARIO
--@IdUsuario int,
--@Nombre varchar(30),
--@Email varchar(30),
--@Contrasenia varchar(30),
--@EstadoConexion varchar(15),
--@FechaRegistro datetime,
--@EstadoU bit,

--@Valoracion float,
--@EstadoC bit
--AS	
--	INSERT INTO USUARIO (Nombre, Email, Contrasenia, EstadoConexion, FechaRegistro, Estado) VALUES (@Nombre, @Email, @Contrasenia, @EstadoConexion, @FechaRegistro, @EstadoU)
	
--	 DECLARE @IdUser as int
--	 SET @IdUser = (SELECT SCOPE_IDENTITY())
--	INSERT INTO CLIENTE(IdUsuario_C,Valoracion,Estado) VALUES (@IdUsuario, @Valoracion, @EstadoC)
--	--select CodPaciente,CodUsuario,FechaRegistro from Paciente1 Where CodPaciente=@CodPaciente
--GO
-----------------------------------------------------------------
-----------------------------------------------------------------
