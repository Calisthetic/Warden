using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiCoreWarden.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? ThirdName { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? SecretWord { get; set; }

    public int DivisionId { get; set; }

    public int? PermissionId { get; set; }

    public bool IsBlocked { get; set; }

    public bool Gender { get; set; }

    public bool IsVerify { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<BlockedUserMessage> BlockedUserMessageDestinationUsers { get; set; } = new List<BlockedUserMessage>();

    [JsonIgnore]
    public virtual ICollection<BlockedUserMessage> BlockedUserMessageSendlerUsers { get; set; } = new List<BlockedUserMessage>();

    public virtual Division Division { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Permission? Permission { get; set; }

    [JsonIgnore]
    public virtual ICollection<ProductEnterAct> ProductEnterActs { get; set; } = new List<ProductEnterAct>();
}
