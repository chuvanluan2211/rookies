using Buoi11_EF_2.Repositories;
using Buoi11_EF_2.Models;

namespace Buoi11_EF_2.Repositories
{
    public class ProductRepository : BaseRepository<Product> , IProductRepository
    {
        public ProductRepository(ProductStoreContext context) : base(context)
        {
            
        }
    }
}