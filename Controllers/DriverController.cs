using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : Controller
    {
        // let's make an in-memory database
        private readonly List<Driver> _drivers = new List<Driver>() { 
            new Driver {Id=0, Name="John", DriverNumber=131, Team="Red Team"},
            new Driver {Id=1, Name="James", DriverNumber=132, Team="Blue Team"},
            new Driver {Id=2, Name="Murdock", DriverNumber=133, Team="Dev Team"}
        };

        public IActionResult Get()
        {
            return Ok(_drivers);
        }
    }
}
