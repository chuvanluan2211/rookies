using Test.Data.DTOs.Books;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _book;

        private readonly ICategoryRepository _category;

        public BookService(IBookRepository book, ICategoryRepository category)
        {
            _book = book;
            _category = category;
        }
        public CreateBookResponse? CreateBook(CreateBookRequest model)
        {
            using (var transaction = _book.DatabaseTransaction())
            {
                try
                {
                    var cate = _category.GetById(s => s.CategoryId == model.CategoryId);

                    if (cate != null)
                    {
                        var book = new Book
                        {
                           BookName = model.BookName,
                           CategoryId = model.CategoryId,
                           Description = model.Description
                        };

                        var newBook = _book.Create(book);

                        _book.SaveChanges();
                        transaction.Commit();

                        return new CreateBookResponse
                        {
                            BookId = newBook.BookId,
                            BookName = newBook.BookName,
                            Description = newBook.Description,
                            CategoryId = newBook.CategoryId
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public bool DeleteBook(DeleteBook model , int id)
        {
            using (var transaction = _book.DatabaseTransaction())
            {
                try
                {
                    var book = _book.GetById(s => s.BookId == id);

                    if (book != null)
                    {
                        var deleteBook = _book.Delete(book);
                        _book.SaveChanges();
                        transaction.Commit();
                    }
                    return true;
                }
                catch
                {
                    transaction.RollBack();
                    return true;
                }
            }
        }

        public IEnumerable<Book> GetAllBook()
        {
            return _book.GetAll(s => true);
        }

        public UpdateBookResponse? UpdateBook(UpdateBookRequest model , int id)
        {
            using (var transaction = _book.DatabaseTransaction())
            {
                try
                {
                    var book = _book.GetById(s => s.BookId == id);

                    if (book != null)
                    {
                        book.BookName = model.BookName;
                        book.CategoryId = model.CategoryId;
                        book.Description = model.Description;

                        var updateBook = _book.Update(book);

                        _book.SaveChanges();
                        transaction.Commit();

                        return new UpdateBookResponse
                        {
                            BookId = updateBook.BookId,
                            BookName = updateBook.BookName,
                            Description = updateBook.Description,
                            CategoryId = updateBook.CategoryId
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

    }
}
