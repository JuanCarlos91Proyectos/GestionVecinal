using AutoMapper;
using GestionVecinal.Models.Common;
using GestionVecinal.Models.DTO;
using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using GestionVecinal.Services.Interfaces;
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
        public ComunidadesService(IComunidadesRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ComunidadDTO>> GetAsync()
        {
            var result = await _repository.GetAsync();
            return _mapper.Map<List<ComunidadDTO>>(result);
        }

        public async Task<Response<bool>> AddAsync(ComunidadDTO comunidad)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Comunidad>(comunidad);
                var result = await _repository.AddAsync(entity);
                if (result)
                    response.setValue(result, true, string.Empty);
                else
                    response.setError("Error al añadir la comunidad", string.Empty);
            }
            catch(Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
            }

            return response;
        }
    }
}
