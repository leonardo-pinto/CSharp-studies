﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace CrudExample.Controllers
{
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        // private fields
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;

        public PersonsController(IPersonsService personsService, ICountriesService countriesService)
        {
            _personsService = personsService;
            _countriesService = countriesService;
        }


        [Route("[action]")]
        [Route("/")]
        // receive parameters on View to perform search
        public async Task<IActionResult> Index(
            string searchBy, 
            string? searchString, 
            string sortBy = nameof(PersonResponse.PersonName), 
            SortOrderOptions sortOrder = SortOrderOptions.ASC
        )
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(PersonResponse.PersonName), "Person Name" },
                { nameof(PersonResponse.Email), "Email" },
                { nameof(PersonResponse.DateOfBirth), "Date of Birth" },
                { nameof(PersonResponse.Gender), "Gender" },
                { nameof(PersonResponse.Address), "Address" },
                { nameof(PersonResponse.Country), "Country" },
            };

            List<PersonResponse> persons = await _personsService.GetFilteredPersons(searchBy, searchString);

            // Sort
            List<PersonResponse> sortedPersons = await _personsService.GetSortedPersons(persons, sortBy, sortOrder);

            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;
            return View(sortedPersons); // View/Persons/Index.cshtml
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            List<CountryResponse> countries = await _countriesService.GetAllCountries();
            ViewBag.Countries = countries.Select(item => new SelectListItem() { Text = item.CountryName, Value = item.CountryID.ToString() });

            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(PersonAddRequest personAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<CountryResponse> countries = await _countriesService.GetAllCountries();
                ViewBag.Countries = countries;
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).SelectMany(e => e.ErrorMessage).ToList();
                return View();
            }

            await _personsService.AddPerson(personAddRequest);
            return RedirectToAction("Index", "Persons");
        }

        [HttpGet]
        [Route("[action]/{personID}")]
        public async Task<IActionResult> Edit(Guid personID)
        {
            PersonResponse? personResponse = await _personsService.GetPersonByPersonID(personID);
            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            PersonUpdateRequest personUpdateRequest = personResponse.ToPersonUpdateRequest();

            List<CountryResponse> countries = await _countriesService.GetAllCountries();
            ViewBag.Countries = countries.Select(item => new SelectListItem() { Text = item.CountryName, Value = item.CountryID.ToString() });

            return View(personUpdateRequest);
        }

        [HttpPost]
        [Route("[action]/{personID}")]
        public async Task<IActionResult> Edit(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse? personResponse = await _personsService.GetPersonByPersonID(personUpdateRequest.PersonID);
            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                PersonResponse updatedPerson = await _personsService.UpdatePerson(personUpdateRequest);
                return RedirectToAction("Index");

            }
            else
            {
                List<CountryResponse> countries = await _countriesService.GetAllCountries();
                ViewBag.Countries = countries.Select(item => new SelectListItem() { Text = item.CountryName, Value = item.CountryID.ToString() });
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).SelectMany(e => e.ErrorMessage).ToList();
                return View(personResponse.ToPersonUpdateRequest()); ;
            }
        }

        [HttpGet]
        [Route("[action]/{personID}")]
        public async Task<IActionResult> Delete(Guid? personID)
        {
            PersonResponse? personResponse = await _personsService.GetPersonByPersonID(personID);
            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            return View(personResponse);
        }

        [HttpPost]
        [Route("[action]/{personID}")]
        public async Task<IActionResult> Delete(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse? personResponse = await _personsService.GetPersonByPersonID(personUpdateRequest.PersonID);
            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            await _personsService.DeletePerson(personUpdateRequest.PersonID);
            return RedirectToAction("Index");
        }

        [Route("persons-pdf")]
        public async Task<IActionResult> PersonsPDF()
        {
            // get list of persons
            List<PersonResponse> persons = await _personsService.GetAllPersons();

            return new ViewAsPdf("PersonsPDF", persons, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Top = 20,
                    Right = 20,
                    Bottom = 20,
                    Left = 20,
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }

        [Route("persons-csv")]
        public async Task<IActionResult> PersonsCSV()
        {
            MemoryStream memoryStream = await _personsService.GetPersonsCSV();

            return File(memoryStream, "application/octet-stream", "persons.csv");
        }
    }
}
