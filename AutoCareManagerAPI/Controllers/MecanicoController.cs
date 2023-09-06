using AutoCareManagerAPI.Data;
using AutoCareManagerAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        private readonly AutoCareManagerAPIContext _context;
        public MecanicoController(AutoCareManagerAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Mecanico>> Get() {
            return await _context.Mecanico.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var mecanico = await _context.Mecanico.FirstOrDefaultAsync(c=>c.id==id);

            if (mecanico == null) return NotFound();

            return Ok(mecanico);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Mecanico mecanico) {
            await _context.Mecanico.AddAsync(mecanico);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", mecanico.id,mecanico);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Mecanico mecanico) {
            _context.Mecanico.Update(mecanico);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Mecanico mecanico)
        {
            if (mecanico == null) return NotFound();

            _context.Mecanico.Remove(mecanico);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
