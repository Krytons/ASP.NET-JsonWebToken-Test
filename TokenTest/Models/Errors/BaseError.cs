using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenTest.Models.Errors
{
    public class BaseError
    {
        public BaseError(string message)
        {
            Message = message;
            Time = DateTime.UtcNow;
        }

        public string Message { get; set; }

        public DateTime Time { get; set; }

    }
}
