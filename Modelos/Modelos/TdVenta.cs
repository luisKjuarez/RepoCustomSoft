using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos;
[ Table("TD_VENTA")]
public partial class TdVenta
{

    public int IdVenta { get; set; }

    public DateOnly  FechaVenta { get; set; }

    public string? Descripcion { get; set; }
}
