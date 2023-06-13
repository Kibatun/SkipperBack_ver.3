using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class BookedLesson
{
    public Guid Id { get; set; }

    public Guid? Userid { get; set; }

    public Guid? Mentorid { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Type { get; set; }

    public long Startdate { get; set; }

    public int Lessondurationid { get; set; }

    public int Messengerid { get; set; }
}
