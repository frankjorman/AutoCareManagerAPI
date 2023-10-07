using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoCareManagerAPI.Entities;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly AutoCareManagerContext _context;

        public ServiciosController(AutoCareManagerContext context)
        {
            _context = context;
        }

        // GET: api/Servicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicios>>> GetServicios()
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            return await _context.Servicios.ToListAsync();
        }

        // GET: api/Servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicios>> GetServicios(int id)
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            var servicios = await _context.Servicios.FindAsync(id);

            if (servicios == null)
            {
                return NotFound();
            }

            return servicios;
        }

        // PUT: api/Servicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicios(int id, Servicios servicios)
        {
            if (id != servicios.IdSercicios)
            {
                return BadRequest();
            }

            _context.Entry(servicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Servicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicios>> PostServicios(Servicios servicios)
        {
          if (_context.Servicios == null)
          {
              return Problem("Entity set 'AutoCareManagerContext.Servicios'  is null.");
          }
            _context.Servicios.Add(servicios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicios", new { id = servicios.IdSercicios }, servicios);
        }

        // DELETE: api/Servicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicios(int id)
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            var servicios = await _context.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiciosExists(int id)
        {
            return (_context.Servicios?.Any(e => e.IdSercicios == id)).GetValueOrDefault();
        }
    }
}
