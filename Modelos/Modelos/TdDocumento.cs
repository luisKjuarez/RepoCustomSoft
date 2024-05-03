using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos;
[Table("TD_DOCUMENTO")]

public partial class TdDocumento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Ruta { get; set; }

    [ForeignKey(nameof(TdVenta))]
    public int IdVenta { get; set; }

    public virtual TdVenta IdVentaNavigation { get; set; } = null!;
}
