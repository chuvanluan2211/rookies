using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Data.DTOs.Categories;
using Test.Data.Entities;
using TestWebAPI.Services.Interfaces;

//using TestWebAPI.Services;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateController : ControllerBase
    {
        private ICategoryService _cateService;

        public CateController(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        [HttpPost("create-category")]
        public CreateCateResponse? CreateCategory(CreateCateRequest model)
        {
            return _cateService.CreateCate(model);
        }

        [HttpGet("get-allcate")]
        public IEnumerable<Category> GetAll()
        {
            return _cateService.GetAll();
        }

        [HttpPut("update-category")]
        public UpdateCateResponse? UpdateCategory(UpdateCateRequest model , int id)
        {
            return _cateService.UpdateCate(model , id);
        }

        [HttpDelete("delete-category")]
        public bool DeleteCategory(DeleteCate model , int id)
        {
            return _cateService.DeleteCate(model, id);
        }

    }
}
