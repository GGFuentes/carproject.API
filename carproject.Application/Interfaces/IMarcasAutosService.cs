using carproject.Application.Dto;

namespace carproject.Application.Interfaces
{
    public interface IMarcasAutosService
    {
        Task<IEnumerable<MarcasAutosDto>> GetAllAsync();        
    }
}
