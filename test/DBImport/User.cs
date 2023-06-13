using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class User
{
    public Guid Uid { get; set; }

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public bool? Ismentor { get; set; }

    public string Bio { get; set; } = null!;

    public string Post { get; set; } = null!;

    public byte[]? Avatar { get; set; }

    public double Rating { get; set; }

    public int Reviewscount { get; set; }

    public long Updatedat { get; set; }

    public long Createdat { get; set; }

    public virtual MessengerInfo? MessengerInfo { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
