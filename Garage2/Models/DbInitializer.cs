﻿using Garage2.Data;
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
                        RegistrationNumber = "XTV213",
                        VehicleType = VehicleType.B,
                        Color = "Silver",
                        Brand = "Volkswagen",
                        Model = "Golf",
                        NumberOfWheels = 4,
                        ArrivalTime = new DateTime(2019, 01, 23),
                    },
                    new ParkedVehicle
                    {
                        RegistrationNumber = "ABC123",
                        VehicleType = VehicleType.B,
                        Color = "Blue",
                        Brand = "Ford",
                        Model = "Mustang",
                        NumberOfWheels = 4,
                        ArrivalTime = new DateTime(2020, 05, 15)
                    },
                    new ParkedVehicle
                    {
                        RegistrationNumber = "XYZ789",
                        VehicleType = VehicleType.B,
                        Color = "Red",
                        Brand = "Toyota",
                        Model = "Camry",
                        NumberOfWheels = 4,
                        ArrivalTime = new DateTime(2021, 11, 10)
                    },
                    new ParkedVehicle
                    {
                        RegistrationNumber = "MOT456",
                        VehicleType = VehicleType.A,
                        Color = "Black",
                        Brand = "Honda",
                        Model = "CBR600RR",
                        NumberOfWheels = 2,
                        ArrivalTime = new DateTime(2020, 07, 12)
                    },
                    new ParkedVehicle
                    {
                        RegistrationNumber = "TRK001",
                        VehicleType = VehicleType.C,
                        Color = "White",
                        Brand = "Ford",
                        Model = "F-150",
                        NumberOfWheels = 6, // Trucks often have multiple wheels
                        ArrivalTime = new DateTime(2019, 08, 05)
                    },
                    new ParkedVehicle
                    {
                        RegistrationNumber = "TRK002",
                        VehicleType = VehicleType.C,
                        Color = "Blue",
                        Brand = "Chevrolet",
                        Model = "Silverado",
                        NumberOfWheels = 8, // Larger trucks might have more wheels
                        ArrivalTime = new DateTime(2020, 03, 15)
                    },
                    new ParkedVehicle
                    {
                        RegistrationNumber = "BUS001",
                        VehicleType = VehicleType.C,
                        Color = "Red",
                        Brand = "Volvo",
                        Model = "XC90",
                        NumberOfWheels = 6, // Adjust this based on the specific bus type
                        ArrivalTime = new DateTime(2022, 07, 10)
                    }
                );
            }

            _context.SaveChanges();
        }
    }
}
