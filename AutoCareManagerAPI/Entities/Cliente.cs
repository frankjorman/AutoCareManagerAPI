﻿using System;
using System.Collections.Generic;

namespace AutoCareManagerAPI.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NumDocumento { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }
}