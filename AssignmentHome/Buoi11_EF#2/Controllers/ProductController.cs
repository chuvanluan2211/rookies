using Buoi11_EF_2.Services;
using Buoi11_EF_2.DTOs;
using Microsoft.AspNetCore.Mvc;
using Buoi11_EF_2.Models;

namespace Buoi11_EF_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product) 
        {
            _product = product;
        }

        [HttpPost("create-newproduct")]
        public CreateProductResponse? CreateProduct([FromBody] CreateProduct model)
        {
            return _product.CreateProduct(model);
        }

        [HttpPut("update-product")]
        public UpdateProductResponse? UpdateProduct(UpdateProduct model ,int id)
        {
            return _product.UpdateProduct(model , id);
        }

        [HttpDelete("delete-product")]
        public bool DeleteProduct(DeleteProduct model , int id)
        {
            return _product.DeleteProduct(model, id);
        }

        [HttpGet("get-productlist")]
        public  IEnumerable<Product> GetAll()
        {
            return _product.GetAll();
        }



    }
}