using DemoAPI.Models;
using DemoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Services
{
    public class OrderService : IOrderService
    {
        [HttpGet]
        public Task<IActionResult> AddDriver(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteDriver(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
