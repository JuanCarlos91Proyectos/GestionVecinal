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
    public class PagosService : IPagosService
    {
        private readonly IPagosRepository _repository;
        private readonly IMapper _mapper;
        public PagosService(IPagosRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        

        public async Task<Response<List<PagoDTO>>> GetAsync(int comunidadId)
        {
            var response = new Response<List<PagoDTO>>();
            try
            {
                var result = await _repository.GetAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<PagoDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }

                else
                    response.setError("Error al obtener los proveedores", string.Empty);
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
