using Test.Data.DTOs.Books;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookService
    {
        CreateBookResponse? CreateBook(CreateBookRequest model);

        UpdateBookResponse? UpdateBook(UpdateBookRequest model ,int id);

        bool DeleteBook(DeleteBook model , int id);

        IEnumerable<Book> GetAll();
    }
}
