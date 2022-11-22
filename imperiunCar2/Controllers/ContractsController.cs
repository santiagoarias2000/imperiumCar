using imperiumCar2.Data.ViewModels;
using imperiumCar2.Models;
using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace imperiunCar2.Controllers
{
    public class ContractsController : Controller
    {
        private readonly IContractsService _service;
        public ContractsController(IContractsService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(p => p.Persons, v => v.Vehicle);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(p => p.Persons, v => v.Vehicle);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(
                    n => n.Persons.Name.Contains(searchString)
                ).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }

        // Get: Person/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetConstractsByIdAsync(id);
            return View(data);
        }

        // Get: Person/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewContractsDropdownsValues();
            ViewBag.Persons = new SelectList(
                movieDropdownsData.Persons, "Id", "Document"
            );
            ViewBag.Vehicles = new SelectList(
                movieDropdownsData.Vehicles, "Id", "LicensePlate"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewContractsVM contracts)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewContractsDropdownsValues();
                ViewBag.Persons = new SelectList(movieDropdownsData.Persons, "Id", "Document");
                ViewBag.Vehicles = new SelectList(movieDropdownsData.Vehicles, "Id", "LicensePlate");

                return View(contracts);
            }
            await _service.AddNewContractsAsync(contracts);
            return RedirectToAction(nameof(Index));
        }

        // Get: Movie/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var contractsDetails = await _service.GetConstractsByIdAsync(id);
            if (contractsDetails == null) return View("NotFound");

            var response = new NewContractsVM()
            {
                Id = contractsDetails.Id,
                SaleValue = contractsDetails.SaleValue,
                Description = contractsDetails.Description,
                IdPersons = contractsDetails.IdPersons,
                IdVehicle = contractsDetails.IdVehicle
            };

            var movieDropdownsData = await _service.GetNewContractsDropdownsValues();
            ViewBag.Persons = new SelectList(movieDropdownsData.Persons, "Id", "Document");
            ViewBag.Vehicles = new SelectList(movieDropdownsData.Vehicles, "Id", "LicensePlate");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewContractsVM person)
        {
            if (id != person.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewContractsDropdownsValues();
                ViewBag.Persons = new SelectList(movieDropdownsData.Persons, "Id", "Document");
                ViewBag.Vehicles = new SelectList(movieDropdownsData.Vehicles, "Id", "LicensePlate");
                return View(person);
            }
            await _service.UpdateContractsAsync(person);
            return RedirectToAction(nameof(Index));
        }
    }
}
