using DemoAPI.Data;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {

        // get the database connection
        public ApplicationDbContext _dbContext;
        // let's make an in-memory database
        private static List<Driver> _drivers = new List<Driver>() { 
            new Driver {Id=0, Name="John", DriverNumber=131, Team="Red Team"},
            new Driver {Id=1, Name="James", DriverNumber=132, Team="Blue Team"},
            new Driver {Id=2, Name="Murdock", DriverNumber=133, Team="Dev Team"}
        };

        private readonly ILogger<DriverController> _logger;
        

        public DriverController(ILogger<DriverController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _dbContext = applicationDbContext;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Drivers.ToListAsync());
        }

        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Driver driver = await _dbContext.Drivers.FirstOrDefaultAsync(u => u.Id == id);
                if (driver != null)
                {
                    return Ok(driver);
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            try
            {
                int id = driver.Id;
                // Let's find the object if it exits already
                Driver obj = await _dbContext.Drivers.FirstOrDefaultAsync(u => u.Id == id);
                if (obj==null)
                {
                    _dbContext.Drivers.Add(driver);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                   return BadRequest("Item already exists.");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(int Id)
        {
            try
            {
                Driver obj = await _dbContext.Drivers.FirstOrDefaultAsync(u => u.Id == Id);
                if (obj != null)
                {
                    _dbContext.Drivers.Remove(obj);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("UpdateDriver")]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            try
            {
                Driver obj = await _dbContext.Drivers.FirstOrDefaultAsync((u=>u.Id == driver.Id));
                if (obj != null)
                {
                    // first remove the old obj and add the new one
                    _dbContext.Drivers.Update(driver);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
