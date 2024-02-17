using System;
using System.Collections.Generic;

namespace DataAccess.Data;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? Correo { get; set; }

    public bool? Estado { get; set; }
}
