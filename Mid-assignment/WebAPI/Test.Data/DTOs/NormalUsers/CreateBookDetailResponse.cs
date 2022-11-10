using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.DTOs.NormalUsers
{
    public class CreateBookDetailResponse
    {
        public int RequestDetailId { get; set; }

        public int BookRequestId { get; set; }

        public int BookId { get; set; }
    }
}
