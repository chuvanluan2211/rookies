﻿using Test.Data.DTOs.SuperUsers;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestService
    {

        UpdateStatusResponse? UpdateStatus(UpdateStatusRequest model, int id);

        IEnumerable<BookBorrowingRequest> GetAll();
    }
}
