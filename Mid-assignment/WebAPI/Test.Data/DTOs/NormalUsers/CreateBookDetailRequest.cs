using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.DTOs.NormalUsers
{
    public class CreateBookDetailRequest
    {
        public int BookRequestId { get; set; }

        public int BookId { get; set; }
    }
}
