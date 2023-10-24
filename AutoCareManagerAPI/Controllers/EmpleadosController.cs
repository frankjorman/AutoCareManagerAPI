using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoCareManagerDOMAIN.Entities;
using AutoCareManagerDOMAIN.Infraestructure.Data;
using AutoCareManagerDOMAIN.Core.Interfaces;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AutoCareManagerContext _context;
        private readonly IEmpleadosRepository _empleado;

        public EmpleadosController(AutoCareManagerContext context, IEmpleadosRepository empleado)
        {
            _context = context;
            _empleado = empleado;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            var resultado = await _empleado.GetEmpleado();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var empleado = await _empleado.GetEmpleadoId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        public async Task<IActionResult> PutEmpleado(Empleado empleado)
        {
            if (empleado != null)
            {
                return BadRequest();
            }

            var resultado = await _empleado.PutEmpleado(empleado);

            if (resultado == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                return Problem("No se puede agregar un empleado vacio");
            }

            var resultado = await _empleado.PostEmpleado(empleado);

            if (resultado == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var resultado = await _empleado.DeleteEmpleado(id);

            if (resultado == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
