using System;
using System.Collections.Generic;

namespace DataAccess.Data;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? NombreServicio { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }
}
