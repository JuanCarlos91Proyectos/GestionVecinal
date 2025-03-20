using AutoMapper;
using GestionVecinal.Models;
using GestionVecinal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services
{
    public class ComunidadesService : IComunidadesService
    {
        private readonly IComunidadesRepository _repository;
        private readonly IMapper _mapper;
        public ComunidadesService(IComunidadesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ComunidadDTO>> GetComunidades()
        {
            var result = await _repository.GetComunidades();
            return _mapper.Map<List<ComunidadDTO>>(result);
        }
    }
}
