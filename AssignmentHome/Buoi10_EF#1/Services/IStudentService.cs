using Buoi10_EF_1.Models;
using Buoi10_EF_1.DTOs;
using System.Linq.Expressions;

namespace Buoi10_EF_1.Services
{
    public interface IStudentService
    {
        AddStudentResponse Create(AddStudentRequest student);

        UpdateStudentResponse Update( Student student);

        Student GetStudent(int id);

        bool Delete(Student student);

        IEnumerable<Student> GetAll(string fName);

    }
}