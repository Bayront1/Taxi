using System;
using System.Collections.Generic;

namespace TaxiAPI.Models;

public partial class Ride
{
    public int RideId { get; set; }

    public int? PassengerId { get; set; }

    public int? DriverId { get; set; }


}
