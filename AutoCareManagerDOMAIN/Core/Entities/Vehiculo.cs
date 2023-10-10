using System;
using System.Collections.Generic;

namespace AutoCareManagerDOMAIN.Entities;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Anio { get; set; }

    public string? Placa { get; set; }
}
