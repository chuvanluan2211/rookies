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

        private readonly IBookBorrowingRequestRepository _status;

        public BookBorrowingRequestDetailService(IBookBorrowingRequestDetailRepository detail, IBookBorrowingRequestRepository status)
        {
            _detail = detail;
            _status = status;
        }

        public CreateBookDetailResponse? CreateBookDetail(CreateBookDetailRequest model)
        {
            using (var transaction = _detail.DatabaseTransaction())
            {
                try
                {
                    var idCheck = _status.GetById(s => s.BookRequestId == model.BookRequestId);
                    if (idCheck != null)
                    {
                        
                            var request = new BookBorrowingRequestDetail
                            {
                                BookRequestId = model.BookRequestId,
                                BookId = model.BookId,
                            };

                            var newRequest = _detail.Create(request);

                            _detail.SaveChanges();
                            transaction.Commit();

                            return new CreateBookDetailResponse
                            {
                                RequestDetailId = newRequest.RequestDetailId,
                                BookId = newRequest.BookId,
                                BookRequestId = newRequest.BookRequestId
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

        public IEnumerable<BookBorrowingRequestDetail> GetAll(int id)
        {
            var detail = _detail.GetAll(s => s.BookRequestId == id).ToList();

            return detail;
        }
    }
}
