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
    public class ServiciosController : ControllerBase
    {
        
        private readonly AutoCareManagerContext _context;

        public ServiciosController(AutoCareManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicios>>> GetServicio()
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            return await _context.Servicios.ToListAsync();
        }
        [HttpGet]
        [Route("GetServicioById/{id}")]
        public async Task<ActionResult<Servicios>> GetServicioById(int id)
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }
        [HttpGet]
        [Route("GetServicioByNombre/{nombre}")]
        public async Task<ActionResult<Servicios>> GetServicioByNombre(string nombre)
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            var servicio = await _context.Servicios.FindAsync(nombre);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(int id, Servicios servicio)
        {
            if (id != servicio.IdServicios)
            {
                return BadRequest();
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return Ok(servicio);
        }
        [HttpPost]
        public async Task<ActionResult<Servicios>> PostServicio(Servicios servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicio", new { id = servicio.IdServicios }, servicio);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Servicios>> DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return servicio;
        }
    }
}
