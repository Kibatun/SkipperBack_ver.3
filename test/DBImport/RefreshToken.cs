using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class RefreshToken
{
    public Guid Id { get; set; }

    public Guid Token { get; set; }

    public DateTime Expiresat { get; set; }

    public bool? Isexpired { get; set; }

    public virtual User TokenNavigation { get; set; } = null!;
}
