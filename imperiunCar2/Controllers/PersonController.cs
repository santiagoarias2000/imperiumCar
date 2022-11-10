using imperiumCar2.Models;
using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace imperiunCar2.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _service;
        public PersonController(IPersonService service)
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
        public async Task<IActionResult> Create([Bind("SaleValue, Description")] Persons persons)
        {
            if (!ModelState.IsValid)
            {
                return View(persons);
            }
            await _service.AddAsync(persons);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var contractsDetails = await _service.GetByIdAsync(id);
            if (contractsDetails == null) return View("Empty");
            return View(contractsDetails);
        }
    }
}
