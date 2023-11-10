using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.DBImport;

public partial class Category
{
    public Guid Id { get; set; }

    public string Key { get; set; }

    public string Name { get; set; } = null!;

    public string[] Subcategories { get; set; } = null!;
}
