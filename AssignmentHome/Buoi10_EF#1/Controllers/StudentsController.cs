using Microsoft.AspNetCore.Mvc;
using Buoi10_EF_1.Services;
using Buoi10_EF_1.DTOs;
using Buoi10_EF_1.Models;



namespace Buoi10_EF_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("create-student")]
        public AddStudentResponse Add(AddStudentRequest student)
        {
            return _studentService.Create(student);
        }

         [HttpPut("update-student")]
        public UpdateStudentResponse Update(Student student , int id)
        {
            var update = _studentService.GetStudent(id);

            if(update != null)
            {
                update.FirstName = student.FirstName;
                update.LastName = student.LastName;
                update.City = student.City;
                update.State = student.State;
            }
            return _studentService.Update(update);
        }

         [HttpDelete("delete-student")]
         public bool Delete(Student student , int id)
        {
            var delete = _studentService.GetStudent(id);

            _studentService.Delete(delete);

            return true;
        }

         [HttpGet("get-student")]
         public IEnumerable<Student> GetAll(string fName)
        {
            return _studentService.GetAll(fName);
        }

    }
}