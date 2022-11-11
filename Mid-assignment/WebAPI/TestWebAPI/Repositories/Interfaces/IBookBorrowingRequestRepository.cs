using Test.Data.DTOs.NormalUsers;
using Test.Data.Entities;

namespace TestWebAPI.Repositories.Interfaces
{
    public interface IBookBorrowingRequestRepository : IBaseRepository<BookBorrowingRequest>
    {
        public IList<AllBookRequest> GetAllBookUser(int id);

        public int CheckRequest(int id);
    }
}
