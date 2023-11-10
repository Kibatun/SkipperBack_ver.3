using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class BookedLesson
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? MentorId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Type { get; set; }

    public long StartDate { get; set; }

    public Guid? LessonDurationId { get; set; }

    public Guid? MessengerId { get; set; }

    public virtual LessonDuration? LessonDuration { get; set; }

    public virtual MessengerInfo? Messenger { get; set; }

    public virtual User? User { get; set; }
}
