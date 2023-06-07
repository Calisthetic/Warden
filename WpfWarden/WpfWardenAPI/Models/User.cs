using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WpfWardenAPI.Models;

public partial class User
{
    public int userId { get; set; }

    public string firstName { get; set; } = null!;

    public string secondName { get; set; } = null!;

    public string? thirdName { get; set; }

    public string? login { get; set; }

    public string? password { get; set; }

    public string? secretWord { get; set; }

    public int divisionId { get; set; }

    public int? permissionId { get; set; }

    public bool isBlocked { get; set; }

    public bool gender { get; set; }

    public bool isVerify { get; set; }
   
    public Division division { get; set; }
    public Permission permission { get; set; }
}
