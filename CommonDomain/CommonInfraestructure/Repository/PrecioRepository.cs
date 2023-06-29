﻿using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class PrecioRepository : BaseRepository<Precio, long>, IPrecioRepository
    {
        public PrecioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}