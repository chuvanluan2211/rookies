using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Data.DTOs.NormalUsers;
using Test.Data.DTOs.SuperUsers;
using Test.Data.Entities;
using TestWebAPI.Services.Interfaces;

//using TestWebAPI.Services;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRequestController : ControllerBase
    {
        private IBookBorrowingRequestService _statusService;

        public BookRequestController(IBookBorrowingRequestService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("get-all-request")]
        public IEnumerable<AllBookRequest> GetAllBookUser(int id)
        {
            return _statusService.GetAllRequestDetail(id);
        }
        [HttpPut("update-status")]
        public UpdateStatusResponse? UpdateStatus(UpdateStatusRequest model , int id)
        {
            return _statusService.UpdateStatus(model , id);
        }

        [HttpPost("create-request")]
        public BookBorrowingRequest? CreateARequest( string name, int id)
        {
            var createRequest = _statusService.CreateARequest(name, id);
            if (createRequest == null)
            {
                //return new BookBorrowingRequest
                //{
                //    AcceptUser = "",
                //    BookRequestId = 0,
                //    RequestUser = "",
                //    Status = "",
                //    UserId = 0
                //};
                return null;
            }
            return createRequest;
        }
    }
}
