USE [BDprogramacionV]
GO
/****** Object:  Table [dbo].[Canton]    Script Date: 18/04/2019 8:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canton](
	[provinciaId] [int] NOT NULL,
	[cantonId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](85) NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_Canton_1] PRIMARY KEY CLUSTERED 
(
	[cantonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carrito]    Script Date: 18/04/2019 8:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carrito](
	[productoId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[cantidad_producto] [int] NOT NULL,
	[fecha_agregado] [datetime2](7) NOT NULL,
	[fecha_modificado] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Productoid_userid] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC,
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 18/04/2019 8:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](120) NULL,
	[descripcion] [text] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[colecciones]    Script Date: 18/04/2019 8:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[colecciones](
	[id_coleccion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](120) NULL,
	[descripcion] [text] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_colecciones] PRIMARY KEY CLUSTERED 
(
	[id_coleccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[distribuidor]    Script Date: 18/04/2019 8:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[distribuidor](
	[id_distribuidor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NULL,
	[email] [varchar](450) NULL,
	[direccion] [text] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_distribuidor] PRIMARY KEY CLUSTERED 
(
	[id_distribuidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 18/04/2019 8:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[provinciaId] [int] NOT NULL,
	[cantonId] [int] NOT NULL,
	[distritoId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](85) NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_Distrito_1] PRIMARY KEY CLUSTERED 
(
	[distritoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estados]    Script Date: 18/04/2019 8:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estados](
	[id_estado] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](80) NULL,
 CONSTRAINT [PK_estados] PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturacion_producto]    Script Date: 18/04/2019 8:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturacion_producto](
	[productoId] [int] NOT NULL,
	[facturacionId] [int] NOT NULL,
	[cantidad] [int] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_facturacion_producto] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC,
	[facturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturaciones]    Script Date: 18/04/2019 8:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturaciones](
	[facturacionId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NULL,
	[fecha] [date] NULL,
	[descripcion] [text] NULL,
	[impuesto] [int] NULL,
	[subtotal] [float] NULL,
	[total] [float] NULL,
	[tipo] [varchar](250) NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_facturaciones] PRIMARY KEY CLUSTERED 
(
	[facturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[formas_pago_facturacion]    Script Date: 18/04/2019 8:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[formas_pago_facturacion](
	[facturacionId] [int] NOT NULL,
	[forma_pago] [varchar](250) NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_formas_pago_facturacion] PRIMARY KEY CLUSTERED 
(
	[facturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genero_producto]    Script Date: 18/04/2019 8:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genero_producto](
	[productoId] [int] NOT NULL,
	[genero] [varchar](35) NULL,
 CONSTRAINT [PK_genero_producto] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[imagen_producto]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[imagen_producto](
	[productoId] [int] NOT NULL,
	[IMAGEN] [varchar](150) NOT NULL,
 CONSTRAINT [PK_imagen_producto] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC,
	[IMAGEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marcas]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marcas](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](120) NULL,
	[descripcion] [text] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_marcas] PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medida_producto]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medida_producto](
	[productoId] [int] NOT NULL,
	[medida] [float] NULL,
 CONSTRAINT [PK_medida_producto] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[paisId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](85) NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[paisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[productoId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NULL,
	[precio] [float] NULL,
	[descripcion] [text] NULL,
	[modelo] [varchar](250) NULL,
	[id_categoria] [int] NULL,
	[id_marca] [int] NULL,
	[id_coleccion] [int] NULL,
	[id_bodega] [int] NULL,
	[id_distribuidor] [int] NULL,
	[cantidad] [int] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promociones]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promociones](
	[promocionId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NULL,
	[descripcion] [text] NULL,
	[valor] [int] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_promociones] PRIMARY KEY CLUSTERED 
(
	[promocionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promociones_productos]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promociones_productos](
	[productoId] [int] NOT NULL,
	[promocionId] [int] NOT NULL,
	[fecha_inicial_promocion] [date] NULL,
	[fecha_final_promocion] [date] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_promociones_productos] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC,
	[promocionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[provinciaId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](85) NULL,
	[paisId] [int] NOT NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[provinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[ROLID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](25) NULL,
	[DESCRIPCION] [text] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[ROLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol_user]    Script Date: 18/04/2019 8:57:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol_user](
	[rolId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_rol_user] PRIMARY KEY CLUSTERED 
(
	[rolId] ASC,
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_facturaciones]    Script Date: 18/04/2019 8:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_facturaciones](
	[usuarioId] [int] NOT NULL,
	[facturacionId] [int] NOT NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_usuario_facturaciones] PRIMARY KEY CLUSTERED 
(
	[usuarioId] ASC,
	[facturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 18/04/2019 8:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NULL,
	[apellidos] [varchar](125) NULL,
	[contrasena] [varchar](125) NULL,
	[correoElectronico] [varchar](125) NULL,
	[fechaNacimiento] [date] NULL,
	[genero] [varchar](20) NULL,
	[fotoPerfil] [varchar](150) NULL,
	[telefono] [int] NULL,
	[direccion] [text] NULL,
	[paisId] [int] NULL,
	[distritoId] [int] NULL,
	[provinciaId] [int] NULL,
	[cantonId] [int] NULL,
	[Usuario_ID] [nvarchar](128) NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios_promocion]    Script Date: 18/04/2019 8:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_promocion](
	[usuarioId] [int] NOT NULL,
	[promocionId] [int] NOT NULL,
	[fecha_inicial_promocion] [date] NULL,
	[fecha_final_promocion] [date] NULL,
	[id_estado] [int] NULL,
 CONSTRAINT [PK_usuarios_promocion] PRIMARY KEY CLUSTERED 
(
	[usuarioId] ASC,
	[promocionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO