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
    public class JuntaMappingProfile : Profile
    {
        public JuntaMappingProfile()
        {
            CreateMap<Junta, JuntaDTO>();
            CreateMap<JuntaDTO, Junta>();
        }
    }
}
