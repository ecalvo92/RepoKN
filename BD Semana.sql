USE [master]
GO

CREATE DATABASE [KN_BD]
GO

USE [KN_BD]
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

CREATE TABLE [dbo].[tbUsuario](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](15) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[CorreoElectronico] [varchar](100) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tbUsuario] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
SET IDENTITY_INSERT [dbo].[tbError] OFF
GO

SET IDENTITY_INSERT [dbo].[tbUsuario] ON 
GO
INSERT [dbo].[tbUsuario] ([Consecutivo], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado]) VALUES (1, N'304590415', N'EDUARDO JOSE CALVO CASTILLO', N'ecalvo90415@ufide.ac.cr', N'90415*', 1)
GO
INSERT [dbo].[tbUsuario] ([Consecutivo], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado]) VALUES (2, N'207960874', N'CORELLA SANCHEZ BRANDON JOSUE', N'bcorella60874@ufide.ac.cr', N'60874*', 1)
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

CREATE PROCEDURE [dbo].[spIniciarSesion]
    @CorreoElectronico    varchar(100),
    @Contrasenna          varchar(10)
AS
BEGIN
	
    SELECT  Consecutivo,
            Identificacion,
            Nombre,
            CorreoElectronico,
            Estado
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

        INSERT INTO dbo.tbUsuario(Identificacion,Nombre,CorreoElectronico,Contrasenna,Estado)
        VALUES (@Identificacion,@Nombre,@CorreoElectronico,@Contrasenna,@vEstado)

    END

END
GO