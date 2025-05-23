﻿using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public interface IComunidadesRepository : IBaseRepository
    {
        Task<List<Comunidad>> GetAsync();

        Task<bool> AddAsync(Comunidad comunidad);
    }
}
