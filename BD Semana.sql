USE [master]
GO

CREATE DATABASE [KN_BD]
GO

USE [KN_BD]
GO

CREATE TABLE [dbo].[EstudiantesActividades](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoActividad] [int] NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[FechaInscripcion] [datetime] NOT NULL,
 CONSTRAINT [PK_EstudiantesCursos] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbActividad](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Inicio] [datetime] NOT NULL,
	[Fin] [datetime] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[ConsecutivoEstado] [int] NOT NULL,
	[Imagen] [varchar](2000) NOT NULL,
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

CREATE TABLE [dbo].[tbEstados](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbEstados] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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

SET IDENTITY_INSERT [dbo].[EstudiantesActividades] ON 
GO
INSERT [dbo].[EstudiantesActividades] ([Consecutivo], [ConsecutivoActividad], [ConsecutivoUsuario], [FechaInscripcion]) VALUES (5, 7, 2, CAST(N'2026-08-04T20:24:56.930' AS DateTime))
GO
INSERT [dbo].[EstudiantesActividades] ([Consecutivo], [ConsecutivoActividad], [ConsecutivoUsuario], [FechaInscripcion]) VALUES (6, 9, 2, CAST(N'2026-08-04T20:48:19.770' AS DateTime))
GO
INSERT [dbo].[EstudiantesActividades] ([Consecutivo], [ConsecutivoActividad], [ConsecutivoUsuario], [FechaInscripcion]) VALUES (7, 10, 2, CAST(N'2026-08-04T20:48:48.823' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[EstudiantesActividades] OFF
GO

SET IDENTITY_INSERT [dbo].[tbActividad] ON 
GO
INSERT [dbo].[tbActividad] ([Consecutivo], [Titulo], [Inicio], [Fin], [FechaRegistro], [ConsecutivoUsuario], [ConsecutivoEstado], [Imagen]) VALUES (7, N'Curso de SQL Server', CAST(N'2026-08-06T18:00:00.000' AS DateTime), CAST(N'2026-08-06T21:00:00.000' AS DateTime), CAST(N'2026-07-28T19:32:59.480' AS DateTime), 1, 1, N'7.png')
GO
INSERT [dbo].[tbActividad] ([Consecutivo], [Titulo], [Inicio], [Fin], [FechaRegistro], [ConsecutivoUsuario], [ConsecutivoEstado], [Imagen]) VALUES (8, N'Prueba', CAST(N'2026-08-05T18:00:00.000' AS DateTime), CAST(N'2026-08-05T21:00:00.000' AS DateTime), CAST(N'2026-07-28T20:59:46.493' AS DateTime), 1, 3, N'8.png')
GO
INSERT [dbo].[tbActividad] ([Consecutivo], [Titulo], [Inicio], [Fin], [FechaRegistro], [ConsecutivoUsuario], [ConsecutivoEstado], [Imagen]) VALUES (9, N'Charla de Base de Datos Relacionales', CAST(N'2026-08-07T15:00:00.000' AS DateTime), CAST(N'2026-08-07T18:00:00.000' AS DateTime), CAST(N'2026-08-04T18:36:37.323' AS DateTime), 3, 1, N'9.png')
GO
INSERT [dbo].[tbActividad] ([Consecutivo], [Titulo], [Inicio], [Fin], [FechaRegistro], [ConsecutivoUsuario], [ConsecutivoEstado], [Imagen]) VALUES (10, N'Curso de SQL Server', CAST(N'2026-08-31T19:30:00.000' AS DateTime), CAST(N'2026-08-31T20:30:00.000' AS DateTime), CAST(N'2026-08-04T18:51:30.263' AS DateTime), 1, 1, N'10.png')
GO
INSERT [dbo].[tbActividad] ([Consecutivo], [Titulo], [Inicio], [Fin], [FechaRegistro], [ConsecutivoUsuario], [ConsecutivoEstado], [Imagen]) VALUES (11, N'Prueba10', CAST(N'2026-08-04T18:00:00.000' AS DateTime), CAST(N'2026-08-04T18:30:00.000' AS DateTime), CAST(N'2026-08-04T19:57:55.610' AS DateTime), 1, 2, N'11.png')
GO
SET IDENTITY_INSERT [dbo].[tbActividad] OFF
GO

SET IDENTITY_INSERT [dbo].[tbError] ON 
GO
INSERT [dbo].[tbError] ([Consecutivo], [Mensaje], [FechaHora], [Lugar], [ConsecutivoUsuario]) VALUES (17, N'An error occurred while preparing the command definition. See the inner exception for details.', CAST(N'2026-07-28T18:39:13.957' AS DateTime), N'Index', 0)
GO
SET IDENTITY_INSERT [dbo].[tbError] OFF
GO

SET IDENTITY_INSERT [dbo].[tbEstados] ON 
GO
INSERT [dbo].[tbEstados] ([Consecutivo], [Nombre]) VALUES (1, N'Pendiente')
GO
INSERT [dbo].[tbEstados] ([Consecutivo], [Nombre]) VALUES (2, N'Finalizada')
GO
INSERT [dbo].[tbEstados] ([Consecutivo], [Nombre]) VALUES (3, N'Cancelada')
GO
SET IDENTITY_INSERT [dbo].[tbEstados] OFF
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
INSERT [dbo].[tbUsuario] ([Consecutivo], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [TieneContrasennaTemp], [VigenciaContrasennaTemp], [ConsecutivoRol]) VALUES (3, N'305440788', N'FABIAN ARAYA BALLESTERO', N'faraya40788@ufide.ac.cr', N'40788*', 1, 0, NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[tbUsuario] OFF
GO

ALTER TABLE [dbo].[EstudiantesActividades] ADD  CONSTRAINT [UK_EstudiantesActividades] UNIQUE NONCLUSTERED 
(
	[ConsecutivoActividad] ASC,
	[ConsecutivoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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

ALTER TABLE [dbo].[EstudiantesActividades]  WITH CHECK ADD  CONSTRAINT [FK_EstudiantesCursos_tbActividad] FOREIGN KEY([ConsecutivoActividad])
REFERENCES [dbo].[tbActividad] ([Consecutivo])
GO
ALTER TABLE [dbo].[EstudiantesActividades] CHECK CONSTRAINT [FK_EstudiantesCursos_tbActividad]
GO

ALTER TABLE [dbo].[EstudiantesActividades]  WITH CHECK ADD  CONSTRAINT [FK_EstudiantesCursos_tbUsuario] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[tbUsuario] ([Consecutivo])
GO
ALTER TABLE [dbo].[EstudiantesActividades] CHECK CONSTRAINT [FK_EstudiantesCursos_tbUsuario]
GO

ALTER TABLE [dbo].[tbActividad]  WITH CHECK ADD  CONSTRAINT [FK_tbActividad_tbEstados] FOREIGN KEY([ConsecutivoEstado])
REFERENCES [dbo].[tbEstados] ([Consecutivo])
GO
ALTER TABLE [dbo].[tbActividad] CHECK CONSTRAINT [FK_tbActividad_tbEstados]
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