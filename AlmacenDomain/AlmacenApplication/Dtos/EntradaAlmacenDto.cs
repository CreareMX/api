﻿using AlmacenCore.Interfaces.Entities;
using CommonApplication.Dtos;

namespace AlmacenApplication.Dtos
{
    public class EntradaAlmacenDto : IEntradaAlmacen
    {
        public long? Id { get; set; }
        public long IdAlmacen { get; set; }
        public AlmacenDto Almacen { get; set; }
        public long IdProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public long IdUnidad { get; set; }
        public UnidadDto Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaEntrada { get; set; }
    }
}
