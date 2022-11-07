using Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test.Data.Entities
{
    public class BookBorrowingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookRequestId { get; set; }

        public string Status { get; set; }
        public string RequestUser { get; set; }
        public DateTime DateOfRequest { get; set; }

        public string AcceptUser { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<BookBorrowingRequestDetail> BorrowingRequestDetails { get; set; }

    }
}
