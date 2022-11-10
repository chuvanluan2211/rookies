using Test.Data.DTOs.Categories;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _category;

        public CategoryService( ICategoryRepository category)
        {
            _category = category;
        }
        public CreateCateResponse? CreateCate(CreateCateRequest model)
        {
            using (var transaction = _category.DatabaseTransaction())
            {
                try
                {
                        var cate = new Category
                        {
                            CategoryName = model.CategoryName
                        };

                        var newCate = _category.Create(cate);

                        _category.SaveChanges();
                        transaction.Commit();

                        return new CreateCateResponse
                        {
                            CategoryId = newCate.CategoryId,
                            CategoryName = newCate.CategoryName,
                        };
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public bool DeleteCate(DeleteCate model , int id)
        {
            using (var transaction = _category.DatabaseTransaction())
            {
                try
                {
                    var cate = _category.GetById(s => s.CategoryId == id);

                    if (cate != null)
                    {
                        var updateCate = _category.Delete(cate);
                        _category.SaveChanges();
                        transaction.Commit();
                    }
                    return true;
                }
                catch
                {
                    transaction.RollBack();
                    return true;
                }
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _category.GetAll(s => true);
        }

        public BookDetailResponse? UpdateCate(UpdateCateRequest model , int id)
        {
            using (var transaction = _category.DatabaseTransaction())
            {
                try
                {
                    var cate = _category.GetById(s => s.CategoryId == id);

                    if (cate != null)
                    {
                        cate.CategoryName = model.CategoryName;

                        var updateBook = _category.Update(cate);

                        _category.SaveChanges();
                        transaction.Commit();

                        return new BookDetailResponse
                        {
                            CategoryId = updateBook.CategoryId,
                            CategoryName = updateBook.CategoryName,
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
