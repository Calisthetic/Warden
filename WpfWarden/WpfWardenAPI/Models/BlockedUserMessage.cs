using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WpfWardenAPI.Models;

public partial class BlockedUserMessage
{
    [JsonPropertyName("blockedUserMessageId")]
    public int BlockedUserMessageId { get; set; }

    [JsonPropertyName("sendlerUserId")]
    public int SendlerUserId { get; set; }

    [JsonPropertyName("destinationUserId")]
    public int? DestinationUserId { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("sendlerUser")]
    public User SendlerUser { get; set; }
}
