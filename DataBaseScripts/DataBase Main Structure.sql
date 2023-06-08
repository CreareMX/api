use sys;
/*drop database Mayoreo_Oriente;
create database Mayoreo_Oriente;
use Mayoreo_Oriente;*/

/*drop database Development;
create database Development;
use Development;*/

/*drop database CnSeguridad;
create database CnSeguridad;
use CnSeguridad;*/

CREATE TABLE permisos (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(50)			NOT NULL,
	descripcion						varchar(255)		NOT NULL,
	ruta_acceso						varchar(500),
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint permisos_pk primary key (id)
);
CREATE TABLE roles (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(50)			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint roles_pk primary key (id)
);
CREATE TABLE permisos_rol (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_rol							bigint,
	id_permiso						bigint				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint rol_permiso_pk primary key (id),
	constraint rol_permiso_permisos_fk foreign key (id_permiso) references permisos(id),
	constraint rol_permiso_roles_fk foreign key (id_rol) references roles(id)
);
CREATE TABLE usuarios (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre_usuario					varchar(50)			NOT NULL,
	contrasena						varchar(255)		NOT NULL,
	id_rol							bigint,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint usuarios_pk primary key (id),
	constraint usuarios_roles_fk foreign key (id_rol) references roles(id)
);
CREATE TABLE entidad_federativa (
  id								bigint				NOT NULL,
  nombre							varchar(150)		NOT NULL,
  constraint entidad_federativa_pk primary key (id)
);
CREATE TABLE secciones(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(50)			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint secciones_pk primary key (id),
	constraint secciones_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint secciones_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE sucursales(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(250)		NOT NULL,
	domicilio						varchar(1500)		NOT NULL,
	telefono						varchar(15),
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint sucuraless_pk primary key (id),
	constraint sucuraless_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint sucuraless_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE estados(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(50)			NOT NULL,
	id_seccion						bigint				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint estados_pk primary key (id),
	constraint estados_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint estados_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id),
	constraint estados_seccion_fk foreign key (id_seccion) references secciones(id)
);
CREATE TABLE tipos_personas(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(50)			NOT NULL,
	es_persona_moral				bit					NOT NULL	DEFAULT 0,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint tipos_personas_pk primary key (id),
	constraint tipos_personas_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint tipos_personas_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE categorias (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(50)			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint categorias_pk primary key (id),
	constraint categorias_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint categorias_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE datos_fiscales (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	razon_social					varchar(250)		NOT NULL,
	rfc								varchar(13),
	nombres							varchar(250),
	apellido_paterno				varchar(250),
	apellido_materno				varchar(250),
	calle							varchar(50),
	numero_exterior					varchar(50),
	numero_interior					varchar(50),
	cruzamientos					varchar(150),
	domicilio						varchar(2500),
	colonia 						varchar(150),
	codigo_postal					int					NOT NULL,
	id_entidad_federativa			bigint				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint datos_fiscales_pk primary key (id),	
	constraint datos_fiscales_entidad_federativa_fk foreign key (id_entidad_federativa) references entidad_federativa(id),
	constraint datos_fiscales_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint datos_fiscales_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE personas (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(250)		NOT NULL,
	email							varchar(250)		NOT NULL,
	telefono						varchar(10)			NOT NULL,
	sitio_web						varchar(250),
	id_tipo_persona					bigint				NOT NULL,
	id_datos_fiscales				bigint,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint personas_pk primary key (id),
	constraint personas_tipo_persona_fk foreign key (id_tipo_persona) references tipos_personas(id),
	constraint personas_datos_fiscales_fk foreign key (id_datos_fiscales) references datos_fiscales(id),
	constraint personas_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint personas_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE cuentas_por_cobrar (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	folio							varchar(150)		NOT NULL,
	id_cliente						bigint				NOT NULL,
	fecha_venta						datetime			NOT NULL,
	fecha_vencimiento				datetime			NOT NULL,
	monto							decimal(10,2)		NOT NULL,
	saldo							decimal(10,2)		NOT NULL,
	comentarios						text,
	id_estado						bigint				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint cuentas_por_cobrar_pk primary key (id),
	constraint cuentas_por_cobrar_personas_fk foreign key (id_cliente) references personas(id),
	constraint cuentas_por_cobrar_estados_fk foreign key (id_estado) references estados(id),
	constraint cuentas_por_cobrar_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint cuentas_por_cobrar_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE abonos_cuentas_por_cobrar(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_cuenta_por_cobrar			bigint				NOT NULL,
	fecha							datetime			NOT NULL,
	monto							decimal(10,2)		NOT NULL,
	comentarios						text,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint abonos_cuentas_por_cobrar_pk primary key (id),
	constraint abonos_cuentas_por_cobrar_CXC_fk foreign key (id_cuenta_por_cobrar) references cuentas_por_cobrar(id),
	constraint abonos_cuentas_por_cobrar_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint abonos_cuentas_por_cobrar_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE contactos (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(500)		NOT NULL,
	relacion						VARCHAR(250)		NOT NULL,
	email							varchar(250),
	telefono						varchar(25),
	id_persona						bigint				NOT NULL,	
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint contactos_pk primary key (id),
	constraint contactos_personas_fk foreign key (id_persona) references personas(id),
	constraint contactos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint contactos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE cuentas_por_pagar (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	folio							varchar(150)		NOT NULL,
	fecha_vencimiento				datetime			NOT NULL,
	monto							decimal(10,2)		NOT NULL,
	saldo							decimal(10,2)		NOT NULL,
	id_proveedor					bigint				NOT NULL,
	id_estado						bigint				NOT NULL,
	comentarios						text,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint cuentas_por_pagar_pk primary key (id),
	constraint cuentas_por_pagar_proveedores_fk foreign key (id_proveedor) references datos_fiscales(id),
	constraint cuentas_por_pagar_estados_fk foreign key (id_estado) references estados(id),
	constraint cuentas_por_pagar_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint cuentas_por_pagar_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE abonos_cuentas_por_pagar(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_cuenta_por_pagar				bigint				NOT NULL,
	fecha							datetime			NOT NULL,
	monto							decimal(10,2)		NOT NULL,
	comentarios						text,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint abonos_cuentas_por_pagar_pk primary key (id),
	constraint abonos_cuentas_por_pagar_CXP_fk foreign key (id_cuenta_por_pagar) references cuentas_por_pagar(id),
	constraint abonos_cuentas_por_pagar_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint abonos_cuentas_por_pagar_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE puestos (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(100)		NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint puestos_pk primary key (id),
	constraint puestos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint puestos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE departamentos (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(100)		NOT NULL,
	id_responsable					bigint				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint departamentos_pk primary key (id),
	constraint departamentos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint departamentos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE datos_empleados (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_persona						bigint				NOT NULL,
	id_puesto						bigint				NOT NULL,
	id_departamento					bigint				NOT NULL,
	salario							decimal(10,2)		NOT NULL,
	fecha_contratacion				datetime			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint datos_empleados_pk primary key (id),
	constraint datos_empleados_personas_fk foreign key (id_persona) references personas(id),
	constraint datos_empleados_puestos_fk foreign key (id_puesto) references puestos(id),
	constraint datos_empleados_departamentos_fk foreign key (id_departamento) references departamentos(id),
	constraint datos_empleados_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint datos_empleados_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE productos (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	codigo_producto					varchar(11)			NOT NULL,
	nombre							varchar(250)		NOT NULL,
	descripcion						text				NOT NULL,
	codigo_barras					bigint				NOT NULL,
	numero_serie					bigint,
	id_categoria					bigint,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint productos_pk primary key (id),
	constraint productos_categorias_fk foreign key (id_categoria) references categorias(id),
	constraint productos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint productos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE tipos_almacenes(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							VARCHAR(250)		NOT NULL,
	descripcion						text				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint tipo_almacen_pk primary key (id),
	constraint tipo_almacen_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint tipo_almacen_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE almacenes(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							VARCHAR(250)		NOT NULL,
	descripcion						text				NOT NULL,
	codigo							varchar(50)			NOT NULL,
	id_tipo_almacen					bigint				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint almacen_pk primary key (id),
	constraint almacen_tipo_fk foreign key (id_tipo_almacen) references tipos_almacenes(id),
	constraint almacen_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint almacen_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE unidades(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							VARCHAR(250)		NOT NULL,
	abreviatura						VARCHAR(15),
	descripcion						text				NOT NULL,
	contenido						decimal(10,2)		NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint unidades_pk primary key (id),
	constraint unidades_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint unidades_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE entradas_almacen (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_almacen						bigint				NOT NULL,
	id_producto						bigint				NOT NULL,
	cantidad						decimal(10,2)		NOT NULL,
	id_unidad						bigint				NOT NULL,
	fecha_entrada					datetime			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint entradas_almacen_pk primary key (id),
	constraint entradas_almacen_almacenes_fk foreign key (id_almacen) references almacenes(id),
	constraint entradas_almacen_productos_fk foreign key (id_producto) references productos(id),
	constraint entradas_almacen_unidades_fk foreign key (id_unidad) references unidades(id),
	constraint entradas_almacen_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint entradas_almacen_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE salidas_almacen (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_almacen						bigint				NOT NULL,
	id_producto						bigint				NOT NULL,
	cantidad						decimal(10,2)		NOT NULL,
	id_unidad						bigint				NOT NULL,
	fecha_salida					datetime			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint salidas_almacen_pk primary key (id),
	constraint salidas_almacen_almacenes_fk foreign key (id_almacen) references almacenes(id),
	constraint salidas_almacen_productos_fk foreign key (id_producto) references productos(id),
	constraint salidas_almacen_unidades_fk foreign key (id_unidad) references unidades(id),
	constraint salidas_almacen_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint salidas_almacen_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE ordenes (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_cliente						bigint				NOT NULL,
	id_empleado_crea				bigint				NOT NULL,
	fecha							datetime			NOT NULL,
	fecha_compromiso				datetime			NOT NULL,
	fecha_envio						datetime			NOT NULL,
	forma_envio						varchar(250)		NOT NULL,
	id_sucursal						bigint,
	comentarios						text				NOT NULL,
	id_estado						bigint				NOT NULL,
	fecha_autorizacion				datetime,
	id_empleado_autoriza			bigint,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint ordenes_pk primary key (id),
	constraint ordenes_personas_clientes_fk foreign key (id_cliente) references personas(id),
	constraint ordenes_personas_empleados_fk foreign key (id_empleado_crea) references personas(id),
	constraint ordenes_sucursal_fk foreign key (id_sucursal) references sucursales(id),
	constraint ordenes_estados_fk foreign key (id_estado) references estados(id),
	constraint ordenes_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint ordenes_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id),
	constraint ordenes_usuario_autoriza_fk foreign key (id_empleado_autoriza) references usuarios(id)
);
CREATE TABLE ordenes_detalle (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_orden						bigint				NOT NULL,
	id_producto						bigint				NOT NULL,
	cantidad						decimal(10,2)		NOT NULL,
	descuento						decimal(10,2),
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint ordenes_detalle_pk primary key (id),
	constraint ordenes_detalle_ordenes_fk foreign key (id_orden) references ordenes(id),
	constraint ordenes_detalle_productos_fk foreign key (id_producto) references productos(id),
	constraint ordenes_detalle_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint ordenes_detalle_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE precios(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_producto						bigint				NOT NULL,
	precio							decimal(10,2)		NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint precios_pk primary key (id),
	constraint precios_productos_fk foreign key (id_producto) references productos(id),
	constraint precios_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint precios_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE costos(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	costo							decimal(10,2)		NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint costos_pk primary key (id),
	constraint costos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint costos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);
CREATE TABLE proveedores_productos (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_producto						bigint				NOT NULL,
	id_proveedor					bigint				NOT NULL,
	id_costo						bigint				NOT NULL,	
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint proveedores_productos_pk primary key (id),
	constraint proveedores_productos_productos_fk foreign key (id_producto) references productos(id),
	constraint proveedores_productos_personas_fk foreign key (id_proveedor) references personas(id),
	constraint proveedores_productos_costos_fk foreign key (id_costo) references costos(id),
	constraint proveedores_productos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint proveedores_productos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);


INSERT INTO entidad_federativa (id, nombre) VALUES
(1, 'Aguascalientes'),
(2, 'Baja California'),
(3, 'Baja California Sur'),
(4, 'Campeche'),
(7, 'Chiapas'),
(8, 'Chihuahua'),
(9, 'Ciudad de México'),
(5, 'Coahuila'),
(6, 'Colima'),
(10, 'Durango'),
(11, 'Guanajuato'),
(12, 'Guerrero'),
(13, 'Hidalgo'),
(14, 'Jalisco'),
(16, 'Michoacán'),
(17, 'Morelos'),
(15, 'México'),
(18, 'Nayarit'),
(19, 'Nuevo León'),
(20, 'Oaxaca'),
(21, 'Puebla'),
(22, 'Querétaro'),
(23, 'Quintana Roo'),
(24, 'San Luis Potosí'),
(25, 'Sinaloa'),
(26, 'Sonora'),
(27, 'Tabasco'),
(28, 'Tamaulipas'),
(29, 'Tlaxcala'),
(30, 'Veracruz'),
(31, 'Yucatán'),
(32, 'Zacatecas');

INSERT INTO usuarios(nombre_usuario, contrasena, fecha_creacion, id_usuario_creacion)
	VALUES('admin', '8C6976E5 B5410415 BDE908BD 4DEE15DF B167A9C8 73FC4BB8 A81F6F2A B448A918', NOW(), 1);

INSERT INTO roles (nombre, fecha_creacion, id_usuario_creacion)
	VALUES('administrador', NOW(), 1);

UPDATE usuarios SET id_rol = 1 WHERE id = 1;

INSERT INTO secciones(nombre, fecha_creacion, id_usuario_creacion)
	VALUES('ORDENES DE COMRPA', NOW(), 1);

INSERT INTO estados(nombre,id_seccion, fecha_creacion, id_usuario_creacion) 
	VALUES('REQUISICION', 1, NOW(), 1);

alter table departamentos add constraint departamentos_empleados_fk foreign key (id_responsable) references usuarios(id);
alter table permisos add constraint permisos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id);
alter table roles add constraint roles_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id);
alter table permisos_rol add constraint permisos_rol_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id);
alter table permisos add constraint permisos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id);
alter table roles add constraint roles_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id);
alter table permisos_rol add constraint permisos_rol_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id);
ALTER TABLE usuarios MODIFY id_rol bigint NOT NULL;