using System;
using System.Collections.Generic;

namespace IDS.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? UserName { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
