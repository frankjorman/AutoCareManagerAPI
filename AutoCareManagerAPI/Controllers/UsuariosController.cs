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
using AutoCareManagerDOMAIN.Core.DTO;

namespace AutoCareManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AutoCareManagerContext _context;
        private readonly IUsuariosRepository _usuario;

        public UsuariosController(AutoCareManagerContext context, IUsuariosRepository usuario)
        {
            _context = context;
            _usuario = usuario;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UsuarioRegisterDTO usuarioRegisterDTO)
        {
            
            var userExists = await _usuario.IsEmailRegistered(usuarioRegisterDTO.Username);

            if(userExists) return BadRequest("El usuario ya existe");

            var c = new Usuario
            {
                Username = usuarioRegisterDTO.Username,
                Password = usuarioRegisterDTO.Password,
                Rol = usuarioRegisterDTO.Rol,
                IdEmpleado = usuarioRegisterDTO.IdEmpleado
            };

            var result = await _usuario.SignUp(c);
            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UsuarioAuthDTO userAuthDTO)
        {


            var c = new Usuario
            {
                Username = userAuthDTO.Username,
                Password = userAuthDTO.Password
            };

            var result = await _usuario.SignIn(c);

            if (result == null)
                return BadRequest("Credenciales inválidas");

            return Ok(result);

        }
    }
}
