ALTER TABLE usuarios ADD id_sucursal BIGINT;
ALTER TABLE usuarios ADD CONSTRAINT usuarios_sucursal_fk FOREIGN KEY (id_sucursal) REFERENCES sucursales(id);

ALTER TABLE almacenes  ADD id_sucursal BIGINT;
ALTER TABLE almacenes ADD CONSTRAINT almacenes_sucursal_fk FOREIGN KEY (id_sucursal) REFERENCES sucursales(id);