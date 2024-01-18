using System;
using System.Collections.Generic;

namespace IDS.Models;

public partial class Lookup
{
    public int LookupId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? LookupOrder { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
