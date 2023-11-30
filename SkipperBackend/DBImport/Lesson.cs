using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.DBImport;

public partial class Lesson
{
    public Guid Id { get; set; }

    public Guid? MentorId { get; set; }

    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;
    public string Desctiption { get; set; } = null!;
}
