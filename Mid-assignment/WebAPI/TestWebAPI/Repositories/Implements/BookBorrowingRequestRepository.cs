using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Test.Data;
using Test.Data.DTOs.NormalUsers;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;

namespace TestWebAPI.Repositories.Implements
{
    public class BookBorrowingRequestRepository : BaseRepository<BookBorrowingRequest>, IBookBorrowingRequestRepository
    {
        public BookBorrowingRequestRepository(BookContext context) : base(context)
        {
        }

        public int CheckRequest(int id)
        {
            var checkRequest = _dbSet.Where(a => a.UserId == id).Select(s => s.DateOfRequest.Month == DateTime.Now.Month).Count(); 
            return checkRequest;
        }

        public IList<AllBookRequest> GetAllBookUser(int id)
        {
            var allRequestUser = _dbSet.Join(_context.BookBorrowingRequestDetails,
                    book => book.BookRequestId,
                    bookRequest => bookRequest.BookRequestId,
                    (book, bookRequest) => new
                    {
                        BookBorrowingRequest = book,
                        BookBorrowingRequestDetail = bookRequest,
                    })
                    //.Include(b => b.BookBorrowingRequestDetail.BookId )
                    .Where(bookId => bookId.BookBorrowingRequest.BookRequestId == id)
                    .Select(i => new AllBookRequest { 
                        BookRequestId = i.BookBorrowingRequestDetail.BookRequestId,
                        BookName = i.BookBorrowingRequestDetail.Book.BookName,
                        Status = i.BookBorrowingRequest.Status
                    }).ToList();
            return allRequestUser;       
        }
    }
}
