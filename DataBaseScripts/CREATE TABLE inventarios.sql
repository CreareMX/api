CREATE TABLE inventario (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_almacen						bigint				NOT NULL,
	fecha_inicio					datetime			NOT NULL,
	id_usuario_inicio				bigint				NOT NULL,
	fecha_fin						datetime,
	id_usuario_fin					bigint,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint inventario_pk primary key (id),
	constraint inventario_almacenes_fk foreign key (id_almacen) references almacenes(id),
	constraint inventario_usuario_inicio_fk foreign key (id_usuario_inicio) references usuarios(id),
	constraint inventario_usuario_fin_fk foreign key (id_usuario_fin) references usuarios(id),
	constraint inventario_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint inventario_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);

CREATE TABLE inventario_detalle (
	id								bigint				NOT NULL	AUTO_INCREMENT,
	id_inventario					bigint				NOT NULL,
	id_producto						bigint				NOT NULL,	
	id_unidad						bigint				NOT NULL,
	cantidad						decimal(10,2)		NOT NULL,
	fecha							datetime			NOT NULL,
	activo							bit					NOT NULL	default 1,
	fecha_creacion					datetime			NOT NULL,
	fecha_ultima_actualizacion		datetime,
	id_usuario_creacion				bigint				NOT NULL,
	id_usuario_ultima_actualizacion	bigint,
	constraint inventario_detalle_pk primary key (id),
	constraint inventario_detalle_inventario_fk foreign key (id_inventario) references inventario(id),
	constraint inventario_detalle_productos_fk foreign key (id_producto) references productos(id),
	constraint inventario_detalle_unidades_fk foreign key (id_unidad) references unidades(id),
	constraint inventario_detalle_usuario_crea_fk foreign key (id_usuario_creacion) references usuarios(id),
	constraint inventario_detalle_usuario_actualiza_fk foreign key (id_usuario_ultima_actualizacion) references usuarios(id)
);