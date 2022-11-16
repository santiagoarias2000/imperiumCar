﻿using imperiumCar2.Models;
using imperiunCar2.Data.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using imperiunCar2.Data.ViewModels;

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
            var data = await _service.GetAllAsync(tp => tp.TypePerson);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(tp => tp.TypePerson);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(
                    n => n.Name.Contains(searchString)
                ).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }

        // Get: Person/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetPersonByIdAsync(id);
            return View(data);
        }

        // Get: Person/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewPersonDropdownsValues();
            ViewBag.TypePerson = new SelectList(
                movieDropdownsData.TypePerson, "Id", "TypePersonName"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewTypePersonVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewPersonDropdownsValues();
                ViewBag.TypePerson = new SelectList(movieDropdownsData.TypePerson, "Id", "TypePersonName");;

                return View(movie);
            }
            await _service.AddNewPersonAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        // Get: Movie/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var personDetails = await _service.GetPersonByIdAsync(id);
            if (personDetails == null) return View("NotFound");

            var response = new NewTypePersonVM()
            {
                Id = personDetails.Id,
                Document= personDetails.Document,
                Name = personDetails.Name,
                LastName = personDetails.LastName,
                PhoneNumber = personDetails.PhoneNumber,
                IdTypePerson = personDetails.IdTypePerson,
            };

            var movieDropdownsData = await _service.GetNewPersonDropdownsValues();
            ViewBag.TypePerson = new SelectList(movieDropdownsData.TypePerson, "Id", "TypePersonName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewTypePersonVM person)
        {
            if (id != person.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewPersonDropdownsValues();
                ViewBag.TypePerson = new SelectList(movieDropdownsData.TypePerson, "Id", "TypePersonName");

                return View(person);
            }
            await _service.UpdatePersonAsync(person);
            return RedirectToAction(nameof(Index));
        }
    }
}
