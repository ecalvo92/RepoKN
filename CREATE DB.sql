USE [master]
GO

CREATE DATABASE [BD_KN]
GO

USE [BD_KN]
GO

CREATE TABLE [dbo].[tbCategoria](
	[ConsecutivoCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbCategoria] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbPerfil](
	[ConsecutivoPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbPerfil] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbProducto](
	[ConsecutivoProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](2000) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[ConsecutivoCategoria] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Imagen] [varchar](250) NOT NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_tbProducto] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbUsuario](
	[ConsecutivoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](15) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[CorreoElectronico] [varchar](100) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
	[ConsecutivoPerfil] [int] NOT NULL,
 CONSTRAINT [PK_tbUsuario] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[tbCategoria] ON 
GO
INSERT [dbo].[tbCategoria] ([ConsecutivoCategoria], [Nombre]) VALUES (1, N'Computadoras y componentes')
GO
INSERT [dbo].[tbCategoria] ([ConsecutivoCategoria], [Nombre]) VALUES (2, N'Celulares y accesorios')
GO
INSERT [dbo].[tbCategoria] ([ConsecutivoCategoria], [Nombre]) VALUES (3, N'Audio y entretenimiento')
GO
INSERT [dbo].[tbCategoria] ([ConsecutivoCategoria], [Nombre]) VALUES (5, N'Hogar inteligente (Smart Home)')
GO
INSERT [dbo].[tbCategoria] ([ConsecutivoCategoria], [Nombre]) VALUES (6, N'Impresoras y consumibles')
GO
INSERT [dbo].[tbCategoria] ([ConsecutivoCategoria], [Nombre]) VALUES (7, N'Accesorios y gadgets')
GO
INSERT [dbo].[tbCategoria] ([ConsecutivoCategoria], [Nombre]) VALUES (8, N'Tecnología para oficina y punto de venta')
GO
SET IDENTITY_INSERT [dbo].[tbCategoria] OFF
GO

SET IDENTITY_INSERT [dbo].[tbPerfil] ON 
GO
INSERT [dbo].[tbPerfil] ([ConsecutivoPerfil], [Nombre]) VALUES (1, N'Usuario Administrador')
GO
INSERT [dbo].[tbPerfil] ([ConsecutivoPerfil], [Nombre]) VALUES (2, N'Usuario Regular')
GO
SET IDENTITY_INSERT [dbo].[tbPerfil] OFF
GO

SET IDENTITY_INSERT [dbo].[tbProducto] ON 
GO
INSERT [dbo].[tbProducto] ([ConsecutivoProducto], [Nombre], [Descripcion], [Precio], [ConsecutivoCategoria], [Estado], [Imagen], [Cantidad]) VALUES (5, N'EchoDot Nueva Generación', N'Prueba de registro', CAST(65.00 AS Decimal(10, 2)), 5, 0, N'/ImgProductos/5.png', 5)
GO
INSERT [dbo].[tbProducto] ([ConsecutivoProducto], [Nombre], [Descripcion], [Precio], [ConsecutivoCategoria], [Estado], [Imagen], [Cantidad]) VALUES (1002, N'Play Station 5', N'Consola de videojuegos', CAST(600.00 AS Decimal(10, 2)), 3, 1, N'/ImgProductos/1002.png', 12)
GO
SET IDENTITY_INSERT [dbo].[tbProducto] OFF
GO

SET IDENTITY_INSERT [dbo].[tbUsuario] ON 
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (1, N'304590415', N'Eduardo', N'ecalvo90415@ufide.ac.cr', N'90415', 1, 2)
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (2, N'304590416', N'Eduardo', N'ecalvo90416@ufide.ac.cr', N'90416', 1, 2)
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (3, N'304590417', N'Alex Cesar Fajardo', N'ecalvo90417@ufide.ac.cr', N'12313221', 1, 2)
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (4, N'119600898', N'VEGA MURILLO JUAN PABLO', N'jvega00898@ufide.ac.cr', N'00898', 1, 2)
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (1003, N'119780659', N'IGNACIO AGUILAR FERNANDEZ', N'iaguilar80659@ufide.ac.cr', N'80659', 1, 1)
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

ALTER TABLE [dbo].[tbProducto]  WITH CHECK ADD  CONSTRAINT [FK_tbProducto_tbCategoria] FOREIGN KEY([ConsecutivoCategoria])
REFERENCES [dbo].[tbCategoria] ([ConsecutivoCategoria])
GO
ALTER TABLE [dbo].[tbProducto] CHECK CONSTRAINT [FK_tbProducto_tbCategoria]
GO

ALTER TABLE [dbo].[tbUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuario_tbPerfil] FOREIGN KEY([ConsecutivoPerfil])
REFERENCES [dbo].[tbPerfil] ([ConsecutivoPerfil])
GO
ALTER TABLE [dbo].[tbUsuario] CHECK CONSTRAINT [FK_tbUsuario_tbPerfil]
GO

CREATE PROCEDURE [dbo].[CrearUsuarios]
    @Identificacion     VARCHAR(15), 
    @Nombre             VARCHAR(255), 
    @CorreoElectronico  VARCHAR(100), 
    @Contrasenna        VARCHAR(10)
AS
BEGIN
	
    --Se valida si el usuario ya existe
    IF NOT EXISTS(  SELECT  1 
                    FROM    dbo.tbUsuario
                    WHERE   Identificacion = @Identificacion
                        OR  CorreoElectronico = @CorreoElectronico)
    BEGIN

        --Si no existe se manda a crear
        INSERT INTO dbo.tbUsuario (Identificacion,Nombre,CorreoElectronico,Contrasenna,Estado,ConsecutivoPerfil)
        VALUES (@Identificacion, @Nombre, @CorreoElectronico, @Contrasenna, 1, 2)

    END
END
GO

CREATE PROCEDURE [dbo].[ValidarUsuarios]
    @CorreoElectronico  VARCHAR(100), 
    @Contrasenna        VARCHAR(10)
AS
BEGIN
	
    SELECT  ConsecutivoUsuario,
            Identificacion,
            Nombre,
            CorreoElectronico,
            Contrasenna,
            Estado,
            ConsecutivoPerfil
    FROM    dbo.tbUsuario
    WHERE   CorreoElectronico = @CorreoElectronico
        AND Contrasenna = @Contrasenna
        AND Estado = 1

END
GO