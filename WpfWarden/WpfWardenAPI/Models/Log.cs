using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WpfWardenAPI.Models;

public partial class Log
{
    public int logId { get; set; }

    public string machineName { get; set; } = null!;

    public DateTime logged { get; set; }

    public string logLevel { get; set; } = null!;

    public string? message { get; set; }

    public string? exception { get; set; }

    public int? userId { get; set; }

    public User user { get; set; }
}
