using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class LessonDuration
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Duration { get; set; }

    public virtual ICollection<BookedLesson> BookedLessons { get; set; } = new List<BookedLesson>();
}
