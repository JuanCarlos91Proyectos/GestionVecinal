﻿using GestionVecinal.Models.Common;
using GestionVecinal.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services.Interfaces
{
    public interface IViviendaService
    {
        Task<Response<List<ViviendaDTO>>> GetAsync(int comunidadId);
        Task<Response<bool>> AddAsync(ViviendaDTO vivienda);
    }
}
