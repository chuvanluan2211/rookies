using Test.Data.DTOs.SuperUsers;
using TestWebAPI.Services.Interfaces;
using TestWebAPI.Repositories.Interfaces;
using Test.Data.Entities;
using Test.Data.DTOs.NormalUsers;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private readonly IBookBorrowingRequestRepository _status;

        public BookBorrowingRequestService(IBookBorrowingRequestRepository status)
        {
            _status = status;
        }

        public IEnumerable<BookBorrowingRequest> GetAll()
        {
            return _status.GetAll(s => true);
        }

        public BookBorrowingRequest? CreateARequest( string name, int id)
        {
            using (var transaction = _status.DatabaseTransaction())
            {
                try
                {
                    var request = new BookBorrowingRequest
                    {
                        AcceptUser = "",
                        Status = "W",
                        RequestUser = name,
                        DateOfRequest = DateTime.Now.Date,
                        UserId = id
                    };

                    var newRequest = _status.Create(request);

                    _status.SaveChanges();
                    transaction.Commit();

                    return newRequest;
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
            using (var transaction = _status.DatabaseTransaction())
            {
                try
                {
                    var status = _status.GetById(s => s.BookRequestId == id);

                    if (status != null)
                    {
                        status.Status = model.Status;

                        var updateStatus = _status.Update(status);

                        _status.SaveChanges();
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
