using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Buoi6_MVC_3.Models
{
    public class PersonUpdateModel
    {
        [DisplayName("FirstName")]
        [Required(ErrorMessage = "FirstName is required!")]
        [MaxLength(12)]
        public string? FirstName { get; set; }

        [Required, DisplayName("LastName")]
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BirthDay { get; set; }

        public int Index { get; set; }

    }
}