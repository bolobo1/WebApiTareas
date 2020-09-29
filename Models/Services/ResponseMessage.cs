using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITareas.Models.Services
{
    public class ResponseMessage
    {
        public int Status {get; set;}
        public int Message { get; set; }
        public Object Data { get; set; }
    }
}
