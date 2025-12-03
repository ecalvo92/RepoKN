USE [master]
GO

CREATE DATABASE [BD_KN]
GO

USE [BD_KN]
GO

CREATE TABLE [dbo].[tbCarrito](
	[ConsecutivoCarrito] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[ConsecutivoProducto] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_tbCarrito] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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

CREATE TABLE [dbo].[tbDetalle](
	[ConsecutivoDetalle] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoFactura] [int] NOT NULL,
	[ConsecutivoProducto] [int] NOT NULL,
	[PrecioUnitarioPagado] [decimal](10, 2) NOT NULL,
	[CantidadUnidades] [int] NOT NULL,
	[SubTotal] [decimal](10, 2) NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[Impuesto] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_tbDetalle] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbFactura](
	[ConsecutivoFactura] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[CantidadProductos] [int] NOT NULL,
	[TotalPagado] [decimal](10, 2) NOT NULL,
	[MetodoPago] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbFactura] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoFactura] ASC
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

SET IDENTITY_INSERT [dbo].[tbCarrito] ON 
GO
INSERT [dbo].[tbCarrito] ([ConsecutivoCarrito], [ConsecutivoUsuario], [ConsecutivoProducto], [Fecha], [Cantidad]) VALUES (23, 4, 5, CAST(N'2025-12-02T20:26:49.737' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tbCarrito] OFF
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

SET IDENTITY_INSERT [dbo].[tbDetalle] ON 
GO
INSERT [dbo].[tbDetalle] ([ConsecutivoDetalle], [ConsecutivoFactura], [ConsecutivoProducto], [PrecioUnitarioPagado], [CantidadUnidades], [SubTotal], [Total], [Impuesto]) VALUES (4, 3, 5, CAST(65.00 AS Decimal(10, 2)), 1, CAST(65.00 AS Decimal(10, 2)), CAST(73.45 AS Decimal(10, 2)), CAST(8.45 AS Decimal(10, 2)))
GO
INSERT [dbo].[tbDetalle] ([ConsecutivoDetalle], [ConsecutivoFactura], [ConsecutivoProducto], [PrecioUnitarioPagado], [CantidadUnidades], [SubTotal], [Total], [Impuesto]) VALUES (5, 3, 1002, CAST(600.00 AS Decimal(10, 2)), 1, CAST(600.00 AS Decimal(10, 2)), CAST(678.00 AS Decimal(10, 2)), CAST(78.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[tbDetalle] ([ConsecutivoDetalle], [ConsecutivoFactura], [ConsecutivoProducto], [PrecioUnitarioPagado], [CantidadUnidades], [SubTotal], [Total], [Impuesto]) VALUES (6, 4, 1002, CAST(600.00 AS Decimal(10, 2)), 8, CAST(4800.00 AS Decimal(10, 2)), CAST(5424.00 AS Decimal(10, 2)), CAST(624.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[tbDetalle] ([ConsecutivoDetalle], [ConsecutivoFactura], [ConsecutivoProducto], [PrecioUnitarioPagado], [CantidadUnidades], [SubTotal], [Total], [Impuesto]) VALUES (7, 5, 5, CAST(65.00 AS Decimal(10, 2)), 1, CAST(65.00 AS Decimal(10, 2)), CAST(73.45 AS Decimal(10, 2)), CAST(8.45 AS Decimal(10, 2)))
GO
INSERT [dbo].[tbDetalle] ([ConsecutivoDetalle], [ConsecutivoFactura], [ConsecutivoProducto], [PrecioUnitarioPagado], [CantidadUnidades], [SubTotal], [Total], [Impuesto]) VALUES (8, 5, 1002, CAST(400.00 AS Decimal(10, 2)), 3, CAST(1200.00 AS Decimal(10, 2)), CAST(1356.00 AS Decimal(10, 2)), CAST(156.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[tbDetalle] OFF
GO

SET IDENTITY_INSERT [dbo].[tbFactura] ON 
GO
INSERT [dbo].[tbFactura] ([ConsecutivoFactura], [Fecha], [ConsecutivoUsuario], [CantidadProductos], [TotalPagado], [MetodoPago]) VALUES (3, CAST(N'2025-12-02T18:54:12.080' AS DateTime), 1004, 2, CAST(751.45 AS Decimal(10, 2)), N'Pago en efectivo')
GO
INSERT [dbo].[tbFactura] ([ConsecutivoFactura], [Fecha], [ConsecutivoUsuario], [CantidadProductos], [TotalPagado], [MetodoPago]) VALUES (4, CAST(N'2025-12-02T19:24:39.490' AS DateTime), 4, 8, CAST(5424.00 AS Decimal(10, 2)), N'Tarjetazo')
GO
INSERT [dbo].[tbFactura] ([ConsecutivoFactura], [Fecha], [ConsecutivoUsuario], [CantidadProductos], [TotalPagado], [MetodoPago]) VALUES (5, CAST(N'2025-12-02T19:27:23.580' AS DateTime), 4, 4, CAST(1429.45 AS Decimal(10, 2)), N'efectivo')
GO
SET IDENTITY_INSERT [dbo].[tbFactura] OFF
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
INSERT [dbo].[tbProducto] ([ConsecutivoProducto], [Nombre], [Descripcion], [Precio], [ConsecutivoCategoria], [Estado], [Imagen], [Cantidad]) VALUES (5, N'EchoDot Nueva Generación', N'Prueba de registro', CAST(65.00 AS Decimal(10, 2)), 5, 1, N'/ImgProductos/5.png', 1)
GO
INSERT [dbo].[tbProducto] ([ConsecutivoProducto], [Nombre], [Descripcion], [Precio], [ConsecutivoCategoria], [Estado], [Imagen], [Cantidad]) VALUES (1002, N'Play Station 5', N'Consola de videojuegos', CAST(400.00 AS Decimal(10, 2)), 3, 1, N'/ImgProductos/1002.png', 7)
GO
SET IDENTITY_INSERT [dbo].[tbProducto] OFF
GO

SET IDENTITY_INSERT [dbo].[tbUsuario] ON 
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (4, N'119600898', N'VEGA MURILLO JUAN PABLO', N'jvega00898@ufide.ac.cr', N'00898', 1, 2)
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (1003, N'119780659', N'IGNACIO AGUILAR FERNANDEZ', N'iaguilar80659@ufide.ac.cr', N'80659', 1, 1)
GO
INSERT [dbo].[tbUsuario] ([ConsecutivoUsuario], [Identificacion], [Nombre], [CorreoElectronico], [Contrasenna], [Estado], [ConsecutivoPerfil]) VALUES (1004, N'208410551', N'ALVARADO TRIGUEROS JUSTIN', N'jalvarado10551@ufide.ac.cr', N'10551', 1, 2)
GO
SET IDENTITY_INSERT [dbo].[tbUsuario] OFF
GO

ALTER TABLE [dbo].[tbUsuario] ADD  CONSTRAINT [UK_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[tbUsuario] ADD  CONSTRAINT [UK_Identificacion] UNIQUE NONCLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbCarrito]  WITH CHECK ADD  CONSTRAINT [FK_tbCarrito_tbProducto] FOREIGN KEY([ConsecutivoProducto])
REFERENCES [dbo].[tbProducto] ([ConsecutivoProducto])
GO
ALTER TABLE [dbo].[tbCarrito] CHECK CONSTRAINT [FK_tbCarrito_tbProducto]
GO

ALTER TABLE [dbo].[tbCarrito]  WITH CHECK ADD  CONSTRAINT [FK_tbCarrito_tbUsuario] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[tbUsuario] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[tbCarrito] CHECK CONSTRAINT [FK_tbCarrito_tbUsuario]
GO

ALTER TABLE [dbo].[tbDetalle]  WITH CHECK ADD  CONSTRAINT [FK_tbDetalle_tbDetalle] FOREIGN KEY([ConsecutivoFactura])
REFERENCES [dbo].[tbFactura] ([ConsecutivoFactura])
GO
ALTER TABLE [dbo].[tbDetalle] CHECK CONSTRAINT [FK_tbDetalle_tbDetalle]
GO

ALTER TABLE [dbo].[tbDetalle]  WITH CHECK ADD  CONSTRAINT [FK_tbDetalle_tbProducto] FOREIGN KEY([ConsecutivoProducto])
REFERENCES [dbo].[tbProducto] ([ConsecutivoProducto])
GO
ALTER TABLE [dbo].[tbDetalle] CHECK CONSTRAINT [FK_tbDetalle_tbProducto]
GO

ALTER TABLE [dbo].[tbFactura]  WITH CHECK ADD  CONSTRAINT [FK_tbFactura_tbUsuario] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[tbUsuario] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[tbFactura] CHECK CONSTRAINT [FK_tbFactura_tbUsuario]
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

CREATE PROCEDURE [dbo].[RealizarPago]
	@ConsecutivoUsuario INT,
	@MetodoPago VARCHAR(50)
AS
BEGIN
	
	--1
    INSERT	INTO tbFactura (Fecha,ConsecutivoUsuario,CantidadProductos,TotalPagado,MetodoPago)
    SELECT	GETDATE(), ConsecutivoUsuario, SUM(C.Cantidad), SUM((C.Cantidad * P.Precio) * 1.13), @MetodoPago
    FROM	tbCarrito C
	INNER	JOIN tbProducto P ON C.ConsecutivoProducto = P.ConsecutivoProducto
	WHERE	ConsecutivoUsuario = @ConsecutivoUsuario
	GROUP	BY ConsecutivoUsuario

	--2
    INSERT	INTO dbo.tbDetalle (ConsecutivoFactura,ConsecutivoProducto,PrecioUnitarioPagado,CantidadUnidades,SubTotal,Total,Impuesto)
    SELECT	@@identity, C.ConsecutivoProducto, P.Precio, C.Cantidad, C.Cantidad * P.Precio, 
			(C.Cantidad * P.Precio) * 1.13, (C.Cantidad * P.Precio) * 0.13
    FROM	tbCarrito C
	INNER	JOIN tbProducto P ON C.ConsecutivoProducto = P.ConsecutivoProducto
	WHERE	ConsecutivoUsuario = @ConsecutivoUsuario

	--3
	UPDATE	P
	SET		P.Cantidad = P.Cantidad - C.Cantidad
	FROM	tbProducto P
	INNER	JOIN tbCarrito C ON P.ConsecutivoProducto = C.ConsecutivoProducto
	WHERE	ConsecutivoUsuario = @ConsecutivoUsuario

	--4
	DELETE	FROM tbCarrito 
	WHERE	ConsecutivoUsuario = @ConsecutivoUsuario

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