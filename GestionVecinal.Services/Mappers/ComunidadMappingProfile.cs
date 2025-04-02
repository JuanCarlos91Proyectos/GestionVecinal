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
    public class ComunidadMappingProfile : Profile
    {
        public ComunidadMappingProfile()
        {
            CreateMap<Comunidad, ComunidadDTO>();
            CreateMap<ComunidadDTO, Comunidad>();
        }
    }
}
