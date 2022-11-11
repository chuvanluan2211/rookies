using Test.Data.DTOs.NormalUsers;
using Test.Data.DTOs.SuperUsers;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestService
    {

        UpdateStatusResponse? UpdateStatus(UpdateStatusRequest model, int id);

        IEnumerable<AllBookRequest> GetAllRequestDetail(int id);

        BookBorrowingRequest? CreateARequest( string name, int id);
    }
}
