using System;
using System.Collections.Generic;

namespace MinhaApi.Models;

public partial class Server
{
    public Guid ServerId { get; set; }

    public Guid UserId { get; set; }

    public int StatusWorkerId { get; set; }

    public int? MaxTables { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual StatusWorker StatusWorker { get; set; } = null!;

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();

     public virtual User User { get; set; } = null!;
}
