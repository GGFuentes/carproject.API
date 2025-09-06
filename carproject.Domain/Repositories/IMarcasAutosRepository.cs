using carproject.Domain.Entities;

namespace carproject.Domain.Repositories
{
    public interface IMarcasAutosRepository
    {
        Task<IEnumerable<MarcasAutos>> GetAllAsync();
        
    }
}
