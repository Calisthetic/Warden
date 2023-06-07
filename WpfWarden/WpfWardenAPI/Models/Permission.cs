using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WpfWardenAPI.Models;

public partial class Permission
{
    public int permissionId { get; set; }

    public string name { get; set; } = null!;

    public bool addData { get; set; }

    public bool changeData { get; set; }

    public bool makeReport { get; set; }

    public bool deleteData { get; set; }
}
