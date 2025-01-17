﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2.Data;
using Garage2.Models;
using Garage2.Models.ViewModels;

namespace Garage2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage2Context _context;

        public ParkedVehiclesController(Garage2Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            var model = _context.ParkedVehicle.Select(v => new ParkedVehiclesViewModel
            {
                Id = v.Id,
                RegistrationNumber = v.RegistrationNumber,
                VehicleType = v.VehicleType,
                ArrivalTime = v.ArrivalTime
            });

            return View("ParkedVehiclesIndex", await model.ToListAsync());
        }

        //public async Task<IActionResult> Index()
        //{
        //    return _context.ParkedVehicle != null ?
        //        View(await _context.ParkedVehicle.ToListAsync()) :
        //        Problem("Entity set 'Garage2Context.ParkedVehicle'  is null.");
        //}

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegistrationNumber,VehicleType,Color,Brand,Model,NumberOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegistrationNumber,VehicleType,Color,Brand,Model,NumberOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //retrive existing vechicles on database
                    var existingParkedVehicle = await _context.ParkedVehicle.FindAsync(id);

                    //only edit the properties we want the user to be able to edit
                    existingParkedVehicle.RegistrationNumber = parkedVehicle.RegistrationNumber;
                    existingParkedVehicle.Brand = parkedVehicle.Brand;
                    existingParkedVehicle.Color = parkedVehicle.Color;
                    existingParkedVehicle.Model = parkedVehicle.Model;
                    existingParkedVehicle.NumberOfWheels = parkedVehicle.NumberOfWheels;
                    existingParkedVehicle.VehicleType = parkedVehicle.VehicleType;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
          return (_context.ParkedVehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
