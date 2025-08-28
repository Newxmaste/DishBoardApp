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

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<Server> Servers { get; set; } = new List<Server>();
}
