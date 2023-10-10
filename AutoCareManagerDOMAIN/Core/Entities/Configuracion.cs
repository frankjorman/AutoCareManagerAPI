using System;
using System.Collections.Generic;

namespace AutoCareManagerDOMAIN.Entities;

public partial class Configuracion
{
    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Grupo { get; set; }
}
