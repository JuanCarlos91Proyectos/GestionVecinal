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
    public class ViviendaService : IViviendaService
    {
        private readonly IViviendaRepository _repository;
        private readonly IMapper _mapper;
        public ViviendaService(IViviendaRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ViviendaDTO>> GetAsync()
        {
            var result = await _repository.GetAsync();
            return _mapper.Map<List<ViviendaDTO>>(result);
        }

        public async Task<Response<bool>> AddAsync(ViviendaDTO vivienda)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Vivienda>(vivienda);
                var result = await _repository.AddAsync(entity);
                if (result)
                    response.setValue(result, true, string.Empty);
                else
                    response.setError("Error al añadir vivienda", string.Empty);
            }
            catch(Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
            }

            return response;
        }
    }
}
