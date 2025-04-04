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

        public async Task<Response<List<DerramaDTO>>> GetDerramasAsync(int comunidadId)
        {
            var response = new Response<List<DerramaDTO>>();
            try
            {
                var result = await _repository.GetDerramasAsync(comunidadId);
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

        public async Task<Response<List<FacturaDTO>>> GetFacturasAsync(int comunidadId)
        {
            var response = new Response<List<FacturaDTO>>();
            try
            {
                var result = await _repository.GetFacturasAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<FacturaDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }

                else
                    response.setError("Error al obtener las facturas", string.Empty);
            }
            catch (Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
                throw new NotImplementedException();
            }

            return response;
        }

        public async Task<Response<List<IncidenciaDTO>>> GetIncidenciasAsync(int comunidadId)
        {
            var response = new Response<List<IncidenciaDTO>>();
            try
            {
                var result = await _repository.GetIncidenciasAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<IncidenciaDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }

                else
                    response.setError("Error al obtener las incidencias", string.Empty);
            }
            catch (Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
                throw new NotImplementedException();
            }

            return response;
        }

        public async Task<Response<List<JuntaDTO>>> GetJuntasAsync(int comunidadId)
        {
            var response = new Response<List<JuntaDTO>>();
            try
            {
                var result = await _repository.GetJuntasAsync(comunidadId);
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
                throw new NotImplementedException();
            }

            return response;
        }

        public async Task<Response<List<MiembroDTO>>> GetMiembrosAsync(int comunidadId)
        {
            var response = new Response<List<MiembroDTO>>();
            try
            {
                var result = await _repository.GetMiembrosAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<MiembroDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }

                else
                    response.setError("Error al obtener los miembros", string.Empty);
            }
            catch (Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
                throw new NotImplementedException();
            }

            return response;
        }

        public async Task<Response<List<PresidenciaDTO>>> GetPresidentesAsync(int comunidadId)
        {
            var response = new Response<List<PresidenciaDTO>>();
            try
            {
                var result = await _repository.GetPresidentesAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<PresidenciaDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }

                else
                    response.setError("Error al obtener el historial de presidentes", string.Empty);
            }
            catch (Exception ex)
            {
                response.setError(ex.Message, ex.StackTrace);
                throw new NotImplementedException();
            }

            return response;
        }

        public async Task<Response<List<ProveedorDTO>>> GetProveedoresAsync(int comunidadId)
        {
            var response = new Response<List<ProveedorDTO>>();
            try
            {
                var result = await _repository.GetProveedoresAsync(comunidadId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<List<ProveedorDTO>>(result);
                    response.setValue(mappedResult, true, string.Empty);
                }

                else
                    response.setError("Error al obtener los proveedores", string.Empty);
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
