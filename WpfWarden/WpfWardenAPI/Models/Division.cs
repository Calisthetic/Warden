using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WpfWardenAPI.Models;

public partial class Division
{
    public int divisionId { get; set; }

    public string name { get; set; } = null!;
}
