using AutoCareManagerDOMAIN.Core.Entities;
using AutoCareManagerDOMAIN.Core.Interfaces;
using AutoCareManagerDOMAIN.Entities;
using AutoCareManagerDOMAIN.Infraestructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestoController : ControllerBase
    {
        private readonly AutoCareManagerContext _context;

        public RepuestoController(AutoCareManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repuesto>>> GetRepuesto()
        {
            if (_context.Repuesto == null)
            {
                return NotFound();
            }

            try
            {
                return await _context.Repuesto.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Repuesto>> GetRepuesto(int id)
        {
            if (_context.Repuesto == null)
            {
                return NotFound();
            }
            var Repuesto = await _context.Repuesto.FindAsync(id);

            if (Repuesto == null)
            {
                return NotFound();
            }

            return Repuesto;
        }

        [HttpPut]
        public async Task<IActionResult> PutRepuesto(Repuesto Repuesto)
        {
            if (Repuesto == null)
            {
                return BadRequest();
            }

            _context.Entry(Repuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();

            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Repuesto>> PostRepuesto(Repuesto Repuesto)
        {
            if (_context.Repuesto == null)
            {
                return Problem("Entity set 'AutoCareManagerContext.Repuesto'  is null.");
            }
            _context.Repuesto.Add(Repuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepuesto", new { id = Repuesto.IdRepuesto }, Repuesto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepuesto(int id)
        {
            if (_context.Repuesto == null)
            {
                return NotFound();
            }
            var Repuesto = await _context.Repuesto.FindAsync(id);
            if (Repuesto == null)
            {
                return NotFound();
            }

            _context.Repuesto.Remove(Repuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepuestoExists(int id)
        {
            return (_context.Repuesto?.Any(e => e.IdRepuesto == id)).GetValueOrDefault();
        }
    }
}
