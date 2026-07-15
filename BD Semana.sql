USE [master]
GO

CREATE DATABASE [KN_BD]
GO

USE [KN_BD]
GO

CREATE TABLE [dbo].[tbActividad](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Inicio] [datetime] NOT NULL,
	[Fin] [datetime] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_tbActividad] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbError](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Mensaje] [varchar](max) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Lugar] [varchar](50) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_tbError] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbRol](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbRol] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbUsuario](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](15) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[CorreoElectronico] [varchar](100) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
	[TieneContrasennaTemp] [bit] NOT NULL,
	[VigenciaContrasennaTemp] [datetime] NULL,
	[ConsecutivoRol] [int] NOT NULL,
 CONSTRAINT [PK_tbUsuario] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[tbActividad] ON 
GO
INSERT [dbo].[tbActividad] ([Consecutivo], [Titulo], [Inicio], [Fin], [FechaRegistro], [ConsecutivoUsuario], [Estado]) VALUES (1, N'Tutoría de Progra', CAST(N'2026-07-15T18:00:00.000' AS DateTime), CAST(N'2026-07-15T21:00:00.000' AS DateTime), CAST(N'2026-07-14T20:48:58.863' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[tbActividad] OFF
GO

SET IDENTITY_INSERT [dbo].[tbError] ON 
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (1, N'Intento de dividir por cero.', CAST(N'2026-06-09T20:33:06.433' AS DateTime), N'Registro', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (2, N'An error occurred while updating the entries. See the inner exception for details.', CAST(N'2026-06-16T19:04:52.330' AS DateTime), N'Registro', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (3, N'An error occurred while updating the entries. See the inner exception for details.', CAST(N'2026-06-16T19:07:16.473' AS DateTime), N'Registro', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (4, N'Validation failed for one or more entities. See ''EntityValidationErrors'' property for more details.', CAST(N'2026-06-16T19:30:58.023' AS DateTime), N'Registro', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (5, N'El servidor SMTP requiere una conexión segura o el cliente no se autenticó. La respuesta del servidor fue: 5.7.57 Client not authenticated to send mail. Error: 535 5.7.139 Authentication unsuccessful, the request did not meet the criteria to be authenticated successfully. Contact your administrator. [BN9PR03CA0716.namprd03.prod.outlook.com 2026-07-01T01:57:31.695Z 08DED6A3FAA75B29]', CAST(N'2026-06-30T19:57:42.030' AS DateTime), N'RecuperarAcceso', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (6, N'La cadena especificada no tiene la forma obligatoria para una dirección de correo electrónico.', CAST(N'2026-07-07T18:49:17.293' AS DateTime), N'RecuperarAcceso', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (7, N'La cadena especificada no tiene la forma obligatoria para una dirección de correo electrónico.', CAST(N'2026-07-07T18:50:12.807' AS DateTime), N'RecuperarAcceso', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (8, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2026-07-14T18:37:50.313' AS DateTime), N'Configuracion', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (9, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2026-07-14T18:38:11.107' AS DateTime), N'Configuracion', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (10, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2026-07-14T18:40:57.507' AS DateTime), N'Configuracion', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (11, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2026-07-14T18:41:48.037' AS DateTime), N'Configuracion', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (12, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2026-07-14T18:42:15.030' AS DateTime), N'Configuracion', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (13, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2026-07-14T18:43:06.947' AS DateTime), N'Configuracion', 0)
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (14, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2026-07-14T18:43:53.943' AS DateTime), N'Configuracion', 2)
GO
SET IDENTITY_INSERT [dbo].[tbError] OFF
GO

SET IDENTITY_INSERT [dbo].[tbRol] ON 
GO
INSERT [dbo].[tbRol] ([Consecutivo], [Nombre]) VALUES (1, N'Estudiante')
GO
INSERT [dbo].[tbRol] ([Consecutivo], [Nombre]) VALUES (2, N'Tutor')
GO
SET IDENTITY_INSERT [dbo].[tbRol] OFF
GO

SET IDENTITY_INSERT [dbo].[tbUsuario] ON 
GO
INSERT [dbo].[tbUsuario] ([Consecutivo], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [TieneContrasennaTemp], [VigenciaContrasennaTemp], [ConsecutivoRol]) VALUES (1, N'304590415', N'EDUARDO JOSE CALVO CASTILLO', N'ecalvo90415@ufide.ac.cr', N'90415*', 1, 0, CAST(N'2026-07-14T19:53:56.767' AS DateTime), 2)
GO
INSERT [dbo].[tbUsuario] ([Consecutivo], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [TieneContrasennaTemp], [VigenciaContrasennaTemp], [ConsecutivoRol]) VALUES (2, N'207960874', N'BRANDON CORELLA SANCHEZ', N'bcorella60874@ufide.ac.cr', N'60874*', 1, 0, CAST(N'2026-07-07T19:43:09.890' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tbUsuario] OFF
GO

ALTER TABLE [dbo].[tbUsuario] ADD  CONSTRAINT [UK_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbUsuario] ADD  CONSTRAINT [UK_Identificacion] UNIQUE NONCLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbActividad]  WITH CHECK ADD  CONSTRAINT [FK_tbActividad_tbUsuario] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[tbUsuario] ([Consecutivo])
GO
ALTER TABLE [dbo].[tbActividad] CHECK CONSTRAINT [FK_tbActividad_tbUsuario]
GO

ALTER TABLE [dbo].[tbUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuario_tbRol] FOREIGN KEY([ConsecutivoRol])
REFERENCES [dbo].[tbRol] ([Consecutivo])
GO
ALTER TABLE [dbo].[tbUsuario] CHECK CONSTRAINT [FK_tbUsuario_tbRol]
GO

CREATE PROCEDURE [dbo].[spIniciarSesion]
    @CorreoElectronico    varchar(100),
    @Contrasenna          varchar(10)
AS
BEGIN
	
    SELECT  Consecutivo,
            Identificacion,
            Nombre,
            CorreoElectronico,
            Estado,
            TieneContrasennaTemp,
            VigenciaContrasennaTemp
      FROM  dbo.tbUsuario
      WHERE CorreoElectronico = @CorreoElectronico
        AND Contrasenna = @Contrasenna
        AND Estado = 1

END
GO

CREATE PROCEDURE [dbo].[spRegistrarError]
    @Mensaje            varchar(max),
    @FechaHora          datetime,
    @Lugar              varchar(50),
    @ConsecutivoUsuario int
AS
BEGIN
	
    INSERT INTO dbo.tbError(Mensaje,FechaHora,Lugar,ConsecutivoUsuario)
    VALUES(@Mensaje,@FechaHora,@Lugar,@ConsecutivoUsuario)

END
GO

CREATE PROCEDURE [dbo].[spRegistrarUsuario]
    @Identificacion     varchar(15),
    @Nombre             varchar(250),
    @CorreoElectronico  varchar(100),
    @Contrasenna        varchar(10)
AS
BEGIN

    IF NOT EXISTS(  SELECT 1 FROM tbUsuario
                    WHERE   Identificacion = @Identificacion
                        OR  CorreoElectronico = @CorreoElectronico )
    BEGIN

        DECLARE @vEstado BIT = 1
        DECLARE @vContrasennaTemp BIT = 0

        INSERT INTO dbo.tbUsuario(Identificacion,Nombre,CorreoElectronico,Contrasenna,Estado,TieneContrasennaTemp)
        VALUES (@Identificacion,@Nombre,@CorreoElectronico,@Contrasenna,@vEstado,@vContrasennaTemp)

    END

END
GO