using System;
using System.Collections.Generic;

namespace IDS.Models;

public partial class User
{
    public int UserId { get; set; }
    public string? UserName { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<EventGuide> EventGuides { get; } = new List<EventGuide>();

    public virtual ICollection<EventMember> EventMembers { get; } = new List<EventMember>();
}
