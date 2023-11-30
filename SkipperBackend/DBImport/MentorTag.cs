using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.DBImport;

public partial class MentorTag
{
    public Guid Id { get; set; }

    public Guid? MentorId { get; set; }

    public Guid? TagId { get; set; } 
}
