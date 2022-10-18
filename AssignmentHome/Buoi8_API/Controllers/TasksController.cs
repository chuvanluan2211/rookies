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

        private Task CreateMultipleTask(List<NewTaskRequestModel> requestModels)
        {
            foreach (var requestModel in requestModels)
            {
                CreateMultipleTask_service_v1(requestModel);
            }
            _= SendEmail_v1();
            return Task.CompletedTask;
        }

        public void CreateMultipleTask_service_v1(NewTaskRequestModel requestModels)
        {
           System.Threading.Thread.Sleep(10);
        }

        private Task SendEmail_v1()
        {
            return Task.CompletedTask;
        }

        [HttpPost("/v1/bulkNew")]
        public IActionResult CreateMultipleTask_v1(List<NewTaskRequestModel> requestModels)
        {
           // to do validate model

           try
           {
            // create new task and get unique id
            var task = CreateMultipleTask(requestModels);

            return Accepted();
           }
           catch (Exception ex)
            {
                
                return StatusCode(500 , "mess:" +ex);
            }
        }

        [HttpPost("/v2/bulkNew")]
        public async Task<IActionResult> CreateMultipleTask_v2(List<NewTaskRequestModel> requestModels)
        {
           // to do validate model

           try
           {
            // create new task and get unique id
            _= CreateMultipleTask(requestModels);

            return Ok();
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