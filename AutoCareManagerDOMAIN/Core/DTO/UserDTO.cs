using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCareManagerDOMAIN.Core.DTO
{
    public class UsuarioAuthDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioRegisterDTO
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int? IdEmpleado { get; set; }
    }

    public class UserReponseDTO
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int? IdEmpleado { get; set; }
        public string Token { get; set; }
    }
}
