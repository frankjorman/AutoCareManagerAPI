using AutoCareManagerAPI.Data;
using AutoCareManagerAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReparacionController : ControllerBase
    {
        private readonly AutoCareManagerAPIContext _context;
        public ReparacionController(AutoCareManagerAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Reparacion>> Get()
        {
            return await _context.reparacion.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var reparacion = await _context.reparacion.FirstOrDefaultAsync(c => c.id == id);

            if (reparacion == null) return NotFound();

            return Ok(reparacion);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Reparacion reparacion)
        {
            await _context.reparacion.AddAsync(reparacion);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", reparacion.id, reparacion);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Reparacion reparacion)
        {
            _context.reparacion.Update(reparacion);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Reparacion reparacion)
        {
            if (reparacion == null) return NotFound();

            _context.reparacion.Remove(reparacion);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
