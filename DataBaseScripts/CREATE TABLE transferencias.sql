create table transferencias(
	id								BIGINT			NOT NULL	AUTO_INCREMENT,		
	id_entrada_almacen				BIGINT			NOT NULL,
	id_salida_almacen				BIGINT			NOT NULL,
	id_usuario_transfiere			BIGINT			NOT NULL,
	fecha_tranferencia				DATETIME		NOT NULL,
	activo							BIT				NOT NULL	default 1,
	fecha_creacion					DATETIME		NOT NULL,
	fecha_ultima_actualizacion		DATETIME,
	id_usuario_creacion				BIGINT			NOT NULL,
	id_usuario_ultima_actualizacion	BIGINT,
	constraint transferencias_pk primary key (id),
	constraint transferencias_entrada_fk foreign key (id_entrada_almacen) references entradas_almacen(id),
	constraint transferencias_salida_fk foreign key (id_salida_almacen) references salidas_almacen(id),
	constraint transferencias_usuario_transfiere_fk foreign key (id_usuario_transfiere) references usuarios(id),
	constraint transferencias_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint transferencias_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
)