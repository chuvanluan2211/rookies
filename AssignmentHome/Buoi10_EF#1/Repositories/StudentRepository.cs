using Buoi10_EF_1.Models;

namespace Buoi10_EF_1.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context)
        {
        }
    }
}