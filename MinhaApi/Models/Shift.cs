using System;
using System.Collections.Generic;

namespace MinhaApi.Models;

public partial class Shift
{
    public Guid ShiftsId { get; set; }

    public Guid? ServerId { get; set; }

    public Guid? ManagerId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string? ShiftType { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Server? Server { get; set; }
}
