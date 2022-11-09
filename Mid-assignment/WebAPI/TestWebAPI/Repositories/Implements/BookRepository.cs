using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;

namespace TestWebAPI.Repositories.Implements
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookContext context) : base(context)
        {
        }
    }
}
