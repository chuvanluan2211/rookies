using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.DTOs.NormalUsers
{
    public class CreateARequestResponse
    {
        public int BookRequestId { get; set; }

        //public string Status { get; set; }

        public string RequestUser { get; set; }

        public DateTime DateOfRequest { get; set; }

        //public string AcceptUser { get; set; }

        public int UserId { get; set; }
    }
}
