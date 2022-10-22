using Buoi11_EF_2.Models;

namespace Buoi11_EF_2.Repositories
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {
            public CategoryRepository(ProductStoreContext context) : base(context)
        {
            
        }
    }
}