using AutoMapper;
using carproject.Application.Dto;
using carproject.Domain.Repositories;

namespace carproject.Application.Interfaces
{
    public class MarcasAutosService : IMarcasAutosService
    {
        private readonly IMarcasAutosRepository _marcasAutosRepository;
        private readonly IMapper _mapper;
        public MarcasAutosService(IMarcasAutosRepository marcasAutosRepository, IMapper mapper)
        {
            _marcasAutosRepository = marcasAutosRepository;
            _mapper = mapper;
        }             
        public async Task<IEnumerable<MarcasAutosDto>> GetAllAsync()
        {
            var vehicles = await _marcasAutosRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MarcasAutosDto>>(vehicles);
        }
    }
}
