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
    public class BookRequestDetailController : ControllerBase
    {
        private IBookBorrowingRequestDetailService _detailService;

        public BookRequestDetailController(IBookBorrowingRequestDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpPost("create-request-detail")]
        public CreateBookDetailResponse? CreateBookDetail(CreateBookDetailRequest model)
        {
            return _detailService.CreateBookDetail(model);
        }
    }    
}


