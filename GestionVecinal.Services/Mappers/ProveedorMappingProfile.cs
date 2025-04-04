using AutoMapper;
using GestionVecinal.Models.DTO;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services.Mappers
{
    public class ProveedorMappingProfile : Profile
    {
        public ProveedorMappingProfile()
        {
            CreateMap<Proveedor, ProveedorDTO>();
            CreateMap<ProveedorDTO, Proveedor>();
        }
    }
}
