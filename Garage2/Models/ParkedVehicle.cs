using System.ComponentModel.DataAnnotations;

namespace Garage2.Models;
public enum VehicleType
{
    A,
    A1,
    B,
    B1,
    BE,
    C,
    C1,
    C1E,
    CE,
    D,
    D1,
    D1E,
    DE,
}


public readonly record struct RegistryNumber
{
    public RegistryNumber(NationCode Nationality, string SerialNumber)
    {
        this.Nationality = Nationality;
        // ensure serial number contains only letters, digits and hyphens
        if (SerialNumber.Any(c => !(char.IsLetterOrDigit(c) || c == '-')))
        {
            throw new ArgumentException("Serial number must contain only letters, digits and hyphens");
        }
        this.SerialNumber = SerialNumber.ToUpperInvariant();
    }
    public NationCode Nationality { get; }
    public string SerialNumber { get; }

    public static implicit operator RegistryNumber(string registryNumberString)
    {
        string[] parts = registryNumberString.ToUpperInvariant().Split(' ');
        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid registry number string format");
        }
        NationCode nationality = Enum.Parse<NationCode>(parts[0]);
        string serialNumber = parts[1];
        return new RegistryNumber(nationality, serialNumber);
    }

    public override string ToString()
    {
        return $"{Nationality} {SerialNumber}";
    }

}


public class ParkedVehicle
{
    [Key]
    public RegistryNumber RegistrationNumber { get; set; }
    public VehicleType VehicleType { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int NumberOfWheels { get; set; }
    public DateTime ArrivalTime { get; set; }

    public ParkedVehicle(RegistryNumber registrationNumber, VehicleType vehicleType, string color, string brand, string model, int numberOfWheels, DateTime arrivalTime)
    {
        this.RegistrationNumber = registrationNumber;
        this.VehicleType = vehicleType;
        this.Color = color;
        this.Brand = brand;
        this.Model = model;
        this.NumberOfWheels = numberOfWheels;
        this.ArrivalTime = arrivalTime;
    }
}

