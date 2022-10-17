using Buoi8_API.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buoi8_API.Controllers
{
    [Route("api/v1/[controller]")]
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/v1-new")]
        public int CreateANewTask([FromBody] NewTaskRequestModel requestModel)
        {
            var newId = 1;
            return newId;
        }

        [HttpPost("/v2-new")]
        public IActionResult CreateANewTask_v2([FromBody] NewTaskRequestModel requestModel)
        {
            //validate request model
            if (string.IsNullOrWhiteSpace(requestModel.Title))
            {
                return BadRequest("some mess");
            }
            requestModel.Title = requestModel.Title.Trim();
            if(requestModel.Title.Length < 5 || requestModel.Title.Length >10)
            {
                return BadRequest("some mess");
            }
            try
            {
                 var newId = 1;
            return Ok(newId);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

        [HttpGet("/v1-list")]
        public List<ListAllTask> ListAllTask([FromBody] ListAllTask requestModel)
        {
            List<ListAllTask> listTask = new List<ListAllTask>(); 
            return listTask;
        }

        [HttpGet("/v2-list")]
        public IActionResult ListAllTask_v2([FromBody] ListAllTask requestModel)
        {
            try
            {
                 var newId = 1;
            return Ok(newId);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

        [HttpGet("/v1-get")]
        public GetATask GetATask([FromBody] GetATask requestModel)
        {
            return Ok();
        }

        [HttpGet("/v2-get")]
        public IActionResult GetATask_v2([FromBody] GetATask requestModel)
        {
            try
            {
                 var newId = 1;
            return Ok(newId);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

         [HttpDelete("/v1-delete")]
        public DeleteATask DeleteATask([FromBody] DeleteATask requestModel)
        {
            return Ok();
        }

        [HttpDelete("/v2-delete")]
        public IActionResult DeleteATask_v2([FromBody] DeleteATask requestModel)
        {
            try
            {
                 var newId = 1;
            return Ok(newId);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

         [HttpPut("/v1-edit")]
        public EditATask EditATask([FromBody] EditATask requestModel)
        {
            return Ok();
        }

        [HttpPut("/v2-edit")]
        public IActionResult EditATask_v2([FromBody] EditATask requestModel)
        {
            try
            {
                 var newId = 1;
            return Ok(newId);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

        [HttpPost("/v1-bulkNew")]
        public int CreateMultipleTask([FromBody] BulkCreateTask requestModel)
        {
            var newId = 1;
            return newId;
        }

        [HttpPost("/v2-bulkNew")]
        public IActionResult CreateMultipleTask_v2([FromBody] BulkCreateTask requestModel)
        {
            //validate request model
            if (string.IsNullOrWhiteSpace(requestModel.Title))
            {
                return BadRequest("some mess");
            }
            requestModel.Title = requestModel.Title.Trim();
            if(requestModel.Title.Length < 5 || requestModel.Title.Length >10)
            {
                return BadRequest("some mess");
            }
            try
            {
                 var newId = 1;
            return Ok(newId);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

         [HttpDelete("/v1-bulkDelete")]
        public BulkDeleteTask DeleteMultipleTask([FromBody] BulkDeleteTask requestModel)
        {
            return Ok();
        }

        [HttpDelete("/v2-bulkDelete")]
        public IActionResult DeleteMultipleTask_v2([FromBody] BulkDeleteTask requestModel)
        {
            try
            {
                 var newId = 1;
            return Ok(newId);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}