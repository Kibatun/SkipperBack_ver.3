using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.DBImport;

public partial class LessonSlot
{
    public Guid Id { get; set; }

    public string Weekday { get; set; } = null!;

    public Guid? LessonId { get; set; }

    public string SlotId { get; set; } = null!;
}
