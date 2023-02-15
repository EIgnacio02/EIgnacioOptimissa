using System;
using System.Collections.Generic;

namespace DL;

public partial class Cuentum
{
    public string Account { get; set; } = null!;

    public int? Balance { get; set; }

    public string? Owners { get; set; }

    public DateTime? Fecha { get; set; }
}
