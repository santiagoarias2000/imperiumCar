using Microsoft.AspNetCore.Mvc;
using imperiunCar2.Data.Service;
using imperiumCar2.Models;

namespace imperiunCar2.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehiclesService _service;
        public VehiclesController(IVehiclesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allData = await _service.GetAllAsync();
            return View(allData);
        }
        //Get: vehicles/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Imagen, Description, PriceBuy, PriceSale, ModelYear, LicensePlate, Sure, TechnicalMechanical")] Vehicles vehicles)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicles);
            }
            await _service.AddAsync(vehicles);
            return RedirectToAction(nameof(Index));
        }
        //Get: vehicles/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var vehiclesDetails = await _service.GetByIdAsync(id);
            if (vehiclesDetails == null) return View("Empty");
            return View(vehiclesDetails);
        }

        //Get: vehicles/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var vehiclesDetails = await _service.GetByIdAsync(id);
            if (vehiclesDetails == null) return View("NotFound");
            return View(vehiclesDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Imagen, Description, PriceBuy, PriceSale, ModelYear, LicensePlate, Sure, TechnicalMechanical")] Vehicles vehicles)
        {
            if (!ModelState.IsValid)
            {
                //view data error...
                //var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View(vehicles);
            }
            await _service.UpdateAsync(id, vehicles);
            return RedirectToAction(nameof(Index));
        }
        //Get: vehicles/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

