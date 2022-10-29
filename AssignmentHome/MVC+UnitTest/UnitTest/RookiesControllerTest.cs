using NUnit.Framework;
using Buoi6_MVC_3.Controllers;
using Buoi6_MVC_3.Services;
using Buoi6_MVC_3.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTest;

public class RookiesControllerTest
{
    private RookiesController _rookiesController;
    private Mock<IPersonService> _personService;

    private Mock<PersonServiceExtended> _personServiceEx;

    [SetUp]
    public void Setup()
    {
        _personService = new Mock<IPersonService>();
        _rookiesController = new RookiesController(_personService.Object);
        _personServiceEx = new Mock<PersonServiceExtended>();
    }

    [Test]
    public void CreatePerson_Success()
    {
        var mockModel = new PersonCreateModel
        {
            FirstName = "Luan",
            LastName = "chu",
            Gender = "male",
            DOB = new DateTime(2001, 2, 12)
        };

        var result = _rookiesController.Create(mockModel);

        Assert.IsInstanceOf<RedirectToActionResult>(result);

        Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);

    }

    [Test]
    public void Detail_ReturnView_Valid()
    {
        var expectResult = new PersonModel
        {
            FirstName = "Luan",
            LastName = "Chu"
        };
        _personService.Setup(a => a.GetOne(It.IsAny<int>())).Returns(expectResult);

        var index = 0;
        var result = _rookiesController.Details(index) as ViewResult;
        var returnResult = result.Model as PersonModel;

        Assert.IsNotNull(result);

        Assert.AreEqual(expectResult.FirstName, returnResult.FirstName);

        Assert.AreEqual(expectResult.LastName, returnResult.LastName);
    }

    [Test]
    public void Delete_ReturnView_InValid()
    {
        int index = 0;
        var expectResult = _rookiesController.Delete(index);

        Assert.IsInstanceOf<NotFoundResult>(expectResult);

    }

    [Test]
    public void Delete_ReturnView_Valid()
    {
        int index = 1;
        var expectResult = _rookiesController.Delete(index);

        Assert.IsInstanceOf<RedirectToActionResult>(expectResult);

        Assert.AreEqual("Index", (expectResult as RedirectToActionResult).ActionName);
    }

    [Test]
    public void GetAllPerson_ReturnView_Valid()
    {
        var expectResult = new List<PersonModel>
        { new PersonModel
        {
            FirstName = "Luan",
            LastName = "Chu"
        },
        new PersonModel
        {
            FirstName = "Tuan",
            LastName = "Ha"
        }
        };

        _personService.Setup(a => a.GetAll()).Returns(expectResult);
        
        var result = _rookiesController.Index();

        Assert.IsInstanceOf<ViewResult>(result);

        var view = (ViewResult)result;

        Assert.IsInstanceOf<List<PersonModel>>(view.Model);

        var viewResult = (List<PersonModel>)view.Model;


        Assert.AreEqual(expectResult.Count, viewResult.Count);

    }
}