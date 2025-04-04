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
    public class DerramasService : IDerramasService
    {
        private readonly IDerramasRepository _repository;
        private readonly IMapper _mapper;
        public DerramasService(IDerramasRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<DerramaDTO>>> GetAsync(int comunidadId)
        {
            var response = new Response<List<DerramaDTO>>();
            try
            {
                var result = await _repository.GetAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<DerramaDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }
                    
                else
                    response.setError("Error al obtener las derramas", string.Empty);
            }
            catch (Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
                throw new NotImplementedException();
            }

            return response;
        }
    }
}
