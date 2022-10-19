using Buoi10_EF_1.Repositories;
using Buoi10_EF_1.DTOs;
using Buoi10_EF_1.Models;
using System.Linq.Expressions;

namespace Buoi10_EF_1.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public AddStudentResponse Create(AddStudentRequest student)
        {
            var createStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State,
            };

            var result = _studentRepository.Create(createStudent);

            _studentRepository.SaveChanges();

            return new AddStudentResponse
            {
                StudentId = result.StudentId,
                FirstName = result.FirstName
            };
        }

        public bool Delete(Student student)
        {
            _studentRepository.Delete(student);
            _studentRepository.SaveChanges();

            return true;
        }

        public IEnumerable<Student> GetAll(string fName)
        {
            return _studentRepository.GetAll(x => x.FirstName.Contains(fName));

        }

        public Student GetStudent(int id)
        {
            var getStudent = _studentRepository.Get(x => x.StudentId == id);

            return getStudent;
        }

        public UpdateStudentResponse Update(Student student)
        {
            var result = _studentRepository.Update(student);
            _studentRepository.SaveChanges();

            return new UpdateStudentResponse
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                City = result.City,
                State = result.State,
            };
        }
    }
}