using Buoi11_EF_2.DTOs;
using Buoi11_EF_2.Repositories;
using Buoi11_EF_2.Models;

namespace Buoi11_EF_2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;

        private readonly ICategoryRepository _category;


        public ProductService(IProductRepository product, ICategoryRepository category)
        {
            _product = product;
            _category = category;
        }

        public CreateProductResponse? CreateProduct(CreateProduct model)
        {
            using (var transaction = _product.DatabaseTransaction())
            {
                try
                {
                    var cate = _category.GetById(s => s.CategoryId == model.CategoryId);

                    if (cate != null)
                    {
                        var product = new Product
                        {
                            ProductName = model.ProductName,
                            Manufature = model.Manufature,
                            CategoryId = cate.CategoryId
                        };

                        var newProduct = _product.Create(product);

                        _product.SaveChanges();
                        transaction.Commit();

                        return new CreateProductResponse
                        {
                            ProductId = newProduct.ProductId,
                            ProductName = newProduct.ProductName,
                            Manufature = newProduct.Manufature,
                            CategoryId = newProduct.CategoryId
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

        public bool DeleteProduct(DeleteProduct model , int id)
        {
            using (var transaction = _product.DatabaseTransaction())
            {
                try
                {
                    var product = _product.GetById(s => s.ProductId == id);

                    if (product != null)
                    {
                        var updateProduct = _product.Delete(product);
                        _product.SaveChanges();
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

        public IEnumerable<Product> GetAll()
        {
            return _product.GetAll(s => true);
        }

        public UpdateProductResponse? UpdateProduct(UpdateProduct model , int id)
        {
            using (var transaction = _product.DatabaseTransaction())
            {
                try
                {
                    var product = _product.GetById(s => s.ProductId == id);

                    if (product != null)
                    {
                        product.ProductName = model.ProductName;
                        product.Manufature = model.Manufature;
                        product.CategoryId = model.CategoryId;

                        var updateProduct = _product.Update(product);

                        _product.SaveChanges();
                        transaction.Commit();

                        return new UpdateProductResponse
                        {
                            ProductId = updateProduct.ProductId,
                            ProductName = updateProduct.ProductName,
                            Manufature = updateProduct.Manufature,
                            CategoryId = updateProduct.CategoryId
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