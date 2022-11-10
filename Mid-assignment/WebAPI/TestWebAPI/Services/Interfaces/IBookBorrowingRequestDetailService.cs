using Test.Data.DTOs.NormalUsers;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestDetailService
    {
        IEnumerable<BookBorrowingRequestDetail> GetAll(int id);

        CreateBookDetailResponse? CreateBookDetail(CreateBookDetailRequest model );


    }
}
