using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class Response404
    {
        private string type = $"Error 404";
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
        private string message = $"Not Found!";
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

        public Response404()
        {
            Type = Type;
            Message = Message;
        }
        public Response404(string x)
        {
            Type = this.Type;
            Message = $"{x} {this.message}";
        }
    }
}
