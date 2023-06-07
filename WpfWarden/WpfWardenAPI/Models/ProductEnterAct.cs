using System;
using System.Collections.Generic;

namespace WebApiCoreWarden.Models;

public partial class ProductEnterAct
{
    public int ProductEnterActId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime EnterDate { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public bool HighPriotity { get; set; }

    public string? Description { get; set; }

    public bool Status { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
