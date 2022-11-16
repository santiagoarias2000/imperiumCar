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
        //Get: CarBrands/Create
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
        //Get: CarBrands/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var carBrandsDetails = await _service.GetByIdAsync(id);
            if (carBrandsDetails == null) return View("Empty");
            return View(carBrandsDetails);
        }

        //Get: CarBrands/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var CarBrandsDetails = await _service.GetByIdAsync(id);
            if (CarBrandsDetails == null) return View("NotFound");
            return View(CarBrandsDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, NameBrands")] CarBrands carBrands)
        {
            if (!ModelState.IsValid)
            {
                //view data error...
                //var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View(carBrands);
            }
            await _service.UpdateAsync(id, carBrands);
            return RedirectToAction(nameof(Index));

        }
        //Get: CarBrands/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var carBrandsDetails = await _service.GetByIdAsync(id);

            if (carBrandsDetails == null) return View("NotFound");
            return View(carBrandsDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carBrandsDetails = await _service.GetByIdAsync(id);
            if (carBrandsDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
