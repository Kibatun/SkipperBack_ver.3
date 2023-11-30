using System;
using System.Collections.Generic;

namespace SkipperBack3.DBImport;

public partial class TimeSLot
{
    public Guid Id { get; set; }

    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
