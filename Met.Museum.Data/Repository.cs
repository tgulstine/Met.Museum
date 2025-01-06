using Microsoft.EntityFrameworkCore;

namespace Met.Museum.Data
{
    internal class Repository<T>(MetDbContext context) : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context = context;

        public void Add(in T entity)
        {
            _context.Add(entity).State = EntityState.Added;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();  
        }
    }
}
