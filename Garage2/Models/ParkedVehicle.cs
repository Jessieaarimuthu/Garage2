using System.ComponentModel.DataAnnotations;

namespace Garage2.Models;
public enum VehicleType
{
    Car = 1,
    Truck,
    Motorcycle,
    Bicycle,
}

public class ParkedVehicle
{
    [Key]
    public string registrationNumber { get; set; }
    public VehicleType vehicleType { get; set; }
    public string color { get; set; }
    public string brand { get; set; }
    public string model { get; set; }
    public int numberOfWheels { get; set; }
    public DateTime arrivalTime { get; set; }
}
