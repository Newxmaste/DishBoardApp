using System;
using System.Collections.Generic;

namespace MinhaApi.Models;

public partial class StatusWorker
{
    public int StatusWorkerId { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<Server> Servers { get; set; } = new List<Server>();
}
