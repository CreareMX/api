﻿using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Purchases;
using EssentialCore.Entities;

namespace CommonCore.Entities.Purchases
{
    public class OrdenCompra : BaseEntityLongId, IOrdenCompra
    {
        public long IdCliente { get; set; }
        public Persona Cliente { get; set; }
        public long IdEmpleadoCrea { get; set; }
        public Persona EmpleadoCrea { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string FormaEnvio { get; set; }
        public long IdAlmacen { get; set; }
        public Almacen Almacen { get; set; }
        public long? IdSucursal { get; set; }
        public Sucursal Sucursal { get; set; }
        public string Comentarios { get; set; }
        public long IdEstado { get; set; }
        public Estado Estado { get; set; }
        public List<DetalleOrdenCompra> Detalles { get; set; }
        public long? IdEmpleadoAutoriza { get; set; }
        public Persona EmpleadoAutoriza { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
    }
}
