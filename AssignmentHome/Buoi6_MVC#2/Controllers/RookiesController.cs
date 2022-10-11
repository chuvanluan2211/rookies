using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Buoi6_MVC_2.Models;
using CsvHelper;

namespace Buoi6_MVC_2.Controllers;

public class RookiesController : Controller
{

    private static List<PersonModel> _people = new List<PersonModel>
    {
        new PersonModel
        {
            FirstName = "Tien",
            LastName =  "Nguyen",
            Gender = "Male",
            DOB = new DateTime(2000 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Ha Noi",
            IsGraduated = false,
        },
        new PersonModel
        {
            FirstName = "Luan",
            LastName =  "Chu Van",
            Gender = "Male",
            DOB = new DateTime(2001 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Hung Yen",
            IsGraduated = false,
        },
        new PersonModel
        {
            FirstName = "Vinh",
            LastName =  "Nguyen",
            Gender = "Male",
            DOB = new DateTime(1999 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Ha Noi",
            IsGraduated = false,
        },
        new PersonModel
        {
            FirstName = "Ha",
            LastName =  "Nguyen",
            Gender = "FeMale",
            DOB = new DateTime(1989 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Ha Noi",
            IsGraduated = false,
        },

    };
    private readonly ILogger<RookiesController> _logger;

    public RookiesController(ILogger<RookiesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_people);
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

            _people.Add(person);

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        if (index >= 0 && index < _people.Count)
        {
            var person = _people[index];
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

            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.PhoneNumber = model.PhoneNumber;
                person.BirthDay = model.BirthDay;

                //_people[index] = person;
            }

            return RedirectToAction("Index");
        }

        return View(model);
    }

    public IActionResult Delete(int index)
    {
        if (index >= 0 && index < _people.Count)
        {
           _people.RemoveAt(index);

        }
        return RedirectToAction("index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
