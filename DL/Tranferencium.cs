using System;
using System.Collections.Generic;

namespace DL;

public partial class Tranferencium
{
    public string? FromAccount { get; set; }

    public string? ToAccount { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? FechaEnvio { get; set; }
}
