using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ResponsesModels
{
    public class Response
    {
        private string type = $"Type";
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

        private string message = $"Response Message";
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

        //Default Constructor
        public Response()
        {
        }

        //Customized Response
        public Response(string type, string message)
        {
            Type = $"{this.type} : {type} ";
            Message = $"{this.message} : {message}";
        }

        public override string ToString()
        {
            return $"Type : {Type} || Response Message : {Message}";
        }
    }
}
