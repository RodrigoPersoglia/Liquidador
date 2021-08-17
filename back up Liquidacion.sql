-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.6.26 - MySQL Community Server (GPL)
-- SO del servidor:              Win32
-- HeidiSQL Versión:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;    
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para liquidacion
CREATE DATABASE IF NOT EXISTS `liquidacion` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `liquidacion`;

-- Volcando estructura para procedimiento liquidacion.AgregarCategoria
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarCategoria`(
	IN `p1` int,
	IN `p2` varchar(60),
	IN `p3` decimal(15,3),
	IN `p4` int
,
	IN `p5` INT
)
BEGIN
START TRANSACTION;
insert into categoria (numero,descripcion,importe,tipoContrato_ID,convenio_ID)
values (p1,p2,p3,p4,p5);
COMMIT;

END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.AgregarConvenio
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarConvenio`(
	IN `p1` varchar(50),
	IN `p2` varchar(50),
	IN `p3` int ,
	IN `p4` int
)
BEGIN
START TRANSACTION;
insert into convenio (codigo,descripcion,numero,año)
values (p1,p2,p3,p4);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.AgregarEmpleado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarEmpleado`(
	IN `p1` int,
	IN `p2` varchar(100),
	IN `p3` varchar(100),
	IN `p4` varchar(45),
	IN `p5` int(8),
	IN `p6` int(2),
	IN `p7` int(8),
	IN `p8` int (1),
	IN `p9` varchar(45),
	IN `p10` varchar(45),
	IN `p11` varchar(45),
	IN `p12` date,
	IN `p13` varchar(45),
	IN `p14` varchar(45),
	IN `p15` date,
	IN `p16` int,
	IN `p17` tinyint,
	IN `p18` date,
	IN `p19` decimal(20,3),
	IN `p20` int,
	IN `p21` int,
	IN `p22` int,
	IN `p23` int,
	IN `p24` int,
	IN `p25` int
)
BEGIN
START TRANSACTION;
insert into empleado(
legajo,nombre,apellido,tipoDNI,numeroDNI,cuil1,cuil2,cuil3,direccion,localidad,provincia,
fechaNacimiento,telefono,celular,fechaIngreso,mesesAnteriores,activo,fechaBaja,sueldoAcordado,
turno_ID,obraSocial_ID,tipoContrato_ID,categoria_ID,sucursal_ID,convenio_ID
)
values (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.AgregarObraSocial
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarObraSocial`(
	IN `p1` int,
	IN `p2` varchar(100),
	IN `p3` varchar(40)
)
BEGIN
START TRANSACTION;
insert into obraSocial (numero,descripcion,abreviatura)
values (p1,p2,p3);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.AgregarSucursal
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarSucursal`(p1 int,p2 varchar(45),p3 varchar(45),p4 varchar(45),p5 varchar(45),p6 varchar(45),p7 varchar(45))
insert into sucursal (numero,nombre,direccion,localidad,provincia,tel1,tel2)
values (p1,p2,p3,p4,p5,p6,p7)//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.AgregarTurno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarTurno`(
	IN `p1` varchar(45),
	IN `p2` varchar(10),
	IN `p3` varchar(10)
)
BEGIN
START TRANSACTION;
insert into turno (descripcion,horaInicio,horaFin)
values (p1,p2,p3);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.buscar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscar`(
	IN `campo1` varchar(100),
	IN `campo2` varchar(100),
	IN `tabla` varchar(100),
	IN `busqueda` varchar(100)

)
BEGIN
set @p1 =  campo1;
set @P2 = campo2;
select id,campo1,campo2
from turno t
where @p1 = busqueda;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.BuscarObraSocial
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscarObraSocial`(
	IN `p1` VARCHAR(100)
)
select *
from obrasocial os
where os.numero like  concat ('%',p1, '%') or os.descripcion like  concat ('%',p1, '%')
order by os.numero//
DELIMITER ;

-- Volcando estructura para tabla liquidacion.categoria
CREATE TABLE IF NOT EXISTS `categoria` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `importe` decimal(12,3) NOT NULL,
  `tipoContrato_ID` int(11) NOT NULL,
  `convenio_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `numero_UNIQUE` (`numero`,`tipoContrato_ID`,`convenio_ID`),
  KEY `fk_categoria_tipoContrato1_idx` (`tipoContrato_ID`),
  KEY `fk_categoria_convenio` (`convenio_ID`),
  CONSTRAINT `fk_categoria_convenio` FOREIGN KEY (`convenio_ID`) REFERENCES `convenio` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_categoria_tipoContrato1` FOREIGN KEY (`tipoContrato_ID`) REFERENCES `tipocontrato` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.categoria: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
REPLACE INTO `categoria` (`ID`, `numero`, `descripcion`, `importe`, `tipoContrato_ID`, `convenio_ID`) VALUES
	(11, 1, 'Operario', 250.000, 2, 1),
	(13, 2, 'Opeario calificado', 260.500, 2, 1),
	(17, 1, 'Administrativo 1', 10000.000, 1, 1),
	(18, 2, 'Administrativo 2', 20000.000, 1, 1),
	(19, 3, 'Administrativo 3', 300000.000, 1, 1),
	(21, 1, 'Administrativo A', 48000.150, 4, 3),
	(22, 2, 'Administrativo B', 50000.800, 4, 3),
	(23, 3, 'Operario Multiple', 280.000, 2, 1),
	(24, 5, 'Operario Especializado', 500.150, 5, 3),
	(25, 1, 'operario Multiple', 600.330, 5, 3);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;

-- Volcando estructura para tabla liquidacion.conceptos
CREATE TABLE IF NOT EXISTS `conceptos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `importe` decimal(12,3) NOT NULL,
  `tipoContrato_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Conceptos_tipoContrato1_idx` (`tipoContrato_ID`),
  CONSTRAINT `fk_Conceptos_tipoContrato1` FOREIGN KEY (`tipoContrato_ID`) REFERENCES `tipocontrato` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.conceptos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `conceptos` DISABLE KEYS */;
/*!40000 ALTER TABLE `conceptos` ENABLE KEYS */;

-- Volcando estructura para tabla liquidacion.conceptosdetalle
CREATE TABLE IF NOT EXISTS `conceptosdetalle` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `importe` decimal(12,3) NOT NULL,
  `Conceptos_ID` int(11) NOT NULL,
  `liquidacion_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_ConceptosDetalle_Conceptos_idx` (`Conceptos_ID`),
  KEY `fk_ConceptosDetalle_liquidacion1_idx` (`liquidacion_ID`),
  CONSTRAINT `fk_ConceptosDetalle_Conceptos` FOREIGN KEY (`Conceptos_ID`) REFERENCES `conceptos` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ConceptosDetalle_liquidacion1` FOREIGN KEY (`liquidacion_ID`) REFERENCES `liquidacion` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.conceptosdetalle: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `conceptosdetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `conceptosdetalle` ENABLE KEYS */;

-- Volcando estructura para tabla liquidacion.convenio
CREATE TABLE IF NOT EXISTS `convenio` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(50) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `numero` int(11) NOT NULL,
  `año` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.convenio: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `convenio` DISABLE KEYS */;
REPLACE INTO `convenio` (`ID`, `codigo`, `descripcion`, `numero`, `año`) VALUES
	(1, 'CCUOM', 'CONVENIO COLECTIVO UOM', 5, 1975),
	(3, 'CCSMATA', 'CONVENIO COLECTIVO SMATA', 1778, 1980);
/*!40000 ALTER TABLE `convenio` ENABLE KEYS */;

-- Volcando estructura para procedimiento liquidacion.EliminarCategoria
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarCategoria`(p0 int)
delete from categoria 
where ID = p0//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.EliminarConvenio
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarConvenio`(p0 int)
delete from convenio 
where ID = p0//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.EliminarObraSocial
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarObraSocial`(p0 int)
delete from obrasocial 
where ID = p0//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.EliminarSucursal
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarSucursal`(p0 int)
delete from sucursal 
where ID = p0//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.EliminarTurno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarTurno`(p0 int)
delete from turno
where ID = p0//
DELIMITER ;

-- Volcando estructura para tabla liquidacion.empleado
CREATE TABLE IF NOT EXISTS `empleado` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `legajo` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `tipoDNI` varchar(45) NOT NULL,
  `numeroDNI` int(8) NOT NULL,
  `cuil1` int(2) NOT NULL,
  `cuil2` int(8) NOT NULL,
  `cuil3` int(1) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `localidad` varchar(45) NOT NULL,
  `provincia` varchar(45) NOT NULL,
  `fechaNacimiento` date NOT NULL,
  `telefono` varchar(45) NOT NULL,
  `celular` varchar(45) NOT NULL,
  `fechaIngreso` date NOT NULL,
  `mesesAnteriores` int(2) NOT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT '1',
  `fechaBaja` date DEFAULT NULL,
  `sueldoAcordado` decimal(20,3) NOT NULL,
  `turno_ID` int(11) NOT NULL,
  `obraSocial_ID` int(11) NOT NULL,
  `tipoContrato_ID` int(11) NOT NULL,
  `categoria_ID` int(11) NOT NULL,
  `sucursal_ID` int(11) NOT NULL,
  `convenio_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `legajo_UNIQUE` (`legajo`),
  KEY `fk_empleado_turno1_idx` (`turno_ID`),
  KEY `fk_empleado_obraSocial1_idx` (`obraSocial_ID`),
  KEY `fk_empleado_tipoContrato1_idx` (`tipoContrato_ID`),
  KEY `fk_empleado_categoria1_idx` (`categoria_ID`),
  KEY `fk_empleado_sucursal1_idx` (`sucursal_ID`),
  KEY `FK_empleado_convenio` (`convenio_ID`),
  CONSTRAINT `FK_empleado_convenio` FOREIGN KEY (`convenio_ID`) REFERENCES `convenio` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_categoria1` FOREIGN KEY (`categoria_ID`) REFERENCES `categoria` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_obraSocial1` FOREIGN KEY (`obraSocial_ID`) REFERENCES `obrasocial` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_sucursal1` FOREIGN KEY (`sucursal_ID`) REFERENCES `sucursal` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_tipoContrato1` FOREIGN KEY (`tipoContrato_ID`) REFERENCES `tipocontrato` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_turno1` FOREIGN KEY (`turno_ID`) REFERENCES `turno` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.empleado: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
REPLACE INTO `empleado` (`ID`, `legajo`, `nombre`, `apellido`, `tipoDNI`, `numeroDNI`, `cuil1`, `cuil2`, `cuil3`, `direccion`, `localidad`, `provincia`, `fechaNacimiento`, `telefono`, `celular`, `fechaIngreso`, `mesesAnteriores`, `activo`, `fechaBaja`, `sueldoAcordado`, `turno_ID`, `obraSocial_ID`, `tipoContrato_ID`, `categoria_ID`, `sucursal_ID`, `convenio_ID`) VALUES
	(1, 1, 'RODRIGO', 'PERSOGLIA', 'DNI', 34813823, 20, 34813823, 6, 'BARZI 719', 'VARELA', 'Buenos Aires', '2021-08-12', '1541709324', '43557120', '2021-08-12', 0, 1, NULL, 0.000, 1, 12, 1, 17, 1, 1),
	(2, 2, 'roberto', 'gomes', 'DNI', 34813824, 20, 34813823, 1, 'a', 'a', 'Capital Federal', '2021-08-12', 'a', 'a', '2021-08-12', 0, 1, NULL, 0.000, 5, 12, 4, 21, 1, 3),
	(3, 3, 'a', 'a', 'DNI', 1, 1, 1, 1, 'a', 'a', 'Buenos Aires', '2021-08-12', 'a', 'a', '2021-08-12', 15, 1, NULL, 98313.150, 1, 19, 4, 22, 1, 3),
	(4, 4, 'marcelo', 'alegre', 'DNI', 92111222, 20, 92111222, 6, 'san martin 1809', 'varela', 'Buenos Aires', '2000-01-12', '1', '1', '2021-08-12', 15, 1, NULL, 0.000, 1, 8, 5, 25, 1, 3),
	(5, 5, 'MARIA BELEN', 'WALTER', 'DNI', 38959263, 20, 38959263, 6, 'CALLE 15 A Nº 942', 'VARELA', 'Buenos Aires', '1995-07-09', '1541709324', '43557120', '2021-08-12', 0, 1, NULL, 11000.000, 1, 19, 4, 21, 1, 3);
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;

-- Volcando estructura para tabla liquidacion.empresa
CREATE TABLE IF NOT EXISTS `empresa` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `razonSocial` varchar(45) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `Localidad` varchar(45) NOT NULL,
  `Provincia` varchar(45) NOT NULL,
  `cp` varchar(45) NOT NULL,
  `cuit1` int(2) NOT NULL,
  `cuit2` int(8) NOT NULL,
  `cuit3` int(1) NOT NULL,
  `rubro` varchar(45) NOT NULL,
  `inicioActividad` date NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.empresa: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
REPLACE INTO `empresa` (`ID`, `razonSocial`, `direccion`, `Localidad`, `Provincia`, `cp`, `cuit1`, `cuit2`, `cuit3`, `rubro`, `inicioActividad`) VALUES
	(1, '.EXE Desarrollos Informáticos', 'CALLE 13', 'FCIO VARELA', 'Capital Federal', '1833', 25, 30000, 2, 'INFORMATICA', '2021-08-07');
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;

-- Volcando estructura para procedimiento liquidacion.HeidiSQL_temproutine_1
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `HeidiSQL_temproutine_1`(
	IN `p1` int,
	IN `p2` varchar(60),
	IN `p3` decimal(15,3),
	IN `p4` int
)
start transaction;//
DELIMITER ;

-- Volcando estructura para tabla liquidacion.liquidacion
CREATE TABLE IF NOT EXISTS `liquidacion` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `mes` int(2) NOT NULL,
  `periodo` int(1) NOT NULL,
  `emision` int(1) NOT NULL,
  `fechaPago` date NOT NULL,
  `lugarPago` varchar(45) NOT NULL,
  `empleado_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_liquidacion_empleado1_idx` (`empleado_ID`),
  CONSTRAINT `fk_liquidacion_empleado1` FOREIGN KEY (`empleado_ID`) REFERENCES `empleado` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.liquidacion: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `liquidacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `liquidacion` ENABLE KEYS */;

-- Volcando estructura para procedimiento liquidacion.ModificarCategoria
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarCategoria`(
	IN `p0` int,
	IN `p1` int,
	IN `p2` varchar(60),
	IN `p3` decimal(15,3)
,
	IN `p4` INT
)
BEGIN
START TRANSACTION;
update categoria c
SET
numero = p1,
descripcion = p2,
importe = p3,
convenio_ID = p4
where c.ID = p0;
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.ModificarConvenio
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarConvenio`(
	IN `p0` int,
	IN `p1` varchar(50),
	IN `p2` varchar(50),
	IN `p3` int ,
	IN `p4` int
)
BEGIN
START TRANSACTION;
update convenio c
SET
codigo = p1,
descripcion = p2,
numero = p3,
año = p4
where c.ID = p0;
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.modificarEmpresa
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `modificarEmpresa`(p0 int,p1 varchar(45),p2 varchar(45),p3 varchar(45),p4 varchar(45),p5 varchar(45),p6 int,p7 int,p8 int,p9 varchar(45),p10 date)
update empresa e
SET
razonSocial = p1,
direccion = p2,
localidad = p3,
provincia = p4,
cp = p5,
cuit1 = p6,
cuit2 = p7,
cuit3 = p8,
rubro = p9,
inicioActividad = p10

where e.ID = p0//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.ModificarObraSocial
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarObraSocial`(
	IN `p0` int,
	IN `p1` int,
	IN `p2` varchar(100),
	IN `p3` varchar(40)
)
BEGIN
START TRANSACTION;
update obrasocial os
SET
numero = p1,
descripcion = p2,
abreviatura = p3
where os.ID = p0;
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.ModificarSucursal
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarSucursal`(
	IN `p0` int,
	IN `p1` int,
	IN `p2` varchar(45),
	IN `p3` varchar(45),
	IN `p4` varchar(45),
	IN `p5` varchar(45),
	IN `p6` varchar(45),
	IN `p7` varchar(45)
)
BEGIN
START TRANSACTION;
update sucursal s 
SET
numero = p1,
nombre = p2,
direccion = p3,
localidad = p4,
provincia = p5,
tel1 = p6,
tel2 = p7
where s.ID = p0;
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.ModificarTurno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarTurno`(
	IN `p0` int,
	IN `p1` varchar(45),
	IN `p2` varchar(10),
	IN `p3` varchar(10)
)
BEGIN
START TRANSACTION;
update turno t
SET
descripcion = p1,
horaInicio = p2,
horaFin = p3
where t.ID = p0;
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para tabla liquidacion.obrasocial
CREATE TABLE IF NOT EXISTS `obrasocial` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `abreviatura` varchar(40) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `numero_UNIQUE` (`numero`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.obrasocial: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `obrasocial` DISABLE KEYS */;
REPLACE INTO `obrasocial` (`ID`, `numero`, `descripcion`, `abreviatura`) VALUES
	(7, 2, 'Empleados de Comercio', 'OSCECAC'),
	(8, 4, 'Omint', 'OMINT'),
	(12, 1, 'Union Obrera Metalurgica', 'OSUOMRA'),
	(19, 3, 'Personal Maestranza', 'MOOS');
/*!40000 ALTER TABLE `obrasocial` ENABLE KEYS */;

-- Volcando estructura para tabla liquidacion.sucursal
CREATE TABLE IF NOT EXISTS `sucursal` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `Localidad` varchar(45) NOT NULL,
  `Provincia` varchar(45) NOT NULL,
  `tel1` varchar(45) NOT NULL,
  `tel2` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.sucursal: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `sucursal` DISABLE KEYS */;
REPLACE INTO `sucursal` (`ID`, `numero`, `nombre`, `direccion`, `Localidad`, `Provincia`, `tel1`, `tel2`) VALUES
	(1, 1, 'CENTRAL', 'Remedios de Escalada de San Martin 1809', '9 de Abril', 'Buenos Aires', '4693-0122', '4693-0054');
/*!40000 ALTER TABLE `sucursal` ENABLE KEYS */;

-- Volcando estructura para tabla liquidacion.tipocontrato
CREATE TABLE IF NOT EXISTS `tipocontrato` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `convenio_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `numero_UNIQUE` (`numero`,`convenio_ID`),
  KEY `FK_tipocontrato_convenio` (`convenio_ID`),
  CONSTRAINT `FK_tipocontrato_convenio` FOREIGN KEY (`convenio_ID`) REFERENCES `convenio` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.tipocontrato: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `tipocontrato` DISABLE KEYS */;
REPLACE INTO `tipocontrato` (`ID`, `numero`, `descripcion`, `convenio_ID`) VALUES
	(1, 1, 'Mensual', 1),
	(2, 2, 'Jornal', 1),
	(4, 1, 'Mensual', 3),
	(5, 2, 'Jornal', 3);
/*!40000 ALTER TABLE `tipocontrato` ENABLE KEYS */;

-- Volcando estructura para tabla liquidacion.turno
CREATE TABLE IF NOT EXISTS `turno` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `horaInicio` varchar(10) NOT NULL,
  `horaFin` varchar(10) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla liquidacion.turno: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
REPLACE INTO `turno` (`ID`, `descripcion`, `horaInicio`, `horaFin`) VALUES
	(1, 'Mañana', '6:00', '15:00'),
	(2, 'Tarde', '15:00', '24:00'),
	(5, 'Noche', '23:00', '6:00'),
	(6, 'Oficina', '8:00', '9:00');
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;

-- Volcando estructura para procedimiento liquidacion.verCategoria
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verCategoria`(
	IN `p1` int
)
select *
from categoria c
where c.tipoContrato_ID = p1
order by c.numero//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.VerConvenio
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `VerConvenio`()
select *,concat (codigo,' - ',descripcion) as convenio
from convenio c
order by c.codigo//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.verEmpresa
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verEmpresa`()
select *
from empresa
limit 1//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.verObraSocial
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verObraSocial`()
select *
from Obrasocial os
order by os.numero//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.VerSucursales
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `VerSucursales`()
select *
from sucursal s
order by s.numero//
DELIMITER ;

-- Volcando estructura para procedimiento liquidacion.verTurno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verTurno`()
select *
from turno t
order by t.descripcion//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
