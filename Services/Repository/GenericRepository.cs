using DemoAPI.Data;
using DemoAPI.Models;
using DemoAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _applicationDbContext;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext applicationDbContext, ILogger logger)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<T>();
            _logger = logger;
        }

        async Task<IEnumerable<T>> IGenericRepository<T>.All()
        {
            return await _dbSet.ToArrayAsync();
        }

        async Task<T?> IGenericRepository<T>.GetbyId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        async Task<bool> IGenericRepository<T>.Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        async Task<bool> IGenericRepository<T>.Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
        async Task<bool> IGenericRepository<T>.Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        
    }
}
