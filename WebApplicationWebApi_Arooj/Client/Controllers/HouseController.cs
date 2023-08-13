using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Client.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseService _houseService;

        public HouseController(HouseService houseService)
        {
            _houseService = houseService;
        }

        public async Task<IActionResult> Index()
        {
            var houses = await _houseService.GetHousesAsync();
            foreach (var house in houses)
            {
                Debug.WriteLine($"House ID: {house.Id}");
            }
            return View(houses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var house = await _houseService.GetHouseAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HouseDTO house)
        {
            if (ModelState.IsValid)
            {
                await _houseService.CreateHouseAsync(house);
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // Implement Edit and Delete actions similar to Create

        public async Task<IActionResult> Edit(int id)
        {
            var house = await _houseService.GetHouseAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HouseDTO house)
        {
            if (id != house.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update the house details
                await _houseService.UpdateHouseAsync(house); // Implement this method in your service
                return RedirectToAction(nameof(Index));
            }

            return View(house);
        }

            public async Task<IActionResult> Delete(int id)
            {
            await _houseService.DeleteHouseAsync(id); // Implement this method in your service
            return RedirectToAction(nameof(Index));
            }

            


    }
}
