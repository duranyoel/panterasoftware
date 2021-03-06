USE [master]
GO
/****** Object:  Database [panterasoftware]    Script Date: 28/11/2016 10:35:02 ******/
CREATE DATABASE [panterasoftware]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'panterasoftware', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\panterasoftware.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'panterasoftware_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\panterasoftware_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [panterasoftware] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [panterasoftware].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [panterasoftware] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [panterasoftware] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [panterasoftware] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [panterasoftware] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [panterasoftware] SET ARITHABORT OFF 
GO
ALTER DATABASE [panterasoftware] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [panterasoftware] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [panterasoftware] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [panterasoftware] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [panterasoftware] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [panterasoftware] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [panterasoftware] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [panterasoftware] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [panterasoftware] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [panterasoftware] SET  ENABLE_BROKER 
GO
ALTER DATABASE [panterasoftware] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [panterasoftware] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [panterasoftware] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [panterasoftware] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [panterasoftware] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [panterasoftware] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [panterasoftware] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [panterasoftware] SET RECOVERY FULL 
GO
ALTER DATABASE [panterasoftware] SET  MULTI_USER 
GO
ALTER DATABASE [panterasoftware] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [panterasoftware] SET DB_CHAINING OFF 
GO
ALTER DATABASE [panterasoftware] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [panterasoftware] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [panterasoftware] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'panterasoftware', N'ON'
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [panterasoftware]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [panterasoftware] WITH PASSWORD=N'hYf zKMz
Ý¿_S¸k1F(eLÅ³c/Ä.ä', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [panterasoftware] DISABLE
GO
/****** Object:  Login [NT SERVICE\winmgmt]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [NT SERVICE\winmgmt] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT SERVICE\SQLSERVERAGENT]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [NT SERVICE\SQLSERVERAGENT] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT SERVICE\ReportServer]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [NT SERVICE\ReportServer] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT Service\MSSQLSERVER]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [NT Service\MSSQLSERVER] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'`ÇÝ4¨rL->ËrÇØO©ÁAïu! 2ä` \s', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 28/11/2016 10:35:02 ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'[ðO¨_T
@§8:ÕþnÜM!v/±th¥¼á', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\winmgmt]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLWriter]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLSERVERAGENT]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT Service\MSSQLSERVER]
GO
USE [panterasoftware]
GO
/****** Object:  User [panterasoftware]    Script Date: 28/11/2016 10:35:02 ******/
CREATE USER [panterasoftware] FOR LOGIN [panterasoftware] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [panterasoftware]
GO
GRANT CONNECT TO [panterasoftware] AS [dbo]
GO
/****** Object:  Table [dbo].[auditoria_accesos]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auditoria_accesos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empresa_id] [int] NOT NULL,
	[usuario_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[hora] [time](7) NOT NULL,
	[estacion] [nvarchar](20) NOT NULL,
	[ip] [nvarchar](15) NOT NULL,
	[accion] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_auditoria_accesos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_empresas]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_empresas](
	[id] [int] IDENTITY(2,1) NOT NULL,
	[codigo] [nvarchar](5) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[cadena_conexion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_sistema_empresas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_estados]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_estados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_sistema_estados_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_funciones]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_funciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[modulo_id] [int] NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](120) NOT NULL,
	[estatus] [nvarchar](20) NOT NULL CONSTRAINT [DF_sistema_funciones_estatus]  DEFAULT (N'Activo'),
 CONSTRAINT [PK_sistema_funciones_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_grupo_funciones]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_grupo_funciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[grupo_id] [int] NOT NULL,
	[funcion_id] [int] NOT NULL,
 CONSTRAINT [PK_usuarios_grupo_permisos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_grupos]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_grupos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL CONSTRAINT [DF_usuarios_grupo_codigo]  DEFAULT ((0)),
	[nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_usuarios_grupo_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_mensajes]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_mensajes](
	[id] [int] IDENTITY(71,1) NOT NULL,
	[detalle] [nvarchar](120) NOT NULL,
	[tipo] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_sistema_mensajes_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_modulos]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_modulos](
	[id] [int] IDENTITY(13,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[estatus] [nvarchar](50) NOT NULL CONSTRAINT [DF_sistema_modulos_estatus]  DEFAULT (N'Activo'),
 CONSTRAINT [PK_sistema_modulos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_periodo_mensual]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_periodo_mensual](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [nvarchar](2) NOT NULL,
	[mes] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_sistema_periodo_mensual_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sistema_usuarios]    Script Date: 28/11/2016 10:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistema_usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empresa_id] [int] NOT NULL,
	[grupo_id] [int] NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[apellido] [nvarchar](150) NOT NULL,
	[clave] [nvarchar](20) NOT NULL,
	[usuario] [nvarchar](20) NOT NULL,
	[estatus] [nvarchar](10) NOT NULL,
	[fecha_alta] [datetime] NOT NULL CONSTRAINT [DF__usuarios__fecha___108B795B]  DEFAULT ('2000-01-01'),
	[fecha_baja] [datetime] NOT NULL CONSTRAINT [DF__usuarios__fecha___117F9D94]  DEFAULT ('2000-01-01'),
	[fecha_sesion] [datetime] NOT NULL CONSTRAINT [DF__usuarios__fecha___1273C1CD]  DEFAULT ('2000-01-01'),
 CONSTRAINT [PK_usuarios_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[sistema_empresas] ON 

INSERT [dbo].[sistema_empresas] ([id], [codigo], [nombre], [cadena_conexion]) VALUES (1, N'00001', N'JE Systems', N'Data Source=YOELDURAN-PC;Initial Catalog=00001;User ID=panterasoftware;Password=1234;Encrypt=False')
INSERT [dbo].[sistema_empresas] ([id], [codigo], [nombre], [cadena_conexion]) VALUES (4, N'00002', N'demo2', N'Data Source=DURANYOEL-LAP\SQLEXPRESS;Initial Catalog=00002;User ID=yoelduran;Password=1234;Encrypt=False')
SET IDENTITY_INSERT [dbo].[sistema_empresas] OFF
SET IDENTITY_INSERT [dbo].[sistema_funciones] ON 

INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (1, 12, N'1200101', N'Sistema, Control de Funciones', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (3, 12, N'1200301', N'Sistema, Control de Usuarios', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (4, 12, N'1200401', N'Configuracion, Control de Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (5, 12, N'1200102', N'Sistema, Registro de Funciones', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (6, 12, N'1200103', N'Sistema, Actualizar Funciones', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (7, 12, N'1200501', N'Sistema, Control de Grupos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (9, 12, N'1200502', N'Sistema, Registro Grupos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (10, 12, N'1200503', N'Sistema, Actualizar Grupos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (11, 12, N'1200504', N'Sistema, Borrar Grupos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (12, 12, N'1200505', N'Sistema, Consulta Grupos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (13, 12, N'1200104', N'Sistema, Borrar Funciones', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (14, 12, N'1200105', N'Sistema, Consulta Funciones', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (15, 12, N'1200202', N'Sistema, Registro de Modulos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (16, 12, N'1200203', N'Sistema, Actualizar Modulos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (17, 12, N'1200204', N'Sistema, Borrar Modulos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (18, 12, N'1200205', N'Sistema, Consulta Modulos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (19, 12, N'1200302', N'Sistema, Registro Usuarios', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (20, 12, N'1200303', N'Sistema, Actualizar Usuarios', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (21, 12, N'1200304', N'Sistema, Borrar Usuarios', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (22, 12, N'1200305', N'Sistema, Consulta Usuarios', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (23, 12, N'1200601', N'Sistema, Control Agregar Permisos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (24, 12, N'1200602', N'Sistema, Agregar Permisos Grupos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (25, 12, N'1200603', N'Sistema, Quitar Permisos Grupos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (26, 12, N'1200402', N'Configuracion, Registro Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (27, 12, N'1200403', N'Configuracion, Actualizar Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (28, 12, N'1200404', N'Configuracion, Borrar Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (29, 12, N'1200405', N'Configuracion, Consulta Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (30, 12, N'1200201', N'Sistema, Control de Modulos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (31, 12, N'1200701', N'Configuración, Control de Sub Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (32, 12, N'1200702', N'Configuración, Registro de Sub Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (33, 12, N'1200703', N'Configuración, Actualizar Sub Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (34, 12, N'1200704', N'Configuración, Borrar Sub Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (35, 12, N'1200705', N'Configuración, Consulta Sub Categorias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (36, 12, N'1200801', N'Empresa, Control de Tasas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (37, 12, N'1200802', N'Empresa, Registro de Tasas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (38, 12, N'1200803', N'Empresa, Actualizar Tasas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (39, 12, N'1200804', N'Empresa, Borrar Tasas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (40, 12, N'1200805', N'Empresa, Consulta Tasas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (41, 12, N'1200901', N'Empresa, Control de Agencias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (42, 12, N'1200902', N'Empresa, Registro de Agencias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (43, 12, N'1200903', N'Empresa, Actualizar Agencias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (44, 12, N'1200904', N'Empresa, Borrar Agencias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (45, 12, N'1200905', N'Empresa, Consulta de Agencias', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (46, 12, N'1201001', N'Empresa, Control de Cobradores', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (47, 12, N'1201002', N'Empresa, Registro de Cobradores', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (48, 12, N'1201003', N'Empresa, Actualizar Cobradores', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (49, 12, N'1201004', N'Empresa, Borrar Cobradores', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (50, 12, N'1201005', N'Empresa, Consulta Cobradores', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (52, 12, N'1201101', N'Empresa, Control de Depositos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (53, 12, N'1201102', N'Empresa, Registro de Depositos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (54, 12, N'1201103', N'Empresa, Actualizar Depositos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (55, 12, N'1201104', N'Empresa, Borrar Depositos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (56, 12, N'1201105', N'Empresa, Consulta de Depositos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (58, 12, N'1201201', N'Empresa, Medios Cobro y Pago', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (59, 12, N'1201203', N'Empresa, Actualizar Medios Cobro y Pago', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (60, 12, N'1201204', N'Empresa, Medios Cobro y Pago', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (61, 12, N'1201205', N'Empresa, Consulta Medios Cobro y Pago', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (62, 12, N'1201202', N'Empresa, Registro de Medios Cobro y Pago', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (63, 4, N'0400101', N'Administracion, Plan Cuentas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (64, 4, N'0400102', N'Administracion, Registro Plan Cuentas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (65, 4, N'0400103', N'Administracion, Actualizar Plan Cuentas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (66, 4, N'0400104', N'Administracion, Borrar Plan Cuentas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (67, 4, N'0400105', N'Administracion, Consulta Plan Cuentas', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (68, 4, N'0400201', N'Administracion, Control DeBancos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (69, 4, N'0400202', N'Administracion, Registro Control De Bancos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (70, 4, N'0400203', N'Administracion, Actualizar Control De Bancos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (71, 4, N'0400204', N'Administracion, Borrar Control De Bancos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (72, 4, N'0400205', N'Administracion, Consulta Control De Bancos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (73, 12, N'1201303', N'Empresa, Actualizar Datos', N'Activo')
INSERT [dbo].[sistema_funciones] ([id], [modulo_id], [codigo], [nombre], [estatus]) VALUES (74, 12, N'1201301', N'Empresa, Control de Transporte', N'Activo')
SET IDENTITY_INSERT [dbo].[sistema_funciones] OFF
SET IDENTITY_INSERT [dbo].[sistema_grupo_funciones] ON 

INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (1, 1, 1)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (2, 1, 2)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (4, 5, 1)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (5, 5, 2)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (7, 1, 5)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (8, 1, 4)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (9, 1, 3)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (10, 1, 6)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (11, 5, 3)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (13, 5, 5)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (14, 5, 6)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (15, 1, 7)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (16, 1, 9)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (17, 1, 10)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (18, 1, 11)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (19, 1, 12)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (20, 1, 13)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (21, 1, 14)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (22, 1, 15)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (23, 1, 16)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (24, 1, 17)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (25, 1, 18)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (26, 1, 19)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (27, 1, 20)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (28, 1, 21)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (29, 1, 22)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (30, 5, 7)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (31, 5, 9)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (32, 5, 10)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (33, 5, 11)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (34, 5, 12)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (35, 5, 13)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (36, 5, 14)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (37, 5, 15)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (38, 5, 16)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (39, 5, 17)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (40, 5, 18)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (41, 5, 19)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (42, 5, 20)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (43, 5, 21)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (44, 5, 22)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (45, 1, 23)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (46, 1, 24)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (47, 1, 25)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (48, 5, 23)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (49, 5, 24)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (50, 5, 25)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (51, 5, 4)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (52, 5, 26)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (53, 5, 27)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (54, 5, 28)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (55, 5, 29)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (56, 1, 26)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (57, 1, 27)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (58, 1, 28)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (59, 1, 29)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (60, 5, 30)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (61, 1, 30)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (62, 5, 31)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (63, 5, 32)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (64, 5, 33)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (65, 5, 34)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (66, 5, 35)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (67, 1, 31)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (68, 1, 32)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (69, 1, 33)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (70, 1, 34)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (71, 1, 35)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (72, 5, 36)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (73, 5, 37)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (74, 5, 38)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (75, 1, 36)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (76, 1, 38)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (77, 1, 37)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (78, 1, 39)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (79, 1, 40)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (80, 5, 39)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (81, 5, 40)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (82, 1, 41)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (83, 1, 43)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (84, 1, 42)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (85, 1, 44)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (86, 1, 45)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (87, 5, 41)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (88, 5, 42)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (89, 5, 43)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (90, 5, 44)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (91, 5, 45)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (92, 1, 46)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (93, 1, 47)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (94, 5, 46)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (95, 5, 47)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (96, 1, 48)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (97, 1, 49)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (98, 1, 50)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (99, 5, 48)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (100, 5, 49)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (101, 5, 50)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (102, 1, 52)
GO
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (103, 1, 53)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (104, 1, 54)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (105, 1, 55)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (106, 1, 56)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (107, 5, 52)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (108, 5, 53)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (109, 5, 54)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (110, 5, 55)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (111, 5, 56)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (112, 1, 58)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (113, 1, 62)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (114, 1, 59)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (115, 1, 60)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (117, 5, 58)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (118, 5, 59)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (119, 5, 60)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (120, 5, 61)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (121, 5, 62)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (122, 1, 61)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (123, 1, 63)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (124, 5, 63)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (125, 4, 63)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (126, 1, 64)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (127, 1, 65)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (128, 1, 66)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (129, 1, 67)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (130, 5, 64)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (131, 5, 65)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (132, 5, 67)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (133, 5, 66)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (134, 1, 68)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (135, 1, 69)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (136, 1, 70)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (137, 1, 71)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (138, 1, 72)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (139, 5, 68)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (140, 5, 69)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (141, 5, 70)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (142, 5, 71)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (143, 5, 72)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (144, 1, 73)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (145, 5, 73)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (146, 1, 74)
INSERT [dbo].[sistema_grupo_funciones] ([id], [grupo_id], [funcion_id]) VALUES (147, 5, 74)
SET IDENTITY_INSERT [dbo].[sistema_grupo_funciones] OFF
SET IDENTITY_INSERT [dbo].[sistema_grupos] ON 

INSERT [dbo].[sistema_grupos] ([id], [codigo], [nombre]) VALUES (1, N'00001', N'Administrador')
INSERT [dbo].[sistema_grupos] ([id], [codigo], [nombre]) VALUES (2, N'00002', N'Auxiliar')
INSERT [dbo].[sistema_grupos] ([id], [codigo], [nombre]) VALUES (4, N'00003', N'Usuario')
INSERT [dbo].[sistema_grupos] ([id], [codigo], [nombre]) VALUES (5, N'00004', N'Desarrollo')
SET IDENTITY_INSERT [dbo].[sistema_grupos] OFF
SET IDENTITY_INSERT [dbo].[sistema_mensajes] ON 

INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (1, N'Error en los datos suministrados.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (2, N'Dato duplicado', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (3, N'Código del Usuario o Clave no registrada.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (4, N'Usuario Inactivo.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (5, N'Datos guardados con éxito.', N'0')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (6, N'Imposible guardar imagen.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (7, N'No se encontraron resultados.', N'0')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (8, N'Código ya registrado.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (9, N'Depósito ya registrado.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (10, N'Imposible eliminar el registro debido a que el mismo posee movimientos.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (11, N'La categoria del producto <Bien de Servicio> no permite el manejo de depositos.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (12, N'No se puede eliminar un depósito con existencia.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (13, N'El producto no maneja seriales.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (14, N'Eliminación del registro con éxito.', N'0')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (15, N'El Documento ya se encuentra anulado.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (16, N'El Documento posee movimientos. Anule primero los movimientos.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (17, N'El monto disponible por Anticipo del cliente es insuficiente.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (18, N'El monto recibido es menor a el monto a cancelar.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (19, N'No existen documentos a procesar.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (20, N'Documento Aplica no puede estar vacio.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (21, N'Documento no puede estar vacio. ', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (22, N'Total del Documento no puede ser cero (0).', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (23, N'No cuadran los montos de Anticipo y Monto Recibido.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (24, N'Documento anulado con éxito.', N'0')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (25, N'Precio del Producto no permitido.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (26, N'Precio del Producto por debajo del costo.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (27, N'CI/RIF ya registrado.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (28, N'No se encuentra el código (VENTAS) en Conceptos de Movimientos de Inventario.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (29, N'No se encuentra el código (DEV_VENTAS) en Conceptos de Movimientos de Inventario.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (30, N'No se encuentra el código (SALIDAS) en Conceptos de Movimientos de Inventario.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (31, N'Serie Fiscal no registrada.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (32, N'Serie Fiscal Inactiva.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (33, N'Debe completar el dato Aplica Documento.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (34, N'No existen renglones en el documento para procesar.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (35, N'Debe completar los datos fiscales del cliente (Nombre,CI/RIF,Dirección)', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (36, N'Saldo restante excede del crédito disponible. ', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (37, N'Existe un límite de documentos pendientes para este cliente.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (38, N'El cliente no posee la opción de crédito activada.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (39, N'Cantidad excede del disponible.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (40, N'Cantidad distinta a seriales registrados.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (41, N'Serial no registrado para este producto.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (42, N'El serial ya se encuentra seleccionado.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (43, N'Tope máximo de seriales.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (44, N'El producto no es de tipo compuesto.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (45, N'No se encuentra registrado el documento en el sistema.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (46, N'Tasa de Retención invalida', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (47, N'No existe un formato de impresión seleccionado', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (48, N'Ha ocurrido un error al ejecutar el proceso.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (49, N'Proceso efectuado con éxito.', N'0')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (50, N'Ha ocurrido un error en el dispositivo de impresión.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (51, N'Debe completar los datos número de Documento y Control', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (52, N'No existe el depósito del producto especificado.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (53, N'Proveedor Inactivo.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (54, N'El producto no posee precio.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (55, N'Código no registrado en el sistema.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (56, N'Producto inactivo.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (57, N'Existen renglones actualmente en el documento.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (58, N'Debe especificar el concepto de movimiento de inventario.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (59, N'Clave Invalida', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (60, N'Tope maximo de usuarios conectados', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (61, N'El rif o serial de la impresora no concuerdan con el registrado en el sistema.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (62, N'No tiene permiso para esta función', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (63, N'Cantidad Invalida.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (64, N'Código del vendedor no registrado.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (65, N'Vendedor inactivo.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (66, N'Cuenta no registrada.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (67, N'Cuenta inactiva.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (68, N'Cuenta abierta.', N'1')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (69, N'Documento generado con exito. Utilice el boton Correo para efectuar el envio.', N'0')
INSERT [dbo].[sistema_mensajes] ([id], [detalle], [tipo]) VALUES (70, N'', N'0')
SET IDENTITY_INSERT [dbo].[sistema_mensajes] OFF
SET IDENTITY_INSERT [dbo].[sistema_modulos] ON 

INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (1, N'01', N'Clientes', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (2, N'02', N'Proveedores', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (3, N'03', N'Inventario', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (4, N'00004', N'Administración', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (5, N'05', N'Ctas. x Pagar', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (6, N'06', N'Caja y Bancos', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (7, N'07', N'Compras', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (8, N'08', N'Ventas', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (9, N'09', N'Vendedores', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (10, N'10', N'Producción', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (11, N'11', N'Web', N'Activo')
INSERT [dbo].[sistema_modulos] ([id], [codigo], [nombre], [estatus]) VALUES (12, N'00012', N'Configuración', N'Activo')
SET IDENTITY_INSERT [dbo].[sistema_modulos] OFF
SET IDENTITY_INSERT [dbo].[sistema_usuarios] ON 

INSERT [dbo].[sistema_usuarios] ([id], [empresa_id], [grupo_id], [nombre], [apellido], [clave], [usuario], [estatus], [fecha_alta], [fecha_baja], [fecha_sesion]) VALUES (1, 1, 5, N'YOEL ', N'DURAN', N'1234', N'yoelduran', N'Activo', CAST(N'2016-08-29 00:00:00.000' AS DateTime), CAST(N'2016-05-29 00:00:00.000' AS DateTime), CAST(N'2000-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[sistema_usuarios] ([id], [empresa_id], [grupo_id], [nombre], [apellido], [clave], [usuario], [estatus], [fecha_alta], [fecha_baja], [fecha_sesion]) VALUES (2, 1, 1, N'juan', N'rodriguez', N'1234', N'admin1', N'Activo', CAST(N'2016-04-19 00:00:00.000' AS DateTime), CAST(N'2015-12-02 00:00:00.000' AS DateTime), CAST(N'2015-12-02 08:08:05.103' AS DateTime))
INSERT [dbo].[sistema_usuarios] ([id], [empresa_id], [grupo_id], [nombre], [apellido], [clave], [usuario], [estatus], [fecha_alta], [fecha_baja], [fecha_sesion]) VALUES (3, 1, 4, N'jose', N'tirado', N'1234', N'jtirado', N'Activo', CAST(N'2016-05-28 00:00:00.000' AS DateTime), CAST(N'2016-05-28 14:51:40.470' AS DateTime), CAST(N'2016-05-28 14:51:40.470' AS DateTime))
INSERT [dbo].[sistema_usuarios] ([id], [empresa_id], [grupo_id], [nombre], [apellido], [clave], [usuario], [estatus], [fecha_alta], [fecha_baja], [fecha_sesion]) VALUES (4, 1, 5, N'YOEL', N'DURAN', N'1234', N'yduran', N'Activo', CAST(N'2016-05-29 00:00:00.000' AS DateTime), CAST(N'2016-05-29 16:41:00.587' AS DateTime), CAST(N'2016-05-29 16:41:00.587' AS DateTime))
SET IDENTITY_INSERT [dbo].[sistema_usuarios] OFF
ALTER TABLE [dbo].[auditoria_accesos] ADD  CONSTRAINT [DF__auditoria__fecha__1BFD2C07]  DEFAULT ('2010-01-01') FOR [fecha]
GO
USE [master]
GO
ALTER DATABASE [panterasoftware] SET  READ_WRITE 
GO
