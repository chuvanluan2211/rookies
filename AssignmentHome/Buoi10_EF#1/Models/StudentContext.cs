using Microsoft.EntityFrameworkCore;
namespace Buoi10_EF_1.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options): base(options)
        {
        } 
        public DbSet<Student> Students {get; set;} = null!;
    }
}