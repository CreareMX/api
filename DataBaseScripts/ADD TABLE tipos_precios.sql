CREATE TABLE tipo_precio(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							varchar(50)			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint tipo_precio_pk primary key (id),
	constraint tipo_precio_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint tipo_precio_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
)

ALTER TABLE precios ADD id_tipo_precio bigint;
ALTER TABLE precios ADD CONSTRAINT precios_tipo_precio_fk foreign key (id_tipo_precio) references tipo_precio(id);

INSERT INTO tipo_precio(nombre, fecha_creacion, id_usuario_creacion)
	VALUES('MENUDEO', NOW(), 1);

UPDATE precios SET id_tipo_precio = 1;

ALTER TABLE precios MODIFY id_tipo_precio bigint NOT NULL;