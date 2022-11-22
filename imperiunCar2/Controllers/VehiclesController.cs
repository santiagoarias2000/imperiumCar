using Microsoft.AspNetCore.Mvc;
using imperiunCar2.Data.Service;
using imperiumCar2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using imperiumCar2.Data.ViewModels;

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
            var data = await _service.GetAllAsync(cb => cb.CarsBrands);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(cb => cb.CarsBrands);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(
                    n => n.LicensePlate.Contains(searchString)
                ).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }

        // Get: Person/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetVehiclesByIdAsync(id);
            return View(data);
        }

        // Get: Person/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewVehiclesDropdownsValues();
            ViewBag.CarBrands = new SelectList(
                movieDropdownsData.CarBrands, "Id", "NameBrands"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCarBrandsVM CarBrands)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewVehiclesDropdownsValues();
                ViewBag.CarBrands = new SelectList(movieDropdownsData.CarBrands, "Id", "NameBrands"); ;

                return View(CarBrands);
            }
            await _service.AddNewVehiclesAsync(CarBrands);
            return RedirectToAction(nameof(Index));
        }

        // Get: Movie/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleDetails = await _service.GetVehiclesByIdAsync(id);
            if (vehicleDetails == null) return View("NotFound");

            var response = new NewCarBrandsVM()
            {
                Id = vehicleDetails.Id,
                PriceBuy = vehicleDetails.PriceBuy,
                PriceSale = vehicleDetails.PriceSale,
                LicensePlate = vehicleDetails.LicensePlate,
                Sure = vehicleDetails.Sure,
                Description = vehicleDetails.Description,
                Imagen = vehicleDetails.Imagen,
                TechnicalMechanical = vehicleDetails.TechnicalMechanical,
                ModelYear = vehicleDetails.ModelYear,
                TypesCars = vehicleDetails.TypesCars,
                IdCarsBrands = vehicleDetails.IdCarsBrands,
            };

            var movieDropdownsData = await _service.GetNewVehiclesDropdownsValues();
            ViewBag.CarBrands = new SelectList(movieDropdownsData.CarBrands, "Id", "NameBrands");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCarBrandsVM carBrands)
        {
            if (id != carBrands.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewVehiclesDropdownsValues();
                ViewBag.CarBrands = new SelectList(movieDropdownsData.CarBrands, "Id", "NameBrands");

                return View(carBrands);
            }
            await _service.UpdateVehiclesAsync(carBrands);
            return RedirectToAction(nameof(Index));
        }
    }
}

