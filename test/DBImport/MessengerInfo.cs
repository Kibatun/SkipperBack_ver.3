using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class MessengerInfo
{
    public Guid Id { get; set; }

    public Guid Userid { get; set; }

    public string? Type { get; set; }

    public string Value { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
