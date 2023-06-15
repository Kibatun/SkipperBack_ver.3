using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class User
{
    public Guid Uid { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool? IsMentor { get; set; }

    public string Bio { get; set; } = null!;

    public string Post { get; set; } = null!;

    public byte[]? Avatar { get; set; }

    public double Rating { get; set; }

    public int ReviewsCount { get; set; }

    public long UpdatedAt { get; set; }

    public long CreatedAt { get; set; }

    public virtual ICollection<BookedLesson> BookedLessons { get; set; } = new List<BookedLesson>();

    public virtual ICollection<MessengerInfo> MessengerInfos { get; set; } = new List<MessengerInfo>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
