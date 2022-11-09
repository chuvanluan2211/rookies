using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;

namespace TestWebAPI.Repositories.Implements
{
    public class BookBorrowingRequestDetailRepository : BaseRepository<BookBorrowingRequestDetail>, IBookBorrowingRequestDetailRepository
    {
        public BookBorrowingRequestDetailRepository(BookContext context) : base(context)
        {
        }
    }
}
