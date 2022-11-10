using Test.Data.DTOs.NormalUsers;
using TestWebAPI.Services.Interfaces;
using TestWebAPI.Repositories.Interfaces;
using Test.Data.Entities;
using System.Collections.Generic;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestDetailService : IBookBorrowingRequestDetailService
    {
        private readonly IBookBorrowingRequestDetailRepository _detail;

        public BookBorrowingRequestDetailService(IBookBorrowingRequestDetailRepository detail)
        {
            _detail = detail;
        }

       
        public IEnumerable<BookBorrowingRequestDetail> GetAll(int id)
        {
            var detail = _detail.GetAll(s => s.BookRequestId == id).ToList();

            return detail;
        }
    }
}
