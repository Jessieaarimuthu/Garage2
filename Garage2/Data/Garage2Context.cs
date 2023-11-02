﻿using Microsoft.EntityFrameworkCore;
using Garage2.Models;

namespace Garage2.Data
{
    public class Garage2Context : DbContext
    {
        public Garage2Context (DbContextOptions<Garage2Context> options)
            : base(options)
        {
        }

        public DbSet<ParkedVehicle> ParkedVehicle => Set<ParkedVehicle>();
    }
}
