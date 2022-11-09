using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Data.DTOs.Books;
using Test.Data.Entities;
using TestWebAPI.Services.Interfaces;

//using TestWebAPI.Services;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("create-book")]
        public CreateBookResponse? CreateBook(CreateBookRequest model)
        {
            return _bookService.CreateBook(model);
        }

        [HttpGet("get-allbook")]
        public IEnumerable<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpPut("update-book")]
        public UpdateBookResponse? UpdateBook(UpdateBookRequest model , int id)
        {
            return _bookService.UpdateBook(model, id);
        }

        [HttpDelete("delete-book")]
        public bool DeleteBook(DeleteBook model ,int id)
        {
            return _bookService.DeleteBook(model, id);
        }

    }
}
