using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.DBImport;

public partial class Tag
{
    public Guid Id { get; set; }

    public Guid? CategoryId { get; set; }

    public string Value { get; set; } = null!;
}
