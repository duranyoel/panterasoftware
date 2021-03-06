USE [master]
GO
/****** Object:  Database [00001]    Script Date: 12/09/2017 15:08:12 ******/
CREATE DATABASE [00001]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'00001', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\00001.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'00001_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\00001_log.ldf' , SIZE = 5824KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [00001] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [00001].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [00001] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [00001] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [00001] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [00001] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [00001] SET ARITHABORT OFF 
GO
ALTER DATABASE [00001] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [00001] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [00001] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [00001] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [00001] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [00001] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [00001] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [00001] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [00001] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [00001] SET  ENABLE_BROKER 
GO
ALTER DATABASE [00001] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [00001] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [00001] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [00001] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [00001] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [00001] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [00001] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [00001] SET RECOVERY FULL 
GO
ALTER DATABASE [00001] SET  MULTI_USER 
GO
ALTER DATABASE [00001] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [00001] SET DB_CHAINING OFF 
GO
ALTER DATABASE [00001] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [00001] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [00001] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'00001', N'ON'
GO
USE [00001]
GO
/****** Object:  User [panterasoftware]    Script Date: 12/09/2017 15:08:13 ******/
CREATE USER [panterasoftware] FOR LOGIN [panterasoftware] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [panterasoftware]
GO
/****** Object:  Table [dbo].[agencias]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agencias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[direccion] [nvarchar](max) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_empresa_agencias_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bancos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bancos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL CONSTRAINT [DF_bancos_userlog_id]  DEFAULT ((0)),
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[direccion] [nvarchar](100) NOT NULL,
	[contacto] [nvarchar](100) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[fax] [nvarchar](20) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[website] [nvarchar](100) NOT NULL,
	[estatus] [nvarchar](10) NOT NULL,
	[borrado] [bit] NOT NULL CONSTRAINT [DF_bancos_borrado]  DEFAULT ((0)),
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_bancos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bancos_movimientos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bancos_movimientos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[banco_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[comprobante] [nvarchar](10) NOT NULL,
	[tipo] [nvarchar](3) NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[debe] [decimal](14, 2) NOT NULL,
	[haber] [decimal](14, 2) NOT NULL,
	[detalle] [nvarchar](120) NOT NULL,
	[aplica] [date] NOT NULL,
	[estatus_conciliado] [bit] NOT NULL,
	[estatus_anulado] [bit] NOT NULL,
	[entidad] [nvarchar](80) NOT NULL,
	[ci_rif] [nvarchar](15) NOT NULL,
	[comprobante_egreso] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_bancos_movimientos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bancos_movimientos_medios]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bancos_movimientos_medios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[importe] [decimal](14, 2) NOT NULL,
	[referencia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_bancos_movimientos_medios_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bancos_plan_cuentas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bancos_plan_cuentas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](20) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[clase] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_bancos_plan_cuentas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categorias]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](45) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_categorias_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientes]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parroquia_id] [int] NOT NULL,
	[vendedor_id] [int] NOT NULL,
	[grupo_id] [int] NOT NULL,
	[zona_id] [int] NOT NULL,
	[cobrador_id] [int] NOT NULL,
	[agencia_id] [int] NOT NULL,
	[codigo] [nvarchar](15) NOT NULL,
	[nombre] [nvarchar](80) NOT NULL,
	[ci_rif] [nvarchar](15) NOT NULL,
	[razon_social] [nvarchar](100) NOT NULL,
	[dir_fiscal] [nvarchar](120) NOT NULL,
	[dir_despacho] [nvarchar](120) NOT NULL,
	[contacto] [nvarchar](60) NOT NULL,
	[telefono_cel_cont] [nvarchar](20) NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[celular] [nvarchar](20) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[website] [nvarchar](100) NOT NULL,
	[denominacion_fiscal] [nvarchar](100) NOT NULL,
	[codigo_postal] [nvarchar](10) NOT NULL,
	[retencion_iva] [decimal](6, 2) NOT NULL,
	[retencion_islr] [decimal](6, 2) NOT NULL,
	[tarifa] [nvarchar](1) NOT NULL,
	[descuento] [decimal](6, 2) NOT NULL,
	[recargo] [decimal](6, 2) NOT NULL,
	[estatus_credito] [tinyint] NOT NULL,
	[dias_credito] [int] NOT NULL,
	[limite_credito] [decimal](14, 2) NOT NULL,
	[doc_pendientes] [int] NOT NULL,
	[estatus_morosidad] [tinyint] NOT NULL,
	[estatus_lunes] [tinyint] NOT NULL,
	[estatus_martes] [tinyint] NOT NULL,
	[estatus_miercoles] [tinyint] NOT NULL,
	[estatus_jueves] [tinyint] NOT NULL,
	[estatus_viernes] [tinyint] NOT NULL,
	[estatus_sabado] [tinyint] NOT NULL,
	[estatus_domingo] [tinyint] NOT NULL,
	[fecha_alta] [date] NOT NULL,
	[fecha_baja] [date] NOT NULL,
	[fecha_ult_venta] [date] NOT NULL,
	[fecha_ult_pago] [date] NOT NULL,
	[anticipos] [decimal](14, 2) NOT NULL,
	[debitos] [decimal](14, 2) NOT NULL,
	[creditos] [decimal](14, 2) NOT NULL,
	[saldo] [decimal](14, 2) NOT NULL,
	[disponible] [decimal](14, 2) NOT NULL,
	[memo] [nvarchar](max) NOT NULL,
	[aviso] [nvarchar](60) NOT NULL,
	[estatus] [nvarchar](10) NOT NULL,
	[cuenta] [nvarchar](30) NOT NULL,
	[iban] [nvarchar](15) NOT NULL,
	[swit] [nvarchar](15) NOT NULL,
	[dir_banco] [nvarchar](60) NOT NULL,
	[codigo_cobrar] [nvarchar](15) NOT NULL,
	[codigo_ingresos] [nvarchar](15) NOT NULL,
	[codigo_anticipos] [nvarchar](15) NOT NULL,
	[categoria] [nvarchar](15) NOT NULL,
	[descuento_pronto_pago] [decimal](6, 2) NOT NULL,
	[importe_ult_pago] [decimal](14, 2) NOT NULL,
	[importe_ult_venta] [decimal](14, 2) NOT NULL,
	[telefono2] [nvarchar](20) NOT NULL,
	[fax] [nvarchar](20) NOT NULL,
	[imagen] [nvarchar](150) NOT NULL,
	[registro] [nvarchar](150) NULL,
	[tomo] [nvarchar](20) NULL,
	[hoja] [nvarchar](20) NULL,
	[folio] [nvarchar](20) NULL,
 CONSTRAINT [PK_clientes_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientes_afiliados]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes_afiliados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente_id] [int] NOT NULL,
	[ci_titular] [nvarchar](15) NOT NULL,
	[ci_beneficiario] [nvarchar](15) NOT NULL,
	[nombre_titular] [nvarchar](80) NOT NULL,
	[nombre_beneficiario] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_clientes_afiliados_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientes_grupo]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes_grupo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_clientes_grupo_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientes_zonas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes_zonas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](40) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_clientes_zonas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cobradores]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cobradores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellido] [nvarchar](100) NOT NULL,
	[ci_rif] [nvarchar](15) NOT NULL,
	[direccion] [nvarchar](max) NOT NULL,
	[comision] [decimal](6, 2) NOT NULL CONSTRAINT [DF__empresa_c__comis__19AACF41]  DEFAULT ((0.00)),
	[contrato] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_empresa_cobradores_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[colores]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[colores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_colores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[compras]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tasa1] [decimal](14, 2) NOT NULL,
	[tasa2] [decimal](14, 2) NOT NULL,
	[tasa3] [decimal](14, 2) NOT NULL,
	[tasa_retencion_iva] [decimal](14, 2) NOT NULL,
	[tasa_retencion_islr] [decimal](14, 2) NOT NULL,
	[usuario_id] [int] NOT NULL,
	[sucursal_id] [int] NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[remision_id] [int] NOT NULL,
	[cxp_id] [int] NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[fecha] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base1] [decimal](14, 2) NOT NULL,
	[base2] [decimal](14, 2) NOT NULL,
	[base3] [decimal](14, 2) NOT NULL,
	[impuesto1] [decimal](14, 2) NOT NULL,
	[impuesto2] [decimal](14, 2) NOT NULL,
	[impuesto3] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[nota] [nvarchar](200) NOT NULL,
	[retencion_iva] [decimal](14, 2) NOT NULL,
	[retencion_islr] [decimal](14, 2) NOT NULL,
	[mes_relacion] [nvarchar](2) NOT NULL,
	[control] [nvarchar](10) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[orden_compra] [nvarchar](10) NOT NULL,
	[dias] [int] NOT NULL,
	[descuento1] [decimal](14, 2) NOT NULL,
	[descuento2] [decimal](14, 2) NOT NULL,
	[cargos] [decimal](14, 2) NOT NULL,
	[descuento1p] [decimal](6, 2) NOT NULL,
	[descuento2p] [decimal](6, 2) NOT NULL,
	[cargosp] [decimal](6, 2) NOT NULL,
	[columna] [nvarchar](1) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[aplica] [nvarchar](10) NOT NULL,
	[comprobante_retencion] [nvarchar](14) NOT NULL,
	[subtotal_neto] [decimal](14, 2) NOT NULL,
	[telefono] [nvarchar](60) NOT NULL,
	[factor_cambio] [decimal](14, 4) NOT NULL,
	[condicion_pago] [nvarchar](7) NOT NULL,
	[hora] [time](7) NOT NULL,
	[monto_divisa] [decimal](14, 2) NOT NULL,
	[estacion] [nvarchar](20) NOT NULL,
	[renglones] [int] NOT NULL,
	[saldo_pendiente] [decimal](14, 2) NOT NULL,
	[ano_relacion] [nvarchar](4) NOT NULL,
	[comprobante_retencion_islr] [nvarchar](10) NOT NULL,
	[dias_validez] [int] NOT NULL,
	[situacion] [nvarchar](10) NOT NULL,
	[signo] [int] NOT NULL,
	[serie] [nvarchar](3) NOT NULL,
	[tarifa] [nvarchar](1) NOT NULL,
	[documento_nombre] [nvarchar](16) NOT NULL,
	[subtotal_impuesto] [decimal](14, 2) NOT NULL,
	[subtotal] [decimal](14, 2) NOT NULL,
	[tipo_proveedor] [nvarchar](2) NOT NULL,
	[planilla] [nvarchar](15) NOT NULL,
	[expediente] [nvarchar](15) NOT NULL,
	[anticipo_iva] [decimal](14, 2) NOT NULL,
	[terceros_iva] [decimal](14, 2) NOT NULL,
	[neto] [decimal](14, 2) NOT NULL,
	[costo] [decimal](14, 2) NOT NULL,
	[utilidad] [decimal](14, 2) NOT NULL,
	[utilidadp] [decimal](6, 2) NOT NULL,
	[documento_tipo] [nvarchar](10) NOT NULL,
	[denominacion_fiscal] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_compras_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[compras_detalle]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras_detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[compra_id] [int] NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[descuento1p] [decimal](6, 2) NOT NULL,
	[descuento2p] [decimal](6, 2) NOT NULL,
	[descuento3p] [decimal](6, 2) NOT NULL,
	[descuento1] [decimal](14, 2) NOT NULL,
	[descuento2] [decimal](14, 2) NOT NULL,
	[descuento3] [decimal](14, 2) NOT NULL,
	[total_neto] [decimal](14, 2) NOT NULL,
	[tasa] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[signo] [int] NOT NULL,
	[decimales] [nvarchar](1) NOT NULL,
	[contenido_empaque] [int] NOT NULL,
	[cantidad_und] [decimal](14, 3) NOT NULL,
	[costo_und] [decimal](14, 2) NOT NULL,
	[costo_promedio_und] [decimal](14, 2) NOT NULL,
	[costo_compra] [decimal](14, 2) NOT NULL,
	[cantidad_bono] [decimal](14, 3) NOT NULL,
	[costo_bruto] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_compras_detalle_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[compras_retenciones]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras_retenciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[documento] [nvarchar](14) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[tasa_retencion] [decimal](6, 2) NOT NULL,
	[retencion] [decimal](14, 2) NOT NULL,
	[fecha_relacion] [date] NOT NULL,
	[ano_relacion] [nvarchar](4) NOT NULL,
	[mes_relacion] [nvarchar](2) NOT NULL,
	[renglones] [int] NOT NULL,
	[documento_nombre] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_compras_retenciones_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[compras_retenciones_detalle]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras_retenciones_detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[compras_retenciones_id] [int] NOT NULL,
	[documento] [nvarchar](14) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[tasa_retencion] [decimal](6, 2) NOT NULL,
	[retencion] [decimal](14, 2) NOT NULL,
	[fecha_retencion] [date] NOT NULL,
	[comprobante] [nvarchar](14) NOT NULL,
	[tipo_retencion] [nvarchar](2) NOT NULL,
	[aplica] [nvarchar](10) NOT NULL,
	[control] [nvarchar](10) NOT NULL,
	[tasa_id] [int] NOT NULL,
	[signo] [int] NOT NULL,
 CONSTRAINT [PK_compras_retenciones_detalle_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[configuracion]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[configuracion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[modulo_id] [int] NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[opcion] [nvarchar](50) NOT NULL,
	[operacion] [nvarchar](60) NOT NULL,
	[valor] [nvarchar](100) NOT NULL,
	[defecto] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_configuracion_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cuentas_bancarias]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas_bancarias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[banco_id] [int] NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombres] [nvarchar](60) NOT NULL,
	[apellidos] [nvarchar](100) NOT NULL,
	[tipo_cuenta] [nvarchar](25) NOT NULL,
	[numero_cuenta] [nvarchar](25) NOT NULL,
	[codigo_contable] [nvarchar](20) NOT NULL,
	[direccion] [nvarchar](100) NOT NULL,
	[contacto] [nvarchar](100) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[fax] [nvarchar](20) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[website] [nvarchar](100) NOT NULL,
	[estatus] [nvarchar](10) NOT NULL,
	[naturaleza_cuenta] [nvarchar](25) NOT NULL,
	[fecha_apertura] [date] NOT NULL CONSTRAINT [DF__cuentas_bancarias__fecha_ap__00200768]  DEFAULT ('2000-01-01'),
	[fecha_conciliacion] [date] NOT NULL CONSTRAINT [DF__cuentas_bancarias__fecha_co__01142BA1]  DEFAULT ('2000-01-01'),
	[fecha_alta] [date] NOT NULL CONSTRAINT [DF__cuentas_bancarias__fecha_al__02084FDA]  DEFAULT (getdate()),
	[saldo] [decimal](14, 2) NOT NULL CONSTRAINT [DF__cuentas_bancarias__saldo__7E37BEF6]  DEFAULT ((0.00)),
	[saldo_conciliado] [decimal](14, 2) NOT NULL CONSTRAINT [DF__cuentas_bancarias__saldo_co__7F2BE32F]  DEFAULT ((0.00)),
	[total_debitos] [decimal](14, 2) NOT NULL CONSTRAINT [DF__cuentas_bancarias__total_de__02FC7413]  DEFAULT ((0.00)),
	[total_creditos] [decimal](14, 2) NOT NULL CONSTRAINT [DF__cuentas_bancarias__total_cr__03F0984C]  DEFAULT ((0.00)),
	[idb] [decimal](6, 2) NOT NULL CONSTRAINT [DF__cuentas_bancarias__idb__04E4BC85]  DEFAULT ((0.00)),
	[ultimo_numero_chq] [int] NOT NULL,
	[numero_nota_debito] [int] NOT NULL CONSTRAINT [DF__cuentas_bancarias__numero_n__05D8E0BE]  DEFAULT ((0)),
	[numero_nota_credito] [int] NOT NULL CONSTRAINT [DF__cuentas_bancarias__numero_n__06CD04F7]  DEFAULT ((0)),
	[rif] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_cuentas_bancarias_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cuentasbancarias_proveedores]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentasbancarias_proveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[cuentabancaria_id] [int] NOT NULL,
	[creado] [datetime] NOT NULL,
 CONSTRAINT [PK_cuentasbancarias_proveedores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxc]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[documento_id] [int] NOT NULL,
	[agencia_id] [int] NOT NULL,
	[vendedor_id] [int] NOT NULL,
	[cliente_id] [int] NOT NULL,
	[c_cobranza] [decimal](14, 2) NOT NULL,
	[c_cobranzap] [decimal](6, 2) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_documento] [nvarchar](3) NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[nota] [nvarchar](200) NOT NULL,
	[importe] [decimal](14, 2) NOT NULL,
	[acumulado] [decimal](14, 2) NOT NULL,
	[estatus_cancelado] [tinyint] NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[resta] [decimal](14, 2) NOT NULL,
	[numero] [nvarchar](10) NOT NULL,
	[signo] [int] NOT NULL,
	[c_departamento] [decimal](14, 2) NOT NULL,
	[c_ventas] [decimal](14, 2) NOT NULL,
	[c_ventasp] [decimal](6, 2) NOT NULL,
	[serie] [nvarchar](3) NOT NULL,
	[importe_neto] [decimal](14, 2) NOT NULL,
	[dias] [int] NOT NULL,
 CONSTRAINT [PK_cxc_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxc_documentos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxc_documentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cxc_id] [int] NOT NULL,
	[cxc_pago_id] [int] NOT NULL,
	[cxc_recibo_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_documento] [nvarchar](3) NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[importe] [decimal](14, 2) NOT NULL,
	[operacion] [nvarchar](5) NOT NULL,
	[numero_recibo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_cxc_documentos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxc_medio_pago]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxc_medio_pago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[recibo_id] [int] NOT NULL,
	[agencia_id] [int] NOT NULL,
	[medio] [nvarchar](20) NOT NULL,
	[codigo] [nvarchar](2) NOT NULL,
	[monto_recibido] [decimal](14, 2) NOT NULL,
	[fecha] [date] NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[numero] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_cxc_medio_pago_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxc_recibos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxc_recibos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente_id] [nvarchar](10) NOT NULL,
	[usuario_id] [int] NOT NULL,
	[cobrador_id] [int] NOT NULL,
	[cxc_id] [int] NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[fecha] [date] NOT NULL,
	[importe] [decimal](14, 2) NOT NULL,
	[monto_recibido] [decimal](14, 2) NOT NULL,
	[codigo] [nvarchar](15) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[anticipos] [decimal](14, 2) NOT NULL,
	[cambio] [decimal](14, 2) NOT NULL,
	[nota] [nvarchar](200) NOT NULL,
	[retenciones] [decimal](14, 2) NOT NULL,
	[descuentos] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_cxc_recibos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxp]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[agencia_id] [int] NOT NULL,
	[documento_id] [int] NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_documento] [nvarchar](3) NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[nota] [nvarchar](200) NOT NULL,
	[estatus_cancelado] [tinyint] NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[numero] [nvarchar](10) NOT NULL,
	[dias] [int] NOT NULL,
	[signo] [int] NOT NULL,
	[monto_recibido] [decimal](14, 2) NOT NULL,
	[comisionp] [decimal](6, 2) NOT NULL,
	[base_comision] [decimal](14, 2) NOT NULL,
	[importe] [decimal](14, 2) NOT NULL,
	[acumulado] [decimal](14, 2) NOT NULL,
	[castigop] [decimal](6, 2) NOT NULL,
	[resta] [decimal](14, 2) NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
 CONSTRAINT [PK_cxp_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxp_documentos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxp_documentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cxp_id] [int] NOT NULL,
	[cxp_pago_id] [int] NOT NULL,
	[cxp_recibo_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_documento] [nvarchar](3) NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[importe] [decimal](14, 2) NOT NULL,
	[operacion] [nvarchar](5) NOT NULL,
	[numero_recibo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_cxp_documentos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxp_medio_pago]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxp_medio_pago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[medio_pago_id] [int] NOT NULL,
	[agencia_id] [int] NOT NULL,
	[medio] [nvarchar](20) NOT NULL,
	[codigo] [nvarchar](2) NOT NULL,
	[monto_recibido] [decimal](14, 2) NOT NULL,
	[fecha] [date] NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[numero] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_cxp_medio_pago_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cxp_recibos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cxp_recibos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cxp_id] [int] NOT NULL,
	[usuario_id] [int] NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[fecha] [date] NOT NULL,
	[importe] [decimal](14, 2) NOT NULL,
	[monto_recibido] [decimal](14, 2) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[anticipos] [decimal](14, 2) NOT NULL,
	[cambio] [decimal](14, 2) NOT NULL,
	[nota] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_cxp_recibos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departamentos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[preciomaximo] [float] NOT NULL CONSTRAINT [DF_departamentos_preciomaximo]  DEFAULT ((0)),
	[preciooferta] [float] NOT NULL CONSTRAINT [DF_departamentos_preciooferta]  DEFAULT ((0)),
	[preciomayor] [float] NOT NULL CONSTRAINT [DF_departamentos_preciomayor]  DEFAULT ((0)),
	[preciominimo] [float] NOT NULL CONSTRAINT [DF_departamentos_preciominimo]  DEFAULT ((0)),
	[cvpreciomaximo] [float] NOT NULL CONSTRAINT [DF_departamentos_cvpreciomaximo]  DEFAULT ((0)),
	[cvpreciooferta] [float] NOT NULL CONSTRAINT [DF_departamentos_cvpreciooferta]  DEFAULT ((0)),
	[cvpreciomayor] [float] NOT NULL CONSTRAINT [DF_departamentos_cvpreciomayor]  DEFAULT ((0)),
	[cvpreciominimo] [float] NOT NULL CONSTRAINT [DF_departamentos_cvpreciominimo]  DEFAULT ((0)),
	[ccpreciomaximo] [float] NOT NULL CONSTRAINT [DF_departamentos_ccpreciomaximo]  DEFAULT ((0)),
	[ccpreciooferta] [float] NOT NULL CONSTRAINT [DF_departamentos_ccpreciooferta]  DEFAULT ((0)),
	[ccpreciomayor] [float] NOT NULL CONSTRAINT [DF_departamentos_ccpreciomayor]  DEFAULT ((0)),
	[ccpreciominimo] [float] NOT NULL CONSTRAINT [DF_departamentos_ccpreciominimo]  DEFAULT ((0)),
	[imagen] [nvarchar](150) NOT NULL CONSTRAINT [DF_departamentos_imagen]  DEFAULT ((0)),
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_empresa_departamentos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[depositos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depositos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](250) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_empresa_depositos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[documentos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[documentos](
	[id] [int] IDENTITY(30,1) NOT NULL,
	[tipo] [nvarchar](20) NOT NULL,
	[nombre] [nvarchar](40) NOT NULL,
	[codigo] [nvarchar](2) NOT NULL,
	[signo] [int] NOT NULL,
	[siglas] [nvarchar](3) NOT NULL,
	[comando] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_documentos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empresas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresas](
	[id] [int] IDENTITY(2,1) NOT NULL,
	[pais] [nvarchar](50) NOT NULL CONSTRAINT [DF_empresas_pais]  DEFAULT (N'Venezuela'),
	[estado] [nvarchar](50) NOT NULL CONSTRAINT [DF_empresas_estado]  DEFAULT (N'Aragua'),
	[municipio] [nvarchar](150) NOT NULL CONSTRAINT [DF_empresas_municipio]  DEFAULT (N'Jose Felix Ribas'),
	[parroquia] [nvarchar](150) NOT NULL CONSTRAINT [DF_empresas_parroquia]  DEFAULT (N'Centro'),
	[nombre] [nvarchar](120) NOT NULL,
	[direccion] [nvarchar](120) NOT NULL,
	[denominacion_social] [nvarchar](150) NOT NULL,
	[rif] [nvarchar](15) NOT NULL,
	[telefono] [nvarchar](60) NOT NULL,
	[telefonocel] [nvarchar](45) NOT NULL,
	[sucursal] [nvarchar](60) NOT NULL,
	[codigo_sucursal] [nvarchar](60) NOT NULL,
	[contacto] [nvarchar](60) NOT NULL,
	[telefonocontacto] [nvarchar](45) NOT NULL,
	[fax] [nvarchar](60) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[website] [nvarchar](100) NOT NULL,
	[registro] [nvarchar](100) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[ciudad] [nvarchar](100) NOT NULL,
	[codigo_postal] [nvarchar](10) NOT NULL,
	[retencion_iva] [decimal](6, 2) NOT NULL CONSTRAINT [DF__empresas__retenc__1F63A897]  DEFAULT ((0.00)),
	[retencion_islr] [decimal](6, 2) NOT NULL CONSTRAINT [DF__empresas__retenc__2057CCD0]  DEFAULT ((0.00)),
	[factor_cambio] [decimal](6, 2) NOT NULL CONSTRAINT [DF__empresas__factor__214BF109]  DEFAULT ((0.00)),
	[debito_bancario] [decimal](6, 2) NOT NULL CONSTRAINT [DF__empresas__debito__22401542]  DEFAULT ((0.00)),
	[imagen] [nvarchar](max) NOT NULL,
	[tomo] [nvarchar](45) NOT NULL,
	[hoja] [nvarchar](50) NOT NULL,
	[folio] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_empresas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[marcas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marcas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[codigo] [nvarchar](20) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_marcas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[medios_pago_cobro]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medios_pago_cobro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[estatus_cobro] [bit] NOT NULL,
	[estatus_pago] [bit] NOT NULL,
 CONSTRAINT [PK_medios_pago_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[monedas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[monedas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[codigo] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[simbolo] [nvarchar](50) NOT NULL,
	[cambioventa] [float] NOT NULL,
	[cambiocompra] [float] NOT NULL,
	[predeterminado] [bit] NOT NULL,
	[notas] [ntext] NOT NULL,
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_monedas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[periodo_mensual]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periodo_mensual](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [nvarchar](2) NOT NULL,
	[mes] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_periodo_mensual_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[pos_comandas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pos_comandas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[vendedor_id] [int] NOT NULL,
	[cuenta_id] [int] NOT NULL,
	[cantidad] [decimal](14, 3) NOT NULL,
	[empaque] [nvarchar](15) NOT NULL,
	[precio_neto] [decimal](14, 2) NOT NULL,
	[descuento1p] [decimal](6, 2) NOT NULL,
	[descuento1] [decimal](14, 2) NOT NULL,
	[costo_venta] [decimal](14, 2) NOT NULL,
	[total_neto] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[fecha] [date] NOT NULL,
	[hora] [time](7) NOT NULL,
	[precio_final] [decimal](14, 2) NOT NULL,
	[decimales] [nvarchar](1) NOT NULL,
	[contenido_empaque] [int] NOT NULL,
	[cantidad_und] [decimal](14, 3) NOT NULL,
	[precio_und] [decimal](14, 2) NOT NULL,
	[costo_und] [decimal](14, 2) NOT NULL,
	[precio_item] [decimal](14, 2) NOT NULL,
	[detalle] [nvarchar](160) NOT NULL,
	[tasa] [decimal](6, 2) NOT NULL,
	[categoria] [nvarchar](20) NOT NULL,
	[costo_promedio_und] [decimal](14, 2) NOT NULL,
	[costo_compra] [decimal](14, 2) NOT NULL,
	[estatus_comanda] [tinyint] NOT NULL,
	[total_descuento] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_pos_comandas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[pos_cuentas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pos_cuentas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cuenta] [nvarchar](5) NOT NULL,
	[estatus_cuenta] [tinyint] NOT NULL,
	[estatus_servicio] [tinyint] NOT NULL,
	[estatus_abierta] [tinyint] NOT NULL,
	[estatus] [nvarchar](10) NOT NULL,
	[acumulado] [decimal](14, 2) NOT NULL,
	[ci_rif] [nvarchar](12) NOT NULL,
	[nombre] [nvarchar](80) NOT NULL,
	[dir_fiscal] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_pos_cuentas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[producto_colores]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto_colores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[color_id] [int] NOT NULL,
 CONSTRAINT [PK_producto_colores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[producto_modelos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto_modelos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[codigo] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_producto_modelos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[producto_tallas]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto_tallas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[talla_id] [int] NOT NULL,
 CONSTRAINT [PK_producto_tallas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[tasacompra_id] [int] NOT NULL,
	[tasaventa_id] [int] NOT NULL,
	[marca_id] [int] NOT NULL,
	[departamento_id] [int] NOT NULL,
	[dias_garantia] [int] NOT NULL,
	[codigo] [nvarchar](150) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
	[nombre_corto] [nvarchar](40) NOT NULL,
	[referencia] [nvarchar](50) NOT NULL,
	[imagen] [nvarchar](250) NOT NULL,
	[comentarios] [nvarchar](150) NOT NULL,
	[modelo] [nvarchar](50) NOT NULL,
	[estatus] [nvarchar](10) NOT NULL,
	[serial] [nvarchar](50) NOT NULL,
	[costo_proveedor] [float] NOT NULL,
	[costo_varios] [float] NOT NULL,
	[costo] [float] NOT NULL,
	[costo_promedio] [float] NOT NULL,
	[utilidad_1] [float] NOT NULL,
	[utilidad_2] [float] NOT NULL,
	[utilidad_3] [float] NOT NULL,
	[utilidad_4] [float] NOT NULL,
	[preciomaximo] [float] NOT NULL,
	[preciooferta] [float] NOT NULL,
	[preciomayor] [float] NOT NULL,
	[preciominimo] [float] NOT NULL,
	[cvpreciomaximo] [float] NOT NULL,
	[cvpreciooferta] [float] NOT NULL,
	[cvpreciomayor] [float] NOT NULL,
	[cvpreciominimo] [float] NOT NULL,
	[ccpreciomaximo] [float] NOT NULL,
	[ccpreciooferta] [float] NOT NULL,
	[ccpreciomayor] [float] NOT NULL,
	[ccpreciominimo] [float] NOT NULL,
	[estatus_serial] [bit] NOT NULL,
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
	[moneda_id] [int] NOT NULL,
	[largo] [int] NOT NULL,
	[ancho] [int] NOT NULL,
	[alto] [int] NOT NULL,
	[peso] [int] NOT NULL,
	[tipoproducto] [nvarchar](50) NOT NULL,
	[unidad_id] [int] NOT NULL,
 CONSTRAINT [PK_productos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_conceptos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_conceptos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](15) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_productos_conceptos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_costos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_costos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [nvarchar](10) NOT NULL,
	[nota] [nvarchar](40) NOT NULL,
	[fecha] [date] NOT NULL,
	[estacion] [nvarchar](20) NOT NULL,
	[hora] [time](7) NOT NULL,
	[usuario_id] [int] NOT NULL,
	[costo] [float] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_productos_costos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_deposito]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_deposito](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[deposito_id] [int] NOT NULL,
	[fisica] [decimal](14, 3) NOT NULL,
	[reservada] [decimal](14, 3) NOT NULL,
	[disponible] [decimal](14, 3) NOT NULL,
	[ubicacion_1] [nvarchar](20) NOT NULL,
	[ubicacion_2] [nvarchar](20) NOT NULL,
	[ubicacion_3] [nvarchar](20) NOT NULL,
	[ubicacion_4] [nvarchar](20) NOT NULL,
	[nivel_minimo] [decimal](14, 3) NOT NULL,
	[pto_pedido] [decimal](14, 3) NOT NULL,
	[nivel_optimo] [decimal](14, 3) NOT NULL,
 CONSTRAINT [PK_productos_deposito_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_grupo]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_grupo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[estatus_catalogo] [tinyint] NOT NULL,
 CONSTRAINT [PK_productos_grupo_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_kardex]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_kardex](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[deposito_id] [int] NOT NULL,
	[concepto_id] [int] NOT NULL,
	[documento_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[hora] [time](7) NOT NULL,
	[documento] [nvarchar](15) NOT NULL,
	[modulo] [nvarchar](10) NOT NULL,
	[entidad] [nvarchar](80) NOT NULL,
	[signo] [int] NOT NULL,
	[cantidad] [decimal](14, 3) NOT NULL,
	[cantidad_bono] [decimal](14, 3) NOT NULL,
	[cantidad_und] [decimal](14, 3) NOT NULL,
	[costo_und] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[nota] [nvarchar](50) NOT NULL,
	[precio_und] [decimal](14, 2) NOT NULL,
	[codigo] [nvarchar](2) NOT NULL,
	[siglas] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_productos_kardex_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_movimientos]    Script Date: 12/09/2017 15:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_movimientos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [int] NOT NULL,
	[deposito_salida_id] [int] NOT NULL,
	[deposito_destino_id] [int] NOT NULL,
	[concepto_id] [int] NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[fecha] [date] NOT NULL,
	[nota] [nvarchar](60) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[hora] [time](7) NOT NULL,
	[estacion] [nvarchar](20) NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[renglones] [int] NOT NULL,
	[documento_nombre] [nvarchar](16) NOT NULL,
	[autorizado] [nvarchar](40) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_productos_movimientos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_movimientos_detalle]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_movimientos_detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productos_movimientos_id] [int] NOT NULL,
	[documento_id] [int] NOT NULL,
	[producto_id] [int] NOT NULL,
	[cantidad] [decimal](14, 3) NOT NULL,
	[cantidad_bono] [decimal](14, 3) NOT NULL,
	[cantidad_und] [decimal](14, 3) NOT NULL,
	[categoria] [nvarchar](20) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[contenido_empaque] [int] NOT NULL,
	[empaque] [nvarchar](15) NOT NULL,
	[decimales] [nvarchar](1) NOT NULL,
	[costo_und] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[costo_compra] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_productos_movimientos_detalle_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_precios]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_precios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[nota] [nvarchar](40) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[estacion] [nvarchar](20) NOT NULL,
	[hora] [time](7) NOT NULL,
	[usuario_id] [int] NOT NULL,
	[precio] [decimal](14, 2) NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_productos_precios_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_proveedor]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_proveedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[proveedor_id] [int] NOT NULL,
 CONSTRAINT [PK_productos_proveedor_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos_vencimiento_depositos]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos_vencimiento_depositos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NOT NULL,
	[deposito_id] [int] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[serial_producto] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_productos_vencimiento_depositos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[grupo_id] [int] NOT NULL,
	[userlog_id] [int] NOT NULL CONSTRAINT [DF_proveedores_userlog_id]  DEFAULT ((0)),
	[pais] [nvarchar](50) NOT NULL,
	[estado] [nvarchar](50) NOT NULL,
	[municipio] [nvarchar](50) NOT NULL,
	[parroquia] [nvarchar](50) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](80) NOT NULL,
	[contacto] [nvarchar](150) NOT NULL,
	[rif] [nvarchar](15) NOT NULL,
	[razon_social] [nvarchar](80) NOT NULL,
	[dir_fiscal] [nvarchar](120) NOT NULL,
	[telefono_ofi] [nvarchar](25) NOT NULL,
	[telefono_cel] [nvarchar](25) NOT NULL,
	[fax] [nvarchar](25) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[website] [nvarchar](100) NOT NULL,
	[ciudad] [nvarchar](50) NOT NULL,
	[denominacion_fiscal] [nvarchar](150) NOT NULL,
	[codigo_postal] [nvarchar](10) NOT NULL,
	[notas] [nvarchar](max) NOT NULL,
	[advertencia] [nvarchar](60) NOT NULL,
	[estatus] [nvarchar](50) NOT NULL,
	[codigo_cobrar] [nvarchar](15) NOT NULL,
	[codigo_ingresos] [nvarchar](15) NOT NULL,
	[codigo_anticipos] [nvarchar](15) NOT NULL,
	[retencion_iva] [float] NOT NULL CONSTRAINT [DF__proveedor__reten__019E3B86]  DEFAULT ((0.00)),
	[retencion_islr] [float] NOT NULL CONSTRAINT [DF__proveedor__reten__02925FBF]  DEFAULT ((0.00)),
	[anticipos] [float] NOT NULL CONSTRAINT [DF__proveedor__antic__075714DC]  DEFAULT ((0.00)),
	[debitos] [float] NOT NULL CONSTRAINT [DF__proveedor__debit__084B3915]  DEFAULT ((0.00)),
	[creditos] [float] NOT NULL CONSTRAINT [DF__proveedor__credi__093F5D4E]  DEFAULT ((0.00)),
	[saldo] [float] NOT NULL CONSTRAINT [DF__proveedor__saldo__0A338187]  DEFAULT ((0.00)),
	[disponible] [float] NOT NULL CONSTRAINT [DF__proveedor__dispo__0B27A5C0]  DEFAULT ((0.00)),
	[ventas_g] [float] NOT NULL CONSTRAINT [DF__proveedor__venta__0C1BC9F9]  DEFAULT ((0.00)),
	[ventas_1] [float] NOT NULL CONSTRAINT [DF__proveedor__venta__0D0FEE32]  DEFAULT ((0.00)),
	[ventas_2] [float] NOT NULL CONSTRAINT [DF__proveedor__venta__0E04126B]  DEFAULT ((0.00)),
	[ventas_3] [float] NOT NULL CONSTRAINT [DF__proveedor__venta__0EF836A4]  DEFAULT ((0.00)),
	[ventas_4] [float] NOT NULL CONSTRAINT [DF__proveedor__venta__0FEC5ADD]  DEFAULT ((0.00)),
	[cobranza_g] [float] NOT NULL CONSTRAINT [DF__proveedor__cobra__10E07F16]  DEFAULT ((0.00)),
	[cobranza_1] [float] NOT NULL CONSTRAINT [DF__proveedor__cobra__11D4A34F]  DEFAULT ((0.00)),
	[cobranza_2] [float] NOT NULL CONSTRAINT [DF__proveedor__cobra__12C8C788]  DEFAULT ((0.00)),
	[cobranza_3] [float] NOT NULL CONSTRAINT [DF__proveedor__cobra__13BCEBC1]  DEFAULT ((0.00)),
	[cobranza_4] [float] NOT NULL CONSTRAINT [DF__proveedor__cobra__14B10FFA]  DEFAULT ((0.00)),
	[estatus_vendedor] [bit] NOT NULL,
	[estatus_ventas] [bit] NOT NULL,
	[estatus_cobranza] [bit] NOT NULL,
	[estatus_departamento] [bit] NOT NULL,
	[borrado] [bit] NOT NULL CONSTRAINT [DF_proveedores_borrado]  DEFAULT ((0)),
	[fecha_ult_compra] [datetime] NOT NULL CONSTRAINT [DF__proveedor__fecha__0662F0A3]  DEFAULT ('2000-01-01'),
	[fecha_ult_pago] [datetime] NOT NULL CONSTRAINT [DF__proveedor__fecha__056ECC6A]  DEFAULT ('2000-01-01'),
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_proveedores_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[proveedores_grupo]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores_grupo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [ntext] NOT NULL,
 CONSTRAINT [PK_proveedores_grupo_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[remisiones]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[remisiones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](40) NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_remisiones_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[series_fiscales]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[series_fiscales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serie] [nvarchar](10) NOT NULL,
	[correlativo] [int] NOT NULL,
	[estatus_factura] [tinyint] NOT NULL,
	[estatus_nd] [tinyint] NOT NULL,
	[estatus_nc] [tinyint] NOT NULL,
	[estatus_ne] [tinyint] NOT NULL,
	[estatus] [nvarchar](10) NOT NULL,
	[control] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_series_fiscales_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[subcategoria]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subcategoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoria_id] [int] NULL,
	[codigo] [nvarchar](45) NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_subcategoria_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tallas]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tallas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_tallas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tasas]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tasas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](20) NOT NULL,
	[tasa] [decimal](6, 2) NOT NULL CONSTRAINT [DF__tasas__tasa__1975C517]  DEFAULT ((0.00)),
 CONSTRAINT [PK_tasas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[transportes]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transportes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[codigo] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[contrato] [nvarchar](20) NOT NULL,
	[placa] [nvarchar](20) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[direccion] [ntext] NOT NULL,
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_empresa_transporte_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[unidadesmedidas]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unidadesmedidas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userlog_id] [int] NOT NULL,
	[codigo] [nvarchar](20) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
	[creado] [datetime] NOT NULL,
	[modificado] [datetime] NOT NULL,
 CONSTRAINT [PK_unidadesmedidas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[variantes_productos]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[variantes_productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[referencia] [nvarchar](150) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
	[atributo] [nvarchar](250) NOT NULL,
	[precio] [decimal](14, 2) NOT NULL,
	[medida_id] [int] NOT NULL,
	[producto_id] [int] NOT NULL,
 CONSTRAINT [PK_variantes_productos_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ventas]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente_id] [int] NOT NULL,
	[usuario_id] [int] NOT NULL,
	[vendedor_id] [int] NOT NULL,
	[transporte_id] [int] NOT NULL,
	[recibo_id] [int] NOT NULL,
	[remision_id] [int] NOT NULL,
	[cxc_id] [int] NOT NULL,
	[documento] [nvarchar](10) NOT NULL,
	[fecha] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base1] [decimal](14, 2) NOT NULL,
	[base2] [decimal](14, 2) NOT NULL,
	[base3] [decimal](14, 2) NOT NULL,
	[impuesto1] [decimal](14, 2) NOT NULL,
	[impuesto2] [decimal](14, 2) NOT NULL,
	[impuesto3] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[tasa1] [decimal](6, 2) NOT NULL,
	[tasa2] [decimal](6, 2) NOT NULL,
	[tasa3] [decimal](6, 2) NOT NULL,
	[nota] [nvarchar](200) NOT NULL,
	[tasa_retencion_iva] [decimal](6, 2) NOT NULL,
	[tasa_retencion_islr] [decimal](6, 2) NOT NULL,
	[retencion_iva] [decimal](14, 2) NOT NULL,
	[retencion_islr] [decimal](14, 2) NOT NULL,
	[mes_relacion] [nvarchar](2) NOT NULL,
	[control] [nvarchar](10) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[orden_compra] [nvarchar](10) NOT NULL,
	[dias] [int] NOT NULL,
	[descuento1] [decimal](14, 2) NOT NULL,
	[descuento2] [decimal](14, 2) NOT NULL,
	[cargos] [decimal](14, 2) NOT NULL,
	[descuento1p] [decimal](6, 2) NOT NULL,
	[descuento2p] [decimal](6, 2) NOT NULL,
	[cargosp] [decimal](6, 2) NOT NULL,
	[columna] [nvarchar](1) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[aplica] [nvarchar](10) NOT NULL,
	[comprobante_retencion] [nvarchar](14) NOT NULL,
	[subtotal_neto] [decimal](14, 2) NOT NULL,
	[telefono] [nvarchar](60) NOT NULL,
	[factor_cambio] [decimal](14, 4) NOT NULL,
	[fecha_pedido] [date] NOT NULL,
	[pedido] [nvarchar](10) NOT NULL,
	[condicion_pago] [nvarchar](7) NOT NULL,
	[hora] [time](7) NOT NULL,
	[monto_divisa] [decimal](14, 2) NOT NULL,
	[despachado] [nvarchar](20) NOT NULL,
	[dir_despacho] [nvarchar](120) NOT NULL,
	[estacion] [nvarchar](20) NOT NULL,
	[renglones] [int] NOT NULL,
	[saldo_pendiente] [decimal](14, 2) NOT NULL,
	[ano_relacion] [nvarchar](4) NOT NULL,
	[comprobante_retencion_islr] [nvarchar](10) NOT NULL,
	[dias_validez] [int] NOT NULL,
	[situacion] [nvarchar](10) NOT NULL,
	[signo] [int] NOT NULL,
	[serie] [nvarchar](3) NOT NULL,
	[tarifa] [nvarchar](1) NOT NULL,
	[documento_nombre] [nvarchar](16) NOT NULL,
	[subtotal_impuesto] [decimal](14, 2) NOT NULL,
	[subtotal] [decimal](14, 2) NOT NULL,
	[planilla] [nvarchar](15) NOT NULL,
	[expediente] [nvarchar](15) NOT NULL,
	[anticipo_iva] [decimal](14, 2) NOT NULL,
	[terceros_iva] [decimal](14, 2) NOT NULL,
	[neto] [decimal](14, 2) NOT NULL,
	[costo] [decimal](14, 2) NOT NULL,
	[utilidad] [decimal](14, 2) NOT NULL,
	[utilidadp] [decimal](6, 2) NOT NULL,
	[documento_tipo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_ventas_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ventas_detalle]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas_detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venta_id] [int] NOT NULL,
	[documento_id] [int] NOT NULL,
	[producto_id] [int] NOT NULL,
	[cantidad] [decimal](14, 3) NOT NULL,
	[empaque] [nvarchar](15) NOT NULL,
	[precio_neto] [decimal](14, 2) NOT NULL,
	[descuento1p] [decimal](6, 2) NOT NULL,
	[descuento2p] [decimal](6, 2) NOT NULL,
	[descuento3p] [decimal](6, 2) NOT NULL,
	[descuento1] [decimal](14, 2) NOT NULL,
	[descuento2] [decimal](14, 2) NOT NULL,
	[descuento3] [decimal](14, 2) NOT NULL,
	[costo_venta] [decimal](14, 2) NOT NULL,
	[total_neto] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[estatus_anulado] [tinyint] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[deposito] [nvarchar](20) NOT NULL,
	[signo] [int] NOT NULL,
	[precio_final] [decimal](14, 2) NOT NULL,
	[decimales] [nvarchar](1) NOT NULL,
	[contenido_empaque] [int] NOT NULL,
	[cantidad_und] [decimal](14, 3) NOT NULL,
	[precio_und] [decimal](14, 2) NOT NULL,
	[costo_und] [decimal](14, 2) NOT NULL,
	[utilidad] [decimal](14, 2) NOT NULL,
	[utilidadp] [decimal](6, 2) NOT NULL,
	[precio_item] [decimal](14, 2) NOT NULL,
	[estatus_garantia] [tinyint] NOT NULL,
	[dias_garantia] [int] NOT NULL,
	[detalle] [nvarchar](160) NOT NULL,
	[precio_sugerido] [decimal](14, 2) NOT NULL,
	[tasa] [decimal](6, 2) NOT NULL,
	[cobranzap] [decimal](6, 2) NOT NULL,
	[ventasp] [decimal](6, 2) NOT NULL,
	[cobranzap_vendedor] [decimal](6, 2) NOT NULL,
	[ventasp_vendedor] [decimal](6, 2) NOT NULL,
	[cobranza] [decimal](14, 2) NOT NULL,
	[ventas] [decimal](14, 2) NOT NULL,
	[cobranza_vendedor] [decimal](14, 2) NOT NULL,
	[ventas_vendedor] [decimal](14, 2) NOT NULL,
	[costo_promedio_und] [decimal](14, 2) NOT NULL,
	[costo_compra] [decimal](14, 2) NOT NULL,
	[estatus_checked] [tinyint] NOT NULL,
 CONSTRAINT [PK_ventas_detalle_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ventas_guias]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas_guias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente_id] [int] NOT NULL,
	[documento] [nvarchar](14) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[tasa_retencion] [decimal](6, 2) NOT NULL,
	[retencion] [decimal](14, 2) NOT NULL,
	[fecha_relacion] [date] NOT NULL,
	[ano_relacion] [nvarchar](4) NOT NULL,
	[mes_relacion] [nvarchar](2) NOT NULL,
	[renglones] [int] NOT NULL,
	[documento_nombre] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_ventas_guias_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ventas_guias_detalle]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas_guias_detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venta_guia] [int] NOT NULL,
	[documento_id] [int] NOT NULL,
	[documento] [nvarchar](14) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[tasa_retencion] [decimal](6, 2) NOT NULL,
	[retencion] [decimal](14, 2) NOT NULL,
	[fecha_retencion] [date] NOT NULL,
	[comprobante] [nvarchar](14) NOT NULL,
	[tipo_retencion] [nvarchar](2) NOT NULL,
	[aplica] [nvarchar](10) NOT NULL,
	[control] [nvarchar](10) NOT NULL,
	[tasa] [decimal](6, 2) NOT NULL,
	[signo] [int] NOT NULL,
 CONSTRAINT [PK_ventas_guias_detalle_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ventas_retenciones]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas_retenciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[documento] [nvarchar](14) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[tasa_retencion] [decimal](6, 2) NOT NULL,
	[retencion] [decimal](14, 2) NOT NULL,
	[cliente_id] [int] NOT NULL,
	[fecha_relacion] [date] NOT NULL,
	[ano_relacion] [nvarchar](4) NOT NULL,
	[mes_relacion] [nvarchar](2) NOT NULL,
	[renglones] [int] NOT NULL,
	[documento_nombre] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_ventas_retenciones_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ventas_retenciones_detalle]    Script Date: 12/09/2017 15:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas_retenciones_detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venta_retencione] [int] NOT NULL,
	[documento_id] [int] NOT NULL,
	[documento] [nvarchar](14) NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [nvarchar](2) NOT NULL,
	[exento] [decimal](14, 2) NOT NULL,
	[base] [decimal](14, 2) NOT NULL,
	[impuesto] [decimal](14, 2) NOT NULL,
	[total] [decimal](14, 2) NOT NULL,
	[tasa_retencion] [decimal](6, 2) NOT NULL,
	[retencion] [decimal](14, 2) NOT NULL,
	[fecha_retencion] [date] NOT NULL,
	[comprobante] [nvarchar](14) NOT NULL,
	[tipo_retencion] [nvarchar](2) NOT NULL,
	[aplica] [nvarchar](10) NOT NULL,
	[control] [nvarchar](10) NOT NULL,
	[tasa] [decimal](6, 2) NOT NULL,
	[signo] [int] NOT NULL,
 CONSTRAINT [PK_ventas_retenciones_detalle_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[agencias] ON 

INSERT [dbo].[agencias] ([id], [codigo], [nombre], [direccion], [telefono]) VALUES (1, N'00001', N'Principal', N'Centro', N'(244)322-7019')
SET IDENTITY_INSERT [dbo].[agencias] OFF
SET IDENTITY_INSERT [dbo].[bancos] ON 

INSERT [dbo].[bancos] ([id], [userlog_id], [codigo], [nombre], [direccion], [contacto], [telefono], [fax], [email], [website], [estatus], [borrado], [creado], [modificado]) VALUES (1, 5, N'00158', N'PROVINCIAL', N'EDIFICIO ONIX, AVENIDA SOCO LA CHAPA', N'GERENTE', N'(244)322-7888', N'(244)322-2222', N'atencionpro@provincial.com', N'www.provincial.com', N'Activo', 0, CAST(N'2017-07-23 10:28:00.000' AS DateTime), CAST(N'2017-07-23 01:09:00.000' AS DateTime))
INSERT [dbo].[bancos] ([id], [userlog_id], [codigo], [nombre], [direccion], [contacto], [telefono], [fax], [email], [website], [estatus], [borrado], [creado], [modificado]) VALUES (2, 5, N'00159', N'BANCO DE VENEZUELA', N'CENTRO', N'PRESIDENTE', N'(240)000-1111', N'(244)000-0000', N'soporte@venezuela.com', N'www.bancodevenezuela.com', N'Activo', 0, CAST(N'2017-07-23 10:28:00.000' AS DateTime), CAST(N'2017-07-23 01:12:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[bancos] OFF
SET IDENTITY_INSERT [dbo].[bancos_plan_cuentas] ON 

INSERT [dbo].[bancos_plan_cuentas] ([id], [codigo], [nombre], [clase]) VALUES (1, N'00KUUJ', N'COMPRAS', N'Egreso')
INSERT [dbo].[bancos_plan_cuentas] ([id], [codigo], [nombre], [clase]) VALUES (2, N'UUUJ', N'UUUUJ', N'Ingreso')
SET IDENTITY_INSERT [dbo].[bancos_plan_cuentas] OFF
SET IDENTITY_INSERT [dbo].[categorias] ON 

INSERT [dbo].[categorias] ([id], [codigo], [nombre], [descripcion]) VALUES (1, N'Cat01', N'Liquidos', N'Liquidos')
INSERT [dbo].[categorias] ([id], [codigo], [nombre], [descripcion]) VALUES (2, N'Cat02', N'Metales', N'Metales')
INSERT [dbo].[categorias] ([id], [codigo], [nombre], [descripcion]) VALUES (3, N'Cat03', N'Liquidos', N'Liquidos')
SET IDENTITY_INSERT [dbo].[categorias] OFF
SET IDENTITY_INSERT [dbo].[cobradores] ON 

INSERT [dbo].[cobradores] ([id], [codigo], [nombre], [apellido], [ci_rif], [direccion], [comision], [contrato], [telefono]) VALUES (1, N'00001', N'YOEL', N'DURAN', N'V-17175809-', N'GUACAMAYA', CAST(10.00 AS Decimal(6, 2)), N'TEMPORAL', N'(412)779-6533')
SET IDENTITY_INSERT [dbo].[cobradores] OFF
SET IDENTITY_INSERT [dbo].[colores] ON 

INSERT [dbo].[colores] ([id], [codigo], [nombre], [userlog_id], [borrado], [creado], [modificado]) VALUES (1, N'BL01', N'BLANCO', 5, 0, CAST(N'2017-08-05 02:04:00.000' AS DateTime), CAST(N'2017-08-10 07:26:00.000' AS DateTime))
INSERT [dbo].[colores] ([id], [codigo], [nombre], [userlog_id], [borrado], [creado], [modificado]) VALUES (2, N'00003', N'NEGRO', 5, 1, CAST(N'2017-08-05 02:04:00.000' AS DateTime), CAST(N'2017-08-05 02:16:00.000' AS DateTime))
INSERT [dbo].[colores] ([id], [codigo], [nombre], [userlog_id], [borrado], [creado], [modificado]) VALUES (3, N'00002', N'AZUL', 5, 0, CAST(N'2017-08-05 02:05:00.000' AS DateTime), CAST(N'2017-08-05 02:05:00.000' AS DateTime))
INSERT [dbo].[colores] ([id], [codigo], [nombre], [userlog_id], [borrado], [creado], [modificado]) VALUES (4, N'00004', N'VERDE', 5, 0, CAST(N'2017-08-05 02:16:00.000' AS DateTime), CAST(N'2017-08-05 02:16:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[colores] OFF
SET IDENTITY_INSERT [dbo].[cuentas_bancarias] ON 

INSERT [dbo].[cuentas_bancarias] ([id], [banco_id], [codigo], [nombres], [apellidos], [tipo_cuenta], [numero_cuenta], [codigo_contable], [direccion], [contacto], [telefono], [fax], [email], [website], [estatus], [naturaleza_cuenta], [fecha_apertura], [fecha_conciliacion], [fecha_alta], [saldo], [saldo_conciliado], [total_debitos], [total_creditos], [idb], [ultimo_numero_chq], [numero_nota_debito], [numero_nota_credito], [rif]) VALUES (1, 1, N'00001', N'YOEL ', N'DURAN', N'Corriente', N'0102-0350-36-0000311304', N'', N'', N'', N'(   )   -', N'(   )   -', N'yoelduran25@gmail.com', N'', N'Activa', N'Natural', CAST(N'2016-09-05' AS Date), CAST(N'2016-09-05' AS Date), CAST(N'2016-09-05' AS Date), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(6, 2)), 0, 0, 0, N'V-17175809-0')
INSERT [dbo].[cuentas_bancarias] ([id], [banco_id], [codigo], [nombres], [apellidos], [tipo_cuenta], [numero_cuenta], [codigo_contable], [direccion], [contacto], [telefono], [fax], [email], [website], [estatus], [naturaleza_cuenta], [fecha_apertura], [fecha_conciliacion], [fecha_alta], [saldo], [saldo_conciliado], [total_debitos], [total_creditos], [idb], [ultimo_numero_chq], [numero_nota_debito], [numero_nota_credito], [rif]) VALUES (2, 1, N'00002', N'YOEL ', N'DURAN', N'Corriente', N'0108-0050-00-0000000111', N'', N'', N'', N'(   )   -', N'(   )   -', N'yoelduran25@gmail.com', N'', N'Activa', N'Natural', CAST(N'2017-07-21' AS Date), CAST(N'2017-07-21' AS Date), CAST(N'2017-07-21' AS Date), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(14, 2)), CAST(0.00 AS Decimal(6, 2)), 0, 0, 0, N'V-17175809-9')
SET IDENTITY_INSERT [dbo].[cuentas_bancarias] OFF
SET IDENTITY_INSERT [dbo].[cuentasbancarias_proveedores] ON 

INSERT [dbo].[cuentasbancarias_proveedores] ([id], [userlog_id], [proveedor_id], [cuentabancaria_id], [creado]) VALUES (3, 6, 0, 1, CAST(N'2017-07-19 11:09:00.000' AS DateTime))
INSERT [dbo].[cuentasbancarias_proveedores] ([id], [userlog_id], [proveedor_id], [cuentabancaria_id], [creado]) VALUES (4, 6, 0, 1, CAST(N'2017-07-19 11:16:00.000' AS DateTime))
INSERT [dbo].[cuentasbancarias_proveedores] ([id], [userlog_id], [proveedor_id], [cuentabancaria_id], [creado]) VALUES (6, 6, 2, 1, CAST(N'2017-07-19 11:43:00.000' AS DateTime))
INSERT [dbo].[cuentasbancarias_proveedores] ([id], [userlog_id], [proveedor_id], [cuentabancaria_id], [creado]) VALUES (9, 6, 1, 1, CAST(N'2017-07-21 09:22:00.000' AS DateTime))
INSERT [dbo].[cuentasbancarias_proveedores] ([id], [userlog_id], [proveedor_id], [cuentabancaria_id], [creado]) VALUES (10, 6, 1, 2, CAST(N'2017-07-21 10:00:00.000' AS DateTime))
INSERT [dbo].[cuentasbancarias_proveedores] ([id], [userlog_id], [proveedor_id], [cuentabancaria_id], [creado]) VALUES (11, 5, 3, 1, CAST(N'2017-07-22 12:24:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[cuentasbancarias_proveedores] OFF
SET IDENTITY_INSERT [dbo].[departamentos] ON 

INSERT [dbo].[departamentos] ([id], [userlog_id], [codigo], [nombre], [preciomaximo], [preciooferta], [preciomayor], [preciominimo], [cvpreciomaximo], [cvpreciooferta], [cvpreciomayor], [cvpreciominimo], [ccpreciomaximo], [ccpreciooferta], [ccpreciomayor], [ccpreciominimo], [imagen], [borrado], [creado], [modificado]) VALUES (1, 5, N'00001', N'DAMAS', 10, 20, 30, 40, 20, 10, 10, 10, 20, 10, 10, 10, N'megan-fox-hd-sweet-girl.png', 0, CAST(N'2017-07-23 12:53:00.000' AS DateTime), CAST(N'2017-08-19 06:54:00.000' AS DateTime))
INSERT [dbo].[departamentos] ([id], [userlog_id], [codigo], [nombre], [preciomaximo], [preciooferta], [preciomayor], [preciominimo], [cvpreciomaximo], [cvpreciooferta], [cvpreciomayor], [cvpreciominimo], [ccpreciomaximo], [ccpreciooferta], [ccpreciomayor], [ccpreciominimo], [imagen], [borrado], [creado], [modificado]) VALUES (2, 5, N'00002', N'CABALLEROS', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'transformers-series-definicion-wallpaper-peliculas-posts-features-review-images-51604.jpg.png', 0, CAST(N'2017-07-23 12:57:00.000' AS DateTime), CAST(N'2017-07-23 08:58:00.000' AS DateTime))
INSERT [dbo].[departamentos] ([id], [userlog_id], [codigo], [nombre], [preciomaximo], [preciooferta], [preciomayor], [preciominimo], [cvpreciomaximo], [cvpreciooferta], [cvpreciomayor], [cvpreciominimo], [ccpreciomaximo], [ccpreciooferta], [ccpreciomayor], [ccpreciominimo], [imagen], [borrado], [creado], [modificado]) VALUES (3, 5, N'00003', N'NIÑOS', 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, N'transformers-la-guarida-de-kovack.jpeg', 0, CAST(N'2017-07-23 09:00:00.000' AS DateTime), CAST(N'2017-07-23 09:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[departamentos] OFF
SET IDENTITY_INSERT [dbo].[depositos] ON 

INSERT [dbo].[depositos] ([id], [codigo], [nombre], [direccion], [telefono]) VALUES (1, N'00001', N'Principal', N'Oficina', N'(009)999-9999')
SET IDENTITY_INSERT [dbo].[depositos] OFF
SET IDENTITY_INSERT [dbo].[documentos] ON 

INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (1, N'Ventas', N'VENTA', N'01', 1, N'FAC', N'ven_factura.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (2, N'Ventas', N'NOTA DEBITO', N'02', 1, N'NDB', N'ven_nota_debito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (3, N'Ventas', N'NOTA CREDITO', N'03', -1, N'NCR', N'ven_nota_credito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (4, N'Ventas', N'NOTA ENTREGA', N'04', 1, N'NEN', N'ven_nota_entrega.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (5, N'Ventas', N'PRESUPUESTO', N'05', 1, N'PRE', N'ven_presupuesto.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (6, N'Ventas', N'PEDIDO', N'06', 1, N'PED', N'ven_pedido.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (7, N'CXC', N'RECIBO DE PAGO CLIENTES', N'01', -1, N'PAG', N'cxc_recibo.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (8, N'CXC', N'FACTURA POR COBRAR CLIENTE', N'02', 1, N'FAC', N'')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (9, N'CXC', N'NOTA DE DEBITO ADMINISTRATIVA CLIENTES', N'03', 1, N'NDB', N'cxc_nota_debito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (10, N'CXC', N'NOTA DE CREDITO ADMINISTRATIVA CLIENTES', N'04', -1, N'NCR', N'cxc_nota_credito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (11, N'CXC', N'CHEQUE DEVUELTO CLIENTE', N'05', 1, N'CHD', N'cxc_cheque_devuelto.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (12, N'CXC', N'ANTICIPO CLIENTE', N'06', -1, N'ANT', N'cxc_recibo.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (13, N'CXP', N'RECIBO DE PAGO PROVEEDOR', N'01', -1, N'PAG', N'cxp_recibo.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (14, N'CXP', N'FACTURA POR PAGAR PROVEEDORES', N'02', 1, N'FAC', N'')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (15, N'CXP', N'NOTA DE DEBITO ADMINISTRATIVA PROVEEDORE', N'03', 1, N'NDB', N'cxp_nota_debito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (16, N'CXP', N'NOTA DE CREDITO ADMINISTRATIVA PROVEEDOR', N'04', -1, N'NCR', N'cxp_nota_credito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (17, N'CXP', N'CHEQUE DEVUELTO PROVEEDOR', N'05', 1, N'CHD', N'cxp_cheque_devuelto.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (18, N'CXP', N'ANTICIPO PROVEEDOR', N'06', -1, N'ANT', N'cxp_recibo.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (19, N'Compras', N'COMPRAS', N'01', 1, N'FAC', N'com_factura.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (20, N'Compras', N'NOTA DEBITO', N'02', 1, N'NDB', N'com_nota_debito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (21, N'Compras', N'NOTA CREDITO', N'03', -1, N'NCR', N'com_nota_credito.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (22, N'Ventas', N'RETENCION IVA', N'07', 1, N'', N'ven_retencion_iva.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (23, N'Ventas', N'RETENCION ISLR', N'08', 1, N'', N'ven_retencion_islr.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (24, N'Inventario', N'CARGOS', N'01', 1, N'CAR', N'inv_movimiento.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (25, N'Inventario', N'DESCARGOS', N'02', -1, N'DES', N'inv_movimiento.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (26, N'Inventario', N'TRANSFERENCIA', N'03', 1, N'TRA', N'inv_movimiento.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (27, N'Compras', N'ORDEN COMPRA', N'04', 1, N'ORD', N'com_orden_compra.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (28, N'Compras', N'RETENCION IVA', N'07', 1, N'', N'com_retencion_iva.lrf')
INSERT [dbo].[documentos] ([id], [tipo], [nombre], [codigo], [signo], [siglas], [comando]) VALUES (29, N'Compras', N'RETENCION ISLR', N'08', 1, N'', N'com_retencion_islr.lrf')
SET IDENTITY_INSERT [dbo].[documentos] OFF
SET IDENTITY_INSERT [dbo].[empresas] ON 

INSERT [dbo].[empresas] ([id], [pais], [estado], [municipio], [parroquia], [nombre], [direccion], [denominacion_social], [rif], [telefono], [telefonocel], [sucursal], [codigo_sucursal], [contacto], [telefonocontacto], [fax], [email], [website], [registro], [codigo], [ciudad], [codigo_postal], [retencion_iva], [retencion_islr], [factor_cambio], [debito_bancario], [imagen], [tomo], [hoja], [folio]) VALUES (1, N'VENEZUELA', N'JOSE FELIX RIBAS', N'JOSE FELIX RIBAS', N'CENTRO', N'JE Systems', N'CENTRO', N'JESYSTEMS C.A', N'J-12345678-9', N'(244)322-7817', N'(412)779-6533', N'unica', N'0001', N'YOEL DURAN', N'(244)322-7817', N'(   )   -', N'yoelduran25@gmail.com', N'jesystems.com.ve', N'0002', N'00001', N'LA VICTORIA', N'2121', CAST(12.00 AS Decimal(6, 2)), CAST(8.00 AS Decimal(6, 2)), CAST(1.00 AS Decimal(6, 2)), CAST(12.00 AS Decimal(6, 2)), N'Penguins.jpg', N'0001', N'01', N'01')
SET IDENTITY_INSERT [dbo].[empresas] OFF
SET IDENTITY_INSERT [dbo].[marcas] ON 

INSERT [dbo].[marcas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (1, 5, N'00001', N'NIKE', 0, CAST(N'2017-07-24 07:59:00.000' AS DateTime), CAST(N'2017-07-24 07:59:00.000' AS DateTime))
INSERT [dbo].[marcas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (2, 5, N'00002', N'PUMA', 0, CAST(N'2017-07-24 07:59:00.000' AS DateTime), CAST(N'2017-07-24 07:59:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[marcas] OFF
SET IDENTITY_INSERT [dbo].[medios_pago_cobro] ON 

INSERT [dbo].[medios_pago_cobro] ([id], [codigo], [nombre], [estatus_cobro], [estatus_pago]) VALUES (1, N'00001', N'EFECTIVO', 1, 1)
INSERT [dbo].[medios_pago_cobro] ([id], [codigo], [nombre], [estatus_cobro], [estatus_pago]) VALUES (2, N'00002', N'CESTA TICKET', 1, 0)
INSERT [dbo].[medios_pago_cobro] ([id], [codigo], [nombre], [estatus_cobro], [estatus_pago]) VALUES (3, N'00003', N'CHEQUE', 1, 1)
INSERT [dbo].[medios_pago_cobro] ([id], [codigo], [nombre], [estatus_cobro], [estatus_pago]) VALUES (4, N'00004', N'TDC', 1, 0)
INSERT [dbo].[medios_pago_cobro] ([id], [codigo], [nombre], [estatus_cobro], [estatus_pago]) VALUES (5, N'00005', N'TDD', 1, 0)
SET IDENTITY_INSERT [dbo].[medios_pago_cobro] OFF
SET IDENTITY_INSERT [dbo].[monedas] ON 

INSERT [dbo].[monedas] ([id], [userlog_id], [codigo], [nombre], [simbolo], [cambioventa], [cambiocompra], [predeterminado], [notas], [borrado], [creado], [modificado]) VALUES (1, 5, N'00001', N'BOLIVAR FUERTE', N'VF', 1, 1, 1, N'MONEDA NACIONAL', 0, CAST(N'2017-07-23 10:28:00.000' AS DateTime), CAST(N'2017-07-23 10:28:00.000' AS DateTime))
INSERT [dbo].[monedas] ([id], [userlog_id], [codigo], [nombre], [simbolo], [cambioventa], [cambiocompra], [predeterminado], [notas], [borrado], [creado], [modificado]) VALUES (2, 5, N'00002', N'DOLAR ', N'$', 7200, 2300, 0, N'DOLAR', 0, CAST(N'2017-07-23 10:28:00.000' AS DateTime), CAST(N'2017-07-23 10:28:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[monedas] OFF
SET IDENTITY_INSERT [dbo].[proveedores] ON 

INSERT [dbo].[proveedores] ([id], [grupo_id], [userlog_id], [pais], [estado], [municipio], [parroquia], [codigo], [nombre], [contacto], [rif], [razon_social], [dir_fiscal], [telefono_ofi], [telefono_cel], [fax], [email], [website], [ciudad], [denominacion_fiscal], [codigo_postal], [notas], [advertencia], [estatus], [codigo_cobrar], [codigo_ingresos], [codigo_anticipos], [retencion_iva], [retencion_islr], [anticipos], [debitos], [creditos], [saldo], [disponible], [ventas_g], [ventas_1], [ventas_2], [ventas_3], [ventas_4], [cobranza_g], [cobranza_1], [cobranza_2], [cobranza_3], [cobranza_4], [estatus_vendedor], [estatus_ventas], [estatus_cobranza], [estatus_departamento], [borrado], [fecha_ult_compra], [fecha_ult_pago], [creado], [modificado]) VALUES (1, 1, 5, N'VENEZUELA', N'ARAGUA', N'JOSE FELIX RIBAS', N'LAS GUACAMAYAS', N'00001', N'YOEL DURAN', N'YOEL DURAN', N'V-17175809-9', N'YOEL', N'GUACAMAYA', N'(412)779-6533', N'(412)779-6533', N'(   )   -', N'yoelduran25@gmail.com', N'jesystems.com.ve', N'LA VICTORIA', N'', N'2121', N'NINGUNA', N'NINGUNA', N'', N'', N'', N'', 12, 75, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 500, 0, 0, 0, 0, 0, 0, 0, 0, CAST(N'2017-04-06 03:55:00.000' AS DateTime), CAST(N'2017-04-06 03:55:00.000' AS DateTime), CAST(N'2017-04-06 03:55:00.000' AS DateTime), CAST(N'2017-07-21 11:03:00.000' AS DateTime))
INSERT [dbo].[proveedores] ([id], [grupo_id], [userlog_id], [pais], [estado], [municipio], [parroquia], [codigo], [nombre], [contacto], [rif], [razon_social], [dir_fiscal], [telefono_ofi], [telefono_cel], [fax], [email], [website], [ciudad], [denominacion_fiscal], [codigo_postal], [notas], [advertencia], [estatus], [codigo_cobrar], [codigo_ingresos], [codigo_anticipos], [retencion_iva], [retencion_islr], [anticipos], [debitos], [creditos], [saldo], [disponible], [ventas_g], [ventas_1], [ventas_2], [ventas_3], [ventas_4], [cobranza_g], [cobranza_1], [cobranza_2], [cobranza_3], [cobranza_4], [estatus_vendedor], [estatus_ventas], [estatus_cobranza], [estatus_departamento], [borrado], [fecha_ult_compra], [fecha_ult_pago], [creado], [modificado]) VALUES (2, 1, 0, N'VENEZUELA', N'ARAGUA', N'JOSE FELIX RIBAS', N'LAS GUACAMAYAS ', N'00002', N'YOEL', N'', N'V-17175777-7', N'YOEL', N'', N'(   )   -', N'(   )   -', N'(   )   -', N'', N'', N'LA VICTORIA', N'', N'2121', N'', N'', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 700, 1500, 200, 500, 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, CAST(N'1999-01-01 12:00:00.000' AS DateTime), CAST(N'1999-01-01 12:00:00.000' AS DateTime), CAST(N'2017-07-18 12:22:00.000' AS DateTime), CAST(N'2017-07-18 12:54:00.000' AS DateTime))
INSERT [dbo].[proveedores] ([id], [grupo_id], [userlog_id], [pais], [estado], [municipio], [parroquia], [codigo], [nombre], [contacto], [rif], [razon_social], [dir_fiscal], [telefono_ofi], [telefono_cel], [fax], [email], [website], [ciudad], [denominacion_fiscal], [codigo_postal], [notas], [advertencia], [estatus], [codigo_cobrar], [codigo_ingresos], [codigo_anticipos], [retencion_iva], [retencion_islr], [anticipos], [debitos], [creditos], [saldo], [disponible], [ventas_g], [ventas_1], [ventas_2], [ventas_3], [ventas_4], [cobranza_g], [cobranza_1], [cobranza_2], [cobranza_3], [cobranza_4], [estatus_vendedor], [estatus_ventas], [estatus_cobranza], [estatus_departamento], [borrado], [fecha_ult_compra], [fecha_ult_pago], [creado], [modificado]) VALUES (3, 2, 5, N'', N'', N'', N'', N'00003', N'JOSUE', N'JOSUE', N'V-17888999-9', N'JOSUE', N'GUACAMAYA', N'(   )   -', N'(   )   -', N'(   )   -', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, CAST(N'1999-01-01 12:00:00.000' AS DateTime), CAST(N'1999-01-01 12:00:00.000' AS DateTime), CAST(N'2017-07-22 12:24:00.000' AS DateTime), CAST(N'2017-07-22 12:24:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[proveedores] OFF
SET IDENTITY_INSERT [dbo].[proveedores_grupo] ON 

INSERT [dbo].[proveedores_grupo] ([id], [codigo], [nombre], [descripcion]) VALUES (1, N'00001', N'VIP', N'PROVEEDORES VIP')
INSERT [dbo].[proveedores_grupo] ([id], [codigo], [nombre], [descripcion]) VALUES (2, N'00002', N'ESTANDAR', N'PROVEEDORES ESTANDAR SIN NINGUN TIPO DE DESCUENTOS')
SET IDENTITY_INSERT [dbo].[proveedores_grupo] OFF
SET IDENTITY_INSERT [dbo].[tallas] ON 

INSERT [dbo].[tallas] ([id], [codigo], [nombre], [userlog_id], [borrado], [creado], [modificado]) VALUES (1, N'20', N'20', 5, 1, CAST(N'2017-08-05 02:38:00.000' AS DateTime), CAST(N'2017-08-10 07:26:00.000' AS DateTime))
INSERT [dbo].[tallas] ([id], [codigo], [nombre], [userlog_id], [borrado], [creado], [modificado]) VALUES (2, N'XG', N'XG', 5, 0, CAST(N'2017-08-10 07:25:00.000' AS DateTime), CAST(N'2017-08-10 07:25:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tallas] OFF
SET IDENTITY_INSERT [dbo].[tasas] ON 

INSERT [dbo].[tasas] ([id], [nombre], [tasa]) VALUES (1, N'ESTANDAR', CAST(12.00 AS Decimal(6, 2)))
INSERT [dbo].[tasas] ([id], [nombre], [tasa]) VALUES (2, N'MINIMO', CAST(8.00 AS Decimal(6, 2)))
INSERT [dbo].[tasas] ([id], [nombre], [tasa]) VALUES (3, N'MAXIMO', CAST(19.00 AS Decimal(6, 2)))
INSERT [dbo].[tasas] ([id], [nombre], [tasa]) VALUES (4, N'TARJETAS', CAST(10.00 AS Decimal(6, 2)))
SET IDENTITY_INSERT [dbo].[tasas] OFF
SET IDENTITY_INSERT [dbo].[transportes] ON 

INSERT [dbo].[transportes] ([id], [userlog_id], [codigo], [nombre], [contrato], [placa], [telefono], [direccion], [borrado], [creado], [modificado]) VALUES (1, 5, N'00001', N'YOEL DURAN', N'009OKM76', N'188-IJK', N'(412)779-6533', N'GUACAMAYA', 0, CAST(N'2017-07-22 11:51:00.000' AS DateTime), CAST(N'2017-07-22 11:51:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[transportes] OFF
SET IDENTITY_INSERT [dbo].[unidadesmedidas] ON 

INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (1, 5, N'00001', N'UNIDAD', 0, CAST(N'2017-07-24 06:07:00.000' AS DateTime), CAST(N'2017-07-24 06:07:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (2, 5, N'00002', N'BOTELLA', 0, CAST(N'2017-07-24 06:08:00.000' AS DateTime), CAST(N'2017-07-24 06:08:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (3, 5, N'00003', N'CAJA', 0, CAST(N'2017-07-24 06:09:00.000' AS DateTime), CAST(N'2017-07-24 06:09:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (4, 5, N'00004', N'BULTO', 0, CAST(N'2017-07-24 06:09:00.000' AS DateTime), CAST(N'2017-07-24 06:09:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (5, 5, N'00005', N'PORCION', 0, CAST(N'2017-07-24 06:09:00.000' AS DateTime), CAST(N'2017-07-24 06:13:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (6, 5, N'00006', N'DOCENA', 0, CAST(N'2017-07-24 06:10:00.000' AS DateTime), CAST(N'2017-07-24 06:10:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (7, 5, N'00007', N'CMS', 0, CAST(N'2017-07-24 06:10:00.000' AS DateTime), CAST(N'2017-07-24 06:10:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (8, 5, N'00008', N'METROS', 0, CAST(N'2017-07-24 06:10:00.000' AS DateTime), CAST(N'2017-07-24 06:10:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (9, 5, N'00009', N'HORA', 0, CAST(N'2017-07-24 06:10:00.000' AS DateTime), CAST(N'2017-07-24 06:10:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (10, 5, N'00010', N'MINUTOS', 0, CAST(N'2017-07-24 06:11:00.000' AS DateTime), CAST(N'2017-07-24 06:11:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (11, 5, N'00011', N'1/4 GALON', 0, CAST(N'2017-07-24 06:11:00.000' AS DateTime), CAST(N'2017-07-24 06:11:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (12, 5, N'00012', N'TAMBOR', 0, CAST(N'2017-07-24 06:12:00.000' AS DateTime), CAST(N'2017-07-24 06:12:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (13, 5, N'00013', N'PAILA', 0, CAST(N'2017-07-24 06:13:00.000' AS DateTime), CAST(N'2017-07-24 06:13:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (14, 5, N'00014', N'LATA', 0, CAST(N'2017-07-24 06:13:00.000' AS DateTime), CAST(N'2017-07-24 06:13:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (15, 5, N'00015', N'BLISTER', 0, CAST(N'2017-07-24 06:14:00.000' AS DateTime), CAST(N'2017-07-24 06:14:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (16, 5, N'00016', N'GALON', 0, CAST(N'2017-07-24 06:14:00.000' AS DateTime), CAST(N'2017-07-24 06:14:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (17, 5, N'00017', N'LITRO', 0, CAST(N'2017-07-24 06:14:00.000' AS DateTime), CAST(N'2017-07-24 06:14:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (18, 5, N'00018', N'MT2', 0, CAST(N'2017-07-24 06:14:00.000' AS DateTime), CAST(N'2017-07-24 06:14:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (19, 5, N'00019', N'MT3', 0, CAST(N'2017-07-24 06:15:00.000' AS DateTime), CAST(N'2017-07-24 06:15:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (20, 5, N'00020', N'MTS', 0, CAST(N'2017-07-24 06:15:00.000' AS DateTime), CAST(N'2017-07-24 06:15:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (21, 5, N'00021', N'PZA', 0, CAST(N'2017-07-24 06:15:00.000' AS DateTime), CAST(N'2017-07-24 06:15:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (22, 5, N'00022', N'BOLSA', 0, CAST(N'2017-07-24 06:15:00.000' AS DateTime), CAST(N'2017-07-24 06:15:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (23, 5, N'00023', N'SACO', 0, CAST(N'2017-07-24 06:16:00.000' AS DateTime), CAST(N'2017-07-24 06:16:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (24, 5, N'00024', N'KG', 0, CAST(N'2017-07-24 07:57:00.000' AS DateTime), CAST(N'2017-07-24 08:00:00.000' AS DateTime))
INSERT [dbo].[unidadesmedidas] ([id], [userlog_id], [codigo], [nombre], [borrado], [creado], [modificado]) VALUES (25, 5, N'00025', N'GRAMOS', 0, CAST(N'2017-07-24 08:00:00.000' AS DateTime), CAST(N'2017-07-24 08:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[unidadesmedidas] OFF
ALTER TABLE [dbo].[bancos_movimientos] ADD  CONSTRAINT [DF__bancos_mo__fecha__07C12930]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[bancos_movimientos] ADD  CONSTRAINT [DF__bancos_mov__debe__08B54D69]  DEFAULT ((0.00)) FOR [debe]
GO
ALTER TABLE [dbo].[bancos_movimientos] ADD  CONSTRAINT [DF__bancos_mo__haber__09A971A2]  DEFAULT ((0.00)) FOR [haber]
GO
ALTER TABLE [dbo].[bancos_movimientos] ADD  CONSTRAINT [DF__bancos_mo__aplic__0A9D95DB]  DEFAULT ('2000-01-01') FOR [aplica]
GO
ALTER TABLE [dbo].[bancos_movimientos_medios] ADD  CONSTRAINT [DF__bancos_mo__fecha__0E6E26BF]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[bancos_movimientos_medios] ADD  CONSTRAINT [DF__bancos_mo__impor__0F624AF8]  DEFAULT ((0.00)) FOR [importe]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__telefo__10566F31]  DEFAULT (NULL) FOR [telefono_cel_cont]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__retenc__114A936A]  DEFAULT ((0.00)) FOR [retencion_iva]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__retenc__123EB7A3]  DEFAULT ((0.00)) FOR [retencion_islr]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__descue__1332DBDC]  DEFAULT ((0.00)) FOR [descuento]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__recarg__14270015]  DEFAULT ((0.00)) FOR [recargo]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__dias_c__151B244E]  DEFAULT ((0)) FOR [dias_credito]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__limite__160F4887]  DEFAULT ((0.00)) FOR [limite_credito]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__doc_pe__17036CC0]  DEFAULT ((0)) FOR [doc_pendientes]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__fecha___17F790F9]  DEFAULT ('2000-01-01') FOR [fecha_alta]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__fecha___18EBB532]  DEFAULT ('2000-01-01') FOR [fecha_baja]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__fecha___19DFD96B]  DEFAULT ('2000-01-01') FOR [fecha_ult_venta]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__fecha___1AD3FDA4]  DEFAULT ('2000-01-01') FOR [fecha_ult_pago]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__antici__1BC821DD]  DEFAULT ((0.00)) FOR [anticipos]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__debito__1CBC4616]  DEFAULT ((0.00)) FOR [debitos]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__credit__1DB06A4F]  DEFAULT ((0.00)) FOR [creditos]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__saldo__1EA48E88]  DEFAULT ((0.00)) FOR [saldo]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__dispon__1F98B2C1]  DEFAULT ((0.00)) FOR [disponible]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__descue__208CD6FA]  DEFAULT ((0.00)) FOR [descuento_pronto_pago]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__import__2180FB33]  DEFAULT ((0.00)) FOR [importe_ult_pago]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__import__22751F6C]  DEFAULT ((0.00)) FOR [importe_ult_venta]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__regist__236943A5]  DEFAULT (NULL) FOR [registro]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__tomo__245D67DE]  DEFAULT (NULL) FOR [tomo]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__hoja__25518C17]  DEFAULT (NULL) FOR [hoja]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF__clientes__folio__2645B050]  DEFAULT (NULL) FOR [folio]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__tasa1__2739D489]  DEFAULT ((0.00)) FOR [tasa1]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__tasa2__282DF8C2]  DEFAULT ((0.00)) FOR [tasa2]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__tasa3__29221CFB]  DEFAULT ((0.00)) FOR [tasa3]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__tasa_re__2A164134]  DEFAULT ((0.00)) FOR [tasa_retencion_iva]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__tasa_re__2B0A656D]  DEFAULT ((0.00)) FOR [tasa_retencion_islr]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__fecha__2BFE89A6]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__fecha_v__2CF2ADDF]  DEFAULT ('2000-01-01') FOR [fecha_vencimiento]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__exento__2DE6D218]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__base1__2EDAF651]  DEFAULT ((0.00)) FOR [base1]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__base2__2FCF1A8A]  DEFAULT ((0.00)) FOR [base2]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__base3__30C33EC3]  DEFAULT ((0.00)) FOR [base3]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__impuest__31B762FC]  DEFAULT ((0.00)) FOR [impuesto1]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__impuest__32AB8735]  DEFAULT ((0.00)) FOR [impuesto2]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__impuest__339FAB6E]  DEFAULT ((0.00)) FOR [impuesto3]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__base__3493CFA7]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__impuest__3587F3E0]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__total__367C1819]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__retenci__37703C52]  DEFAULT ((0.00)) FOR [retencion_iva]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__retenci__3864608B]  DEFAULT ((0.00)) FOR [retencion_islr]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__fecha_r__395884C4]  DEFAULT ('2000-01-01') FOR [fecha_registro]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__dias__3A4CA8FD]  DEFAULT ((0)) FOR [dias]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__descuen__3B40CD36]  DEFAULT ((0.00)) FOR [descuento1]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__descuen__3C34F16F]  DEFAULT ((0.00)) FOR [descuento2]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__cargos__3D2915A8]  DEFAULT ((0.00)) FOR [cargos]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__descuen__3E1D39E1]  DEFAULT ((0.00)) FOR [descuento1p]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__descuen__3F115E1A]  DEFAULT ((0.00)) FOR [descuento2p]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__cargosp__40058253]  DEFAULT ((0.00)) FOR [cargosp]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__subtota__40F9A68C]  DEFAULT ((0.00)) FOR [subtotal_neto]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__factor___41EDCAC5]  DEFAULT ((0.0000)) FOR [factor_cambio]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__monto_d__42E1EEFE]  DEFAULT ((0.00)) FOR [monto_divisa]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__renglon__43D61337]  DEFAULT ((0)) FOR [renglones]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__saldo_p__44CA3770]  DEFAULT ((0.00)) FOR [saldo_pendiente]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__dias_va__45BE5BA9]  DEFAULT ((0)) FOR [dias_validez]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__signo__46B27FE2]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__subtota__47A6A41B]  DEFAULT ((0.00)) FOR [subtotal_impuesto]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__subtota__489AC854]  DEFAULT ((0.00)) FOR [subtotal]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__anticip__498EEC8D]  DEFAULT ((0.00)) FOR [anticipo_iva]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__tercero__4A8310C6]  DEFAULT ((0.00)) FOR [terceros_iva]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__neto__4B7734FF]  DEFAULT ((0.00)) FOR [neto]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__costo__4C6B5938]  DEFAULT ((0.00)) FOR [costo]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__utilida__4D5F7D71]  DEFAULT ((0.00)) FOR [utilidad]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF__compras__utilida__4E53A1AA]  DEFAULT ((0.00)) FOR [utilidadp]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__descu__4F47C5E3]  DEFAULT ((0.00)) FOR [descuento1p]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__descu__503BEA1C]  DEFAULT ((0.00)) FOR [descuento2p]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__descu__51300E55]  DEFAULT ((0.00)) FOR [descuento3p]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__descu__5224328E]  DEFAULT ((0.00)) FOR [descuento1]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__descu__531856C7]  DEFAULT ((0.00)) FOR [descuento2]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__descu__540C7B00]  DEFAULT ((0.00)) FOR [descuento3]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__total__55009F39]  DEFAULT ((0.00)) FOR [total_neto]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_de__tasa__55F4C372]  DEFAULT ((0.00)) FOR [tasa]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__impue__56E8E7AB]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__total__57DD0BE4]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__fecha__58D1301D]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__signo__59C55456]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__conte__5AB9788F]  DEFAULT ((0)) FOR [contenido_empaque]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__canti__5BAD9CC8]  DEFAULT ((0.000)) FOR [cantidad_und]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__costo__5CA1C101]  DEFAULT ((0.00)) FOR [costo_und]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__costo__5D95E53A]  DEFAULT ((0.00)) FOR [costo_promedio_und]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__costo__5E8A0973]  DEFAULT ((0.00)) FOR [costo_compra]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__canti__5F7E2DAC]  DEFAULT ((0.000)) FOR [cantidad_bono]
GO
ALTER TABLE [dbo].[compras_detalle] ADD  CONSTRAINT [DF__compras_d__costo__607251E5]  DEFAULT ((0.00)) FOR [costo_bruto]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__fecha__6166761E]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__exent__625A9A57]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_re__base__634EBE90]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__impue__6442E2C9]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__total__65370702]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__tasa___662B2B3B]  DEFAULT ((0.00)) FOR [tasa_retencion]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__reten__671F4F74]  DEFAULT ((0.00)) FOR [retencion]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__fecha__681373AD]  DEFAULT ('2000-01-01') FOR [fecha_relacion]
GO
ALTER TABLE [dbo].[compras_retenciones] ADD  CONSTRAINT [DF__compras_r__rengl__690797E6]  DEFAULT ((0)) FOR [renglones]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__fecha__69FBBC1F]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__exent__6AEFE058]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_re__base__6BE40491]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__impue__6CD828CA]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__total__6DCC4D03]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__tasa___6EC0713C]  DEFAULT ((0.00)) FOR [tasa_retencion]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__reten__6FB49575]  DEFAULT ((0.00)) FOR [retencion]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__fecha__70A8B9AE]  DEFAULT ('2000-01-01') FOR [fecha_retencion]
GO
ALTER TABLE [dbo].[compras_retenciones_detalle] ADD  CONSTRAINT [DF__compras_r__signo__719CDDE7]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__c_cobranza__7C1A6C5A]  DEFAULT ((0.00)) FOR [c_cobranza]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__c_cobranzap__7D0E9093]  DEFAULT ((0.00)) FOR [c_cobranzap]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__fecha__7E02B4CC]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__fecha_venci__7EF6D905]  DEFAULT ('2000-01-01') FOR [fecha_vencimiento]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__importe__7FEAFD3E]  DEFAULT ((0.00)) FOR [importe]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__acumulado__00DF2177]  DEFAULT ((0.00)) FOR [acumulado]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__resta__01D345B0]  DEFAULT ((0.00)) FOR [resta]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__signo__02C769E9]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__c_departame__03BB8E22]  DEFAULT ((0.00)) FOR [c_departamento]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__c_ventas__04AFB25B]  DEFAULT ((0.00)) FOR [c_ventas]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__c_ventasp__05A3D694]  DEFAULT ((0.00)) FOR [c_ventasp]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__importe_net__0697FACD]  DEFAULT ((0.00)) FOR [importe_neto]
GO
ALTER TABLE [dbo].[cxc] ADD  CONSTRAINT [DF__cxc__dias__078C1F06]  DEFAULT ((0)) FOR [dias]
GO
ALTER TABLE [dbo].[cxc_documentos] ADD  CONSTRAINT [DF__cxc_docum__fecha__0880433F]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxc_documentos] ADD  CONSTRAINT [DF__cxc_docum__impor__09746778]  DEFAULT ((0.00)) FOR [importe]
GO
ALTER TABLE [dbo].[cxc_medio_pago] ADD  CONSTRAINT [DF__cxc_medio__monto__0A688BB1]  DEFAULT ((0.00)) FOR [monto_recibido]
GO
ALTER TABLE [dbo].[cxc_medio_pago] ADD  CONSTRAINT [DF__cxc_medio__fecha__0B5CAFEA]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxc_recibos] ADD  CONSTRAINT [DF__cxc_recib__fecha__0C50D423]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxc_recibos] ADD  CONSTRAINT [DF__cxc_recib__impor__0D44F85C]  DEFAULT ((0.00)) FOR [importe]
GO
ALTER TABLE [dbo].[cxc_recibos] ADD  CONSTRAINT [DF__cxc_recib__monto__0E391C95]  DEFAULT ((0.00)) FOR [monto_recibido]
GO
ALTER TABLE [dbo].[cxc_recibos] ADD  CONSTRAINT [DF__cxc_recib__antic__0F2D40CE]  DEFAULT ((0.00)) FOR [anticipos]
GO
ALTER TABLE [dbo].[cxc_recibos] ADD  CONSTRAINT [DF__cxc_recib__cambi__10216507]  DEFAULT ((0.00)) FOR [cambio]
GO
ALTER TABLE [dbo].[cxc_recibos] ADD  CONSTRAINT [DF__cxc_recib__reten__11158940]  DEFAULT ((0.00)) FOR [retenciones]
GO
ALTER TABLE [dbo].[cxc_recibos] ADD  CONSTRAINT [DF__cxc_recib__descu__1209AD79]  DEFAULT ((0.00)) FOR [descuentos]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__fecha__12FDD1B2]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__dias__13F1F5EB]  DEFAULT ((0)) FOR [dias]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__signo__14E61A24]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__monto_recib__15DA3E5D]  DEFAULT ((0.00)) FOR [monto_recibido]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__comisionp__16CE6296]  DEFAULT ((0.00)) FOR [comisionp]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__base_comisi__17C286CF]  DEFAULT ((0.00)) FOR [base_comision]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__importe__18B6AB08]  DEFAULT ((0.00)) FOR [importe]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__acumulado__19AACF41]  DEFAULT ((0.00)) FOR [acumulado]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__castigop__1A9EF37A]  DEFAULT ((0.00)) FOR [castigop]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__resta__1B9317B3]  DEFAULT ((0.00)) FOR [resta]
GO
ALTER TABLE [dbo].[cxp] ADD  CONSTRAINT [DF__cxp__fecha_venci__1C873BEC]  DEFAULT ('2000-01-01') FOR [fecha_vencimiento]
GO
ALTER TABLE [dbo].[cxp_documentos] ADD  CONSTRAINT [DF__cxp_docum__fecha__1D7B6025]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxp_documentos] ADD  CONSTRAINT [DF__cxp_docum__impor__1E6F845E]  DEFAULT ((0.00)) FOR [importe]
GO
ALTER TABLE [dbo].[cxp_medio_pago] ADD  CONSTRAINT [DF__cxp_medio__monto__1F63A897]  DEFAULT ((0.00)) FOR [monto_recibido]
GO
ALTER TABLE [dbo].[cxp_medio_pago] ADD  CONSTRAINT [DF__cxp_medio__fecha__2057CCD0]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxp_recibos] ADD  CONSTRAINT [DF__cxp_recib__fecha__214BF109]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[cxp_recibos] ADD  CONSTRAINT [DF__cxp_recib__impor__22401542]  DEFAULT ((0.00)) FOR [importe]
GO
ALTER TABLE [dbo].[cxp_recibos] ADD  CONSTRAINT [DF__cxp_recib__monto__2334397B]  DEFAULT ((0.00)) FOR [monto_recibido]
GO
ALTER TABLE [dbo].[cxp_recibos] ADD  CONSTRAINT [DF__cxp_recib__antic__24285DB4]  DEFAULT ((0.00)) FOR [anticipos]
GO
ALTER TABLE [dbo].[cxp_recibos] ADD  CONSTRAINT [DF__cxp_recib__cambi__251C81ED]  DEFAULT ((0.00)) FOR [cambio]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__canti__336AA144]  DEFAULT ((0.000)) FOR [cantidad]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__preci__345EC57D]  DEFAULT ((0.00)) FOR [precio_neto]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__descu__3552E9B6]  DEFAULT ((0.00)) FOR [descuento1p]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__descu__36470DEF]  DEFAULT ((0.00)) FOR [descuento1]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__costo__373B3228]  DEFAULT ((0.00)) FOR [costo_venta]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__total__382F5661]  DEFAULT ((0.00)) FOR [total_neto]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__impue__39237A9A]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__total__3A179ED3]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__fecha__3B0BC30C]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__preci__3BFFE745]  DEFAULT ((0.00)) FOR [precio_final]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__conte__3CF40B7E]  DEFAULT ((0)) FOR [contenido_empaque]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__canti__3DE82FB7]  DEFAULT ((0.000)) FOR [cantidad_und]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__preci__3EDC53F0]  DEFAULT ((0.00)) FOR [precio_und]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__costo__3FD07829]  DEFAULT ((0.00)) FOR [costo_und]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__preci__40C49C62]  DEFAULT ((0.00)) FOR [precio_item]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_comand__tasa__41B8C09B]  DEFAULT ((0.00)) FOR [tasa]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__costo__42ACE4D4]  DEFAULT ((0.00)) FOR [costo_promedio_und]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__costo__43A1090D]  DEFAULT ((0.00)) FOR [costo_compra]
GO
ALTER TABLE [dbo].[pos_comandas] ADD  CONSTRAINT [DF__pos_coman__total__44952D46]  DEFAULT ((0.00)) FOR [total_descuento]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__dias___373B3228]  DEFAULT ((0)) FOR [dias_garantia]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__costo__382F5661]  DEFAULT ((0.00)) FOR [costo_proveedor]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__costo__3B0BC30C]  DEFAULT ((0.00)) FOR [costo_varios]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__costo__3CF40B7E]  DEFAULT ((0.00)) FOR [costo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__costo__3EDC53F0]  DEFAULT ((0.00)) FOR [costo_promedio]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__utili__40C49C62]  DEFAULT ((0.00)) FOR [utilidad_1]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__utili__41B8C09B]  DEFAULT ((0.00)) FOR [utilidad_2]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__utili__42ACE4D4]  DEFAULT ((0.00)) FOR [utilidad_3]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__utili__43A1090D]  DEFAULT ((0.00)) FOR [utilidad_4]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_preciomaximo]  DEFAULT ((0)) FOR [preciomaximo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_preciooferta]  DEFAULT ((0)) FOR [preciooferta]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_preciomayor]  DEFAULT ((0)) FOR [preciomayor]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_preciominimo]  DEFAULT ((0)) FOR [preciominimo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_cvpreciomaximo]  DEFAULT ((0)) FOR [cvpreciomaximo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_cvpreciooferta]  DEFAULT ((0)) FOR [cvpreciooferta]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_cvpreciomayor]  DEFAULT ((0)) FOR [cvpreciomayor]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_cvpreciominimo]  DEFAULT ((0)) FOR [cvpreciominimo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_ccpreciomaximo]  DEFAULT ((0)) FOR [ccpreciomaximo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_ccpreciooferta]  DEFAULT ((0)) FOR [ccpreciooferta]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_ccpreciomayor]  DEFAULT ((0)) FOR [ccpreciomayor]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_ccpreciominimo]  DEFAULT ((0)) FOR [ccpreciominimo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__fecha__477199F1]  DEFAULT ('2000-01-01') FOR [creado]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF__productos__fecha__4865BE2A]  DEFAULT ('2000-01-01') FOR [modificado]
GO
ALTER TABLE [dbo].[productos_costos] ADD  CONSTRAINT [DF__productos__fecha__6501FCD8]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[productos_costos] ADD  CONSTRAINT [DF__productos__costo__65F62111]  DEFAULT ((0.00)) FOR [costo]
GO
ALTER TABLE [dbo].[productos_deposito] ADD  CONSTRAINT [DF__productos__fisic__66EA454A]  DEFAULT ((0.000)) FOR [fisica]
GO
ALTER TABLE [dbo].[productos_deposito] ADD  CONSTRAINT [DF__productos__reser__67DE6983]  DEFAULT ((0.000)) FOR [reservada]
GO
ALTER TABLE [dbo].[productos_deposito] ADD  CONSTRAINT [DF__productos__dispo__68D28DBC]  DEFAULT ((0.000)) FOR [disponible]
GO
ALTER TABLE [dbo].[productos_deposito] ADD  CONSTRAINT [DF__productos__nivel__69C6B1F5]  DEFAULT ((0.000)) FOR [nivel_minimo]
GO
ALTER TABLE [dbo].[productos_deposito] ADD  CONSTRAINT [DF__productos__pto_p__6ABAD62E]  DEFAULT ((0.000)) FOR [pto_pedido]
GO
ALTER TABLE [dbo].[productos_deposito] ADD  CONSTRAINT [DF__productos__nivel__6BAEFA67]  DEFAULT ((0.000)) FOR [nivel_optimo]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__fecha__6CA31EA0]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__signo__6D9742D9]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__canti__6E8B6712]  DEFAULT ((0.000)) FOR [cantidad]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__canti__6F7F8B4B]  DEFAULT ((0.000)) FOR [cantidad_bono]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__canti__7073AF84]  DEFAULT ((0.000)) FOR [cantidad_und]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__costo__7167D3BD]  DEFAULT ((0.00)) FOR [costo_und]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__total__725BF7F6]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[productos_kardex] ADD  CONSTRAINT [DF__productos__preci__73501C2F]  DEFAULT ((0.00)) FOR [precio_und]
GO
ALTER TABLE [dbo].[productos_movimientos] ADD  CONSTRAINT [DF__productos__fecha__753864A1]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[productos_movimientos] ADD  CONSTRAINT [DF__productos__rengl__762C88DA]  DEFAULT ((0)) FOR [renglones]
GO
ALTER TABLE [dbo].[productos_movimientos] ADD  CONSTRAINT [DF__productos__total__7720AD13]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__canti__7814D14C]  DEFAULT ((0.000)) FOR [cantidad]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__canti__7908F585]  DEFAULT ((0.000)) FOR [cantidad_bono]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__canti__79FD19BE]  DEFAULT ((0.000)) FOR [cantidad_und]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__fecha__7AF13DF7]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__conte__7BE56230]  DEFAULT ((0)) FOR [contenido_empaque]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__costo__7CD98669]  DEFAULT ((0.00)) FOR [costo_und]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__total__7DCDAAA2]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[productos_movimientos_detalle] ADD  CONSTRAINT [DF__productos__costo__7EC1CEDB]  DEFAULT ((0.00)) FOR [costo_compra]
GO
ALTER TABLE [dbo].[productos_precios] ADD  CONSTRAINT [DF__productos__fecha__7FB5F314]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[productos_precios] ADD  CONSTRAINT [DF__productos__preci__00AA174D]  DEFAULT ((0.00)) FOR [precio]
GO
ALTER TABLE [dbo].[series_fiscales] ADD  CONSTRAINT [DF__series_fi__corre__15A53433]  DEFAULT ((0)) FOR [correlativo]
GO
ALTER TABLE [dbo].[subcategoria] ADD  CONSTRAINT [DF__subcatego__categ__1699586C]  DEFAULT (NULL) FOR [categoria_id]
GO
ALTER TABLE [dbo].[subcategoria] ADD  CONSTRAINT [DF__subcatego__codig__178D7CA5]  DEFAULT (NULL) FOR [codigo]
GO
ALTER TABLE [dbo].[subcategoria] ADD  CONSTRAINT [DF__subcatego__nombr__1881A0DE]  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[variantes_productos] ADD  CONSTRAINT [DF__variantes__preci__1A69E950]  DEFAULT ((0.00)) FOR [precio]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__fecha__1B5E0D89]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__fecha_ve__1C5231C2]  DEFAULT ('2000-01-01') FOR [fecha_vencimiento]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__exento__1D4655FB]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__base1__1E3A7A34]  DEFAULT ((0.00)) FOR [base1]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__base2__1F2E9E6D]  DEFAULT ((0.00)) FOR [base2]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__base3__2022C2A6]  DEFAULT ((0.00)) FOR [base3]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__impuesto__2116E6DF]  DEFAULT ((0.00)) FOR [impuesto1]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__impuesto__220B0B18]  DEFAULT ((0.00)) FOR [impuesto2]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__impuesto__22FF2F51]  DEFAULT ((0.00)) FOR [impuesto3]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__base__23F3538A]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__impuesto__24E777C3]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__total__25DB9BFC]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__tasa1__26CFC035]  DEFAULT ((0.00)) FOR [tasa1]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__tasa2__27C3E46E]  DEFAULT ((0.00)) FOR [tasa2]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__tasa3__28B808A7]  DEFAULT ((0.00)) FOR [tasa3]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__tasa_ret__29AC2CE0]  DEFAULT ((0.00)) FOR [tasa_retencion_iva]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__tasa_ret__2AA05119]  DEFAULT ((0.00)) FOR [tasa_retencion_islr]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__retencio__2B947552]  DEFAULT ((0.00)) FOR [retencion_iva]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__retencio__2C88998B]  DEFAULT ((0.00)) FOR [retencion_islr]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__fecha_re__2D7CBDC4]  DEFAULT ('2000-01-01') FOR [fecha_registro]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__dias__2E70E1FD]  DEFAULT ((0)) FOR [dias]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__descuent__2F650636]  DEFAULT ((0.00)) FOR [descuento1]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__descuent__30592A6F]  DEFAULT ((0.00)) FOR [descuento2]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__cargos__314D4EA8]  DEFAULT ((0.00)) FOR [cargos]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__descuent__324172E1]  DEFAULT ((0.00)) FOR [descuento1p]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__descuent__3335971A]  DEFAULT ((0.00)) FOR [descuento2p]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__cargosp__3429BB53]  DEFAULT ((0.00)) FOR [cargosp]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__subtotal__351DDF8C]  DEFAULT ((0.00)) FOR [subtotal_neto]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__factor_c__361203C5]  DEFAULT ((0.0000)) FOR [factor_cambio]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__fecha_pe__370627FE]  DEFAULT ('2000-01-01') FOR [fecha_pedido]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__monto_di__37FA4C37]  DEFAULT ((0.00)) FOR [monto_divisa]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__renglone__38EE7070]  DEFAULT ((0)) FOR [renglones]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__saldo_pe__39E294A9]  DEFAULT ((0.00)) FOR [saldo_pendiente]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__dias_val__3AD6B8E2]  DEFAULT ((0)) FOR [dias_validez]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__signo__3BCADD1B]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__subtotal__3CBF0154]  DEFAULT ((0.00)) FOR [subtotal_impuesto]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__subtotal__3DB3258D]  DEFAULT ((0.00)) FOR [subtotal]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__anticipo__3EA749C6]  DEFAULT ((0.00)) FOR [anticipo_iva]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__terceros__3F9B6DFF]  DEFAULT ((0.00)) FOR [terceros_iva]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__neto__408F9238]  DEFAULT ((0.00)) FOR [neto]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__costo__4183B671]  DEFAULT ((0.00)) FOR [costo]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__utilidad__4277DAAA]  DEFAULT ((0.00)) FOR [utilidad]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF__ventas__utilidad__436BFEE3]  DEFAULT ((0.00)) FOR [utilidadp]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__canti__4460231C]  DEFAULT ((0.000)) FOR [cantidad]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__preci__45544755]  DEFAULT ((0.00)) FOR [precio_neto]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__descu__46486B8E]  DEFAULT ((0.00)) FOR [descuento1p]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__descu__473C8FC7]  DEFAULT ((0.00)) FOR [descuento2p]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__descu__4830B400]  DEFAULT ((0.00)) FOR [descuento3p]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__descu__4924D839]  DEFAULT ((0.00)) FOR [descuento1]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__descu__4A18FC72]  DEFAULT ((0.00)) FOR [descuento2]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__descu__4B0D20AB]  DEFAULT ((0.00)) FOR [descuento3]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__costo__4C0144E4]  DEFAULT ((0.00)) FOR [costo_venta]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__total__4CF5691D]  DEFAULT ((0.00)) FOR [total_neto]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__impue__4DE98D56]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__total__4EDDB18F]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__fecha__4FD1D5C8]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__signo__50C5FA01]  DEFAULT ((0)) FOR [signo]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__preci__51BA1E3A]  DEFAULT ((0.00)) FOR [precio_final]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__conte__52AE4273]  DEFAULT ((0)) FOR [contenido_empaque]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__canti__53A266AC]  DEFAULT ((0.000)) FOR [cantidad_und]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__preci__54968AE5]  DEFAULT ((0.00)) FOR [precio_und]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__costo__558AAF1E]  DEFAULT ((0.00)) FOR [costo_und]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__utili__567ED357]  DEFAULT ((0.00)) FOR [utilidad]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__utili__5772F790]  DEFAULT ((0.00)) FOR [utilidadp]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__preci__58671BC9]  DEFAULT ((0.00)) FOR [precio_item]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__dias___595B4002]  DEFAULT ((0)) FOR [dias_garantia]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__preci__5A4F643B]  DEFAULT ((0.00)) FOR [precio_sugerido]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__cobra__5B438874]  DEFAULT ((0.00)) FOR [cobranzap]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__venta__5C37ACAD]  DEFAULT ((0.00)) FOR [ventasp]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__cobra__5D2BD0E6]  DEFAULT ((0.00)) FOR [cobranzap_vendedor]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__venta__5E1FF51F]  DEFAULT ((0.00)) FOR [ventasp_vendedor]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__cobra__5F141958]  DEFAULT ((0.00)) FOR [cobranza]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__venta__60083D91]  DEFAULT ((0.00)) FOR [ventas]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__cobra__60FC61CA]  DEFAULT ((0.00)) FOR [cobranza_vendedor]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__venta__61F08603]  DEFAULT ((0.00)) FOR [ventas_vendedor]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__costo__62E4AA3C]  DEFAULT ((0.00)) FOR [costo_promedio_und]
GO
ALTER TABLE [dbo].[ventas_detalle] ADD  CONSTRAINT [DF__ventas_de__costo__63D8CE75]  DEFAULT ((0.00)) FOR [costo_compra]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__fecha__64CCF2AE]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__exent__65C116E7]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gui__base__66B53B20]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__impue__67A95F59]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__total__689D8392]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__tasa___6991A7CB]  DEFAULT ((0.00)) FOR [tasa_retencion]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__reten__6A85CC04]  DEFAULT ((0.00)) FOR [retencion]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__fecha__6B79F03D]  DEFAULT ('2000-01-01') FOR [fecha_relacion]
GO
ALTER TABLE [dbo].[ventas_guias] ADD  CONSTRAINT [DF__ventas_gu__rengl__6C6E1476]  DEFAULT ((0)) FOR [renglones]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gu__fecha__6D6238AF]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gu__exent__6E565CE8]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gui__base__6F4A8121]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gu__impue__703EA55A]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gu__total__7132C993]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gu__tasa___7226EDCC]  DEFAULT ((0.00)) FOR [tasa_retencion]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gu__reten__731B1205]  DEFAULT ((0.00)) FOR [retencion]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gu__fecha__740F363E]  DEFAULT ('2000-01-01') FOR [fecha_retencion]
GO
ALTER TABLE [dbo].[ventas_guias_detalle] ADD  CONSTRAINT [DF__ventas_gui__tasa__75035A77]  DEFAULT ((0.00)) FOR [tasa]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__fecha__75F77EB0]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__exent__76EBA2E9]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_ret__base__77DFC722]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__impue__78D3EB5B]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__total__79C80F94]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__tasa___7ABC33CD]  DEFAULT ((0.00)) FOR [tasa_retencion]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__reten__7BB05806]  DEFAULT ((0.00)) FOR [retencion]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__fecha__7CA47C3F]  DEFAULT ('2000-01-01') FOR [fecha_relacion]
GO
ALTER TABLE [dbo].[ventas_retenciones] ADD  CONSTRAINT [DF__ventas_re__rengl__7D98A078]  DEFAULT ((0)) FOR [renglones]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_re__fecha__7E8CC4B1]  DEFAULT ('2000-01-01') FOR [fecha]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_re__exent__7F80E8EA]  DEFAULT ((0.00)) FOR [exento]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_ret__base__00750D23]  DEFAULT ((0.00)) FOR [base]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_re__impue__0169315C]  DEFAULT ((0.00)) FOR [impuesto]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_re__total__025D5595]  DEFAULT ((0.00)) FOR [total]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_re__tasa___035179CE]  DEFAULT ((0.00)) FOR [tasa_retencion]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_re__reten__04459E07]  DEFAULT ((0.00)) FOR [retencion]
GO
ALTER TABLE [dbo].[ventas_retenciones_detalle] ADD  CONSTRAINT [DF__ventas_re__fecha__0539C240]  DEFAULT ('2000-01-01') FOR [fecha_retencion]
GO
ALTER TABLE [dbo].[productos_precios]  WITH CHECK ADD  CONSTRAINT [FK_productos_precios_productos] FOREIGN KEY([producto_id])
REFERENCES [dbo].[productos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[productos_precios] CHECK CONSTRAINT [FK_productos_precios_productos]
GO
ALTER TABLE [dbo].[productos_proveedor]  WITH CHECK ADD  CONSTRAINT [FK_productos_proveedor_productos] FOREIGN KEY([producto_id])
REFERENCES [dbo].[productos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[productos_proveedor] CHECK CONSTRAINT [FK_productos_proveedor_productos]
GO
ALTER TABLE [dbo].[productos_proveedor]  WITH CHECK ADD  CONSTRAINT [FK_productos_proveedor_proveedores] FOREIGN KEY([proveedor_id])
REFERENCES [dbo].[proveedores] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[productos_proveedor] CHECK CONSTRAINT [FK_productos_proveedor_proveedores]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.empresa_agencias' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'agencias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.bancos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bancos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.bancos_movimientos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bancos_movimientos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.bancos_movimientos_medios' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bancos_movimientos_medios'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.bancos_plan_cuentas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bancos_plan_cuentas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.categorias' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'categorias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.clientes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'clientes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.clientes_afiliados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'clientes_afiliados'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.clientes_grupo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'clientes_grupo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.clientes_zonas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'clientes_zonas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.empresa_cobradores' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cobradores'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.compras' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'compras'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.compras_detalle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'compras_detalle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.compras_retenciones' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'compras_retenciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.compras_retenciones_detalle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'compras_retenciones_detalle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.configuracion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'configuracion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cuentas_bancarias' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cuentas_bancarias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.proveedores_agencias' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cuentasbancarias_proveedores'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxc_documentos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxc_documentos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxc_medio_pago' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxc_medio_pago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxc_recibos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxc_recibos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxp_documentos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxp_documentos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxp_medio_pago' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxp_medio_pago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.cxp_recibos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cxp_recibos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.empresa_departamentos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'departamentos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.empresa_depositos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'depositos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.documentos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'documentos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.empresas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'empresas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.marcas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'marcas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.medios_pago' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'medios_pago_cobro'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.periodo_mensual' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'periodo_mensual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.pos_comandas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pos_comandas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.pos_cuentas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pos_cuentas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_conceptos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_conceptos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_costos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_costos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_deposito' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_deposito'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_grupo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_grupo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_kardex' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_kardex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_movimientos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_movimientos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_movimientos_detalle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_movimientos_detalle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_precios' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_precios'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_proveedor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_proveedor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.productos_vencimiento_depositos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'productos_vencimiento_depositos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.proveedores' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'proveedores'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.proveedores_grupo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'proveedores_grupo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.remisiones' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'remisiones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.series_fiscales' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'series_fiscales'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.subcategoria' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'subcategoria'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.tasas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tasas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.empresa_transporte' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'transportes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.unidadesmedidas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'unidadesmedidas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.variantes_productos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'variantes_productos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.ventas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ventas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.ventas_detalle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ventas_detalle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.ventas_guias' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ventas_guias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.ventas_guias_detalle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ventas_guias_detalle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.ventas_retenciones' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ventas_retenciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'`00001`.ventas_retenciones_detalle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ventas_retenciones_detalle'
GO
USE [master]
GO
ALTER DATABASE [00001] SET  READ_WRITE 
GO
