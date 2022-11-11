using Test.Data.DTOs.NormalUsers;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestDetailService
    {
        CreateBookDetailResponse? CreateBookDetail(CreateBookDetailRequest model );


    }
}
