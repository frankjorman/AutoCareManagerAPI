using System;
using System.Collections.Generic;

namespace AutoCareManagerDOMAIN.Entities;

public partial class ServicioRealizados
{
    public int IdServicioRealizado { get; set; }
    public DateTime Fecha { get; set; }
    public int? IdVehiculo { get; set; }
    public int? IdCliente { get; set; }
    public int? IdServicio { get; set; }
    public int? IdRepuesto { get; set; }
}
