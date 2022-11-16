using imperiumCar2.Models;
using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imperiunCar2.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractsService _service;
        public ContractController(IContractsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allData = await _service.GetAllAsync();
            return View(allData);
        }
        //Get: Contracts/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("SaleValue, Description")] Contracts contracts)
        {
            if (!ModelState.IsValid)
            {
                return View(contracts);
            }
            await _service.AddAsync(contracts);
            return RedirectToAction(nameof(Index));
        }
        //Get: Contracts/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var contractsDetails = await _service.GetByIdAsync(id);
            if (contractsDetails == null) return View("Empty");
            return View(contractsDetails);
        }
        //Get: Contracts/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var CarBrandsDetails = await _service.GetByIdAsync(id);
            if (CarBrandsDetails == null) return View("NotFound");
            return View(CarBrandsDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SaleValue, Description")] Contracts contracts)
        {
            if (!ModelState.IsValid)
            {
                //view data error...
                //var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View(contracts);
            }
            await _service.UpdateAsync(id, contracts);
            return RedirectToAction(nameof(Index));

        }
        //Get: Contracts/Delete/id
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
