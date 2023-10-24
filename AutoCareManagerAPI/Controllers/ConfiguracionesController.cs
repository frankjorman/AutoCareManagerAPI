using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoCareManagerDOMAIN.Entities;
using AutoCareManagerDOMAIN.Infraestructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionesController : ControllerBase
    {
        private readonly AutoCareManagerContext _context;

        public ConfiguracionesController(AutoCareManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuracion>>> GetConfiguracion()
        {
          if (_context.Configuracion == null)
          {
              return NotFound();
          }
            return await _context.Configuracion.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Configuracion>> GetConfiguracion(string id)
        {
          if (_context.Configuracion == null)
          {
              return NotFound();
          }
            var configuracion = await _context.Configuracion.FindAsync(id);

            if (configuracion == null)
            {
                return NotFound();
            } 

            return configuracion;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracion(string id, Configuracion configuracion)
        {
            if (id != configuracion.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(configuracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracionExists(id))
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
        public async Task<ActionResult<Configuracion>> PostConfiguracion(Configuracion configuracion)
        {
          if (_context.Configuracion == null)
          {
              return Problem("Entity set 'AutoCareManagerContext.Configuracion'  is null.");
          }
            _context.Configuracion.Add(configuracion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConfiguracionExists(configuracion.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConfiguracion", new { id = configuracion.Codigo }, configuracion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracion(string id)
        {
            if (_context.Configuracion == null)
            {
                return NotFound();
            }
            var configuracion = await _context.Configuracion.FindAsync(id);
            if (configuracion == null)
            {
                return NotFound();
            }

            _context.Configuracion.Remove(configuracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfiguracionExists(string id)
        {
            return (_context.Configuracion?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
