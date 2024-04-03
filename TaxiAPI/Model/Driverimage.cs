using System;
using System.Collections.Generic;

namespace TaxiAPI.Models;
public partial class Driverimage
{
    public int DriverImagesId { get; set; }

    public int DriverId { get; set; }

    public byte[] ImageData { get; set; } = null!;

}
