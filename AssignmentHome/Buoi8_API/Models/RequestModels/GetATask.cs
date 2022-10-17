using System.ComponentModel.DataAnnotations;

namespace Buoi8_API.Models.RequestModels
{
    public class GetATask
    {
        [Required]
        [MaxLength(10)]
        [MinLength(4)]
        public string Title { get; set; } = null!;

        [Required]
        public bool IsCompleted { get; set; }
    }
}