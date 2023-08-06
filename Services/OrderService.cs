using DemoAPI.Data;
using DemoAPI.Models;
using DemoAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class OrderService : IOrderService
    {
        public ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task<Object> AddDriver(Driver driver)
        {
            
            int id = driver.Id;
            // Let's find the object if it exits already
            Driver obj = await _dbContext.Drivers.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                _dbContext.Drivers.Add(driver);
                await _dbContext.SaveChangesAsync();
                return "Done";
            }else
            {
                return null;
            }
            
        }

        public async Task<Object> DeleteDriver(int Id)
        {
            Driver obj = await _dbContext.Drivers.FirstOrDefaultAsync(u => u.Id == Id);
            if (obj != null)
            {
                _dbContext.Drivers.Remove(obj);
                await _dbContext.SaveChangesAsync();
                return "Done";
            }
            else
            {
                return null;
            }   
        }

        public async Task<List<Driver>> Get()
        {
             return await _dbContext.Drivers.ToListAsync();
        }

        public async Task<Driver> Get(int id)
        {
            Driver driver = await _dbContext.Drivers.FirstOrDefaultAsync(u => u.Id == id);
            if (driver != null)
            {
                return driver;
            }
            else
            {
                return null;
            }   
        }

        
        public async Task<Object> UpdateDriver(Driver driver)
        {
            Driver obj = await _dbContext.Drivers.FirstOrDefaultAsync((u => u.Id == driver.Id));
            if (obj != null)
            {
                // first remove the old obj and add the new one
                _dbContext.Drivers.Update(driver);
                await _dbContext.SaveChangesAsync();
                return "Done";
            }
            else
            {
                return null;
            }   
        }
    }
}
