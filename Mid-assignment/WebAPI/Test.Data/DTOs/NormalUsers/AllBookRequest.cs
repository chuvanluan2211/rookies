using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.DTOs.NormalUsers
{
    public class AllBookRequest
    {
        public int BookRequestId { get; set; }

        public string BookName { get; set; }

        public string Status { get; set; }
    }
}
