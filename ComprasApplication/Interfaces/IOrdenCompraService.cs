﻿using ComprasApplication.Dtos;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace ComprasApplication.Interfaces
{
    public interface IOrdenCompraService : IService<IOrdenCompraRepository, OrdenCompra, long, OrdenCompraDto>
    {
    }
}
