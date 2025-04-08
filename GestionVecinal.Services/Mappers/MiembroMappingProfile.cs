using AutoMapper;
using GestionVecinal.Models.DTO;
using GestionVecinal.Models.Enums;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services.Mappers
{
    public class MiembroMappingProfile : Profile
    {
        public MiembroMappingProfile()
        {
            CreateMap<Miembro, MiembroDTO>()
                .ForMember(x => x.FormaPagoCuota, opt => opt.MapFrom(origin => (FormaPagoCuotaEnum)origin.FormaPagoCuota));
            CreateMap<MiembroDTO, Miembro>()
                .ForMember(x => x.FormaPagoCuota, opt => opt.MapFrom(origin => (int)origin.FormaPagoCuota)); ;
        }
    }
}
