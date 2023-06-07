using System;
using System.Collections.Generic;

namespace WpfWardenAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public bool? IsGood { get; set; }

    public int OrderId { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
