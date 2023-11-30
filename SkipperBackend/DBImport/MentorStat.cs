using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.DBImport;

public partial class MentorStat
{
    public Guid Id { get; set; }

    public Guid? MentorId { get; set; }

    public int LessonsCount { get; set; }
    
    public float Rating { get; set; }

    public float ReviewersCount { get; set; }
}
