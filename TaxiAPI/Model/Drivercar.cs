using System;
using System.Collections.Generic;

namespace TaxiAPI.Models;

public partial class Drivercar
{
    public int CarId { get; set; }

    public int DriverId { get; set; }

    public string? CarModel { get; set; }

    public string? CarColor { get; set; }

    public string? CarPlateNumber { get; set; }

}
