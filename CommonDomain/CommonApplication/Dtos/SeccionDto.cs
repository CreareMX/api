﻿using CommonCore.Interfaces.Entities;

namespace CommonApplication.Dtos
{
    public class SeccionDto : ISeccion
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
    }
}