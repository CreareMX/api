﻿using AlmacenCore.Interfaces.Entities;
using CommonCore.Entities;
using EssentialCore.Entities;

namespace AlmacenCore.Entities
{
    public class SalidaAlmacen : BaseEntityLongId, ISalidaAlmacen
    {
        public long IdAlmacen { get; set; }
        public Almacen Almacen { get; set; }
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
        public long IdUnidad { get; set; }
        public Unidad Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
