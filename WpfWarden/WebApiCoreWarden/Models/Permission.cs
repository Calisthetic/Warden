using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiCoreWarden.Models;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string Name { get; set; } = null!;

    public bool AddData { get; set; }

    public bool ChangeData { get; set; }

    public bool MakeReport { get; set; }

    public bool DeleteData { get; set; }

    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
