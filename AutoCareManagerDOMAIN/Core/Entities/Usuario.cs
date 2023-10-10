using System;
using System.Collections.Generic;

namespace AutoCareManagerDOMAIN.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public int? IdEmpleado { get; set; }
}
