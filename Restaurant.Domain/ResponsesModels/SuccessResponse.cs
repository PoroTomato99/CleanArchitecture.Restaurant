using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ResponsesModels
{
    public class SuccessResponse
    {
        private string type = $"Success";
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

        private string message = $"Success!";
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
        public SuccessResponse()
        {
        }

        //Customized Response
        public SuccessResponse(string type, string message)
        {
            Type = $"{this.type} : {type} ";
            Message = $"{this.message} {message}";
        }

        public override string ToString()
        {
            return $"Sucess : {Type} || Success Message : {Message}";
        }
    }
}
