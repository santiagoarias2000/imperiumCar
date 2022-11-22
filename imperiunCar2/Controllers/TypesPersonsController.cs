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
        //Get: CarBrands/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var typePersonsDetails = await _service.GetByIdAsync(id);

            if (typePersonsDetails == null) return View("NotFound");
            return View(typePersonsDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carBrandsDetails = await _service.GetByIdAsync(id);
            if (carBrandsDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Get: CarBrands/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var CarBrandsDetails = await _service.GetByIdAsync(id);
            if (CarBrandsDetails == null) return View("NotFound");
            return View(CarBrandsDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, TypePersonName")] TypesPersons typesPersons)
        {
            if (!ModelState.IsValid)
            {
                //view data error...
                //var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View(typesPersons);
            }
            await _service.UpdateAsync(id, typesPersons);
            return RedirectToAction(nameof(Index));

        }
    }
}

