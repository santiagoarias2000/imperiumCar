using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Mvc;
using imperiumCar2.Models;


namespace imperiunCar2.Controllers
{
    public class TypesPersonsController : Controller
    {
        private readonly ITypesPersonsService _service;
        public TypesPersonsController(ITypesPersonsService service)
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
        public async Task<IActionResult> Create([Bind("TypePersonName")] TypesPersons typePerson)
        {
            if (!ModelState.IsValid)
            {
                return View(typePerson);
            }
            await _service.AddAsync(typePerson);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var typePersonDetails = await _service.GetByIdAsync(id);
            if (typePersonDetails == null) return View("Empty");
            return View(typePersonDetails);
        }
    }
}

