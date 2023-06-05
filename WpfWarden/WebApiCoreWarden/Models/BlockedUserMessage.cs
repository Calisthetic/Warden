using System;
using System.Collections.Generic;

namespace WebApiCoreWarden.Models;

public partial class BlockedUserMessage
{
    public int BlockedUserMessageId { get; set; }

    public int SendlerUserId { get; set; }

    public int? DestinationUserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime Time { get; set; }

    public virtual User? DestinationUser { get; set; }

    public virtual User SendlerUser { get; set; } = null!;
}
