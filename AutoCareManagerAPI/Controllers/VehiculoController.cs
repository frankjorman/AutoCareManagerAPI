using AutoCareManagerAPI.Data;
using AutoCareManagerAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly AutoCareManagerAPIContext _context;
        public VehiculoController(AutoCareManagerAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Vehiculo>> Get()
        {
            return await _context.vehiculo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var vehiculo = await _context.vehiculo.FirstOrDefaultAsync(c => c.id == id);

            if (vehiculo == null) return NotFound();

            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vehiculo vehiculo)
        {
            await _context.vehiculo.AddAsync(vehiculo);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", vehiculo.id, vehiculo);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vehiculo vehiculo)
        {
            _context.vehiculo.Update(vehiculo);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Vehiculo vehiculo)
        {
            if (vehiculo == null) return NotFound();

            _context.vehiculo.Remove(vehiculo);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
