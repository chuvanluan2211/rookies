using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.DTOs.Books
{
    public class CreateBookRequest
    {
        public string BookName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

    }
}
