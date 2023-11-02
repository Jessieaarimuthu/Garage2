using Garage2.Data;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace Garage2.Models
{
	public static class DbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			Garage2Context _context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Garage2Context>();

			if (!_context.ParkedVehicle.Any())
			{
				_context.AddRange(
				new ParkedVehicle
				{
					registrationNumber = "XTV213",
					vehicleType = VehicleType.Car,
					color = "Silver",
					brand = "Volkswagen",
					model = "Golf",
					numberOfWheels = 4,
					arrivalTime = new DateTime(2019, 01, 23),
				},
				new ParkedVehicle
				{
					registrationNumber = "ABC123",
					vehicleType = VehicleType.Car,
					color = "Blue",
					brand = "Ford",
					model = "Mustang",
					numberOfWheels = 4,
					arrivalTime = new DateTime(2020, 05, 15)
				},
				new ParkedVehicle
				{
					registrationNumber = "XYZ789",
					vehicleType = VehicleType.Car,
					color = "Red",
					brand = "Toyota",
					model = "Camry",
					numberOfWheels = 4,
					arrivalTime = new DateTime(2021, 11, 10)
				},
				new ParkedVehicle
				{
					registrationNumber = "MOT456",
					vehicleType = VehicleType.Motorcycle,
					color = "Black",
					brand = "Honda",
					model = "CBR600RR",
					numberOfWheels = 2,
					arrivalTime = new DateTime(2020, 07, 12)
				},
				new ParkedVehicle
				{
					registrationNumber = "TRK001",
					vehicleType = VehicleType.Truck,
					color = "White",
					brand = "Ford",
					model = "F-150",
					numberOfWheels = 6, // Trucks often have multiple wheels
					arrivalTime = new DateTime(2019, 08, 05)
				},
				new ParkedVehicle
				{
					registrationNumber = "TRK002",
					vehicleType = VehicleType.Truck,
					color = "Blue",
					brand = "Chevrolet",
					model = "Silverado",
					numberOfWheels = 8, // Larger trucks might have more wheels
					arrivalTime = new DateTime(2020, 03, 15)
				}
				);
			}

			_context.SaveChanges();
		}
	}
}
