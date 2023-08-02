CREATE TABLE gastos_generales_fijos(
	id								bigint				NOT NULL	AUTO_INCREMENT,
	descripcion						text				NOT NULL,
	monto							decimal				NOT NULL,
	id_concepto						bigint				NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint gastos_fijos_pk primary key (id),
	constraint gastos_fijos_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint gastos_fijos_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id),
	constraint gastos_fijos_usuario_concepto_fk foreign key (id_concepto) references conceptos(id)
)