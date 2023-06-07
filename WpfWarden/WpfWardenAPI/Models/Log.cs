using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiCoreWarden.Models;

public partial class Log
{
    public int LogId { get; set; }

    public string MachineName { get; set; } = null!;

    public DateTime Logged { get; set; }

    public string LogLevel { get; set; } = null!;

    public string? Message { get; set; }

    public string? Exception { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
