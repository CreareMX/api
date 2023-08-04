ALTER TABLE entradas_almacen ADD id_estado BIGINT;
ALTER TABLE entradas_almacen ADD CONSTRAINT entrada_alamacen_estado_fk FOREIGN KEY (id_estado) REFERENCES estados(id);

ALTER TABLE salidas_almacen ADD id_estado BIGINT;
ALTER TABLE salidas_almacen ADD CONSTRAINT salida_alamacen_estado_fk FOREIGN KEY (id_estado) REFERENCES estados(id); 