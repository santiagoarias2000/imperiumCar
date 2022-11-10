using Microsoft.AspNetCore.Mvc;
using imperiumCar2.Models;
using imperiunCar2.Data.Service;

namespace imperiunCar2.Controllers
{
    public class CarBrandsController : Controller
    {
        private readonly ICarBrandsService _service;
        public CarBrandsController(ICarBrandsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allData = await _service.GetAllAsync();
            return View(allData);
        }
        //Get: Actor/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("NameBrands")] CarBrands carBrands)
        {
            if (!ModelState.IsValid)
            {
                return View(carBrands);
            }
            await _service.AddAsync(carBrands);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var carBrandsDetails = await _service.GetByIdAsync(id);
            if (carBrandsDetails == null) return View("Empty");
            return View(carBrandsDetails);
        }
    }
}
