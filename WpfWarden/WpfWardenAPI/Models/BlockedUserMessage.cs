using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiCoreWarden.Models;

public partial class BlockedUserMessage
{
    public int BlockedUserMessageId { get; set; }

    public int SendlerUserId { get; set; }

    public int? DestinationUserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime Time { get; set; }
}
