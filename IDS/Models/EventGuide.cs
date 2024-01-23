using System;
using System.Collections.Generic;

namespace IDS.Models;

public partial class EventGuide
{
    public int EventGuideId { get; set; }

    public int? EventId { get; set; }

    public int? GuideId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? Guide { get; set; }
}
