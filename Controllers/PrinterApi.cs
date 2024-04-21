using PrinterApi.Data;
using PrinterApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PrinterApi.Controllers
{
    //TODO: Replace fat controller with interface-based service and repository layer.
    //TODO: Add DTOs.
    [Route("[controller]")]
    [ApiController]
    public class PrinterApiController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PrinterApiController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Printer>>> GetAllPrinters()
        {
            var printers = await _dataContext.Printers.ToListAsync();
            return printers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Printer>> GetPrinter(int id)
        {
            var printer = await _dataContext.Printers.FindAsync(id);
            if (printer is null)
            {
                return BadRequest("Printer not found");
            }
            return Ok(printer);
        }


        [HttpPost]
        public async Task<ActionResult<List<Printer>>> AddPrinter(Printer emp)
        {

            _dataContext.Printers.Add(emp);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Printers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Printer>>> UpdatePrinter(Printer updatedPrinter)
        {
            var dbEmpl = await _dataContext.Printers.FindAsync(updatedPrinter.PrinterId);
            if (dbEmpl is null)
            {
                return NotFound("Printer not found");
            }
            dbEmpl.PrinterName = updatedPrinter.PrinterName;
            dbEmpl.IpAddress = updatedPrinter.IpAddress;
            dbEmpl.IsActive = updatedPrinter.IsActive;
            

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Printers.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Printer>>> DeletePrinter(int id)
        {
            var dbEmpl = await _dataContext.Printers.FindAsync(id);
            if (dbEmpl is null)
            {
                return NotFound("Printer not found");
            }
            _dataContext.Remove(dbEmpl);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Printers.ToListAsync());
        }
    }
}
