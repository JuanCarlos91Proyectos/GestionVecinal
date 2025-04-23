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
    public class PresidenciaMappingProfile : Profile
    {
        public PresidenciaMappingProfile()
        {
            CreateMap<Presidencia, PresidenciaDTO>()
                .ForMember(x => x.FechaFin, opt => opt.MapFrom(origin => DateOnly.Parse(origin.FechaFin)))
                .ForMember(x => x.FechaInicio, opt => opt.MapFrom(origin => DateOnly.Parse(origin.FechaInicio)));
            CreateMap<PresidenciaDTO, Presidencia>()
                .ForMember(x => x.FechaFin, opt => opt.MapFrom(origin => origin.FechaFin.ToString()))
                .ForMember(x => x.FechaInicio, opt => opt.MapFrom(origin => origin.FechaInicio.ToString())); ;
        }
    }
}
