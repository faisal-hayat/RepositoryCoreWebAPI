using DemoAPI.Data;
using DemoAPI.Models;
using DemoAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DemoAPI.Services
{
    public class IDriverRepository : IGenericRepository<Driver>
    {
        // we need to get the application DbContext
        protected ApplicationDbContext _applicationDbContext;
        internal DbSet<T> _dBSet;


        // implenment the interface
        public IDriverRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        async Task<IEnumerable<Driver>> IGenericRepository<Driver>.All()
        {
            return await _applicationDbContext.Drivers.ToListAsync();
        }

        Task<bool> IGenericRepository<Driver>.Add(Driver entity)
        {

            throw new NotImplementedException();
        }

        async Task<bool> IGenericRepository<Driver>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Driver> IGenericRepository<Driver>.GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepository<Driver>.Update(Driver entity)
        {
            throw new NotImplementedException();
        }
    }
}
