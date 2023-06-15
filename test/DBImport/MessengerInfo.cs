using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class MessengerInfo
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Type { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<BookedLesson> BookedLessons { get; set; } = new List<BookedLesson>();

    public virtual User? User { get; set; }
}
