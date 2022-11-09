using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get-allcate")]
        public IEnumerable<BookBorrowingRequest> GetAll()
        {
            return _statusService.GetAll();
        }

        [HttpPut("update-category")]
        public UpdateStatusResponse? UpdateCategory(UpdateStatusRequest model , int id)
        {
            return _statusService.UpdateStatus(model , id);
        }

    }
}
