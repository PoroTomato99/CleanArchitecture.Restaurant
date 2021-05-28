using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class Response400
    {
        private string type = $"Error 400";
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        private string message = $"Bad Request!";
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public Response400()
        {
            Type = type;
            Message = message;
        }
        public Response400(string x)
        {
            Type = type;
            Message = $"{message} {x}";
        }
    }
}
