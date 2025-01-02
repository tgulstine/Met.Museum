using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
