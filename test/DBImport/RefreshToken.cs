using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class RefreshToken
{
    public Guid Id { get; set; }

    public string Token { get; set; } = null!;

    public Guid UserId { get; set; }

    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? IsExpired { get; set; }

    public virtual User User { get; set; } = null!;
}
