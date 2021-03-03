-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 24-09-2015 a las 17:28:06
-- Versión del servidor: 5.5.16
-- Versión de PHP: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `00001`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `auditoria_accesos`
--

CREATE TABLE IF NOT EXISTS `auditoria_accesos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_id` int(11) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2010-01-01',
  `hora` time NOT NULL,
  `estacion` varchar(20) NOT NULL,
  `ip` varchar(15) NOT NULL,
  `accion` varchar(2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bancos`
--

CREATE TABLE IF NOT EXISTS `bancos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `tipo_cuenta` varchar(25) NOT NULL,
  `numero_cuenta` varchar(25) NOT NULL,
  `ultimo_numero_chq` int(11) NOT NULL,
  `codigo_contable` varchar(20) NOT NULL,
  `saldo` float NOT NULL DEFAULT '0',
  `saldo_conciliado` float NOT NULL DEFAULT '0',
  `lugar` varchar(100) NOT NULL,
  `contacto` varchar(100) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `fax` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `website` varchar(100) NOT NULL,
  `estatus` varchar(10) NOT NULL,
  `fecha_apertura` date NOT NULL DEFAULT '2000-01-01',
  `fecha_conciliacion` date NOT NULL DEFAULT '2000-01-01',
  `fecha_alta` date NOT NULL DEFAULT '2000-00-01',
  `total_debitos` float NOT NULL DEFAULT '0',
  `total_creditos` float NOT NULL DEFAULT '0',
  `titular` varchar(100) NOT NULL,
  `naturaleza_cuenta` varchar(25) NOT NULL,
  `idb` float NOT NULL DEFAULT '0',
  `numero_nota_debito` int(11) NOT NULL DEFAULT '0',
  `numero_nota_credito` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bancos_movimientos`
--

CREATE TABLE IF NOT EXISTS `bancos_movimientos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `banco_id` int(11) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `comprobante` varchar(10) NOT NULL,
  `tipo` varchar(3) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `debe` float NOT NULL DEFAULT '0',
  `haber` float NOT NULL DEFAULT '0',
  `estatus_conciliado` varchar(1) NOT NULL,
  `detalle` varchar(120) NOT NULL,
  `numero_cuenta` varchar(25) NOT NULL,
  `aplica` date NOT NULL DEFAULT '2000-01-01',
  `banco` varchar(60) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `entidad` varchar(80) NOT NULL,
  `ci_rif` varchar(15) NOT NULL,
  `comprobante_egreso` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bancos_movimientos_medios`
--

CREATE TABLE IF NOT EXISTS `bancos_movimientos_medios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `importe` float NOT NULL DEFAULT '0',
  `referencia` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bancos_plan_cuentas`
--

CREATE TABLE IF NOT EXISTS `bancos_plan_cuentas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `clase` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE IF NOT EXISTS `categorias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(45) NOT NULL,
  `nombre` varchar(150) NOT NULL,
  `descripcion` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='	' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE IF NOT EXISTS `clientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parroquia_id` int(11) NOT NULL,
  `vendedor_id` int(11) NOT NULL,
  `grupo_id` int(11) NOT NULL,
  `zona_id` int(11) NOT NULL,
  `cobrador_id` int(11) NOT NULL,
  `agencia_id` int(11) NOT NULL,
  `codigo` varchar(15) NOT NULL,
  `nombre` varchar(80) NOT NULL,
  `ci_rif` varchar(15) NOT NULL,
  `razon_social` varchar(100) NOT NULL,
  `dir_fiscal` varchar(120) NOT NULL,
  `dir_despacho` varchar(120) NOT NULL,
  `contacto` varchar(60) NOT NULL,
  `telefono_cel_cont` varchar(20) DEFAULT NULL,
  `telefono` varchar(20) NOT NULL,
  `celular` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `website` varchar(100) NOT NULL,
  `denominacion_fiscal` varchar(100) NOT NULL,
  `codigo_postal` varchar(10) NOT NULL,
  `retencion_iva` float NOT NULL DEFAULT '0',
  `retencion_islr` float NOT NULL DEFAULT '0',
  `tarifa` varchar(1) NOT NULL,
  `descuento` float NOT NULL DEFAULT '0',
  `recargo` float NOT NULL DEFAULT '0',
  `estatus_credito` tinyint(1) NOT NULL,
  `dias_credito` int(11) NOT NULL DEFAULT '0',
  `limite_credito` float NOT NULL DEFAULT '0',
  `doc_pendientes` int(11) NOT NULL DEFAULT '0',
  `estatus_morosidad` tinyint(1) NOT NULL,
  `estatus_lunes` tinyint(1) NOT NULL,
  `estatus_martes` tinyint(1) NOT NULL,
  `estatus_miercoles` tinyint(1) NOT NULL,
  `estatus_jueves` tinyint(1) NOT NULL,
  `estatus_viernes` tinyint(1) NOT NULL,
  `estatus_sabado` tinyint(1) NOT NULL,
  `estatus_domingo` tinyint(1) NOT NULL,
  `fecha_alta` date NOT NULL DEFAULT '2000-01-01',
  `fecha_baja` date NOT NULL DEFAULT '2000-01-01',
  `fecha_ult_venta` date NOT NULL DEFAULT '2000-01-01',
  `fecha_ult_pago` date NOT NULL DEFAULT '2000-01-01',
  `anticipos` float NOT NULL DEFAULT '0',
  `debitos` float NOT NULL DEFAULT '0',
  `creditos` float NOT NULL DEFAULT '0',
  `saldo` float NOT NULL DEFAULT '0',
  `disponible` float NOT NULL DEFAULT '0',
  `memo` text NOT NULL,
  `aviso` varchar(60) NOT NULL,
  `estatus` varchar(10) NOT NULL,
  `cuenta` varchar(30) NOT NULL,
  `iban` varchar(15) NOT NULL,
  `swit` varchar(15) NOT NULL,
  `dir_banco` varchar(60) NOT NULL,
  `codigo_cobrar` varchar(15) NOT NULL,
  `codigo_ingresos` varchar(15) NOT NULL,
  `codigo_anticipos` varchar(15) NOT NULL,
  `categoria` varchar(15) NOT NULL,
  `descuento_pronto_pago` float NOT NULL DEFAULT '0',
  `importe_ult_pago` float NOT NULL DEFAULT '0',
  `importe_ult_venta` float NOT NULL DEFAULT '0',
  `telefono2` varchar(20) NOT NULL,
  `fax` varchar(20) NOT NULL,
  `imagen` varchar(150) NOT NULL,
  `registro` varchar(150) DEFAULT NULL,
  `tomo` varchar(20) DEFAULT NULL,
  `hoja` varchar(20) DEFAULT NULL,
  `folio` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes_afiliados`
--

CREATE TABLE IF NOT EXISTS `clientes_afiliados` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` int(11) NOT NULL,
  `ci_titular` varchar(15) NOT NULL,
  `ci_beneficiario` varchar(15) NOT NULL,
  `nombre_titular` varchar(80) NOT NULL,
  `nombre_beneficiario` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes_grupo`
--

CREATE TABLE IF NOT EXISTS `clientes_grupo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes_zonas`
--

CREATE TABLE IF NOT EXISTS `clientes_zonas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras`
--

CREATE TABLE IF NOT EXISTS `compras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tasa1` float NOT NULL DEFAULT '0',
  `tasa2` float NOT NULL DEFAULT '0',
  `tasa3` float NOT NULL DEFAULT '0',
  `tasa_retencion_iva` float NOT NULL DEFAULT '0',
  `tasa_retencion_islr` float NOT NULL DEFAULT '0',
  `usuario_id` int(11) NOT NULL,
  `sucursal_id` int(11) NOT NULL,
  `proveedor_id` int(11) NOT NULL,
  `remision_id` int(11) NOT NULL,
  `cxp_id` int(11) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `fecha_vencimiento` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base1` float NOT NULL DEFAULT '0',
  `base2` float NOT NULL DEFAULT '0',
  `base3` float NOT NULL DEFAULT '0',
  `impuesto1` float NOT NULL DEFAULT '0',
  `impuesto2` float NOT NULL DEFAULT '0',
  `impuesto3` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `nota` varchar(200) NOT NULL,
  `retencion_iva` float NOT NULL DEFAULT '0',
  `retencion_islr` float NOT NULL DEFAULT '0',
  `mes_relacion` varchar(2) NOT NULL,
  `control` varchar(10) NOT NULL,
  `fecha_registro` date NOT NULL DEFAULT '2000-01-01',
  `orden_compra` varchar(10) NOT NULL,
  `dias` int(11) NOT NULL DEFAULT '0',
  `descuento1` float NOT NULL DEFAULT '0',
  `descuento2` float NOT NULL DEFAULT '0',
  `cargos` float NOT NULL DEFAULT '0',
  `descuento1p` float NOT NULL DEFAULT '0',
  `descuento2p` float NOT NULL DEFAULT '0',
  `cargosp` float NOT NULL DEFAULT '0',
  `columna` varchar(1) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `aplica` varchar(10) NOT NULL,
  `comprobante_retencion` varchar(14) NOT NULL,
  `subtotal_neto` float NOT NULL DEFAULT '0',
  `telefono` varchar(60) NOT NULL,
  `factor_cambio` float NOT NULL DEFAULT '000',
  `condicion_pago` varchar(7) NOT NULL,
  `hora` time NOT NULL,
  `monto_divisa` float NOT NULL DEFAULT '0',
  `estacion` varchar(20) NOT NULL,
  `renglones` int(11) NOT NULL DEFAULT '0',
  `saldo_pendiente` float NOT NULL DEFAULT '0',
  `ano_relacion` varchar(4) NOT NULL,
  `comprobante_retencion_islr` varchar(10) NOT NULL,
  `dias_validez` int(11) NOT NULL DEFAULT '0',
  `situacion` varchar(10) NOT NULL,
  `signo` int(11) NOT NULL DEFAULT '0',
  `serie` varchar(3) NOT NULL,
  `tarifa` varchar(1) NOT NULL,
  `documento_nombre` varchar(16) NOT NULL,
  `subtotal_impuesto` float NOT NULL DEFAULT '0',
  `subtotal` float NOT NULL DEFAULT '0',
  `tipo_proveedor` varchar(2) NOT NULL,
  `planilla` varchar(15) NOT NULL,
  `expediente` varchar(15) NOT NULL,
  `anticipo_iva` float NOT NULL DEFAULT '0',
  `terceros_iva` float NOT NULL DEFAULT '0',
  `neto` float NOT NULL DEFAULT '0',
  `costo` float NOT NULL DEFAULT '0',
  `utilidad` float NOT NULL DEFAULT '0',
  `utilidadp` float NOT NULL DEFAULT '0',
  `documento_tipo` varchar(10) NOT NULL,
  `denominacion_fiscal` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras_detalle`
--

CREATE TABLE IF NOT EXISTS `compras_detalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` int(11) NOT NULL,
  `compra_id` int(11) NOT NULL,
  `proveedor_id` int(11) NOT NULL,
  `descuento1p` float NOT NULL DEFAULT '0',
  `descuento2p` float NOT NULL DEFAULT '0',
  `descuento3p` float NOT NULL DEFAULT '0',
  `descuento1` float NOT NULL DEFAULT '0',
  `descuento2` float NOT NULL DEFAULT '0',
  `descuento3` float NOT NULL DEFAULT '0',
  `total_neto` float NOT NULL DEFAULT '0',
  `tasa` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `estatus_anulado` tinyint(1) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `signo` int(11) NOT NULL DEFAULT '0',
  `decimales` varchar(1) NOT NULL,
  `contenido_empaque` int(11) NOT NULL DEFAULT '0',
  `cantidad_und` float NOT NULL DEFAULT '00',
  `costo_und` float NOT NULL DEFAULT '0',
  `costo_promedio_und` float NOT NULL DEFAULT '0',
  `costo_compra` float NOT NULL DEFAULT '0',
  `cantidad_bono` float NOT NULL DEFAULT '00',
  `costo_bruto` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras_retenciones`
--

CREATE TABLE IF NOT EXISTS `compras_retenciones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `proveedor_id` int(11) NOT NULL,
  `documento` varchar(14) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `tasa_retencion` float NOT NULL DEFAULT '0',
  `retencion` float NOT NULL DEFAULT '0',
  `fecha_relacion` date NOT NULL DEFAULT '2000-01-01',
  `ano_relacion` varchar(4) NOT NULL,
  `mes_relacion` varchar(2) NOT NULL,
  `renglones` int(11) NOT NULL DEFAULT '0',
  `documento_nombre` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras_retenciones_detalle`
--

CREATE TABLE IF NOT EXISTS `compras_retenciones_detalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `compras_retenciones_id` int(11) NOT NULL,
  `documento` varchar(14) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `tasa_retencion` float NOT NULL DEFAULT '0',
  `retencion` float NOT NULL DEFAULT '0',
  `fecha_retencion` date NOT NULL DEFAULT '2000-01-01',
  `comprobante` varchar(14) NOT NULL,
  `tipo_retencion` varchar(2) NOT NULL,
  `aplica` varchar(10) NOT NULL,
  `control` varchar(10) NOT NULL,
  `tasa_id` int(11) NOT NULL,
  `signo` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `configuracion`
--

CREATE TABLE IF NOT EXISTS `configuracion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_id` int(11) NOT NULL,
  `modulo_id` int(11) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `operacion` varchar(60) NOT NULL,
  `valor` varchar(100) NOT NULL,
  `defecto` varchar(60) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxc`
--

CREATE TABLE IF NOT EXISTS `cxc` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `documento_id` int(11) NOT NULL,
  `agencia_id` int(11) NOT NULL,
  `vendedor_id` int(11) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `c_cobranza` float NOT NULL DEFAULT '0',
  `c_cobranzap` float NOT NULL DEFAULT '0',
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo_documento` varchar(3) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `fecha_vencimiento` date NOT NULL DEFAULT '2000-01-01',
  `nota` varchar(200) NOT NULL,
  `importe` float NOT NULL DEFAULT '0',
  `acumulado` float NOT NULL DEFAULT '0',
  `estatus_cancelado` tinyint(1) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `resta` float NOT NULL DEFAULT '0',
  `numero` varchar(10) NOT NULL,
  `signo` int(11) NOT NULL DEFAULT '0',
  `c_departamento` float NOT NULL DEFAULT '0',
  `c_ventas` float NOT NULL DEFAULT '0',
  `c_ventasp` float NOT NULL DEFAULT '0',
  `serie` varchar(3) NOT NULL,
  `importe_neto` float NOT NULL DEFAULT '0',
  `dias` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxc_documentos`
--

CREATE TABLE IF NOT EXISTS `cxc_documentos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cxc_id` int(11) NOT NULL,
  `cxc_pago_id` int(11) NOT NULL,
  `cxc_recibo_id` int(11) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo_documento` varchar(3) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `importe` float NOT NULL DEFAULT '0',
  `operacion` varchar(5) NOT NULL,
  `numero_recibo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxc_medio_pago`
--

CREATE TABLE IF NOT EXISTS `cxc_medio_pago` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `recibo_id` int(11) NOT NULL,
  `agencia_id` int(11) NOT NULL,
  `medio` varchar(20) NOT NULL,
  `codigo` varchar(2) NOT NULL,
  `monto_recibido` float NOT NULL DEFAULT '0',
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `estatus_anulado` tinyint(1) NOT NULL,
  `numero` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxc_recibos`
--

CREATE TABLE IF NOT EXISTS `cxc_recibos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` varchar(10) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `cobrador_id` int(11) NOT NULL,
  `cxc_id` int(11) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `importe` float NOT NULL DEFAULT '0',
  `monto_recibido` float NOT NULL DEFAULT '0',
  `codigo` varchar(15) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `anticipos` float NOT NULL DEFAULT '0',
  `cambio` float NOT NULL DEFAULT '0',
  `nota` varchar(200) NOT NULL,
  `retenciones` float NOT NULL DEFAULT '0',
  `descuentos` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxp`
--

CREATE TABLE IF NOT EXISTS `cxp` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `agencia_id` int(11) NOT NULL,
  `documento_id` int(11) NOT NULL,
  `proveedor_id` int(11) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo_documento` varchar(3) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `nota` varchar(200) NOT NULL,
  `estatus_cancelado` tinyint(1) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `numero` varchar(10) NOT NULL,
  `dias` int(11) NOT NULL DEFAULT '0',
  `signo` int(11) NOT NULL DEFAULT '0',
  `monto_recibido` float NOT NULL DEFAULT '0',
  `comisionp` float NOT NULL DEFAULT '0',
  `base_comision` float NOT NULL DEFAULT '0',
  `importe` float NOT NULL DEFAULT '0',
  `acumulado` float NOT NULL DEFAULT '0',
  `castigop` float NOT NULL DEFAULT '0',
  `resta` float NOT NULL DEFAULT '0',
  `fecha_vencimiento` date NOT NULL DEFAULT '2000-01-01',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxp_documentos`
--

CREATE TABLE IF NOT EXISTS `cxp_documentos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cxp_id` int(11) NOT NULL,
  `cxp_pago_id` int(11) NOT NULL,
  `cxp_recibo_id` int(11) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo_documento` varchar(3) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `importe` float NOT NULL DEFAULT '0',
  `operacion` varchar(5) NOT NULL,
  `numero_recibo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxp_medio_pago`
--

CREATE TABLE IF NOT EXISTS `cxp_medio_pago` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `medio_pago_id` int(11) NOT NULL,
  `agencia_id` int(11) NOT NULL,
  `medio` varchar(20) NOT NULL,
  `codigo` varchar(2) NOT NULL,
  `monto_recibido` float NOT NULL DEFAULT '0',
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `estatus_anulado` tinyint(1) NOT NULL,
  `numero` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cxp_recibos`
--

CREATE TABLE IF NOT EXISTS `cxp_recibos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cxp_id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `importe` float NOT NULL DEFAULT '0',
  `monto_recibido` float NOT NULL DEFAULT '0',
  `estatus_anulado` tinyint(1) NOT NULL,
  `anticipos` float NOT NULL DEFAULT '0',
  `cambio` float NOT NULL DEFAULT '0',
  `nota` varchar(120) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `documentos`
--

CREATE TABLE IF NOT EXISTS `documentos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(20) NOT NULL,
  `nombre` varchar(40) NOT NULL,
  `codigo` varchar(2) NOT NULL,
  `signo` int(11) NOT NULL,
  `siglas` varchar(3) NOT NULL,
  `comando` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=30 ;

--
-- Volcado de datos para la tabla `documentos`
--

INSERT INTO `documentos` (`id`, `tipo`, `nombre`, `codigo`, `signo`, `siglas`, `comando`) VALUES
(1, 'Ventas', 'VENTA', '01', 1, 'FAC', 'ven_factura.lrf'),
(2, 'Ventas', 'NOTA DEBITO', '02', 1, 'NDB', 'ven_nota_debito.lrf'),
(3, 'Ventas', 'NOTA CREDITO', '03', -1, 'NCR', 'ven_nota_credito.lrf'),
(4, 'Ventas', 'NOTA ENTREGA', '04', 1, 'NEN', 'ven_nota_entrega.lrf'),
(5, 'Ventas', 'PRESUPUESTO', '05', 1, 'PRE', 'ven_presupuesto.lrf'),
(6, 'Ventas', 'PEDIDO', '06', 1, 'PED', 'ven_pedido.lrf'),
(7, 'CXC', 'RECIBO DE PAGO CLIENTES', '01', -1, 'PAG', 'cxc_recibo.lrf'),
(8, 'CXC', 'FACTURA POR COBRAR CLIENTE', '02', 1, 'FAC', ''),
(9, 'CXC', 'NOTA DE DEBITO ADMINISTRATIVA CLIENTES', '03', 1, 'NDB', 'cxc_nota_debito.lrf'),
(10, 'CXC', 'NOTA DE CREDITO ADMINISTRATIVA CLIENTES', '04', -1, 'NCR', 'cxc_nota_credito.lrf'),
(11, 'CXC', 'CHEQUE DEVUELTO CLIENTE', '05', 1, 'CHD', 'cxc_cheque_devuelto.lrf'),
(12, 'CXC', 'ANTICIPO CLIENTE', '06', -1, 'ANT', 'cxc_recibo.lrf'),
(13, 'CXP', 'RECIBO DE PAGO PROVEEDOR', '01', -1, 'PAG', 'cxp_recibo.lrf'),
(14, 'CXP', 'FACTURA POR PAGAR PROVEEDORES', '02', 1, 'FAC', ''),
(15, 'CXP', 'NOTA DE DEBITO ADMINISTRATIVA PROVEEDORE', '03', 1, 'NDB', 'cxp_nota_debito.lrf'),
(16, 'CXP', 'NOTA DE CREDITO ADMINISTRATIVA PROVEEDOR', '04', -1, 'NCR', 'cxp_nota_credito.lrf'),
(17, 'CXP', 'CHEQUE DEVUELTO PROVEEDOR', '05', 1, 'CHD', 'cxp_cheque_devuelto.lrf'),
(18, 'CXP', 'ANTICIPO PROVEEDOR', '06', -1, 'ANT', 'cxp_recibo.lrf'),
(19, 'Compras', 'COMPRAS', '01', 1, 'FAC', 'com_factura.lrf'),
(20, 'Compras', 'NOTA DEBITO', '02', 1, 'NDB', 'com_nota_debito.lrf'),
(21, 'Compras', 'NOTA CREDITO', '03', -1, 'NCR', 'com_nota_credito.lrf'),
(22, 'Ventas', 'RETENCION IVA', '07', 1, '', 'ven_retencion_iva.lrf'),
(23, 'Ventas', 'RETENCION ISLR', '08', 1, '', 'ven_retencion_islr.lrf'),
(24, 'Inventario', 'CARGOS', '01', 1, 'CAR', 'inv_movimiento.lrf'),
(25, 'Inventario', 'DESCARGOS', '02', -1, 'DES', 'inv_movimiento.lrf'),
(26, 'Inventario', 'TRANSFERENCIA', '03', 1, 'TRA', 'inv_movimiento.lrf'),
(27, 'Compras', 'ORDEN COMPRA', '04', 1, 'ORD', 'com_orden_compra.lrf'),
(28, 'Compras', 'RETENCION IVA', '07', 1, '', 'com_retencion_iva.lrf'),
(29, 'Compras', 'RETENCION ISLR', '08', 1, '', 'com_retencion_islr.lrf');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresas`
--

CREATE TABLE IF NOT EXISTS `empresas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parroquia_id` int(11) NOT NULL,
  `nombre` varchar(120) NOT NULL,
  `direccion` varchar(120) NOT NULL,
  `denominacion_social` varchar(150) NOT NULL,
  `rif` varchar(15) NOT NULL,
  `telefono` varchar(60) NOT NULL,
  `telefonocel` varchar(45) NOT NULL,
  `sucursal` varchar(60) NOT NULL,
  `codigo_sucursal` varchar(60) NOT NULL,
  `contacto` varchar(60) NOT NULL,
  `telefonocontacto` varchar(45) NOT NULL,
  `fax` varchar(60) NOT NULL,
  `email` varchar(100) NOT NULL,
  `website` varchar(100) NOT NULL,
  `registro` varchar(100) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `ciudad` varchar(100) NOT NULL,
  `codigo_postal` varchar(10) NOT NULL,
  `retencion_iva` float NOT NULL DEFAULT '0',
  `retencion_islr` float NOT NULL DEFAULT '0',
  `factor_cambio` float NOT NULL DEFAULT '0',
  `debito_bancario` float NOT NULL DEFAULT '0',
  `imagen` text NOT NULL,
  `tomo` varchar(45) NOT NULL,
  `hoja` varchar(50) NOT NULL,
  `folio` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Volcado de datos para la tabla `empresas`
--

INSERT INTO `empresas` (`id`, `parroquia_id`, `nombre`, `direccion`, `denominacion_social`, `rif`, `telefono`, `telefonocel`, `sucursal`, `codigo_sucursal`, `contacto`, `telefonocontacto`, `fax`, `email`, `website`, `registro`, `codigo`, `ciudad`, `codigo_postal`, `retencion_iva`, `retencion_islr`, `factor_cambio`, `debito_bancario`, `imagen`, `tomo`, `hoja`, `folio`) VALUES
(1, 100, 'demo', 'demo', 'demo', 'J-123456789', '2443227817', '4127796533', 'unica', '0001', 'yoel duran', '4127796533', '', 'yoelduran25@gmail.com', 'jesystems.com.ve', '0002', '00001', 'la victoria', '2121', 12.00, 8.00, 1.00, 12.00, '', '', '', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa_agencias`
--

CREATE TABLE IF NOT EXISTS `empresa_agencias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) NOT NULL,
  `direccion` text NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa_cobradores`
--

CREATE TABLE IF NOT EXISTS `empresa_cobradores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `ci_rif` varchar(15) NOT NULL,
  `direccion` text NOT NULL,
  `comision` float NOT NULL DEFAULT '0',
  `contrato` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa_departamentos`
--

CREATE TABLE IF NOT EXISTS `empresa_departamentos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `comision_g` float NOT NULL DEFAULT '0',
  `comision_1` float NOT NULL DEFAULT '0',
  `comision_2` float NOT NULL DEFAULT '0',
  `comision_3` float NOT NULL DEFAULT '0',
  `comision_4` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa_depositos`
--

CREATE TABLE IF NOT EXISTS `empresa_depositos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa_transporte`
--

CREATE TABLE IF NOT EXISTS `empresa_transporte` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `contrato` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estados`
--

CREATE TABLE IF NOT EXISTS `estados` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pais_id` int(11) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `iso_3166-2` varchar(4) NOT NULL,
  `cod_ine` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=26 ;

--
-- Volcado de datos para la tabla `estados`
--

INSERT INTO `estados` (`id`, `pais_id`, `nombre`, `iso_3166-2`, `cod_ine`) VALUES
(1, 232, 'Amazonas', 'VE-X', '2'),
(2, 232, 'Anzoategui', 'VE-B', '1'),
(3, 232, 'Apure', 'VE-C', '3'),
(4, 232, 'Aragua', 'VE-D', '4'),
(5, 232, 'Barinas', 'VE-E', '5'),
(6, 232, 'Bolivar', 'VE-F', '6'),
(7, 232, 'Carabobo', 'VE-G', '7'),
(8, 232, 'Cojedes', 'VE-H', '8'),
(9, 232, 'Delta Amacuro', 'VE-Y', '9'),
(10, 232, 'Falcon', 'VE-I', '10'),
(11, 232, 'Guarico', 'VE-J', '11'),
(12, 232, 'Lara', 'VE-K', '12'),
(13, 232, 'Merida', 'VE-L', '13'),
(14, 232, 'Miranda', 'VE-M', '14'),
(15, 232, 'Monagas', 'VE-N', '15'),
(16, 232, 'Nueva Esparta', 'VE-O', '16'),
(17, 232, 'Portuguesa', 'VE-P', '17'),
(18, 232, 'Sucre', 'VE-R', '18'),
(19, 232, 'Tachira', 'VE-S', '19'),
(20, 232, 'Trujillo', 'VE-T', '20'),
(21, 232, 'Vargas', 'VE-W', '22'),
(22, 232, 'Yaracuy', 'VE-U', '21'),
(23, 232, 'Zulia', 'VE-V', '23'),
(24, 232, 'Distrito Capital', 'VE-A', 'DF'),
(25, 232, 'Dependencias Federales', 'VE-Z', 'DF');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `medios_pago`
--

CREATE TABLE IF NOT EXISTS `medios_pago` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `estatus_cobro` tinyint(1) NOT NULL,
  `estatus_pago` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `municipios`
--

CREATE TABLE IF NOT EXISTS `municipios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `estado_id` int(11) NOT NULL,
  `municipio` varchar(100) CHARACTER SET utf8 COLLATE utf8_spanish_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=336 ;

--
-- Volcado de datos para la tabla `municipios`
--

INSERT INTO `municipios` (`id`, `estado_id`, `municipio`) VALUES
(1, 1, 'Alto Orinoco'),
(2, 1, 'Atabapo'),
(3, 1, 'Atures'),
(4, 1, 'Autana'),
(5, 1, 'Manapiare'),
(6, 1, 'Maroa'),
(7, 1, 'Río Negro'),
(8, 2, 'Anaco'),
(9, 2, 'Aragua'),
(10, 2, 'Manuel Ezequiel Bruzual'),
(11, 2, 'Diego Bautista Urbaneja'),
(12, 2, 'Fernando Peñalver'),
(13, 2, 'Francisco Del Carmen Carvajal'),
(14, 2, 'General Sir Arthur McGregor'),
(15, 2, 'Guanta'),
(16, 2, 'Independencia'),
(17, 2, 'José Gregorio Monagas'),
(18, 2, 'Juan Antonio Sotillo'),
(19, 2, 'Juan Manuel Cajigal'),
(20, 2, 'Libertad'),
(21, 2, 'Francisco de Miranda'),
(22, 2, 'Pedro María Freites'),
(23, 2, 'Píritu'),
(24, 2, 'San José de Guanipa'),
(25, 2, 'San Juan de Capistrano'),
(26, 2, 'Santa Ana'),
(27, 2, 'Simón Bolívar'),
(28, 2, 'Simón Rodríguez'),
(29, 3, 'Achaguas'),
(30, 3, 'Biruaca'),
(31, 3, 'Muñóz'),
(32, 3, 'Páez'),
(33, 3, 'Pedro Camejo'),
(34, 3, 'Rómulo Gallegos'),
(35, 3, 'San Fernando'),
(36, 4, 'Atanasio Girardot'),
(37, 4, 'Bolívar'),
(38, 4, 'Camatagua'),
(39, 4, 'Francisco Linares Alcántara'),
(40, 4, 'José Ángel Lamas'),
(41, 4, 'José Félix Ribas'),
(42, 4, 'José Rafael Revenga'),
(43, 4, 'Libertador'),
(44, 4, 'Mario Briceño Iragorry'),
(45, 4, 'Ocumare de la Costa de Oro'),
(46, 4, 'San Casimiro'),
(47, 4, 'San Sebastián'),
(48, 4, 'Santiago Mariño'),
(49, 4, 'Santos Michelena'),
(50, 4, 'Sucre'),
(51, 4, 'Tovar'),
(52, 4, 'Urdaneta'),
(53, 4, 'Zamora'),
(54, 5, 'Alberto Arvelo Torrealba'),
(55, 5, 'Andrés Eloy Blanco'),
(56, 5, 'Antonio José de Sucre'),
(57, 5, 'Arismendi'),
(58, 5, 'Barinas'),
(59, 5, 'Bolívar'),
(60, 5, 'Cruz Paredes'),
(61, 5, 'Ezequiel Zamora'),
(62, 5, 'Obispos'),
(63, 5, 'Pedraza'),
(64, 5, 'Rojas'),
(65, 5, 'Sosa'),
(66, 6, 'Caroní'),
(67, 6, 'Cedeño'),
(68, 6, 'El Callao'),
(69, 6, 'Gran Sabana'),
(70, 6, 'Heres'),
(71, 6, 'Piar'),
(72, 6, 'Angostura (Raúl Leoni)'),
(73, 6, 'Roscio'),
(74, 6, 'Sifontes'),
(75, 6, 'Sucre'),
(76, 6, 'Padre Pedro Chien'),
(77, 7, 'Bejuma'),
(78, 7, 'Carlos Arvelo'),
(79, 7, 'Diego Ibarra'),
(80, 7, 'Guacara'),
(81, 7, 'Juan José Mora'),
(82, 7, 'Libertador'),
(83, 7, 'Los Guayos'),
(84, 7, 'Miranda'),
(85, 7, 'Montalbán'),
(86, 7, 'Naguanagua'),
(87, 7, 'Puerto Cabello'),
(88, 7, 'San Diego'),
(89, 7, 'San Joaquín'),
(90, 7, 'Valencia'),
(91, 8, 'Anzoátegui'),
(92, 8, 'Tinaquillo'),
(93, 8, 'Girardot'),
(94, 8, 'Lima Blanco'),
(95, 8, 'Pao de San Juan Bautista'),
(96, 8, 'Ricaurte'),
(97, 8, 'Rómulo Gallegos'),
(98, 8, 'San Carlos'),
(99, 8, 'Tinaco'),
(100, 9, 'Antonio Díaz'),
(101, 9, 'Casacoima'),
(102, 9, 'Pedernales'),
(103, 9, 'Tucupita'),
(104, 10, 'Acosta'),
(105, 10, 'Bolívar'),
(106, 10, 'Buchivacoa'),
(107, 10, 'Cacique Manaure'),
(108, 10, 'Carirubana'),
(109, 10, 'Colina'),
(110, 10, 'Dabajuro'),
(111, 10, 'Democracia'),
(112, 10, 'Falcón'),
(113, 10, 'Federación'),
(114, 10, 'Jacura'),
(115, 10, 'José Laurencio Silva'),
(116, 10, 'Los Taques'),
(117, 10, 'Mauroa'),
(118, 10, 'Miranda'),
(119, 10, 'Monseñor Iturriza'),
(120, 10, 'Palmasola'),
(121, 10, 'Petit'),
(122, 10, 'Píritu'),
(123, 10, 'San Francisco'),
(124, 10, 'Sucre'),
(125, 10, 'Tocópero'),
(126, 10, 'Unión'),
(127, 10, 'Urumaco'),
(128, 10, 'Zamora'),
(129, 11, 'Camaguán'),
(130, 11, 'Chaguaramas'),
(131, 11, 'El Socorro'),
(132, 11, 'José Félix Ribas'),
(133, 11, 'José Tadeo Monagas'),
(134, 11, 'Juan Germán Roscio'),
(135, 11, 'Julián Mellado'),
(136, 11, 'Las Mercedes'),
(137, 11, 'Leonardo Infante'),
(138, 11, 'Pedro Zaraza'),
(139, 11, 'Ortíz'),
(140, 11, 'San Gerónimo de Guayabal'),
(141, 11, 'San José de Guaribe'),
(142, 11, 'Santa María de Ipire'),
(143, 11, 'Sebastián Francisco de Miranda'),
(144, 12, 'Andrés Eloy Blanco'),
(145, 12, 'Crespo'),
(146, 12, 'Iribarren'),
(147, 12, 'Jiménez'),
(148, 12, 'Morán'),
(149, 12, 'Palavecino'),
(150, 12, 'Simón Planas'),
(151, 12, 'Torres'),
(152, 12, 'Urdaneta'),
(153, 13, 'Alberto Adriani'),
(154, 13, 'Andrés Bello'),
(155, 13, 'Antonio Pinto Salinas'),
(156, 13, 'Aricagua'),
(157, 13, 'Arzobispo Chacón'),
(158, 13, 'Campo Elías'),
(159, 13, 'Caracciolo Parra Olmedo'),
(160, 13, 'Cardenal Quintero'),
(161, 13, 'Guaraque'),
(162, 13, 'Julio César Salas'),
(163, 13, 'Justo Briceño'),
(164, 13, 'Libertador'),
(165, 13, 'Miranda'),
(166, 13, 'Obispo Ramos de Lora'),
(167, 13, 'Padre Noguera'),
(168, 13, 'Pueblo Llano'),
(169, 13, 'Rangel'),
(170, 13, 'Rivas Dávila'),
(171, 13, 'Santos Marquina'),
(172, 13, 'Sucre'),
(173, 13, 'Tovar'),
(174, 13, 'Tulio Febres Cordero'),
(175, 13, 'Zea'),
(176, 14, 'Acevedo'),
(177, 14, 'Andrés Bello'),
(178, 14, 'Baruta'),
(179, 14, 'Brión'),
(180, 14, 'Buroz'),
(181, 14, 'Carrizal'),
(182, 14, 'Chacao'),
(183, 14, 'Cristóbal Rojas'),
(184, 14, 'El Hatillo'),
(185, 14, 'Guaicaipuro'),
(186, 14, 'Independencia'),
(187, 14, 'Lander'),
(188, 14, 'Los Salias'),
(189, 14, 'Páez'),
(190, 14, 'Paz Castillo'),
(191, 14, 'Pedro Gual'),
(192, 14, 'Plaza'),
(193, 14, 'Simón Bolívar'),
(194, 14, 'Sucre'),
(195, 14, 'Urdaneta'),
(196, 14, 'Zamora'),
(197, 15, 'Acosta'),
(198, 15, 'Aguasay'),
(199, 15, 'Bolívar'),
(200, 15, 'Caripe'),
(201, 15, 'Cedeño'),
(202, 15, 'Ezequiel Zamora'),
(203, 15, 'Libertador'),
(204, 15, 'Maturín'),
(205, 15, 'Piar'),
(206, 15, 'Punceres'),
(207, 15, 'Santa Bárbara'),
(208, 15, 'Sotillo'),
(209, 15, 'Uracoa'),
(210, 16, 'Antolín del Campo'),
(211, 16, 'Arismendi'),
(212, 16, 'García'),
(213, 16, 'Gómez'),
(214, 16, 'Maneiro'),
(215, 16, 'Marcano'),
(216, 16, 'Mariño'),
(217, 16, 'Península de Macanao'),
(218, 16, 'Tubores'),
(219, 16, 'Villalba'),
(220, 16, 'Díaz'),
(221, 17, 'Agua Blanca'),
(222, 17, 'Araure'),
(223, 17, 'Esteller'),
(224, 17, 'Guanare'),
(225, 17, 'Guanarito'),
(226, 17, 'Monseñor José Vicente de Unda'),
(227, 17, 'Ospino'),
(228, 17, 'Páez'),
(229, 17, 'Papelón'),
(230, 17, 'San Genaro de Boconoíto'),
(231, 17, 'San Rafael de Onoto'),
(232, 17, 'Santa Rosalía'),
(233, 17, 'Sucre'),
(234, 17, 'Turén'),
(235, 18, 'Andrés Eloy Blanco'),
(236, 18, 'Andrés Mata'),
(237, 18, 'Arismendi'),
(238, 18, 'Benítez'),
(239, 18, 'Bermúdez'),
(240, 18, 'Bolívar'),
(241, 18, 'Cajigal'),
(242, 18, 'Cruz Salmerón Acosta'),
(243, 18, 'Libertador'),
(244, 18, 'Mariño'),
(245, 18, 'Mejía'),
(246, 18, 'Montes'),
(247, 18, 'Ribero'),
(248, 18, 'Sucre'),
(249, 18, 'Valdéz'),
(250, 19, 'Andrés Bello'),
(251, 19, 'Antonio Rómulo Costa'),
(252, 19, 'Ayacucho'),
(253, 19, 'Bolívar'),
(254, 19, 'Cárdenas'),
(255, 19, 'Córdoba'),
(256, 19, 'Fernández Feo'),
(257, 19, 'Francisco de Miranda'),
(258, 19, 'García de Hevia'),
(259, 19, 'Guásimos'),
(260, 19, 'Independencia'),
(261, 19, 'Jáuregui'),
(262, 19, 'José María Vargas'),
(263, 19, 'Junín'),
(264, 19, 'Libertad'),
(265, 19, 'Libertador'),
(266, 19, 'Lobatera'),
(267, 19, 'Michelena'),
(268, 19, 'Panamericano'),
(269, 19, 'Pedro María Ureña'),
(270, 19, 'Rafael Urdaneta'),
(271, 19, 'Samuel Darío Maldonado'),
(272, 19, 'San Cristóbal'),
(273, 19, 'Seboruco'),
(274, 19, 'Simón Rodríguez'),
(275, 19, 'Sucre'),
(276, 19, 'Torbes'),
(277, 19, 'Uribante'),
(278, 19, 'San Judas Tadeo'),
(279, 20, 'Andrés Bello'),
(280, 20, 'Boconó'),
(281, 20, 'Bolívar'),
(282, 20, 'Candelaria'),
(283, 20, 'Carache'),
(284, 20, 'Escuque'),
(285, 20, 'José Felipe Márquez Cañizalez'),
(286, 20, 'Juan Vicente Campos Elías'),
(287, 20, 'La Ceiba'),
(288, 20, 'Miranda'),
(289, 20, 'Monte Carmelo'),
(290, 20, 'Motatán'),
(291, 20, 'Pampán'),
(292, 20, 'Pampanito'),
(293, 20, 'Rafael Rangel'),
(294, 20, 'San Rafael de Carvajal'),
(295, 20, 'Sucre'),
(296, 20, 'Trujillo'),
(297, 20, 'Urdaneta'),
(298, 20, 'Valera'),
(299, 21, 'Vargas'),
(300, 22, 'Arístides Bastidas'),
(301, 22, 'Bolívar'),
(302, 22, 'Bruzual'),
(303, 22, 'Cocorote'),
(304, 22, 'Independencia'),
(305, 22, 'José Antonio Páez'),
(306, 22, 'La Trinidad'),
(307, 22, 'Manuel Monge'),
(308, 22, 'Nirgua'),
(309, 22, 'Peña'),
(310, 22, 'San Felipe'),
(311, 22, 'Sucre'),
(312, 22, 'Urachiche'),
(313, 22, 'José Joaquín Veroes'),
(314, 23, 'Almirante Padilla'),
(315, 23, 'Baralt'),
(316, 23, 'Cabimas'),
(317, 23, 'Catatumbo'),
(318, 23, 'Colón'),
(319, 23, 'Francisco Javier Pulgar'),
(320, 23, 'Páez'),
(321, 23, 'Jesús Enrique Losada'),
(322, 23, 'Jesús María Semprún'),
(323, 23, 'La Cañada de Urdaneta'),
(324, 23, 'Lagunillas'),
(325, 23, 'Machiques de Perijá'),
(326, 23, 'Mara'),
(327, 23, 'Maracaibo'),
(328, 23, 'Miranda'),
(329, 23, 'Rosario de Perijá'),
(330, 23, 'San Francisco'),
(331, 23, 'Santa Rita'),
(332, 23, 'Simón Bolívar'),
(333, 23, 'Sucre'),
(334, 23, 'Valmore Rodríguez'),
(335, 24, 'Libertador');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `paises`
--

CREATE TABLE IF NOT EXISTS `paises` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `iso` char(2) DEFAULT NULL,
  `nombre` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=241 ;

--
-- Volcado de datos para la tabla `paises`
--

INSERT INTO `paises` (`id`, `iso`, `nombre`) VALUES
(1, 'AF', 'Afganistán'),
(2, 'AX', 'Islas Gland'),
(3, 'AL', 'Albania'),
(4, 'DE', 'Alemania'),
(5, 'AD', 'Andorra'),
(6, 'AO', 'Angola'),
(7, 'AI', 'Anguilla'),
(8, 'AQ', 'Antártida'),
(9, 'AG', 'Antigua y Barbuda'),
(10, 'AN', 'Antillas Holandesas'),
(11, 'SA', 'Arabia Saudí'),
(12, 'DZ', 'Argelia'),
(13, 'AR', 'Argentina'),
(14, 'AM', 'Armenia'),
(15, 'AW', 'Aruba'),
(16, 'AU', 'Australia'),
(17, 'AT', 'Austria'),
(18, 'AZ', 'Azerbaiyán'),
(19, 'BS', 'Bahamas'),
(20, 'BH', 'Bahréin'),
(21, 'BD', 'Bangladesh'),
(22, 'BB', 'Barbados'),
(23, 'BY', 'Bielorrusia'),
(24, 'BE', 'Bélgica'),
(25, 'BZ', 'Belice'),
(26, 'BJ', 'Benin'),
(27, 'BM', 'Bermudas'),
(28, 'BT', 'Bhután'),
(29, 'BO', 'Bolivia'),
(30, 'BA', 'Bosnia y Herzegovina'),
(31, 'BW', 'Botsuana'),
(32, 'BV', 'Isla Bouvet'),
(33, 'BR', 'Brasil'),
(34, 'BN', 'Brunéi'),
(35, 'BG', 'Bulgaria'),
(36, 'BF', 'Burkina Faso'),
(37, 'BI', 'Burundi'),
(38, 'CV', 'Cabo Verde'),
(39, 'KY', 'Islas Caimán'),
(40, 'KH', 'Camboya'),
(41, 'CM', 'Camerún'),
(42, 'CA', 'Canadá'),
(43, 'CF', 'República Centroafricana'),
(44, 'TD', 'Chad'),
(45, 'CZ', 'República Checa'),
(46, 'CL', 'Chile'),
(47, 'CN', 'China'),
(48, 'CY', 'Chipre'),
(49, 'CX', 'Isla de Navidad'),
(50, 'VA', 'Ciudad del Vaticano'),
(51, 'CC', 'Islas Cocos'),
(52, 'CO', 'Colombia'),
(53, 'KM', 'Comoras'),
(54, 'CD', 'República Democrática del Congo'),
(55, 'CG', 'Congo'),
(56, 'CK', 'Islas Cook'),
(57, 'KP', 'Corea del Norte'),
(58, 'KR', 'Corea del Sur'),
(59, 'CI', 'Costa de Marfil'),
(60, 'CR', 'Costa Rica'),
(61, 'HR', 'Croacia'),
(62, 'CU', 'Cuba'),
(63, 'DK', 'Dinamarca'),
(64, 'DM', 'Dominica'),
(65, 'DO', 'República Dominicana'),
(66, 'EC', 'Ecuador'),
(67, 'EG', 'Egipto'),
(68, 'SV', 'El Salvador'),
(69, 'AE', 'Emiratos Árabes Unidos'),
(70, 'ER', 'Eritrea'),
(71, 'SK', 'Eslovaquia'),
(72, 'SI', 'Eslovenia'),
(73, 'ES', 'España'),
(74, 'UM', 'Islas ultramarinas de Estados Unidos'),
(75, 'US', 'Estados Unidos'),
(76, 'EE', 'Estonia'),
(77, 'ET', 'Etiopía'),
(78, 'FO', 'Islas Feroe'),
(79, 'PH', 'Filipinas'),
(80, 'FI', 'Finlandia'),
(81, 'FJ', 'Fiyi'),
(82, 'FR', 'Francia'),
(83, 'GA', 'Gabón'),
(84, 'GM', 'Gambia'),
(85, 'GE', 'Georgia'),
(86, 'GS', 'Islas Georgias del Sur y Sandwich del Sur'),
(87, 'GH', 'Ghana'),
(88, 'GI', 'Gibraltar'),
(89, 'GD', 'Granada'),
(90, 'GR', 'Grecia'),
(91, 'GL', 'Groenlandia'),
(92, 'GP', 'Guadalupe'),
(93, 'GU', 'Guam'),
(94, 'GT', 'Guatemala'),
(95, 'GF', 'Guayana Francesa'),
(96, 'GN', 'Guinea'),
(97, 'GQ', 'Guinea Ecuatorial'),
(98, 'GW', 'Guinea-Bissau'),
(99, 'GY', 'Guyana'),
(100, 'HT', 'Haití'),
(101, 'HM', 'Islas Heard y McDonald'),
(102, 'HN', 'Honduras'),
(103, 'HK', 'Hong Kong'),
(104, 'HU', 'Hungría'),
(105, 'IN', 'India'),
(106, 'ID', 'Indonesia'),
(107, 'IR', 'Irán'),
(108, 'IQ', 'Iraq'),
(109, 'IE', 'Irlanda'),
(110, 'IS', 'Islandia'),
(111, 'IL', 'Israel'),
(112, 'IT', 'Italia'),
(113, 'JM', 'Jamaica'),
(114, 'JP', 'Japón'),
(115, 'JO', 'Jordania'),
(116, 'KZ', 'Kazajstán'),
(117, 'KE', 'Kenia'),
(118, 'KG', 'Kirguistán'),
(119, 'KI', 'Kiribati'),
(120, 'KW', 'Kuwait'),
(121, 'LA', 'Laos'),
(122, 'LS', 'Lesotho'),
(123, 'LV', 'Letonia'),
(124, 'LB', 'Líbano'),
(125, 'LR', 'Liberia'),
(126, 'LY', 'Libia'),
(127, 'LI', 'Liechtenstein'),
(128, 'LT', 'Lituania'),
(129, 'LU', 'Luxemburgo'),
(130, 'MO', 'Macao'),
(131, 'MK', 'ARY Macedonia'),
(132, 'MG', 'Madagascar'),
(133, 'MY', 'Malasia'),
(134, 'MW', 'Malawi'),
(135, 'MV', 'Maldivas'),
(136, 'ML', 'Malí'),
(137, 'MT', 'Malta'),
(138, 'FK', 'Islas Malvinas'),
(139, 'MP', 'Islas Marianas del Norte'),
(140, 'MA', 'Marruecos'),
(141, 'MH', 'Islas Marshall'),
(142, 'MQ', 'Martinica'),
(143, 'MU', 'Mauricio'),
(144, 'MR', 'Mauritania'),
(145, 'YT', 'Mayotte'),
(146, 'MX', 'México'),
(147, 'FM', 'Micronesia'),
(148, 'MD', 'Moldavia'),
(149, 'MC', 'Mónaco'),
(150, 'MN', 'Mongolia'),
(151, 'MS', 'Montserrat'),
(152, 'MZ', 'Mozambique'),
(153, 'MM', 'Myanmar'),
(154, 'NA', 'Namibia'),
(155, 'NR', 'Nauru'),
(156, 'NP', 'Nepal'),
(157, 'NI', 'Nicaragua'),
(158, 'NE', 'Níger'),
(159, 'NG', 'Nigeria'),
(160, 'NU', 'Niue'),
(161, 'NF', 'Isla Norfolk'),
(162, 'NO', 'Noruega'),
(163, 'NC', 'Nueva Caledonia'),
(164, 'NZ', 'Nueva Zelanda'),
(165, 'OM', 'Omán'),
(166, 'NL', 'Países Bajos'),
(167, 'PK', 'Pakistán'),
(168, 'PW', 'Palau'),
(169, 'PS', 'Palestina'),
(170, 'PA', 'Panamá'),
(171, 'PG', 'Papúa Nueva Guinea'),
(172, 'PY', 'Paraguay'),
(173, 'PE', 'Perú'),
(174, 'PN', 'Islas Pitcairn'),
(175, 'PF', 'Polinesia Francesa'),
(176, 'PL', 'Polonia'),
(177, 'PT', 'Portugal'),
(178, 'PR', 'Puerto Rico'),
(179, 'QA', 'Qatar'),
(180, 'GB', 'Reino Unido'),
(181, 'RE', 'Reunión'),
(182, 'RW', 'Ruanda'),
(183, 'RO', 'Rumania'),
(184, 'RU', 'Rusia'),
(185, 'EH', 'Sahara Occidental'),
(186, 'SB', 'Islas Salomón'),
(187, 'WS', 'Samoa'),
(188, 'AS', 'Samoa Americana'),
(189, 'KN', 'San Cristóbal y Nevis'),
(190, 'SM', 'San Marino'),
(191, 'PM', 'San Pedro y Miquelón'),
(192, 'VC', 'San Vicente y las Granadinas'),
(193, 'SH', 'Santa Helena'),
(194, 'LC', 'Santa Lucía'),
(195, 'ST', 'Santo Tomé y Príncipe'),
(196, 'SN', 'Senegal'),
(197, 'CS', 'Serbia y Montenegro'),
(198, 'SC', 'Seychelles'),
(199, 'SL', 'Sierra Leona'),
(200, 'SG', 'Singapur'),
(201, 'SY', 'Siria'),
(202, 'SO', 'Somalia'),
(203, 'LK', 'Sri Lanka'),
(204, 'SZ', 'Suazilandia'),
(205, 'ZA', 'Sudáfrica'),
(206, 'SD', 'Sudán'),
(207, 'SE', 'Suecia'),
(208, 'CH', 'Suiza'),
(209, 'SR', 'Surinam'),
(210, 'SJ', 'Svalbard y Jan Mayen'),
(211, 'TH', 'Tailandia'),
(212, 'TW', 'Taiwán'),
(213, 'TZ', 'Tanzania'),
(214, 'TJ', 'Tayikistán'),
(215, 'IO', 'Territorio Británico del Océano Índico'),
(216, 'TF', 'Territorios Australes Franceses'),
(217, 'TL', 'Timor Oriental'),
(218, 'TG', 'Togo'),
(219, 'TK', 'Tokelau'),
(220, 'TO', 'Tonga'),
(221, 'TT', 'Trinidad y Tobago'),
(222, 'TN', 'Túnez'),
(223, 'TC', 'Islas Turcas y Caicos'),
(224, 'TM', 'Turkmenistán'),
(225, 'TR', 'Turquía'),
(226, 'TV', 'Tuvalu'),
(227, 'UA', 'Ucrania'),
(228, 'UG', 'Uganda'),
(229, 'UY', 'Uruguay'),
(230, 'UZ', 'Uzbekistán'),
(231, 'VU', 'Vanuatu'),
(232, 'VE', 'Venezuela'),
(233, 'VN', 'Vietnam'),
(234, 'VG', 'Islas Vírgenes Británicas'),
(235, 'VI', 'Islas Vírgenes de los Estados Unidos'),
(236, 'WF', 'Wallis y Futuna'),
(237, 'YE', 'Yemen'),
(238, 'DJ', 'Yibuti'),
(239, 'ZM', 'Zambia'),
(240, 'ZW', 'Zimbabue');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `parroquias`
--

CREATE TABLE IF NOT EXISTS `parroquias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `municipio_id` int(11) NOT NULL,
  `parroquia` varchar(250) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1139 ;

--
-- Volcado de datos para la tabla `parroquias`
--

INSERT INTO `parroquias` (`id`, `municipio_id`, `parroquia`) VALUES
(1, 1, 'Alto Orinoco'),
(2, 1, 'Huachamacare Acanaña'),
(3, 1, 'Marawaka Toky Shamanaña'),
(4, 1, 'Mavaka Mavaka'),
(5, 1, 'Sierra Parima Parimabé'),
(6, 2, 'Ucata Laja Lisa'),
(7, 2, 'Yapacana Macuruco'),
(8, 2, 'Caname Guarinuma'),
(9, 3, 'Fernando Girón Tovar'),
(10, 3, 'Luis Alberto Gómez'),
(11, 3, 'Pahueña Limón de Parhueña'),
(12, 3, 'Platanillal Platanillal'),
(13, 4, 'Samariapo'),
(14, 4, 'Sipapo'),
(15, 4, 'Munduapo'),
(16, 4, 'Guayapo'),
(17, 5, 'Alto Ventuari'),
(18, 5, 'Medio Ventuari'),
(19, 5, 'Bajo Ventuari'),
(20, 6, 'Victorino'),
(21, 6, 'Comunidad'),
(22, 7, 'Casiquiare'),
(23, 7, 'Cocuy'),
(24, 7, 'San Carlos de Río Negro'),
(25, 7, 'Solano'),
(26, 8, 'Anaco'),
(27, 8, 'San Joaquín'),
(28, 9, 'Cachipo'),
(29, 9, 'Aragua de Barcelona'),
(30, 11, 'Lechería'),
(31, 11, 'El Morro'),
(32, 12, 'Puerto Píritu'),
(33, 12, 'San Miguel'),
(34, 12, 'Sucre'),
(35, 13, 'Valle de Guanape'),
(36, 13, 'Santa Bárbara'),
(37, 14, 'El Chaparro'),
(38, 14, 'Tomás Alfaro'),
(39, 14, 'Calatrava'),
(40, 15, 'Guanta'),
(41, 15, 'Chorrerón'),
(42, 16, 'Mamo'),
(43, 16, 'Soledad'),
(44, 17, 'Mapire'),
(45, 17, 'Piar'),
(46, 17, 'Santa Clara'),
(47, 17, 'San Diego de Cabrutica'),
(48, 17, 'Uverito'),
(49, 17, 'Zuata'),
(50, 18, 'Puerto La Cruz'),
(51, 18, 'Pozuelos'),
(52, 19, 'Onoto'),
(53, 19, 'San Pablo'),
(54, 20, 'San Mateo'),
(55, 20, 'El Carito'),
(56, 20, 'Santa Inés'),
(57, 20, 'La Romereña'),
(58, 21, 'Atapirire'),
(59, 21, 'Boca del Pao'),
(60, 21, 'El Pao'),
(61, 21, 'Pariaguán'),
(62, 22, 'Cantaura'),
(63, 22, 'Libertador'),
(64, 22, 'Santa Rosa'),
(65, 22, 'Urica'),
(66, 23, 'Píritu'),
(67, 23, 'San Francisco'),
(68, 24, 'San José de Guanipa'),
(69, 25, 'Boca de Uchire'),
(70, 25, 'Boca de Chávez'),
(71, 26, 'Pueblo Nuevo'),
(72, 26, 'Santa Ana'),
(73, 27, 'Bergatín'),
(74, 27, 'Caigua'),
(75, 27, 'El Carmen'),
(76, 27, 'El Pilar'),
(77, 27, 'Naricual'),
(78, 27, 'San Crsitóbal'),
(79, 28, 'Edmundo Barrios'),
(80, 28, 'Miguel Otero Silva'),
(81, 29, 'Achaguas'),
(82, 29, 'Apurito'),
(83, 29, 'El Yagual'),
(84, 29, 'Guachara'),
(85, 29, 'Mucuritas'),
(86, 29, 'Queseras del medio'),
(87, 30, 'Biruaca'),
(88, 31, 'Bruzual'),
(89, 31, 'Mantecal'),
(90, 31, 'Quintero'),
(91, 31, 'Rincón Hondo'),
(92, 31, 'San Vicente'),
(93, 32, 'Guasdualito'),
(94, 32, 'Aramendi'),
(95, 32, 'El Amparo'),
(96, 32, 'San Camilo'),
(97, 32, 'Urdaneta'),
(98, 33, 'San Juan de Payara'),
(99, 33, 'Codazzi'),
(100, 33, 'Cunaviche'),
(101, 34, 'Elorza'),
(102, 34, 'La Trinidad'),
(103, 35, 'San Fernando'),
(104, 35, 'El Recreo'),
(105, 35, 'Peñalver'),
(106, 35, 'San Rafael de Atamaica'),
(107, 36, 'Pedro José Ovalles'),
(108, 36, 'Joaquín Crespo'),
(109, 36, 'José Casanova Godoy'),
(110, 36, 'Madre María de San José'),
(111, 36, 'Andrés Eloy Blanco'),
(112, 36, 'Los Tacarigua'),
(113, 36, 'Las Delicias'),
(114, 36, 'Choroní'),
(115, 37, 'Bolívar'),
(116, 38, 'Camatagua'),
(117, 38, 'Carmen de Cura'),
(118, 39, 'Santa Rita'),
(119, 39, 'Francisco de Miranda'),
(120, 39, 'Moseñor Feliciano González'),
(121, 40, 'Santa Cruz'),
(122, 41, 'José Félix Ribas'),
(123, 41, 'Castor Nieves Ríos'),
(124, 41, 'Las Guacamayas'),
(125, 41, 'Pao de Zárate'),
(126, 41, 'Zuata'),
(127, 42, 'José Rafael Revenga'),
(128, 43, 'Palo Negro'),
(129, 43, 'San Martín de Porres'),
(130, 44, 'El Limón'),
(131, 44, 'Caña de Azúcar'),
(132, 45, 'Ocumare de la Costa'),
(133, 46, 'San Casimiro'),
(134, 46, 'Güiripa'),
(135, 46, 'Ollas de Caramacate'),
(136, 46, 'Valle Morín'),
(137, 47, 'San Sebastían'),
(138, 48, 'Turmero'),
(139, 48, 'Arevalo Aponte'),
(140, 48, 'Chuao'),
(141, 48, 'Samán de Güere'),
(142, 48, 'Alfredo Pacheco Miranda'),
(143, 49, 'Santos Michelena'),
(144, 49, 'Tiara'),
(145, 50, 'Cagua'),
(146, 50, 'Bella Vista'),
(147, 51, 'Tovar'),
(148, 52, 'Urdaneta'),
(149, 52, 'Las Peñitas'),
(150, 52, 'San Francisco de Cara'),
(151, 52, 'Taguay'),
(152, 53, 'Zamora'),
(153, 53, 'Magdaleno'),
(154, 53, 'San Francisco de Asís'),
(155, 53, 'Valles de Tucutunemo'),
(156, 53, 'Augusto Mijares'),
(157, 54, 'Sabaneta'),
(158, 54, 'Juan Antonio Rodríguez Domínguez'),
(159, 55, 'El Cantón'),
(160, 55, 'Santa Cruz de Guacas'),
(161, 55, 'Puerto Vivas'),
(162, 56, 'Ticoporo'),
(163, 56, 'Nicolás Pulido'),
(164, 56, 'Andrés Bello'),
(165, 57, 'Arismendi'),
(166, 57, 'Guadarrama'),
(167, 57, 'La Unión'),
(168, 57, 'San Antonio'),
(169, 58, 'Barinas'),
(170, 58, 'Alberto Arvelo Larriva'),
(171, 58, 'San Silvestre'),
(172, 58, 'Santa Inés'),
(173, 58, 'Santa Lucía'),
(174, 58, 'Torumos'),
(175, 58, 'El Carmen'),
(176, 58, 'Rómulo Betancourt'),
(177, 58, 'Corazón de Jesús'),
(178, 58, 'Ramón Ignacio Méndez'),
(179, 58, 'Alto Barinas'),
(180, 58, 'Manuel Palacio Fajardo'),
(181, 58, 'Juan Antonio Rodríguez Domínguez'),
(182, 58, 'Dominga Ortiz de Páez'),
(183, 59, 'Barinitas'),
(184, 59, 'Altamira de Cáceres'),
(185, 59, 'Calderas'),
(186, 60, 'Barrancas'),
(187, 60, 'El Socorro'),
(188, 60, 'Mazparrito'),
(189, 61, 'Santa Bárbara'),
(190, 61, 'Pedro Briceño Méndez'),
(191, 61, 'Ramón Ignacio Méndez'),
(192, 61, 'José Ignacio del Pumar'),
(193, 62, 'Obispos'),
(194, 62, 'Guasimitos'),
(195, 62, 'El Real'),
(196, 62, 'La Luz'),
(197, 63, 'Ciudad Bolívia'),
(198, 63, 'José Ignacio Briceño'),
(199, 63, 'José Félix Ribas'),
(200, 63, 'Páez'),
(201, 64, 'Libertad'),
(202, 64, 'Dolores'),
(203, 64, 'Santa Rosa'),
(204, 64, 'Palacio Fajardo'),
(205, 65, 'Ciudad de Nutrias'),
(206, 65, 'El Regalo'),
(207, 65, 'Puerto Nutrias'),
(208, 65, 'Santa Catalina'),
(209, 66, 'Cachamay'),
(210, 66, 'Chirica'),
(211, 66, 'Dalla Costa'),
(212, 66, 'Once de Abril'),
(213, 66, 'Simón Bolívar'),
(214, 66, 'Unare'),
(215, 66, 'Universidad'),
(216, 66, 'Vista al Sol'),
(217, 66, 'Pozo Verde'),
(218, 66, 'Yocoima'),
(219, 66, '5 de Julio'),
(220, 67, 'Cedeño'),
(221, 67, 'Altagracia'),
(222, 67, 'Ascensión Farreras'),
(223, 67, 'Guaniamo'),
(224, 67, 'La Urbana'),
(225, 67, 'Pijiguaos'),
(226, 68, 'El Callao'),
(227, 69, 'Gran Sabana'),
(228, 69, 'Ikabarú'),
(229, 70, 'Catedral'),
(230, 70, 'Zea'),
(231, 70, 'Orinoco'),
(232, 70, 'José Antonio Páez'),
(233, 70, 'Marhuanta'),
(234, 70, 'Agua Salada'),
(235, 70, 'Vista Hermosa'),
(236, 70, 'La Sabanita'),
(237, 70, 'Panapana'),
(238, 71, 'Andrés Eloy Blanco'),
(239, 71, 'Pedro Cova'),
(240, 72, 'Raúl Leoni'),
(241, 72, 'Barceloneta'),
(242, 72, 'Santa Bárbara'),
(243, 72, 'San Francisco'),
(244, 73, 'Roscio'),
(245, 73, 'Salóm'),
(246, 74, 'Sifontes'),
(247, 74, 'Dalla Costa'),
(248, 74, 'San Isidro'),
(249, 75, 'Sucre'),
(250, 75, 'Aripao'),
(251, 75, 'Guarataro'),
(252, 75, 'Las Majadas'),
(253, 75, 'Moitaco'),
(254, 76, 'Padre Pedro Chien'),
(255, 76, 'Río Grande'),
(256, 77, 'Bejuma'),
(257, 77, 'Canoabo'),
(258, 77, 'Simón Bolívar'),
(259, 78, 'Güigüe'),
(260, 78, 'Carabobo'),
(261, 78, 'Tacarigua'),
(262, 79, 'Mariara'),
(263, 79, 'Aguas Calientes'),
(264, 80, 'Ciudad Alianza'),
(265, 80, 'Guacara'),
(266, 80, 'Yagua'),
(267, 81, 'Morón'),
(268, 81, 'Yagua'),
(269, 82, 'Tocuyito'),
(270, 82, 'Independencia'),
(271, 83, 'Los Guayos'),
(272, 84, 'Miranda'),
(273, 85, 'Montalbán'),
(274, 86, 'Naguanagua'),
(275, 87, 'Bartolomé Salóm'),
(276, 87, 'Democracia'),
(277, 87, 'Fraternidad'),
(278, 87, 'Goaigoaza'),
(279, 87, 'Juan José Flores'),
(280, 87, 'Unión'),
(281, 87, 'Borburata'),
(282, 87, 'Patanemo'),
(283, 88, 'San Diego'),
(284, 89, 'San Joaquín'),
(285, 90, 'Candelaria'),
(286, 90, 'Catedral'),
(287, 90, 'El Socorro'),
(288, 90, 'Miguel Peña'),
(289, 90, 'Rafael Urdaneta'),
(290, 90, 'San Blas'),
(291, 90, 'San José'),
(292, 90, 'Santa Rosa'),
(293, 90, 'Negro Primero'),
(294, 91, 'Cojedes'),
(295, 91, 'Juan de Mata Suárez'),
(296, 92, 'Tinaquillo'),
(297, 93, 'El Baúl'),
(298, 93, 'Sucre'),
(299, 94, 'La Aguadita'),
(300, 94, 'Macapo'),
(301, 95, 'El Pao'),
(302, 96, 'El Amparo'),
(303, 96, 'Libertad de Cojedes'),
(304, 97, 'Rómulo Gallegos'),
(305, 98, 'San Carlos de Austria'),
(306, 98, 'Juan Ángel Bravo'),
(307, 98, 'Manuel Manrique'),
(308, 99, 'General en Jefe José Laurencio Silva'),
(309, 100, 'Curiapo'),
(310, 100, 'Almirante Luis Brión'),
(311, 100, 'Francisco Aniceto Lugo'),
(312, 100, 'Manuel Renaud'),
(313, 100, 'Padre Barral'),
(314, 100, 'Santos de Abelgas'),
(315, 101, 'Imataca'),
(316, 101, 'Cinco de Julio'),
(317, 101, 'Juan Bautista Arismendi'),
(318, 101, 'Manuel Piar'),
(319, 101, 'Rómulo Gallegos'),
(320, 102, 'Pedernales'),
(321, 102, 'Luis Beltrán Prieto Figueroa'),
(322, 103, 'San José (Delta Amacuro)'),
(323, 103, 'José Vidal Marcano'),
(324, 103, 'Juan Millán'),
(325, 103, 'Leonardo Ruíz Pineda'),
(326, 103, 'Mariscal Antonio José de Sucre'),
(327, 103, 'Monseñor Argimiro García'),
(328, 103, 'San Rafael (Delta Amacuro)'),
(329, 103, 'Virgen del Valle'),
(330, 10, 'Clarines'),
(331, 10, 'Guanape'),
(332, 10, 'Sabana de Uchire'),
(333, 104, 'Capadare'),
(334, 104, 'La Pastora'),
(335, 104, 'Libertador'),
(336, 104, 'San Juan de los Cayos'),
(337, 105, 'Aracua'),
(338, 105, 'La Peña'),
(339, 105, 'San Luis'),
(340, 106, 'Bariro'),
(341, 106, 'Borojó'),
(342, 106, 'Capatárida'),
(343, 106, 'Guajiro'),
(344, 106, 'Seque'),
(345, 106, 'Zazárida'),
(346, 106, 'Valle de Eroa'),
(347, 107, 'Cacique Manaure'),
(348, 108, 'Norte'),
(349, 108, 'Carirubana'),
(350, 108, 'Santa Ana'),
(351, 108, 'Urbana Punta Cardón'),
(352, 109, 'La Vela de Coro'),
(353, 109, 'Acurigua'),
(354, 109, 'Guaibacoa'),
(355, 109, 'Las Calderas'),
(356, 109, 'Macoruca'),
(357, 110, 'Dabajuro'),
(358, 111, 'Agua Clara'),
(359, 111, 'Avaria'),
(360, 111, 'Pedregal'),
(361, 111, 'Piedra Grande'),
(362, 111, 'Purureche'),
(363, 112, 'Adaure'),
(364, 112, 'Adícora'),
(365, 112, 'Baraived'),
(366, 112, 'Buena Vista'),
(367, 112, 'Jadacaquiva'),
(368, 112, 'El Vínculo'),
(369, 112, 'El Hato'),
(370, 112, 'Moruy'),
(371, 112, 'Pueblo Nuevo'),
(372, 113, 'Agua Larga'),
(373, 113, 'El Paují'),
(374, 113, 'Independencia'),
(375, 113, 'Mapararí'),
(376, 114, 'Agua Linda'),
(377, 114, 'Araurima'),
(378, 114, 'Jacura'),
(379, 115, 'Tucacas'),
(380, 115, 'Boca de Aroa'),
(381, 116, 'Los Taques'),
(382, 116, 'Judibana'),
(383, 117, 'Mene de Mauroa'),
(384, 117, 'San Félix'),
(385, 117, 'Casigua'),
(386, 118, 'Guzmán Guillermo'),
(387, 118, 'Mitare'),
(388, 118, 'Río Seco'),
(389, 118, 'Sabaneta'),
(390, 118, 'San Antonio'),
(391, 118, 'San Gabriel'),
(392, 118, 'Santa Ana'),
(393, 119, 'Boca del Tocuyo'),
(394, 119, 'Chichiriviche'),
(395, 119, 'Tocuyo de la Costa'),
(396, 120, 'Palmasola'),
(397, 121, 'Cabure'),
(398, 121, 'Colina'),
(399, 121, 'Curimagua'),
(400, 122, 'San José de la Costa'),
(401, 122, 'Píritu'),
(402, 123, 'San Francisco'),
(403, 124, 'Sucre'),
(404, 124, 'Pecaya'),
(405, 125, 'Tocópero'),
(406, 126, 'El Charal'),
(407, 126, 'Las Vegas del Tuy'),
(408, 126, 'Santa Cruz de Bucaral'),
(409, 127, 'Bruzual'),
(410, 127, 'Urumaco'),
(411, 128, 'Puerto Cumarebo'),
(412, 128, 'La Ciénaga'),
(413, 128, 'La Soledad'),
(414, 128, 'Pueblo Cumarebo'),
(415, 128, 'Zazárida'),
(416, 113, 'Churuguara'),
(417, 129, 'Camaguán'),
(418, 129, 'Puerto Miranda'),
(419, 129, 'Uverito'),
(420, 130, 'Chaguaramas'),
(421, 131, 'El Socorro'),
(422, 132, 'Tucupido'),
(423, 132, 'San Rafael de Laya'),
(424, 133, 'Altagracia de Orituco'),
(425, 133, 'San Rafael de Orituco'),
(426, 133, 'San Francisco Javier de Lezama'),
(427, 133, 'Paso Real de Macaira'),
(428, 133, 'Carlos Soublette'),
(429, 133, 'San Francisco de Macaira'),
(430, 133, 'Libertad de Orituco'),
(431, 134, 'Cantaclaro'),
(432, 134, 'San Juan de los Morros'),
(433, 134, 'Parapara'),
(434, 135, 'El Sombrero'),
(435, 135, 'Sosa'),
(436, 136, 'Las Mercedes'),
(437, 136, 'Cabruta'),
(438, 136, 'Santa Rita de Manapire'),
(439, 137, 'Valle de la Pascua'),
(440, 137, 'Espino'),
(441, 138, 'San José de Unare'),
(442, 138, 'Zaraza'),
(443, 139, 'San José de Tiznados'),
(444, 139, 'San Francisco de Tiznados'),
(445, 139, 'San Lorenzo de Tiznados'),
(446, 139, 'Ortiz'),
(447, 140, 'Guayabal'),
(448, 140, 'Cazorla'),
(449, 141, 'San José de Guaribe'),
(450, 141, 'Uveral'),
(451, 142, 'Santa María de Ipire'),
(452, 142, 'Altamira'),
(453, 143, 'El Calvario'),
(454, 143, 'El Rastro'),
(455, 143, 'Guardatinajas'),
(456, 143, 'Capital Urbana Calabozo'),
(457, 144, 'Quebrada Honda de Guache'),
(458, 144, 'Pío Tamayo'),
(459, 144, 'Yacambú'),
(460, 145, 'Fréitez'),
(461, 145, 'José María Blanco'),
(462, 146, 'Catedral'),
(463, 146, 'Concepción'),
(464, 146, 'El Cují'),
(465, 146, 'Juan de Villegas'),
(466, 146, 'Santa Rosa'),
(467, 146, 'Tamaca'),
(468, 146, 'Unión'),
(469, 146, 'Aguedo Felipe Alvarado'),
(470, 146, 'Buena Vista'),
(471, 146, 'Juárez'),
(472, 147, 'Juan Bautista Rodríguez'),
(473, 147, 'Cuara'),
(474, 147, 'Diego de Lozada'),
(475, 147, 'Paraíso de San José'),
(476, 147, 'San Miguel'),
(477, 147, 'Tintorero'),
(478, 147, 'José Bernardo Dorante'),
(479, 147, 'Coronel Mariano Peraza '),
(480, 148, 'Bolívar'),
(481, 148, 'Anzoátegui'),
(482, 148, 'Guarico'),
(483, 148, 'Hilario Luna y Luna'),
(484, 148, 'Humocaro Alto'),
(485, 148, 'Humocaro Bajo'),
(486, 148, 'La Candelaria'),
(487, 148, 'Morán'),
(488, 149, 'Cabudare'),
(489, 149, 'José Gregorio Bastidas'),
(490, 149, 'Agua Viva'),
(491, 150, 'Sarare'),
(492, 150, 'Buría'),
(493, 150, 'Gustavo Vegas León'),
(494, 151, 'Trinidad Samuel'),
(495, 151, 'Antonio Díaz'),
(496, 151, 'Camacaro'),
(497, 151, 'Castañeda'),
(498, 151, 'Cecilio Zubillaga'),
(499, 151, 'Chiquinquirá'),
(500, 151, 'El Blanco'),
(501, 151, 'Espinoza de los Monteros'),
(502, 151, 'Lara'),
(503, 151, 'Las Mercedes'),
(504, 151, 'Manuel Morillo'),
(505, 151, 'Montaña Verde'),
(506, 151, 'Montes de Oca'),
(507, 151, 'Torres'),
(508, 151, 'Heriberto Arroyo'),
(509, 151, 'Reyes Vargas'),
(510, 151, 'Altagracia'),
(511, 152, 'Siquisique'),
(512, 152, 'Moroturo'),
(513, 152, 'San Miguel'),
(514, 152, 'Xaguas'),
(515, 179, 'Presidente Betancourt'),
(516, 179, 'Presidente Páez'),
(517, 179, 'Presidente Rómulo Gallegos'),
(518, 179, 'Gabriel Picón González'),
(519, 179, 'Héctor Amable Mora'),
(520, 179, 'José Nucete Sardi'),
(521, 179, 'Pulido Méndez'),
(522, 180, 'La Azulita'),
(523, 181, 'Santa Cruz de Mora'),
(524, 181, 'Mesa Bolívar'),
(525, 181, 'Mesa de Las Palmas'),
(526, 182, 'Aricagua'),
(527, 182, 'San Antonio'),
(528, 183, 'Canagua'),
(529, 183, 'Capurí'),
(530, 183, 'Chacantá'),
(531, 183, 'El Molino'),
(532, 183, 'Guaimaral'),
(533, 183, 'Mucutuy'),
(534, 183, 'Mucuchachí'),
(535, 184, 'Fernández Peña'),
(536, 184, 'Matriz'),
(537, 184, 'Montalbán'),
(538, 184, 'Acequias'),
(539, 184, 'Jají'),
(540, 184, 'La Mesa'),
(541, 184, 'San José del Sur'),
(542, 185, 'Tucaní'),
(543, 185, 'Florencio Ramírez'),
(544, 186, 'Santo Domingo'),
(545, 186, 'Las Piedras'),
(546, 187, 'Guaraque'),
(547, 187, 'Mesa de Quintero'),
(548, 187, 'Río Negro'),
(549, 188, 'Arapuey'),
(550, 188, 'Palmira'),
(551, 189, 'San Cristóbal de Torondoy'),
(552, 189, 'Torondoy'),
(553, 190, 'Antonio Spinetti Dini'),
(554, 190, 'Arias'),
(555, 190, 'Caracciolo Parra Pérez'),
(556, 190, 'Domingo Peña'),
(557, 190, 'El Llano'),
(558, 190, 'Gonzalo Picón Febres'),
(559, 190, 'Jacinto Plaza'),
(560, 190, 'Juan Rodríguez Suárez'),
(561, 190, 'Lasso de la Vega'),
(562, 190, 'Mariano Picón Salas'),
(563, 190, 'Milla'),
(564, 190, 'Osuna Rodríguez'),
(565, 190, 'Sagrario'),
(566, 190, 'El Morro'),
(567, 190, 'Los Nevados'),
(568, 191, 'Andrés Eloy Blanco'),
(569, 191, 'La Venta'),
(570, 191, 'Piñango'),
(571, 191, 'Timotes'),
(572, 192, 'Eloy Paredes'),
(573, 192, 'San Rafael de Alcázar'),
(574, 192, 'Santa Elena de Arenales'),
(575, 193, 'Santa María de Caparo'),
(576, 194, 'Pueblo Llano'),
(577, 195, 'Cacute'),
(578, 195, 'La Toma'),
(579, 195, 'Mucuchíes'),
(580, 195, 'Mucurubá'),
(581, 195, 'San Rafael'),
(582, 196, 'Gerónimo Maldonado'),
(583, 196, 'Bailadores'),
(584, 197, 'Tabay'),
(585, 198, 'Chiguará'),
(586, 198, 'Estánquez'),
(587, 198, 'Lagunillas'),
(588, 198, 'La Trampa'),
(589, 198, 'Pueblo Nuevo del Sur'),
(590, 198, 'San Juan'),
(591, 199, 'El Amparo'),
(592, 199, 'El Llano'),
(593, 199, 'San Francisco'),
(594, 199, 'Tovar'),
(595, 200, 'Independencia'),
(596, 200, 'María de la Concepción Palacios Blanco'),
(597, 200, 'Nueva Bolivia'),
(598, 200, 'Santa Apolonia'),
(599, 201, 'Caño El Tigre'),
(600, 201, 'Zea'),
(601, 223, 'Aragüita'),
(602, 223, 'Arévalo González'),
(603, 223, 'Capaya'),
(604, 223, 'Caucagua'),
(605, 223, 'Panaquire'),
(606, 223, 'Ribas'),
(607, 223, 'El Café'),
(608, 223, 'Marizapa'),
(609, 224, 'Cumbo'),
(610, 224, 'San José de Barlovento'),
(611, 225, 'El Cafetal'),
(612, 225, 'Las Minas'),
(613, 225, 'Nuestra Señora del Rosario'),
(614, 226, 'Higuerote'),
(615, 226, 'Curiepe'),
(616, 226, 'Tacarigua de Brión'),
(617, 227, 'Mamporal'),
(618, 228, 'Carrizal'),
(619, 229, 'Chacao'),
(620, 230, 'Charallave'),
(621, 230, 'Las Brisas'),
(622, 231, 'El Hatillo'),
(623, 232, 'Altagracia de la Montaña'),
(624, 232, 'Cecilio Acosta'),
(625, 232, 'Los Teques'),
(626, 232, 'El Jarillo'),
(627, 232, 'San Pedro'),
(628, 232, 'Tácata'),
(629, 232, 'Paracotos'),
(630, 233, 'Cartanal'),
(631, 233, 'Santa Teresa del Tuy'),
(632, 234, 'La Democracia'),
(633, 234, 'Ocumare del Tuy'),
(634, 234, 'Santa Bárbara'),
(635, 235, 'San Antonio de los Altos'),
(636, 236, 'Río Chico'),
(637, 236, 'El Guapo'),
(638, 236, 'Tacarigua de la Laguna'),
(639, 236, 'Paparo'),
(640, 236, 'San Fernando del Guapo'),
(641, 237, 'Santa Lucía del Tuy'),
(642, 238, 'Cúpira'),
(643, 238, 'Machurucuto'),
(644, 239, 'Guarenas'),
(645, 240, 'San Antonio de Yare'),
(646, 240, 'San Francisco de Yare'),
(647, 241, 'Leoncio Martínez'),
(648, 241, 'Petare'),
(649, 241, 'Caucagüita'),
(650, 241, 'Filas de Mariche'),
(651, 241, 'La Dolorita'),
(652, 242, 'Cúa'),
(653, 242, 'Nueva Cúa'),
(654, 243, 'Guatire'),
(655, 243, 'Bolívar'),
(656, 258, 'San Antonio de Maturín'),
(657, 258, 'San Francisco de Maturín'),
(658, 259, 'Aguasay'),
(659, 260, 'Caripito'),
(660, 261, 'El Guácharo'),
(661, 261, 'La Guanota'),
(662, 261, 'Sabana de Piedra'),
(663, 261, 'San Agustín'),
(664, 261, 'Teresen'),
(665, 261, 'Caripe'),
(666, 262, 'Areo'),
(667, 262, 'Capital Cedeño'),
(668, 262, 'San Félix de Cantalicio'),
(669, 262, 'Viento Fresco'),
(670, 263, 'El Tejero'),
(671, 263, 'Punta de Mata'),
(672, 264, 'Chaguaramas'),
(673, 264, 'Las Alhuacas'),
(674, 264, 'Tabasca'),
(675, 264, 'Temblador'),
(676, 265, 'Alto de los Godos'),
(677, 265, 'Boquerón'),
(678, 265, 'Las Cocuizas'),
(679, 265, 'La Cruz'),
(680, 265, 'San Simón'),
(681, 265, 'El Corozo'),
(682, 265, 'El Furrial'),
(683, 265, 'Jusepín'),
(684, 265, 'La Pica'),
(685, 265, 'San Vicente'),
(686, 266, 'Aparicio'),
(687, 266, 'Aragua de Maturín'),
(688, 266, 'Chaguamal'),
(689, 266, 'El Pinto'),
(690, 266, 'Guanaguana'),
(691, 266, 'La Toscana'),
(692, 266, 'Taguaya'),
(693, 267, 'Cachipo'),
(694, 267, 'Quiriquire'),
(695, 268, 'Santa Bárbara'),
(696, 269, 'Barrancas'),
(697, 269, 'Los Barrancos de Fajardo'),
(698, 270, 'Uracoa'),
(699, 271, 'Antolín del Campo'),
(700, 272, 'Arismendi'),
(701, 273, 'García'),
(702, 273, 'Francisco Fajardo'),
(703, 274, 'Bolívar'),
(704, 274, 'Guevara'),
(705, 274, 'Matasiete'),
(706, 274, 'Santa Ana'),
(707, 274, 'Sucre'),
(708, 275, 'Aguirre'),
(709, 275, 'Maneiro'),
(710, 276, 'Adrián'),
(711, 276, 'Juan Griego'),
(712, 276, 'Yaguaraparo'),
(713, 277, 'Porlamar'),
(714, 278, 'San Francisco de Macanao'),
(715, 278, 'Boca de Río'),
(716, 279, 'Tubores'),
(717, 279, 'Los Baleales'),
(718, 280, 'Vicente Fuentes'),
(719, 280, 'Villalba'),
(720, 281, 'San Juan Bautista'),
(721, 281, 'Zabala'),
(722, 283, 'Capital Araure'),
(723, 283, 'Río Acarigua'),
(724, 284, 'Capital Esteller'),
(725, 284, 'Uveral'),
(726, 285, 'Guanare'),
(727, 285, 'Córdoba'),
(728, 285, 'San José de la Montaña'),
(729, 285, 'San Juan de Guanaguanare'),
(730, 285, 'Virgen de la Coromoto'),
(731, 286, 'Guanarito'),
(732, 286, 'Trinidad de la Capilla'),
(733, 286, 'Divina Pastora'),
(734, 287, 'Monseñor José Vicente de Unda'),
(735, 287, 'Peña Blanca'),
(736, 288, 'Capital Ospino'),
(737, 288, 'Aparición'),
(738, 288, 'La Estación'),
(739, 289, 'Páez'),
(740, 289, 'Payara'),
(741, 289, 'Pimpinela'),
(742, 289, 'Ramón Peraza'),
(743, 290, 'Papelón'),
(744, 290, 'Caño Delgadito'),
(745, 291, 'San Genaro de Boconoito'),
(746, 291, 'Antolín Tovar'),
(747, 292, 'San Rafael de Onoto'),
(748, 292, 'Santa Fe'),
(749, 292, 'Thermo Morles'),
(750, 293, 'Santa Rosalía'),
(751, 293, 'Florida'),
(752, 294, 'Sucre'),
(753, 294, 'Concepción'),
(754, 294, 'San Rafael de Palo Alzado'),
(755, 294, 'Uvencio Antonio Velásquez'),
(756, 294, 'San José de Saguaz'),
(757, 294, 'Villa Rosa'),
(758, 295, 'Turén'),
(759, 295, 'Canelones'),
(760, 295, 'Santa Cruz'),
(761, 295, 'San Isidro Labrador'),
(762, 296, 'Mariño'),
(763, 296, 'Rómulo Gallegos'),
(764, 297, 'San José de Aerocuar'),
(765, 297, 'Tavera Acosta'),
(766, 298, 'Río Caribe'),
(767, 298, 'Antonio José de Sucre'),
(768, 298, 'El Morro de Puerto Santo'),
(769, 298, 'Puerto Santo'),
(770, 298, 'San Juan de las Galdonas'),
(771, 299, 'El Pilar'),
(772, 299, 'El Rincón'),
(773, 299, 'General Francisco Antonio Váquez'),
(774, 299, 'Guaraúnos'),
(775, 299, 'Tunapuicito'),
(776, 299, 'Unión'),
(777, 300, 'Santa Catalina'),
(778, 300, 'Santa Rosa'),
(779, 300, 'Santa Teresa'),
(780, 300, 'Bolívar'),
(781, 300, 'Maracapana'),
(782, 302, 'Libertad'),
(783, 302, 'El Paujil'),
(784, 302, 'Yaguaraparo'),
(785, 303, 'Cruz Salmerón Acosta'),
(786, 303, 'Chacopata'),
(787, 303, 'Manicuare'),
(788, 304, 'Tunapuy'),
(789, 304, 'Campo Elías'),
(790, 305, 'Irapa'),
(791, 305, 'Campo Claro'),
(792, 305, 'Maraval'),
(793, 305, 'San Antonio de Irapa'),
(794, 305, 'Soro'),
(795, 306, 'Mejía'),
(796, 307, 'Cumanacoa'),
(797, 307, 'Arenas'),
(798, 307, 'Aricagua'),
(799, 307, 'Cogollar'),
(800, 307, 'San Fernando'),
(801, 307, 'San Lorenzo'),
(802, 308, 'Villa Frontado (Muelle de Cariaco)'),
(803, 308, 'Catuaro'),
(804, 308, 'Rendón'),
(805, 308, 'San Cruz'),
(806, 308, 'Santa María'),
(807, 309, 'Altagracia'),
(808, 309, 'Santa Inés'),
(809, 309, 'Valentín Valiente'),
(810, 309, 'Ayacucho'),
(811, 309, 'San Juan'),
(812, 309, 'Raúl Leoni'),
(813, 309, 'Gran Mariscal'),
(814, 310, 'Cristóbal Colón'),
(815, 310, 'Bideau'),
(816, 310, 'Punta de Piedras'),
(817, 310, 'Güiria'),
(818, 341, 'Andrés Bello'),
(819, 342, 'Antonio Rómulo Costa'),
(820, 343, 'Ayacucho'),
(821, 343, 'Rivas Berti'),
(822, 343, 'San Pedro del Río'),
(823, 344, 'Bolívar'),
(824, 344, 'Palotal'),
(825, 344, 'General Juan Vicente Gómez'),
(826, 344, 'Isaías Medina Angarita'),
(827, 345, 'Cárdenas'),
(828, 345, 'Amenodoro Ángel Lamus'),
(829, 345, 'La Florida'),
(830, 346, 'Córdoba'),
(831, 347, 'Fernández Feo'),
(832, 347, 'Alberto Adriani'),
(833, 347, 'Santo Domingo'),
(834, 348, 'Francisco de Miranda'),
(835, 349, 'García de Hevia'),
(836, 349, 'Boca de Grita'),
(837, 349, 'José Antonio Páez'),
(838, 350, 'Guásimos'),
(839, 351, 'Independencia'),
(840, 351, 'Juan Germán Roscio'),
(841, 351, 'Román Cárdenas'),
(842, 352, 'Jáuregui'),
(843, 352, 'Emilio Constantino Guerrero'),
(844, 352, 'Monseñor Miguel Antonio Salas'),
(845, 353, 'José María Vargas'),
(846, 354, 'Junín'),
(847, 354, 'La Petrólea'),
(848, 354, 'Quinimarí'),
(849, 354, 'Bramón'),
(850, 355, 'Libertad'),
(851, 355, 'Cipriano Castro'),
(852, 355, 'Manuel Felipe Rugeles'),
(853, 356, 'Libertador'),
(854, 356, 'Doradas'),
(855, 356, 'Emeterio Ochoa'),
(856, 356, 'San Joaquín de Navay'),
(857, 357, 'Lobatera'),
(858, 357, 'Constitución'),
(859, 358, 'Michelena'),
(860, 359, 'Panamericano'),
(861, 359, 'La Palmita'),
(862, 360, 'Pedro María Ureña'),
(863, 360, 'Nueva Arcadia'),
(864, 361, 'Delicias'),
(865, 361, 'Pecaya'),
(866, 362, 'Samuel Darío Maldonado'),
(867, 362, 'Boconó'),
(868, 362, 'Hernández'),
(869, 363, 'La Concordia'),
(870, 363, 'San Juan Bautista'),
(871, 363, 'Pedro María Morantes'),
(872, 363, 'San Sebastián'),
(873, 363, 'Dr. Francisco Romero Lobo'),
(874, 364, 'Seboruco'),
(875, 365, 'Simón Rodríguez'),
(876, 366, 'Sucre'),
(877, 366, 'Eleazar López Contreras'),
(878, 366, 'San Pablo'),
(879, 367, 'Torbes'),
(880, 368, 'Uribante'),
(881, 368, 'Cárdenas'),
(882, 368, 'Juan Pablo Peñalosa'),
(883, 368, 'Potosí'),
(884, 369, 'San Judas Tadeo'),
(885, 370, 'Araguaney'),
(886, 370, 'El Jaguito'),
(887, 370, 'La Esperanza'),
(888, 370, 'Santa Isabel'),
(889, 371, 'Boconó'),
(890, 371, 'El Carmen'),
(891, 371, 'Mosquey'),
(892, 371, 'Ayacucho'),
(893, 371, 'Burbusay'),
(894, 371, 'General Ribas'),
(895, 371, 'Guaramacal'),
(896, 371, 'Vega de Guaramacal'),
(897, 371, 'Monseñor Jáuregui'),
(898, 371, 'Rafael Rangel'),
(899, 371, 'San Miguel'),
(900, 371, 'San José'),
(901, 372, 'Sabana Grande'),
(902, 372, 'Cheregüé'),
(903, 372, 'Granados'),
(904, 373, 'Arnoldo Gabaldón'),
(905, 373, 'Bolivia'),
(906, 373, 'Carrillo'),
(907, 373, 'Cegarra'),
(908, 373, 'Chejendé'),
(909, 373, 'Manuel Salvador Ulloa'),
(910, 373, 'San José'),
(911, 374, 'Carache'),
(912, 374, 'La Concepción'),
(913, 374, 'Cuicas'),
(914, 374, 'Panamericana'),
(915, 374, 'Santa Cruz'),
(916, 375, 'Escuque'),
(917, 375, 'La Unión'),
(918, 375, 'Santa Rita'),
(919, 375, 'Sabana Libre'),
(920, 376, 'El Socorro'),
(921, 376, 'Los Caprichos'),
(922, 376, 'Antonio José de Sucre'),
(923, 377, 'Campo Elías'),
(924, 377, 'Arnoldo Gabaldón'),
(925, 378, 'Santa Apolonia'),
(926, 378, 'El Progreso'),
(927, 378, 'La Ceiba'),
(928, 378, 'Tres de Febrero'),
(929, 379, 'El Dividive'),
(930, 379, 'Agua Santa'),
(931, 379, 'Agua Caliente'),
(932, 379, 'El Cenizo'),
(933, 379, 'Valerita'),
(934, 380, 'Monte Carmelo'),
(935, 380, 'Buena Vista'),
(936, 380, 'Santa María del Horcón'),
(937, 381, 'Motatán'),
(938, 381, 'El Baño'),
(939, 381, 'Jalisco'),
(940, 382, 'Pampán'),
(941, 382, 'Flor de Patria'),
(942, 382, 'La Paz'),
(943, 382, 'Santa Ana'),
(944, 383, 'Pampanito'),
(945, 383, 'La Concepción'),
(946, 383, 'Pampanito II'),
(947, 384, 'Betijoque'),
(948, 384, 'José Gregorio Hernández'),
(949, 384, 'La Pueblita'),
(950, 384, 'Los Cedros'),
(951, 385, 'Carvajal'),
(952, 385, 'Campo Alegre'),
(953, 385, 'Antonio Nicolás Briceño'),
(954, 385, 'José Leonardo Suárez'),
(955, 386, 'Sabana de Mendoza'),
(956, 386, 'Junín'),
(957, 386, 'Valmore Rodríguez'),
(958, 386, 'El Paraíso'),
(959, 387, 'Andrés Linares'),
(960, 387, 'Chiquinquirá'),
(961, 387, 'Cristóbal Mendoza'),
(962, 387, 'Cruz Carrillo'),
(963, 387, 'Matriz'),
(964, 387, 'Monseñor Carrillo'),
(965, 387, 'Tres Esquinas'),
(966, 388, 'Cabimbú'),
(967, 388, 'Jajó'),
(968, 388, 'La Mesa de Esnujaque'),
(969, 388, 'Santiago'),
(970, 388, 'Tuñame'),
(971, 388, 'La Quebrada'),
(972, 389, 'Juan Ignacio Montilla'),
(973, 389, 'La Beatriz'),
(974, 389, 'La Puerta'),
(975, 389, 'Mendoza del Valle de Momboy'),
(976, 389, 'Mercedes Díaz'),
(977, 389, 'San Luis'),
(978, 390, 'Caraballeda'),
(979, 390, 'Carayaca'),
(980, 390, 'Carlos Soublette'),
(981, 390, 'Caruao Chuspa'),
(982, 390, 'Catia La Mar'),
(983, 390, 'El Junko'),
(984, 390, 'La Guaira'),
(985, 390, 'Macuto'),
(986, 390, 'Maiquetía'),
(987, 390, 'Naiguatá'),
(988, 390, 'Urimare'),
(989, 391, 'Arístides Bastidas'),
(990, 392, 'Bolívar'),
(991, 407, 'Chivacoa'),
(992, 407, 'Campo Elías'),
(993, 408, 'Cocorote'),
(994, 409, 'Independencia'),
(995, 410, 'José Antonio Páez'),
(996, 411, 'La Trinidad'),
(997, 412, 'Manuel Monge'),
(998, 413, 'Salóm'),
(999, 413, 'Temerla'),
(1000, 413, 'Nirgua'),
(1001, 414, 'San Andrés'),
(1002, 414, 'Yaritagua'),
(1003, 415, 'San Javier'),
(1004, 415, 'Albarico'),
(1005, 415, 'San Felipe'),
(1006, 416, 'Sucre'),
(1007, 417, 'Urachiche'),
(1008, 418, 'El Guayabo'),
(1009, 418, 'Farriar'),
(1010, 441, 'Isla de Toas'),
(1011, 441, 'Monagas'),
(1012, 442, 'San Timoteo'),
(1013, 442, 'General Urdaneta'),
(1014, 442, 'Libertador'),
(1015, 442, 'Marcelino Briceño'),
(1016, 442, 'Pueblo Nuevo'),
(1017, 442, 'Manuel Guanipa Matos'),
(1018, 443, 'Ambrosio'),
(1019, 443, 'Carmen Herrera'),
(1020, 443, 'La Rosa'),
(1021, 443, 'Germán Ríos Linares'),
(1022, 443, 'San Benito'),
(1023, 443, 'Rómulo Betancourt'),
(1024, 443, 'Jorge Hernández'),
(1025, 443, 'Punta Gorda'),
(1026, 443, 'Arístides Calvani'),
(1027, 444, 'Encontrados'),
(1028, 444, 'Udón Pérez'),
(1029, 445, 'Moralito'),
(1030, 445, 'San Carlos del Zulia'),
(1031, 445, 'Santa Cruz del Zulia'),
(1032, 445, 'Santa Bárbara'),
(1033, 445, 'Urribarrí'),
(1034, 446, 'Carlos Quevedo'),
(1035, 446, 'Francisco Javier Pulgar'),
(1036, 446, 'Simón Rodríguez'),
(1037, 446, 'Guamo-Gavilanes'),
(1038, 448, 'La Concepción'),
(1039, 448, 'San José'),
(1040, 448, 'Mariano Parra León'),
(1041, 448, 'José Ramón Yépez'),
(1042, 449, 'Jesús María Semprún'),
(1043, 449, 'Barí'),
(1044, 450, 'Concepción'),
(1045, 450, 'Andrés Bello'),
(1046, 450, 'Chiquinquirá'),
(1047, 450, 'El Carmelo'),
(1048, 450, 'Potreritos'),
(1049, 451, 'Libertad'),
(1050, 451, 'Alonso de Ojeda'),
(1051, 451, 'Venezuela'),
(1052, 451, 'Eleazar López Contreras'),
(1053, 451, 'Campo Lara'),
(1054, 452, 'Bartolomé de las Casas'),
(1055, 452, 'Libertad'),
(1056, 452, 'Río Negro'),
(1057, 452, 'San José de Perijá'),
(1058, 453, 'San Rafael'),
(1059, 453, 'La Sierrita'),
(1060, 453, 'Las Parcelas'),
(1061, 453, 'Luis de Vicente'),
(1062, 453, 'Monseñor Marcos Sergio Godoy'),
(1063, 453, 'Ricaurte'),
(1064, 453, 'Tamare'),
(1065, 454, 'Antonio Borjas Romero'),
(1066, 454, 'Bolívar'),
(1067, 454, 'Cacique Mara'),
(1068, 454, 'Carracciolo Parra Pérez'),
(1069, 454, 'Cecilio Acosta'),
(1070, 454, 'Cristo de Aranza'),
(1071, 454, 'Coquivacoa'),
(1072, 454, 'Chiquinquirá'),
(1073, 454, 'Francisco Eugenio Bustamante'),
(1074, 454, 'Idelfonzo Vásquez'),
(1075, 454, 'Juana de Ávila'),
(1076, 454, 'Luis Hurtado Higuera'),
(1077, 454, 'Manuel Dagnino'),
(1078, 454, 'Olegario Villalobos'),
(1079, 454, 'Raúl Leoni'),
(1080, 454, 'Santa Lucía'),
(1081, 454, 'Venancio Pulgar'),
(1082, 454, 'San Isidro'),
(1083, 455, 'Altagracia'),
(1084, 455, 'Faría'),
(1085, 455, 'Ana María Campos'),
(1086, 455, 'San Antonio'),
(1087, 455, 'San José'),
(1088, 456, 'Donaldo García'),
(1089, 456, 'El Rosario'),
(1090, 456, 'Sixto Zambrano'),
(1091, 457, 'San Francisco'),
(1092, 457, 'El Bajo'),
(1093, 457, 'Domitila Flores'),
(1094, 457, 'Francisco Ochoa'),
(1095, 457, 'Los Cortijos'),
(1096, 457, 'Marcial Hernández'),
(1097, 458, 'Santa Rita'),
(1098, 458, 'El Mene'),
(1099, 458, 'Pedro Lucas Urribarrí'),
(1100, 458, 'José Cenobio Urribarrí'),
(1101, 459, 'Rafael Maria Baralt'),
(1102, 459, 'Manuel Manrique'),
(1103, 459, 'Rafael Urdaneta'),
(1104, 460, 'Bobures'),
(1105, 460, 'Gibraltar'),
(1106, 460, 'Heras'),
(1107, 460, 'Monseñor Arturo Álvarez'),
(1108, 460, 'Rómulo Gallegos'),
(1109, 460, 'El Batey'),
(1110, 461, 'Rafael Urdaneta'),
(1111, 461, 'La Victoria'),
(1112, 461, 'Raúl Cuenca'),
(1113, 447, 'Sinamaica'),
(1114, 447, 'Alta Guajira'),
(1115, 447, 'Elías Sánchez Rubio'),
(1116, 447, 'Guajira'),
(1117, 462, 'Altagracia'),
(1118, 462, 'Antímano'),
(1119, 462, 'Caricuao'),
(1120, 462, 'Catedral'),
(1121, 462, 'Coche'),
(1122, 462, 'El Junquito'),
(1123, 462, 'El Paraíso'),
(1124, 462, 'El Recreo'),
(1125, 462, 'El Valle'),
(1126, 462, 'La Candelaria'),
(1127, 462, 'La Pastora'),
(1128, 462, 'La Vega'),
(1129, 462, 'Macarao'),
(1130, 462, 'San Agustín'),
(1131, 462, 'San Bernardino'),
(1132, 462, 'San José'),
(1133, 462, 'San Juan'),
(1134, 462, 'San Pedro'),
(1135, 462, 'Santa Rosalía'),
(1136, 462, 'Santa Teresa'),
(1137, 462, 'Sucre (Catia)'),
(1138, 462, '23 de enero');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `periodo_mensual`
--

CREATE TABLE IF NOT EXISTS `periodo_mensual` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` varchar(2) NOT NULL,
  `mes` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pos_comandas`
--

CREATE TABLE IF NOT EXISTS `pos_comandas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` int(11) NOT NULL,
  `vendedor_id` int(11) NOT NULL,
  `cuenta_id` int(11) NOT NULL,
  `cantidad` float NOT NULL DEFAULT '00',
  `empaque` varchar(15) NOT NULL,
  `precio_neto` float NOT NULL DEFAULT '0',
  `descuento1p` float NOT NULL DEFAULT '0',
  `descuento1` float NOT NULL DEFAULT '0',
  `costo_venta` float NOT NULL DEFAULT '0',
  `total_neto` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `hora` time NOT NULL,
  `precio_final` float NOT NULL DEFAULT '0',
  `decimales` varchar(1) NOT NULL,
  `contenido_empaque` int(11) NOT NULL DEFAULT '0',
  `cantidad_und` float NOT NULL DEFAULT '00',
  `precio_und` float NOT NULL DEFAULT '0',
  `costo_und` float NOT NULL DEFAULT '0',
  `precio_item` float NOT NULL DEFAULT '0',
  `detalle` varchar(160) NOT NULL,
  `tasa` float NOT NULL DEFAULT '0',
  `categoria` varchar(20) NOT NULL,
  `costo_promedio_und` float NOT NULL DEFAULT '0',
  `costo_compra` float NOT NULL DEFAULT '0',
  `estatus_comanda` tinyint(1) NOT NULL,
  `total_descuento` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pos_cuentas`
--

CREATE TABLE IF NOT EXISTS `pos_cuentas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cuenta` varchar(5) NOT NULL,
  `estatus_cuenta` tinyint(1) NOT NULL,
  `estatus_servicio` tinyint(1) NOT NULL,
  `estatus_abierta` tinyint(1) NOT NULL,
  `estatus` varchar(10) NOT NULL,
  `acumulado` float NOT NULL,
  `ci_rif` varchar(12) NOT NULL,
  `nombre` varchar(80) NOT NULL,
  `dir_fiscal` varchar(120) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE IF NOT EXISTS `productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tasa_id` int(11) NOT NULL,
  `departamento_id` int(11) NOT NULL,
  `empaque_compra_id` int(11) NOT NULL,
  `subcategoria_id` int(11) NOT NULL,
  `dias_garantia` int(11) NOT NULL DEFAULT '0',
  `codigo` varchar(15) NOT NULL,
  `nombre` varchar(120) NOT NULL,
  `nombre_corto` varchar(40) NOT NULL,
  `imagen` varchar(100) NOT NULL,
  `costo_proveedor` float NOT NULL DEFAULT '0',
  `costo_importacion` float NOT NULL DEFAULT '0',
  `costo_importacion_und` float NOT NULL DEFAULT '0',
  `costo_varios` float NOT NULL DEFAULT '0',
  `costo_varios_und` float NOT NULL DEFAULT '0',
  `costo` float NOT NULL DEFAULT '0',
  `costo_und` float NOT NULL DEFAULT '0',
  `costo_promedio` float NOT NULL DEFAULT '0',
  `costo_promedio_und` float NOT NULL DEFAULT '0',
  `utilidad_1` float NOT NULL DEFAULT '0',
  `utilidad_2` float NOT NULL DEFAULT '0',
  `utilidad_3` float NOT NULL DEFAULT '0',
  `utilidad_4` float NOT NULL DEFAULT '0',
  `utilidad_pto` float NOT NULL DEFAULT '0',
  `estatus_garantia` tinyint(1) NOT NULL,
  `precio_sugerido` float NOT NULL DEFAULT '0',
  `comentarios` varchar(120) NOT NULL,
  `referencia` varchar(20) NOT NULL,
  `contenido_compras` int(11) NOT NULL DEFAULT '0',
  `estatus` varchar(10) NOT NULL,
  `advertencia` varchar(60) NOT NULL,
  `fecha_alta` date NOT NULL DEFAULT '2000-01-01',
  `fecha_baja` date NOT NULL DEFAULT '2000-01-01',
  `codigo_contable` varchar(15) NOT NULL,
  `categoria` varchar(20) NOT NULL,
  `origen` varchar(10) NOT NULL,
  `codigo_arancel` varchar(15) NOT NULL,
  `tasa_arancel` float NOT NULL DEFAULT '0',
  `estatus_serial` tinyint(1) NOT NULL,
  `estatus_oferta` tinyint(1) NOT NULL,
  `inicio` date NOT NULL DEFAULT '2000-01-01',
  `fin` date NOT NULL DEFAULT '2000-01-01',
  `precio_oferta` float NOT NULL DEFAULT '0',
  `precio_1` float NOT NULL DEFAULT '0',
  `precio_2` float NOT NULL DEFAULT '0',
  `precio_3` float NOT NULL DEFAULT '0',
  `precio_4` float NOT NULL DEFAULT '0',
  `precio_pto` float NOT NULL DEFAULT '0',
  `memo` text NOT NULL,
  `serial` varchar(50) NOT NULL,
  `contenido_1` int(11) NOT NULL DEFAULT '0',
  `contenido_2` int(11) NOT NULL DEFAULT '0',
  `contenido_3` int(11) NOT NULL DEFAULT '0',
  `contenido_4` int(11) NOT NULL DEFAULT '0',
  `contenido_pto` int(11) NOT NULL DEFAULT '0',
  `plu` varchar(5) NOT NULL,
  `estatus_catalogo` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_conceptos`
--

CREATE TABLE IF NOT EXISTS `productos_conceptos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(15) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_costos`
--

CREATE TABLE IF NOT EXISTS `productos_costos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` varchar(10) NOT NULL,
  `nota` varchar(40) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `estacion` varchar(20) NOT NULL,
  `hora` time NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `costo` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_deposito`
--

CREATE TABLE IF NOT EXISTS `productos_deposito` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` int(11) NOT NULL,
  `deposito_id` int(11) NOT NULL,
  `fisica` float NOT NULL DEFAULT '00',
  `reservada` float NOT NULL DEFAULT '00',
  `disponible` float NOT NULL DEFAULT '00',
  `ubicacion_1` varchar(20) NOT NULL,
  `ubicacion_2` varchar(20) NOT NULL,
  `ubicacion_3` varchar(20) NOT NULL,
  `ubicacion_4` varchar(20) NOT NULL,
  `nivel_minimo` float NOT NULL DEFAULT '00',
  `pto_pedido` float NOT NULL DEFAULT '00',
  `nivel_optimo` float NOT NULL DEFAULT '00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_grupo`
--

CREATE TABLE IF NOT EXISTS `productos_grupo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `estatus_catalogo` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_kardex`
--

CREATE TABLE IF NOT EXISTS `productos_kardex` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` int(11) NOT NULL,
  `deposito_id` int(11) NOT NULL,
  `concepto_id` int(11) NOT NULL,
  `documento_id` int(11) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `hora` time NOT NULL,
  `documento` varchar(15) NOT NULL,
  `modulo` varchar(10) NOT NULL,
  `entidad` varchar(80) NOT NULL,
  `signo` int(11) NOT NULL DEFAULT '0',
  `cantidad` float NOT NULL DEFAULT '00',
  `cantidad_bono` float NOT NULL DEFAULT '00',
  `cantidad_und` float NOT NULL DEFAULT '00',
  `costo_und` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `estatus_anulado` tinyint(1) NOT NULL,
  `nota` varchar(50) NOT NULL,
  `precio_und` float NOT NULL DEFAULT '0',
  `codigo` varchar(2) NOT NULL,
  `siglas` varchar(3) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_medida`
--

CREATE TABLE IF NOT EXISTS `productos_medida` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `decimales` varchar(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_movimientos`
--

CREATE TABLE IF NOT EXISTS `productos_movimientos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_id` int(11) NOT NULL,
  `deposito_salida_id` int(11) NOT NULL,
  `deposito_destino_id` int(11) NOT NULL,
  `concepto_id` int(11) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `nota` varchar(60) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `hora` time NOT NULL,
  `estacion` varchar(20) NOT NULL,
  `tipo` varchar(2) NOT NULL,
  `renglones` int(6) NOT NULL DEFAULT '0',
  `documento_nombre` varchar(16) NOT NULL,
  `autorizado` varchar(40) NOT NULL,
  `total` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_movimientos_detalle`
--

CREATE TABLE IF NOT EXISTS `productos_movimientos_detalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `productos_movimientos_id` int(11) NOT NULL,
  `documento_id` int(11) NOT NULL,
  `producto_id` int(11) NOT NULL,
  `cantidad` float NOT NULL DEFAULT '00',
  `cantidad_bono` float NOT NULL DEFAULT '00',
  `cantidad_und` float NOT NULL DEFAULT '00',
  `categoria` varchar(20) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `contenido_empaque` int(11) NOT NULL DEFAULT '0',
  `empaque` varchar(15) NOT NULL,
  `decimales` varchar(1) NOT NULL,
  `costo_und` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `costo_compra` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_precios`
--

CREATE TABLE IF NOT EXISTS `productos_precios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` varchar(10) NOT NULL,
  `nota` varchar(40) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `estacion` varchar(20) NOT NULL,
  `hora` time NOT NULL,
  `usuario_id` varchar(20) NOT NULL,
  `precio` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_proveedor`
--

CREATE TABLE IF NOT EXISTS `productos_proveedor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` int(11) NOT NULL,
  `proveedor_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_vencimiento_depositos`
--

CREATE TABLE IF NOT EXISTS `productos_vencimiento_depositos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producto_id` int(11) NOT NULL,
  `deposito_id` int(11) NOT NULL,
  `fecha_vencimiento` date NOT NULL,
  `serial_producto` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE IF NOT EXISTS `proveedores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grupo_id` int(11) NOT NULL,
  `parroquia_id` int(11) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(80) NOT NULL,
  `ci_rif` varchar(15) NOT NULL,
  `razon_social` varchar(80) NOT NULL,
  `dir_fiscal` varchar(120) NOT NULL,
  `contacto` varchar(60) NOT NULL,
  `telefono_ofi` varchar(60) NOT NULL,
  `telefono_cel` varchar(60) NOT NULL,
  `email` varchar(100) NOT NULL,
  `website` varchar(100) NOT NULL,
  `denominacion_fiscal` varchar(20) NOT NULL,
  `codigo_postal` varchar(10) NOT NULL,
  `retencion_iva` float NOT NULL DEFAULT '0',
  `retencion_islr` float NOT NULL DEFAULT '0',
  `fecha_alta` date NOT NULL DEFAULT '2000-01-01',
  `fecha_baja` date NOT NULL DEFAULT '2000-01-01',
  `fecha_ult_pago` date NOT NULL DEFAULT '2000-01-01',
  `fecha_ult_compra` date NOT NULL DEFAULT '2000-01-01',
  `anticipos` float NOT NULL DEFAULT '0',
  `debitos` float NOT NULL DEFAULT '0',
  `creditos` float NOT NULL DEFAULT '0',
  `saldo` float NOT NULL DEFAULT '0',
  `disponible` float NOT NULL DEFAULT '0',
  `memo` text NOT NULL,
  `advertencia` varchar(60) NOT NULL,
  `estatus` varchar(10) NOT NULL,
  `codigo_cobrar` varchar(15) NOT NULL,
  `codigo_ingresos` varchar(15) NOT NULL,
  `codigo_anticipos` varchar(15) NOT NULL,
  `estatus_vendedor` tinyint(1) NOT NULL,
  `ventas_g` float NOT NULL DEFAULT '0',
  `ventas_1` float NOT NULL DEFAULT '0',
  `ventas_2` float NOT NULL DEFAULT '0',
  `ventas_3` float NOT NULL DEFAULT '0',
  `ventas_4` float NOT NULL DEFAULT '0',
  `cobranza_g` float NOT NULL DEFAULT '0',
  `cobranza_1` float NOT NULL DEFAULT '0',
  `cobranza_2` float NOT NULL DEFAULT '0',
  `cobranza_3` float NOT NULL DEFAULT '0',
  `cobranza_4` float NOT NULL DEFAULT '0',
  `estatus_ventas` tinyint(1) NOT NULL,
  `estatus_cobranza` tinyint(1) NOT NULL,
  `estatus_departamento` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores_agencias`
--

CREATE TABLE IF NOT EXISTS `proveedores_agencias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `proveedor_id` int(11) NOT NULL,
  `agencia_id` int(11) NOT NULL,
  `cuenta` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores_grupo`
--

CREATE TABLE IF NOT EXISTS `proveedores_grupo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `remisiones`
--

CREATE TABLE IF NOT EXISTS `remisiones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `series_fiscales`
--

CREATE TABLE IF NOT EXISTS `series_fiscales` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `serie` varchar(10) NOT NULL,
  `correlativo` int(11) NOT NULL DEFAULT '0',
  `estatus_factura` tinyint(1) NOT NULL,
  `estatus_nd` tinyint(1) NOT NULL,
  `estatus_nc` tinyint(1) NOT NULL,
  `estatus_ne` tinyint(1) NOT NULL,
  `estatus` varchar(10) NOT NULL,
  `control` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `subcategoria`
--

CREATE TABLE IF NOT EXISTS `subcategoria` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoria_id` int(11) DEFAULT NULL,
  `codigo` varchar(45) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tasas`
--

CREATE TABLE IF NOT EXISTS `tasas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `tasa` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grupo_id` int(11) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `clave` varchar(20) NOT NULL,
  `usuario` varchar(20) NOT NULL,
  `estatus` varchar(10) NOT NULL,
  `fecha_alta` date NOT NULL DEFAULT '2000-01-01',
  `fecha_baja` date NOT NULL DEFAULT '2000-01-01',
  `fecha_sesion` date NOT NULL DEFAULT '2000-01-01',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios_grupo`
--

CREATE TABLE IF NOT EXISTS `usuarios_grupo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios_grupo_permisos`
--

CREATE TABLE IF NOT EXISTS `usuarios_grupo_permisos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grupo_id` varchar(10) NOT NULL,
  `funcion_id` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `variantes_productos`
--

CREATE TABLE IF NOT EXISTS `variantes_productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `referencia` varchar(150) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `atributo` varchar(250) NOT NULL,
  `precio` float NOT NULL DEFAULT '0',
  `medida_id` int(11) NOT NULL,
  `producto_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE IF NOT EXISTS `ventas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `vendedor_id` int(11) NOT NULL,
  `transporte_id` int(11) NOT NULL,
  `recibo_id` int(11) NOT NULL,
  `remision_id` int(11) NOT NULL,
  `cxc_id` int(11) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `fecha_vencimiento` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base1` float NOT NULL DEFAULT '0',
  `base2` float NOT NULL DEFAULT '0',
  `base3` float NOT NULL DEFAULT '0',
  `impuesto1` float NOT NULL DEFAULT '0',
  `impuesto2` float NOT NULL DEFAULT '0',
  `impuesto3` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `tasa1` float NOT NULL DEFAULT '0',
  `tasa2` float NOT NULL DEFAULT '0',
  `tasa3` float NOT NULL DEFAULT '0',
  `nota` varchar(200) NOT NULL,
  `tasa_retencion_iva` float NOT NULL DEFAULT '0',
  `tasa_retencion_islr` float NOT NULL DEFAULT '0',
  `retencion_iva` float NOT NULL DEFAULT '0',
  `retencion_islr` float NOT NULL DEFAULT '0',
  `mes_relacion` varchar(2) NOT NULL,
  `control` varchar(10) NOT NULL,
  `fecha_registro` date NOT NULL DEFAULT '2000-01-01',
  `orden_compra` varchar(10) NOT NULL,
  `dias` int(11) NOT NULL DEFAULT '0',
  `descuento1` float NOT NULL DEFAULT '0',
  `descuento2` float NOT NULL DEFAULT '0',
  `cargos` float NOT NULL DEFAULT '0',
  `descuento1p` float NOT NULL DEFAULT '0',
  `descuento2p` float NOT NULL DEFAULT '0',
  `cargosp` float NOT NULL DEFAULT '0',
  `columna` varchar(1) NOT NULL,
  `estatus_anulado` tinyint(1) NOT NULL,
  `aplica` varchar(10) NOT NULL,
  `comprobante_retencion` varchar(14) NOT NULL,
  `subtotal_neto` float NOT NULL DEFAULT '0',
  `telefono` varchar(60) NOT NULL,
  `factor_cambio` float NOT NULL DEFAULT '000',
  `fecha_pedido` date NOT NULL DEFAULT '2000-01-01',
  `pedido` varchar(10) NOT NULL,
  `condicion_pago` varchar(7) NOT NULL,
  `hora` time NOT NULL,
  `monto_divisa` float NOT NULL DEFAULT '0',
  `despachado` varchar(20) NOT NULL,
  `dir_despacho` varchar(120) NOT NULL,
  `estacion` varchar(20) NOT NULL,
  `renglones` int(11) NOT NULL DEFAULT '0',
  `saldo_pendiente` float NOT NULL DEFAULT '0',
  `ano_relacion` varchar(4) NOT NULL,
  `comprobante_retencion_islr` varchar(10) NOT NULL,
  `dias_validez` int(11) NOT NULL DEFAULT '0',
  `situacion` varchar(10) NOT NULL,
  `signo` int(11) NOT NULL DEFAULT '0',
  `serie` varchar(3) NOT NULL,
  `tarifa` varchar(1) NOT NULL,
  `documento_nombre` varchar(16) NOT NULL,
  `subtotal_impuesto` float NOT NULL DEFAULT '0',
  `subtotal` float NOT NULL DEFAULT '0',
  `planilla` varchar(15) NOT NULL,
  `expediente` varchar(15) NOT NULL,
  `anticipo_iva` float NOT NULL DEFAULT '0',
  `terceros_iva` float NOT NULL DEFAULT '0',
  `neto` float NOT NULL DEFAULT '0',
  `costo` float NOT NULL DEFAULT '0',
  `utilidad` float NOT NULL DEFAULT '0',
  `utilidadp` float NOT NULL DEFAULT '0',
  `documento_tipo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas_detalle`
--

CREATE TABLE IF NOT EXISTS `ventas_detalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `venta_id` int(11) NOT NULL,
  `documento_id` int(11) NOT NULL,
  `producto_id` int(11) NOT NULL,
  `cantidad` float NOT NULL DEFAULT '00',
  `empaque` varchar(15) NOT NULL,
  `precio_neto` float NOT NULL DEFAULT '0',
  `descuento1p` float NOT NULL DEFAULT '0',
  `descuento2p` float NOT NULL DEFAULT '0',
  `descuento3p` float NOT NULL DEFAULT '0',
  `descuento1` float NOT NULL DEFAULT '0',
  `descuento2` float NOT NULL DEFAULT '0',
  `descuento3` float NOT NULL DEFAULT '0',
  `costo_venta` float NOT NULL DEFAULT '0',
  `total_neto` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `estatus_anulado` tinyint(1) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `deposito` varchar(20) NOT NULL,
  `signo` int(11) NOT NULL DEFAULT '0',
  `precio_final` float NOT NULL DEFAULT '0',
  `decimales` varchar(1) NOT NULL,
  `contenido_empaque` int(11) NOT NULL DEFAULT '0',
  `cantidad_und` float NOT NULL DEFAULT '00',
  `precio_und` float NOT NULL DEFAULT '0',
  `costo_und` float NOT NULL DEFAULT '0',
  `utilidad` float NOT NULL DEFAULT '0',
  `utilidadp` float NOT NULL DEFAULT '0',
  `precio_item` float NOT NULL DEFAULT '0',
  `estatus_garantia` tinyint(1) NOT NULL,
  `dias_garantia` int(11) NOT NULL DEFAULT '0',
  `detalle` varchar(160) NOT NULL,
  `precio_sugerido` float NOT NULL DEFAULT '0',
  `tasa` float NOT NULL,
  `cobranzap` float NOT NULL DEFAULT '0',
  `ventasp` float NOT NULL DEFAULT '0',
  `cobranzap_vendedor` float NOT NULL DEFAULT '0',
  `ventasp_vendedor` float NOT NULL DEFAULT '0',
  `cobranza` float NOT NULL DEFAULT '0',
  `ventas` float NOT NULL DEFAULT '0',
  `cobranza_vendedor` float NOT NULL DEFAULT '0',
  `ventas_vendedor` float NOT NULL DEFAULT '0',
  `costo_promedio_und` float NOT NULL DEFAULT '0',
  `costo_compra` float NOT NULL DEFAULT '0',
  `estatus_checked` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas_guias`
--

CREATE TABLE IF NOT EXISTS `ventas_guias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` int(11) NOT NULL,
  `documento` varchar(14) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `tasa_retencion` float NOT NULL DEFAULT '0',
  `retencion` float NOT NULL DEFAULT '0',
  `fecha_relacion` date NOT NULL DEFAULT '2000-01-01',
  `ano_relacion` varchar(4) NOT NULL,
  `mes_relacion` varchar(2) NOT NULL,
  `renglones` int(11) NOT NULL DEFAULT '0',
  `documento_nombre` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas_guias_detalle`
--

CREATE TABLE IF NOT EXISTS `ventas_guias_detalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `venta_guia` int(11) NOT NULL,
  `documento_id` int(11) NOT NULL,
  `documento` varchar(14) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `tasa_retencion` float NOT NULL DEFAULT '0',
  `retencion` float NOT NULL DEFAULT '0',
  `fecha_retencion` date NOT NULL DEFAULT '2000-01-01',
  `comprobante` varchar(14) NOT NULL,
  `tipo_retencion` varchar(2) NOT NULL,
  `aplica` varchar(10) NOT NULL,
  `control` varchar(10) NOT NULL,
  `tasa` float NOT NULL DEFAULT '0',
  `signo` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas_retenciones`
--

CREATE TABLE IF NOT EXISTS `ventas_retenciones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `documento` varchar(14) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `tasa_retencion` float NOT NULL DEFAULT '0',
  `retencion` float NOT NULL DEFAULT '0',
  `cliente_id` int(11) NOT NULL,
  `fecha_relacion` date NOT NULL DEFAULT '2000-01-01',
  `ano_relacion` varchar(4) NOT NULL,
  `mes_relacion` varchar(2) NOT NULL,
  `renglones` int(11) NOT NULL DEFAULT '0',
  `documento_nombre` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas_retenciones_detalle`
--

CREATE TABLE IF NOT EXISTS `ventas_retenciones_detalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `venta_retencione` int(11) NOT NULL,
  `documento_id` int(11) NOT NULL,
  `documento` varchar(14) NOT NULL,
  `fecha` date NOT NULL DEFAULT '2000-01-01',
  `tipo` varchar(2) NOT NULL,
  `exento` float NOT NULL DEFAULT '0',
  `base` float NOT NULL DEFAULT '0',
  `impuesto` float NOT NULL DEFAULT '0',
  `total` float NOT NULL DEFAULT '0',
  `tasa_retencion` float NOT NULL DEFAULT '0',
  `retencion` float NOT NULL DEFAULT '0',
  `fecha_retencion` date NOT NULL DEFAULT '2000-01-01',
  `comprobante` varchar(14) NOT NULL,
  `tipo_retencion` varchar(2) NOT NULL,
  `aplica` varchar(10) NOT NULL,
  `control` varchar(10) NOT NULL,
  `tasa` float NOT NULL,
  `signo` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
