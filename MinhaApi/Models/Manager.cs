using System;
using System.Collections.Generic;

namespace MinhaApi.Models;

public partial class Manager
{
    public Guid ManagerId { get; set; }

    public Guid UserId { get; set; }

    public int StatusWorkerId { get; set; }

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual StatusWorker StatusWorker { get; set; } = null!;

     public virtual User User { get; set; } = null!;
}
