using Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test.Data.Entities
{
    public class BookBorrowingRequestDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestDetailId { get; set; }

        public ICollection<Book> Books { get; set; }

        [ForeignKey("BookBorrowingRequest")] 
        public int BookRequestId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

    }
}
