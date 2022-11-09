using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;

namespace TestWebAPI.Repositories.Implements
{
    public class BookBorrowingRequestRepository : BaseRepository<BookBorrowingRequest>, IBookBorrowingRequestRepository
    {
        public BookBorrowingRequestRepository(BookContext context) : base(context)
        {
        }
    }
}
