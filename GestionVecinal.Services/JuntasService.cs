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
    public class JuntasService : IJuntasService
    {
        private readonly IJuntasRepository _repository;
        private readonly IMapper _mapper;
        public JuntasService(IJuntasRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        

        public async Task<Response<List<JuntaDTO>>> GetAsync(int comunidadId)
        {
            var response = new Response<List<JuntaDTO>>();
            try
            {
                var result = await _repository.GetAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<JuntaDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }

                else
                    response.setError("Error al obtener las juntas", string.Empty);
            }
            catch (Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
                throw ex;
            }

            return response;
        }
    }
}
