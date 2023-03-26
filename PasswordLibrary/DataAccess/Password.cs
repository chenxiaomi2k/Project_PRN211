using System;
using System.Collections.Generic;

namespace PasswordLibrary.DataAccess;

public partial class Password
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Website { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string SavedPassword { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string? Note { get; set; }

    public virtual User User { get; set; } = null!;
}
