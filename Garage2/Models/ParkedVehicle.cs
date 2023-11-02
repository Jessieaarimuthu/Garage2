using System.ComponentModel.DataAnnotations;

namespace Garage2.Models;
public enum VehicleType
{
    Car = 1,
    Truck,
    Motorcycle,
}

public class ParkedVehicle
{
    [Key]
    [Display(Name = "Registration Number")]
    public string RegistrationNumber { get; set; }
    [Display(Name = "Vehicle Type")]
    public VehicleType VehicleType { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    [Display(Name = "Number Of Wheels")]
    public int NumberOfWheels { get; set; }
    [Display(Name = "Arrival Time")]
    public DateTime ArrivalTime { get; set; }
}
