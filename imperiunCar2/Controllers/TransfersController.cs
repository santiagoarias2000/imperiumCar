using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using imperiumCar2.Data.ViewModels;

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
            var data = await _service.GetAllAsync(v => v.Vehicle);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(v => v.Vehicle);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(
                    n => n.Vehicle.LicensePlate.Contains(searchString)
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
            ViewBag.Vehicles = new SelectList(
                movieDropdownsData.Vehicles, "Id", "LicensePlate"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewVehicleVM newVehicle)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewTransfersDropdownsValues();
                ViewBag.Vehicles = new SelectList(movieDropdownsData.Vehicles, "Id", "LicensePlate"); 

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
                ValueTrans = transfersDetails.ValueTrans
            };

            var movieDropdownsData = await _service.GetNewTransfersDropdownsValues();
            ViewBag.Vehicles = new SelectList(movieDropdownsData.Vehicles, "Id", "LicensePlate");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewVehicleVM vehicle)
        {
            if (id != vehicle.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewTransfersDropdownsValues();
                ViewBag.Vehicles = new SelectList(movieDropdownsData.Vehicles, "Id", "LicensePlate");

                return View(vehicle);
            }
            await _service.UpdateTransfersAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }
    }
}

