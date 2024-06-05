using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ResponseModel
    {
        public bool status { get; set; } = true;

        public string message { get; set; } 

        public string data { get; set; }

    }
}
