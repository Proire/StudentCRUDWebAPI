using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    internal class ResponseModel(bool status, string message, string data)
    {
        public bool status { get; set; } = status;

        public string message { get; set; } = message;

        public string data { get; set; } = data;

    }
}
