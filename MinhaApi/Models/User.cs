using System;
using System.Collections.Generic;

namespace MinhaApi.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ProfileImage { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual Server? Server { get; set; }
    public virtual Manager? Manager { get; set; }

}
