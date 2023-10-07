using System;
using System.Collections.Generic;

namespace AutoCareManagerAPI.Entities;

public partial class ServicioRealizados
{
    public int IdServicio { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdVehiculo { get; set; }

    public int? IdCliente { get; set; }

    public int? Servicio1 { get; set; }

    public string? Codigo { get; set; }
}
