using AutoCareManagerAPI.Data;
using AutoCareManagerAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly AutoCareManagerAPIContext _context;
        public EmpleadoController(AutoCareManagerAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Empleado>> Get() {
            return await _context.empleado.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var empleado = await _context.empleado.FirstOrDefaultAsync(c=>c.id==id);

            if (empleado == null) return NotFound();

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Empleado empleado) {
            empleado.estado = true;
            await _context.empleado.AddAsync(empleado);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", empleado.id,empleado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Empleado empleado) {
            _context.empleado.Update(empleado);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Empleado empleado)
        {
            if (empleado == null) return NotFound();

            _context.empleado.Remove(empleado);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
