using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Mvc;
using imperiumCar2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using imperiunCar2.Data.ViewModels;

namespace imperiunCar2.Controllers
{
    public class TransfersController: Controller
    {
        private readonly ITransfersService _service;
        public TransfersController(ITransfersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(tp => tp.Vehicle);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(tp => tp.Vehicle);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(
                    n => n.Vehicle.Description.Contains(searchString)
                ).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }

        // Get: Person/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetTransfersByIdAsync(id);
            return View(data);
        }

        // Get: Person/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewTransfersDropdownsValues();
            ViewBag.TypePerson = new SelectList(
                movieDropdownsData.Vehicles, "Id", "Description"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewVehicleVM newVehicle)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewTransfersDropdownsValues();
                ViewBag.TypePerson = new SelectList(movieDropdownsData.Vehicles, "Id", "Description"); 

                return View(newVehicle);
            }
            await _service.AddNewTransfersAsync(newVehicle);
            return RedirectToAction(nameof(Index));
        }

        // Get: Transfer/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var transfersDetails = await _service.GetTransfersByIdAsync(id);
            if (transfersDetails == null) return View("NotFound");

            var response = new NewVehicleVM()
            {
                Id = transfersDetails.Id,
                IdVehicle = transfersDetails.IdVehicle,
            };

            var movieDropdownsData = await _service.GetNewTransfersDropdownsValues();
            ViewBag.Vehicles(movieDropdownsData.Vehicles, "Id", "Description");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewTypePersonVM vehicle)
        {
            if (id != vehicle.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewTransfersDropdownsValues();
                ViewBag.Vehicles = new SelectList(movieDropdownsData.Vehicles, "Id", "Description");

                return View(vehicle);
            }
            //await _service.UpdateTransfersAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }
    }
}

