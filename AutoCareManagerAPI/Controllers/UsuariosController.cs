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
        public async Task<IActionResult> SignUp([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var result = await _usuario.SignUp(userRegisterDTO);
            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult>
            SignIn([FromBody] UserAuthDTO userAuthDTO)
        {
            var result = await
                _userService.SignIn(userAuthDTO);

            if (result == null)
                return BadRequest("Credenciales inválidas");

            return Ok(result);

        }
    }
}
