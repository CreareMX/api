﻿using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ContabilidadInfraestructure.Repository
{
    public class AbonoCuentaPorPagarRepository : BaseRepository<AbonoCuentaPorPagar, long>, IAbonoCuentaPorPagarRepository
    {
        public AbonoCuentaPorPagarRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}
