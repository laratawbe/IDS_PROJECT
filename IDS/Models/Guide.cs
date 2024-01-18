using System;
using System.Collections.Generic;

namespace IDS.Models;

public partial class Guide
{
    public int GuideId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? JoiningDate { get; set; }

    public byte[]? Photo { get; set; }

    public string? Profession { get; set; }

    public virtual ICollection<EventGuide> EventGuides { get; } = new List<EventGuide>();
}
