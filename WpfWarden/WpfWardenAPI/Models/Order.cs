using System;
using System.Collections.Generic;

namespace WpfWardenAPI.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string TrackCode { get; set; } = null!;

    public bool IsDelivered { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public int UserId { get; set; }

    public string DeliverCompany { get; set; } = null!;

    public bool IsClosed { get; set; }

    public virtual ICollection<ProductEnterAct> ProductEnterActs { get; set; } = new List<ProductEnterAct>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User User { get; set; } = null!;
}
