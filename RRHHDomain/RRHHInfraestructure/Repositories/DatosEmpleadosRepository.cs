﻿using EssentialCore.DbContexts;
using EssentialCore.Repositories;
using Microsoft.EntityFrameworkCore;
using RRHHCore.Entities;
using RRHHCore.Interfaces.Repositories;

namespace RRHHInfraestructure.Repositories
{
    public class DatosEmpleadosRepository : BaseRepository<DatosEmpleado, long>, IDatosEmpleadoRepository
    {
        public DatosEmpleadosRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override DatosEmpleado GetById(long id) => Context.Set<DatosEmpleado>()
                                                            .Include(p => p.Empleado)
                                                            .Include(p => p.Puesto)
                                                            .Include(p => p.Departamento)
                                                            .FirstOrDefault(p => p.Id == id);
    }
}
