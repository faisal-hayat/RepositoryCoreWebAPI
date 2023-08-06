using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<List<Driver>> Get();
        public Task<Driver> Get(int id);
        public Task<Object> AddDriver(Driver driver);
        public Task<Object> DeleteDriver(int Id);
        public Task<Object> UpdateDriver(Driver driver);
    }
}