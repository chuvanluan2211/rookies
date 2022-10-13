using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Buoi6_MVC_3.Models;
using Buoi6_MVC_3.Services;
using CsvHelper;

namespace Buoi6_MVC_3.Controllers;

public class RookiesController : Controller
{

    private readonly ILogger<RookiesController> _logger;

    private readonly IPersonService _personService;

    public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    public IActionResult Index()
    {
        var model = _personService.GetAll();
        return View(model);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(PersonCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DOB = model.DOB,
                BirthDay = model.BirthDay,
                PhoneNumber = model.PhoneNumber,
                IsGraduated = false
            };

            _personService.Create(person);

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        var person = _personService.GetOne(index);

        if (person != null)
        {
            var model = new PersonUpdateModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDay = person.BirthDay,
                PhoneNumber = person.PhoneNumber,
            };
            ViewData["Index"] = index;

            return View(model);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Update(int index, PersonUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.PhoneNumber = model.PhoneNumber;
                person.BirthDay = model.BirthDay;

                _personService.Update(index, person);
            }

            return RedirectToAction("Index");
        }

        return View(model);
    }

    public IActionResult Details(int index)
    {
        var person = _personService.GetOne(index);

        if (person != null)
        {
            var model = new PersonDetailModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DOB = person.DOB,
                BirthDay = person.BirthDay,
                PhoneNumber = person.PhoneNumber,
            };
            ViewData["Index"] = index;

            return View(model);
        }
        return View();
    }

    public IActionResult Delete(int index)
    {
        var person = _personService.Delete(index);
        ViewData["Index"] = index;

        if (person == null)
        {
            return NotFound();
        }

        return RedirectToAction("index");
    }

    public IActionResult DeleteAndRedirectToView(int index)
    {
        var person = _personService.Delete(index);

        if (person == null)
        {
            return NotFound();
        }

        HttpContext.Session.SetString("DeleteName" , person.FullName);


        return RedirectToAction("DeleteResult");
    }

    public IActionResult DeleteResult()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
