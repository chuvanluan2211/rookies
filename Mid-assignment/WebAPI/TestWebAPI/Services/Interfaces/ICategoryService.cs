using Test.Data.Entities;
using Test.Data.DTOs.Categories;

namespace TestWebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        CreateCateResponse? CreateCate(CreateCateRequest model);

        BookDetailResponse? UpdateCate(UpdateCateRequest model , int id);

        bool DeleteCate(DeleteCate model, int id);

        IEnumerable<Category> GetAllCategory();
    }
}
