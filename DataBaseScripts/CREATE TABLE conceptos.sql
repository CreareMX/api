CREATE TABLE conceptos(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	nombre							VARCHAR(250)		NOT NULL,
	descripcion						text				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint conceptos_pk primary key (id),
	constraint conceptos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint conceptos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);

ALTER TABLE entradas_almacen ADD id_concepto BIGINT;
ALTER TABLE entradas_almacen ADD CONSTRAINT entrada_alamacen_concepto_fk FOREIGN KEY (id_concepto) REFERENCES conceptos(id);

ALTER TABLE salidas_almacen ADD id_concepto BIGINT;
ALTER TABLE salidas_almacen ADD CONSTRAINT salida_alamacen_concepto_fk FOREIGN KEY (id_concepto) REFERENCES conceptos(id); 