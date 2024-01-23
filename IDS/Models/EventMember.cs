using System;
using System.Collections.Generic;

namespace IDS.Models;

public partial class EventMember
{
    public int EventMemberId { get; set; }

    public int? EventId { get; set; }

    public int? MemberId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? Member { get; set; }
}
