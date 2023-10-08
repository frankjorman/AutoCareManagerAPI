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
    public class ServicioRealizadosController : ControllerBase
    {
        private readonly AutoCareManagerContext _context;

        public ServicioRealizadosController(AutoCareManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioRealizados>>> GetServicioRealizados()
        {
          if (_context.ServicioRealizados == null)
          {
              return NotFound();
          }
            return await _context.ServicioRealizados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioRealizados>> GetServicioRealizados(int id)
        {
          if (_context.ServicioRealizados == null)
          {
              return NotFound();
          }
            var servicioRealizados = await _context.ServicioRealizados.FindAsync(id);

            if (servicioRealizados == null)
            {
                return NotFound();
            }

            return servicioRealizados;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioRealizados(int id, ServicioRealizados servicioRealizados)
        {
            if (id != servicioRealizados.IdServicio)
            {
                return BadRequest();
            }

            _context.Entry(servicioRealizados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioRealizadosExists(id))
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

        [HttpPost]
        public async Task<ActionResult<ServicioRealizados>> PostServicioRealizados(ServicioRealizados servicioRealizados)
        {
          if (_context.ServicioRealizados == null)
          {
              return Problem("Entity set 'AutoCareManagerContext.ServicioRealizados'  is null.");
          }
            _context.ServicioRealizados.Add(servicioRealizados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioRealizados", new { id = servicioRealizados.IdServicio }, servicioRealizados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicioRealizados(int id)
        {
            if (_context.ServicioRealizados == null)
            {
                return NotFound();
            }
            var servicioRealizados = await _context.ServicioRealizados.FindAsync(id);
            if (servicioRealizados == null)
            {
                return NotFound();
            }

            _context.ServicioRealizados.Remove(servicioRealizados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioRealizadosExists(int id)
        {
            return (_context.ServicioRealizados?.Any(e => e.IdServicio == id)).GetValueOrDefault();
        }
    }
}
