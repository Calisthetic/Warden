using System;
using System.Collections.Generic;

namespace WebApiCoreWarden.Models;

public partial class Division
{
    public int DivisionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
