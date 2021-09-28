DROP DATABASE segundoparcial;
CREATE DATABASE segundoparcial;
USE segundoparcial;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `consultaProveedores` ()  BEGIN
    select codigo_proveedor as ID, nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor from proveedores; 
END$$

DELIMITER ; 

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `consultaCompras` ()  BEGIN
    select documento_compraenca as ID,  codigo_proveedor, fecha_compraenca, total_compraenca, estatus_compraenca  from compras_encabezado; 
END$$

DELIMITER ;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ingresoProveedores` (IN `codigo_proveedor` VARCHAR(5), IN `nombre_proveedor` VARCHAR(60), IN `direccion_proveedor` VARCHAR(60), IN `telefono_proveedor` VARCHAR(50), IN  `nit_proveedor` VARCHAR(50), IN `estatus_proveedor` VARCHAR(1))  BEGIN
	insert into proveedores (codigo_proveedor, nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor) values (codigo_proveedor, nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor);
END$$

DELIMITER ; 


DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ingresoCompras` (IN `documento_compraenca` VARCHAR(10), IN `codigo_proveedor` VARCHAR(5), IN `fecha_compraenca` VARCHAR(20), IN `total_compraenca` FLOAT(10,2), IN  `estatus_compraenca` VARCHAR(1))  BEGIN
	insert into compras_encabezado (documento_compraenca, codigo_proveedor, fecha_compraenca, total_compraenca) values (documento_compraenca, codigo_proveedor, fecha_compraenca, total_compraenca);
END$$

DELIMITER ; 

create table if not exists proveedores
(
	codigo_proveedor VARCHAR(5) PRIMARY KEY,
    nombre_proveedor VARCHAR(60),
    direccion_proveedor VARCHAR(60),
    telefono_proveedor VARCHAR(50),
    nit_proveedor VARCHAR(50),
    estatus_proveedor VARCHAR(1)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists lineas
(
	codigo_linea VARCHAR(5) PRIMARY KEY,
    nombre_linea VARCHAR(60),
    estatus_linea VARCHAR(1)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists marcas
(
	codigo_marca VARCHAR(5) PRIMARY KEY,
    nombre_marca VARCHAR(60),
    estatus_marca VARCHAR(1)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists productos
(
	codigo_producto VARCHAR(18) PRIMARY KEY,
    nombre_producto VARCHAR(60),
    codigo_linea VARCHAR(5),
    codigo_marca VARCHAR(5),
    existencia_producto FLOAT(10,2),
    estatus_producto VARCHAR(1),
    FOREIGN KEY (codigo_linea) REFERENCES lineas(codigo_linea),
    FOREIGN KEY (codigo_marca) REFERENCES marcas(codigo_marca)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists bodegas
(
	codigo_bodega VARCHAR(5) PRIMARY KEY,
    nombre_bodega VARCHAR(60),
    estatus_bodega VARCHAR(1)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists existencias
(
	codigo_bodega VARCHAR(5),
    nombre_bodega VARCHAR(60),
    codigo_producto VARCHAR(18),
    saldo_existencia FLOAT(10,2),
    PRIMARY KEY (codigo_bodega, codigo_producto),
	FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists compras_encabezado
(
	documento_compraenca VARCHAR(10) PRIMARY KEY,
    codigo_proveedor VARCHAR(5),
    fecha_compraenca VARCHAR(20),
	total_compraenca FLOAT(10,2),
    estatus_compraenca VARCHAR(1),
    FOREIGN KEY (codigo_proveedor) REFERENCES proveedores(codigo_proveedor)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists compras_detalle
(
	documento_compraenca VARCHAR(10),
    codigo_producto VARCHAR(18),
    cantidad_compradet FLOAT(10,2),
    costo_compradet FLOAT(10,2),
	codigo_bodega VARCHAR(5),
    PRIMARY KEY (documento_compraenca, codigo_producto),
    FOREIGN KEY (documento_compraenca) REFERENCES compras_encabezado(documento_compraenca),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto),
    FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

create table if not exists pedido
(
	codigo_pedido VARCHAR(5) PRIMARY KEY,
    codigo_proveedor VARCHAR(5),
    nombre_proveedor VARCHAR(60),
    codigo_producto VARCHAR(18),
    nombre_producto VARCHAR(60),
    codigo_bodega VARCHAR(5),
    nombre_bodega VARCHAR(60),
    FOREIGN KEY (codigo_proveedor) REFERENCES proveedores(codigo_proveedor),
	FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto)
) ENGINE=INNODB DEFAULT CHARSET=latin1;