using System;
using System.Collections.Generic;

namespace TaxiAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public byte[] Image { get; set; } 

    public string? UserType { get; set; }

}
