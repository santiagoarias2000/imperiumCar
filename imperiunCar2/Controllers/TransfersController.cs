using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Mvc;
using imperiumCar2.Models;

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
            var allData = await _service.GetAllAsync();
            return View(allData);
        }
        //Get: Actor/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Value")] Transfers transfers)
        {
            if (!ModelState.IsValid)
            {
                return View(transfers);
            }
            await _service.AddAsync(transfers);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var transfersDetails = await _service.GetByIdAsync(id);
            if (transfersDetails == null) return View("Empty");
            return View(transfersDetails);
        }
    }
}

