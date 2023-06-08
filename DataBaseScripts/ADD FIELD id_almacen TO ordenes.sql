ALTER TABLE ordenes ADD id_almacen bigint not null;
ALTER TABLE ordenes ADD CONSTRAINT ordenes_almacen_fk foreign key (id_almacen) references almacenes(id);