using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        public Task<IActionResult> AddDriver(Driver driver);
        public Task<IActionResult> DeleteDriver(int Id);
        public Task<IActionResult> UpdateDriver(Driver driver);
    }
}