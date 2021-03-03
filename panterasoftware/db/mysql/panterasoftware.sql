-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 24-09-2015 a las 17:28:28
-- Versión del servidor: 5.5.16
-- Versión de PHP: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `panterasoftware`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sistema_empresas`
--

CREATE TABLE IF NOT EXISTS `sistema_empresas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(5) NOT NULL,
  `nombre` varchar(150) NOT NULL,
  `cadena_conexion` text NOT NULL,
  `activa` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Volcado de datos para la tabla `sistema_empresas`
--

INSERT INTO `sistema_empresas` (`id`, `codigo`, `nombre`, `cadena_conexion`, `activa`) VALUES
(1, '00001', 'demo', 'server=127.0.0.1;dataBase=00001;Uid=root;pwd=', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sistema_estados`
--

CREATE TABLE IF NOT EXISTS `sistema_estados` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sistema_funciones`
--

CREATE TABLE IF NOT EXISTS `sistema_funciones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sistema_mensajes`
--

CREATE TABLE IF NOT EXISTS `sistema_mensajes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `detalle` varchar(120) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=71 ;

--
-- Volcado de datos para la tabla `sistema_mensajes`
--

INSERT INTO `sistema_mensajes` (`id`, `detalle`, `tipo`) VALUES
(1, 'Error en los datos suministrados.', '1'),
(2, 'Dato duplicado', '1'),
(3, 'Código del Usuario o Clave no registrada.', '1'),
(4, 'Usuario Inactivo.', '1'),
(5, 'Datos guardados con éxito.', '0'),
(6, 'Imposible guardar imagen.', '1'),
(7, 'No se encontraron resultados.', '0'),
(8, 'Código ya registrado.', '1'),
(9, 'Depósito ya registrado.', '1'),
(10, 'Imposible eliminar el registro debido a que el mismo posee movimientos.', '1'),
(11, 'La categoria del producto <Bien de Servicio> no permite el manejo de depositos.', '1'),
(12, 'No se puede eliminar un depósito con existencia.', '1'),
(13, 'El producto no maneja seriales.', '1'),
(14, 'Eliminación del registro con éxito.', '0'),
(15, 'El Documento ya se encuentra anulado.', '1'),
(16, 'El Documento posee movimientos. Anule primero los movimientos.', '1'),
(17, 'El monto disponible por Anticipo del cliente es insuficiente.', '1'),
(18, 'El monto recibido es menor a el monto a cancelar.', '1'),
(19, 'No existen documentos a procesar.', '1'),
(20, 'Documento Aplica no puede estar vacio.', '1'),
(21, 'Documento no puede estar vacio. ', '1'),
(22, 'Total del Documento no puede ser cero (0).', '1'),
(23, 'No cuadran los montos de Anticipo y Monto Recibido.', '1'),
(24, 'Documento anulado con éxito.', '0'),
(25, 'Precio del Producto no permitido.', '1'),
(26, 'Precio del Producto por debajo del costo.', '1'),
(27, 'CI/RIF ya registrado.', '1'),
(28, 'No se encuentra el código (VENTAS) en Conceptos de Movimientos de Inventario.', '1'),
(29, 'No se encuentra el código (DEV_VENTAS) en Conceptos de Movimientos de Inventario.', '1'),
(30, 'No se encuentra el código (SALIDAS) en Conceptos de Movimientos de Inventario.', '1'),
(31, 'Serie Fiscal no registrada.', '1'),
(32, 'Serie Fiscal Inactiva.', '1'),
(33, 'Debe completar el dato Aplica Documento.', '1'),
(34, 'No existen renglones en el documento para procesar.', '1'),
(35, 'Debe completar los datos fiscales del cliente (Nombre,CI/RIF,Dirección)', '1'),
(36, 'Saldo restante excede del crédito disponible. ', '1'),
(37, 'Existe un límite de documentos pendientes para este cliente.', '1'),
(38, 'El cliente no posee la opción de crédito activada.', '1'),
(39, 'Cantidad excede del disponible.', '1'),
(40, 'Cantidad distinta a seriales registrados.', '1'),
(41, 'Serial no registrado para este producto.', '1'),
(42, 'El serial ya se encuentra seleccionado.', '1'),
(43, 'Tope máximo de seriales.', '1'),
(44, 'El producto no es de tipo compuesto.', '1'),
(45, 'No se encuentra registrado el documento en el sistema.', '1'),
(46, 'Tasa de Retención invalida', '1'),
(47, 'No existe un formato de impresión seleccionado', '1'),
(48, 'Ha ocurrido un error al ejecutar el proceso.', '1'),
(49, 'Proceso efectuado con éxito.', '0'),
(50, 'Ha ocurrido un error en el dispositivo de impresión.', '1'),
(51, 'Debe completar los datos número de Documento y Control', '1'),
(52, 'No existe el depósito del producto especificado.', '1'),
(53, 'Proveedor Inactivo.', '1'),
(54, 'El producto no posee precio.', '1'),
(55, 'Código no registrado en el sistema.', '1'),
(56, 'Producto inactivo.', '1'),
(57, 'Existen renglones actualmente en el documento.', '1'),
(58, 'Debe especificar el concepto de movimiento de inventario.', '1'),
(59, 'Clave Invalida', '1'),
(60, 'Tope maximo de usuarios conectados', '1'),
(61, 'El rif o serial de la impresora no concuerdan con el registrado en el sistema.', '1'),
(62, 'No tiene permiso para esta función', '1'),
(63, 'Cantidad Invalida.', '1'),
(64, 'Código del vendedor no registrado.', '1'),
(65, 'Vendedor inactivo.', '1'),
(66, 'Cuenta no registrada.', '1'),
(67, 'Cuenta inactiva.', '1'),
(68, 'Cuenta abierta.', '1'),
(69, 'Documento generado con exito. Utilice el boton Correo para efectuar el envio.', '0'),
(70, '', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sistema_modulos`
--

CREATE TABLE IF NOT EXISTS `sistema_modulos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `nombre` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Volcado de datos para la tabla `sistema_modulos`
--

INSERT INTO `sistema_modulos` (`id`, `codigo`, `nombre`) VALUES
(1, '01', 'Clientes'),
(2, '02', 'Proveedores'),
(3, '03', 'Inventario'),
(4, '04', 'Ctas. x Cobrar'),
(5, '05', 'Ctas. x Pagar'),
(6, '06', 'Caja y Bancos'),
(7, '07', 'Compras'),
(8, '08', 'Ventas'),
(9, '09', 'Vendedores'),
(10, '10', 'Producción'),
(11, '11', 'Web'),
(12, '12', 'Configuración');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sistema_periodo_mensual`
--

CREATE TABLE IF NOT EXISTS `sistema_periodo_mensual` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` varchar(2) NOT NULL,
  `mes` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
