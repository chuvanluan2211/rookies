using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Buoi5_MVC_1.Models;
using CsvHelper;

namespace Buoi5_MVC_1.Controllers;
[Route("NashTech/Rookies")]
[Route("")]

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

    [Route("Index")]
    public IActionResult Index()
    {
        return Json(_people);
        //return View();
    }

    [Route("Male")]
    public IActionResult Male()
    {
        var data = _people.Where(x => x.Gender == "Male");
        return Json(data);
    }

    [Route("Age")]
    public IActionResult Age()
    {
        var max = _people.Max(x => x.Age);
        var data = _people.FirstOrDefault(a => a.Age == max);
        return Json(data);
    }

    [Route("FullName")]
    public IActionResult FullName()
    {
        var data = _people.Select(p => p.FullName);
        return Json(data);
    }

    [Route("GetMemByBirthYear")]
    public IActionResult GetMemByBirthYear(int year, string compareType)
    {
        switch (compareType)
        {
            case "equal":
                return Json(_people.Where(x => x.DOB?.Year == year));
            case "greater":
                return Json(_people.Where(x => x.DOB?.Year > year));
            case "less":
                return Json(_people.Where(x => x.DOB?.Year < year));
            default:
                return Json(null);
        }
    }

    [Route("Mem2000")]
    public IActionResult Mem2000()
    {
        return RedirectToAction("GetMemByBirthYear", new { year = 2000, compareType = "equal" });
    }

    [Route("MemGreater2000")]
    public IActionResult MemGreater2000()
    {
        return RedirectToAction("GetMemByBirthYear", new { year = 2000, compareType = "greater" });
    }

    [Route("MemLess2000")]
    public IActionResult MemLess2000()
    {
        return RedirectToAction("GetMemByBirthYear", new { year = 2000, compareType = "less" });
    }

#region #5

    private byte[] WriteCsvToMemory(IEnumerable<PersonModel> people)
    {
        using (var memoryStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
        {
            csvWriter.WriteRecords(people);
            streamWriter.Flush();
            return memoryStream.ToArray();
        }
    }

    [Route("Export")]
    public FileStreamResult Export()
    {
        var result = WriteCsvToMemory(_people);
        var memoryStream = new MemoryStream(result);

        return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "people.csv" };
    }

    #endregion #5

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
