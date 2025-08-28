using System;
using System.Collections.Generic;

namespace MinhaApi.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid? ServerId { get; set; }

    public Guid? TableId { get; set; }

    public int StatusOrderId { get; set; }

    public Guid? ShiftsId { get; set; }

    public DateTime OrderDate { get; set; }

    public int TableNumber { get; set; }

    public string? Details { get; set; }

    public virtual Server? Server { get; set; }

    public virtual Shift? Shifts { get; set; }

    public virtual StatusOrder StatusOrder { get; set; } = null!;

    public virtual Table? Table { get; set; }
}
