using System;
using System.Collections.Generic;

namespace AutoCareManagerDOMAIN.Entities;

public partial class Servicios
{
    public int IdSercicios { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public string? Tipo { get; set; }
}
