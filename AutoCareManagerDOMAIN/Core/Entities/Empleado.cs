using System;
using System.Collections.Generic;

namespace AutoCareManagerDOMAIN.Entities;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public bool Estado { get; set; }
}
