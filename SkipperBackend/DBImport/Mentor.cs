using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class Mentor
{
    public Guid Id { get; set; }

     public string FullName { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string Post { get; set; } = null!;

    public string About { get; set; } = null!;

    public string Lessons { get; set; } = null!;
    
    public string? CvInfoId  {get; set; }
    public float Messengers { get; set; }
    public TimeSpan UpdatedAt { get; set; }
    public TimeSpan CreatedAt { get; set; }
}

