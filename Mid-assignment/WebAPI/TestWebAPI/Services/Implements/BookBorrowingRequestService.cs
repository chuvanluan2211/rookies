using Test.Data.DTOs.SuperUsers;
using TestWebAPI.Services.Interfaces;
using TestWebAPI.Repositories.Interfaces;
using Test.Data.Entities;
using Test.Data.DTOs.NormalUsers;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private readonly IBookBorrowingRequestRepository _request;

        public BookBorrowingRequestService(IBookBorrowingRequestRepository request)
        {
            _request = request;
        }

        public IEnumerable<AllBookRequest> GetAllRequestDetail(int id)
        {
            return _request.GetAllBookUser(id);
        }

        public BookBorrowingRequest? CreateARequest( string name, int id)
        {
            using (var transaction = _request.DatabaseTransaction())
            {
                try
                {
                    var checkrequest = _request.CheckRequest(id);
                    if(checkrequest < 3)
                    {
                        var request = new BookBorrowingRequest
                        {
                            AcceptUser = "",
                            Status = "W",
                            RequestUser = name,
                            DateOfRequest = DateTime.Now.Date,
                            UserId = id
                        };

                        var newRequest = _request.Create(request);

                        _request.SaveChanges();
                        transaction.Commit();

                        return newRequest;
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

        public UpdateStatusResponse? UpdateStatus(UpdateStatusRequest model, int id)
        {
            using (var transaction = _request.DatabaseTransaction())
            {
                try
                {
                    var status = _request.GetById(s => s.BookRequestId == id);

                    if (status != null)
                    {
                        status.Status = model.Status;

                        var updateStatus = _request.Update(status);

                        _request.SaveChanges();
                        transaction.Commit();

                        return new UpdateStatusResponse
                        {
                            BookRequestId = updateStatus.BookRequestId,
                            Status = updateStatus.Status,
                            AcceptUser = updateStatus.AcceptUser,
                            DateOfRequest = updateStatus.DateOfRequest,
                            RequestUser = updateStatus.RequestUser,
                            UserId = updateStatus.UserId
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
