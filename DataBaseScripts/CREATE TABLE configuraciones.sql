CREATE TABLE configuraciones(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							VARCHAR(250)		NOT NULL,
	descripcion						text				NOT NULL,
	valor							VARCHAR(250)			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint configuraciones_pk primary key (id),
	constraint configuraciones_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint configuraciones_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);