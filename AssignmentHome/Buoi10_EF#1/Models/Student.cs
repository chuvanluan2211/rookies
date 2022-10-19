namespace Buoi10_EF_1.Models
{
    public class Student : BaseEntity<int>
    {
        public string? FirstName {get; set;} 
        public string? LastName {get; set;} 
        public string? City {get; set;} 
        public string? State {get; set;} 
    }
}