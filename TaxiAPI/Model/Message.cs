using System;
using System.Collections.Generic;

namespace TaxiAPI.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public string Text { get; set; } = null!;

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }
}
