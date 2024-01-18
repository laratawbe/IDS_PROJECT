﻿using System;
using System.Collections.Generic;

namespace IDS.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public string? Destination { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public decimal? Cost { get; set; }

    public int? RelatedGuideId { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual Lookup? Category { get; set; }

    public virtual ICollection<EventGuide> EventGuides { get; } = new List<EventGuide>();

    public virtual ICollection<EventMember> EventMembers { get; } = new List<EventMember>();

    public virtual User? RelatedGuide { get; set; }
}
