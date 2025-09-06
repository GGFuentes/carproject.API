using carproject.Domain.Entities;
using carproject.Domain.Repositories;
using carproject.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace carproject.Infraestructure.Repositories
{
    public class MarcasAutosRepository : IMarcasAutosRepository
    {
        private readonly ApplicationDbContext _db;
        public MarcasAutosRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<MarcasAutos>> GetAllAsync()
        {
            return await _db.MarcasAutos.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
