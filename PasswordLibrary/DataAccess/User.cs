using System;
using System.Collections.Generic;

namespace PasswordLibrary.DataAccess;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Password> Passwords { get; } = new List<Password>();
}
