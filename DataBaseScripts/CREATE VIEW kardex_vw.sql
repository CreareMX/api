create view kardex_vw as
select	
	rnd,
	RANK() OVER(ORDER BY rnd, id_almacen, id_producto, id_unidad) as id,
	id_almacen,
	almacen,
	id_producto,	
	producto,
	codigo_producto,
	codigo_barras,
	id_unidad,
	unidad,
	entrada,
	fecha_entrada,
	salida,
	fecha_salida,
	id_estado,
	estado,
	id_concepto,
	concepto
from (
	select 
		uuid() as rnd,
		p.id as id_producto,	
		p.nombre as producto,
		p.codigo_producto,
		p.codigo_barras,
		u.id as id_unidad,
		u.nombre as unidad,
		ea.cantidad as entrada,
		ea.fecha_entrada,
		0 as salida,
		null as fecha_salida,
		a.id as id_almacen,
		a.nombre as almacen,
		c.id as id_concepto,
		c.nombre as concepto,
		e.id as id_estado,
		e.nombre as estado
	from productos p 
		left join entradas_almacen ea on p.id = ea.id_producto 
		inner join unidades u on ea.id_unidad = u.id
		inner join almacenes a on ea.id_almacen = a.id
		inner join estados e on ea.id_estado = e.id
		inner join conceptos c on ea.id_concepto = c.id
	union all
	select 
		uuid() as rnd,
		p.id as id_producto,	
		p.nombre as producto,
		p.codigo_producto,
		p.codigo_barras,
		u.id as id_unidad,
		u.nombre as unidad,
		0 as entrada,
		null as fecha_entrada,
		sa.cantidad as salida,
		sa.fecha_salida,
		a.id as id_almacen,
		a.nombre as almacen,
		c.id as id_concepto,
		c.nombre as concepto,
		e.id as id_estado,
		e.nombre as estado
	from productos p 
		left join salidas_almacen sa  on p.id = sa.id_producto 
		inner join unidades u on sa.id_unidad = u.id
		inner join almacenes a on sa.id_almacen = a.id
		inner join estados e on sa.id_estado = e.id
		inner join conceptos c on sa.id_concepto = c.id
) as kardex
order by id_almacen, id_producto, id_unidad