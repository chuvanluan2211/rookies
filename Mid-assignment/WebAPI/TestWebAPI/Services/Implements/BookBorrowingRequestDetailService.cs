using Test.Data.DTOs.NormalUsers;
using TestWebAPI.Services.Interfaces;
using TestWebAPI.Repositories.Interfaces;
using Test.Data.Entities;
using System.Collections.Generic;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestDetailService : IBookBorrowingRequestDetailService
    {
        private readonly IBookBorrowingRequestDetailRepository _requestDetail;

        private readonly IBookBorrowingRequestRepository _request;

        public BookBorrowingRequestDetailService(IBookBorrowingRequestDetailRepository detail, IBookBorrowingRequestRepository status)
        {
            _requestDetail = detail;
            _request = status;
        }

        public CreateBookDetailResponse? CreateBookDetail(CreateBookDetailRequest model)
        {
            using (var transaction = _requestDetail.DatabaseTransaction())
            {
                try
                {
                    var idCheck = _request.GetById(s => s.BookRequestId == model.BookRequestId);
                    if (idCheck != null)
                    {

                        var request = new BookBorrowingRequestDetail
                        {
                            BookRequestId = model.BookRequestId,
                            BookId = model.BookId,
                        };

                        var newRequest = _requestDetail.Create(request);

                        _requestDetail.SaveChanges();
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
    }
}
