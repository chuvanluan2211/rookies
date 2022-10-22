using Buoi11_EF_2.Models;
using Buoi11_EF_2.DTOs;


namespace Buoi11_EF_2.Services
{
    public interface IProductService
    {
        CreateProductResponse? CreateProduct(CreateProduct model);

        UpdateProductResponse? UpdateProduct(UpdateProduct model , int id);

        bool DeleteProduct(DeleteProduct model , int id);

        IEnumerable<Product> GetAll();
    }
}